Imports System.Data.Odbc
Public Class FormLogin
    'Public nameAdmin As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Username atau Password Tidak Boleh Kosong")
        Else
            Call Koneksi()
            CMd = New OdbcCommand("Select * from tbl_admin where username ='" & TextBox1.Text & "' and password = '" & TextBox2.Text & "' ", Conn)
            Rd = CMd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                If Rd.Item("username") = "admin" Then
                    Dim OBJ As New FormMenuUtama
                    OBJ.nameAdmin = Rd.Item("username")
                    OBJ.ShowDialog()
                Else
                    Dim OBJ As New FormAbsensi
                    OBJ.nameAdmin = Rd.Item("username")
                    OBJ.ShowDialog()

                End If
            Else
                MsgBox("Username atau Password Salah!")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


End Class