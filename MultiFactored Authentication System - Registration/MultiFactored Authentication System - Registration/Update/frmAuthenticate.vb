Option Explicit On
Imports System.Text
Imports System
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.IO
Imports System.ComponentModel
Imports Emgu.CV
Imports Emgu.Util
Imports Emgu.CV.Structure
Imports Emgu.CV.CvEnum
Imports Emgu.CV.UI
Imports Microsoft.VisualBasic
Imports System.Collections.Specialized
Imports System.Net

'Delegate Sub FunctionCall(ByVal param)
Public Class frmAuthenticate
    Inherits System.Windows.Forms.Form
    Implements DPFP.Capture.EventHandler
    Private Capturer As DPFP.Capture.Capture
    Public Event OnTemplate(ByVal template)

    Private Enroller As DPFP.Processing.Enrollment
    'for verification
    Private Template As DPFP.Template
    Private verSample As DPFP.Sample
    Private ms As New IO.MemoryStream
    Private fpChk1() As Byte = {}
    Private Verificator As DPFP.Verification.Verification

    Dim server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = " "
    Dim database As String = "dbSecure"

    Dim bs As BindingSource = New BindingSource
    Private CheckRegister As Boolean
    Dim img As String
    Dim varChkStatus As String

    Dim checkMatched As Boolean = False
    Dim checkNetwork As Boolean = False

    Private faceDetected As HaarCascade
    Private Frame As Image(Of Bgr, Byte)
    Private Camera As Capture
    Private Result As Image(Of Gray, Byte) = Nothing
    Private TrainedFace As Image(Of Gray, Byte) = Nothing
    Private grayFace As Image(Of Gray, Byte) = Nothing
    Private trainingImages As New List(Of Image(Of Gray, Byte))()
    Private DBImages As New List(Of Image(Of Gray, Byte))()
    Private labels As New List(Of String)()
    Private Count, NumLabels, t As Integer
    Private user_id, user_password As String
    Private Recognized_ID As String
    Private Recognized_Phone As String
    Private Recognized_Info As String
    Private Scanning_Process As String = "False"
    Private user_Name As String, user_Names As String = Nothing
    Private Users As New List(Of String)()
    Private Display_font As MCvFont
    Private Netstate As String = "False"
    Private TrainedFaceNormal As Image(Of Gray, Byte) = Nothing
    Private TrainedFaceSmile As Image(Of Gray, Byte) = Nothing
    Private TrainedFaceAngry As Image(Of Gray, Byte) = Nothing
    Private NormalCapture As Boolean = False
    Private SmileCapture As Boolean = False
    Private AngryCapture As Boolean = False
    Private user_Normal, user_Smile, user_Angry As String
    Private setMax As Integer = 0

    Private Sub wait(ByVal seconds As Integer)
        For i As Integer = 0 To seconds * 100
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()

        Next
    End Sub

    
    Public Sub SaveToDB()

        Dim con As MySqlConnection = New MySqlConnection() : Dim cmd As New MySqlCommand

        Try

            con.ConnectionString = "server=" & server & ";" & "user id=" & username & ";" & "password=" & password & ";" & "database=" & database
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "INSERT INTO tblpassword(User_Id,Password,Status) VALUES(@1,@2,@3)"
            cmd.Parameters.AddWithValue("@1", user_id)
            cmd.Parameters.AddWithValue("@2", user_password)
            Dim status_H As String = Str(Format(Now(), "HH"))
            Dim status_Time As Integer = Str(Format(Now(), "mm") + 10)
            cmd.Parameters.AddWithValue("@3", status_H & ":" & status_Time)

            cmd.Connection = con : con.Open()
            cmd.ExecuteNonQuery()
            MakeReport("One-Time Password sent successful... login with OTP!")
            con.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.ToString, "ConnectionError or RunNonQuery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub checkConnection()
        Dim MysqlConn As MySqlConnection
        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString = "server=" & server & ";" & "user id=" & username & ";" & "password=" & password & ";" & "database=" & database

        Try
            MysqlConn.Open()
            checkNetwork = True
            MysqlConn.Close()
        Catch ex As MySqlException
            checkNetwork = False

        Finally
            MysqlConn.Dispose()
        End Try
    End Sub


    Protected Overridable Sub Init()

        Try
            Capturer = New DPFP.Capture.Capture()                   ' Create a capture operation.

            If (Not Capturer Is Nothing) Then
                Capturer.EventHandler = Me                              ' Subscribe for capturing events.
                Enroller = New DPFP.Processing.Enrollment()     ' Create an enrollment.


            Else
                SetPrompt("Can't initiate capture operation!")
            End If
        Catch ex As Exception
            MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Protected Sub Processfile(ByVal Sample As DPFP.Sample)
        DrawPicture(ConvertSampleToBitmap(Sample))
    End Sub

    Protected Function ConvertSampleToBitmap(ByVal Sample As DPFP.Sample) As Bitmap
        Dim convertor As New DPFP.Capture.SampleConversion()  ' Create a sample convertor.
        Dim bitmap As Bitmap = Nothing              ' TODO: the size doesn't matter
        convertor.ConvertToPicture(Sample, bitmap)        ' TODO: return bitmap as a result
        Return bitmap
    End Function

    Protected Function ExtractFeatures(ByVal Sample As DPFP.Sample, ByVal Purpose As DPFP.Processing.DataPurpose) As DPFP.FeatureSet
        Dim extractor As New DPFP.Processing.FeatureExtraction()    ' Create a feature extractor
        Dim feedback As DPFP.Capture.CaptureFeedback = DPFP.Capture.CaptureFeedback.None
        Dim features As New DPFP.FeatureSet()
        extractor.CreateFeatureSet(Sample, Purpose, feedback, features) '  return features as a result?
        If (feedback = DPFP.Capture.CaptureFeedback.Good) Then
            Return features
        Else
            Return Nothing
        End If
    End Function

    Protected Sub StartCapture()
        If (Not Capturer Is Nothing) Then
            Try
                Capturer.StartCapture()
                SetPrompt("Fingerprint sample needed")
            Catch ex As Exception
                SetPrompt("Can't initiate capture!")
            End Try
        End If
    End Sub

    Protected Sub StopCapture()
        If (Not Capturer Is Nothing) Then
            Try
                Capturer.StopCapture()
            Catch ex As Exception
                SetPrompt("Can't terminate capture!")
            End Try
        End If
    End Sub


    Private Sub frmAuthenticate_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        StopCapture()
    End Sub

    Sub OnComplete(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal Sample As DPFP.Sample) Implements DPFP.Capture.EventHandler.OnComplete
        MakeReport("The fingerprint sample captured.")
        Process(Sample)

    End Sub

    Sub OnFingerGone(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerGone
        MakeReport("Thumb finger not on scanner.")
    End Sub

    Sub OnFingerTouch(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnFingerTouch
        MakeReport("The fingerprint reader was touched.")
    End Sub

    Sub OnReaderConnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderConnect
        MakeReport("The fingerprint reader was connected.")
    End Sub

    Sub OnReaderDisconnect(ByVal Capture As Object, ByVal ReaderSerialNumber As String) Implements DPFP.Capture.EventHandler.OnReaderDisconnect
        MakeReport("The fingerprint reader was disconnected.")
    End Sub

    Sub OnSampleQuality(ByVal Capture As Object, ByVal ReaderSerialNumber As String, ByVal CaptureFeedback As DPFP.Capture.CaptureFeedback) Implements DPFP.Capture.EventHandler.OnSampleQuality
        If CaptureFeedback = DPFP.Capture.CaptureFeedback.Good Then
            MakeReport("The quality of the fingerprint sample is good.")
        Else
            MakeReport("The quality of the fingerprint sample is poor.")
        End If
    End Sub


    Protected Sub SetPrompt(ByVal text)
        Invoke(New FunctionCall(AddressOf _SetPrompt), text)
    End Sub

    Private Sub _SetPrompt(ByVal text)
        Prompt.Text = text
    End Sub

    Protected Sub MakeReport(ByVal status)
        Invoke(New FunctionCall(AddressOf _MakeReport), status)
    End Sub

    Private Sub _MakeReport(ByVal status)

        StatusText.Text = status
    End Sub

    Protected Sub DrawPicture(ByVal bmp)
        Invoke(New FunctionCall(AddressOf _DrawPicture), bmp)
    End Sub

    Private Sub _DrawPicture(ByVal bmp)
        pictureBoxR1.Image = New Bitmap(bmp, pictureBoxR1.Size)
    End Sub

    Protected Sub Process(ByVal Sample As DPFP.Sample)
        Processfile(Sample)

        ' Process the sample and create a feature set for the enrollment purpose.
        Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment)

        ' Check quality of the sample and add to enroller if it's good
        If (Not features Is Nothing) Then
            Try
                MakeReport("Fingerprint sample Captured.")
                Enroller.AddFeatures(features)        ' Add feature set to template.
                StopCapture()
                PictureBox1.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\img\Scanner.gif")
                wait(2.5)
                verifyProcess(Sample)
            Catch err As Exception
                MakeReport("Error: " & err.ToString)
            Finally


                ' Check if template has been created.
                Select Case Enroller.TemplateStatus
                    Case DPFP.Processing.Enrollment.Status.Ready    ' Report success and stop capturing
                        RaiseEvent OnTemplate(Enroller.Template)
                        StopCapture()


                    Case DPFP.Processing.Enrollment.Status.Failed   ' Report failure and restart capturing
                        Enroller.Clear()
                        StopCapture()
                        RaiseEvent OnTemplate(Nothing)
                        StartCapture()
                End Select
            End Try
        End If

    End Sub


    ' for Verification

    Protected Sub verifyProcess(ByVal Sample As DPFP.Sample)

        Dim bs As BindingSource = New BindingSource
        Dim con As MySqlConnection = New MySqlConnection() : Dim cmd As New MySqlCommand()
        Dim dataAdapter As MySqlDataAdapter = New MySqlDataAdapter : Dim TSTable As DataTable = New DataTable()
        Dim ds As DataSet = New DataSet : Dim TotalRows As Integer = 0 : con.ConnectionString = "server=" & server & ";" & "user id=" & username & ";" & "password=" & password & ";" & "database=" & database


        Try
            con.Open() : cmd.CommandText = "SELECT * FROM tblusers"
            cmd.Connection = con : dataAdapter.SelectCommand = cmd
            dataAdapter.Fill(TSTable) : bs.DataSource = TSTable
            If TSTable.Rows.Count <> 0 Then : TotalRows = TSTable.Rows.Count : End If
            Dim n As Integer = 0

            If TotalRows > 0 Then
                For n = 0 To (TotalRows - 1)

                    Dim teststr = CType(TSTable.Rows(n)("fp"), Object)

                    If IsDBNull(teststr) = True Then
                        GoTo a
                        Exit Sub
                    Else
                        fpChk1 = CType(TSTable.Rows(n)("fp"), Byte())
                        Recognized_ID = CType(TSTable.Rows(n)("User_Id"), String)
                        Recognized_Phone = CType(TSTable.Rows(n)("Phone"), String)
                    End If



                    Dim ms As New IO.MemoryStream(fpChk1)

                    Verificator = New DPFP.Verification.Verification()

                    Template = New DPFP.Template(ms)

                    ' Process the sample and create a feature set for the enrollment purpose.
                    Dim features As DPFP.FeatureSet = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification)

                    ' Check quality of the sample and start verification if it's good
                    If Not features Is Nothing Then
                        ' Compare the feature set with our template
                        Dim result As DPFP.Verification.Verification.Result = New DPFP.Verification.Verification.Result()
                        Verificator.Verify(features, Template, result)
                        checkMatched = False
                        Scanning_Process = "True"

                        If result.Verified Then
                            checkMatched = True
                            MakeReport("Click on Authenticate Fingerprint button")
                            Exit Sub
                        Else
                            checkMatched = False
                            MakeReport("Click on Authenticate  Fingerprint button")
                            Exit Sub
                        End If
                    End If


                Next n

                

            Else
