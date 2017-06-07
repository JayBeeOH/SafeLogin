<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.UserNameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UserNameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.OkayButton = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.GreetingLabel = New System.Windows.Forms.Label()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.RegisterLinkLabel = New System.Windows.Forms.LinkLabel()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UserNameLabel
        '
        Me.UserNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.UserNameLabel.AutoSize = True
        Me.UserNameLabel.Location = New System.Drawing.Point(295, 115)
        Me.UserNameLabel.Name = "UserNameLabel"
        Me.UserNameLabel.Size = New System.Drawing.Size(68, 15)
        Me.UserNameLabel.TabIndex = 1
        Me.UserNameLabel.Text = "&User Name:"
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PasswordLabel.AutoSize = True
        Me.PasswordLabel.Location = New System.Drawing.Point(295, 169)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(60, 15)
        Me.PasswordLabel.TabIndex = 3
        Me.PasswordLabel.Text = "&Password:"
        '
        'UserNameTextBox
        '
        Me.UserNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.UserNameTextBox.Location = New System.Drawing.Point(298, 134)
        Me.UserNameTextBox.Name = "UserNameTextBox"
        Me.UserNameTextBox.Size = New System.Drawing.Size(179, 23)
        Me.UserNameTextBox.TabIndex = 2
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PasswordTextBox.Location = New System.Drawing.Point(298, 187)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.PasswordTextBox.Size = New System.Drawing.Size(179, 23)
        Me.PasswordTextBox.TabIndex = 4
        '
        'OkayButton
        '
        Me.OkayButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkayButton.Location = New System.Drawing.Point(298, 216)
        Me.OkayButton.Name = "OkayButton"
        Me.OkayButton.Size = New System.Drawing.Size(75, 23)
        Me.OkayButton.TabIndex = 5
        Me.OkayButton.Text = "&OK"
        Me.OkayButton.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.Location = New System.Drawing.Point(402, 216)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.CancelBtn.TabIndex = 6
        Me.CancelBtn.Text = "&Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'GreetingLabel
        '
        Me.GreetingLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GreetingLabel.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GreetingLabel.Location = New System.Drawing.Point(298, 13)
        Me.GreetingLabel.Name = "GreetingLabel"
        Me.GreetingLabel.Size = New System.Drawing.Size(179, 93)
        Me.GreetingLabel.TabIndex = 0
        Me.GreetingLabel.Text = "Welcome to Bolen Apps!"
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = Global.SafeLogin.My.Resources.Resources.BolenAppLogo
        Me.LogoPictureBox.Location = New System.Drawing.Point(13, 13)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(256, 256)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LogoPictureBox.TabIndex = 4
        Me.LogoPictureBox.TabStop = False
        '
        'RegisterLinkLabel
        '
        Me.RegisterLinkLabel.AutoSize = True
        Me.RegisterLinkLabel.Location = New System.Drawing.Point(428, 254)
        Me.RegisterLinkLabel.Name = "RegisterLinkLabel"
        Me.RegisterLinkLabel.Size = New System.Drawing.Size(49, 15)
        Me.RegisterLinkLabel.TabIndex = 7
        Me.RegisterLinkLabel.TabStop = True
        Me.RegisterLinkLabel.Text = "Register"
        '
        'LoginForm
        '
        Me.AcceptButton = Me.OkayButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.ClientSize = New System.Drawing.Size(508, 284)
        Me.Controls.Add(Me.RegisterLinkLabel)
        Me.Controls.Add(Me.GreetingLabel)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OkayButton)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.UserNameTextBox)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UserNameLabel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(524, 323)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(524, 323)
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UserNameLabel As Label
    Friend WithEvents PasswordLabel As Label
    Friend WithEvents UserNameTextBox As TextBox
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents LogoPictureBox As PictureBox
    Friend WithEvents OkayButton As Button
    Friend WithEvents CancelBtn As Button
    Friend WithEvents GreetingLabel As Label
    Friend WithEvents RegisterLinkLabel As LinkLabel
End Class
