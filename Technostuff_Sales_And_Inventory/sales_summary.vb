Public Class sales_summary
    Public Sub AutoSearch(ByRef xcb As ComboBox, ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal blnLimitToList As Boolean)

        Dim strFindStr As String = ""

        If e.KeyChar = ChrW(8) Then

            If (xcb.SelectionStart <= 1) Then

                xcb.Text = ""
                Exit Sub
            End If

            If (xcb.SelectionLength = 0) Then

                strFindStr = xcb.Text.Substring(0, xcb.Text.Length - 1)

            Else

                strFindStr = xcb.Text.Substring(0, xcb.SelectionStart - 1)
            End If

        Else

            If (xcb.SelectionLength = 0) Then

                strFindStr = xcb.Text + e.KeyChar

            Else

                strFindStr = xcb.Text.Substring(0, xcb.SelectionStart) + e.KeyChar
            End If

            Dim intIdx As Integer = -1
            ' Search the string in the ComboBox list.  

            intIdx = xcb.FindString(strFindStr)
            If (intIdx <> -1) Then

                xcb.SelectedText = ""
                xcb.SelectedIndex = intIdx
                xcb.SelectionStart = strFindStr.Length
                xcb.SelectionLength = xcb.Text.Length
                e.Handled = True

            Else

                e.Handled = blnLimitToList

            End If
        End If
    End Sub

    Private Sub btngenerate_Click(sender As Object, e As EventArgs) Handles btngenerate.Click
        Dim d As New DAO
        Dim ds As DataSet
        'all transaction between date 
        If combolname.Text = "" And combopmode.Text = "" Then
            ds = d.loaddata("select c_name,in_date,in_no,pay_mode,in_tot,gst_tot,r_off from sales_summary where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "'")
        ElseIf combolname.Text <> "" And combopmode.Text = "" Then
            'all ledger transaction between date
            ds = d.loaddata("select c_name,in_date,in_no,pay_mode,in_tot,gst_tot,r_off from sales_summary where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and c_name='" & combolname.Text & "'")
        ElseIf combolname.Text = "" And combopmode.Text <> "" Then
            'all payment trasaction between date
            ds = d.loaddata("select c_name,in_date,in_no,pay_mode,in_tot,gst_tot,r_off from sales_summary where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and pay_mode='" & combopmode.Text & "'")
        Else
            'all transaction with ledger and payment 
            ds = d.loaddata("select c_name,in_date,in_no,pay_mode,in_tot,gst_tot,r_off from sales_summary where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and c_name='" & combolname.Text & "' and pay_mode='" & combopmode.Text & "'")
        End If
        DataGridView1.DataSource = ds.Tables(0)

        dk = ds
        count_total()
    End Sub
    Private Sub count_total()
        Dim d As Integer = DataGridView1.Rows.Count - 1
        Dim gtot As Double = 0
        Dim tt As Double = 0
        While d >= 0
            gtot += Val(DataGridView1.Item("gst_tot", d).Value)
            tt += Val(DataGridView1.Item("in_tot", d).Value)
            d -= 1
        End While
        txtgsttotamt.Text = Math.Round(gtot, 2)
        txtgrandtot.Text = tt
    End Sub
    Private Sub load_c_details()

        Dim d As New DAO
        Dim ds As DataSet = d.loaddata("select distinct(c_name) from sales_summary")
        combolname.DisplayMember = "c_name"
        combolname.ValueMember = "c_name"
        combolname.DataSource = ds.Tables(0)


    End Sub

    Private Sub sales_summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_c_details()
        Dim d As New DAO
        d.enable_design(DataGridView1)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            inv_no = DataGridView1.Item("in_no", DataGridView1.CurrentCell.RowIndex).Value
            If inv_no <> "" Then
                Dim d As New Sales_master
                d.MdiParent = Me.MdiParent
                d.Show()
            End If
        End If
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        If DataGridView1.Rows.Count > 0 Then
            r_type = "sales_summary"
            Dim d As New view_s_rpt
            d.MdiParent = Me.MdiParent
            d.Show()
        End If
    End Sub

    Private Sub combolname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles combolname.KeyPress
        AutoSearch(combolname, e, True)

    End Sub

    Private Sub combopmode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles combopmode.KeyPress
        AutoSearch(combopmode, e, True)
    End Sub

    Private Sub combolname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combolname.SelectedIndexChanged

    End Sub
End Class