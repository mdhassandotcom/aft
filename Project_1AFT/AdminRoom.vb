Imports System.Data
Imports System.Data.SqlClient

Public Class AdminRoom
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        WelcomeAdmin.Show()
    End Sub

    Private Sub AdminRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Hide()
        Label3.Hide()
        Label4.Hide()
        Label5.Hide()

        ComboBox1.Hide()
        TextBox3.Hide()
        TextBox4.Hide()
        TextBox5.Hide()

        Button7.Hide()
        Button8.Hide()

        ComboBox1.Text = "Select Room Type"
        With ComboBox1.Items
            .Add("Standard")
            .Add("Family")
            .Add("Deluxe")
        End With

    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button7.Hide()
        Button8.Hide()
        If TextBox1.Text IsNot "" Then
            Dim con As New SqlConnection(DBconfig)
            Dim command As New SqlCommand("Select * from aft_room where roomnumber=" + TextBox1.Text + "", con)
            Dim sda As New SqlDataAdapter(command)
            Dim dt As New DataTable()

            sda.Fill(dt)
            If (dt.Rows.Count > 0) Then
                Label2.Show()
                Label3.Show()
                Label4.Show()
                Label5.Show()

                ComboBox1.Show()
                TextBox3.Show()
                TextBox4.Show()
                TextBox5.Show()

                ComboBox1.Text = dt.Rows(0)("roomtype").ToString()
                TextBox3.Text = dt.Rows(0)("roomprice").ToString()
                TextBox4.Text = dt.Rows(0)("roomnumber").ToString()
                TextBox5.Text = dt.Rows(0)("roomsize").ToString()

                ComboBox1.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
            Else
                Label2.Hide()
                Label3.Hide()
                Label4.Hide()
                Label5.Hide()

                ComboBox1.Hide()
                TextBox3.Hide()
                TextBox4.Hide()
                TextBox5.Hide()

                Button7.Hide()
                Button8.Hide()
                MessageBox.Show("No room Found.")
            End If
            con.Close()
        Else
            Label2.Hide()
            Label3.Hide()
            Label4.Hide()
            Label5.Hide()

            ComboBox1.Hide()
            TextBox3.Hide()
            TextBox4.Hide()
            TextBox5.Hide()
            MessageBox.Show("Please Enter Room Number.")
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button7.Show()
        Button8.Hide()

        Label2.Show()
        Label3.Show()
        Label4.Show()
        Label5.Show()

        ComboBox1.Show()
        TextBox3.Show()
        TextBox4.Show()
        TextBox5.Show()

        TextBox1.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

        ComboBox1.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If TextBox1.Text IsNot "" Then
            Try
                Dim con As New SqlConnection(DBconfig)
                Dim command As New SqlCommand("DELETE FROM aft_room
            WHERE roomnumber=" + TextBox1.Text + "", con)
                con.Open()
                command.ExecuteNonQuery()
                MessageBox.Show("Room Deleted")
                con.Close()
                TextBox1.Text = ""
                Label2.Hide()
                Label3.Hide()
                Label4.Hide()
                Label5.Hide()

                ComboBox1.Hide()
                TextBox3.Hide()
                TextBox4.Hide()
                TextBox5.Hide()

                Button7.Hide()
                Button8.Hide()
            Catch ex As Exception
                MessageBox.Show("Exception: {0}", ex.Message)
                MessageBox.Show("We found an error, Please contact with super admin.")
            End Try
        Else
            MessageBox.Show("Please Enter Room Number.")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button7.Hide()
        Button2.PerformClick()
        If TextBox1.Text IsNot "" Then
            Button8.Show()
        End If
        ComboBox1.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Label2.Show()
        Label3.Show()
        Label4.Show()
        Label5.Show()

        ComboBox1.Show()
        TextBox3.Show()
        TextBox4.Show()
        TextBox5.Show()
        Try
            Dim con As New SqlConnection(DBconfig)
            Dim command As New SqlCommand("INSERT INTO aft_room
           ([roomtype]
           ,[roomprice]
           ,[roomnumber]
           ,[roomsize])
     VALUES
           ('" + ComboBox1.Text + "',
           " + TextBox3.Text + ",
           " + TextBox4.Text + ",
           " + TextBox5.Text + ")", con)

            con.Open()
            command.ExecuteNonQuery()
            MessageBox.Show("New Room Added")
            con.Close()

        Catch ex As Exception
            MessageBox.Show("Exception: {0}", ex.Message)
            MessageBox.Show("We found an error, Please contact with super admin.")
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Label2.Show()
        Label3.Show()
        Label4.Show()
        Label5.Show()

        ComboBox1.Show()
        TextBox3.Show()
        TextBox4.Show()
        TextBox5.Show()

        If TextBox1.Text IsNot "" Then
            Try
                Dim con As New SqlConnection(DBconfig)
                Dim command As New SqlCommand("Update aft_room
            SET [roomtype] = '" + ComboBox1.Text + "'
            ,[roomprice] = " + TextBox3.Text + "
            ,[roomnumber] = " + TextBox4.Text + "
            ,[roomsize] = " + TextBox5.Text + "
            WHERE roomnumber=" + TextBox1.Text + "", con)
                con.Open()
                command.ExecuteNonQuery()
                MessageBox.Show("Room Details Updated")
                con.Close()
            Catch ex As Exception
                MessageBox.Show("Exception: {0}", ex.Message)
                MessageBox.Show("We found an error, Please contact with super admin.")
            End Try
        Else
            MessageBox.Show("Please Enter Room Number.")
        End If
    End Sub
End Class