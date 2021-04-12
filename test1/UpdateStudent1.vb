Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging
Public Class UpdateStudent1
    Dim con As New SqlConnection

    Dim cmd As New SqlCommand
    Private Sub UpdateStudent1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet.Students' table. You can move, or remove it, as needed.
        Me.StudentsTableAdapter.Fill(Me.Database1DataSet.Students)
        con.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\source\repos\test1\test1\Database1.mdf;Integrated Security=True"
        con.Open()
        txtRegisterNumber.Text = ""
        txtFullName.Text = ""
        cmbGender.Text = ""
        cmbAge.Value = 0
        txtAddress.Text = ""
        txtPhoneNumber.Text = ""
        txtEmail.Text = ""
        cmbClass.Text = ""
        PictureBox1.Image = Nothing
        DataGridView1.RowTemplate.Height = 80
        DataGridView2.RowTemplate.Height = 80
        DataGridView3.RowTemplate.Height = 80
        DataGridView4.RowTemplate.Height = 80
        DataGridView5.RowTemplate.Height = 80
        DataGridView6.RowTemplate.Height = 80
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

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If txtRegisterNumber.Text = "" Or txtFullName.Text = "" Or txtPhoneNumber.Text = "" Or txtEmail.Text = "" Or cmbClass.Text = "" Or cmbGender.Text = "" Then
            MsgBox("Incomplete Data")

        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Students set   FullName = '" & txtFullName.Text & "',Gender ='" & cmbGender.Text & "', Age = '" & cmbAge.Value & "', Address = '" & txtAddress.Text & "',PhoneNumber='" & txtPhoneNumber.Text & "',Email='" & txtEmail.Text & "',Class='" & cmbClass.Text & "',Image=@img where RegisterNumber='" & txtRegisterNumber.Text & "' and  Class ='Class 1' ", con)
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()

            MsgBox("Student updated")
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
            da = New SqlDataAdapter("Select * from Students where Class='Class 1'", con)

            da.Fill(dt)
            DataGridView1.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtRegisterNumber.Text = Row.Cells(1).Value.ToString
            txtFullName.Text = Row.Cells(2).Value.ToString
            cmbGender.Text = Row.Cells(3).Value.ToString
            cmbAge.Value = Row.Cells(4).Value.ToString
            txtAddress.Text = Row.Cells(5).Value.ToString
            txtPhoneNumber.Text = Row.Cells(6).Value.ToString
            txtEmail.Text = Row.Cells(7).Value.ToString
            cmbClass.Text = Row.Cells(8).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox1.Image = Image.FromStream(ms)
        End If

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
    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        If txtRegisterNumber.Text = "" Then
            MsgBox("No Student selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Students where RegisterNumber='" & txtRegisterNumber.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow()
        End If
    End Sub




    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        If txtRegisterNumber1.Text = "" Or txtFullName1.Text = "" Or txtPhoneNumber1.Text = "" Or txtEmail1.Text = "" Or cmbClass1.Text = "" Or cmbGender1.Text = "" Then
            MsgBox("Incomplete Data")

        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Students set   FullName = '" & txtFullName1.Text & "',Gender ='" & cmbGender1.Text & "', Age = '" & cmbAge1.Value & "', Address = '" & txtAddress1.Text & "',PhoneNumber='" & txtPhoneNumber1.Text & "',Email='" & txtEmail1.Text & "',Class='" & cmbClass1.Text & "',Image=@img where RegisterNumber='" & txtRegisterNumber1.Text & "' and  Class ='Class 2' ", con)
            PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            MsgBox("Student updated")
            con.Close()
            datagridShow1()
            Me.Close()
        End If

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            txtRegisterNumber1.Text = Row.Cells(1).Value.ToString
            txtFullName1.Text = Row.Cells(2).Value.ToString
            cmbGender1.Text = Row.Cells(3).Value.ToString
            cmbAge1.Value = Row.Cells(4).Value.ToString
            txtAddress1.Text = Row.Cells(5).Value.ToString
            txtPhoneNumber1.Text = Row.Cells(6).Value.ToString
            txtEmail1.Text = Row.Cells(7).Value.ToString
            cmbClass1.Text = Row.Cells(8).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox2.Image = Image.FromStream(ms)
        End If
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
    Private Sub datagridShow1()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Students where Class='Class 2'", con)

            da.Fill(dt)
            DataGridView2.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        If txtRegisterNumber1.Text = "" Then
            MsgBox("No Student selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Students where RegisterNumber='" & txtRegisterNumber1.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow1()

        End If

    End Sub





    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        If txtRegisterNumber2.Text = "" Or txtFullName2.Text = "" Or txtPhoneNumber2.Text = "" Or txtEmail2.Text = "" Or cmbClass2.Text = "" Or cmbGender2.Text = "" Then
            MsgBox("Incomplete Data")
        ElseIf cmbClass2.Text <> "Class 3" Then
            MsgBox("Class and Student updated")
            Me.Close()
        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Students set   FullName = '" & txtFullName2.Text & "',Gender ='" & cmbGender2.Text & "', Age = '" & cmbAge2.Value & "', Address = '" & txtAddress2.Text & "',PhoneNumber='" & txtPhoneNumber2.Text & "',Email='" & txtEmail2.Text & "',Class='" & cmbClass2.Text & "',Image=@img where RegisterNumber='" & txtRegisterNumber2.Text & "' and  Class ='Class 3' ", con)
            PictureBox3.Image.Save(ms, PictureBox3.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            MsgBox("Student updated")
            con.Close()
            datagridShow2()

        End If
        If cmbClass2.Text <> "Class 3" Then
            Me.Close()
        End If
    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView3.Rows(e.RowIndex)
            txtRegisterNumber2.Text = Row.Cells(1).Value.ToString
            txtFullName2.Text = Row.Cells(2).Value.ToString
            cmbGender2.Text = Row.Cells(3).Value.ToString
            cmbAge2.Value = Row.Cells(4).Value.ToString
            txtAddress2.Text = Row.Cells(5).Value.ToString
            txtPhoneNumber2.Text = Row.Cells(6).Value.ToString
            txtEmail2.Text = Row.Cells(7).Value.ToString
            cmbClass2.Text = Row.Cells(8).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox3.Image = Image.FromStream(ms)
        End If
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
    Private Sub datagridShow2()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Students where Class='Class 3'", con)

            da.Fill(dt)
            DataGridView3.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        If txtRegisterNumber2.Text = "" Then
            MsgBox("No Student selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Students where RegisterNumber='" & txtRegisterNumber2.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow2()

        End If
    End Sub




    Private Sub Guna2Button11_Click(sender As Object, e As EventArgs) Handles Guna2Button11.Click
        If txtRegisterNumber3.Text = "" Or txtFullName3.Text = "" Or txtPhoneNumber3.Text = "" Or txtEmail3.Text = "" Or cmbClass3.Text = "" Or cmbGender3.Text = "" Then
            MsgBox("Incomplete Data")
        ElseIf cmbClass3.Text <> "Class 4" Then
            MsgBox("Class and Student updated")
            Me.Close()
        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Students set   FullName = '" & txtFullName3.Text & "',Gender ='" & cmbGender3.Text & "', Age = '" & cmbAge3.Value & "', Address = '" & txtAddress3.Text & "',PhoneNumber='" & txtPhoneNumber3.Text & "',Email='" & txtEmail3.Text & "',Class='" & cmbClass3.Text & "',Image=@img where RegisterNumber='" & txtRegisterNumber3.Text & "' and  Class ='Class 4' ", con)
            PictureBox4.Image.Save(ms, PictureBox4.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            MsgBox("Student updated")
            con.Close()
            datagridShow3()

        End If
        If cmbClass3.Text <> "Class 4" Then
            Me.Close()
        End If
    End Sub

    Private Sub DataGridView4_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView4.Rows(e.RowIndex)
            txtRegisterNumber3.Text = Row.Cells(1).Value.ToString
            txtFullName3.Text = Row.Cells(2).Value.ToString
            cmbGender3.Text = Row.Cells(3).Value.ToString
            cmbAge3.Value = Row.Cells(4).Value.ToString
            txtAddress3.Text = Row.Cells(5).Value.ToString
            txtPhoneNumber3.Text = Row.Cells(6).Value.ToString
            txtEmail3.Text = Row.Cells(7).Value.ToString
            cmbClass3.Text = Row.Cells(8).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox4.Image = Image.FromStream(ms)
        End If
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
    Private Sub datagridShow3()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Students where Class='Class 4'", con)

            da.Fill(dt)
            DataGridView4.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Guna2Button12_Click(sender As Object, e As EventArgs) Handles Guna2Button12.Click
        If txtRegisterNumber3.Text = "" Then
            MsgBox("No Student selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Students where RegisterNumber='" & txtRegisterNumber3.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow3()

        End If
    End Sub




    Private Sub Guna2Button17_Click(sender As Object, e As EventArgs) Handles Guna2Button17.Click
        If txtRegisterNumber4.Text = "" Or txtFullName4.Text = "" Or txtPhoneNumber4.Text = "" Or txtEmail4.Text = "" Or cmbClass4.Text = "" Or cmbGender4.Text = "" Then
            MsgBox("Incomplete Data")
        ElseIf cmbClass4.Text <> "Class 5" Then
            MsgBox("Class and Student updated")
            Me.Close()
        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Students set   FullName = '" & txtFullName4.Text & "',Gender ='" & cmbGender4.Text & "', Age = '" & cmbAge4.Value & "', Address = '" & txtAddress4.Text & "',PhoneNumber='" & txtPhoneNumber4.Text & "',Email='" & txtEmail4.Text & "',Class='" & cmbClass4.Text & "',Image=@img where RegisterNumber='" & txtRegisterNumber4.Text & "' and  Class ='Class 5' ", con)
            PictureBox5.Image.Save(ms, PictureBox5.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            MsgBox("Student updated")
            con.Close()
            datagridShow4()

        End If
        If cmbClass4.Text <> "Class 5" Then
            Me.Close()
        End If
    End Sub

    Private Sub DataGridView5_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView5.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView5.Rows(e.RowIndex)
            txtRegisterNumber4.Text = Row.Cells(1).Value.ToString
            txtFullName4.Text = Row.Cells(2).Value.ToString
            cmbGender4.Text = Row.Cells(3).Value.ToString
            cmbAge4.Value = Row.Cells(4).Value.ToString
            txtAddress4.Text = Row.Cells(5).Value.ToString
            txtPhoneNumber4.Text = Row.Cells(6).Value.ToString
            txtEmail4.Text = Row.Cells(7).Value.ToString
            cmbClass4.Text = Row.Cells(8).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox5.Image = Image.FromStream(ms)
        End If
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
    Private Sub datagridShow4()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Students where Class='Class 5'", con)

            da.Fill(dt)
            DataGridView5.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Guna2Button18_Click(sender As Object, e As EventArgs) Handles Guna2Button18.Click

        If txtRegisterNumber4.Text = "" Then
            MsgBox("No Student selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Students where RegisterNumber='" & txtRegisterNumber4.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow4()

        End If
    End Sub





    Private Sub Guna2Button20_Click(sender As Object, e As EventArgs) Handles Guna2Button20.Click
        If txtRegisterNumber5.Text = "" Or txtFullName5.Text = "" Or txtPhoneNumber5.Text = "" Or txtEmail5.Text = "" Or cmbClass5.Text = "" Or cmbGender5.Text = "" Then
            MsgBox("Incomplete Data")
        ElseIf cmbClass5.Text <> "Class 6" Then
            MsgBox("Class and Student updated")
            Me.Close()
        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Students set   FullName = '" & txtFullName5.Text & "',Gender ='" & cmbGender5.Text & "', Age = '" & cmbAge5.Value & "', Address = '" & txtAddress5.Text & "',PhoneNumber='" & txtPhoneNumber5.Text & "',Email='" & txtEmail5.Text & "',Class='" & cmbClass5.Text & "',Image=@img where RegisterNumber='" & txtRegisterNumber5.Text & "' and  Class ='Class 6' ", con)
            PictureBox6.Image.Save(ms, PictureBox6.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            MsgBox("Student updated")
            con.Close()
            datagridShow5()

        End If

    End Sub

    Private Sub DataGridView6_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView6.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView6.Rows(e.RowIndex)
            txtRegisterNumber5.Text = Row.Cells(1).Value.ToString
            txtFullName5.Text = Row.Cells(2).Value.ToString
            cmbGender5.Text = Row.Cells(3).Value.ToString
            cmbAge5.Value = Row.Cells(4).Value.ToString
            txtAddress5.Text = Row.Cells(5).Value.ToString
            txtPhoneNumber5.Text = Row.Cells(6).Value.ToString
            txtEmail5.Text = Row.Cells(7).Value.ToString
            cmbClass5.Text = Row.Cells(8).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox6.Image = Image.FromStream(ms)
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        With OpenFileDialog1
            .Title = "Select Student Photo"
            .Filter = "JPEG Images Only|*.jpg"
            .FileName = ""
            .Multiselect = False
            .ShowDialog()
            If .FileName <> "" Then
                PictureBox6.Load(.FileName)
            End If
        End With
    End Sub
    Private Sub datagridShow5()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Students where Class='Class 6'", con)

            da.Fill(dt)
            DataGridView6.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Guna2Button21_Click(sender As Object, e As EventArgs) Handles Guna2Button21.Click
        If txtRegisterNumber5.Text = "" Then
            MsgBox("No Student selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Students where RegisterNumber='" & txtRegisterNumber5.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow5()

        End If
    End Sub






    Private Sub Guna2Button23_Click(sender As Object, e As EventArgs) Handles Guna2Button23.Click
        If txtRegisterNumber6.Text = "" Or txtFullName6.Text = "" Or txtPhoneNumber6.Text = "" Or txtEmail6.Text = "" Or cmbClass6.Text = "" Or cmbGender6.Text = "" Then
            MsgBox("Incomplete Data")
        ElseIf cmbClass6.Text <> "Class 7" Then
            MsgBox("Class and Student updated")
            Me.Close()
        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Students set   FullName = '" & txtFullName6.Text & "',Gender ='" & cmbGender6.Text & "', Age = '" & cmbAge6.Value & "', Address = '" & txtAddress6.Text & "',PhoneNumber='" & txtPhoneNumber6.Text & "',Email='" & txtEmail6.Text & "',Class='" & cmbClass6.Text & "',Image=@img where RegisterNumber='" & txtRegisterNumber6.Text & "' and  Class ='Class 7' ", con)
            PictureBox7.Image.Save(ms, PictureBox7.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            MsgBox("Student updated")
            con.Close()
            datagridShow6()

        End If

    End Sub

    Private Sub DataGridView7_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView7.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView7.Rows(e.RowIndex)
            txtRegisterNumber6.Text = Row.Cells(1).Value.ToString
            txtFullName6.Text = Row.Cells(2).Value.ToString
            cmbGender6.Text = Row.Cells(3).Value.ToString
            cmbAge6.Value = Row.Cells(4).Value.ToString
            txtAddress6.Text = Row.Cells(5).Value.ToString
            txtPhoneNumber6.Text = Row.Cells(6).Value.ToString
            txtEmail6.Text = Row.Cells(7).Value.ToString
            cmbClass6.Text = Row.Cells(8).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox7.Image = Image.FromStream(ms)
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        With OpenFileDialog1
            .Title = "Select Student Photo"
            .Filter = "JPEG Images Only|*.jpg"
            .FileName = ""
            .Multiselect = False
            .ShowDialog()
            If .FileName <> "" Then
                PictureBox7.Load(.FileName)
            End If
        End With
    End Sub
    Private Sub datagridShow6()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Students where Class='Class 7'", con)

            da.Fill(dt)
            DataGridView7.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Guna2Button24_Click(sender As Object, e As EventArgs) Handles Guna2Button24.Click
        If txtRegisterNumber6.Text = "" Then
            MsgBox("No Student selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Students where RegisterNumber='" & txtRegisterNumber6.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow6()

        End If
    End Sub




    Private Sub Guna2Button26_Click(sender As Object, e As EventArgs) Handles Guna2Button26.Click
        If txtRegisterNumber7.Text = "" Or txtFullName7.Text = "" Or txtPhoneNumber7.Text = "" Or txtEmail7.Text = "" Or cmbClass7.Text = "" Or cmbGender7.Text = "" Then
            MsgBox("Incomplete Data")
        ElseIf cmbClass7.Text <> "Class 8" Then
            MsgBox("Class and Student updated")
            Me.Close()
        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Students set   FullName = '" & txtFullName7.Text & "',Gender ='" & cmbGender7.Text & "', Age = '" & cmbAge7.Value & "', Address = '" & txtAddress7.Text & "',PhoneNumber='" & txtPhoneNumber7.Text & "',Email='" & txtEmail7.Text & "',Class='" & cmbClass7.Text & "',Image=@img where RegisterNumber='" & txtRegisterNumber7.Text & "' and  Class ='Class 8' ", con)
            PictureBox8.Image.Save(ms, PictureBox8.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            MsgBox("Student updated")
            con.Close()
            datagridShow7()

        End If


    End Sub

    Private Sub DataGridView8_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView8.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView8.Rows(e.RowIndex)
            txtRegisterNumber7.Text = Row.Cells(1).Value.ToString
            txtFullName7.Text = Row.Cells(2).Value.ToString
            cmbGender7.Text = Row.Cells(3).Value.ToString
            cmbAge7.Value = Row.Cells(4).Value.ToString
            txtAddress7.Text = Row.Cells(5).Value.ToString
            txtPhoneNumber7.Text = Row.Cells(6).Value.ToString
            txtEmail7.Text = Row.Cells(7).Value.ToString
            cmbClass7.Text = Row.Cells(8).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox8.Image = Image.FromStream(ms)
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        With OpenFileDialog1
            .Title = "Select Student Photo"
            .Filter = "JPEG Images Only|*.jpg"
            .FileName = ""
            .Multiselect = False
            .ShowDialog()
            If .FileName <> "" Then
                PictureBox8.Load(.FileName)
            End If
        End With
    End Sub
    Private Sub datagridShow7()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Students where Class='Class 8'", con)

            da.Fill(dt)
            DataGridView8.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Guna2Button27_Click(sender As Object, e As EventArgs) Handles Guna2Button27.Click
        If txtRegisterNumber7.Text = "" Then
            MsgBox("No Student selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Students where RegisterNumber='" & txtRegisterNumber7.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow7()

        End If
    End Sub




    Private Sub Guna2Button29_Click(sender As Object, e As EventArgs) Handles Guna2Button29.Click
        If txtRegisterNumber8.Text = "" Or txtFullName8.Text = "" Or txtPhoneNumber8.Text = "" Or txtEmail8.Text = "" Or cmbClass8.Text = "" Or cmbGender8.Text = "" Then
            MsgBox("Incomplete Data")
        ElseIf cmbClass8.Text <> "Class 9 " Then
            MsgBox("Class and Student updated")
            Me.Close()
        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Students set   FullName = '" & txtFullName8.Text & "',Gender ='" & cmbGender8.Text & "', Age = '" & cmbAge8.Value & "', Address = '" & txtAddress8.Text & "',PhoneNumber='" & txtPhoneNumber8.Text & "',Email='" & txtEmail8.Text & "',Class='" & cmbClass8.Text & "',Image=@img where RegisterNumber='" & txtRegisterNumber8.Text & "' and  Class ='Class 9' ", con)
            PictureBox9.Image.Save(ms, PictureBox9.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            MsgBox("Student updated")
            con.Close()
            datagridShow8()

        End If

    End Sub

    Private Sub DataGridView9_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView9.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView9.Rows(e.RowIndex)
            txtRegisterNumber8.Text = Row.Cells(1).Value.ToString
            txtFullName8.Text = Row.Cells(2).Value.ToString
            cmbGender8.Text = Row.Cells(3).Value.ToString
            cmbAge8.Value = Row.Cells(4).Value.ToString
            txtAddress8.Text = Row.Cells(5).Value.ToString
            txtPhoneNumber8.Text = Row.Cells(6).Value.ToString
            txtEmail8.Text = Row.Cells(7).Value.ToString
            cmbClass8.Text = Row.Cells(8).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox9.Image = Image.FromStream(ms)
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        With OpenFileDialog1
            .Title = "Select Student Photo"
            .Filter = "JPEG Images Only|*.jpg"
            .FileName = ""
            .Multiselect = False
            .ShowDialog()
            If .FileName <> "" Then
                PictureBox9.Load(.FileName)
            End If
        End With
    End Sub
    Private Sub datagridShow8()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Students where Class='Class 9'", con)

            da.Fill(dt)
            DataGridView9.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Guna2Button28_Click(sender As Object, e As EventArgs) Handles Guna2Button28.Click
        If txtRegisterNumber8.Text = "" Then
            MsgBox("No Student selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Students where RegisterNumber='" & txtRegisterNumber8.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow8()

        End If
    End Sub





    Private Sub Guna2Button32_Click(sender As Object, e As EventArgs) Handles Guna2Button32.Click
        If txtRegisterNumber9.Text = "" Or txtFullName9.Text = "" Or txtPhoneNumber9.Text = "" Or txtEmail9.Text = "" Or cmbClass9.Text = "" Or cmbGender9.Text = "" Then
            MsgBox("Incomplete Data")
        ElseIf cmbClass9.Text <> "Class 10 " Then
            MsgBox("Class and Student updated")
            Me.Close()
        Else
            Dim ms As New MemoryStream()
            con.Open()
            Dim cmd As New SqlCommand("Update Students set   FullName = '" & txtFullName9.Text & "',Gender ='" & cmbGender9.Text & "', Age = '" & cmbAge9.Value & "', Address = '" & txtAddress9.Text & "',PhoneNumber='" & txtPhoneNumber9.Text & "',Email='" & txtEmail9.Text & "',Class='" & cmbClass9.Text & "',Image=@img where RegisterNumber='" & txtRegisterNumber9.Text & "' and  Class ='Class 10' ", con)
            PictureBox10.Image.Save(ms, PictureBox10.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            MsgBox("Student updated")
            con.Close()
            datagridShow9()

        End If
    End Sub

    Private Sub DataGridView10_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView10.CellContentClick
        If e.RowIndex >= 0 Then
            Dim Row As DataGridViewRow = DataGridView10.Rows(e.RowIndex)
            txtRegisterNumber9.Text = Row.Cells(1).Value.ToString
            txtFullName9.Text = Row.Cells(2).Value.ToString
            cmbGender9.Text = Row.Cells(3).Value.ToString
            cmbAge9.Value = Row.Cells(4).Value.ToString
            txtAddress9.Text = Row.Cells(5).Value.ToString
            txtPhoneNumber9.Text = Row.Cells(6).Value.ToString
            txtEmail9.Text = Row.Cells(7).Value.ToString
            cmbClass9.Text = Row.Cells(8).Value.ToString
            Dim bytes As [Byte]() = Row.Cells(0).Value
            Dim ms As New MemoryStream(bytes)
            PictureBox10.Image = Image.FromStream(ms)
        End If
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        With OpenFileDialog1
            .Title = "Select Student Photo"
            .Filter = "JPEG Images Only|*.jpg"
            .FileName = ""
            .Multiselect = False
            .ShowDialog()
            If .FileName <> "" Then
                PictureBox10.Load(.FileName)
            End If
        End With
    End Sub
    Private Sub datagridShow9()
        Dim ds As New Database1DataSet
        Dim dt As New DataTable

        Try
            ds.Tables.Add(dt)
            Dim da As New SqlDataAdapter
            da = New SqlDataAdapter("Select * from Students where Class='Class 10'", con)

            da.Fill(dt)
            DataGridView10.DataSource = dt.DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error:{0}", ex.Message))
        End Try
    End Sub

    Private Sub Guna2Button33_Click(sender As Object, e As EventArgs) Handles Guna2Button33.Click
        If txtRegisterNumber9.Text = "" Then
            MsgBox("No Student selected")
        Else
            con.Open()
            Dim query As String
            query = "Delete from Students where RegisterNumber='" & txtRegisterNumber9.Text & "'"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Record deleted successfully")
            con.Close()
            datagridShow9()

        End If
    End Sub
End Class