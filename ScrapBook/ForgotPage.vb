Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class ForgotPage
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        MainPage.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Please fill the blank boxes")
        ElseIf TextBox2.Text = "" Then
            MsgBox("Please fill the blank boxes")
        Else sql = " Update login Set Password = '" & TextBox3.Text & "'   WHERE Email ='" & TextBox2.Text & "'"
            cmd = New SqlClient.SqlCommand(sql, conn)
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Passowrd Resest Done!!!")

            Catch ae As SqlException
                MessageBox.Show(ae.Message.ToString())
            End Try
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub ForgotPage_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn = New SqlConnection(connectionstring)
        executesqlstmt(sql)
    End Sub
    Private Sub TextBox2_Leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        Dim check As Boolean
        check = EmailAddressCheck(TextBox2.Text)
        If check = False Then
            MsgBox("Enter a Valid Email", MsgBoxStyle.Exclamation, "Warning")
            TextBox2.Focus()
        End If

    End Sub
    Function EmailAddressCheck(ByVal emailaddress As String) As Boolean
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailaddressMatch As Match = Regex.Match(emailaddress, pattern)
        If emailaddressMatch.Success Then
            EmailAddressCheck = True
        Else
            EmailAddressCheck = False
        End If
    End Function
End Class