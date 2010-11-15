Imports System
Imports System.Data
Imports System.Data.Odbc
Public Class engg
    Dim user As Integer
    Dim pendcnt As Integer
    Dim facnt As Integer
    Dim time As Date
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        user = Val(login.TextBox1.Text)
        Dim con As New DBConnection
        Dim sqlstr As String
        Dim rd As OdbcDataReader
        sqlstr = "Select prob_id,subject from problem where p_status =0 and pholder_id=" & user & " order by p_date"
        rd = con.Execute_reader(sqlstr)
        Dim c As Integer
        While (rd.Read() And c < 5)
            Select Case c
                Case (0)
                    LinkLabel1.Text = rd(0).ToString
                    sub1.Text = rd(1).ToString
                Case (1)
                    LinkLabel2.Text = rd(0).ToString
                    sub2.Text = rd(1).ToString
                Case (2)
                    LinkLabel3.Text = rd(0).ToString
                    sub3.Text = rd(1).ToString
                Case (3)
                    LinkLabel4.Text = rd(0).ToString
                    sub4.Text = rd(1).ToString
                Case (4)
                    LinkLabel5.Text = rd(0).ToString
                    sub5.Text = rd(1).ToString
            End Select

            c = c + 1
        End While
        con.close()

        sqlstr = "Select work_log.prob_id,problem.subject from problem,work_log where work_log.p_status =1 and work_log.e_id=" & user & " and work_log.prob_id=problem.prob_id order by work_log.w_date"
        rd = con.Execute_reader(sqlstr)
        c = 0
        While (rd.Read() And c < 5)
            Select Case c
                Case (0)
                    LinkLabel9.Text = rd(0).ToString
                    Label1.Text = rd(1).ToString
                Case (1)
                    LinkLabel10.Text = rd(0).ToString
                    Label2.Text = rd(1).ToString
                Case (2)
                    LinkLabel11.Text = rd(0).ToString
                    Label3.Text = rd(1).ToString
                Case (3)
                    LinkLabel12.Text = rd(0).ToString
                    Label4.Text = rd(1).ToString
                Case (4)
                    LinkLabel13.Text = rd(0).ToString
                    Label5.Text = rd(1).ToString
            End Select

            c = c + 1
        End While
        con.close()
        Dim name As String
        Dim dep As String = ""
        sqlstr = "Select e_name,dept from employee where e_id=" & user
        rd = con.Execute_reader(sqlstr)
        If (rd.Read() = True) Then
            name = rd(0).ToString()
            dep = rd(1).ToString()
            Label9.Text = name
        End If
        con.close()
        Select Case (dep)
            Case ("Mobile")
                PictureBox3.Visible = 1
            Case ("Landline")
                PictureBox4.Visible = 1
            Case ("Broadband")
                PictureBox2.Visible = 1
            Case Else
                PictureBox1.Visible = 1
        End Select

        sqlstr = "Select e_name,n_date,notice_st from notice,employee where (notice.dept='General'  or notice.dept='" & dep & "'" & ") and employee.e_id=notice.e_id "
        rd = con.Execute_reader(sqlstr)
        Dim ms As String = ""
        While (rd.Read())
            ms = ms + Chr(13)
            ms = ms + rd(1).ToString + "     " + rd(2).ToString + "   : by   " + rd(0).ToString

        End While
        Label7.Text = ms
        con.close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        time = Now
        lbltime.Text = "India || " & time
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        LinkLabel9.Text = ""
        Label1.Text = ""
        LinkLabel10.Text = ""
        Label2.Text = ""
        LinkLabel11.Text = ""
        Label3.Text = ""
        LinkLabel12.Text = ""
        Label4.Text = ""
        LinkLabel13.Text = ""
        Label5.Text = ""
        LinkLabel1.Text = ""
        sub1.Text = ""
        LinkLabel2.Text = ""
        sub2.Text = ""
        LinkLabel3.Text = ""
        sub3.Text = ""
        LinkLabel4.Text = ""
        sub4.Text = ""
        LinkLabel5.Text = ""
        sub5.Text = ""
        pendcnt = 0
        facnt = 0
        Dim con As New DBConnection
        Dim sqlstr As String
        Dim rd As OdbcDataReader
        sqlstr = "Select prob_id,subject from problem where p_status =0 and pholder_id=" & user & " order by p_date"
        rd = con.Execute_reader(sqlstr)
        Dim c As Integer
        While (rd.Read() And c < 5)
            Select Case c
                Case (0)
                    LinkLabel1.Text = rd(0).ToString
                    sub1.Text = rd(1).ToString
                Case (1)
                    LinkLabel2.Text = rd(0).ToString
                    sub2.Text = rd(1).ToString
                Case (2)
                    LinkLabel3.Text = rd(0).ToString
                    sub3.Text = rd(1).ToString
                Case (3)
                    LinkLabel4.Text = rd(0).ToString
                    sub4.Text = rd(1).ToString
                Case (4)
                    LinkLabel5.Text = rd(0).ToString
                    sub5.Text = rd(1).ToString
            End Select

            c = c + 1
        End While
        con.close()

        sqlstr = "Select work_log.prob_id,problem.subject from problem,work_log where work_log.p_status =1 and work_log.e_id=" & user & " and work_log.prob_id=problem.prob_id order by work_log.w_date"
        rd = con.Execute_reader(sqlstr)
        c = 0
        While (rd.Read() And c < 5)
            Select Case c
                Case (0)
                    LinkLabel9.Text = rd(0).ToString
                    Label1.Text = rd(1).ToString
                Case (1)
                    LinkLabel10.Text = rd(0).ToString
                    Label2.Text = rd(1).ToString
                Case (2)
                    LinkLabel11.Text = rd(0).ToString
                    Label3.Text = rd(1).ToString
                Case (3)
                    LinkLabel12.Text = rd(0).ToString
                    Label4.Text = rd(1).ToString
                Case (4)
                    LinkLabel13.Text = rd(0).ToString
                    Label5.Text = rd(1).ToString
            End Select

            c = c + 1
        End While
        con.close()
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        LinkLabel1.Text = ""
        sub1.Text = ""
        LinkLabel2.Text = ""
        sub2.Text = ""
        LinkLabel3.Text = ""
        sub3.Text = ""
        LinkLabel4.Text = ""
        sub4.Text = ""
        LinkLabel5.Text = ""
        sub5.Text = ""
        Dim con As New DBConnection
        Dim sqlstr As String
        Dim rd As OdbcDataReader
        sqlstr = "Select prob_id,subject from problem where p_status =0 and pholder_id=" & user & " order by p_date"
        rd = con.Execute_reader(sqlstr)
        pendcnt = pendcnt + 1
        Dim c As Integer
        While (rd.Read() And c < (5 + pendcnt * 5))
            Select Case c
                Case (0 + pendcnt * 5)
                    LinkLabel1.Text = rd(0).ToString
                    sub1.Text = rd(1).ToString
                Case (1 + pendcnt * 5)
                    LinkLabel2.Text = rd(0).ToString
                    sub2.Text = rd(1).ToString
                Case (2 + pendcnt * 5)
                    LinkLabel3.Text = rd(0).ToString
                    sub3.Text = rd(1).ToString
                Case (3 + pendcnt * 5)
                    LinkLabel4.Text = rd(0).ToString
                    sub4.Text = rd(1).ToString
                Case (4 + pendcnt * 5)
                    LinkLabel5.Text = rd(0).ToString
                    sub5.Text = rd(1).ToString
            End Select

            c = c + 1
        End While
        con.close()
    End Sub

    Private Sub LinkLabel7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        pendcnt = pendcnt - 1
        LinkLabel1.Text = ""
        sub1.Text = ""
        LinkLabel2.Text = ""
        sub2.Text = ""
        LinkLabel3.Text = ""
        sub3.Text = ""
        LinkLabel4.Text = ""
        sub4.Text = ""
        LinkLabel5.Text = ""
        sub5.Text = ""
        Dim con As New DBConnection
        Dim sqlstr As String
        Dim rd As OdbcDataReader
        sqlstr = "Select prob_id,subject from problem where p_status =0 and pholder_id=" & user & " order by p_date"
        rd = con.Execute_reader(sqlstr)
        Dim c As Integer
        While (rd.Read() And c < (5 + pendcnt * 5))
            Select Case c
                Case (0 + pendcnt * 5)
                    LinkLabel1.Text = rd(0).ToString
                    sub1.Text = rd(1).ToString
                Case (1 + pendcnt * 5)
                    LinkLabel2.Text = rd(0).ToString
                    sub2.Text = rd(1).ToString
                Case (2 + pendcnt * 5)
                    LinkLabel3.Text = rd(0).ToString
                    sub3.Text = rd(1).ToString
                Case (3 + pendcnt * 5)
                    LinkLabel4.Text = rd(0).ToString
                    sub4.Text = rd(1).ToString
                Case (4 + pendcnt * 5)
                    LinkLabel5.Text = rd(0).ToString
                    sub5.Text = rd(1).ToString
            End Select

            c = c + 1
        End While
        con.close()
    End Sub

    Private Sub LinkLabel15_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        LinkLabel9.Text = ""
        Label1.Text = ""
        LinkLabel10.Text = ""
        Label2.Text = ""
        LinkLabel11.Text = ""
        Label3.Text = ""
        LinkLabel12.Text = ""
        Label4.Text = ""
        LinkLabel13.Text = ""
        Label5.Text = ""
        Dim con As New DBConnection
        Dim sqlstr As String
        Dim rd As OdbcDataReader
        sqlstr = "Select work_log.prob_id,problem.subject from problem,work_log where work_log.p_status =1 and work_log.e_id=" & user & " and work_log.prob_id=problem.prob_id order by work_log.w_date"
        rd = con.Execute_reader(sqlstr)
        facnt = facnt + 1
        Dim c As Integer
        While (rd.Read() And c < (5 + facnt * 5))
            Select Case c
                Case (0 + facnt * 5)
                    LinkLabel9.Text = rd(0).ToString
                    Label1.Text = rd(1).ToString
                Case (1 + facnt * 5)
                    LinkLabel10.Text = rd(0).ToString
                    Label2.Text = rd(1).ToString
                Case (2 + facnt * 5)
                    LinkLabel11.Text = rd(0).ToString
                    Label3.Text = rd(1).ToString
                Case (3 + facnt * 5)
                    LinkLabel12.Text = rd(0).ToString
                    Label4.Text = rd(1).ToString
                Case (4 + facnt * 5)
                    LinkLabel13.Text = rd(0).ToString
                    Label5.Text = rd(1).ToString
            End Select

            c = c + 1
        End While
        con.close()
    End Sub

    Private Sub LinkLabel14_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        LinkLabel9.Text = ""
        Label1.Text = ""
        LinkLabel10.Text = ""
        Label2.Text = ""
        LinkLabel11.Text = ""
        Label3.Text = ""
        LinkLabel12.Text = ""
        Label4.Text = ""
        LinkLabel13.Text = ""
        Label5.Text = ""
        Dim con As New DBConnection
        Dim sqlstr As String
        Dim rd As OdbcDataReader
        sqlstr = "Select work_log.prob_id,problem.subject from problem,work_log where work_log.p_status =1 and work_log.e_id=" & user & " and work_log.prob_id=problem.prob_id order by work_log.w_date"
        rd = con.Execute_reader(sqlstr)
        facnt = facnt - 1
        Dim c As Integer
        While (rd.Read() And c < (5 + facnt * 5))
            Select Case c
                Case (0 + facnt * 5)
                    LinkLabel9.Text = rd(0).ToString
                    Label1.Text = rd(1).ToString
                Case (1 + facnt * 5)
                    LinkLabel10.Text = rd(0).ToString
                    Label2.Text = rd(1).ToString
                Case (2 + facnt * 5)
                    LinkLabel11.Text = rd(0).ToString
                    Label3.Text = rd(1).ToString
                Case (3 + facnt * 5)
                    LinkLabel12.Text = rd(0).ToString
                    Label4.Text = rd(1).ToString
                Case (4 + facnt * 5)
                    LinkLabel13.Text = rd(0).ToString
                    Label5.Text = rd(1).ToString
            End Select

            c = c + 1
        End While
        con.close()
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim frm As New solve
        Me.AddOwnedForm(frm)
        frm.Label6.Text = LinkLabel1.Text
        frm.Label7.Text = Str(user)
        frm.Label8.Text = 2
        frm.Show()
    End Sub
    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim frm As New solve
        Me.AddOwnedForm(frm)
        frm.Label6.Text = LinkLabel2.Text
        frm.Label7.Text = Str(user)
        frm.Label8.Text = 2
       
        frm.Show()
    End Sub
    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim frm As New solve
        Me.AddOwnedForm(frm)
        frm.Label6.Text = LinkLabel3.Text
        frm.Label7.Text = Str(user)
        frm.Label8.Text = 2
        frm.Show()
    End Sub
    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim frm As New solve
        Me.AddOwnedForm(frm)
        frm.Label6.Text = LinkLabel4.Text
        frm.Label7.Text = Str(user)
        frm.Label8.Text = 2
        frm.Show()
    End Sub
    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim frm As New solve
        Me.AddOwnedForm(frm)
        frm.Label6.Text = LinkLabel5.Text
        frm.Label7.Text = Str(user)
        frm.Label8.Text = 2
        frm.Show()
    End Sub
    Private Sub LinkLabel9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Dim frm As New solve
        Me.AddOwnedForm(frm)
        frm.Label6.Text = LinkLabel9.Text
        frm.Label7.Text = Str(user)
        frm.Label8.Text = 2
        frm.Button1.Visible = 0
        frm.Button2.Visible = 0
        frm.Button3.Visible = 0
        frm.Show()
    End Sub
    Private Sub LinkLabel10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Dim frm As New solve
        Me.AddOwnedForm(frm)
        frm.Label6.Text = LinkLabel10.Text
        frm.Label7.Text = Str(user)
        frm.Label8.Text = 2
        frm.Button1.Visible = 0
        frm.Button2.Visible = 0
        frm.Button3.Visible = 0
        frm.Show()
    End Sub
    Private Sub LinkLabel11_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Dim frm As New solve
        Me.AddOwnedForm(frm)
        frm.Label6.Text = LinkLabel11.Text
        frm.Label7.Text = Str(user)
        frm.Label8.Text = 2
        frm.Button1.Visible = 0
        frm.Button2.Visible = 0
        frm.Button3.Visible = 0
        frm.Show()
    End Sub
    Private Sub LinkLabel12_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        Dim frm As New solve
        Me.AddOwnedForm(frm)
        frm.Label6.Text = LinkLabel12.Text
        frm.Label7.Text = Str(user)
        frm.Label8.Text = 2
        frm.Button1.Visible = 0
        frm.Button2.Visible = 0
        frm.Button3.Visible = 0
        frm.Show()
    End Sub
    Private Sub LinkLabel13_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
        Dim frm As New solve
        Me.AddOwnedForm(frm)
        frm.Label6.Text = LinkLabel13.Text
        frm.Label7.Text = Str(user)
        frm.Label8.Text = 2
        frm.Button1.Visible = 0
        frm.Button2.Visible = 0
        frm.Button3.Visible = 0
        frm.Show()
    End Sub

    Private Sub LinkLabel8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        login.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click

    End Sub
End Class