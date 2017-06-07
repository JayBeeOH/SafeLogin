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
' Class:          MainForm
'
' Author:         Joseph L. Bolen
' Date Created:   06 JUN 2017
'
' Description:    Demonstration of not storing passwords, but storing the salt and hash.
'
'                 Documentation is at:
'                   App's documentation is at:  https://jaybeeoh.github.io/SafeLogin/
'                   Video tutorials at YouTube: http://www.youtube.com/user/bolenpresents
'-------------------------------------------------------------------------------------------

Public Class MainForm

    Public Property UserId As Integer
    Public Property UserName As String

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(id As Integer, name As String)
        InitializeComponent()

        UserId = id
        UserName = name
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        IDValueLabel.Text = UserId.ToString
        UserNameValueLabel.Text = UserName
    End Sub
End Class
