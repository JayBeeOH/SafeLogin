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
' Class:          PersonDB
'
' Author:         Joseph L. Bolen
' Date Created:   06 JUN 2017
'
' Description:    Demonstration of not storing passwords, but storing the salt and hash.
'
'-------------------------------------------------------------------------------------------'
'                 Documentation is at:
'                   App's documentation is at:  https://jaybeeoh.github.io/SafeLogin/
'                   Video tutorials at YouTube: http://www.youtube.com/user/bolenpresents
'-------------------------------------------------------------------------------------------
Imports System.Data.SqlClient

Public Class PersonDB

    Public Shared Function GetPersonIDByUserName(name As String) As Integer
        Dim query As String = "SELECT PersonId " &
                              "FROM Person " &
                              "WHERE UserName=@UserName;"
        Try
            Using con As SqlConnection = JLBSampleDB.GetConnection()
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserName", name)
                    con.Open()
                    Return Convert.ToInt32(cmd.ExecuteScalar)
                End Using
            End Using

        Catch ex As SqlException
            Throw ex
            Return Nothing
        End Try

    End Function

    Public Shared Function InsertPersonByUserName(p As Person) As Integer
        Dim query As String = "INSERT INTO Person (" &
                              "TitleID, FirstName, MiddleName, LastName, SuffixID, UserName) VALUES (" &
                              "@TitleID, @FirstName, @MiddleName, @LastName, @SuffixID, @UserName); " &
                              "SELECT SCOPE_IDENTITY();"
        Try
            Using con As SqlConnection = JLBSampleDB.GetConnection()
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@TitleID", IIf(p.TitleID.Value < 1, DBNull.Value, p.TitleID))
                    cmd.Parameters.AddWithValue("@FirstName", p.FirstName)
                    cmd.Parameters.AddWithValue("@MiddleName", IIf(String.IsNullOrWhiteSpace(p.MiddleName), DBNull.Value, p.MiddleName))
                    cmd.Parameters.AddWithValue("@LastName", p.LastName)
                    cmd.Parameters.AddWithValue("@SuffixID", IIf(p.SuffixID.Value < 1, DBNull.Value, p.SuffixID))
                    cmd.Parameters.AddWithValue("@UserName", p.UserName)
                    con.Open()
                    Return Convert.ToInt32(cmd.ExecuteScalar)
                End Using
            End Using

        Catch ex As SqlException
            Throw ex
            Return Nothing
        End Try

    End Function

End Class
