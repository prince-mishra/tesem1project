Imports System
Imports System.Data
Imports System.Data.Odbc

Public Class login
    Dim time As Date

    Private Sub login_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox1.Enabled = 1
        TextBox2.Enabled = 1
        TextBox1.Focus()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        time = Now
        lbltime.Text = "India || " & time
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        TextBox1.Enabled = 0
        TextBox2.Enabled = 0
        Dim con As New DBConnection
        Dim reader As OdbcDataReader
        Dim user As Integer
        Dim psw, sqlstr As String
        user = Val(TextBox1.Text)
        psw = TextBox2.Text
        sqlstr = "Select password , lvl from employee where e_id=" & TextBox1.Text
        reader = con.Execute_reader(sqlstr)
        Dim pw As String

        If (reader.Read = True) Then
            pw = reader(0).ToString()
            If (psw = pw) Then
                Dim lv As Integer
                lv = reader(1)
                con.close()
                Select Case (lv)
                    Case (1)
                        Dim frm As New agent
                        frm.Show()
                        Me.Hide()
                    Case (2)
                        Dim frm As New engg
                        frm.show()
                        Me.Hide()
                    Case (3)
                        Dim frm As New chief
                        frm.Show()
                        Me.Hide()
                    Case (4)
                        Dim frm As New mngr
                        frm.Show()
                        Me.Hide()
                    Case (5)
                        Dim frm As New gen
                        frm.Show()
                        Me.Hide()
                End Select
            Else
                con.close()
                If (MsgBox("Password is Invalid.", MsgBoxStyle.Information, "Access Denied") = MsgBoxResult.Ok) Then
                    TextBox1.Enabled = 1
                    TextBox2.Enabled = 1
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox1.Focus()
                End If
            End If
        Else
            con.close()
            If (MsgBox("User Name is Invalid.", MsgBoxStyle.Information, "Access Denied") = MsgBoxResult.Ok) Then
                TextBox1.Enabled = 1
                TextBox2.Enabled = 1
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()
            End If

        End If

    End Sub
End Class
