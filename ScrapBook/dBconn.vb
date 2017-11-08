

Imports System.Data.SqlClient

Module dBconn
    Friend connectionstring As String = Nothing

    Public reader As SqlDataReader = Nothing
    Public conn As SqlConnection = Nothing
    Public cmd As SqlCommand = Nothing
    Public sql As String = Nothing

    Public Sub executesqlstmt(ByVal sql As String)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        connectionstring = “Integrated Security=true;” + ” Initial Catalog = ScrapDB ;” + “ Data source=(localdb)\ProjectsV13;”
        conn.ConnectionString = connectionstring
        conn.Open()
    End Sub

End Module

