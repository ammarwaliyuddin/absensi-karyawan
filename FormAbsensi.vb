Imports System.Data.Odbc
Imports System.Windows.Forms.AxHost

Public Class FormAbsensi
    Public nameAdmin As String
    Public myDate As String
    Public myDateNow As String

    Sub FieldAktif()
        Button1.Enabled = False
        Button2.Enabled = False


    End Sub
    Private Sub FormAbsensi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call FieldAktif()
        Call Koneksi()

        CMd = New OdbcCommand("Select * from tbl_karyawan where nip ='" & nameAdmin & "' ", Conn)
        Rd = CMd.ExecuteReader
        Rd.Read()
        TextBox1.Text = Rd.Item("nama")
        TextBox2.Text = Rd.Item("nip")
        TextBox3.Text = Rd.Item("nama")

        myDateNow = Format(Date.Now, “yyyy-MM-dd”)
        CMd = New OdbcCommand("Select * from tbl_absensi where nip ='" & TextBox2.Text & "' and tanggal_absen='" & myDateNow & "' ", Conn)
        Rd = CMd.ExecuteReader
        Rd.Read()

        'Dim dt = New DateTime(Rd.Item("waktu_datang")).ToString("HH:mm")
        If Rd.HasRows Then
            ComboBox1.SelectedItem = Rd.Item("status")
            ComboBox1.Enabled = False
            If Rd.Item("status") = "Hadir" Then
                Label10.Text = Rd.Item("waktu_datang")
                Label13.Text = Rd.Item("waktu_pulang")
                Button1.Enabled = False


                If Rd.Item("waktu_pulang") = "" Then
                    Button2.Enabled = True

                Else
                    Button2.Enabled = False
                    Button4.Hide()
                    TextBox6.Enabled = False
                End If
            Else
                Button1.Enabled = False
                Button2.Enabled = False
                Button4.Hide()
                TextBox6.Enabled = False

            End If
        End If

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label7.Text = TimeOfDay
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Hadir" Then
            Button1.Enabled = True
        Else
            Call FieldAktif()
        End If
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        myDate = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        myDateNow = Format(Date.Now, “yyyy-MM-dd”)

        If ComboBox1.Text = "" Then
            MsgBox("Pastikan semua field terisi")

        Else
            Call Koneksi()
            If Rd.HasRows Then
                If Rd.Item("waktu_pulang") = "" Then
                    Dim InputData As String = "Update tbl_absensi Set waktu_pulang='" & Label13.Text & "', keterangan='" & TextBox6.Text & "' where nip ='" & TextBox2.Text & "' "
                    CMd = New Odbc.OdbcCommand(InputData, Conn)
                    CMd.ExecuteNonQuery()
                    MsgBox("Data Berhasil Tersimpan")
                End If

            Else
                Dim InputData As String = "INSERT INTO tbl_absensi Set nip='" & TextBox2.Text & "', tanggal_absen='" & myDate & "', waktu_datang='" & Label10.Text & "', waktu_pulang='" & Label13.Text & "', status='" & ComboBox1.Text & "', keterangan='" & TextBox6.Text & "' "
                CMd = New Odbc.OdbcCommand(InputData, Conn)
                CMd.ExecuteNonQuery()

                Call queryToReport()
                MsgBox("Data Berhasil Tersimpan")
            End If


            'Call KondisiAwal()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label10.Text = Now.ToLongTimeString

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label13.Text = Now.ToLongTimeString
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub

    Sub queryToReport()
        Call Koneksi()
        CMd = New OdbcCommand("SELECT a.nip,b.nama,
                                COUNT(CASE WHEN a.`status` = 'Hadir' THEN 1 END) Hadir, 
                                COUNT(CASE WHEN a.`status` = 'Ijin' THEN 1 END) Ijin,
	                            COUNT(CASE WHEN a.`status` = 'Sakit' THEN 1 END) Sakit, 
                                COUNT(CASE WHEN a.`status` = 'Alpa' THEN 1 END) Alpa
                                FROM
	                                tbl_absensi a
                                LEFT JOIN tbl_karyawan b on b.nip = a.NIP
                                WHERE a.NIP = '" & TextBox2.Text & "' ", Conn)
        Rd = CMd.ExecuteReader
        Rd.Read()

        Dim InputReport As String = "INSERT INTO tbl_laporan Set nip='" & Rd.Item("nip") & "', nama='" & Rd.Item("nama") & "', hadir='" & Rd.Item("Hadir") & "', ijin='" & Rd.Item("Ijin") & "', sakit='" & Rd.Item("Sakit") & "', alpa='" & Rd.Item("Alpa") & "' "
        CMd = New Odbc.OdbcCommand(InputReport, Conn)
        CMd.ExecuteNonQuery()
    End Sub
End Class