<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuthenticate
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnStartFinger = New System.Windows.Forms.Button()
        Me.pictureBoxR1 = New System.Windows.Forms.PictureBox()
        Me.Prompt = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnCapture = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.imgNormal = New Emgu.CV.UI.ImageBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CameraBox = New Emgu.CV.UI.ImageBox()
        Me.btnInitialize = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.StatusText = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBoxR1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.imgNormal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CameraBox, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(1053, 135)
        Me.Panel1.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Lucida Fax", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(88, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(876, 33)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "VICTORIA UNIVERSITY PROJECT MANAGEMENT PORTAL"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Fax", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(70, 60)
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
        Me.Label1.Location = New System.Drawing.Point(339, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(374, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ACCESS AUTHENTICATION FORM"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.btnStartFinger)
        Me.GroupBox2.Controls.Add(Me.pictureBoxR1)
        Me.GroupBox2.Controls.Add(Me.Prompt)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 141)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(319, 416)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fingerprint Authentication"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MultiFactored_Authentication_Systems.My.Resources.Resources.scanner2
        Me.PictureBox1.Location = New System.Drawing.Point(27, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(236, 263)
        Me.PictureBox1.TabIndex = 45
        Me.PictureBox1.TabStop = False
        '
        'btnStartFinger
        '
        Me.btnStartFinger.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnStartFinger.Enabled = False
        Me.btnStartFinger.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartFinger.Location = New System.Drawing.Point(27, 349)
        Me.btnStartFinger.Name = "btnStartFinger"
        Me.btnStartFinger.Size = New System.Drawing.Size(236, 57)
        Me.btnStartFinger.TabIndex = 44
        Me.btnStartFinger.Text = "Authenticate Fingerprint "
        Me.btnStartFinger.UseVisualStyleBackColor = False
        '
        'pictureBoxR1
        '
        Me.pictureBoxR1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pictureBoxR1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBoxR1.Location = New System.Drawing.Point(269, 326)
        Me.pictureBoxR1.Name = "pictureBoxR1"
        Me.pictureBoxR1.Size = New System.Drawing.Size(41, 40)
        Me.pictureBoxR1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBoxR1.TabIndex = 43
        Me.pictureBoxR1.TabStop = False
        Me.pictureBoxR1.Visible = False
        '
        'Prompt
        '
        Me.Prompt.BackColor = System.Drawing.Color.Black
        Me.Prompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Prompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Prompt.ForeColor = System.Drawing.Color.Yellow
        Me.Prompt.Location = New System.Drawing.Point(27, 310)
        Me.Prompt.Name = "Prompt"
        Me.Prompt.Size = New System.Drawing.Size(236, 27)
        Me.Prompt.TabIndex = 26
        Me.Prompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnCapture)
        Me.GroupBox3.Controls.Add(Me.LinkLabel1)
        Me.GroupBox3.Controls.Add(Me.imgNormal)
        Me.GroupBox3.Controls.Add(Me.PictureBox3)
        Me.GroupBox3.Controls.Add(Me.PictureBox2)
        Me.GroupBox3.Controls.Add(Me.CameraBox)
        Me.GroupBox3.Controls.Add(Me.btnInitialize)
        Me.GroupBox3.Controls.Add(Me.btnClose)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(344, 141)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(697, 416)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Face Authentication"
        '
        'btnCapture
        '
        Me.btnCapture.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCapture.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCapture.Enabled = False
        Me.btnCapture.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapture.Location = New System.Drawing.Point(73, 386)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(191, 29)
        Me.btnCapture.TabIndex = 40
        Me.btnCapture.Text = "1. Capture Normal Face"
        Me.btnCapture.UseVisualStyleBackColor = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(94, 261)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(149, 16)
        Me.LinkLabel1.TabIndex = 39
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "3 face samples needed"
        '
        'imgNormal
        '
        Me.imgNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgNormal.Location = New System.Drawing.Point(118, 280)
        Me.imgNormal.Name = "imgNormal"
        Me.imgNormal.Size = New System.Drawing.Size(100, 100)
        Me.imgNormal.TabIndex = 37
        Me.imgNormal.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.MultiFactored_Authentication_Systems.My.Resources.Resources.network_false
        Me.PictureBox3.Location = New System.Drawing.Point(624, 345)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(67, 53)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 36
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.MultiFactored_Authentication_Systems.My.Resources.Resources.facescan
        Me.PictureBox2.Location = New System.Drawing.Point(345, 18)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(247, 240)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 35
        Me.PictureBox2.TabStop = False
        '
        'CameraBox
        '
        Me.CameraBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CameraBox.Location = New System.Drawing.Point(8, 18)
        Me.CameraBox.Name = "CameraBox"
        Me.CameraBox.Size = New System.Drawing.Size(320, 240)
        Me.CameraBox.TabIndex = 2
        Me.CameraBox.TabStop = False
        '
        'btnInitialize
        '
        Me.btnInitialize.BackColor = System.Drawing.Color.DarkGreen
        Me.btnInitialize.Enabled = False
        Me.btnInitialize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInitialize.ForeColor = System.Drawing.Color.White
        Me.btnInitialize.Location = New System.Drawing.Point(384, 287)
        Me.btnInitialize.Name = "btnInitialize"
        Me.btnInitialize.Size = New System.Drawing.Size(168, 57)
        Me.btnInitialize.TabIndex = 34
        Me.btnInitialize.Text = "Authenticate Face"
        Me.btnInitialize.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Maroon
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(384, 347)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(168, 57)
        Me.btnClose.TabIndex = 33
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'StatusText
        '
        Me.StatusText.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.StatusText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StatusText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusText.ForeColor = System.Drawing.Color.White
        Me.StatusText.Location = New System.Drawing.Point(0, 563)
        Me.StatusText.Name = "StatusText"
        Me.StatusText.Size = New System.Drawing.Size(1054, 26)
        Me.StatusText.TabIndex = 25
        Me.StatusText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmAuthenticate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1053, 595)
        Me.Controls.Add(Me.StatusText)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAuthenticate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Multi-factored Authentication System: Registration Form"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBoxR1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.imgNormal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CameraBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Prompt As System.Windows.Forms.Label
    Friend WithEvents StatusText As System.Windows.Forms.TextBox
    Friend WithEvents pictureBoxR1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnStartFinger As System.Windows.Forms.Button
    Private WithEvents btnInitialize As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents CameraBox As Emgu.CV.UI.ImageBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents imgNormal As Emgu.CV.UI.ImageBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Private WithEvents btnCapture As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
