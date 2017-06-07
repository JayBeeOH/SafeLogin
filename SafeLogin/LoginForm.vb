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
' Class:          LoginForm
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
Imports DataAccess
Imports Main

Public Class LoginForm

    Const SALT_LENGTH As Integer = 24
    Const HASH_LENGTH As Integer = 128

    Public Property LoginAttemptsAllowed As Integer
    Public Property PasswordMinLength As Integer
    Public Property UserNameMinLength As Integer

    Private WithEvents MyErrorProvider As New ErrorProvider With {.BlinkStyle = ErrorBlinkStyle.NeverBlink}

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) _
        Handles Me.Load

        LoginAttemptsAllowed = 3
        PasswordMinLength = 8
        UserNameMinLength = 8
    End Sub

    Private Sub OkayButton_Click(sender As Object, e As EventArgs) Handles OkayButton.Click

        If Not ValidateChildren() Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            Exit Sub
        End If

        Static attempts As Integer = 0
        Dim passwordSalt(SALT_LENGTH) As Byte
        Dim passwordHash(HASH_LENGTH) As Byte

        Try
            Dim id As Integer = PersonDB.GetPersonIDByUserName(UserNameTextBox.Text)
            If (id > 0) AndAlso
                (PasswordDB.GetSaltAndHashByID(id, passwordSalt, passwordHash)) AndAlso
                (Security.Verify(PasswordTextBox.Text, passwordSalt, passwordHash)) Then
                'MessageBox.Show("User Name and Password Verified.",
                '    "Login Successful",
                '    MessageBoxButtons.OK,
                '    MessageBoxIcon.Information)
                Dim main As New MainForm(id, UserNameTextBox.Text)
                main.Show()
                Close()
            Else
                MessageBox.Show("User Name and Password not correct.",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                'UserNameTextBox.Clear()
                PasswordTextBox.Clear()
                UserNameTextBox.Focus()
                UserNameTextBox.Select(UserNameTextBox.Text.Length, 0)
                attempts += 1
                If attempts >= LoginAttemptsAllowed Then
                    Close()
                End If
            End If
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

    Private Sub CancelBtn_Click_1(sender As Object, e As EventArgs) _
        Handles CancelBtn.Click

        Close()
    End Sub

    Private Sub RegisterLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles RegisterLinkLabel.LinkClicked

        If Not ValidateChildren() Then
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
            Exit Sub
        End If

        Dim frm As New RegistrationForm(UserNameTextBox.Text)
        If (frm.ShowDialog = DialogResult.OK) Then
            UserNameTextBox.Text = frm.UserNameTextBox.Text
            Dim hb As New Security.HashBytes
            Try
                hb = Security.Hash(PasswordTextBox.Text, SALT_LENGTH, HASH_LENGTH)
                PasswordDB.SaveSaltAndHashByID(frm.RecordID, hb.Salt, hb.Hash)
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
        End If
    End Sub

    Private Sub UserNameTextBox_Validating(sender As Object, e As CancelEventArgs) _
        Handles UserNameTextBox.Validating

        Dim ctrl As Control = CType(sender, Control)
        MyErrorProvider.SetError(ctrl, String.Empty)
        Try
            ValidateMinLength(ctrl.Text, UserNameMinLength)
            ValidateNoWhiteSpace(ctrl.Text)
        Catch ex As Exception
            MyErrorProvider.SetError(ctrl, ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub PasswordTextBox_Validating(sender As Object, e As CancelEventArgs) _
        Handles PasswordTextBox.Validating

        Dim ctrl As Control = CType(sender, Control)
        MyErrorProvider.SetError(ctrl, String.Empty)
        Try
            Dim answer = (ctrl.Text).Any(Function(x) Char.IsWhiteSpace(x))
            ValidateMinLength(ctrl.Text, PasswordMinLength)
            ValidateNoWhiteSpace(ctrl.Text)
        Catch ex As Exception
            MyErrorProvider.SetError(ctrl, ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub LoginForm_Closing(sender As Object, e As CancelEventArgs) _
        Handles Me.Closing

        e.Cancel = False
    End Sub

End Class
