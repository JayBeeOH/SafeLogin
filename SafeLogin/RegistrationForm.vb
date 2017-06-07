'------------------------------------------------------------------------------------------
'           Notice of My Copyright and Intellectual Property Rights
'
'            Copyright © 2017 Joseph L. Bolen. All rights reserved.
'        All trademarks remain the property of their respective owners.
'
'    This program Is free software: you can redistribute it And/Or modify
'    it under the terms Of the GNU General Public License As published by
'    the Free Software Foundation, either version 3 Of the License, Or
'    any later version.
'
'    This program Is distributed In the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty Of
'    MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License For more details.
'
'    You should have received a copy Of the GNU General Public License
'    along with this program.  If Not, see < http: //www.gnu.org/licenses/>.
'
'-------------------------------------------------------------------------------------------
' Program Name:   Safe Login
' Class:          RegistrationForm
'
' Author:         Joseph L. Bolen
' Date Created:   06 JUN 2017
'
' Description:    Demonstration of not storing passwords, but storing the salt and hash.
'
'                 The Rfc2898DeriveBytes Class Implements PBKDF2 which is a pseudorandom
'                 function and can be used to create a salt and hash for password security.
'                 The idea Is to never store a user's password, but only the derived salt and
'                 hash of the password. Then the salt and hash are used for validation for future
'                 authentication. For father learning, see "Rfc2898DeriveBytes Class" of the
'                 .NET Framework at:
'     < http://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rfc2898derivebytes >.
'
'                 This app uses MS SQLExpress database for the backend data store. However, it will
'                 work with all fully supported SQL databases with little changes.
'
'                 Set project's Shutdown Mode: When last form closes.
'
'                 Documentation is at:
'                   App's documentation is at:  https://jaybeeoh.github.io/SafeLogin/
'                   Video tutorials at YouTube: http://www.youtube.com/user/bolenpresents
'-------------------------------------------------------------------------------------------

Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading
Imports DataAccess

Public Class RegistrationForm

    Private myTI As TextInfo

    Private WithEvents MyErrorProvider As New ErrorProvider With {.BlinkStyle = ErrorBlinkStyle.NeverBlink}

    Public Property RecordID As Integer

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(name As String)
        InitializeComponent()
        UserNameTextBox.Text = name
    End Sub

    Private Sub RegistrationForm_Load(sender As Object, e As EventArgs) _
        Handles Me.Load

        myTI = Thread.CurrentThread.CurrentCulture.TextInfo

        LoadTitleComboBox()
        LoadSuffixComboBox()
    End Sub

    Private Sub LoadTitleComboBox()

        Try
            Dim dt As DataTable = TitleDB.GetTitles()

            With TitleComboBox
                .DropDownStyle = ComboBoxStyle.DropDown
                .IntegralHeight = False
                .MaxDropDownItems = 8
                .DataSource = dt
                .DisplayMember = "Title"
                .ValueMember = "TitleID"
                .SelectedIndex = -1
            End With
        Catch ex As SqlException        ' SqlException error.
            MessageBox.Show($"Database Error Code # 0x{ex.ErrorCode.ToString("X")} - Number: {ex.Number} - {ex.Message}",
                                ex.GetType.ToString,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)

        Catch ex As Exception           ' General catch all error.
            MessageBox.Show(ex.Message,
                            ex.GetType.ToString,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSuffixComboBox()

        Try
            Dim dt As DataTable = SuffixDB.GetSuffixes()

            With SuffixComboBox
                .DropDownStyle = ComboBoxStyle.DropDown
                .IntegralHeight = False
                .MaxDropDownItems = 8
                .DataSource = dt
                .DisplayMember = "Suffix"
                .ValueMember = "SuffixID"
                .SelectedIndex = -1
            End With
        Catch ex As SqlException        ' SqlException error.
            MessageBox.Show($"Database Error Code # 0x{ex.ErrorCode.ToString("X")} - Number: {ex.Number} - {ex.Message}",
                                ex.GetType.ToString,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)

        Catch ex As Exception           ' General catch all error.
            MessageBox.Show(ex.Message,
                            ex.GetType.ToString,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles OK_Button.Click

        If Not ValidateChildren() Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            Exit Sub
        End If

        If InsertPerson() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            'MessageBox.Show($"User Name: {UserNameTextBox.Text} has already been taken. Try another User Name.",
            '                "Registration Failure",
            '                MessageBoxButtons.OK,
            '                MessageBoxIcon.Error)
            MyErrorProvider.SetError(UserNameTextBox, "User Name has already been taken. Try another User Name.")
            UserNameTextBox.Focus()
            UserNameTextBox.Select(UserNameTextBox.Text.Length, 0)
        End If

    End Sub

    Private Function InsertPerson() As Boolean
        Dim newPerson As New Person
        With newPerson
            .UserName = UserNameTextBox.Text
            .TitleID = CType(TitleComboBox.SelectedValue, Integer)
            .FirstName = FirstNameTextBox.Text
            .MiddleName = MiddleNameTextBox.Text
            .LastName = LastNameTextBox.Text
            .SuffixID = CType(SuffixComboBox.SelectedValue, Integer)
        End With

        Try
            RecordID = PersonDB.InsertPersonByUserName(newPerson)
        Catch ex As SqlException        ' SqlException error.
            If ex.Number = 2601 Then    ' Duplicate Index Error
                Return False
            Else
                MessageBox.Show($"Database Error Code # 0x{ex.ErrorCode.ToString("X")} - Number: {ex.Number} - {ex.Message}",
                                ex.GetType.ToString,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return False
            End If
        Catch ex As Exception           ' General catch all error.
            MessageBox.Show(ex.Message,
                            ex.GetType.ToString,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return False
        End Try

        Return True

    End Function

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RegistrationForm_Closing(sender As Object, e As CancelEventArgs) _
        Handles Me.Closing

        e.Cancel = False
    End Sub

    Private Sub UserNameTextBox_Validating(sender As Object, e As CancelEventArgs) _
        Handles UserNameTextBox.Validating

        Dim ctrl As Control = CType(sender, Control)
        MyErrorProvider.SetError(ctrl, String.Empty)
        Try
            ValidateMinLength(ctrl.Text, LoginForm.UserNameMinLength)
            ValidateNoWhiteSpace(ctrl.Text)
        Catch ex As Exception
            MyErrorProvider.SetError(ctrl, ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub FirstNameTextBox_Validating(sender As Object, e As CancelEventArgs) _
        Handles FirstNameTextBox.Validating

        Dim ctrl As Control = CType(sender, Control)
        MyErrorProvider.SetError(ctrl, String.Empty)
        Try
            ValidateIsRequired(ctrl.Text)
            ctrl.Text = myTI.ToTitleCase(ctrl.Text)
        Catch ex As Exception
            MyErrorProvider.SetError(ctrl, ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub LastNameTextBox_Validating(sender As Object, e As CancelEventArgs) _
        Handles LastNameTextBox.Validating

        Dim ctrl As Control = CType(sender, Control)
        MyErrorProvider.SetError(ctrl, String.Empty)
        Try
            ValidateIsRequired(ctrl.Text)
            ctrl.Text = myTI.ToTitleCase(ctrl.Text)
        Catch ex As Exception
            MyErrorProvider.SetError(ctrl, ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub MiddleNameTextBox_LostFocus(sender As Object, e As EventArgs) _
        Handles MiddleNameTextBox.LostFocus

        Dim ctrl As Control = CType(sender, Control)
        ctrl.Text = myTI.ToTitleCase(ctrl.Text)
    End Sub
End Class
