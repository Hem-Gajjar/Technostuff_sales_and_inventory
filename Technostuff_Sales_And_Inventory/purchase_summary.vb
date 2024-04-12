Public Class purchase_summary
    Private Sub btngenerate_Click(sender As Object, e As EventArgs) Handles btngenerate.Click
        Dim d As New DAO
        Dim ds As DataSet
        'all transaction between date 
        If combosname.Text = "" And combopmode.Text = "" Then
            ds = d.loaddata("select s_name,in_date,in_no,pay_mode,in_tot,gst_tot,r_off from purchase_summary where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "'")
        ElseIf combosname.Text <> "" And combopmode.Text = "" Then
            'all ledger transaction between date
            ds = d.loaddata("select s_name,in_date,in_no,pay_mode,in_tot,gst_tot,r_off from purchase_summary where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and s_name='" & combosname.Text & "'")
        ElseIf combosname.Text = "" And combopmode.Text <> "" Then
            'all payment trasaction between date
            ds = d.loaddata("select s_name,in_date,in_no,pay_mode,in_tot,gst_tot,r_off from purchase_summary where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and pay_mode='" & combopmode.Text & "'")
        Else
            'all transaction with ledger and payment 
            ds = d.loaddata("select s_name,in_date,in_no,pay_mode,in_tot,gst_tot,r_off from purchase_summary where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and s_name='" & combosname.Text & "' and '" & combopmode.Text & "'")
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
    Private Sub load_s_details()
        Dim d As New DAO
        Dim ds As DataSet = d.loaddata("select distinct(s_name) from purchase_summary")
        combosname.DisplayMember = "s_name"
        combosname.ValueMember = "s_name"
        combosname.DataSource = ds.Tables(0)

    End Sub

    Private Sub purchase_summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_s_details()
        Dim d As New DAO
        d.enable_design(DataGridView1)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            inv_no = DataGridView1.Item("in_no", DataGridView1.CurrentCell.RowIndex).Value
            If inv_no <> "" Then
                Dim d As New Purchase_master
                d.MdiParent = Me.MdiParent
                d.Show()
            End If
        End If
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        If DataGridView1.Rows.Count > 0 Then
            r_type = "purchase_summary"
            Dim d As New view_s_rpt
            d.MdiParent = Me.MdiParent
            d.Show()
        End If
    End Sub

    Private Sub combosname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles combosname.KeyPress
        AutoSearch(combosname, e, True)
    End Sub

    Private Sub combopmode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles combopmode.KeyPress
        AutoSearch(combopmode, e, True)
    End Sub
End Class