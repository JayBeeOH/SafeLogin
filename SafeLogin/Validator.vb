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
' Module:         Validator
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

Module Validator

    Public Function ValidateIsNumeric(ByVal value As String) As Boolean

        If Not IsNumeric(value) Then
            Throw New InvalidExpressionException("Value must be numeric.")
            Return False
        Else
            Return True
        End If

    End Function

    Public Function ValidateIsRequired(ByVal value As String) As Boolean

        If String.IsNullOrWhiteSpace(value) Then
            Throw New InvalidExpressionException("A value is required.")
            Return False
        Else
            Return True
        End If

    End Function

    Public Function ValidateInRange(ByVal value As String,
                                  ByVal minValue As Double,
                                  ByVal maxValue As Double) As Boolean

        Dim valueDouble As Double = 0
        Double.TryParse(value, valueDouble)
        If valueDouble < minValue OrElse valueDouble > maxValue Then
            Throw New InvalidExpressionException(String.Format("Value is out of range, please enter a number between {0} and {1}.", minValue, maxValue))
            Return False
        Else
            Return True
        End If

    End Function

    Public Function ValidateMinLength(ByVal value As String,
                                      ByVal minLength As Integer) As Boolean
        If value.Length < minLength Then
            Throw New InvalidExpressionException(String.Format("Value must have a minimum length of {0}.", minLength))
            Return False
        Else
            Return True
        End If
    End Function

    Public Function ValidateNoWhiteSpace(ByVal value As String) As Boolean
        If value.Any(Function(x) Char.IsWhiteSpace(x)) Then
            Throw New InvalidExpressionException("Value must not contain spaces.")
            Return False
        Else
            Return True
        End If
    End Function

End Module
