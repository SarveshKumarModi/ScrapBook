
Imports System.Data.SqlClient
Public Class ProfilePage
    Dim connection As New SqlConnection("Server= (localdb)\ProjectsV13; Database = ScrapDB; Integrated Security = true")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        HomePage.Show()
    End Sub
    Public Sub writelabeltolabel(ByVal txt As String)
        Label2.Text = txt
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        MainPage.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sql = " Update login Set Email = '" & TextBox3.Text & "' , About = '" & TextBox2.Text & "', Occupation = '" & ComboBox1.Text & "', Phone = " & TextBox4.Text & " WHERE UserName='" & Label2.Text & "' "
        cmd = New SqlClient.SqlCommand(sql, conn)
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Profile Updated")

        Catch ae As SqlException
            MessageBox.Show(ae.Message.ToString())
        End Try
        ComboBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""


    End Sub

    Private Sub ProfilePage_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn = New SqlConnection(connectionstring)
        executesqlstmt(sql)

    End Sub
End Class