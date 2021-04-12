Imports System.Data.SqlClient

Public Class Form1
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If txtusername.Text = "" Then
            MessageBox.Show("Please enter the Username")
        ElseIf txtPassword.Text = "" Then
            MessageBox.Show("Please enter the Password")
        End If

        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\source\repos\test1\test1\Database1.mdf;Integrated Security=True"
        Dim Sql As String = "Select count (*) From Users where Username=@txtusername and Password=@txtPassword"
        Dim Conn As New SqlConnection(str)
        Try
            Conn.Open()
            Dim cmd As New SqlCommand(Sql, Conn)
            cmd.Parameters.AddWithValue("@txtusername", txtusername.Text)
            cmd.Parameters.AddWithValue("@txtPassword", txtPassword.Text)
            Dim value = cmd.ExecuteScalar()
            If value > 0 Then
                MessageBox.Show("login Successfull")
                Form3.Show()
                Me.Hide()
            Else
                MessageBox.Show("The Username and Password incorrect")
            End If
        Catch ex As Exception
            Console.WriteLine("Exception caught :{0}", ex)
        End Try
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusername.Focus()
    End Sub
End Class