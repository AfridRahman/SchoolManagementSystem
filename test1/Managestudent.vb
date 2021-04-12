Imports System.Data.DataTable
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Entity
Imports System.IO
Public Class Managestudent

    Dim Conn0 As New SqlConnection


    Private Sub Managestudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet.Students' table. You can move, or remove it, as needed.
        Conn0.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\source\repos\test1\test1\Database1.mdf;Integrated Security=True"
        Conn0.Open()
        datagridShow()
        datagridShow1()
        datagridShow2()
        datagridShow3()
        datagridShow4()
        datagridShow5()
        datagridShow6()
        datagridShow7()
        datagridShow8()
        datagridShow9()




    End Sub


    Private Sub datagridShow()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Students where Class ='Class 1'", Conn0)

            da.Fill(dt)
            DataGridView1.DataSource = dt.DefaultView
            Conn0.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub
    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        UpdateStudent1.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub datagridShow1()
        Dim ds1 As New Database1DataSet
        Dim dt1 As New DataTable
        Try
            ds1.Tables.Add(dt1)
            Dim da1 As New SqlDataAdapter
            da1 = New SqlDataAdapter("Select * from Students where Class = 'Class 2'", Conn0)
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
            da2 = New SqlDataAdapter("Select * from Students where Class = 'Class 3'", Conn0)
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
            da3 = New SqlDataAdapter("Select * from  Students where Class = 'Class 4'", Conn0)
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
            da4 = New SqlDataAdapter("Select * from Students where Class = 'Class 5'", Conn0)
            da4.Fill(dt4)
            DataGridView5.DataSource = dt4.DefaultView
            Conn0.Close()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub




    Private Sub datagridShow5()
        Dim ds5 As New Database1DataSet
        Dim dt5 As New DataTable
        Try
            ds5.Tables.Add(dt5)
            Dim da5 As New SqlDataAdapter
            da5 = New SqlDataAdapter("Select * from Students where Class = 'Class 6'", Conn0)
            da5.Fill(dt5)
            DataGridView6.DataSource = dt5.DefaultView
            Conn0.Close()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub datagridShow6()
        Dim ds6 As New Database1DataSet
        Dim dt6 As New DataTable
        Try
            ds6.Tables.Add(dt6)
            Dim da6 As New SqlDataAdapter
            da6 = New SqlDataAdapter("Select * from Students where Class = 'Class 7'", Conn0)
            da6.Fill(dt6)
            DataGridView7.DataSource = dt6.DefaultView
            Conn0.Close()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub
    Private Sub datagridShow7()
        Dim ds7 As New Database1DataSet
        Dim dt7 As New DataTable
        Try
            ds7.Tables.Add(dt7)
            Dim da7 As New SqlDataAdapter
            da7 = New SqlDataAdapter("Select * from Students where Class = 'Class 8'", Conn0)
            da7.Fill(dt7)
            DataGridView8.DataSource = dt7.DefaultView


            Conn0.Close()


        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub
    Private Sub datagridShow8()
        Dim ds8 As New Database1DataSet
        Dim dt8 As New DataTable
        Try
            ds8.Tables.Add(dt8)
            Dim da8 As New SqlDataAdapter
            da8 = New SqlDataAdapter("Select * from Students where Class = 'Class 9'", Conn0)
            da8.Fill(dt8)
            DataGridView9.DataSource = dt8.DefaultView
            Conn0.Close()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub
    Private Sub datagridShow9()
        Dim ds9 As New Database1DataSet
        Dim dt9 As New DataTable
        Try
            ds9.Tables.Add(dt9)
            Dim da9 As New SqlDataAdapter
            da9 = New SqlDataAdapter("Select * from Students where Class = 'Class 10'", Conn0)
            da9.Fill(dt9)
            DataGridView10.DataSource = dt9.DefaultView
            Conn0.Close()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub DataGridView6_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView6.CellContentClick

    End Sub

    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click
        UpdateStudent1.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Updatestudent1.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        UpdateStudent1.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        UpdateStudent1.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        UpdateStudent1.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        UpdateStudent1.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        UpdateStudent1.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        UpdateStudent1.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        UpdateStudent1.ShowDialog()
        Me.Hide()
    End Sub
End Class