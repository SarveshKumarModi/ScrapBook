Public Class ChatPage
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        HomePage.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        MainPage.Show()
    End Sub

    Private Sub ChatPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ScrapDBDataSet.Chats' table. You can move, or remove it, as needed.
        Me.ChatsTableAdapter.Fill(Me.ScrapDBDataSet.Chats)

    End Sub
    Public Sub writelabeltolabel(ByVal txt As String)
        Label1.Text = txt
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ChatPost.writelabeltolabel(Label1.Text)
        ChatPost.Show()

    End Sub


End Class