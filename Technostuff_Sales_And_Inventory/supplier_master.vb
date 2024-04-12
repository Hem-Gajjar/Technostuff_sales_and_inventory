Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

Public Class supplier_master
    Dim ds As DataSet
    Dim flag As Integer = 0
    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcity.KeyPress, txtcontact.KeyPress, btnsave.KeyPress, txtgst.KeyPress, txtname.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            txtname.Focus()
            If sender.name = txtname.Name Then
                txtcontact.Focus()
            ElseIf sender.name = txtcontact.Name Then
                txtcity.Focus()
            ElseIf sender.name = txtcity.Name Then
                txtemail.Focus()
            ElseIf sender.name = txtemail.Name Then
                txtgst.Focus()
            End If
        End If
        Dim d As New DAO
        If sender.name = txtcontact.Name Then
            e.Handled = d.number_validate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = txtcity.Name Or sender.name = txtname.Name Then
            e.Handled = d.isalpha_validate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
        If sender.name = txtgst.Name Or sender.name = txtemail.Name Then
            e.Handled = d.isalphanumeric_validate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        'try

        Dim d As New DAO
            If txtname.Text <> "" Then
                If txtcontact.Text <> "" And txtcontact.TextLength = 10 And IsNumeric(txtcontact.Text) Then
                    If txtcity.Text <> "" Then
                        If txtgst.Text <> "" And txtgst.TextLength = 15 Then
                            If txtemail.Text <> "" And d.valid_email(txtemail.Text) = 1 Then
                                Dim dao As New DAO
                                If flag = 0 Then
                                    'insert
                                    Try
                                        dao.ModifyData("insert into supplier_master (s_name,s_contact,s_address,gst_number,s_email) values ('" & txtname.Text & "'," & txtcontact.Text & ",'" & txtcity.Text & "','" & txtgst.Text & "','" & txtemail.Text & "')")
                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                    End Try
                                    MessageBox.Show("Supplier is created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    Button2_Click(sender, e)
                                Else
                                    'update
                                    dao.ModifyData("update supplier_master set s_name ='" & txtname.Text & "', s_contact=" & txtcontact.Text & " , s_address='" & txtcity.Text & "', gst_number='" & txtgst.Text & "',s_email = '" & txtemail.Text & "' where s_id=" & txtid.Text & "")

                                    MessageBox.Show("Supplier is updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                    flag = 0
                                    Button2_Click(sender, e)
                                End If
                            Else
                                MessageBox.Show("Enter Valid Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                txtgst.Focus()
                            End If
                        Else
                            MessageBox.Show("Enter Valid GST Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            txtgst.Focus()
                        End If
                    Else
                        MessageBox.Show("Enter Valid City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        txtcity.Focus()
                    End If
                Else
                    MessageBox.Show("Enter Valid Contact Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    txtcontact.Focus()
                End If
            Else
                MessageBox.Show("Enter Valid Supplier Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                txtname.Focus()
            End If
            loaddata()
        'Catch ex As Exception
        'MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        txtid.Text = ""
        txtname.Text = ""
        txtemail.Text = ""
        txtcontact.Text = ""
        txtcity.Text = ""
        txtgst.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try
            Dim c As New Integer
            c = MessageBox.Show("Do you want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If c = 6 Then
                Dim d As New DAO
                d.ModifyData("delete from supplier_master where s_id=" & txtid.Text & " ")
            End If
            loaddata()
            btndelete.Enabled = False
            Button2_Click(sender, e)
            flag = 0
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Public Sub loaddata()
        Try
            Dim ds As New Data.DataSet
            Dim d As New DAO
            ds = d.loaddata("select * from supplier_master")
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Dim d As New DAO
    Private Sub supplier_master_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
        d.enable_design(DataGridView1)
    End Sub
    Private Sub DataGridView3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                txtid.Text = DataGridView1.Item("s_id", DataGridView1.CurrentCell.RowIndex).Value
                txtname.Text = DataGridView1.Item("s_name", DataGridView1.CurrentCell.RowIndex).Value
                txtcontact.Text = DataGridView1.Item("s_contact", DataGridView1.CurrentCell.RowIndex).Value
                txtcity.Text = DataGridView1.Item("s_address", DataGridView1.CurrentCell.RowIndex).Value
                txtgst.Text = DataGridView1.Item("gst_number", DataGridView1.CurrentCell.RowIndex).Value
                txtemail.Text = DataGridView1.Item("s_email", DataGridView1.CurrentCell.RowIndex).Value
                flag = 1
                btndelete.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
End Class