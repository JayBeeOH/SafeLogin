<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistrationForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistrationForm))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.UserNameLabel = New System.Windows.Forms.Label()
        Me.UserNameTextBox = New System.Windows.Forms.TextBox()
        Me.FirstNameTextBox = New System.Windows.Forms.TextBox()
        Me.FirstNameLabel = New System.Windows.Forms.Label()
        Me.LastNameTextBox = New System.Windows.Forms.TextBox()
        Me.LastNameLabel = New System.Windows.Forms.Label()
        Me.MiddleNameTextBox = New System.Windows.Forms.TextBox()
        Me.MIddleNameLabel = New System.Windows.Forms.Label()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.TitleComboBox = New System.Windows.Forms.ComboBox()
        Me.SuffixComboBox = New System.Windows.Forms.ComboBox()
        Me.SuffixLabel = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(192, 221)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(170, 33)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(78, 27)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(88, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(78, 27)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'UserNameLabel
        '
        Me.UserNameLabel.AutoSize = True
        Me.UserNameLabel.Location = New System.Drawing.Point(12, 15)
        Me.UserNameLabel.Name = "UserNameLabel"
        Me.UserNameLabel.Size = New System.Drawing.Size(68, 15)
        Me.UserNameLabel.TabIndex = 0
        Me.UserNameLabel.Text = "&User Name:"
        '
        'UserNameTextBox
        '
        Me.UserNameTextBox.Location = New System.Drawing.Point(104, 12)
        Me.UserNameTextBox.MaxLength = 35
        Me.UserNameTextBox.Name = "UserNameTextBox"
        Me.UserNameTextBox.Size = New System.Drawing.Size(244, 23)
        Me.UserNameTextBox.TabIndex = 1
        '
        'FirstNameTextBox
        '
        Me.FirstNameTextBox.Location = New System.Drawing.Point(104, 90)
        Me.FirstNameTextBox.MaxLength = 35
        Me.FirstNameTextBox.Name = "FirstNameTextBox"
        Me.FirstNameTextBox.Size = New System.Drawing.Size(244, 23)
        Me.FirstNameTextBox.TabIndex = 5
        '
        'FirstNameLabel
        '
        Me.FirstNameLabel.AutoSize = True
        Me.FirstNameLabel.Location = New System.Drawing.Point(12, 93)
        Me.FirstNameLabel.Name = "FirstNameLabel"
        Me.FirstNameLabel.Size = New System.Drawing.Size(67, 15)
        Me.FirstNameLabel.TabIndex = 4
        Me.FirstNameLabel.Text = "&First Name:"
        '
        'LastNameTextBox
        '
        Me.LastNameTextBox.Location = New System.Drawing.Point(104, 148)
        Me.LastNameTextBox.MaxLength = 35
        Me.LastNameTextBox.Name = "LastNameTextBox"
        Me.LastNameTextBox.Size = New System.Drawing.Size(244, 23)
        Me.LastNameTextBox.TabIndex = 9
        '
        'LastNameLabel
        '
        Me.LastNameLabel.AutoSize = True
        Me.LastNameLabel.Location = New System.Drawing.Point(12, 151)
        Me.LastNameLabel.Name = "LastNameLabel"
        Me.LastNameLabel.Size = New System.Drawing.Size(66, 15)
        Me.LastNameLabel.TabIndex = 8
        Me.LastNameLabel.Text = "&Last Name:"
        '
        'MiddleNameTextBox
        '
        Me.MiddleNameTextBox.Location = New System.Drawing.Point(104, 119)
        Me.MiddleNameTextBox.MaxLength = 35
        Me.MiddleNameTextBox.Name = "MiddleNameTextBox"
        Me.MiddleNameTextBox.Size = New System.Drawing.Size(244, 23)
        Me.MiddleNameTextBox.TabIndex = 7
        '
        'MIddleNameLabel
        '
        Me.MIddleNameLabel.AutoSize = True
        Me.MIddleNameLabel.Location = New System.Drawing.Point(12, 122)
        Me.MIddleNameLabel.Name = "MIddleNameLabel"
        Me.MIddleNameLabel.Size = New System.Drawing.Size(82, 15)
        Me.MIddleNameLabel.TabIndex = 6
        Me.MIddleNameLabel.Text = "&Middle Name:"
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Location = New System.Drawing.Point(13, 67)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(33, 15)
        Me.TitleLabel.TabIndex = 2
        Me.TitleLabel.Text = "&Title:"
        '
        'TitleComboBox
        '
        Me.TitleComboBox.FormattingEnabled = True
        Me.TitleComboBox.Location = New System.Drawing.Point(104, 61)
        Me.TitleComboBox.Name = "TitleComboBox"
        Me.TitleComboBox.Size = New System.Drawing.Size(77, 23)
        Me.TitleComboBox.TabIndex = 3
        '
        'SuffixComboBox
        '
        Me.SuffixComboBox.FormattingEnabled = True
        Me.SuffixComboBox.Location = New System.Drawing.Point(104, 177)
        Me.SuffixComboBox.Name = "SuffixComboBox"
        Me.SuffixComboBox.Size = New System.Drawing.Size(77, 23)
        Me.SuffixComboBox.TabIndex = 11
        '
        'SuffixLabel
        '
        Me.SuffixLabel.AutoSize = True
        Me.SuffixLabel.Location = New System.Drawing.Point(13, 183)
        Me.SuffixLabel.Name = "SuffixLabel"
        Me.SuffixLabel.Size = New System.Drawing.Size(39, 15)
        Me.SuffixLabel.TabIndex = 10
        Me.SuffixLabel.Text = "&Suffix:"
        '
        'RegistrationForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(376, 268)
        Me.Controls.Add(Me.SuffixComboBox)
        Me.Controls.Add(Me.SuffixLabel)
        Me.Controls.Add(Me.TitleComboBox)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.LastNameTextBox)
        Me.Controls.Add(Me.LastNameLabel)
        Me.Controls.Add(Me.MiddleNameTextBox)
        Me.Controls.Add(Me.MIddleNameLabel)
        Me.Controls.Add(Me.FirstNameTextBox)
        Me.Controls.Add(Me.FirstNameLabel)
        Me.Controls.Add(Me.UserNameTextBox)
        Me.Controls.Add(Me.UserNameLabel)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RegistrationForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registration"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents UserNameLabel As Label
    Friend WithEvents UserNameTextBox As TextBox
    Friend WithEvents FirstNameTextBox As TextBox
    Friend WithEvents FirstNameLabel As Label
    Friend WithEvents LastNameTextBox As TextBox
    Friend WithEvents LastNameLabel As Label
    Friend WithEvents MiddleNameTextBox As TextBox
    Friend WithEvents MIddleNameLabel As Label
    Friend WithEvents TitleLabel As Label
    Friend WithEvents TitleComboBox As ComboBox
    Friend WithEvents SuffixComboBox As ComboBox
    Friend WithEvents SuffixLabel As Label
End Class
