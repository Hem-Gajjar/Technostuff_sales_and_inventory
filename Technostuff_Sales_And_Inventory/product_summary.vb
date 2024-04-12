Public Class product_summary
    Private Sub product_summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_product()
        Dim d As New DAO
        d.enable_design(DataGridView1)
    End Sub
    Private Sub load_product()
        Try
            Dim d As New DAO
            Dim ds As New Data.DataSet

            ds = d.loaddata("select distinct(p_cat) from sales_detail")
            combopcat.DisplayMember = "p_cat"
            combopcat.ValueMember = "p_id"
            combopcat.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub combopcat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combopcat.SelectedIndexChanged
        Try
            If combopcat.Text <> "" Then
                combopcom.Text = ""
                Dim ds As New Data.DataSet
                Dim d As New DAO

                ds = d.loaddata("select distinct(p_com) from sales_detail where p_cat='" & combopcat.Text & "'")
                combopcom.DisplayMember = "p_com"
                combopcom.ValueMember = "p_id"
                combopcom.DataSource = ds.Tables(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub combopcom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combopcom.SelectedIndexChanged
        Try
            If combopcom.Text <> "" Then
                comboptype.Text = ""
                Dim ds As New Data.DataSet
                Dim d As New DAO
                ds = d.loaddata("select distinct(p_type) from sales_detail where p_com='" & combopcom.Text & "'")
                comboptype.DisplayMember = "p_type"
                comboptype.ValueMember = "p_id"
                comboptype.DataSource = ds.Tables(0)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btngenerate_Click(sender As Object, e As EventArgs) Handles btngenerate.Click
        Dim d As New DAO
        Dim ds As New DataSet
        'all transaction between date
        If combopcat.Text = "" And combopcom.Text = "" And comboptype.Text = "" Then
            ds = d.loaddata("select p_cat,p_com,p_type,p_qty,p_rate,p_gst_amt,p_tot,in_date from sales_detail where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "'")
            'all transaction using cat between date
        ElseIf combopcat.Text <> "" And combopcom.Text = "" And comboptype.Text = "" Then
            ds = d.loaddata("select p_cat,p_com,p_type,p_qty,p_rate,p_gst_amt,p_tot,in_date from sales_detail  where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and p_cat = '" & combopcat.Text & "'")
            'all transaction usin com between date
        ElseIf combopcat.Text = "" And combopcom.Text <> "" And comboptype.Text = "" Then
            ds = d.loaddata("select p_cat,p_com,p_type,p_qty,p_rate,p_gst_amt,p_tot,in_date from sales_detail  where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and p_com = '" & combopcom.Text & "'")
            'all transaction usin type between date
        ElseIf combopcat.Text = "" And combopcom.Text = "" And comboptype.Text <> "" Then
            ds = d.loaddata("select p_cat,p_com,p_type,p_qty,p_rate,p_gst_amt,p_tot,in_date from sales_detail where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and p_type = '" & comboptype.Text & "'")
            ' all transaction using cat and com
        ElseIf combopcat.Text <> "" And combopcom.Text <> "" And comboptype.Text = "" Then
            ds = d.loaddata("select p_cat,p_com,p_type,p_qty,p_rate,p_gst_amt,p_tot,in_date from sales_detail  where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and p_cat = '" & combopcat.Text & "' and p_com='" & combopcom.Text & "'")
            'all transaction using cat and type
        ElseIf combopcat.Text <> "" And combopcom.Text = "" And comboptype.Text <> "" Then

            ds = d.loaddata("select p_cat,p_com,p_type,p_qty,p_rate,p_gst_amt,p_tot,in_date from sales_detail  where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and p_cat = '" & combopcat.Text & "' and p_type='" & comboptype.Text & "'")
            'all transaction using com and type
        ElseIf combopcat.Text = "" And combopcom.Text <> "" And comboptype.Text <> "" Then

            ds = d.loaddata("select p_cat,p_com,p_type,p_qty,p_rate,p_gst_amt,p_tot,in_date from sales_detail  where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and p_com = '" & combopcom.Text & "' and p_type='" & comboptype.Text & "'")
            'all are selected
        ElseIf combopcat.Text <> "" And combopcom.Text <> "" And comboptype.Text <> "" Then

            ds = d.loaddata("select p_cat,p_com,p_type,p_qty,p_rate,p_gst_amt,p_tot,in_date from sales_detail  where in_date between '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "' and '" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "' and p_cat='" & combopcat.Text & "' and p_com = '" & combopcom.Text & "' and p_type='" & comboptype.Text & "'")
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
            gtot += Val(DataGridView1.Item("p_gst_amt", d).Value)
            tt += Val(DataGridView1.Item("p_tot", d).Value)
            d -= 1
        End While
        txtgsttotamt.Text = Math.Round(gtot, 2)
        txtgrandtot.Text = tt
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        If DataGridView1.Rows.Count > 0 Then
            r_type = "product_summary"
            Dim d As New view_s_rpt
            d.MdiParent = Me.MdiParent
            d.Show()
        End If
    End Sub

    Private Sub combopcat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles combopcat.KeyPress
        AutoSearch(combopcat, e, True)
    End Sub

    Private Sub combopcom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles combopcom.KeyPress
        AutoSearch(combopcom, e, True)
    End Sub

    Private Sub comboptype_KeyPress(sender As Object, e As KeyPressEventArgs) Handles comboptype.KeyPress
        AutoSearch(comboptype, e, True)
    End Sub
End Class