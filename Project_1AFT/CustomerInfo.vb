Imports System.Data
Imports System.Data.SqlClient
Public Class CustomerInfo
    Private Sub TextBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Please Enter Number Only")
            e.Handled = True
        End If

    End Sub
    Private Sub CustomerInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBox2.Hide()
        GroupBox3.Hide()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        CustomerMainview.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox1.Text IsNot "" Then
            Dim con As New SqlConnection(DBconfig)
            Dim command As New SqlCommand("Select * from aft_customer where cid=" + TextBox1.Text + "", con)
            Dim sda As New SqlDataAdapter(command)
            Dim dt As New DataTable()

            sda.Fill(dt)
            If (dt.Rows.Count > 0) Then
                GroupBox2.Show()
                GroupBox3.Show()
                TextBox2.Text = dt.Rows(0)("cname").ToString()
                TextBox3.Text = dt.Rows(0)("cemail").ToString()
                TextBox4.Text = dt.Rows(0)("cphone").ToString()
                TextBox5.Text = dt.Rows(0)("caddress").ToString()
            Else
                GroupBox2.Hide()
                GroupBox3.Hide()
                MessageBox.Show("No Customer Found! Please check the IC Number or register a new customer.")
            End If
            con.Close()
        Else
            MessageBox.Show("Please Enter IC Number.")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            Dim con As New SqlConnection(DBconfig)
            Dim command As New SqlCommand("Update aft_customer
            SET [cname] = '" + TextBox2.Text + "'
            ,[cemail] = '" + TextBox3.Text + "'
            ,[cphone] = '" + TextBox4.Text + "'
            ,[caddress] = '" + TextBox5.Text + "'
            WHERE cid=" + TextBox1.Text + "", con)
            con.Open()
            command.ExecuteNonQuery()
            MessageBox.Show("Customer Info Updated")
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Exception: {0}", ex.Message)
            MessageBox.Show("We found an error, Please contact with super admin.")
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim con As New SqlConnection(DBconfig)
            Dim command As New SqlCommand("DELETE FROM aft_customer
            WHERE cid=" + TextBox1.Text + "", con)
            con.Open()
            command.ExecuteNonQuery()
            MessageBox.Show("Customer Info Deleted")
            con.Close()
            TextBox1.Text = ""
            GroupBox2.Hide()
            GroupBox3.Hide()
        Catch ex As Exception
            MessageBox.Show("Exception: {0}", ex.Message)
            MessageBox.Show("We found an error, Please contact with super admin.")
        End Try
    End Sub
End Class