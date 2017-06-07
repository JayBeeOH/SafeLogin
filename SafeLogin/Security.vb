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
' Class:          Security
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

Imports System.Security.Cryptography

Public Class Security

    Public Structure HashBytes
        Public Salt() As Byte
        Public Hash() As Byte
    End Structure

    Public Shared Function GetSalt(size As Integer) As Byte()

        Dim salt(size) As Byte

        Using rngCsp As New RNGCryptoServiceProvider()
            rngCsp.GetBytes(salt)
        End Using
        Return salt
    End Function

    Public Shared Function Hash(password As String, saltLength As Integer, hashLength As Integer) As HashBytes

        Using deriveBytes As New Rfc2898DeriveBytes(password, saltLength, 10000)
            Return New HashBytes With {
                .Salt = deriveBytes.Salt,
                .Hash = deriveBytes.GetBytes(hashLength)}
        End Using
    End Function

    Public Shared Function Verify(password As String, salt As Byte(), hash As Byte()) As Boolean
        Using deriveBytes = New Rfc2898DeriveBytes(password, salt, 10000)
            Return deriveBytes.GetBytes(hash.Length).SequenceEqual(hash)
        End Using
    End Function

End Class
