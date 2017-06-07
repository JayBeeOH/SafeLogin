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
' Class:          JLBSampleDB
'
' Author:         Joseph L. Bolen
' Date Created:   06 JUN 2017
'
' Description:    Demonstration of not storing passwords, but storing the salt and hash.
'                 The database's file location is retrieved from the App.config file.
'
'                 Note: Add Reference to System.Configuration to the Project.
'-------------------------------------------------------------------------------------------'
'                 Documentation is at:
'                   App's documentation is at:  https://jaybeeoh.github.io/SafeLogin/
'                   Video tutorials at YouTube: http://www.youtube.com/user/bolenpresents
'-------------------------------------------------------------------------------------------


Imports System.Configuration
Imports System.Data.SqlClient

Public Class JLBSampleDB

    Public Shared Function GetConnection() As SqlConnection
        Dim conn As String = ConfigurationManager.ConnectionStrings("JLBSampleDB").ConnectionString
        Return New SqlConnection(conn)
    End Function

End Class
