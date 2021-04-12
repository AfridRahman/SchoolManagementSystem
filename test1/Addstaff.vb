Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.DateTimePicker
Public Class Addstaff
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
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

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        txtFullname.Text = ""
        txtPhonenumber.Text = ""
        txtStaffid.Text = ""
        txtEmail.Text = ""
        txtAddress.Text = ""
        cmbAge.Value = 0
        cmbDesgination.Text = ""
        cmbGender.Text = ""

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        If txtFullname.Text = "" Or txtStaffid.Text = "" Or txtEmail.Text = "" Or txtAddress.Text = "" Or txtPhonenumber.Text = "" Or cmbAge.Value = 0 Or cmbGender.Text = "" Then
            MsgBox("Fill in the Required Fields", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Exit Sub

        End If
        If txtPhonenumber.TextLength < 10 Then
            MsgBox("Please enter the Correct phone number", MsgBoxStyle.Exclamation)
        ElseIf txtPhonenumber.TextLength > 10 Then
            MsgBox("Please enter the Correct phone number", MsgBoxStyle.Exclamation)
            Exit Sub

        End If

        Dim str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin\source\repos\test1\test1\Database1.mdf;Integrated Security=True"
        Dim sql As String = "Insert into Teachers(StaffID,FullName,Gender,Age,Designation,Address,PhoneNumber,Email,Image,Date) Values('" & txtStaffid.Text & "','" & txtFullname.Text & "','" & cmbGender.Text & "','" & cmbAge.Value & "','" & cmbDesgination.Text & "','" & txtAddress.Text & "','" & txtPhonenumber.Text & "','" & txtEmail.Text & "',@img,@d1)"
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


            txtFullname.Text = ""
            txtPhonenumber.Text = ""
            txtStaffid.Text = ""
            txtEmail.Text = ""
            txtAddress.Text = ""
            cmbAge.Value = 0
            cmbDesgination.Text = ""
            cmbGender.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Conn.Dispose()
        End Try

    End Sub

    Private Sub Addstaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class