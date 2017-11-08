Imports System.Data.SqlClient
Public Class AddUpdateBooks
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Don't keep blank Credentials for Title ")

        ElseIf TextBox2.Text = "" Then
            MsgBox("Don't keep blank Credentials for Details")
        ElseIf TextBox3.text = "" Then
            MsgBox("Don't keep blank Credentials for Author  ")
        Else
            sql = "insert into Books  (Title, Details, Author) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
            cmd = New SqlClient.SqlCommand(sql, conn)

            Try
                cmd.ExecuteNonQuery()
                MsgBox(" Book Posted")
                BooksHandler.BooksTableAdapter.Fill(BooksHandler.ScrapDBDataSet.Books)

            Catch ae As SqlException
                MessageBox.Show(ae.Message.ToString())
            End Try
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub AddUpdateBooks_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn = New SqlConnection(connectionstring)
        executesqlstmt(sql)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Don't keep blank Credentials for Title ")


        Else
            sql = " Delete From Books Where Title='" & TextBox1.Text & "' "
            cmd = New SqlClient.SqlCommand(sql, conn)
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Book Deleted")
                BooksHandler.BooksTableAdapter.Fill(BooksHandler.ScrapDBDataSet.Books)
            Catch ae As SqlException
                MessageBox.Show(ae.Message.ToString())
            End Try
        End If
        TextBox1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If TextBox1.Text = "" Then
            MsgBox("Don't keep blank Credentials for Title ")

        ElseIf TextBox2.Text = "" Then
            MsgBox("Don't keep blank Credentials for Details")
        ElseIf TextBox3.Text = "" Then
            MsgBox("Don't keep blank Credentials for Author  ")
        Else
            sql = " Update Books Set Details='" & TextBox2.Text & "', Author = '" & TextBox3.Text & "' WHERE Title='" & TextBox1.Text & "' "
            cmd = New SqlClient.SqlCommand(sql, conn)
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Book Updated")
                BooksHandler.BooksTableAdapter.Fill(BooksHandler.ScrapDBDataSet.Books)
            Catch ae As SqlException
                MessageBox.Show(ae.Message.ToString())
            End Try
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
End Class