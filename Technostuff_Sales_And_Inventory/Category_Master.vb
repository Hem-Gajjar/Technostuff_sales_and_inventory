Public Class Category_Master
    Dim flag As Integer = 0
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcategory.KeyPress, Button1.KeyPress
        If e.KeyChar.GetHashCode = 851981 Then
            txtid.Focus()
            If sender.name = txtid.Name Then
                txtcategory.Focus()
            ElseIf sender.name = txtcategory.Name Then
                Button1.Focus()
            End If
        End If
        Dim d As New DAO
        If sender.name = txtcategory.Name Then
            e.Handled = d.isalphanumeric_validate(e.KeyChar, e.KeyChar.GetHashCode)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim d As New DAO
            If txtcategory.Text <> "" Then
                Dim dao As New DAO
                If flag = 0 Then
                    dao.ModifyData("insert into category_master (ct_name) values ('" & txtcategory.Text & "')")

                    MessageBox.Show("Data Entered Succssefully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Button2_Click(sender, e)
                Else
                    dao.ModifyData("update category_master set ct_name='" & txtcategory.Text & "' where ct_id=" & txtid.Text & "")
                    MessageBox.Show("Category is updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Button2_Click(sender, e)
                    flag = 0
                End If
            Else
                MessageBox.Show("Enter Valid Category Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

                loaddata()
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtid.Text = ""
        txtcategory.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim c As New Integer
            c = MessageBox.Show("Do you want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If c = 6 Then
                Dim d As New DAO
                d.ModifyData("delete from category_master where ct_id=" & txtid.Text & " ")
            End If
            loaddata()
            Button3.Enabled = False
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
            ds = d.loaddata("select * from category_master")
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub category_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
        txtid.Focus()
        Dim d As New DAO
        d.enable_design(DataGridView1)
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                txtid.Text = DataGridView1.Item("ct_id", DataGridView1.CurrentCell.RowIndex).Value
                txtcategory.Text = DataGridView1.Item("ct_name", DataGridView1.CurrentCell.RowIndex).Value
                flag = 1
                Button3.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
End Class