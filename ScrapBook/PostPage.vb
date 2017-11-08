Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class PostPage
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        HomePage.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        MainPage.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Don't keep blank credentials")

        ElseIf TextBox2.Text = "" Then
            MsgBox("Don't keep blank credentials")
        ElseIf TextBox3.Text = "" Then
            MsgBox("Don't keep blank credentials")
        Else sql = "insert into Books (Title, Details, Author) values ('" & TextBox2.Text & "','" & TextBox1.Text & "','" & TextBox3.Text & "')"
                    cmd = New SqlClient.SqlCommand(sql, conn)
                    Try
                        cmd.ExecuteNonQuery()
                MsgBox("Book Posted!!!")
                Me.Hide()
                HomePage.BooksTableAdapter.Fill(HomePage.ScrapDBDataSet.Books)
                HomePage.Show()

            Catch ae As SqlException
                        MessageBox.Show(ae.Message.ToString())
                    End Try
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                End If
    End Sub

    Private Sub PostPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn = New SqlConnection(connectionstring)
        executesqlstmt(sql)
    End Sub
End Class