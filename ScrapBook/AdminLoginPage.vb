Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class AdminLoginPage
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Don't leave Blank Credentials")
        ElseIf TextBox1.Text = "" Then
            MsgBox("Don't leave Blank Credentials")
        Else
            sql = "select Admin, Password from Admin where Admin = '" & TextBox1.Text & "'AND Password = '" & TextBox2.Text & "'"
        cmd = New SqlCommand(sql, conn)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        Try
            If dr.Read = False Then
                MessageBox.Show(“OOOps login failed”)
            Else

                Me.Hide()
                AdminHome.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        dr.Close()
        AdminHome.writetextboxtolabel(TextBox1.Text)
        TextBox1.Text = ""
            TextBox2.Text = ""
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        MainPage.Show()
    End Sub

    Private Sub AdminLoginPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn = New SqlConnection(connectionstring)
        executesqlstmt(sql)

    End Sub
End Class