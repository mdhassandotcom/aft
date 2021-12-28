Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class CustomerViewbooking
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        CustomerMainview.Show()
    End Sub

    Private Sub CustomerViewbooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Hide()
        Label3.Hide()
        Label4.Hide()
        Label5.Hide()
        Label6.Hide()
        Label7.Hide()
        Label8.Hide()
        Label9.Hide()
        Label10.Hide()
        Label11.Hide()
        Label12.Hide()
        Label13.Hide()
        Button3.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text IsNot "" Then
            Dim con As New SqlConnection(DBconfig)
            Dim command As New SqlCommand("Select * from aft_booking where bid=" + TextBox1.Text + "", con)
            Dim sda As New SqlDataAdapter(command)
            Dim dt As New DataTable()

            sda.Fill(dt)
            If (dt.Rows.Count > 0) Then
                Button3.Show()
                Label2.Show()
                Label3.Show()
                Label4.Show()
                Label5.Show()
                Label6.Show()
                Label7.Show()
                Label8.Show()
                Label9.Show()
                Label10.Show()
                Label11.Show()
                Label12.Show()
                Label13.Show()
                Label8.Text = dt.Rows(0)("customername").ToString()
                Label9.Text = dt.Rows(0)("customeremail").ToString()
                Label10.Text = dt.Rows(0)("customerphone").ToString()
                Label11.Text = dt.Rows(0)("croomtype").ToString() + " - " + dt.Rows(0)("croomnumber").ToString()
                Label12.Text = dt.Rows(0)("cdate").ToString()
                Label13.Text = dt.Rows(0)("ctotalprice").ToString()
            Else
                Label2.Hide()
                Label3.Hide()
                Label4.Hide()
                Label5.Hide()
                Label6.Hide()
                Label7.Hide()
                Label8.Hide()
                Label9.Hide()
                Label10.Hide()
                Label11.Hide()
                Label12.Hide()
                Label13.Hide()
                Button3.Hide()
                MessageBox.Show("No Booking Found.")
            End If
            con.Close()
        Else
            Button3.Hide()
            Label2.Hide()
            Label3.Hide()
            Label4.Hide()
            Label5.Hide()
            Label6.Hide()
            Label7.Hide()
            Label8.Hide()
            Label9.Hide()
            Label10.Hide()
            Label11.Hide()
            Label12.Hide()
            Label13.Hide()
            MessageBox.Show("Please Enter Booking Number.")
        End If
    End Sub

    'Private bitmap As Bitmap
    Private Sub BookPrint()
        'Dim height As Integer = DataGridView1.Height
        'DataGridView1.Height = DataGridView1.RowCount * DataGridView1.RowTemplate.Height
        'bitmap = New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        'DataGridView1.DrawToBitmap(bitmap, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()


    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        BookPrint()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font As New Font("Arial", 16, FontStyle.Regular)
        Dim fontbold As New Font("Arial", 16, FontStyle.Bold)
        Dim fontHead As New Font("Arial", 28, FontStyle.Bold)
        Dim fontend As New Font("Arial", 16, FontStyle.Italic)
        e.Graphics.DrawString("AFT MOTEL", fontHead, Brushes.Blue, 300, 50)
        e.Graphics.DrawString("All Details", fontbold, Brushes.Black, 150, 200)
        e.Graphics.DrawString("------------", fontbold, Brushes.Black, 150, 220)
        e.Graphics.DrawString("Name: " + Label8.Text, font, Brushes.Black, 150, 250)
        e.Graphics.DrawString("Email: " + Label9.Text, font, Brushes.Black, 150, 280)
        e.Graphics.DrawString("Phone: " + Label10.Text, font, Brushes.Black, 150, 310)
        e.Graphics.DrawString("Room Type & Number: " + Label11.Text, font, Brushes.Black, 150, 340)
        e.Graphics.DrawString("Leave Date: " + Label12.Text, font, Brushes.Black, 150, 370)
        e.Graphics.DrawString("Total Price: RM " + Label13.Text, fontbold, Brushes.Black, 150, 400)

        e.Graphics.DrawString("Booking ID: " + TextBox1.Text, font, Brushes.Green, 150, 500)


        e.Graphics.DrawString("THANK YOU FOR CHOSSING US. ENJOY YOUR STAY!! ", fontend, Brushes.LightPink, 150, 600)
    End Sub
End Class