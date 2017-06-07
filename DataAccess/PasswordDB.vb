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
' Class:          PasswordDB
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

Public Class PasswordDB

    Public Shared Function GetSaltAndHashByID(id As Integer, ByRef salt As Byte(), ByRef hash As Byte()) As Boolean
        Dim query As String = "SELECT PasswordSalt, PasswordHash " &
                              "FROM Password " &
                              " WHERE PersonID=@PersonID;"
        Try
            Using con As SqlConnection = JLBSampleDB.GetConnection()
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@PersonID", id)
                    con.Open()
                    Using rdr As SqlDataReader = cmd.ExecuteReader
                        Do While rdr.Read
                            salt = CType(rdr.GetSqlBinary(0), Byte())
                            hash = CType(rdr.GetSqlBinary(1), Byte())
                            Return True
                        Loop
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            Throw ex
        End Try
        Return False
    End Function

    Public Shared Function SaveSaltAndHashByID(id As Integer, salt As Byte(), hash As Byte()) As Boolean
        Dim query As String = "INSERT INTO Password (PersonID, PasswordSalt, PasswordHash) " &
                                           "VALUES (@PersonID, @PasswordSalt, @PasswordHash)"
        Try
            Using con As SqlConnection = JLBSampleDB.GetConnection()
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@PersonID", id)
                    cmd.Parameters.AddWithValue("@PasswordSalt", salt)
                    cmd.Parameters.AddWithValue("@PasswordHash", hash)

                    con.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As SqlException
            Throw ex
        End Try
        Return False
    End Function
End Class
