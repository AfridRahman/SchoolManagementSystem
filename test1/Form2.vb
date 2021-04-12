Imports System.Data.SqlClient
Imports System.IO
Public Class Form2

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        txtRgisterNumber.Text = ""
        txtPhonenumber.Text = ""
        txtFullName.Text = ""
        txtEmail.Text = ""
        txtAddress.Text = ""
        cmbAge.Value = 0
        cmbClass.Text = ""
        cmbGender.Text = ""
        cmbDate = Nothing
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
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

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If txtRgisterNumber.Text = "" Or txtFullName.Text = "" Or txtEmail.Text = "" Or txtAddress.Text = "" Or txtPhonenumber.Text = "" Or cmbAge.Value = 0 Or cmbClass.Text = "" Or cmbGender.Text = "" Then
            MsgBox("Fill in the Required Fields", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Exit Sub

        End If
        If txtPhonenumber.TextLength < 10 Then
            MsgBox("Please enter the Correct phone number", MsgBoxStyle.Exclamation)
        ElseIf txtPhonenumber.TextLength > 10 Then
            MsgBox("Please enter the Correct phone number", MsgBoxStyle.Exclamation)
            Exit Sub

        End If

        Dim d1 As DateTime = cmbDate.Value
        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\source\repos\test1\test1\Database1.mdf;Integrated Security=True"
        Dim sql As String = "Insert into Students(RegisterNumber,FullName,Gender,Age,Address,PhoneNumber,Email,Class,Image,Date) Values('" & txtRgisterNumber.Text & "','" & txtFullName.Text & "','" & cmbGender.Text & "','" & cmbAge.Value & "','" & txtAddress.Text & "','" & txtPhonenumber.Text & "','" & txtEmail.Text & "','" & cmbClass.Text & "',@img,@d1)"
        Dim Conn As New SqlConnection(str)
        Dim RD As SqlDataReader
        Dim ms As New MemoryStream()


        Try
            Conn.Open()
            Dim cmd As New SqlCommand(sql, Conn)
            cmd.Parameters.AddWithValue("@d1", SqlDbType.DateTime)

            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@img", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            RD = cmd.ExecuteReader
            MessageBox.Show("Data saved")
            Conn.Close()


            txtRgisterNumber.Text = ""
            txtPhonenumber.Text = ""
            txtFullName.Text = ""
            txtEmail.Text = ""
            txtAddress.Text = ""
            cmbAge.Value = 0
            cmbClass.Text = ""
            cmbGender.Text = ""
            cmbDate = Nothing
            PictureBox1.Image = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Conn.Dispose()
        End Try


    End Sub

    
Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.Image = Nothing
    End Sub






End Class