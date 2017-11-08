Imports System.Data.SqlClient
Public Class ChatPost
    Private Sub ChatPost_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New SqlConnection(connectionstring)
        executesqlstmt(sql)
    End Sub
    Public Sub writelabeltolabel(ByVal txt As String)
        Label1.Text = txt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Please fill the blank boxes")
        Else
            sql = "insert into Chats  (UserName,Messages) values ('" & Label1.Text & "','" & TextBox1.Text & "' )"
            cmd = New SqlClient.SqlCommand(sql, conn)

            Try
                cmd.ExecuteNonQuery()

                ChatPage.ChatsTableAdapter.Fill(ChatPage.ScrapDBDataSet.Chats)

            Catch ae As SqlException
                MessageBox.Show(ae.Message.ToString())
            End Try
            TextBox1.Text = ""
        End If
    End Sub
End Class