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

Delegate Sub FunctionCall(ByVal param)
Public Class frmRegister
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
    Private TrainedFaceNormal As Image(Of Gray, Byte) = Nothing
    Private TrainedFaceSmile As Image(Of Gray, Byte) = Nothing
    Private TrainedFaceAngry As Image(Of Gray, Byte) = Nothing
    Private grayFace As Image(Of Gray, Byte) = Nothing
    Private trainingImages As New List(Of Image(Of Gray, Byte))()
    Private DBImages As New List(Of Image(Of Gray, Byte))()
    Private labels As New List(Of String)()
    Private Users As New List(Of String)()
    Private Count, NumLabels, t As Integer
    Private user_Name As String, user_Names As String = Nothing
    Private user_Normal, user_Smile, user_Angry As String
    Private Display_font As MCvFont
    Public SerialNumber As String





    Private Sub wait(ByVal seconds As Integer)
        For i As Integer = 0 To seconds * 100
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()

        Next
    End Sub

    Public Sub GenId()
        Dim XNoArray() As Char = "0123456789".ToCharArray
        Dim xCharArray() As Char = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz".ToCharArray
        Dim xGen As System.Random = New System.Random
        Dim xStr2 As String = String.Empty
        Dim xStr1 As String = String.Empty

        While xStr2.Length < 8
            If xGen.Next(0, 2) = 0 Then
                xStr2 &= XNoArray(xGen.Next(0, XNoArray.Length))
            End If
        End While

        While xStr1.Length < 2
            If xGen.Next(0, 2) = 0 Then
                xStr1 &= xCharArray(xGen.Next(0, xCharArray.Length))
            End If
        End While
        lblID.Text = xStr1 & "" & xStr2

    End Sub

    Public Sub SaveToDB()
        Dim ms As New IO.MemoryStream
        ms = New MemoryStream()
        'PictureBox1.Image.Save(ms, Imaging.ImageFormat.Png)
        Dim photoArray(ms.Length - 1) As Byte
        ms.Position = 0
        ms.Read(photoArray, 0, photoArray.Length)




        Template = New DPFP.Template
        Template = Enroller.Template

        Dim memstream As New IO.MemoryStream
        Template.Serialize(memstream)

        Dim fingerArray(memstream.Length - 1) As Byte
        memstream.Position = 0
        memstream.Read(fingerArray, 0, fingerArray.Length)



        Dim con As MySqlConnection = New MySqlConnection() : Dim cmd As New MySqlCommand

        Try

            con.ConnectionString = "server=" & server & ";" & "user id=" & username & ";" & "password=" & password & ";" & "database=" & database
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "INSERT INTO tblusers(User_Id,Name,Gender,Phone,fp,Dates) VALUES(@1,@2,@3,@4,@5,@6)"
            cmd.Parameters.AddWithValue("@1", lblID.Text)
            cmd.Parameters.AddWithValue("@2", txtName.Text)
            cmd.Parameters.AddWithValue("@3", cboSex.Text)
            cmd.Parameters.AddWithValue("@4", txtPhone.Text)
            cmd.Parameters.AddWithValue("@5", fingerArray)
            Dim [Edate] As String = Format(dtpDate.Value.Date, "yyyy-MM-dd")
            cmd.Parameters.AddWithValue("@6", [Edate])

            cmd.Connection = con : con.Open()
            cmd.ExecuteNonQuery()
            MessageBox.Show("Registration was successful!")
            con.Close()
            SaveFaces()
            clsClear()

        Catch ex As MySqlException
            MessageBox.Show(ex.ToString, "ConnectionError or RunNonQuery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub clsClear()
        GenId()
        txtName.Clear()
        cboSex.Text = "Select"
        txtPhone.Clear()
        dtpDate.Text = ""

        imgNormal.Image = Nothing
        imgSmiling.Image = Nothing
        imgAngry.Image = Nothing


        pictureBoxR1.Image = Nothing

    End Sub


    Private Sub btnRegister_Click(sender As System.Object, e As System.EventArgs) Handles btnRegister.Click

        If cboSex.Text = "Select" Then
            MessageBox.Show("Select Gender")
            Exit Sub
        End If

        If IsNumeric(txtName.Text) = True Then
            MessageBox.Show("Enter User Name")
            Exit Sub
        End If


        If IsNumeric(txtPhone.Text) = False Then
            MessageBox.Show("Invalid Phone Number")
            Exit Sub
        End If

        If (pictureBoxR1.Image Is Nothing) Then
            MessageBox.Show("Scanner Thumbprint ")
            Exit Sub
        End If

        checkConnection()
        If checkNetwork = False Then
            MessageBox.Show("Connection to Server failed")
            Exit Sub
        End If

        CheckNormal()
        CheckSmile()
        CheckAngry()

        If user_Angry <> "" AndAlso user_Normal <> "" AndAlso user_Smile <> "" Then
            If user_Normal = user_Smile AndAlso user_Normal = user_Angry AndAlso user_Angry = user_Smile Then
                MakeReport("Verification failed... User's face already exist")
                Exit Sub
            ElseIf user_Normal = user_Smile Or user_Normal = user_Angry Or user_Smile = user_Angry Then
                MakeReport("Verification failed... Recapture User's face")
                Exit Sub
            End If
        End If

        If checkMatched = True Then
            MessageBox.Show("Cannot Register, fingerprint exists")
            Exit Sub
        Else
            SaveToDB()
            LoadFaces()
            btnRegister.Enabled = False
        End If
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
                SetPrompt("4 fingerprint samples needed")
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


    Private Sub CaptureForm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
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
                MakeReport("The fingerprint feature set was created.")
                Enroller.AddFeatures(features)        ' Add feature set to template.
                UpdateStatus()
            Catch err As Exception
                MakeReport("Error: " & err.ToString)
            Finally


                ' Check if template has been created.
                Select Case Enroller.TemplateStatus
                    Case DPFP.Processing.Enrollment.Status.Ready    ' Report success and stop capturing
                        MakeReport("Scan has Finished, Verification begins...")
                        StopCapture()
                        wait(2.5)
                        verifyProcess(Sample)

                    Case DPFP.Processing.Enrollment.Status.Failed   ' Report failure and restart capturing
                        Enroller.Clear()
                        StopCapture()
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
                        If result.Verified Then
                            checkMatched = True
                        End If
                    End If


                Next n

                If checkMatched = True Then
                    MakeReport("Verification complete, fingerprint exists")
                Else
                    MakeReport("Verification complete, Proceed to Face capture.")
                End If

            Else
a:
                MakeReport("Verification complete, Proceed to Face capture.")
                con.Close()
                Exit Sub
            End If
            con.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.ToString, "ConnectionError or RunNonQuery", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Protected Sub UpdateStatus()
        ' Show number of samples needed.
        SetPrompt("Scan Left Thumb: " & Enroller.FeaturesNeeded.ToString & " left")
    End Sub
    Private Sub frmEnroll_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        GenId()
        checkConnection()
        If checkNetwork = True Then
            MakeReport("Connected to Server ")
            btnStartFinger.Enabled = True
        Else
            MakeReport("Connection to Server failed")
            btnStartFinger.Enabled = False
        End If
        rbtnLeft.Checked = True

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
                trainingImages.Add(New Image(Of Gray, Byte)(Application.StartupPath & "\Faces\" & FacesLoad))
                labels.Add(loadLabels(i))
            Next i

        Catch ex As Exception
            MessageBox.Show("Database is empty... add faces.", "Load face Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub btnStartFinger_Click(sender As System.Object, e As System.EventArgs) Handles btnStartFinger.Click
        If btnStartFinger.Text = "Start Fingerprint Capture" Then
            Init()
            StartCapture()
            btnStartFinger.Text = "Stop Fingerprint Capture"
            btnInitialize.Enabled = True
        ElseIf btnStartFinger.Text = "Stop Fingerprint Capture" Then
            StopCapture()
            pictureBoxR1.Image = Nothing
            SetPrompt(" ")
            MakeReport(" ")
            btnStartFinger.Text = "Start Fingerprint Capture"
        End If

    End Sub


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnInitialize_Click(sender As System.Object, e As System.EventArgs) Handles btnInitialize.Click

        'If cbCamIndex.Text = 0 Then
        'ElseIf cbCamIndex.Text = 1 Then
        'Else
        'MessageBox.Show("Enter valid camera index.")
        'Exit Sub
        'End If

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
            If btnInitialize.Text = "Start Face Detection" Then
                Camera.QueryFrame()
                AddHandler Application.Idle, AddressOf Me.FrameProcedure
                btnInitialize.Text = "Stop Face Detection"
                btnA.Enabled = True

            ElseIf btnInitialize.Text = "Stop Face Detection" Then
                RemoveHandler Application.Idle, AddressOf Me.FrameProcedure
                btnInitialize.Text = "Start Face Detection"

            End If
        End If



    End Sub

    Private Sub FrameProcedure(sender As Object, e As EventArgs)
        Users.Add("")
        Frame = Camera.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)
        grayFace = Frame.Convert(Of Gray, Byte)()
        grayFace._EqualizeHist()
        grayFace._GammaCorrect(0.18)

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
            MakeReport("Error! No Lighting... Try again")
        End Try


    End Sub

    Public Sub SaveFaces()

        trainingImages.Add(TrainedFaceNormal)
        labels.Add(lblID.Text)
        trainingImages.Add(TrainedFaceSmile)
        labels.Add(lblID.Text)
        trainingImages.Add(TrainedFaceAngry)
        labels.Add(lblID.Text)



        File.WriteAllText(Application.StartupPath & "\Faces\Faces.txt", trainingImages.ToArray().Length().ToString() & ",")

        For i As Integer = 1 To trainingImages.ToArray().Length
            trainingImages.ToArray()(i - 1).Save(Application.StartupPath & "\Faces\face" & i & ".bmp")
            File.AppendAllText(Application.StartupPath & "\Faces\Faces.txt", labels.ToArray()(i - 1) & ",")

        Next i



    End Sub

    Private Sub btnA_Click(sender As System.Object, e As System.EventArgs) Handles btnA.Click
        grayFace = Camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)
        grayFace._EqualizeHist()
        grayFace._GammaCorrect(0.18)


        Try
            'Face Detector
            Dim DetectedFaces()() As MCvAvgComp = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, New Size(20, 20))

            If DetectedFaces.Length = 1 Then

                'Action for each element detected
                For Each f As MCvAvgComp In DetectedFaces(0)
                    TrainedFaceNormal = Frame.Copy(f.rect).Convert(Of Gray, Byte)()
                    Exit For
                Next f


                TrainedFaceNormal = Result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)


                imgNormal.Image = TrainedFaceNormal
                btnA.Enabled = False
                btnB.Enabled = True
            Else
                MessageBox.Show("No Faces Detected!")
                Exit Sub
            End If
        Catch
            MessageBox.Show("Error! No database", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub btnB_Click(sender As System.Object, e As System.EventArgs) Handles btnB.Click
        grayFace = Camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)
        grayFace._EqualizeHist()
        grayFace._GammaCorrect(0.18)


        Try
            'Face Detector
            Dim DetectedFaces()() As MCvAvgComp = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, New Size(20, 20))

            If DetectedFaces.Length = 1 Then

                'Action for each element detected
                For Each f As MCvAvgComp In DetectedFaces(0)
                    TrainedFaceSmile = Frame.Copy(f.rect).Convert(Of Gray, Byte)()
                    Exit For
                Next f

                TrainedFaceSmile = Result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)


                imgSmiling.Image = TrainedFaceSmile
                btnB.Enabled = False
                btnC.Enabled = True
            Else
                MessageBox.Show("No Faces Detected!")
                Exit Sub
            End If
        Catch
            MessageBox.Show("Error! No database", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Private Sub btnC_Click(sender As System.Object, e As System.EventArgs) Handles btnC.Click
        grayFace = Camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)
        grayFace._EqualizeHist()
        grayFace._GammaCorrect(0.18)


        Try
            'Face Detector
            Dim DetectedFaces()() As MCvAvgComp = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, New Size(20, 20))

            If DetectedFaces.Length = 1 Then

                'Action for each element detected
                For Each f As MCvAvgComp In DetectedFaces(0)
                    TrainedFaceAngry = Frame.Copy(f.rect).Convert(Of Gray, Byte)()
                    Exit For
                Next f

                TrainedFaceAngry = TrainedFaceAngry.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC)

                imgAngry.Image = TrainedFaceAngry
                btnC.Enabled = False
                btnRegister.Enabled = True
            Else
                MessageBox.Show("No Faces Detected!")
                Exit Sub
            End If
        Catch
            MessageBox.Show("Error! No database", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    Public Sub CheckNormal()

        If trainingImages.ToArray().Length <> 0 Then
            Dim termCriterias As New MCvTermCriteria(Count, 0.3)
            Dim recognizer As New EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 1100, termCriterias)
            user_Normal = recognizer.Recognize(TrainedFaceNormal)
        Else
            user_Normal = ""
        End If

    End Sub
    Public Sub CheckSmile()

        If trainingImages.ToArray().Length <> 0 Then
            Dim termCriterias As New MCvTermCriteria(Count, 0.3)
            Dim recognizer As New EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 1100, termCriterias)
            user_Smile = recognizer.Recognize(TrainedFaceSmile)
        Else
            user_Smile = ""
        End If

    End Sub

    Public Sub CheckAngry()

        If trainingImages.ToArray().Length <> 0 Then
            Dim termCriterias As New MCvTermCriteria(Count, 0.3)
            Dim recognizer As New EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 1100, termCriterias)
            user_Angry = recognizer.Recognize(TrainedFaceAngry)
        Else
            user_Angry = ""
        End If

    End Sub

End Class
