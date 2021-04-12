Imports System.Data.DataTable
Imports System.Data.SqlClient
Imports System.Data

Public Class ADMIN
    Dim Conn0 As New SqlConnection
    Dim cmd As New SqlCommand
    Dim cmd2 As New SqlCommand
    Dim Conn1 As New SqlConnection

    Private Sub ADMIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet.Users' table. You can move, or remove it, as needed.
        'Me.UsersTableAdapter.Fill(Me.Database1DataSet.Users)
        Conn0.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\source\repos\test1\test1\Database1.mdf;Integrated Security=True"
        Conn1.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\source\repos\test1\test1\Database1.mdf;Integrated Security=True"
        cmd.Connection = Conn0
        cmd2.Connection = Conn1
        Conn0.Open()
        Conn1.Open()
        cmd.CommandText = "select StaffID from Teachers"
        Dim reader As SqlDataReader = cmd.ExecuteReader

        While (reader.Read())
            'Dim str2 As String = reader("StaffID")
            'Dim str1 As String = ""
            'Dim str0 As String = ""

            cmd2.CommandText = "insert into Users(Username, Password, StaffID) values (@name,@password,@staffid)"
            cmd2.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = ""
            cmd2.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = ""
            cmd2.Parameters.Add("@staffid", SqlDbType.VarChar, 50).Value = reader("StaffID")

            cmd2.ExecuteNonQuery()
            'MessageBox.Show(reader("StaffID"))

        End While
        reader.Close()
        Conn0.Close()
        Conn1.Close()
        datagridShow()
    End Sub
    Private Sub datagridShow()
        'Dim ds As New Database1DataSet
        'Dim dt As New DataTable

        'Try
        '    ds.Tables.Add(dt)
        '    'Dim da As New SqlDataAdapter
        '    Dim da1 As New SqlDataAdapter
        '    'da = New SqlDataAdapter("Select * from Users ", Conn0)
        '    da1 = New SqlDataAdapter("Select * from Teachers where Designation='ADMIN'", Conn0)
        '    'da.Fill(dt)
        '    da1.Fill(dt)
        '    DataGridView1.DataSource = dt.DefaultView
        '    Conn0.Close()
        'Catch ex As Exception
        '    MessageBox.Show(String.Format("Error:{0}", ex.Message))
        'End Try
        Dim adapt As New SqlDataAdapter
        Dim dt As New DataTable
        Conn0.Open()

        cmd.CommandText = "select * from Users"
        adapt.SelectCommand = cmd
        adapt.Fill(dt)
        DataGridView1.DataSource = dt
        Conn0.Close()

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If txtUsername.Text = "" And txtPassword.Text = "" Then
            MsgBox("Username and Password empty please enter the proper details")
        Else

            Dim sql As String = "Insert into Users(Username,Password)Values('" & txtUsername.Text & "','" & txtPassword.Text & "')"
            Conn0.Open()
            Dim cmd As New SqlCommand(sql, Conn0)
            Dim RD As SqlDataReader
            RD = cmd.ExecuteReader

            MessageBox.Show("Data saved")
            Conn0.Close()
            txtUsername.Text = ""
            txtPassword.Text = ""
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtStaffID.Text = Row.Cells(0).Value.ToString
            txtUsername.Text = Row.Cells(1).Value.ToString
            txtPassword.Text = Row.Cells(2).Value.ToString
        End If
    End Sub
End Class