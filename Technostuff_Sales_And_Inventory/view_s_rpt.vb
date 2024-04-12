Imports CrystalDecisions.CrystalReports.Engine
Public Class view_s_rpt
    Private Sub view_s_rpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If r_type = "sales_summary" Then
            Dim d As New sales_summary_rpt
            d.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d.FileName)
            orpt.SetDataSource(dk.Tables(0))
            CrystalReportViewer1.ReportSource = orpt
            CrystalReportViewer2.ReportSource = orpt
            CrystalReportViewer3.ReportSource = orpt
            d.Dispose()
        ElseIf r_type = "purchase_summary" Then
            Dim d As New purchase_summary_rpt
            d.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d.FileName)
            orpt.SetDataSource(dk.Tables(0))
            CrystalReportViewer1.ReportSource = orpt
            CrystalReportViewer2.ReportSource = orpt
            CrystalReportViewer3.ReportSource = orpt
            d.Dispose()
        ElseIf r_type = "product_summary" Then
            Dim d As New product_summary_rpt
            d.Load()
            Dim orpt As New ReportDocument
            orpt.Load(d.FileName)
            orpt.SetDataSource(dk.Tables(0))
            CrystalReportViewer1.ReportSource = orpt
            CrystalReportViewer2.ReportSource = orpt
            CrystalReportViewer3.ReportSource = orpt
            d.Dispose()
        ElseIf r_type = "sales_master" Then
            Dim d As New inv_rpt
            d.load()
            Dim orpt As New ReportDocument
            orpt.Load(d.FileName)
            orpt.SetDataSource(dk.Tables(0))
            orpt.SetDatabaseLogon("data_stu5", "Lovecoding@6750")
            CrystalReportViewer3.ReportSource = orpt
            d.dispose()
        End If
    End Sub

    Private Sub CrystalReportViewer3_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer3.Load

    End Sub
End Class