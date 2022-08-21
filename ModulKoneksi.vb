Imports System.Data.Odbc
Module ModulKoneksi
    Public Conn As Odbc.OdbcConnection
    Public Da As OdbcDataAdapter
    Public Ds As DataSet
    Public CMd As OdbcCommand
    Public Rd As OdbcDataReader
    Public MyDB As String

    Public Sub Koneksi()
        MyDB = "Dsn=konek_dbabsensi"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
End Module
