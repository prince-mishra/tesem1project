
Imports System
Imports System.Data
Imports System.Data.Odbc
Public Class agent
    Dim time As Date
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        time = Now
        lbltime.Text = "India || " & time

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim con As New DBConnection
        Dim user As Integer
        Dim name As String
        user = Val(login.TextBox1.Text)
        Dim rd As OdbcDataReader
        Dim sqlstr As String = "Select e_name from employee where e_id=" & user
        rd = con.Execute_reader(sqlstr)
        If (rd.Read() = True) Then
            name = rd(0).ToString()
            Label2.Text = name
        End If
        con.close()
        sqlstr = "Select e_name,n_date,notice_st from notice,employee where notice.dept='General' and employee.e_id=notice.e_id"
        rd = con.Execute_reader(sqlstr)
        Dim ms As String = ""
        While (rd.Read())
            ms = ms + Chr(13)
            ms = ms + rd(1).ToString + "     " + rd(2).ToString + "   : by   " + rd(0).ToString

        End While
        Label7.Text = ms
        con.close()
    End Sub


    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim frm As New complaint
        frm.Show()

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        login.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Dim id As Integer
        id = InputBox("Enter Problem ID of problem whose status you want to view")
        Dim con As New DBConnection
        Dim sqlstr As String
        Dim rd As OdbcDataReader
        sqlstr = "Select cname from customer where prob_id=" & Str(id)
        rd = con.Execute_reader(sqlstr)
        If (rd.Read()) Then
            Dialog2.Label3.Text = Str(id)
            Dialog2.Show()
        Else
            MsgBox("No problem with this id exist")
        End If
    End Sub
End Class