﻿
Imports System.Data.SqlClient
Public Class Sales_master
    Private Sub Sales_master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  load_invoice()
        Try

            load_customer()
            If inv_no <> "" Then
                txtinvno.Text = inv_no
                inv_no = ""
                load_invoice_data()
            Else
                load_invoice()
            End If

            Dim d As New DAO
            d.enable_design(DataGridView1)
            load_product()
            txtword.Text = NumberToText(Val(txtgrandtot.Text))


            combocname.Focus()
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    Private Sub txtinvno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttotamt.KeyPress, txtpsunit.KeyPress, txtpsrate.KeyPress, txtpsgst.KeyPress, txtphsn.KeyPress, txtpcgst.KeyPress, txtinvno.KeyPress, txtcid.KeyPress, txtcgst.KeyPress, txtccontact.KeyPress, dtp1.KeyPress, btnsave.KeyPress, btnnew.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            txtinvno.Focus()
            If sender.name = txtinvno.Name Then
                dtp1.Focus()
            ElseIf sender.name = dtp1.Name Then
                txtcid.Focus()
            ElseIf sender.name = txtcid.Name Then
                combocname.Focus()
            ElseIf sender.name = combocname.Name Then
                txtccontact.Focus()
            ElseIf sender.name = txtccontact.Name Then
                txtcgst.Focus()
            ElseIf sender.name = txtcgst.Name Then
                txtpid.Focus()
            ElseIf sender.name = txtpid.Name Then
                combocategory.Focus()
            ElseIf sender.name = combocategory.Name Then
                combocompany.Focus()
            ElseIf sender.name = combocompany.Name Then
                combotype.Focus()
            ElseIf sender.name = combotype.Name Then
                txtphsn.Focus()
            ElseIf sender.name = txtphsn.Name Then
                txtpsrate.Focus()
            ElseIf sender.name = txtpsrate.Name Then
                txtpsunit.Focus()
            ElseIf sender.name = txtpsunit.Name Then
                txtpcgst.Focus()
            ElseIf sender.name = txtpcgst.Name Then
                txtpsgst.Focus()
            ElseIf sender.name = txtpsgst.Name Then
                txttotamt.Focus()
            ElseIf sender.name = txttotamt.Name Then
                btnsave.Focus()
            ElseIf sender.name = btnsave.Name Then
                btnnew.Focus()
            End If
        End If
    End Sub
    Dim count As Integer
    Private Sub load_category()
        Try
            Dim d As New DAO
            Dim ds As New Data.DataSet
            ds = d.loaddata("select distinct(ct_name),ct_id from category_master")
            combocategory.DisplayMember = "ct_name"
            combocategory.ValueMember = "ct_id"
            combocategory.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub


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
    Private Sub load_invoice()
        Try
            Dim d As New DAO
            Dim ds As New Data.DataSet
            ds = d.loaddata("select * from configuration_master")
            If ds.Tables(0).Rows.Count > 0 Then
                txtinvno.Text = "TC-" & set_zero(ds.Tables(0).Rows(0).Item(0))
            End If
            load_invoice_data()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Function set_zero(v As String) As String
        Dim d As Integer = v.Length
        Dim s As String = ""
        For i = d To 3
            s &= "0"
        Next
        s &= v
        Return s
    End Function
    Private Sub load_customer()
        Try
            Dim d As New DAO
            Dim ds As New Data.DataSet
            ds = d.loaddata("select distinct(c_name) from customer_master")
            combocname.DisplayMember = "c_name"
            combocname.ValueMember = "c_name"
            combocname.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub combocname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combocname.SelectedIndexChanged
        Try

            If combocname.Text <> "" Then
                Dim ds As New Data.DataSet
                Dim d As New DAO
                ds = d.loaddata("select c_id,c_contact,c_gst,c_address from customer_master where c_name =  '" & combocname.Text & "'")

                If ds.Tables(0).Rows.Count > 0 Then
                    txtcid.Text = ds.Tables(0).Rows(0).Item("c_id")
                    txtccontact.Text = ds.Tables(0).Rows(0).Item("c_contact")
                    txtcgst.Text = ds.Tables(0).Rows(0).Item("c_gst")
                    txtcadd.Text = ds.Tables(0).Rows(0).Item("c_address")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    Private Sub load_product()
        Try
            Dim d As New DAO
            Dim ds As New Data.DataSet

            ds = d.loaddata("select distinct(p_category) from product_master")
            combocategory.DisplayMember = "p_category"
            combocategory.ValueMember = "p_id"
            combocategory.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub combocategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combocategory.SelectedIndexChanged
        Try
            If combocategory.Text <> "" Then
                combocompany.Text = ""
                Dim ds As New Data.DataSet
                Dim d As New DAO

                ds = d.loaddata("select p_company from product_master where p_category='" & combocategory.Text & "'")
                combocompany.DisplayMember = "p_company"
                combocompany.ValueMember = "p_id"
                combocompany.DataSource = ds.Tables(0)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub combocompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combocompany.SelectedIndexChanged
        Try
            If combocompany.Text <> "" Then
                combotype.Text = ""
                Dim ds As New Data.DataSet
                Dim d As New DAO
                ds = d.loaddata("select p_type from product_master where p_company='" & combocompany.Text & "'")
                combotype.DisplayMember = "p_type"
                combotype.ValueMember = "p_id"
                combotype.DataSource = ds.Tables(0)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub combotype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combotype.SelectedIndexChanged

        load_product_data()
    End Sub
    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        'all_clear()
        Try
            load_invoice()
            Dim d As New DAO
            Dim flag As Integer = d.validate("select id from sales_summary where in_no='" & txtinvno.Text & "'")
            If flag = 1 Then
                'invoice is already created update invoice no and get new invoice no
                Dim invno As Integer = 0
                Dim obj As SqlClient.SqlDataReader
                obj = d.getdata("select inv_num from configuration_master")
                While obj.Read
                    invno = obj.Item(0)
                End While
                d.closeconnection()

                invno += 1
                d.ModifyData("update configuration_master set inv_num=" & invno)
                load_invoice()
            Else
                'invoice is not created 
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub all_clear()
        combocname.Text = ""
        txtcid.Text = ""
        txtccontact.Text = ""
        txtcgst.Text = ""
        txtcadd.Text = ""
        txtpid.Text = ""
        combocategory.Text = " "
        combocompany.Text = ""
        combotype.Text = ""
        txtstockqty.ResetText()
        txtvno.ResetText()
        txtphsn.Text = ""
        txtqty.ResetText()
        txtpsrate.ResetText()
        combopay.Text = ""
        txtpcgst.ResetText()
        txtpsgst.ResetText()
        txtgsttotper.ResetText()
        txtamtgst.ResetText()
        txttotamt.ResetText()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try

            If combocname.Text <> "" Then
                If txtccontact.Text <> "" Then
                    If combocategory.Text <> "" Then
                        If combocompany.Text <> "" Then
                            If combotype.Text <> "" Then
                                If txtphsn.Text <> "" Then
                                    If txtpsrate.Text <> "0" Then
                                        If txtpsunit.Text <> "" Then
                                            If txtpcgst.Text <> "0" Then
                                                If txtpsgst.Text <> "0" Then
                                                    If combopay.Text <> "" Then
                                                        If Val(txtstockqty.Text) >= Val(txtqty.Text) Then
                                                            If txtqty.Text <> "0" Then
                                                                If txtnarr.Text <> "" Then

                                                                    Dim d As New DAO


                                                                    'PRODUCT ENTRY 

                                                                    d.ModifyData("insert into sales_detail (in_no,p_cat,p_com,p_type,p_qty,p_unit,p_rate,p_cgst,p_sgst,p_hsn,p_tot,p_gst_amt,p_id,in_date) values ('" & txtinvno.Text & "','" & combocategory.Text & "','" & combocompany.Text & "','" & combotype.Text & "'," & txtqty.Text & ",'" & txtpsunit.Text & "'," & txtpsrate.Text & "," & txtpcgst.Text & "," & txtpsgst.Text & "," & txtphsn.Text & "," & txttotamt.Text & "," & txtamtgst.Text & "," & txtpid.Text & ",'" & dtp1.Value.ToString("yyyy-MM-dd") & "')")



                                                                    'LOAD DATA & CALCULATE TOTALS 
                                                                    load_invoice_data()

                                                                    'update inventory
                                                                    update_inventory(0)

                                                                    'update creditor accounts
                                                                    update_creditor_account(0)

                                                                    'ONE ENTRY IN SALES SUMMARY
                                                                    If DataGridView1.Rows.Count = 1 Then
                                                                        d.ModifyData("insert into sales_summary (c_name,c_contact,in_date,in_no,pay_mode,in_tot,gst_tot,lab_char,r_off,l_slip,in_narr) values ('" & combocname.Text & "'," & txtccontact.Text & ",'" & dtp1.Value.ToString("yyyy-MM-dd") & "','" & txtinvno.Text & "','" & combopay.Text & "'," & ttaxamt.Text & "," & txtgsttotamt.Text & "," & txtlabour.Text & "," & txtround.Text & "," & txtvno.Text & ",'" & txtnarr.Text & "')")
                                                                        MessageBox.Show("Product added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                                    Else
                                                                        'UPDATE TOTALS
                                                                        d.ModifyData("update sales_summary set in_tot=" & ttaxamt.Text & ",gst_tot=" & txtgsttotamt.Text & ",r_off=" & txtround.Text & ",lab_char=" & txtlabour.Text & ",l_slip=" & txtvno.Text & " where in_no='" & txtinvno.Text & "'")
                                                                    End If


                                                                Else
                                                                    MessageBox.Show("Enter Valid Sale Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                                                    txtnarr.Focus()
                                                                End If
                                                            Else
                                                                MessageBox.Show("Enter Valid Sale Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                                                txtqty.Focus()

                                                            End If

                                                        Else
                                                            MessageBox.Show("Enter Valid Sale Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                                            txtqty.Focus()
                                                        End If
                                                    Else
                                                        MessageBox.Show("Enter Valid Mode Of Payment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                                        combopay.Focus()
                                                    End If
                                                Else
                                                    MessageBox.Show("Enter Valid SGST(%)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                                    txtpsgst.Focus()

                                                End If
                                            Else
                                                MessageBox.Show("Enter Valid CGST(%)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                                txtpcgst.Focus()


                                            End If
                                        Else
                                            MessageBox.Show("Enter Valid Sales Unit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                            txtpsunit.Focus()

                                        End If
                                    Else
                                        MessageBox.Show("Enter Valid Sales Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                        txtpsrate.Focus()

                                    End If
                                Else
                                    MessageBox.Show("Enter Valid HSN Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                    txtphsn.Focus()

                                End If
                            Else
                                MessageBox.Show("Enter Valid Product Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                combotype.Focus()
                            End If
                        Else
                            MessageBox.Show("Enter Valid Product Company", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            combocompany.Focus()


                        End If
                    Else
                        MessageBox.Show("Enter Valid Product Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        combocategory.Focus()

                    End If

                Else
                    MessageBox.Show("Enter Valid Contact Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    txtccontact.Focus()
                End If
            Else
                MessageBox.Show("Enter Valid Customer Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                combocname.Focus()
            End If

            txtword.Text = NumberToText(Val(txtgrandtot.Text))
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub update_creditor_account(ByVal v As Integer)
        Try

            If combopay.Text = "Credit" Then
                If DataGridView1.Rows.Count() = 1 And v = 0 Then
                    'insert

                    '1) load voucher number
                    Dim v_no As Integer = 0
                    Dim d As New DAO
                    Dim obj As SqlClient.SqlDataReader
                    obj = d.getdata(" select v_no from configuration_master ")
                    While obj.Read
                        v_no = obj.Item(0)
                    End While
                    d.closeconnection()
                    txtvno.Text = v_no
                    '2)insert voucher to account_master
                    d.ModifyData("insert into account_master (l_name,l_id,l_amt,l_type,l_desc,l_slip) values ('" & combocname.Text & "'," & txtcid.Text & "," & txtgrandtot.Text & ",'Dr','Sales Invoice # " & txtinvno.Text & "'," & v_no & " )")


                    '3)update voucher number
                    d.ModifyData("update configuration_master set v_no=" & (v_no + 1))

                ElseIf DataGridView1.Rows.Count = 0 Then
                    ' no record in invoice
                    Dim d As New DAO
                    d.ModifyData("delete from account_master where l_slip=" & txtvno.Text)
                Else
                    'update
                    Dim d As New DAO
                    d.ModifyData("update account_master set l_amt=" & txtgrandtot.Text & " where l_slip=" & txtvno.Text)

                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub update_inventory(v As Integer)
        Try

            If v = 0 Then
                'inventory minus
                Dim new_qty As Double = Val(txtstockqty.Text) - Val(txtqty.Text)
                Dim d As New DAO
                d.ModifyData("update product_master set p_stock=" & new_qty & " where p_id=" & txtpid.Text)
            Else
                'inventory plus
                Dim new_qty As Double = Val(txtstockqty.Text) + Val(txtqty.Text)
                Dim d As New DAO
                d.ModifyData("update product_master set p_stock=" & new_qty & " where p_id=" & txtpid.Text)
            End If

            txtstockqty.Text = ""
            txtpid.Text = ""

            load_product_data()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub load_invoice_data()
        Try
            Dim d As New DAO
            Dim dd As New Data.DataSet
            dd = d.loaddata("SELECT * FROM sales_summary WHERE in_no='" & txtinvno.Text & "'")
            If dd.Tables(0).Rows.Count > 0 Then
                combocname.Text = dd.Tables(0).Rows(0).Item("c_name")
                dtp1.Value = dd.Tables(0).Rows(0).Item("in_date")
                combopay.Text = dd.Tables(0).Rows(0).Item("pay_mode")
                txtround.Text = dd.Tables(0).Rows(0).Item("r_off")
                txtvno.Text = dd.Tables(0).Rows(0).Item("l_slip")
            End If


            Dim ds As New Data.DataSet
            ds = d.loaddata("select * from sales_detail where in_no='" & txtinvno.Text & "'")
            DataGridView1.DataSource = ds.Tables(0)

            'calculate total
            Dim c As Integer = DataGridView1.Rows.Count - 1
            'sidho hisab
            Dim tot_with_gst As Double
            Dim cgsttot As Double = 0
            Dim sgsttot As Double = 0

            Dim tot_without_gst As Double = 0
            Dim gsttot As Double = 0
            While c >= 0
                cgsttot += Math.Round(((Val(DataGridView1.Rows(c).Cells("p_qty").Value) * Val(DataGridView1.Rows(c).Cells("p_rate").Value)) * Val(DataGridView1.Rows(c).Cells("p_cgst").Value)) / 100, 2)
                sgsttot += Math.Round(((Val(DataGridView1.Rows(c).Cells("p_qty").Value) * Val(DataGridView1.Rows(c).Cells("p_rate").Value)) * Val(DataGridView1.Rows(c).Cells("p_sgst").Value)) / 100, 2)
                tot_with_gst += Math.Round(Val(DataGridView1.Rows(c).Cells("p_tot").Value), 2)
                gsttot += Math.Round(Val(DataGridView1.Rows(c).Cells("p_gst_amt").Value), 2)

                tot_without_gst += Math.Round((Val(DataGridView1.Rows(c).Cells("p_qty").Value) * Val(DataGridView1.Rows(c).Cells("p_rate").Value)), 2)


                c -= 1
            End While
            ttaxamt.Text = tot_without_gst
            txtcgstamt.Text = Math.Round(cgsttot, 2)
            txtsgstamt.Text = Math.Round(sgsttot, 2)
            txtgsttotamt.Text = Val(txtcgstamt.Text) + Val(txtsgstamt.Text)
            txtgrandtot.Text = tot_with_gst + Val(txtlabour.Text)
            Dim total As Double = Val(txtgsttotamt.Text) + Val(ttaxamt.Text)
            txtround.Text = Math.Round(Math.Ceiling(total) - total, 2)

            txtgrandtot.Text = Math.Round(Val(txtgrandtot.Text))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtqty_textchanged(sender As Object, e As EventArgs) Handles txtqty.TextChanged, combotype.SelectedIndexChanged
        Try

            Dim basic As Double = Val(txtqty.Text) * Val(txtpsrate.Text)
            Dim cgst_amt As Double = basic * (Val(txtpcgst.Text) / 100)
            Dim sgst_amt As Double = basic * (Val(txtpsgst.Text) / 100)
            Dim basic_gst As Double
            txtgsttotper.Text = Val(txtpcgst.Text) + Val(txtpsgst.Text)
            txtamtgst.Text = Math.Round(cgst_amt + sgst_amt, 2)
            basic_gst = basic + cgst_amt + sgst_amt
            txttotamt.Text = Math.Round(basic_gst, 2)
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try


    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try

            Dim d As Integer = MessageBox.Show("Do you want to delete Category:" & DataGridView1.Item("p_cat", DataGridView1.CurrentCell.RowIndex).Value & " Company:" & DataGridView1.Item("p_com", DataGridView1.CurrentCell.RowIndex).Value & " Type:" & DataGridView1.Item("p_type", DataGridView1.CurrentCell.RowIndex).Value, "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            If d = 6 Then
                Dim id As Integer = DataGridView1.Item("id", DataGridView1.CurrentCell.RowIndex).Value
                Dim dp As New DAO
                dp.ModifyData("delete from sales_detail where id=" & id)
                update_inventory(1)
                load_invoice_data()
                update_creditor_account(1)
                If DataGridView1.Rows.Count = 0 Then
                    dp.ModifyData("delete from sales_summary where in_no='" & txtinvno.Text & "'")
                Else
                    'UPDATE TOTALS
                    dp.ModifyData("update sales_summary set in_tot=" & ttaxamt.Text & ",gst_tot=" & txtgsttotamt.Text & ",r_off=" & txtround.Text & ",lab_char=" & txtlabour.Text & " where in_no='" & txtinvno.Text & "'")
                End If
                btndelete.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try

            Dim ino As String = InputBox("Enter Invoice Number", "Search Invoice", "0")
            If ino <> "" And ino <> "0" Then
                txtinvno.Text = ino
                load_invoice_data()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try

            If DataGridView1.Rows.Count > 0 Then
                btndelete.Enabled = True
                txtpid.Text = DataGridView1.Item("p_id", DataGridView1.CurrentCell.RowIndex).Value
                Dim d As New DAO
                Dim obj As SqlClient.SqlDataReader
                obj = d.getdata("select p_stock from product_master where p_id =" & txtpid.Text)
                While obj.Read
                    txtstockqty.Text = obj.Item(0)
                End While
                d.closeconnection()
                txtqty.Text = DataGridView1.Item("p_qty", DataGridView1.CurrentCell.RowIndex).Value
                combocategory.Text = DataGridView1.Item("p_cat", DataGridView1.CurrentCell.RowIndex).Value
                combocompany.Text = DataGridView1.Item("p_com", DataGridView1.CurrentCell.RowIndex).Value
                combotype.Text = DataGridView1.Item("p_type", DataGridView1.CurrentCell.RowIndex).Value

            Else
                btndelete.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Function NumberToText(ByVal n As Integer) As String

        Select Case n
            Case 0
                Return ""

            Case 1 To 19
                Dim arr() As String = {"One", "Two", "Three", "Four", "Five", "Six", "Seven",
    "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
      "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                Return arr(n - 1) & " "

            Case 20 To 99
                Dim arr() As String = {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"}
                Return arr(n \ 10 - 2) & " " & NumberToText(n Mod 10)

            Case 100 To 199
                Return "One Hundred " & NumberToText(n Mod 100)

            Case 200 To 999
                Return NumberToText(n \ 100) & "Hundreds " & NumberToText(n Mod 100)

            Case 1000 To 1999
                Return "One Thousand " & NumberToText(n Mod 1000)

            Case 2000 To 999999
                Return NumberToText(n \ 1000) & "Thousands " & NumberToText(n Mod 1000)

            Case 1000000 To 1999999
                Return "One Million " & NumberToText(n Mod 1000000)

            Case 1000000 To 999999999
                Return NumberToText(n \ 1000000) & "Millions " & NumberToText(n Mod 1000000)

            Case 1000000000 To 1999999999
                Return "One Billion " & NumberToText(n Mod 1000000000)

            Case Else
                Return NumberToText(n \ 1000000000) & "Billion " _
    & NumberToText(n Mod 1000000000)
        End Select
    End Function
    Private Sub txtlabour_TextChanged(sender As Object, e As EventArgs) Handles txtlabour.TextChanged
        load_invoice_data()
    End Sub

    Private Sub btnfinal_Click(sender As Object, e As EventArgs) Handles btnfinal.Click
        Try

            Dim c As Integer = MessageBox.Show("Do you want to Save Invoice?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Dim d As New DAO
            If c = 6 Then
                'UPDATE TOTALS
                d.ModifyData("update sales_summary set in_tot=" & ttaxamt.Text & ",gst_tot=" & txtgsttotamt.Text & ",r_off=" & txtround.Text & ",in_narr='" & txtnarr.Text & "' where in_no='" & txtinvno.Text & "'")
                'update_creditor_account(1)
            End If

            dk = d.loaddata("Select sales_summary.*, sales_detail.* from sales_summary, sales_detail where  sales_summary.in_no = '" & txtinvno.Text & "' And Sales_Summary.In_No = Sales_Detail.In_No")

        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub load_product_data()
        If combotype.Text <> "" Then
            Try
                Dim d As New DAO
                Dim ds As New Data.DataSet
                ds = d.loaddata("select p_hsn,p_sales_rate,p_sales_unit,p_cgst,p_sgst,p_id,p_stock from product_master where p_type='" & combotype.Text & "' AND p_company='" & combocompany.Text & "' AND p_category='" & combocategory.Text & "'")
                If ds.Tables(0).Rows.Count > 0 Then
                    txtpcgst.Text = ds.Tables(0).Rows(0).Item(3)
                    txtpsgst.Text = ds.Tables(0).Rows(0).Item(4)
                    txtpid.Text = ds.Tables(0).Rows(0).Item(5)
                    txtphsn.Text = ds.Tables(0).Rows(0).Item(0)
                    txtpsrate.Text = ds.Tables(0).Rows(0).Item(1)
                    txtpsunit.Text = ds.Tables(0).Rows(0).Item(2)
                    txtstockqty.Text = ds.Tables(0).Rows(0).Item(6)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub combocname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtqty.KeyPress, combotype.KeyPress, combopay.KeyPress, combocompany.KeyPress, combocname.KeyPress, combocategory.KeyPress, txtlabour.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = combocname.Name Then
                combocategory.Focus()
            ElseIf sender.name = combocategory.Name Then
                combocompany.Focus()
            ElseIf sender.name = combocompany.Name Then
                combotype.Focus()
            ElseIf sender.name = combotype.Name Then
                txtqty.Focus()
            ElseIf sender.name = txtqty.Name Then
                combopay.Focus()
            ElseIf sender.name = combopay.Name Then
                btnsave.Focus()
            ElseIf sender.name = btnsave.Name Then
                btnnew.Focus()
            ElseIf sender.name = btnnew.Name Then
                btndelete.Focus()
            ElseIf sender.name = btndelete.Name Then
                btnsearch.Focus()
            ElseIf sender.name = btnsearch.Name Then
                txtlabour.Focus()
            End If
        End If
        Dim d As New DAO

        If sender.name = txtqty.Name Or sender.name = txtlabour.Name Then
            e.Handled = d.number_validate(e.KeyChar, e.KeyChar.GetHashCode)
        End If

        If sender.name = combocname.Name Then
            AutoSearch(sender, e, True)
        ElseIf sender.name = combotype.Name Then
            AutoSearch(sender, e, True)
        ElseIf sender.name = combocompany.Name Then
            AutoSearch(sender, e, True)
        ElseIf sender.name = combocategory.Name Then
            AutoSearch(sender, e, True)
        ElseIf sender.name = combopay.Name Then
            AutoSearch(sender, e, True)
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        Dim d As New DAO

        dk = d.loaddata("Select sales_summary.*, sales_detail.* from sales_summary, sales_detail where  sales_summary.in_no = '" & txtinvno.Text & "' And Sales_Summary.In_No = Sales_Detail.In_No")

        If DataGridView1.Rows.Count > 0 Then
            r_type = "sales_master"
            Dim d1 As New view_s_rpt
            d1.MdiParent = Me.MdiParent
            d1.Show()
        End If
    End Sub
End Class

