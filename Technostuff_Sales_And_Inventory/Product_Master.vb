Imports System.Data.SqlClient
Public Class Product_Master
    Dim dao As New DAO
    Dim flag As Integer = 0
    Private Sub Product_Master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            loaddata()
            txtid.Focus()
            btndelete.Enabled = False
            Dim d As New DAO
            d.enable_design(DataGridView1)
            Dim obj As SqlDataReader
            obj = d.getdata("select distinct(ct_name) from category_master")
            While obj.Read
                combocategory.Items.Add(obj.Item(0))
            End While
            obj = d.getdata("select distinct(u_name) from unit_master")
            While obj.Read
                combopunit.Items.Add(obj.Item(0))
            End While
            obj = d.getdata("select distinct(u_name) from unit_master")
            While obj.Read
                combosunit.Items.Add(obj.Item(0))
            End While
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Public Sub loaddata()
        Try
            Dim ds As New Data.DataSet
            Dim d As New DAO
            ds = d.loaddata("select * from product_master")
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub txtid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtid.KeyPress, combocategory.KeyPress, combopunit.KeyPress, numcgst.KeyPress, numsgst.KeyPress, combocompany.KeyPress, combotype.KeyPress, txthsn.KeyPress, combosunit.KeyPress, txtprate.KeyPress, txtsrate.KeyPress

        If e.KeyChar.GetHashCode = 851981 Then
            combocategory.Focus()
            If sender.name = combocategory.Name Then
                combocompany.Focus()
            ElseIf sender.name = combocompany.Name Then
                combotype.Focus()
            ElseIf sender.name = combotype.Name Then
                numcgst.Focus()
            ElseIf sender.name = numcgst.Name Then
                numsgst.Focus()
            ElseIf sender.name = numsgst.Name Then
                txthsn.Focus()
            ElseIf sender.name = txthsn.Name Then
                combopunit.Focus()
            ElseIf sender.name = combopunit.Name Then
                txtprate.Focus()
            ElseIf sender.name = txtprate.Name Then
                combosunit.Focus()
            ElseIf sender.name = combosunit.Name Then
                txtsrate.Focus()
            ElseIf sender.name = txtsrate.Name Then
                btnnew.Focus()
            End If
        End If
        Dim d As New DAO
        If sender.name = txthsn.Name Or sender.name = txtprate.Name Or sender.name = txtsrate.Name Or sender.name = txtstock.Name Then
            e.Handled = d.number_validate(e.KeyChar, e.KeyChar.GetHashCode)
        End If

    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        txtid.Text = ""
        combocategory.Text = ""
        combocompany.Text = ""
        combotype.Text = ""
        combopunit.Text = ""
        combosunit.Text = ""
        numcgst.Value = 0
        numsgst.Value = 0
        txthsn.Text = ""
        txtsrate.Text = ""
        txtprate.Text = ""
        txtstock.Text = ""
        combocategory.Focus()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            If combocategory.Text <> "" Then
                If combocompany.Text <> "" Then
                    If combotype.Text <> "" Then
                        If combopunit.Text <> "" Then
                            If numcgst.Value >= 0 Then
                                If numsgst.Value >= 0 Then
                                    If txthsn.Text <> "" Then
                                        If combosunit.Text <> "" Then
                                            If txtprate.Text <> "" Then
                                                If txtsrate.Text <> "" Then
                                                    If txtstock.Text <> "" Then
                                                        If flag = 0 Then
                                                            Dim f As Integer = 0
                                                            f = dao.validate("select p_category,p_company,p_type from product_master where p_category='" & combocategory.Text & "' AND p_company='" & combocompany.Text & "' AND p_type='" & combotype.Text & "'")
                                                            If f = 1 Then
                                                                MessageBox.Show("Product is already created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                                                combocategory.Focus()
                                                            Else
                                                                'insert
                                                                dao.ModifyData("insert into product_master (p_category,p_company,p_type,p_cgst,p_sgst,p_hsn,p_purch_unit,p_sales_unit,p_purch_rate,p_sales_rate,p_stock) values ('" & combocategory.Text & "','" & combocompany.Text & "','" & combotype.Text & "'," & numcgst.Value & "," & numsgst.Value & "," & txthsn.Text & ",'" & combopunit.Text & "','" & combosunit.Text & "'," & txtprate.Text & "," & txtsrate.Text & "," & txtstock.Text & ")")
                                                                MessageBox.Show("Product Created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                                btnnew_Click(sender, e)

                                                            End If
                                                        Else
                                                            'update
                                                            dao.ModifyData("update product_master set p_category='" & combocategory.Text & "',p_company='" & combocompany.Text & "',p_type='" & combotype.Text & "',p_cgst='" & numcgst.Value & "',p_sgst='" & numsgst.Text & "',p_hsn='" & txthsn.Text & "',p_purch_unit='" & combopunit.Text & "',p_sales_unit='" & combosunit.Text & "',p_purch_rate='" & txtprate.Text & "',p_sales_rate='" & txtsrate.Text & "',p_stock=" & txtstock.Text & " where p_id='" & txtid.Text & "'")

                                                            MessageBox.Show("Product Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                                            flag = 0
                                                            btnnew_Click(sender, e)
                                                        End If

                                                    Else
                                                        MessageBox.Show("Enter Opening Stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                                        txtstock.Focus()
                                                    End If
                                                Else
                                                    MessageBox.Show("Enter Sales Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                                    txtsrate.Focus()

                                                End If
                                            Else
                                                MessageBox.Show("Enter Purchase Rate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                                txtprate.Focus()
                                            End If
                                        Else
                                            MessageBox.Show("Enter Sales Unit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                            combosunit.Focus()
                                        End If
                                    Else
                                        MessageBox.Show("Enter Valid HSN Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                        txthsn.Focus()
                                    End If
                                Else
                                    MessageBox.Show("Enter SGST For Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                    numsgst.Focus()
                                End If
                            Else
                                MessageBox.Show("Enter CGST For Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                numcgst.Focus()
                            End If
                        Else
                            MessageBox.Show("Enter Valid Purchase Unit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            combopunit.Focus()
                        End If
                    Else
                        MessageBox.Show("Enter Valid Product Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        combotype.Focus()
                    End If
                Else
                    MessageBox.Show("Enter Valid Company", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    combocompany.Focus()
                End If
            Else
                MessageBox.Show("Enter Valid Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                combocategory.Focus()
            End If
            loaddata()
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows.Count > 0 Then
            txtid.Text = DataGridView1.Item("p_id", DataGridView1.CurrentCell.RowIndex).Value
            combocategory.Text = DataGridView1.Item("p_category", DataGridView1.CurrentCell.RowIndex).Value
            combocompany.Text = DataGridView1.Item("p_company", DataGridView1.CurrentCell.RowIndex).Value
            combotype.Text = DataGridView1.Item("p_type", DataGridView1.CurrentCell.RowIndex).Value
            numcgst.Text = DataGridView1.Item("p_cgst", DataGridView1.CurrentCell.RowIndex).Value
            numsgst.Text = DataGridView1.Item("p_sgst", DataGridView1.CurrentCell.RowIndex).Value
            txthsn.Text = DataGridView1.Item("p_hsn", DataGridView1.CurrentCell.RowIndex).Value
            combopunit.Text = DataGridView1.Item("p_purch_unit", DataGridView1.CurrentCell.RowIndex).Value
            combosunit.Text = DataGridView1.Item("p_sales_unit", DataGridView1.CurrentCell.RowIndex).Value
            txtprate.Text = DataGridView1.Item("p_purch_rate", DataGridView1.CurrentCell.RowIndex).Value
            txtsrate.Text = DataGridView1.Item("p_sales_rate", DataGridView1.CurrentCell.RowIndex).Value
            txtstock.Text = DataGridView1.Item("p_stock", DataGridView1.CurrentCell.RowIndex).Value
            flag = 1
            btndelete.Enabled = True
        End If
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try

            Dim c As Integer
            c = MessageBox.Show("Do you want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If c = 6 Then
                Dim d As New DAO
                d.ModifyData("delete from product_master where p_id=" & txtid.Text & " ")
                loaddata()
                btndelete.Enabled = False
                btnnew_Click(sender, e)
                flag = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub combocategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combocategory.SelectedIndexChanged
        Try

            Dim obj As SqlDataReader
            Dim d As New DAO
            combocompany.Items.Clear()
            obj = d.getdata("select distinct(company_name) from sub_category_master where category_name='" & combocategory.Text & "'")
            While obj.Read
                combocompany.Items.Add(obj.Item(0))
            End While
            Dim check As String = combocategory.Text
            If String.Compare(check, "Cement", True) = 0 Then
                numcgst.Value = 14
                numsgst.Value = 14
                combopunit.Text = "Bag"
                combosunit.Text = "Bag"
            ElseIf String.Compare(check, "Steel", True) = 0 Then
                numcgst.Value = 9
                numsgst.Value = 9
                combopunit.Text = "Kilogram"
                combosunit.Text = "Kilogram"
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub combocompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combocompany.SelectedIndexChanged
        Try
            Dim obj As SqlDataReader
            Dim d As New DAO
            combotype.Items.Clear()
            obj = d.getdata("select distinct(product_type) from sub_category_master where company_name='" & combocompany.Text & "' And category_name='" & combocategory.Text & "'")
            While obj.Read
                combotype.Items.Add(obj.Item(0))
            End While

        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


End Class