Imports System
Imports System.Data
Imports System.Data.Odbc
Public Class complaint

    Private Sub complaint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim newid As Integer
        If (ComboBox1.SelectedIndex > 4 Or ComboBox1.SelectedIndex < 0 Or TextBox6.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "") Then
            MsgBox("Please fill all Mandatory fields.", MsgBoxStyle.Critical)
        Else
            Dim con As New DBConnection
            Dim sqlstr As String

            Dim rd As OdbcDataReader
            sqlstr = "Select max(prob_id) from problem"
            rd = con.Execute_reader(sqlstr)
            If (rd.Read() = True) Then
                newid = rd(0) + 1
            End If
            con.close()
            Dim ph, emid, add, name As String
            ph = TextBox5.Text
            emid = TextBox4.Text
            add = TextBox3.Text
            name = TextBox2.Text

            sqlstr = "insert into customer values(" & newid & ",'" & name & "','" & add & "','" & emid & "','" & ph & "')"
            con.Execute_nonequery(sqlstr)
            MsgBox("Problem Submitted. Your Problem ID is  '" & Str(newid) & "'. Please note it for Future References.", MsgBoxStyle.ApplicationModal)
        End If
        Dim con1 As New DBConnection
        Dim sqlstr1 As String
        Dim rd1 As OdbcDataReader
        Dim rd2 As OdbcDataReader
        Dim pholder, tmpholder, min, tmpmin As Integer
        min = 999999999
        sqlstr1 = "Select e_id from employee where lvl=2 and dept= '" & ComboBox1.Text & "'"
        rd1 = con1.Execute_reader(sqlstr1)
        While (rd1.Read())
            tmpmin = 0
            tmpholder = rd1(0)
            sqlstr1 = "select count(*) from work_log where e_id=" & tmpholder
            rd2 = con1.Execute_reader(sqlstr1)
            If (rd2.Read() = True) Then
                tmpmin = rd2(0)
            End If
            If (tmpmin <= min) Then
                pholder = tmpholder
                min = rd2(0)
            End If
        End While
        con1.close()
        Dim time As Date
        time = Now
        Dim dt, pr, sb As String
        dt = Format(time, "d-MMM-yyyy")
        sqlstr1 = "Insert into work_log values(" & newid & "," & pholder & ",'" & dt & "'," & 0 & ")"
        con1.Execute_nonequery(sqlstr1)
        pr = TextBox1.Text
        sb = TextBox6.Text

        sqlstr1 = "Insert into problem values(" & newid & ",'" & sb & "','" & pr & "','" & dt & "'," & pholder & "," & 0 & ")"
        con1.Execute_nonequery(sqlstr1)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""
        Me.TextBox3.Text = ""
        Me.TextBox4.Text = ""
        Me.TextBox5.Text = ""
        Me.TextBox6.Text = ""
        Me.ComboBox1.Text = "                    --------------Select-----------                      "



    End Sub

    
End Class