Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

Public Class Customer_master
    Dim flag As Integer = 0
    Dim d As New DAO
    Private Sub Customer_master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
        txtname.Focus()
        d.enable_design(DataGridView1)
    End Sub

    Private Sub txtname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtname.KeyPress, txtemail.KeyPress, txtaddress.KeyPress, txtgst.KeyPress, txtcontact.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            If sender.name = txtname.Name Then
                txtcontact.Focus()
            ElseIf sender.name = txtcontact.Name Then
                txtemail.Focus()
            ElseIf sender.name = txtemail.Name Then
                txtaddress.Focus()
            ElseIf sender.name = txtaddress.Name Then
                txtgst.Focus()
            ElseIf sender.name = txtgst.Name Then
                btnnew.Focus()
            End If
        End If
        Dim d As New DAO
        If sender.name = txtgst.Name Then
            e.Handled = d.isalphanumeric_validate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = txtname.Name Then
            e.Handled = d.isalpha_validate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = txtcontact.Name Then
            e.Handled = d.number_validate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click

        txtid.Text = ""
        txtname.Text = ""
        txtcontact.Text = ""
        txtaddress.Text = ""
        txtemail.Text = ""
        txtgst.Text = ""
        btndelete.Enabled = False
        txtname.Focus()

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim dao As New DAO
        'Try
        If txtname.Text <> "" Then
                If txtcontact.Text <> "" And txtcontact.TextLength = 10 And IsNumeric(txtcontact.Text) Then
                    If txtemail.Text <> "" And dao.valid_email(txtemail.Text) = 1 Then
                        If txtaddress.Text <> "" Then
                            If txtgst.Text <> "" And txtgst.TextLength = 15 Then
                                If flag = 0 Then
                                    'insert
                                    Dim check As Integer
                                    check = dao.validate("select c_name from customer_master where c_name='" & txtname.Text & "'")
                                    If check = 1 Then
                                        MessageBox.Show("Customer is already created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                        txtname.Focus()
                                    Else
                                        dao.ModifyData("insert into customer_master(c_name,c_contact,c_email,c_address,c_gst) values ('" & txtname.Text & "'," & txtcontact.Text & ",'" & txtemail.Text & "','" & txtaddress.Text & "','" & txtgst.Text & "')")

                                        MessageBox.Show("Customer is created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                        btnnew_Click(sender, e)
                                    End If
                                Else
                                    'update
                                    dao.ModifyData("update customer_master set c_name='" & txtname.Text & "' , c_contact=" & txtcontact.Text & " , c_email='" & txtemail.Text & "', c_address='" & txtaddress.Text & "', c_gst='" & txtgst.Text & "' where c_id=" & txtid.Text & " ")
                                MessageBox.Show("Customer is updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                flag = 0
                                btnnew_Click(sender, e)
                            End If
                            Else
                                MessageBox.Show("Enter valid GST number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                txtgst.Focus()

                            End If
                        Else
                            MessageBox.Show("Enter valid address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            txtaddress.Focus()
                        End If
                    Else
                        MessageBox.Show("Enter valid email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        txtemail.Focus()
                    End If
                Else
                    MessageBox.Show("Enter valid contact number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1)
                    txtcontact.Focus()
                End If
            Else
                MessageBox.Show("Enter valid name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                txtname.Focus()
            End If
            loaddata()
        'Catch ex As Exception
        'MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'End Try

    End Sub
    Public Sub loaddata()
        Try

            Dim ds As New Data.DataSet
            ds = d.loaddata("select * from customer_master")
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try

            If DataGridView1.Rows.Count > 0 Then
                txtid.Text = DataGridView1.Item("c_id", DataGridView1.CurrentCell.RowIndex).Value
                txtname.Text = DataGridView1.Item("c_name", DataGridView1.CurrentCell.RowIndex).Value
                txtcontact.Text = DataGridView1.Item("c_contact", DataGridView1.CurrentCell.RowIndex).Value
                txtemail.Text = DataGridView1.Item("c_email", DataGridView1.CurrentCell.RowIndex).Value
                txtaddress.Text = DataGridView1.Item("c_address", DataGridView1.CurrentCell.RowIndex).Value
                txtgst.Text = DataGridView1.Item("c_gst", DataGridView1.CurrentCell.RowIndex).Value
                flag = 1
                btndelete.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Dim c As Integer
        c = MessageBox.Show("Do you want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Try
            If c = 6 Then
                Dim d As New DAO
                d.ModifyData("delete from customer_master where c_id=" & txtid.Text & " ")
                loaddata()
                btndelete.Enabled = False
                btnnew_Click(sender, e)
                flag = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
End Class
