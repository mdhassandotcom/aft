<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1User = New System.Windows.Forms.TextBox()
        Me.TextBox2Pass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(339, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "WELCOME TO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(249, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(323, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "AFT MOTEL BOOKING SYSTEM"
        '
        'TextBox1User
        '
        Me.TextBox1User.Location = New System.Drawing.Point(261, 201)
        Me.TextBox1User.Name = "TextBox1User"
        Me.TextBox1User.PlaceholderText = "Type Your Username Here"
        Me.TextBox1User.Size = New System.Drawing.Size(311, 27)
        Me.TextBox1User.TabIndex = 2
        '
        'TextBox2Pass
        '
        Me.TextBox2Pass.Location = New System.Drawing.Point(261, 266)
        Me.TextBox2Pass.Name = "TextBox2Pass"
        Me.TextBox2Pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox2Pass.PlaceholderText = "Type Your Password Here"
        Me.TextBox2Pass.Size = New System.Drawing.Size(311, 27)
        Me.TextBox2Pass.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(156, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Username : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(156, 269)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Password :"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(261, 332)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 38)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Login"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(443, 332)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(129, 38)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(697, 30)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(81, 34)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "🏠 Home"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'AdminLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2Pass)
        Me.Controls.Add(Me.TextBox1User)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "AdminLogin"
        Me.Text = "AdminLogin"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1User As TextBox
    Friend WithEvents TextBox2Pass As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
