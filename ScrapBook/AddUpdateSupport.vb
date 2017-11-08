Imports System.Data.SqlClient
Public Class AddUpdateSupport

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Don't keep blank Credentials for User ")

        ElseIf TextBox2.Text = "" Then
            MsgBox("Don't keep blank Credentials for message")

        Else
            sql = " Update Support Set Reply='" & TextBox2.Text & "' WHERE UserName='" & TextBox1.Text & "' "
            cmd = New SqlClient.SqlCommand(sql, conn)
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Replied User")
                SupportHandler.SupportTableAdapter.Fill(SupportHandler.ScrapDBDataSet.Support)
            Catch ae As SqlException
                MessageBox.Show(ae.Message.ToString())
            End Try
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub AddUpdateSupport_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn = New SqlConnection(connectionstring)
        executesqlstmt(sql)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Don't keep blank Credentials for Title ")


        Else
            sql = " Delete From Support Where UserName='" & TextBox1.Text & "' "
            cmd = New SqlClient.SqlCommand(sql, conn)
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Messages Deleted")
                SupportHandler.SupportTableAdapter.Fill(SupportHandler.ScrapDBDataSet.Support)
            Catch ae As SqlException
                MessageBox.Show(ae.Message.ToString())
            End Try
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub
End Class