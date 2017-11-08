
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions


Public Class MainPage

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Don't keep blank Credentials for UserName")

        ElseIf TextBox2.Text = "" Then
            MsgBox("Don't keep blank Credentials for Password")
        Else
            sql = "select UserName, Password from Login where UserName = '" & TextBox1.Text & "'AND Password = '" & TextBox2.Text & "'"
            cmd = New SqlCommand(sql, conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Try
                If dr.Read = False Then
                    MessageBox.Show(“Ooops!! Login Failed”)
                Else
                    MessageBox.Show(“Welcome Back...!!!”)
                    Me.Hide()
                    HomePage.Show()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            dr.Close()

            HomePage.writetextboxtolabel(TextBox1.Text)
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox3.Text = "" Then
            MsgBox("Don't keep blank Credentials for UserName")
        ElseIf TextBox4.Text = "" Then
            MsgBox("Don't keep blank Credentials for Password")

        Else
            sql = "insert into Login  (UserName, Password, Email) values ('" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
            cmd = New SqlClient.SqlCommand(sql, conn)

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Welcome New User...!!!")
                Me.Hide()
                HomePage.Show()

            Catch ae As SqlException
                MessageBox.Show(ae.Message.ToString())
            End Try
            HomePage.writetextboxtolabel(TextBox3.Text)
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
        End If
    End Sub

    Private Sub HomePage_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn = New SqlConnection(connectionstring)
        executesqlstmt(sql)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        AdminLoginPage.Show()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Me.Hide()
        ForgotPage.Show()
    End Sub

    Private Sub TextBox5_Leave(sender As Object, e As EventArgs) Handles TextBox5.Leave
        Dim check As Boolean
        check = EmailAddressCheck(TextBox5.Text)
        If check = False Then
            MsgBox("Enter a Valid Email", MsgBoxStyle.Exclamation, "Warning")
            TextBox5.Focus()
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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Credits.Show()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class