Imports System
Imports System.Data
Imports System.Data.Odbc
Public Class solve
    Dim time As Date
    Dim dt As String
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub solve_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub solve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim con As New DBConnection
        Dim sqlstr As String
        Dim rd As OdbcDataReader
        Dim st As Integer = -1
        sqlstr = "select p_status from problem where prob_id = " & Label6.Text
        rd = con.Execute_reader(sqlstr)
        If (rd.Read() = True) Then
            st = rd(0)
        End If
        con.close()
        sqlstr = "Select customer.cname ,customer.ph_no,problem.prob_detail from customer,problem where customer.prob_id=problem.prob_id and customer.prob_id= " & Label6.Text
        rd = con.Execute_reader(sqlstr)
        Label1.Text = Label1.Text & "  " & Label6.Text
        If (rd.Read() = True) Then
            Label3.Text = Label3.Text & "  " & rd(0).ToString
            Label4.Text = Label4.Text & "  " & rd(1).ToString
        End If
        TextBox1.Text = rd(2).ToString
        time = Now
        dt = Format(time, "d-MMM-yyyy")
        If (st = 0) Then
            sqlstr = "Select cmnt from p_comment where commentby_id = " & Label7.Text & " and prob_id= " & Label6.Text
            rd = con.Execute_reader(sqlstr)
            If (rd.Read() = True) Then
                Label9.Visible = 1
                Label9.Text = "Comment given by me :"
                TextBox2.Text = rd(0)
                TextBox2.Enabled = 0
            Else
                TextBox2.Text = ""
                TextBox2.Enabled = 1
            End If
        Else
            Label9.Visible = 1
            Label9.Text = "Solution to the problem is :"
            TextBox2.Enabled = 0
            sqlstr = "Select p_solution from solved_prob where solvedby = " & Label7.Text
            rd = con.Execute_reader(sqlstr)
            If (rd.Read() = True) Then
                TextBox2.Text = rd(0)
            End If
        End If
        con.close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con As New DBConnection
        Dim sqlstr As String
        If (TextBox2.Text <> "") Then
            sqlstr = "Insert into solved_prob values(" & Label6.Text & ",'" & TextBox2.Text & "'," & Label7.Text & ",'" & dt & "')"
            con.Execute_nonequery(sqlstr)
            sqlstr = "update problem set p_status =1 where prob_id=" & Label6.Text
            con.Execute_nonequery(sqlstr)
            sqlstr = "update work_log set p_status =1 where prob_id=" & Label6.Text & " and e_id=" & Label7.Text
            con.Execute_nonequery(sqlstr)
            Me.Close()
        Else
            MsgBox("Please Give solution for this problem.", MsgBoxStyle.Critical, "Solution Not Given")
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim con As New DBConnection
        Dim sqlstr As String
        Dim sen As Integer
        Dim rd As OdbcDataReader
        If (TextBox2.Text <> "") Then
            sqlstr = "Insert into p_comment values('" & dt & "'," & Label6.Text & "," & Label7.Text & ",'" & TextBox2.Text & "'," & Label8.Text & ")"
            con.Execute_nonequery(sqlstr)
            sqlstr = "update work_log set p_status =1 where prob_id=" & Label6.Text & " and e_id= " & Label7.Text
            con.Execute_nonequery(sqlstr)
            sqlstr = "Select sr_id from employee where e_id = " & Label7.Text
            rd = con.Execute_reader(sqlstr)
            If (rd.Read() = True) Then
                sen = rd(0)
            End If
            con.close()
            sqlstr = "insert into work_log values(" & Label6.Text & "," & sen & ",'" & dt & "',0)"
            con.Execute_nonequery(sqlstr)
            sqlstr = "Update problem set pholder_id=" & sen & " where prob_id=" & Label6.Text
            con.Execute_nonequery(sqlstr)
            Me.Close()
        Else
            MsgBox("Please Give a Comment for this problem.", MsgBoxStyle.Critical, "Solution Not Given")
        End If
    End Sub
End Class