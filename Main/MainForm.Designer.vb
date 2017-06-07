<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.WelcomeLabel = New System.Windows.Forms.Label()
        Me.IDLabel = New System.Windows.Forms.Label()
        Me.IDValueLabel = New System.Windows.Forms.Label()
        Me.UserNameValueLabel = New System.Windows.Forms.Label()
        Me.UserNameLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'WelcomeLabel
        '
        Me.WelcomeLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WelcomeLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WelcomeLabel.ForeColor = System.Drawing.Color.Blue
        Me.WelcomeLabel.Location = New System.Drawing.Point(12, 64)
        Me.WelcomeLabel.Name = "WelcomeLabel"
        Me.WelcomeLabel.Size = New System.Drawing.Size(600, 106)
        Me.WelcomeLabel.TabIndex = 0
        Me.WelcomeLabel.Text = "Welcome to Main"
        Me.WelcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IDLabel
        '
        Me.IDLabel.AutoSize = True
        Me.IDLabel.Location = New System.Drawing.Point(12, 9)
        Me.IDLabel.Name = "IDLabel"
        Me.IDLabel.Size = New System.Drawing.Size(21, 15)
        Me.IDLabel.TabIndex = 1
        Me.IDLabel.Text = "ID:"
        '
        'IDValueLabel
        '
        Me.IDValueLabel.AutoSize = True
        Me.IDValueLabel.Location = New System.Drawing.Point(51, 9)
        Me.IDValueLabel.Name = "IDValueLabel"
        Me.IDValueLabel.Size = New System.Drawing.Size(0, 15)
        Me.IDValueLabel.TabIndex = 3
        Me.IDValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UserNameValueLabel
        '
        Me.UserNameValueLabel.AutoSize = True
        Me.UserNameValueLabel.Location = New System.Drawing.Point(51, 24)
        Me.UserNameValueLabel.Name = "UserNameValueLabel"
        Me.UserNameValueLabel.Size = New System.Drawing.Size(0, 15)
        Me.UserNameValueLabel.TabIndex = 5
        Me.UserNameValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UserNameLabel
        '
        Me.UserNameLabel.AutoSize = True
        Me.UserNameLabel.Location = New System.Drawing.Point(12, 24)
        Me.UserNameLabel.Name = "UserNameLabel"
        Me.UserNameLabel.Size = New System.Drawing.Size(33, 15)
        Me.UserNameLabel.TabIndex = 4
        Me.UserNameLabel.Text = "User:"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 281)
        Me.Controls.Add(Me.UserNameValueLabel)
        Me.Controls.Add(Me.UserNameLabel)
        Me.Controls.Add(Me.IDValueLabel)
        Me.Controls.Add(Me.IDLabel)
        Me.Controls.Add(Me.WelcomeLabel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WelcomeLabel As Label
    Friend WithEvents IDLabel As Label
    Friend WithEvents IDValueLabel As Label
    Friend WithEvents UserNameValueLabel As Label
    Friend WithEvents UserNameLabel As Label
End Class
