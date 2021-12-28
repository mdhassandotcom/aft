Imports System.Data
Imports System.Data.SqlClient
Public Class AdminLogin
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection(DBconfig)
        Dim command As New SqlCommand("Select * from aft_users where username='" + TextBox1User.Text + "' and password='" + TextBox2Pass.Text + "'", con)
        Dim sda As New SqlDataAdapter(command)
        Dim dt As New DataTable()

        sda.Fill(dt)
        If (dt.Rows.Count > 0) Then
            FullNames = dt.Rows(0)("fullname").ToString()
            TextBox1User.Text = ""
            TextBox2Pass.Text = ""
            WelcomeAdmin.Show()
            Me.Hide()
        Else
            MessageBox.Show("No User Found! Please check the username and password and try again.")
        End If
        con.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1User.Text = ""
        TextBox2Pass.Text = ""
    End Sub
End Class