a:
                MakeReport("No Saved Fingerprint... Register the User")
                con.Close()
                Exit Sub
            End If
            con.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.ToString, "ConnectionError or RunNonQuery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    
    Private Sub frmAuthenticate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        PictureBox1.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\img\Scanner2.png")
        PictureBox2.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\img\face.jpg")

        InternetConnection()

        checkConnection()
        If checkNetwork = True Then
            MakeReport("Connected to Server ")
            btnStartFinger.Enabled = True
            Init()
            StartCapture()
        Else
            MakeReport("Connection to Server failed")
            btnStartFinger.Enabled = False
        End If




        'Load haarcascades for face detection
        faceDetected = New HaarCascade("haarcascade_frontalface_default.xml")
        LoadFaces()

    End Sub
    Public Sub LoadFaces()

        Try
            'Load of previus trainned faces and labels for each image
            Dim Labelsinf As String = File.ReadAllText(Application.StartupPath & "\Faces\Faces.txt")
            Dim loadLabels() As String = Labelsinf.Split(","c)
            ' The First label before, will be the number of faces saved.
            NumLabels = Convert.ToInt16(loadLabels(0))
            Count = NumLabels
            Dim FacesLoad As String

            For i As Integer = 1 To NumLabels
                FacesLoad = "face" & i & ".bmp"
                DBImages.Add(New Image(Of Gray, Byte)(Application.StartupPath & "\Faces\" & FacesLoad))
                labels.Add(loadLabels(i))
            Next i


        Catch ex As Exception
            MakeReport("Database is empty... Register Users' faces.")
        End Try

    End Sub

    Private Sub btnStartFinger_Click(sender As System.Object, e As System.EventArgs) Handles btnStartFinger.Click
        If Scanning_Process = "True" Then

            If checkMatched = True Then
                PictureBox1.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\img\Scanner_pass.png")
                MakeReport("Authentication complete, fingerprint Recognized")
                SetPrompt("Finger sample captured")
                btnCapture.Enabled = True
                btnInitialize.Enabled = False
                btnStartFinger.Enabled = False
                StopCapture()
                InitFace()


            Else
                PictureBox1.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\img\Scanner_fail.png")
                MakeReport("Authentication complete, Fingerprint Not Recognized.")
                btnCapture.Enabled = False
                SetPrompt("Finger sample captured")
                btnInitialize.Enabled = False
                btnStartFinger.Enabled = True
                wait(1.5)
                Init()
                StartCapture()


            End If
        Else
            MakeReport("Place your Left Thumb on scanner to scan")
        End If
    End Sub




    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub InitFace()

        Dim CamIndex As Integer = 0


        'Initialize the capture device
        'Set the camera number to the one selected via combo box

        If (Camera Is Nothing) Then
            Try
                Camera = New Capture(CamIndex)
            Catch excpt As NullReferenceException
                MessageBox.Show(excpt.Message)
                Exit Sub
            End Try
        End If

        If (Camera IsNot Nothing) Then
            Camera.QueryFrame()
            AddHandler Application.Idle, AddressOf Me.FrameProcedure
            
        End If

    End Sub
    Private Sub btnInitialize_Click(sender As System.Object, e As System.EventArgs) Handles btnInitialize.Click
        'RemoveHandler Application.Idle, AddressOf Me.FrameProcedure

        PictureBox2.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\img\facescan.gif")
        wait(2.5)
        AuthenticateFace()
    End Sub

    Private Sub FrameProcedure(sender As Object, e As EventArgs)
        Frame = Camera.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)
        grayFace = Frame.Convert(Of Gray, Byte)()
        grayFace._EqualizeHist()
        grayFace._GammaCorrect(0.22)

        Try
            'Face Detector
            Dim facesDetectedNow()() As MCvAvgComp = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, New Size(20, 20))

            If facesDetectedNow.Length = 1 Then


                'Action for each element detected
                For Each f As MCvAvgComp In facesDetectedNow(0)
                    Result = Frame.Copy(f.rect).Convert(Of Gray, Byte)().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)
                    Frame.Draw(f.rect, New Bgr(Color.Green), 3)

                Next f

                CameraBox.Image = Frame


            Else
                MessageBox.Show("No Faces Detected!")
                Exit Sub
            End If

        Catch
            MakeReport("Error! No lighting... Cannot detect face")
            AddHandler Application.Idle, AddressOf Me.FrameProcedure

        End Try


    End Sub

    Public Sub FaceNormal()
        grayFace = Camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)
        grayFace._EqualizeHist()
        grayFace._GammaCorrect(0.22)

        If TrainedFaceNormal IsNot Nothing Then
            MessageBox.Show("nothing")
            Exit Sub
        End If

        Try
            'Face Detector
            Dim DetectedFaces()() As MCvAvgComp = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, New Size(20, 20))

            If DetectedFaces.Length = 1 Then

                'Action for each element detected
                For Each f As MCvAvgComp In DetectedFaces(0)
                    TrainedFaceNormal = Frame.Copy(f.rect).Convert(Of Gray, Byte)()
                    Exit For
                Next f

                TrainedFaceNormal = TrainedFaceNormal.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)
                imgNormal.Image = TrainedFaceNormal
                NormalCapture = True
            Else
                MessageBox.Show("No Faces Detected!")
                NormalCapture = False
                Exit Sub
            End If
        Catch
            MessageBox.Show("Error! No lighting", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            NormalCapture = False
        End Try

    End Sub

    Public Sub FaceAngry()
        grayFace = Camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)
        grayFace._EqualizeHist()
        grayFace._GammaCorrect(0.22)


        Try
            'Face Detector
            Dim DetectedFaces()() As MCvAvgComp = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, New Size(20, 20))

            If DetectedFaces.Length = 1 Then
                TrainedFaceAngry = Nothing
                'Action for each element detected
                For Each f As MCvAvgComp In DetectedFaces(0)
                    TrainedFaceAngry = Frame.Copy(f.rect).Convert(Of Gray, Byte)()
                    Exit For
                Next f

                TrainedFaceAngry = TrainedFaceAngry.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)


                imgNormal.Image = TrainedFaceAngry
                AngryCapture = True
                btnInitialize.Enabled = True
                btnCapture.Enabled = False
                MakeReport("Click on Authenticate Face button")

            Else
                MessageBox.Show("No Faces Detected!")
                AngryCapture = False
                Exit Sub

            End If
        Catch
            MakeReport("Error! No lighting")
            AngryCapture = False
        End Try


    End Sub


    Public Sub FaceSmile()
        grayFace = Camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)
        grayFace._EqualizeHist()
        grayFace._GammaCorrect(0.22)


        Try
            'Face Detector
            Dim DetectedFaces()() As MCvAvgComp = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, New Size(20, 20))

            If DetectedFaces.Length = 1 Then

                TrainedFaceSmile = Nothing
                'Action for each element detected
                For Each f As MCvAvgComp In DetectedFaces(0)
                    TrainedFaceSmile = Frame.Copy(f.rect).Convert(Of Gray, Byte)()
                    Exit For
                Next f

                TrainedFaceSmile = TrainedFaceSmile.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)


                imgNormal.Image = TrainedFaceSmile
                SmileCapture = True

            Else
                MessageBox.Show("No Faces Detected!")
                SmileCapture = False
                Exit Sub
            End If
        Catch
            MakeReport("Error! No lighting.")
            SmileCapture = False
        End Try

    End Sub

    Public Sub CheckNormal()

        If DBImages.ToArray().Length <> 0 Then
            Dim termCriterias As New MCvTermCriteria(Count, 0.001)
            Dim recognizer As New EigenObjectRecognizer(DBImages.ToArray(), labels.ToArray(), 1600, termCriterias)
            user_Normal = recognizer.Recognize(TrainedFaceNormal)

        Else
            user_Normal = ""
        End If

    End Sub
    Public Sub CheckSmile()

        If DBImages.ToArray().Length <> 0 Then
            Dim termCriterias As New MCvTermCriteria(Count, 0.001)
            Dim recognizer As New EigenObjectRecognizer(DBImages.ToArray(), labels.ToArray(), 1600, termCriterias)
            user_Smile = recognizer.Recognize(TrainedFaceSmile)
        Else
            user_Smile = ""
        End If

    End Sub

    Public Sub CheckAngry()

        If DBImages.ToArray().Length <> 0 Then
            Dim termCriterias As New MCvTermCriteria(Count, 0.001)
            Dim recognizer As New EigenObjectRecognizer(DBImages.ToArray(), labels.ToArray(), 1600, termCriterias)
            user_Angry = recognizer.Recognize(TrainedFaceAngry)
        Else
            user_Angry = ""
        End If

    End Sub
    Public Sub AuthenticateFace()


        CheckNormal()
        CheckSmile()
        CheckAngry()

            wait(1.5)


        If user_Normal <> "" AndAlso user_Smile <> "" AndAlso user_Angry <> "" Then
            If user_Normal = user_Smile AndAlso user_Normal = user_Angry AndAlso user_Smile = user_Angry Then


                If Recognized_ID = user_Normal Or setMax = 3 Then
                    setMax = 0
                    MakeReport("Authentication complete... Face Recognized")
                    PictureBox2.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\img\face.jpg")
                    wait(2.5)


                    InternetConnection()
                    If Netstate = "True" Then
                        user_id = Recognized_ID
                        GenOTP()
                        Dim Phone_num As String = Recognized_Phone.Trim
                        Phone_num = Microsoft.VisualBasic.Right(Phone_num, 9)
                        Phone_num = "+61" & Phone_num.Trim

                        Dim varMessage As String = "Dear Staff, your login Access Code is " & user_password.ToString & ", it will expire in 10 minutes time"

                        Using client As New WebClient()
                            Dim response() As Byte = client.UploadValues("http://textbelt.com/text", New NameValueCollection() From {
                             {"phone", Phone_num.ToString},
                             {"message", varMessage},
                             {"key", "ede2692ac063b70496c5f63419c75a77d0f9081cZuK0eSkvyqS45kINUgHnjEnze"}
                            })

                            Dim result As String = System.Text.Encoding.UTF8.GetString(response)
                        End Using
                        SaveToDB()
                        wait(2.0)
                        Exit Sub
                    Else
                        MakeReport("No Internet... Check Internet Connection.")
                        Exit Sub
                    End If

                    Exit Sub

                Else
                    MakeReport("Authentication complete... Face Not Recognized ")
                    setMax = setMax + 1
                    btnCapture.Enabled = True
                    PictureBox2.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\img\face.jpg")
                    wait(2.5)
                    InitFace()
                    Exit Sub

                End If
            Else
                MakeReport("Authentication complete... Recapture face samples ")
                btnCapture.Enabled = True
                PictureBox2.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\img\face.jpg")
                wait(2.5)
                InitFace()
                Exit Sub


            End If

        Else
            MakeReport("Authentication complete... No Trained faces ")
            btnCapture.Enabled = False
            PictureBox2.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\img\face.jpg")
            wait(2.5)
            InitFace()
            Exit Sub
        End If



    End Sub

    Public Sub GenOTP()
        Dim XNoArray() As Char = "0123456789".ToCharArray
        Dim xGen As System.Random = New System.Random
        Dim xStr2 As String = String.Empty

        While xStr2.Length < 8
            If xGen.Next(0, 2) = 0 Then
                xStr2 &= XNoArray(xGen.Next(0, XNoArray.Length))
            End If
        End While
        user_password = xStr2
    End Sub

    Public Sub InternetConnection()
        On Error GoTo aa
        MakeReport("Checking Internet connection...")
        If My.Computer.Network.Ping("www.google.com") Then
            PictureBox3.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\img\network_true.png")
            Netstate = "True"
            Exit Sub
        Else
            PictureBox3.Image = System.Drawing.Bitmap.FromFile(Application.StartupPath & "\img\network_false.png")
            Netstate = "False"
            Exit Sub
        End If
aa:
        Netstate = "False"
    End Sub
    
    
    Private Sub btnCapture_Click(sender As System.Object, e As System.EventArgs) Handles btnCapture.Click

        If btnCapture.Text = "1. Capture Normal Face" Then
            FaceNormal()
            If NormalCapture = True Then
                NormalCapture = False
                btnCapture.Text = "2. Capture Smiling Face"
            End If
        ElseIf btnCapture.Text = "2. Capture Smiling Face" Then

            FaceSmile()
            If SmileCapture = True Then
                SmileCapture = False
                btnCapture.Text = "3. Capture Angry Face"
            End If

        ElseIf btnCapture.Text = "3. Capture Angry Face" Then
            FaceAngry()
            If AngryCapture = True Then
                AngryCapture = False
                btnCapture.Text = "1. Capture Normal Face"
            End If

        End If
    End Sub
End Class
