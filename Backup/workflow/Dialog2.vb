Imports System.Windows.Forms
Imports System
Imports System.Data
Imports System.Data.Odbc

Public Class Dialog2

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click


        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Dialog2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim con As New DBConnection
        Dim sqlstr, cus As String
        cus = "    Customer Name :  "
        Dim rd As OdbcDataReader
        sqlstr = "Select cname,ph_no from customer where prob_id=" & Label3.Text
        rd = con.Execute_reader(sqlstr)
        If (rd.Read()) Then
            cus = cus + rd(0).ToString + "      Phone :   " + rd(1).ToString
        End If
        Label2.Text = cus
        con.close()

        cus = ""
        sqlstr = "Select p_comment.cmnt,p_comment.c_date ,employee.e_name from p_comment,employee where p_comment.prob_id=" & Label3.Text & "  and p_comment.commentby_id = employee.e_id order by p_comment.c_date"
        rd = con.Execute_reader(sqlstr)
        While (rd.Read() = True)
            cus = Chr(13) + Chr(13) + "  Comment : " + rd(0).ToString + "   ;  by : " + rd(2).ToString + "  ; On : " + rd(1).ToString
        End While


        sqlstr = "Select p_solution,sol_date ,e_name from solved_prob,employee where solved_prob.prob_id=" & Label3.Text & "  and solved_prob.solvedby = employee.e_id order by solved_prob.sol_date"
        rd = con.Execute_reader(sqlstr)
        While (rd.Read() = True)
            cus = cus + Chr(13) + Chr(13) + Chr(13) + "  Solution :   " + rd(0).ToString + "   ;  by : " + rd(2).ToString + "  ; On : " + rd(1).ToString
        End While
        Label1.Text = cus
        con.close()
    End Sub
End Class
