Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging

Public Class UpdateStaff
    Dim con As New SqlConnection

    Dim cmd As New SqlCommand
    Private Sub UpdateStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet.Teachers' table. You can move, or remove it, as needed.
        Me.TeachersTableAdapter.Fill(Me.Database1DataSet.Teachers)
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\source\repos\test1\test1\Database1.mdf;Integrated Security=True"
        con.Open()
        txtStaffid.Text = ""
        txtFullName.Text = ""
        cmbGender.Text = ""
        cmbAge.Value = 0
        txtAddress.Text = ""
        txtPhoneNumber.Text = ""
        txtEmail.Text = ""
        cmbDesignation.Text = ""
        DataGridView1.RowTemplate.Height = 80
        DataGridView2.RowTemplate.Height = 80
        DataGridView3.RowTemplate.Height = 80
        DataGridView4.RowTemplate.Height = 80
        DataGridView5.RowTemplate.Height = 80
        datagridShow()
        datagridShow1()
        datagridShow2()
        datagridShow3()
        datagridShow4()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If txtStaffid.Text = "" Or txtFullName.Text = "" Or txtPhoneNumber.Text = "" Or txtEmail.Text = "" Or cmbDesignation.Text = "" Or cmbGender.Text = "" Then
            MsgBox("Incomplete Data")

        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Teachers set   FullName = '" & txtFullName.Text & "',Gender ='" & cmbGender.Text & "', Age = '" & cmbAge.Value & "', Address = '" & txtAddress.Text & "',PhoneNumber='" & txtPhoneNumber.Text & "',Email='" & txtEmail.Text & "',Designation='" & cmbDesignation.Text & "',Image=@img where StaffID='" & txtStaffid.Text & "' and  Designation ='ADMIN' ", con)
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()

            MsgBox("Staff updated")
            con.Close()
            datagridShow()

        End If

    End Sub
    Private Sub datagridShow()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Teachers where Designation='ADMIN'", con)

            da.Fill(dt)
            DataGridView1.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With OpenFileDialog1
            .Title = "Select Student Photo"
            .Filter = "JPEG Images Only|*.jpg"
            .FileName = ""
            .Multiselect = False
            .ShowDialog()
            If .FileName <> "" Then
                PictureBox1.Load(.FileName)
            End If
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtStaffid.Text = Row.Cells(1).Value.ToString
            txtFullName.Text = Row.Cells(2).Value.ToString
            cmbGender.Text = Row.Cells(3).Value.ToString
            cmbAge.Value = Row.Cells(4).Value.ToString
            txtAddress.Text = Row.Cells(6).Value.ToString
            txtPhoneNumber.Text = Row.Cells(7).Value.ToString
            txtEmail.Text = Row.Cells(8).Value.ToString
            cmbDesignation.Text = Row.Cells(5).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox1.Image = Image.FromStream(ms)
        End If
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        If txtStaffid.Text = "" Then
            MsgBox("No Staff selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Teachers where StaffID='" & txtStaffid.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow()
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Addstaff.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.Image = Nothing
    End Sub





    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        If txtStaffid1.Text = "" Or txtFullName1.Text = "" Or txtPhoneNumber1.Text = "" Or txtEmail1.Text = "" Or cmbDesignation1.Text = "" Or cmbGender1.Text = "" Then
            MsgBox("Incomplete Data")

        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Teachers set   FullName = '" & txtFullName1.Text & "',Gender ='" & cmbGender1.Text & "', Age = '" & cmbAge1.Value & "', Address = '" & txtAddress1.Text & "',PhoneNumber='" & txtPhoneNumber1.Text & "',Email='" & txtEmail1.Text & "',Designation='" & cmbDesignation1.Text & "',Image=@img where StaffID='" & txtStaffid1.Text & "' and  Designation ='Teacher' ", con)
            PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()

            MsgBox("Staff updated")
            con.Close()
            datagridShow1()

        End If
    End Sub
    Private Sub datagridShow1()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Teachers where Designation='Teachers'", con)

            da.Fill(dt)
            DataGridView2.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With OpenFileDialog1
            .Title = "Select Student Photo"
            .Filter = "JPEG Images Only|*.jpg"
            .FileName = ""
            .Multiselect = False
            .ShowDialog()
            If .FileName <> "" Then
                PictureBox2.Load(.FileName)
            End If
        End With
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            txtStaffid1.Text = Row.Cells(1).Value.ToString
            txtFullName1.Text = Row.Cells(2).Value.ToString
            cmbGender1.Text = Row.Cells(3).Value.ToString
            cmbAge1.Value = Row.Cells(4).Value.ToString
            txtAddress1.Text = Row.Cells(6).Value.ToString
            txtPhoneNumber1.Text = Row.Cells(7).Value.ToString
            txtEmail1.Text = Row.Cells(8).Value.ToString
            cmbDesignation1.Text = Row.Cells(5).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox2.Image = Image.FromStream(ms)
        End If
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        If txtStaffid1.Text = "" Then
            MsgBox("No Staff selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Teachers where StaffID='" & txtStaffid1.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow1()
        End If
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Addstaff.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PictureBox2.Image = Nothing
    End Sub





    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        If txtStaffid2.Text = "" Or txtFullName2.Text = "" Or txtPhoneNumber2.Text = "" Or txtEmail2.Text = "" Or cmbDesignation2.Text = "" Or cmbGender2.Text = "" Then
            MsgBox("Incomplete Data")

        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Teachers set   FullName = '" & txtFullName2.Text & "',Gender ='" & cmbGender2.Text & "', Age = '" & cmbAge2.Value & "', Address = '" & txtAddress2.Text & "',PhoneNumber='" & txtPhoneNumber2.Text & "',Email='" & txtEmail2.Text & "',Designation='" & cmbDesignation2.Text & "',Image=@img where StaffID='" & txtStaffid2.Text & "' and  Designation ='Manager' ", con)
            PictureBox3.Image.Save(ms, PictureBox3.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()

            MsgBox("Staff updated")
            con.Close()
            datagridShow2()

        End If
    End Sub
    Private Sub datagridShow2()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Teachers where Designation='Manager'", con)

            da.Fill(dt)
            DataGridView3.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With OpenFileDialog1
            .Title = "Select Student Photo"
            .Filter = "JPEG Images Only|*.jpg"
            .FileName = ""
            .Multiselect = False
            .ShowDialog()
            If .FileName <> "" Then
                PictureBox3.Load(.FileName)
            End If
        End With
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView3.Rows(e.RowIndex)
            txtStaffid2.Text = Row.Cells(1).Value.ToString
            txtFullName2.Text = Row.Cells(2).Value.ToString
            cmbGender2.Text = Row.Cells(3).Value.ToString
            cmbAge2.Value = Row.Cells(4).Value.ToString
            txtAddress2.Text = Row.Cells(6).Value.ToString
            txtPhoneNumber2.Text = Row.Cells(7).Value.ToString
            txtEmail2.Text = Row.Cells(8).Value.ToString
            cmbDesignation2.Text = Row.Cells(5).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox3.Image = Image.FromStream(ms)
        End If
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        If txtStaffid2.Text = "" Then
            MsgBox("No Staff selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Teachers where StaffID='" & txtStaffid2.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow2()
        End If
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Addstaff.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        PictureBox3.Image = Nothing
    End Sub




    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click
        If txtStaffid3.Text = "" Or txtFullName3.Text = "" Or txtPhoneNumber3.Text = "" Or txtEmail3.Text = "" Or cmbDesignation3.Text = "" Or cmbGender3.Text = "" Then
            MsgBox("Incomplete Data")

        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Teachers set   FullName = '" & txtFullName3.Text & "',Gender ='" & cmbGender3.Text & "', Age = '" & cmbAge3.Value & "', Address = '" & txtAddress3.Text & "',PhoneNumber='" & txtPhoneNumber3.Text & "',Email='" & txtEmail3.Text & "',Designation='" & cmbDesignation3.Text & "',Image=@img where StaffID='" & txtStaffid3.Text & "' and  Designation ='Accountant' ", con)
            PictureBox4.Image.Save(ms, PictureBox4.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()

            MsgBox("Staff updated")
            con.Close()
            datagridShow3()

        End If
    End Sub
    Private Sub datagridShow3()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Teachers where Designation='Accountant'", con)

            da.Fill(dt)
            DataGridView4.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        With OpenFileDialog1
            .Title = "Select Student Photo"
            .Filter = "JPEG Images Only|*.jpg"
            .FileName = ""
            .Multiselect = False
            .ShowDialog()
            If .FileName <> "" Then
                PictureBox4.Load(.FileName)
            End If
        End With
    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView4.Rows(e.RowIndex)
            txtStaffid3.Text = Row.Cells(1).Value.ToString
            txtFullName3.Text = Row.Cells(2).Value.ToString
            cmbGender3.Text = Row.Cells(3).Value.ToString
            cmbAge3.Value = Row.Cells(4).Value.ToString
            txtAddress3.Text = Row.Cells(6).Value.ToString
            txtPhoneNumber3.Text = Row.Cells(7).Value.ToString
            txtEmail3.Text = Row.Cells(8).Value.ToString
            cmbDesignation3.Text = Row.Cells(5).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox4.Image = Image.FromStream(ms)
        End If
    End Sub

    Private Sub Guna2Button12_Click(sender As Object, e As EventArgs) Handles Guna2Button12.Click
        If txtStaffid3.Text = "" Then
            MsgBox("No Staff selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Teachers where StaffID='" & txtStaffid3.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow3()
        End If
    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        Addstaff.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        PictureBox4.Image = Nothing
    End Sub




    Private Sub Guna2Button14_Click(sender As Object, e As EventArgs) Handles Guna2Button14.Click
        If txtStaffid4.Text = "" Or txtFullName4.Text = "" Or txtPhoneNumber4.Text = "" Or txtEmail4.Text = "" Or cmbDesignation4.Text = "" Or cmbGender4.Text = "" Then
            MsgBox("Incomplete Data")

        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Teachers set   FullName = '" & txtFullName4.Text & "',Gender ='" & cmbGender4.Text & "', Age = '" & cmbAge4.Value & "', Address = '" & txtAddress4.Text & "',PhoneNumber='" & txtPhoneNumber4.Text & "',Email='" & txtEmail4.Text & "',Designation='" & cmbDesignation4.Text & "',Image=@img where StaffID='" & txtStaffid4.Text & "' and  Designation ='Other Staff' ", con)
            PictureBox5.Image.Save(ms, PictureBox5.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()

            MsgBox("Staff updated")
            con.Close()
            datagridShow4()

        End If
    End Sub
    Private Sub datagridShow4()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Teachers where Designation='Other Staff'", con)

            da.Fill(dt)
            DataGridView5.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        With OpenFileDialog1
            .Title = "Select Student Photo"
            .Filter = "JPEG Images Only|*.jpg"
            .FileName = ""
            .Multiselect = False
            .ShowDialog()
            If .FileName <> "" Then
                PictureBox5.Load(.FileName)
            End If
        End With
    End Sub

    Private Sub DataGridView5_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView5.Rows(e.RowIndex)
            txtStaffid4.Text = Row.Cells(1).Value.ToString
            txtFullName4.Text = Row.Cells(2).Value.ToString
            cmbGender4.Text = Row.Cells(3).Value.ToString
            cmbAge4.Value = Row.Cells(4).Value.ToString
            txtAddress4.Text = Row.Cells(6).Value.ToString
            txtPhoneNumber4.Text = Row.Cells(7).Value.ToString
            txtEmail4.Text = Row.Cells(8).Value.ToString
            cmbDesignation4.Text = Row.Cells(5).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox5.Image = Image.FromStream(ms)
        End If
    End Sub

    Private Sub Guna2Button15_Click(sender As Object, e As EventArgs) Handles Guna2Button15.Click
        If txtStaffid4.Text = "" Then
            MsgBox("No Staff selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Teachers where StaffID='" & txtStaffid4.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow4()
        End If
    End Sub

    Private Sub Guna2Button13_Click(sender As Object, e As EventArgs) Handles Guna2Button13.Click
        Addstaff.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        PictureBox5.Image = Nothing
    End Sub
End Class