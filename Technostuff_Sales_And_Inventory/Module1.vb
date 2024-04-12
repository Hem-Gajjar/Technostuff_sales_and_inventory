Module Module1
    Public u_name As String
    Public inv_no As String = ""
    Public dk As New DataSet
    Public r_type As String = ""

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
End Module
