Imports System.Data
Imports System.Data.SqlClient
Public Class WelcomeAdmin
    Private Sub WelcomeAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = Label1.Text + " " + FullNames
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        AdminLogin.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        AdminViewbooking.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        AdminRoom.Show()
    End Sub
End Class