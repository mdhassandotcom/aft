Imports System.Data
Imports System.Data.SqlClient
Public Class AdminViewbooking
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub
    Private Sub AdminViewbooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Hide()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        WelcomeAdmin.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox1.Text IsNot "" Then
            Dim con As New SqlConnection(DBconfig)
            Dim command As New SqlCommand("Select * from aft_booking where bid=" + TextBox1.Text + "", con)
            Dim sda As New SqlDataAdapter(command)
            Dim dt As New DataTable()

            sda.Fill(dt)
            If (dt.Rows.Count > 0) Then
                DataGridView1.Show()
                DataGridView1.DataSource = dt
            Else
                MessageBox.Show("No Booking Found.")
            End If
            con.Close()
        Else
            MessageBox.Show("Please Insert an IC Number")
        End If
    End Sub
End Class