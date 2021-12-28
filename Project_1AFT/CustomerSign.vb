Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Public Class CustomerSign
    Private Sub TextBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Please Enter Number Only")
            e.Handled = True
        End If

    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Please Enter Number Only")
            e.Handled = True
        End If

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim regex As Regex = New Regex("^[^@\s]+@[^@\s]+\.[^@\s]+$")
        Dim isValid As Boolean = regex.IsMatch(TextBox3.Text.Trim)
        If isValid And Len(TextBox2.Text) = 12 Then
            Try
                Dim con As New SqlConnection(DBconfig)
                Dim command As New SqlCommand("INSERT INTO aft_customer
           ([icnumber]
           ,[cname]
           ,[cemail]
           ,[cphone]
           ,[caddress]
           ,[ccreateat])
     VALUES
           (" + TextBox2.Text + ",
           '" + TextBox1.Text + "',
           '" + TextBox3.Text + "',
           '" + TextBox4.Text + "',
           '" + TextBox5.Text + "',
           getdate()); SELECT CAST(scope_identity() AS int)", con)

                con.Open()
                Dim GetCustomerID As Integer = command.ExecuteScalar()
                MessageBox.Show("New Customer Added.")
                con.Close()
                Me.Hide()
                CustomerMainview.Show()
            Catch ex As Exception
                MessageBox.Show("Exception: {0}", ex.Message)
                MessageBox.Show("We found an error, Please contact with super admin.")
            End Try
        ElseIf Len(TextBox2.Text) < 12 Then
            MessageBox.Show("Please Enter Exactly 12 Digit Number.")
        Else
            MessageBox.Show("Please Enter a Valid Email Address.")
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        CustomerMainview.Show()
    End Sub

    Private Sub CustomerSign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.MaxLength = 12
    End Sub
End Class