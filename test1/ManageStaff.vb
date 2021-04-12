Imports System.Data.DataTable
Imports System.Data.SqlClient
Imports System.Data
Public Class ManageStaff
    Dim Conn0 As New SqlConnection

    Private Sub ManageStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Conn0.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\source\repos\test1\test1\Database1.mdf;Integrated Security=True"
        Conn0.Open()
        datagridShow()

        datagridShow1()

        datagridShow2()

        datagridShow3()

        datagridShow4()
    End Sub
    Private Sub datagridShow()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Teachers where Designation ='ADMIN'", Conn0)

            da.Fill(dt)
            DataGridView1.DataSource = dt.DefaultView
            Conn0.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub
    Private Sub datagridShow1()
        Dim ds1 As New Database1DataSet
        Dim dt1 As New DataTable
        Try
            ds1.Tables.Add(dt1)
            Dim da1 As New SqlDataAdapter
            da1 = New SqlDataAdapter("Select * from Teachers where Designation = 'Teachers'", Conn0)
            da1.Fill(dt1)
            DataGridView2.DataSource = dt1.DefaultView
            Conn0.Close()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub
    Private Sub datagridShow2()
        Dim ds2 As New Database1DataSet
        Dim dt2 As New DataTable
        Try
            ds2.Tables.Add(dt2)
            Dim da2 As New SqlDataAdapter
            da2 = New SqlDataAdapter("Select * from Teachers where Designation = 'Manager'", Conn0)
            da2.Fill(dt2)
            DataGridView3.DataSource = dt2.DefaultView
            Conn0.Close()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub
    Private Sub datagridShow3()
        Dim ds3 As New Database1DataSet
        Dim dt3 As New DataTable
        Try
            ds3.Tables.Add(dt3)
            Dim da3 As New SqlDataAdapter
            da3 = New SqlDataAdapter("Select * from Teachers where Designation = 'Accountant'", Conn0)
            da3.Fill(dt3)
            DataGridView4.DataSource = dt3.DefaultView
            Conn0.Close()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub
    Private Sub datagridShow4()
        Dim ds4 As New Database1DataSet
        Dim dt4 As New DataTable
        Try
            ds4.Tables.Add(dt4)
            Dim da4 As New SqlDataAdapter
            da4 = New SqlDataAdapter("Select * from Teachers where Designation = 'Other Staff'", Conn0)
            da4.Fill(dt4)
            DataGridView5.DataSource = dt4.DefaultView
            Conn0.Close()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        UpdateStaff.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        UpdateStaff.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        UpdateStaff.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        UpdateStaff.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        UpdateStaff.ShowDialog()
        Me.Close()
    End Sub
End Class