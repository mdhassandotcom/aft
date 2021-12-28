
Imports System.Data
Imports System.Data.SqlClient
Public Class Form2

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DateTimePicker1.MinDate = Date.Now.Date

        DateTimePicker1.MaxDate = Date.Now.AddDays(30)

        GroupBox1.Hide()
        GroupBox2.Hide()

        ComboBox1.Text = "Select Room Type"
        With ComboBox1.Items
            .Add("Standard")
            .Add("Family")
            .Add("Deluxe")
        End With
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Dim Price As Double
        Dim Add As Double
        Dim TotalPayment As Double

        Price = Label2.Text
        Add = TextBox1.Text

        TotalPayment = (Label2.Text * Add)
        Label10.Text = (" RM " & TotalPayment)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            Dim con As New SqlConnection(DBconfig)
            Dim query As String = "INSERT INTO aft_booking
            ([customername]
           ,[customeremail]
           ,[customerphone]
           ,[croomtype]
           ,[croomnumber]
           ,[cdate]
           ,[ctotalprice])
     VALUES
           ('" + TextBox2.Text + "',
           '" + TextBox3.Text + "',
           '" + TextBox4.Text + "',
           '" + ComboBox1.Text + "',
           '" + ComboBox2.Text + "',
            @DtValue ,
           '" + Label11.Text + "'); SELECT CAST(scope_identity() AS int)"

            Dim command As New SqlCommand(query, con)
            command.Parameters.AddWithValue("DtValue", DateTimePicker1.Value.Date)
            con.Open()
            Dim GetBookID As Integer = command.ExecuteScalar()
            Label14.Text = "Your Booking Number is: " + GetBookID.ToString() + ""
            MessageBox.Show("Booking Info Added. Booking ID is: " + GetBookID.ToString() + "")
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Exception: {0}", ex.Message)
            MessageBox.Show("We found an error, Please contact with super admin.")
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Items.Clear()
        ComboBox2.Text = ""
        If ComboBox1.Text = "Standard" Then
            If TextBox1.Text IsNot "" Then
                Dim con As New SqlConnection(DBconfig)
                Dim command As New SqlCommand("Select * from aft_room where roomtype='" + ComboBox1.Text + "'", con)
                Dim sda As New SqlDataAdapter(command)
                Dim dt As New DataTable()
                sda.Fill(dt)
                Dim temp As Integer = 0
                While temp < dt.Rows.Count
                    ComboBox2.Items.Add(dt.Rows(temp)("roomnumber").ToString())
                    temp += 1
                End While
                con.Close()
            Else
                MessageBox.Show("Please Enter IC Number.")
            End If
        End If

        If ComboBox1.Text = "Family" Then
            If TextBox1.Text IsNot "" Then
                Dim con As New SqlConnection(DBconfig)
                Dim command As New SqlCommand("Select * from aft_room where roomtype='" + ComboBox1.Text + "'", con)
                Dim sda As New SqlDataAdapter(command)
                Dim dt As New DataTable()
                sda.Fill(dt)
                Dim temp As Integer = 0
                While temp < dt.Rows.Count
                    ComboBox2.Items.Add(dt.Rows(temp)("roomnumber").ToString())
                    temp += 1
                End While
                con.Close()
            Else
                MessageBox.Show("Please Enter IC Number.")
            End If
        End If

        If ComboBox1.Text = "Deluxe" Then
            If TextBox1.Text IsNot "" Then
                Dim con As New SqlConnection(DBconfig)
                Dim command As New SqlCommand("Select * from aft_room where roomtype='" + ComboBox1.Text + "'", con)
                Dim sda As New SqlDataAdapter(command)
                Dim dt As New DataTable()
                sda.Fill(dt)
                Dim temp As Integer = 0
                While temp < dt.Rows.Count
                    ComboBox2.Items.Add(dt.Rows(temp)("roomnumber").ToString())
                    temp += 1
                End While
                con.Close()
            Else
                MessageBox.Show("Please Enter IC Number.")
            End If
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text IsNot "" Then
            Dim con As New SqlConnection(DBconfig)
            Dim command As New SqlCommand("Select * from aft_customer where cid=" + TextBox1.Text + "", con)
            Dim sda As New SqlDataAdapter(command)
            Dim dt As New DataTable()

            sda.Fill(dt)
            If (dt.Rows.Count > 0) Then
                GroupBox1.Show()
                TextBox2.Text = dt.Rows(0)("cname").ToString()
                TextBox3.Text = dt.Rows(0)("cemail").ToString()
                TextBox4.Text = dt.Rows(0)("cphone").ToString()
            Else
                GroupBox1.Hide()
                GroupBox2.Hide()
                MessageBox.Show("No Customer Found! Please check the IC Number or register a new customer.")
            End If
            con.Close()
        Else
            MessageBox.Show("Please Enter IC Number.")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        CustomerMainview.Show()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        GroupBox2.Show()
        If ComboBox2.Text IsNot "" Then
            Dim con As New SqlConnection(DBconfig)
            Dim command As New SqlCommand("Select * from aft_room where roomnumber='" + ComboBox2.Text + "'", con)
            Dim sda As New SqlDataAdapter(command)
            Dim dt As New DataTable()
            sda.Fill(dt)

            Label2.Text = dt.Rows(0)("roomprice").ToString()

            Dim arrivaldate As Date = Date.Now
            Dim departuredate As Date = Me.DateTimePicker1.Value
            Dim DaysStayed As Int32 = departuredate.Subtract(arrivaldate).Days
            DaysStayed += 1
            Dim EachPrice As Int32 = Label2.Text
            Dim total As Int32 = EachPrice * DaysStayed

            Label13.Text = DaysStayed.ToString()
            Label11.Text = total.ToString()

            con.Close()
        Else
            MessageBox.Show("Please Enter IC Number.")
        End If

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Dim arrivaldate As Date = Date.Now
        Dim departuredate As Date = Me.DateTimePicker1.Value
        Dim DaysStayed As Int32 = departuredate.Subtract(arrivaldate).Days
        DaysStayed += 1
        Dim EachPrice As Int32 = Label2.Text
        Dim total As Int32 = EachPrice * DaysStayed

        Label13.Text = DaysStayed.ToString()
        Label11.Text = total.ToString()
    End Sub
End Class