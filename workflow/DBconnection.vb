Imports System
Imports System.Data
Imports System.Data.Odbc

Public Class DBConnection
    Dim cn As OdbcConnection
    
    Public Function Execute_reader(ByVal str As String) As OdbcDataReader
        Dim conn As String
        conn = "Dsn=test;uid=scott;pwd=tiger"
        cn = New OdbcConnection(conn)
        cn.Open()
        Dim cmd As OdbcCommand
        Dim reader As OdbcDataReader
        cmd = New OdbcCommand(str, cn)

        reader = cmd.ExecuteReader

        Return reader
    End Function

    Public Sub Execute_nonequery(ByVal str As String)
        Dim cmd As OdbcCommand
        Dim conn As String


        conn = "Dsn=test;uid=scott;pwd=tiger"
        cn = New OdbcConnection(conn)
        cn.Open()

        cmd = New OdbcCommand(str, cn)

        Dim i As Integer
        i = cmd.ExecuteNonQuery()
        cn.Close()
    End Sub
    Public Sub close()
        cn.Close()
    End Sub

End Class
