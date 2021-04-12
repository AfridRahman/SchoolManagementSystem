Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging
Public Class UpdateStudent0
    Dim con As New SqlConnection

    Dim cmd As New SqlCommand

    Private Sub UpdateStudent0_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        datagridShow()
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

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Hide()
        Form2.ShowDialog()
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.Image = Nothing
    End Sub
End Class