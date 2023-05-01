<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(frmMain))
        Label1 = New Label()
        grpFinal = New GroupBox()
        lnkOutputFinal = New LinkLabel()
        lnkInputExpanded = New LinkLabel()
        Label7 = New Label()
        Label6 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        grdFinal = New DataGridView()
        grdInput = New DataGridView()
        grpDummy = New GroupBox()
        cmbHPTVersion = New ComboBox()
        lnkCopyDummyColumnHeaders = New LinkLabel()
        spinHzRange = New NumericUpDown()
        spinDummyColumns = New NumericUpDown()
        radHzRange = New RadioButton()
        radColumns = New RadioButton()
        lblSoftWarn = New Label()
        Label11 = New Label()
        Label10 = New Label()
        Label8 = New Label()
        Label5 = New Label()
        grdDummy = New DataGridView()
        grpInput = New GroupBox()
        lnkCopyDefaultColumnHeaders = New LinkLabel()
        lnkInputColumns = New LinkLabel()
        lnkInputTable = New LinkLabel()
        Label9 = New Label()
        Label2 = New Label()
        MenuStrip1 = New MenuStrip()
        mnuFile = New ToolStripMenuItem()
        mnuFileExit = New ToolStripMenuItem()
        mnuHelp = New ToolStripMenuItem()
        mnuHelpSupportBuyMeACoffee = New ToolStripMenuItem()
        mnuHelpSupportSendMeAPM = New ToolStripMenuItem()
        ToolStripMenuItem1 = New ToolStripSeparator()
        mnuHelpHowToYoutubeVideoDemo = New ToolStripMenuItem()
        mnuHelpUseDynamicAir = New ToolStripMenuItem()
        mnuHelpManuallyCheckForNewerVersion = New ToolStripMenuItem()
        mnuHelpAbout = New ToolStripMenuItem()
        grpFinal.SuspendLayout()
        CType(grdFinal, ComponentModel.ISupportInitialize).BeginInit()
        CType(grdInput, ComponentModel.ISupportInitialize).BeginInit()
        grpDummy.SuspendLayout()
        CType(spinHzRange, ComponentModel.ISupportInitialize).BeginInit()
        CType(spinDummyColumns, ComponentModel.ISupportInitialize).BeginInit()
        CType(grdDummy, ComponentModel.ISupportInitialize).BeginInit()
        grpInput.SuspendLayout()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 21)
        Label1.Name = "Label1"
        Label1.Size = New Size(35, 15)
        Label1.TabIndex = 0
        Label1.Text = "Paste"
        ' 
        ' grpFinal
        ' 
        grpFinal.Controls.Add(lnkOutputFinal)
        grpFinal.Controls.Add(lnkInputExpanded)
        grpFinal.Controls.Add(Label7)
        grpFinal.Controls.Add(Label6)
        grpFinal.Controls.Add(Label4)
        grpFinal.Controls.Add(Label3)
        grpFinal.Controls.Add(grdFinal)
        grpFinal.Location = New Point(3, 429)
        grpFinal.Name = "grpFinal"
        grpFinal.Size = New Size(978, 168)
        grpFinal.TabIndex = 2
        grpFinal.TabStop = False
        grpFinal.Text = "Remove Dummy Columns"
        ' 
        ' lnkOutputFinal
        ' 
        lnkOutputFinal.AutoSize = True
        lnkOutputFinal.Location = New Point(614, 24)
        lnkOutputFinal.Name = "lnkOutputFinal"
        lnkOutputFinal.Size = New Size(35, 15)
        lnkOutputFinal.TabIndex = 7
        lnkOutputFinal.TabStop = True
        lnkOutputFinal.Text = "Copy"
        ' 
        ' lnkInputExpanded
        ' 
        lnkInputExpanded.AutoSize = True
        lnkInputExpanded.Location = New Point(67, 24)
        lnkInputExpanded.Name = "lnkInputExpanded"
        lnkInputExpanded.Size = New Size(86, 15)
        lnkInputExpanded.TabIndex = 6
        lnkInputExpanded.TabStop = True
        lnkInputExpanded.Text = "Histo with Axis"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(6, 49)
        Label7.Name = "Label7"
        Label7.Size = New Size(225, 15)
        Label7.TabIndex = 10
        Label7.Text = "(from Scanner, will remove Dummy cells)"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(538, 47)
        Label6.Name = "Label6"
        Label6.Size = New Size(272, 15)
        Label6.TabIndex = 9
        Label6.Text = "(use as Paste Special > Multiply by % in the Editor)"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(538, 24)
        Label4.Name = "Label4"
        Label4.Size = New Size(45, 15)
        Label4.TabIndex = 8
        Label4.Text = "Output"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(6, 24)
        Label3.Name = "Label3"
        Label3.Size = New Size(35, 15)
        Label3.TabIndex = 2
        Label3.Text = "Paste"
        ' 
        ' grdFinal
        ' 
        grdFinal.AllowUserToAddRows = False
        grdFinal.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.ActiveCaption
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        grdFinal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        grdFinal.ColumnHeadersHeight = 34
        grdFinal.EnableHeadersVisualStyles = False
        grdFinal.Location = New Point(3, 75)
        grdFinal.Name = "grdFinal"
        grdFinal.ReadOnly = True
        grdFinal.RowHeadersVisible = False
        grdFinal.RowHeadersWidth = 62
        grdFinal.RowTemplate.Height = 25
        grdFinal.Size = New Size(968, 88)
        grdFinal.TabIndex = 2
        ' 
        ' grdInput
        ' 
        grdInput.AllowUserToAddRows = False
        grdInput.AllowUserToDeleteRows = False
        grdInput.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.ActiveCaption
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        grdInput.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        grdInput.ColumnHeadersHeight = 34
        grdInput.EnableHeadersVisualStyles = False
        grdInput.Location = New Point(3, 73)
        grdInput.Name = "grdInput"
        grdInput.ReadOnly = True
        grdInput.RowHeadersVisible = False
        grdInput.RowHeadersWidth = 62
        grdInput.RowTemplate.Height = 25
        grdInput.Size = New Size(968, 88)
        grdInput.TabIndex = 0
        ' 
        ' grpDummy
        ' 
        grpDummy.Controls.Add(cmbHPTVersion)
        grpDummy.Controls.Add(lnkCopyDummyColumnHeaders)
        grpDummy.Controls.Add(spinHzRange)
        grpDummy.Controls.Add(spinDummyColumns)
        grpDummy.Controls.Add(radHzRange)
        grpDummy.Controls.Add(radColumns)
        grpDummy.Controls.Add(lblSoftWarn)
        grpDummy.Controls.Add(Label11)
        grpDummy.Controls.Add(Label10)
        grpDummy.Controls.Add(Label8)
        grpDummy.Controls.Add(Label5)
        grpDummy.Controls.Add(grdDummy)
        grpDummy.Location = New Point(3, 194)
        grpDummy.Name = "grpDummy"
        grpDummy.Size = New Size(978, 232)
        grpDummy.TabIndex = 3
        grpDummy.TabStop = False
        grpDummy.Text = "Add Dummy Columns"
        ' 
        ' cmbHPTVersion
        ' 
        cmbHPTVersion.DropDownStyle = ComboBoxStyle.DropDownList
        cmbHPTVersion.FormattingEnabled = True
        cmbHPTVersion.Location = New Point(3, 99)
        cmbHPTVersion.Name = "cmbHPTVersion"
        cmbHPTVersion.Size = New Size(337, 23)
        cmbHPTVersion.TabIndex = 15
        ' 
        ' lnkCopyDummyColumnHeaders
        ' 
        lnkCopyDummyColumnHeaders.AutoSize = True
        lnkCopyDummyColumnHeaders.Location = New Point(614, 28)
        lnkCopyDummyColumnHeaders.Name = "lnkCopyDummyColumnHeaders"
        lnkCopyDummyColumnHeaders.Size = New Size(96, 15)
        lnkCopyDummyColumnHeaders.TabIndex = 6
        lnkCopyDummyColumnHeaders.TabStop = True
        lnkCopyDummyColumnHeaders.Text = "Column Headers"
        ' 
        ' spinHzRange
        ' 
        spinHzRange.Location = New Point(184, 64)
        spinHzRange.Name = "spinHzRange"
        spinHzRange.Size = New Size(58, 23)
        spinHzRange.TabIndex = 9
        spinHzRange.Value = New [Decimal](New Integer() {50, 0, 0, 0})
        ' 
        ' spinDummyColumns
        ' 
        spinDummyColumns.Enabled = False
        spinDummyColumns.Location = New Point(184, 27)
        spinDummyColumns.Name = "spinDummyColumns"
        spinDummyColumns.Size = New Size(58, 23)
        spinDummyColumns.TabIndex = 2
        spinDummyColumns.Value = New [Decimal](New Integer() {2, 0, 0, 0})
        ' 
        ' radHzRange
        ' 
        radHzRange.AutoSize = True
        radHzRange.Checked = True
        radHzRange.Location = New Point(3, 64)
        radHzRange.Name = "radHzRange"
        radHzRange.Size = New Size(96, 19)
        radHzRange.TabIndex = 8
        radHzRange.TabStop = True
        radHzRange.Text = "Hz Range +/-"
        radHzRange.UseVisualStyleBackColor = True
        ' 
        ' radColumns
        ' 
        radColumns.AutoSize = True
        radColumns.Location = New Point(3, 26)
        radColumns.Name = "radColumns"
        radColumns.Size = New Size(119, 19)
        radColumns.TabIndex = 7
        radColumns.Text = "Columns to Insert"
        radColumns.UseVisualStyleBackColor = True
        ' 
        ' lblSoftWarn
        ' 
        lblSoftWarn.AutoSize = True
        lblSoftWarn.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point)
        lblSoftWarn.ForeColor = Color.Red
        lblSoftWarn.Location = New Point(536, 99)
        lblSoftWarn.Name = "lblSoftWarn"
        lblSoftWarn.Size = New Size(265, 19)
        lblSoftWarn.TabIndex = 14
        lblSoftWarn.Text = "Excessive Columns for HPT version 4.x"
        lblSoftWarn.Visible = False
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(248, 29)
        Label11.Name = "Label11"
        Label11.Size = New Size(174, 15)
        Label11.TabIndex = 13
        Label11.Text = "(interpolates between columns)"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(248, 66)
        Label10.Name = "Label10"
        Label10.Size = New Size(164, 15)
        Label10.TabIndex = 12
        Label10.Text = "(adds a left and right column)"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(536, 66)
        Label8.Name = "Label8"
        Label8.Size = New Size(253, 15)
        Label8.TabIndex = 11
        Label8.Text = "(use as Column Axis Parameter in the Scanner)"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(538, 29)
        Label5.Name = "Label5"
        Label5.Size = New Size(35, 15)
        Label5.TabIndex = 6
        Label5.Text = "Copy"
        ' 
        ' grdDummy
        ' 
        grdDummy.AllowUserToAddRows = False
        grdDummy.AllowUserToDeleteRows = False
        grdDummy.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.ActiveCaption
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        grdDummy.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        grdDummy.ColumnHeadersHeight = 34
        grdDummy.EnableHeadersVisualStyles = False
        grdDummy.Location = New Point(3, 139)
        grdDummy.Name = "grdDummy"
        grdDummy.ReadOnly = True
        grdDummy.RowHeadersVisible = False
        grdDummy.RowHeadersWidth = 62
        grdDummy.RowTemplate.Height = 25
        grdDummy.Size = New Size(968, 88)
        grdDummy.TabIndex = 1
        ' 
        ' grpInput
        ' 
        grpInput.Controls.Add(lnkCopyDefaultColumnHeaders)
        grpInput.Controls.Add(lnkInputColumns)
        grpInput.Controls.Add(lnkInputTable)
        grpInput.Controls.Add(Label9)
        grpInput.Controls.Add(Label2)
        grpInput.Controls.Add(grdInput)
        grpInput.Controls.Add(Label1)
        grpInput.Location = New Point(3, 24)
        grpInput.Name = "grpInput"
        grpInput.Size = New Size(978, 168)
        grpInput.TabIndex = 3
        grpInput.TabStop = False
        grpInput.Text = "Default MAF Columns"
        ' 
        ' lnkCopyDefaultColumnHeaders
        ' 
        lnkCopyDefaultColumnHeaders.AutoSize = True
        lnkCopyDefaultColumnHeaders.Location = New Point(614, 21)
        lnkCopyDefaultColumnHeaders.Name = "lnkCopyDefaultColumnHeaders"
        lnkCopyDefaultColumnHeaders.Size = New Size(96, 15)
        lnkCopyDefaultColumnHeaders.TabIndex = 10
        lnkCopyDefaultColumnHeaders.TabStop = True
        lnkCopyDefaultColumnHeaders.Text = "Column Headers"
        ' 
        ' lnkInputColumns
        ' 
        lnkInputColumns.AutoSize = True
        lnkInputColumns.Location = New Point(63, 44)
        lnkInputColumns.Name = "lnkInputColumns"
        lnkInputColumns.Size = New Size(111, 15)
        lnkInputColumns.TabIndex = 5
        lnkInputColumns.TabStop = True
        lnkInputColumns.Text = "Column Axis Labels"
        ' 
        ' lnkInputTable
        ' 
        lnkInputTable.AutoSize = True
        lnkInputTable.Location = New Point(63, 21)
        lnkInputTable.Name = "lnkInputTable"
        lnkInputTable.Size = New Size(85, 15)
        lnkInputTable.TabIndex = 4
        lnkInputTable.TabStop = True
        lnkInputTable.Text = "Table with Axis"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(538, 46)
        Label9.Name = "Label9"
        Label9.Size = New Size(264, 15)
        Label9.TabIndex = 12
        Label9.Text = "(just in case you lost the originals in the Scanner)"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(538, 21)
        Label2.Name = "Label2"
        Label2.Size = New Size(35, 15)
        Label2.TabIndex = 11
        Label2.Text = "Copy"
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {mnuFile, mnuHelp})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(984, 24)
        MenuStrip1.TabIndex = 4
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' mnuFile
        ' 
        mnuFile.DropDownItems.AddRange(New ToolStripItem() {mnuFileExit})
        mnuFile.Name = "mnuFile"
        mnuFile.Size = New Size(37, 20)
        mnuFile.Text = "File"
        ' 
        ' mnuFileExit
        ' 
        mnuFileExit.Name = "mnuFileExit"
        mnuFileExit.Size = New Size(93, 22)
        mnuFileExit.Text = "Exit"
        ' 
        ' mnuHelp
        ' 
        mnuHelp.DropDownItems.AddRange(New ToolStripItem() {mnuHelpSupportBuyMeACoffee, mnuHelpSupportSendMeAPM, ToolStripMenuItem1, mnuHelpHowToYoutubeVideoDemo, mnuHelpUseDynamicAir, mnuHelpManuallyCheckForNewerVersion, mnuHelpAbout})
        mnuHelp.Name = "mnuHelp"
        mnuHelp.Size = New Size(44, 20)
        mnuHelp.Text = "Help"
        ' 
        ' mnuHelpSupportBuyMeACoffee
        ' 
        mnuHelpSupportBuyMeACoffee.Name = "mnuHelpSupportBuyMeACoffee"
        mnuHelpSupportBuyMeACoffee.Size = New Size(327, 22)
        mnuHelpSupportBuyMeACoffee.Text = "Support: Buy Me a Coffee"
        ' 
        ' mnuHelpSupportSendMeAPM
        ' 
        mnuHelpSupportSendMeAPM.Name = "mnuHelpSupportSendMeAPM"
        mnuHelpSupportSendMeAPM.Size = New Size(327, 22)
        mnuHelpSupportSendMeAPM.Text = "Support: Send Me a PM"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(324, 6)
        ' 
        ' mnuHelpHowToYoutubeVideoDemo
        ' 
        mnuHelpHowToYoutubeVideoDemo.Name = "mnuHelpHowToYoutubeVideoDemo"
        mnuHelpHowToYoutubeVideoDemo.Size = New Size(327, 22)
        mnuHelpHowToYoutubeVideoDemo.Text = "How To: Youtube Video Demo"
        ' 
        ' mnuHelpUseDynamicAir
        ' 
        mnuHelpUseDynamicAir.Name = "mnuHelpUseDynamicAir"
        mnuHelpUseDynamicAir.Size = New Size(327, 22)
        mnuHelpUseDynamicAir.Text = "First, join the 21st Centurty and use Dynamic Air"
        ' 
        ' mnuHelpManuallyCheckForNewerVersion
        ' 
        mnuHelpManuallyCheckForNewerVersion.Name = "mnuHelpManuallyCheckForNewerVersion"
        mnuHelpManuallyCheckForNewerVersion.Size = New Size(327, 22)
        mnuHelpManuallyCheckForNewerVersion.Text = "Manually Check for Newer Version"
        ' 
        ' mnuHelpAbout
        ' 
        mnuHelpAbout.Name = "mnuHelpAbout"
        mnuHelpAbout.Size = New Size(327, 22)
        mnuHelpAbout.Text = "About"
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(984, 601)
        Controls.Add(grpDummy)
        Controls.Add(grpInput)
        Controls.Add(grpFinal)
        Controls.Add(MenuStrip1)
        DoubleBuffered = True
        Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmMain"
        Text = "MAF Analyzer     [INTERNAL DEVELOPER RELEASE]     [ALPHA RELEASE 4]"
        grpFinal.ResumeLayout(False)
        grpFinal.PerformLayout()
        CType(grdFinal, ComponentModel.ISupportInitialize).EndInit()
        CType(grdInput, ComponentModel.ISupportInitialize).EndInit()
        grpDummy.ResumeLayout(False)
        grpDummy.PerformLayout()
        CType(spinHzRange, ComponentModel.ISupportInitialize).EndInit()
        CType(spinDummyColumns, ComponentModel.ISupportInitialize).EndInit()
        CType(grdDummy, ComponentModel.ISupportInitialize).EndInit()
        grpInput.ResumeLayout(False)
        grpInput.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents grpFinal As GroupBox
    Friend WithEvents grdInput As DataGridView
    Friend WithEvents grdFinal As DataGridView
    Friend WithEvents grpDummy As GroupBox
    Friend WithEvents grdDummy As DataGridView
    Friend WithEvents grpInput As GroupBox
    Friend WithEvents lnkOutputFinal As LinkLabel
    Friend WithEvents lnkInputExpanded As LinkLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents spinDummyColumns As NumericUpDown
    Friend WithEvents lnkInputColumns As LinkLabel
    Friend WithEvents lnkInputTable As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents lnkCopyDummyColumnHeaders As LinkLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents radHzRange As RadioButton
    Friend WithEvents radColumns As RadioButton
    Friend WithEvents spinHzRange As NumericUpDown
    Friend WithEvents lnkCopyDefaultColumnHeaders As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblSoftWarn As Label
    Friend WithEvents cmbHPTVersion As ComboBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuFileExit As ToolStripMenuItem
    Friend WithEvents mnuHelp As ToolStripMenuItem
    Friend WithEvents mnuHelpSupportBuyMeACoffee As ToolStripMenuItem
    Friend WithEvents mnuHelpSupportSendMeAPM As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuHelpHowToYoutubeVideoDemo As ToolStripMenuItem
    Friend WithEvents mnuHelpManuallyCheckForNewerVersion As ToolStripMenuItem
    Friend WithEvents mnuHelpAbout As ToolStripMenuItem
    Friend WithEvents mnuHelpUseDynamicAir As ToolStripMenuItem
End Class
