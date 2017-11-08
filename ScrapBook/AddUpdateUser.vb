Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class AddUpdateUser

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then
            MsgBox("Don't keep blank Credentials for UserName")

        ElseIf TextBox2.Text = "" Then
            MsgBox("Don't keep blank Credentials for Password")
        Else
            sql = " Update Login Set Password='" & TextBox2.Text & "', Email = '" & TextBox4.Text & "' , About = '" & TextBox3.Text & "', Occupation = '" & TextBox6.Text & "', Phone = '" & TextBox5.Text & "' WHERE UserName='" & TextBox1.Text & "' "
            cmd = New SqlClient.SqlCommand(sql, conn)
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Profile Updated")
                UsersHandler.LoginTableAdapter.Fill(UsersHandler.ScrapDBDataSet.Login)
            Catch ae As SqlException
                MessageBox.Show(ae.Message.ToString())
            End Try
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub

    Private Sub AddUpdateUser_Load(sender As Object, e As EventArgs) Handles Me.Load
        conn = New SqlConnection(connectionstring)
        executesqlstmt(sql)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Don't keep blank Credentials for UserName")


        Else
            sql = " Delete From login Where UserName='" & TextBox1.Text & "' "
            cmd = New SqlClient.SqlCommand(sql, conn)
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Profile Deleted")
                UsersHandler.LoginTableAdapter.Fill(UsersHandler.ScrapDBDataSet.Login)
            Catch ae As SqlException
                MessageBox.Show(ae.Message.ToString())
            End Try
        End If
        TextBox1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MsgBox("Don't keep blank Credentials for UserName")

        ElseIf TextBox2.Text = "" Then
            MsgBox("Don't keep blank Credentials for Password")
        Else
            sql = "insert into Login  (UserName, Password, About, Email, Phone, Occupation) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "')"
            cmd = New SqlClient.SqlCommand(sql, conn)

            Try
                cmd.ExecuteNonQuery()
                MsgBox("Profile Added")
                UsersHandler.LoginTableAdapter.Fill(UsersHandler.ScrapDBDataSet.Login)

            Catch ae As SqlException
                MessageBox.Show(ae.Message.ToString())
            End Try
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub
    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        Dim check As Boolean
        check = EmailAddressCheck(TextBox4.Text)
        If check = False Then
            MsgBox("Enter a Valid Email", MsgBoxStyle.Exclamation, "Warning")
            TextBox4.Focus()
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