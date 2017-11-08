Imports System.Data.SqlClient
Public Class Support
    Private Sub Support_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ScrapDBDataSet.Support' table. You can move, or remove it, as needed.
        Me.SupportTableAdapter.Fill(Me.ScrapDBDataSet.Support)
        conn = New SqlConnection(connectionstring)
        executesqlstmt(sql)
    End Sub

    Public Sub writelabeltolabel(ByVal txt As String)
        Label1.Text = txt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Please fill the blank boxe")
        Else sql = "insert into Support  (UserName, Messages) values ('" & Label1.Text & "','" & TextBox1.Text & "' )"
            cmd = New SqlClient.SqlCommand(sql, conn)

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Support Message Sent")
                Me.SupportTableAdapter.Fill(Me.ScrapDBDataSet.Support)

            Catch ae As SqlException
                MessageBox.Show(ae.Message.ToString())
            End Try
            TextBox1.Text = ""

        End If
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        MainPage.Show()
    End Sub


End Class