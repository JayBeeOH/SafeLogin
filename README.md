# SafeLogin
Demonstration of not storing passwords, but storing the salt and hash.

SAFE LOGIN DEMO APP

Many newbie programmers wish to code a Login application, but lack the understanding of security in today’s world.  This SafeLogin demo app, shows one way to create a login program without saving the user’s password, but rather saves only a derived random salt and hash which strongly challenges unwanted compromise to user’s data. Note: this program does not use additional encryption although it could be implemented.

The Rfc2898DeriveBytes Class Implements PBKDF2 which is a pseudorandom function and can be used to create a salt and hash for password security. The idea Is to never store a user's password, but only the derived salt and hash of the password. Then the salt and hash are used for validation for future authentication. For father learning, see "Rfc2898DeriveBytes Class" of the .NET Framework.

This app uses MS SQL Express database for the backend data store. However, it will work with all fully supported SQL databases with little changes. The SafeLogin app was coded in Visual Basic .NET.
