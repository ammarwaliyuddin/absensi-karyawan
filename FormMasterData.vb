Imports System.Windows.Forms.VisualStyles

Public Class FormMasterData
    Public myDate As String
    Public myDateNow As String

    Private Sub FormMasterData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        DateTimePicker1.Text = ""
        ComboBox1.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        DateTimePicker1.Enabled = False
        ComboBox1.Enabled = False

        Button1.Text = "INPUT"
        Button2.Text = "EDIT"
        Button3.Text = "HAPUS"
        Button4.Text = "TUTUP"

        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = False


        Call Koneksi()
        Da = New Odbc.OdbcDataAdapter("Select * From tbl_karyawan", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_karyawan")
        DataGridView1.DataSource = Ds.Tables("tbl_karyawan")

    End Sub

    Sub FieldAktif()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        DateTimePicker1.Enabled = True
        ComboBox1.Enabled = True
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "INPUT" Then
            Button1.Text = "SIMPAN"
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Text = "BATAL"
            Call FieldAktif()
        Else

            myDate = Format(DateTimePicker1.Value, "yyyy-MM-dd")
            myDateNow = Format(Date.Now, “yyyy-MM-dd”)
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Pastikan semua field terisi")
            ElseIf myDate = myDateNow Then
                MsgBox("Tanggal yang anda masukkan hari ini")
            Else

                Call Koneksi()
                Dim InputData As String = "Insert into tbl_karyawan values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & myDate & "','" & ComboBox1.Text & "' )"
                CMd = New Odbc.OdbcCommand(InputData, Conn)
                CMd.ExecuteNonQuery()

                Dim InputDataAbsensi As String = "Insert into tbl_admin set username='" & TextBox1.Text & "', password='user' "
                CMd = New Odbc.OdbcCommand(InputDataAbsensi, Conn)
                CMd.ExecuteNonQuery()
                MsgBox("Input Data Berhasil")
                Call KondisiAwal()
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "EDIT" Then
            Button2.Text = "UPDATE"
            Button4.Text = "BATAL"
            Button1.Enabled = False
            Button3.Enabled = False
            Button5.Enabled = True

            Call FieldAktif()
        Else

            myDate = Format(DateTimePicker1.Value, "yyyy-MM-dd")
            myDateNow = Format(Date.Now, “dd MMMM yyyy”)
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Pastikan semua field terisi")
            ElseIf myDate = myDateNow Then
                MsgBox("Tanggal yang anda masukkan hari ini")
            Else
                Call Koneksi()
                Dim EditData As String = "Update tbl_karyawan set  nama = '" & TextBox2.Text & "', no_hp = '" & TextBox3.Text & "', unit = '" & TextBox4.Text & "', tanggal_lahir = '" & myDate & "', jenis_kelamin = '" & ComboBox1.Text & "' where nip = '" & TextBox1.Text & "' "
                CMd = New Odbc.OdbcCommand(EditData, Conn)
                CMd.ExecuteNonQuery()
                MsgBox("Edit Data Berhasil")
                Call KondisiAwal()
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Text = "TUTUP" Then
            End
        Else
            Call KondisiAwal()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Call Koneksi()
        CMd = New Odbc.OdbcCommand("Select * from tbl_karyawan where nip = '" & TextBox1.Text & "' ", Conn)
        Rd = CMd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            TextBox1.Text = Rd.Item("nip")
            TextBox2.Text = Rd.Item("nama")
            TextBox3.Text = Rd.Item("no_hp")
            TextBox4.Text = Rd.Item("unit")
            DateTimePicker1.Value = Rd.Item("tanggal_lahir")
            ComboBox1.Text = Rd.Item("jenis_kelamin")
        Else
            MsgBox("Tidak ada Data")

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "HAPUS" Then
            Button3.Text = "HAPUS DATA"
            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Text = "BATAL"
            Button5.Enabled = True
            Call FieldAktif()
        Else
            myDate = Format(DateTimePicker1.Value, "yyyy-MM-dd")
            myDateNow = Format(Date.Now, “dd MMMM yyyy”)
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("Pastikan Data Yang terhapus terisi")
            ElseIf myDate = myDateNow Then
                MsgBox("Tanggal yang anda masukkan hari ini")
            Else
                Call Koneksi()
                Dim HapusData As String = "Delete from tbl_karyawan where nip = '" & TextBox1.Text & "' "
                CMd = New Odbc.OdbcCommand(HapusData, Conn)
                CMd.ExecuteNonQuery()
                MsgBox("Hapus Data Berhasil")
                Call KondisiAwal()
            End If
        End If

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
End Class

