Imports System
Imports System.Data
Imports System.Data.Odbc
Public Class gen
    Dim time As Date
    Dim user As Integer
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim id As Integer
        id = InputBox("Enter Employee id  ")


        Dim con As New DBConnection
        Dim sqlstr As String
        Dim rd As OdbcDataReader
        sqlstr = "Select * from employee where e_id = " & Str(id)
        rd = con.Execute_reader(sqlstr)
        If (rd.Read() = True) Then
            Dim frm As New newemp
            frm.Show()
            frm.OK_Button.Visible = 0
            frm.Cancel_Button.Visible = 0
            frm.TextBox1.Text = rd(0).ToString
            frm.TextBox2.Text = rd(1).ToString
            frm.ComboBox2.Text = rd(2).ToString
            frm.ComboBox1.Text = rd(3).ToString
            frm.TextBox6.Text = rd(5).ToString
            frm.TextBox5.Text = rd(6).ToString
            frm.TextBox4.Text = rd(7).ToString
            frm.TextBox8.Text = rd(9).ToString
            frm.TextBox7.Text = rd(8).ToString
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim id As Integer
        id = InputBox("Enter Employee ID of Employee to be Fired")
        If (MsgBox("Are You Sure, You want to fire Employee   '" + Str(id) + ".  ", MsgBoxStyle.Question) = MsgBoxResult.Yes) Then
            Dim sqlstr As String
            Dim con As New DBConnection
            sqlstr = "Delete Employee where e_id=" & id
            con.Execute_nonequery(sqlstr)
            MsgBox("Record Deleted.")
        End If
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        newemp.Show()
    End Sub
    Private Sub gen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        user = Val(login.TextBox1.Text)
        Dim name, sqlstr As String
        Dim con As New DBConnection
        Dim rd As OdbcDataReader
        sqlstr = "Select e_name,dept from employee where e_id=" & user
        rd = con.Execute_reader(sqlstr)
        If (rd.Read() = True) Then
            name = rd(0).ToString()
            Label9.Text = name
        End If
        con.close()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        ComboBox1.Visible = 1

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dep As String
        time = Now
        If (RadioButton1.Checked() = True) Then
            dep = "General"
        Else
            dep = ComboBox1.Text
        End If
        Dim dt As String
        dt = Format(time, "d-MMM-yyyy")
        If (TextBox1.Text = "") Then
            MsgBox("Please Enter text on Notice Board.", MsgBoxStyle.Exclamation, "Empty Notice Board")
        Else
            Dim con As New DBConnection
            Dim sqlstr As String
            Dim rd As OdbcDataReader
            Dim ms As String
            ms = TextBox1.Text
            sqlstr = "Insert into notice values (" & user & ",'" & dep & "','" & dt & "','" & ms & "')"
            rd = con.Execute_reader(sqlstr)
            MsgBox("Notice Send Successfully to all concerned.", MsgBoxStyle.Information)
        End If
        TextBox1.Clear()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        time = Now
        lbltime.Text = "India || " & time
    End Sub

    Private Sub LinkLabel8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        login.Show()
        Me.Close()
    End Sub
End Class