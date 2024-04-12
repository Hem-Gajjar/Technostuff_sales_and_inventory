<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class product_summary
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(product_summary))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtgsttotamt = New System.Windows.Forms.TextBox()
        Me.txtgrandtot = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.p_cat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.in_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_com = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_gst_amt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_tot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.comboptype = New System.Windows.Forms.ComboBox()
        Me.btnprint = New System.Windows.Forms.Button()
        Me.btngenerate = New System.Windows.Forms.Button()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.combopcom = New System.Windows.Forms.ComboBox()
        Me.combopcat = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label29)
        Me.Panel3.Controls.Add(Me.Label25)
        Me.Panel3.Controls.Add(Me.txtgsttotamt)
        Me.Panel3.Controls.Add(Me.txtgrandtot)
        Me.Panel3.Location = New System.Drawing.Point(24, 777)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1744, 72)
        Me.Panel3.TabIndex = 13
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(1392, 25)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(104, 21)
        Me.Label29.TabIndex = 74
        Me.Label29.Text = "Grand Total : "
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(962, 23)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(145, 21)
        Me.Label25.TabIndex = 72
        Me.Label25.Text = "Total GST Amount :"
        '
        'txtgsttotamt
        '
        Me.txtgsttotamt.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgsttotamt.Location = New System.Drawing.Point(1126, 20)
        Me.txtgsttotamt.Name = "txtgsttotamt"
        Me.txtgsttotamt.Size = New System.Drawing.Size(214, 28)
        Me.txtgsttotamt.TabIndex = 71
        Me.txtgsttotamt.Text = "0"
        Me.txtgsttotamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtgrandtot
        '
        Me.txtgrandtot.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgrandtot.Location = New System.Drawing.Point(1509, 21)
        Me.txtgrandtot.Name = "txtgrandtot"
        Me.txtgrandtot.Size = New System.Drawing.Size(214, 28)
        Me.txtgrandtot.TabIndex = 73
        Me.txtgrandtot.Text = "0"
        Me.txtgrandtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Location = New System.Drawing.Point(24, 289)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1744, 470)
        Me.Panel2.TabIndex = 12
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.p_cat, Me.in_date, Me.p_com, Me.p_type, Me.p_qty, Me.p_rate, Me.p_gst_amt, Me.p_tot})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(1744, 470)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.TabStop = False
        '
        'p_cat
        '
        Me.p_cat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.p_cat.DataPropertyName = "p_cat"
        Me.p_cat.HeaderText = "Product Category"
        Me.p_cat.Name = "p_cat"
        Me.p_cat.ReadOnly = True
        '
        'in_date
        '
        Me.in_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.in_date.DataPropertyName = "in_date"
        Me.in_date.HeaderText = "Date"
        Me.in_date.Name = "in_date"
        Me.in_date.ReadOnly = True
        '
        'p_com
        '
        Me.p_com.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.p_com.DataPropertyName = "p_com"
        Me.p_com.HeaderText = "Product Company"
        Me.p_com.Name = "p_com"
        Me.p_com.ReadOnly = True
        '
        'p_type
        '
        Me.p_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.p_type.DataPropertyName = "p_type"
        Me.p_type.HeaderText = "Product Type"
        Me.p_type.Name = "p_type"
        Me.p_type.ReadOnly = True
        '
        'p_qty
        '
        Me.p_qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.p_qty.DataPropertyName = "p_qty"
        Me.p_qty.HeaderText = "Product Quantity"
        Me.p_qty.Name = "p_qty"
        Me.p_qty.ReadOnly = True
        '
        'p_rate
        '
        Me.p_rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.p_rate.DataPropertyName = "p_rate"
        Me.p_rate.HeaderText = "Product Rate"
        Me.p_rate.Name = "p_rate"
        Me.p_rate.ReadOnly = True
        '
        'p_gst_amt
        '
        Me.p_gst_amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.p_gst_amt.DataPropertyName = "p_gst_amt"
        Me.p_gst_amt.HeaderText = "GST Total"
        Me.p_gst_amt.Name = "p_gst_amt"
        Me.p_gst_amt.ReadOnly = True
        '
        'p_tot
        '
        Me.p_tot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.p_tot.DataPropertyName = "p_tot"
        Me.p_tot.HeaderText = "Product Total"
        Me.p_tot.Name = "p_tot"
        Me.p_tot.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.comboptype)
        Me.Panel1.Controls.Add(Me.btnprint)
        Me.Panel1.Controls.Add(Me.btngenerate)
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.combopcom)
        Me.Panel1.Controls.Add(Me.combopcat)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(24, 144)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1744, 130)
        Me.Panel1.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(498, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 21)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Product Type : "
        '
        'comboptype
        '
        Me.comboptype.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboptype.FormattingEnabled = True
        Me.comboptype.Location = New System.Drawing.Point(502, 71)
        Me.comboptype.Name = "comboptype"
        Me.comboptype.Size = New System.Drawing.Size(198, 29)
        Me.comboptype.TabIndex = 2
        '
        'btnprint
        '
        Me.btnprint.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btnprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnprint.ForeColor = System.Drawing.Color.White
        Me.btnprint.Location = New System.Drawing.Point(1568, 59)
        Me.btnprint.Name = "btnprint"
        Me.btnprint.Size = New System.Drawing.Size(112, 46)
        Me.btnprint.TabIndex = 8
        Me.btnprint.Text = "&Print"
        Me.btnprint.UseVisualStyleBackColor = False
        '
        'btngenerate
        '
        Me.btngenerate.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btngenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btngenerate.ForeColor = System.Drawing.Color.White
        Me.btngenerate.Location = New System.Drawing.Point(1394, 59)
        Me.btngenerate.Name = "btngenerate"
        Me.btngenerate.Size = New System.Drawing.Size(147, 46)
        Me.btngenerate.TabIndex = 7
        Me.btngenerate.Text = "&Generate"
        Me.btngenerate.UseVisualStyleBackColor = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Location = New System.Drawing.Point(1059, 72)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(295, 28)
        Me.DateTimePicker2.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1055, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 21)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "End Date :"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(729, 72)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(293, 28)
        Me.DateTimePicker1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(725, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 21)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Start Date :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(272, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 21)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Product Company : "
        '
        'combopcom
        '
        Me.combopcom.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combopcom.FormattingEnabled = True
        Me.combopcom.Location = New System.Drawing.Point(276, 71)
        Me.combopcom.Name = "combopcom"
        Me.combopcom.Size = New System.Drawing.Size(198, 29)
        Me.combopcom.TabIndex = 1
        '
        'combopcat
        '
        Me.combopcat.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combopcat.FormattingEnabled = True
        Me.combopcat.Location = New System.Drawing.Point(43, 71)
        Me.combopcat.Name = "combopcat"
        Me.combopcat.Size = New System.Drawing.Size(191, 29)
        Me.combopcat.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(39, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 21)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Product Category :"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Location = New System.Drawing.Point(24, 52)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1744, 77)
        Me.Panel5.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(748, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(63, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(830, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(303, 46)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Product Summary"
        '
        'product_summary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(24, 52)
        Me.Name = "product_summary"
        Me.Text = "product_summary"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label29 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtgsttotamt As TextBox
    Friend WithEvents txtgrandtot As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnprint As Button
    Friend WithEvents btngenerate As Button
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents combopcom As ComboBox
    Friend WithEvents combopcat As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents comboptype As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents p_cat As DataGridViewTextBoxColumn
    Friend WithEvents in_date As DataGridViewTextBoxColumn
    Friend WithEvents p_com As DataGridViewTextBoxColumn
    Friend WithEvents p_type As DataGridViewTextBoxColumn
    Friend WithEvents p_qty As DataGridViewTextBoxColumn
    Friend WithEvents p_rate As DataGridViewTextBoxColumn
    Friend WithEvents p_gst_amt As DataGridViewTextBoxColumn
    Friend WithEvents p_tot As DataGridViewTextBoxColumn
End Class
