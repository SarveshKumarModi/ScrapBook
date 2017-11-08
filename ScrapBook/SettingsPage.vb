Imports System.Data.SqlClient
Public Class SettingsPage
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        HomePage.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        MainPage.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sql = " Delete From login Where UserName='" & Label1.Text & "' "
        cmd = New SqlClient.SqlCommand(sql, conn)
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Profile Deactivated")
            Me.Hide()
            DeactivateSubPage.Show()
        Catch ae As SqlException
            MessageBox.Show(ae.Message.ToString())
        End Try
    End Sub

    Public Sub writelabeltolabel(ByVal txt As String)
        Label1.Text = txt
    End Sub
    Private Sub SettingsPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn = New SqlConnection(connectionstring)
        executesqlstmt(sql)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        ProfilePage.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Support.writelabeltolabel(Label1.Text)
        Support.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Credits.Show()
    End Sub
End Class