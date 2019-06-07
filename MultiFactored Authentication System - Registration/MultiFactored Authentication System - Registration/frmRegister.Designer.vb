<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegister
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.cboSex = New System.Windows.Forms.ComboBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbtnRight = New System.Windows.Forms.RadioButton()
        Me.rbtnLeft = New System.Windows.Forms.RadioButton()
        Me.btnStartFinger = New System.Windows.Forms.Button()
        Me.pictureBoxR1 = New System.Windows.Forms.PictureBox()
        Me.Prompt = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnC = New System.Windows.Forms.Button()
        Me.btnB = New System.Windows.Forms.Button()
        Me.btnA = New System.Windows.Forms.Button()
        Me.CameraBox = New Emgu.CV.UI.ImageBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.imgAngry = New Emgu.CV.UI.ImageBox()
        Me.imgSmiling = New Emgu.CV.UI.ImageBox()
        Me.imgNormal = New Emgu.CV.UI.ImageBox()
        Me.btnInitialize = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.StatusText = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.pictureBoxR1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CameraBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.imgAngry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgSmiling, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgNormal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1107, 131)
        Me.Panel1.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Fax", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(115, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(876, 33)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "VICTORIA UNIVERSITY PROJECT MANAGEMENT PORTAL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(95, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(912, 27)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "A MULTI-FACTORED AUTHENTICATION BASED CYBER SECURITY SYSTEM"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Fax", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(428, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(247, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "REGISTRATION FORM"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpDate)
        Me.GroupBox1.Controls.Add(Me.cboSex)
        Me.GroupBox1.Controls.Add(Me.txtPhone)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 152)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(613, 124)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User's Details"
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(434, 71)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(165, 22)
        Me.dtpDate.TabIndex = 3
        '
        'cboSex
        '
        Me.cboSex.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSex.FormattingEnabled = True
        Me.cboSex.Items.AddRange(New Object() {"M", "F"})
        Me.cboSex.Location = New System.Drawing.Point(63, 68)
        Me.cboSex.Name = "cboSex"
        Me.cboSex.Size = New System.Drawing.Size(76, 28)
        Me.cboSex.TabIndex = 2
        Me.cboSex.Text = "Select"
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(206, 68)
        Me.txtPhone.MaxLength = 10
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(126, 26)
        Me.txtPhone.TabIndex = 1
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(345, 28)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(262, 26)
        Me.txtName.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(342, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Enrolled Date:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(153, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Phone:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Gender:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(254, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "User's Name:"
        '
        'lblID
        '
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.Location = New System.Drawing.Point(112, 29)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(140, 23)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "User ID Number:"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "User ID Number:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.btnStartFinger)
        Me.GroupBox2.Controls.Add(Me.pictureBoxR1)
        Me.GroupBox2.Controls.Add(Me.Prompt)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 285)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(615, 271)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fingerprint Enrollment"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbtnRight)
        Me.GroupBox4.Controls.Add(Me.rbtnLeft)
        Me.GroupBox4.Location = New System.Drawing.Point(317, 30)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(284, 102)
        Me.GroupBox4.TabIndex = 45
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Finger Selection"
        '
        'rbtnRight
        '
        Me.rbtnRight.AutoSize = True
        Me.rbtnRight.Enabled = False
        Me.rbtnRight.Location = New System.Drawing.Point(21, 66)
        Me.rbtnRight.Name = "rbtnRight"
        Me.rbtnRight.Size = New System.Drawing.Size(102, 20)
        Me.rbtnRight.TabIndex = 0
        Me.rbtnRight.TabStop = True
        Me.rbtnRight.Text = "Right Thumb"
        Me.rbtnRight.UseVisualStyleBackColor = True
        '
        'rbtnLeft
        '
        Me.rbtnLeft.AutoSize = True
        Me.rbtnLeft.Location = New System.Drawing.Point(21, 35)
        Me.rbtnLeft.Name = "rbtnLeft"
        Me.rbtnLeft.Size = New System.Drawing.Size(92, 20)
        Me.rbtnLeft.TabIndex = 0
        Me.rbtnLeft.TabStop = True
        Me.rbtnLeft.Text = "Left Thumb"
        Me.rbtnLeft.UseVisualStyleBackColor = True
        '
        'btnStartFinger
        '
        Me.btnStartFinger.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnStartFinger.Enabled = False
        Me.btnStartFinger.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartFinger.Location = New System.Drawing.Point(317, 181)
        Me.btnStartFinger.Name = "btnStartFinger"
        Me.btnStartFinger.Size = New System.Drawing.Size(284, 57)
        Me.btnStartFinger.TabIndex = 44
        Me.btnStartFinger.Text = "Start Fingerprint Capture"
        Me.btnStartFinger.UseVisualStyleBackColor = False
        '
        'pictureBoxR1
        '
        Me.pictureBoxR1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pictureBoxR1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBoxR1.Location = New System.Drawing.Point(91, 30)
        Me.pictureBoxR1.Name = "pictureBoxR1"
        Me.pictureBoxR1.Size = New System.Drawing.Size(192, 208)
        Me.pictureBoxR1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBoxR1.TabIndex = 43
        Me.pictureBoxR1.TabStop = False
        '
        'Prompt
        '
        Me.Prompt.BackColor = System.Drawing.Color.Black
        Me.Prompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Prompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Prompt.ForeColor = System.Drawing.Color.Yellow
        Me.Prompt.Location = New System.Drawing.Point(91, 241)
        Me.Prompt.Name = "Prompt"
        Me.Prompt.Size = New System.Drawing.Size(192, 27)
        Me.Prompt.TabIndex = 26
        Me.Prompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnC)
        Me.GroupBox3.Controls.Add(Me.btnB)
        Me.GroupBox3.Controls.Add(Me.btnA)
        Me.GroupBox3.Controls.Add(Me.CameraBox)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.btnInitialize)
        Me.GroupBox3.Controls.Add(Me.btnClose)
        Me.GroupBox3.Controls.Add(Me.btnRegister)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(631, 152)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(463, 404)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Face Enrollment"
        '
        'btnC
        '
        Me.btnC.Enabled = False
        Me.btnC.Location = New System.Drawing.Point(232, 284)
        Me.btnC.Name = "btnC"
        Me.btnC.Size = New System.Drawing.Size(100, 59)
        Me.btnC.TabIndex = 38
        Me.btnC.Text = "Capture Angry Face"
        Me.btnC.UseVisualStyleBackColor = True
        '
        'btnB
        '
        Me.btnB.Enabled = False
        Me.btnB.Location = New System.Drawing.Point(122, 284)
        Me.btnB.Name = "btnB"
        Me.btnB.Size = New System.Drawing.Size(100, 59)
        Me.btnB.TabIndex = 37
        Me.btnB.Text = "Capture Smiling Face"
        Me.btnB.UseVisualStyleBackColor = True
        '
        'btnA
        '
        Me.btnA.Enabled = False
        Me.btnA.Location = New System.Drawing.Point(11, 284)
        Me.btnA.Name = "btnA"
        Me.btnA.Size = New System.Drawing.Size(100, 59)
        Me.btnA.TabIndex = 36
        Me.btnA.Text = "Capture Normal Face"
        Me.btnA.UseVisualStyleBackColor = True
        '
        'CameraBox
        '
        Me.CameraBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CameraBox.Location = New System.Drawing.Point(12, 25)
        Me.CameraBox.Name = "CameraBox"
        Me.CameraBox.Size = New System.Drawing.Size(320, 240)
        Me.CameraBox.TabIndex = 2
        Me.CameraBox.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.imgAngry)
        Me.GroupBox5.Controls.Add(Me.imgSmiling)
        Me.GroupBox5.Controls.Add(Me.imgNormal)
        Me.GroupBox5.Location = New System.Drawing.Point(338, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(125, 352)
        Me.GroupBox5.TabIndex = 35
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Captured Face"
        '
        'imgAngry
        '
        Me.imgAngry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgAngry.Location = New System.Drawing.Point(12, 246)
        Me.imgAngry.Name = "imgAngry"
        Me.imgAngry.Size = New System.Drawing.Size(100, 100)
        Me.imgAngry.TabIndex = 3
        Me.imgAngry.TabStop = False
        '
        'imgSmiling
        '
        Me.imgSmiling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgSmiling.Location = New System.Drawing.Point(12, 136)
        Me.imgSmiling.Name = "imgSmiling"
        Me.imgSmiling.Size = New System.Drawing.Size(100, 100)
        Me.imgSmiling.TabIndex = 3
        Me.imgSmiling.TabStop = False
        '
        'imgNormal
        '
        Me.imgNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgNormal.Location = New System.Drawing.Point(12, 25)
        Me.imgNormal.Name = "imgNormal"
        Me.imgNormal.Size = New System.Drawing.Size(100, 100)
        Me.imgNormal.TabIndex = 3
        Me.imgNormal.TabStop = False
        '
        'btnInitialize
        '
        Me.btnInitialize.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnInitialize.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInitialize.Location = New System.Drawing.Point(12, 357)
        Me.btnInitialize.Name = "btnInitialize"
        Me.btnInitialize.Size = New System.Drawing.Size(140, 41)
        Me.btnInitialize.TabIndex = 34
        Me.btnInitialize.Text = "Start Face Detection"
        Me.btnInitialize.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(350, 357)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 38)
        Me.btnClose.TabIndex = 33
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.Color.Plum
        Me.btnRegister.Enabled = False
        Me.btnRegister.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegister.Location = New System.Drawing.Point(174, 357)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(158, 41)
        Me.btnRegister.TabIndex = 32
        Me.btnRegister.Text = "Verify && Register"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'StatusText
        '
        Me.StatusText.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.StatusText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StatusText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusText.ForeColor = System.Drawing.Color.White
        Me.StatusText.Location = New System.Drawing.Point(-2, 566)
        Me.StatusText.Name = "StatusText"
        Me.StatusText.Size = New System.Drawing.Size(1107, 26)
        Me.StatusText.TabIndex = 25
        Me.StatusText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1108, 598)
        Me.Controls.Add(Me.StatusText)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Multi-factored Authentication System: Registration Form"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.pictureBoxR1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.CameraBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.imgAngry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgSmiling, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgNormal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents cboSex As System.Windows.Forms.ComboBox
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents Prompt As System.Windows.Forms.Label
    Friend WithEvents StatusText As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pictureBoxR1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnStartFinger As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnRight As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnLeft As System.Windows.Forms.RadioButton
    Private WithEvents btnInitialize As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnRegister As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CameraBox As Emgu.CV.UI.ImageBox
    Friend WithEvents imgNormal As Emgu.CV.UI.ImageBox
    Friend WithEvents imgAngry As Emgu.CV.UI.ImageBox
    Friend WithEvents imgSmiling As Emgu.CV.UI.ImageBox
    Friend WithEvents btnC As System.Windows.Forms.Button
    Friend WithEvents btnB As System.Windows.Forms.Button
    Friend WithEvents btnA As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
