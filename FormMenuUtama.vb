﻿Public Class FormMenuUtama
    Public nameAdmin As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormMasterData.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormReport.ShowDialog()


    End Sub

    Private Sub FormMenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = nameAdmin
    End Sub


End Class