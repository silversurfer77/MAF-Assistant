<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileClearStartOver = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpSupportBuyMeACoffee = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpSupportSendMeAPM = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuHelpHowToYoutubeVideoDemo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpUseDynamicAir = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpManuallyCheckForNewerVersion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxDrillDown = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxGenerateFocusList25 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxGenerateFocusList50 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrCopied = New System.Windows.Forms.Timer(Me.components)
        Me.grpInput = New System.Windows.Forms.GroupBox()
        Me.grdInput = New System.Windows.Forms.DataGridView()
        Me.lblCopiedDefault = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lnkCopyDefaultColumnHeaders = New System.Windows.Forms.LinkLabel()
        Me.lnkInputColumns = New System.Windows.Forms.LinkLabel()
        Me.lnkInputTable = New System.Windows.Forms.LinkLabel()
        Me.grpDummy = New System.Windows.Forms.GroupBox()
        Me.grdDummy = New System.Windows.Forms.DataGridView()
        Me.cmbHPTVersion = New System.Windows.Forms.ComboBox()
        Me.lblSoftWarn = New System.Windows.Forms.Label()
        Me.lblCopiedDummy = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lnkCopyDummyColumnHeaders = New System.Windows.Forms.LinkLabel()
        Me.spinHzRange = New System.Windows.Forms.NumericUpDown()
        Me.spinDummyColumns = New System.Windows.Forms.NumericUpDown()
        Me.radHzRange = New System.Windows.Forms.RadioButton()
        Me.radColumns = New System.Windows.Forms.RadioButton()
        Me.grpFinal = New System.Windows.Forms.GroupBox()
        Me.grdFinal = New System.Windows.Forms.DataGridView()
        Me.lblCopiedFinal = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lnkOutputFinal = New System.Windows.Forms.LinkLabel()
        Me.lnkInputExpanded = New System.Windows.Forms.LinkLabel()
        Me.ctxCopyColumnHeaders = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1.SuspendLayout()
        Me.ctxDrillDown.SuspendLayout()
        Me.grpInput.SuspendLayout()
        CType(Me.grdInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDummy.SuspendLayout()
        CType(Me.grdDummy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spinHzRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spinDummyColumns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFinal.SuspendLayout()
        CType(Me.grdFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(1264, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileClearStartOver, Me.ToolStripMenuItem2, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 19)
        Me.mnuFile.Text = "File"
        '
        'mnuFileClearStartOver
        '
        Me.mnuFileClearStartOver.Name = "mnuFileClearStartOver"
        Me.mnuFileClearStartOver.Size = New System.Drawing.Size(158, 22)
        Me.mnuFileClearStartOver.Text = "Clear/Start Over"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(155, 6)
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(158, 22)
        Me.mnuFileExit.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpSupportBuyMeACoffee, Me.mnuHelpSupportSendMeAPM, Me.ToolStripMenuItem1, Me.mnuHelpHowToYoutubeVideoDemo, Me.mnuHelpUseDynamicAir, Me.mnuHelpManuallyCheckForNewerVersion, Me.mnuHelpAbout})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 19)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'mnuHelpSupportBuyMeACoffee
        '
        Me.mnuHelpSupportBuyMeACoffee.Name = "mnuHelpSupportBuyMeACoffee"
        Me.mnuHelpSupportBuyMeACoffee.Size = New System.Drawing.Size(323, 22)
        Me.mnuHelpSupportBuyMeACoffee.Text = "Support: Buy Me a Coffee"
        '
        'mnuHelpSupportSendMeAPM
        '
        Me.mnuHelpSupportSendMeAPM.Name = "mnuHelpSupportSendMeAPM"
        Me.mnuHelpSupportSendMeAPM.Size = New System.Drawing.Size(323, 22)
        Me.mnuHelpSupportSendMeAPM.Text = "Support: Send Me a PM"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(320, 6)
        '
        'mnuHelpHowToYoutubeVideoDemo
        '
        Me.mnuHelpHowToYoutubeVideoDemo.Name = "mnuHelpHowToYoutubeVideoDemo"
        Me.mnuHelpHowToYoutubeVideoDemo.Size = New System.Drawing.Size(323, 22)
        Me.mnuHelpHowToYoutubeVideoDemo.Text = "How To: Youtube Video Demo"
        '
        'mnuHelpUseDynamicAir
        '
        Me.mnuHelpUseDynamicAir.Name = "mnuHelpUseDynamicAir"
        Me.mnuHelpUseDynamicAir.Size = New System.Drawing.Size(323, 22)
        Me.mnuHelpUseDynamicAir.Text = "First, join the 21st Century and use Dynamic Air"
        '
        'mnuHelpManuallyCheckForNewerVersion
        '
        Me.mnuHelpManuallyCheckForNewerVersion.Name = "mnuHelpManuallyCheckForNewerVersion"
        Me.mnuHelpManuallyCheckForNewerVersion.Size = New System.Drawing.Size(323, 22)
        Me.mnuHelpManuallyCheckForNewerVersion.Text = "Manully Check for Newer Version"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(323, 22)
        Me.mnuHelpAbout.Text = "About"
        '
        'ctxDrillDown
        '
        Me.ctxDrillDown.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxCopyColumnHeaders, Me.ToolStripMenuItem3, Me.ctxGenerateFocusList25, Me.ctxGenerateFocusList50})
        Me.ctxDrillDown.Name = "ctxDrillDown"
        Me.ctxDrillDown.Size = New System.Drawing.Size(213, 76)
        '
        'ctxGenerateFocusList25
        '
        Me.ctxGenerateFocusList25.Name = "ctxGenerateFocusList25"
        Me.ctxGenerateFocusList25.Size = New System.Drawing.Size(212, 22)
        Me.ctxGenerateFocusList25.Tag = "25"
        Me.ctxGenerateFocusList25.Text = "Generate Focus List +/- 25"
        '
        'ctxGenerateFocusList50
        '
        Me.ctxGenerateFocusList50.Name = "ctxGenerateFocusList50"
        Me.ctxGenerateFocusList50.Size = New System.Drawing.Size(212, 22)
        Me.ctxGenerateFocusList50.Tag = "50"
        Me.ctxGenerateFocusList50.Text = "Generate Focus List +/- 50"
        '
        'tmrCopied
        '
        Me.tmrCopied.Interval = 500
        '
        'grpInput
        '
        Me.grpInput.Controls.Add(Me.grdInput)
        Me.grpInput.Controls.Add(Me.lblCopiedDefault)
        Me.grpInput.Controls.Add(Me.Label3)
        Me.grpInput.Controls.Add(Me.Label2)
        Me.grpInput.Controls.Add(Me.Label1)
        Me.grpInput.Controls.Add(Me.lnkCopyDefaultColumnHeaders)
        Me.grpInput.Controls.Add(Me.lnkInputColumns)
        Me.grpInput.Controls.Add(Me.lnkInputTable)
        Me.grpInput.Location = New System.Drawing.Point(4, 32)
        Me.grpInput.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.grpInput.Name = "grpInput"
        Me.grpInput.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.grpInput.Size = New System.Drawing.Size(1253, 198)
        Me.grpInput.TabIndex = 2
        Me.grpInput.TabStop = False
        Me.grpInput.Text = "Default MAF Columns"
        '
        'grdInput
        '
        Me.grdInput.AllowUserToAddRows = False
        Me.grdInput.AllowUserToDeleteRows = False
        Me.grdInput.AllowUserToResizeRows = False
        Me.grdInput.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.grdInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdInput.EnableHeadersVisualStyles = False
        Me.grdInput.Location = New System.Drawing.Point(4, 75)
        Me.grdInput.Margin = New System.Windows.Forms.Padding(4)
        Me.grdInput.Name = "grdInput"
        Me.grdInput.ReadOnly = True
        Me.grdInput.RowHeadersVisible = False
        Me.grdInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdInput.ShowEditingIcon = False
        Me.grdInput.Size = New System.Drawing.Size(1245, 117)
        Me.grdInput.TabIndex = 11
        '
        'lblCopiedDefault
        '
        Me.lblCopiedDefault.AutoSize = True
        Me.lblCopiedDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopiedDefault.ForeColor = System.Drawing.Color.Green
        Me.lblCopiedDefault.Location = New System.Drawing.Point(969, 25)
        Me.lblCopiedDefault.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCopiedDefault.Name = "lblCopiedDefault"
        Me.lblCopiedDefault.Size = New System.Drawing.Size(164, 20)
        Me.lblCopiedDefault.TabIndex = 10
        Me.lblCopiedDefault.Text = "Copied to clipboard"
        Me.lblCopiedDefault.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(692, 25)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Copy"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(692, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(352, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "(just in case you lost the originals in the Scanner)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Paste"
        '
        'lnkCopyDefaultColumnHeaders
        '
        Me.lnkCopyDefaultColumnHeaders.AutoSize = True
        Me.lnkCopyDefaultColumnHeaders.Location = New System.Drawing.Point(789, 25)
        Me.lnkCopyDefaultColumnHeaders.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lnkCopyDefaultColumnHeaders.Name = "lnkCopyDefaultColumnHeaders"
        Me.lnkCopyDefaultColumnHeaders.Size = New System.Drawing.Size(128, 20)
        Me.lnkCopyDefaultColumnHeaders.TabIndex = 6
        Me.lnkCopyDefaultColumnHeaders.TabStop = True
        Me.lnkCopyDefaultColumnHeaders.Text = "Column Headers"
        '
        'lnkInputColumns
        '
        Me.lnkInputColumns.AutoSize = True
        Me.lnkInputColumns.Location = New System.Drawing.Point(81, 50)
        Me.lnkInputColumns.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lnkInputColumns.Name = "lnkInputColumns"
        Me.lnkInputColumns.Size = New System.Drawing.Size(147, 20)
        Me.lnkInputColumns.TabIndex = 5
        Me.lnkInputColumns.TabStop = True
        Me.lnkInputColumns.Text = "Column Axis Labels"
        '
        'lnkInputTable
        '
        Me.lnkInputTable.AutoSize = True
        Me.lnkInputTable.Location = New System.Drawing.Point(81, 25)
        Me.lnkInputTable.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lnkInputTable.Name = "lnkInputTable"
        Me.lnkInputTable.Size = New System.Drawing.Size(113, 20)
        Me.lnkInputTable.TabIndex = 4
        Me.lnkInputTable.TabStop = True
        Me.lnkInputTable.Text = "Table with Axis"
        '
        'grpDummy
        '
        Me.grpDummy.Controls.Add(Me.grdDummy)
        Me.grpDummy.Controls.Add(Me.cmbHPTVersion)
        Me.grpDummy.Controls.Add(Me.lblSoftWarn)
        Me.grpDummy.Controls.Add(Me.lblCopiedDummy)
        Me.grpDummy.Controls.Add(Me.Label5)
        Me.grpDummy.Controls.Add(Me.Label7)
        Me.grpDummy.Controls.Add(Me.Label4)
        Me.grpDummy.Controls.Add(Me.Label8)
        Me.grpDummy.Controls.Add(Me.lnkCopyDummyColumnHeaders)
        Me.grpDummy.Controls.Add(Me.spinHzRange)
        Me.grpDummy.Controls.Add(Me.spinDummyColumns)
        Me.grpDummy.Controls.Add(Me.radHzRange)
        Me.grpDummy.Controls.Add(Me.radColumns)
        Me.grpDummy.Location = New System.Drawing.Point(4, 231)
        Me.grpDummy.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.grpDummy.Name = "grpDummy"
        Me.grpDummy.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.grpDummy.Size = New System.Drawing.Size(1253, 241)
        Me.grpDummy.TabIndex = 3
        Me.grpDummy.TabStop = False
        Me.grpDummy.Text = "Add Dummy Columns"
        '
        'grdDummy
        '
        Me.grdDummy.AllowUserToAddRows = False
        Me.grdDummy.AllowUserToDeleteRows = False
        Me.grdDummy.AllowUserToResizeRows = False
        Me.grdDummy.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.grdDummy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDummy.EnableHeadersVisualStyles = False
        Me.grdDummy.Location = New System.Drawing.Point(4, 118)
        Me.grdDummy.Margin = New System.Windows.Forms.Padding(4)
        Me.grdDummy.Name = "grdDummy"
        Me.grdDummy.ReadOnly = True
        Me.grdDummy.RowHeadersVisible = False
        Me.grdDummy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdDummy.ShowEditingIcon = False
        Me.grdDummy.Size = New System.Drawing.Size(1245, 117)
        Me.grdDummy.TabIndex = 12
        '
        'cmbHPTVersion
        '
        Me.cmbHPTVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHPTVersion.FormattingEnabled = True
        Me.cmbHPTVersion.Location = New System.Drawing.Point(4, 85)
        Me.cmbHPTVersion.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbHPTVersion.Name = "cmbHPTVersion"
        Me.cmbHPTVersion.Size = New System.Drawing.Size(308, 28)
        Me.cmbHPTVersion.TabIndex = 18
        '
        'lblSoftWarn
        '
        Me.lblSoftWarn.AutoSize = True
        Me.lblSoftWarn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoftWarn.ForeColor = System.Drawing.Color.Red
        Me.lblSoftWarn.Location = New System.Drawing.Point(689, 82)
        Me.lblSoftWarn.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSoftWarn.Name = "lblSoftWarn"
        Me.lblSoftWarn.Size = New System.Drawing.Size(318, 20)
        Me.lblSoftWarn.TabIndex = 17
        Me.lblSoftWarn.Text = "Excessive Columns for HPT version 4.x"
        Me.lblSoftWarn.Visible = False
        '
        'lblCopiedDummy
        '
        Me.lblCopiedDummy.AutoSize = True
        Me.lblCopiedDummy.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopiedDummy.ForeColor = System.Drawing.Color.Green
        Me.lblCopiedDummy.Location = New System.Drawing.Point(969, 25)
        Me.lblCopiedDummy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCopiedDummy.Name = "lblCopiedDummy"
        Me.lblCopiedDummy.Size = New System.Drawing.Size(164, 20)
        Me.lblCopiedDummy.TabIndex = 15
        Me.lblCopiedDummy.Text = "Copied to clipboard"
        Me.lblCopiedDummy.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(319, 58)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(214, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "(adds a left and right column)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(692, 25)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Copy"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(319, 28)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(230, 20)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "(interpolates between columns)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(689, 55)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(352, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "(just in case you lost the originals in the Scanner)"
        '
        'lnkCopyDummyColumnHeaders
        '
        Me.lnkCopyDummyColumnHeaders.AutoSize = True
        Me.lnkCopyDummyColumnHeaders.Location = New System.Drawing.Point(789, 25)
        Me.lnkCopyDummyColumnHeaders.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lnkCopyDummyColumnHeaders.Name = "lnkCopyDummyColumnHeaders"
        Me.lnkCopyDummyColumnHeaders.Size = New System.Drawing.Size(128, 20)
        Me.lnkCopyDummyColumnHeaders.TabIndex = 12
        Me.lnkCopyDummyColumnHeaders.TabStop = True
        Me.lnkCopyDummyColumnHeaders.Text = "Column Headers"
        '
        'spinHzRange
        '
        Me.spinHzRange.Location = New System.Drawing.Point(237, 55)
        Me.spinHzRange.Margin = New System.Windows.Forms.Padding(4)
        Me.spinHzRange.Name = "spinHzRange"
        Me.spinHzRange.Size = New System.Drawing.Size(75, 26)
        Me.spinHzRange.TabIndex = 15
        '
        'spinDummyColumns
        '
        Me.spinDummyColumns.Location = New System.Drawing.Point(237, 25)
        Me.spinDummyColumns.Margin = New System.Windows.Forms.Padding(4)
        Me.spinDummyColumns.Name = "spinDummyColumns"
        Me.spinDummyColumns.Size = New System.Drawing.Size(75, 26)
        Me.spinDummyColumns.TabIndex = 14
        '
        'radHzRange
        '
        Me.radHzRange.AutoSize = True
        Me.radHzRange.Checked = True
        Me.radHzRange.Location = New System.Drawing.Point(4, 55)
        Me.radHzRange.Margin = New System.Windows.Forms.Padding(4)
        Me.radHzRange.Name = "radHzRange"
        Me.radHzRange.Size = New System.Drawing.Size(121, 24)
        Me.radHzRange.TabIndex = 13
        Me.radHzRange.TabStop = True
        Me.radHzRange.Text = "Hz Range +/-"
        Me.radHzRange.UseVisualStyleBackColor = True
        '
        'radColumns
        '
        Me.radColumns.AutoSize = True
        Me.radColumns.Location = New System.Drawing.Point(4, 24)
        Me.radColumns.Margin = New System.Windows.Forms.Padding(4)
        Me.radColumns.Name = "radColumns"
        Me.radColumns.Size = New System.Drawing.Size(152, 24)
        Me.radColumns.TabIndex = 12
        Me.radColumns.Text = "Columns to Insert"
        Me.radColumns.UseVisualStyleBackColor = True
        '
        'grpFinal
        '
        Me.grpFinal.Controls.Add(Me.grdFinal)
        Me.grpFinal.Controls.Add(Me.lblCopiedFinal)
        Me.grpFinal.Controls.Add(Me.Label10)
        Me.grpFinal.Controls.Add(Me.Label12)
        Me.grpFinal.Controls.Add(Me.Label6)
        Me.grpFinal.Controls.Add(Me.Label13)
        Me.grpFinal.Controls.Add(Me.lnkOutputFinal)
        Me.grpFinal.Controls.Add(Me.lnkInputExpanded)
        Me.grpFinal.Location = New System.Drawing.Point(4, 475)
        Me.grpFinal.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.grpFinal.Name = "grpFinal"
        Me.grpFinal.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.grpFinal.Size = New System.Drawing.Size(1253, 198)
        Me.grpFinal.TabIndex = 3
        Me.grpFinal.TabStop = False
        Me.grpFinal.Text = "Remove Dummy Columns"
        '
        'grdFinal
        '
        Me.grdFinal.AllowUserToAddRows = False
        Me.grdFinal.AllowUserToDeleteRows = False
        Me.grdFinal.AllowUserToResizeRows = False
        Me.grdFinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFinal.EnableHeadersVisualStyles = False
        Me.grdFinal.Location = New System.Drawing.Point(4, 75)
        Me.grdFinal.Margin = New System.Windows.Forms.Padding(4)
        Me.grdFinal.Name = "grdFinal"
        Me.grdFinal.ReadOnly = True
        Me.grdFinal.RowHeadersVisible = False
        Me.grdFinal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdFinal.ShowEditingIcon = False
        Me.grdFinal.Size = New System.Drawing.Size(1245, 117)
        Me.grdFinal.TabIndex = 19
        '
        'lblCopiedFinal
        '
        Me.lblCopiedFinal.AutoSize = True
        Me.lblCopiedFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopiedFinal.ForeColor = System.Drawing.Color.Green
        Me.lblCopiedFinal.Location = New System.Drawing.Point(969, 25)
        Me.lblCopiedFinal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCopiedFinal.Name = "lblCopiedFinal"
        Me.lblCopiedFinal.Size = New System.Drawing.Size(164, 20)
        Me.lblCopiedFinal.TabIndex = 22
        Me.lblCopiedFinal.Text = "Copied to clipboard"
        Me.lblCopiedFinal.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 50)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(352, 20)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "(just in case you lost the originals in the Scanner)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(692, 25)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 20)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Copy"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 24)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Paste"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(692, 50)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(363, 20)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "(use as Paste Special > Multiply by % in the Editor)"
        '
        'lnkOutputFinal
        '
        Me.lnkOutputFinal.AutoSize = True
        Me.lnkOutputFinal.Location = New System.Drawing.Point(789, 25)
        Me.lnkOutputFinal.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lnkOutputFinal.Name = "lnkOutputFinal"
        Me.lnkOutputFinal.Size = New System.Drawing.Size(134, 20)
        Me.lnkOutputFinal.TabIndex = 19
        Me.lnkOutputFinal.TabStop = True
        Me.lnkOutputFinal.Text = "New Percentages"
        '
        'lnkInputExpanded
        '
        Me.lnkInputExpanded.AutoSize = True
        Me.lnkInputExpanded.Location = New System.Drawing.Point(86, 24)
        Me.lnkInputExpanded.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lnkInputExpanded.Name = "lnkInputExpanded"
        Me.lnkInputExpanded.Size = New System.Drawing.Size(113, 20)
        Me.lnkInputExpanded.TabIndex = 12
        Me.lnkInputExpanded.TabStop = True
        Me.lnkInputExpanded.Text = "Table with Axis"
        '
        'ctxCopyColumnHeaders
        '
        Me.ctxCopyColumnHeaders.Name = "ctxCopyColumnHeaders"
        Me.ctxCopyColumnHeaders.Size = New System.Drawing.Size(212, 22)
        Me.ctxCopyColumnHeaders.Text = "Copy Column Headers"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(209, 6)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 676)
        Me.Controls.Add(Me.grpFinal)
        Me.Controls.Add(Me.grpDummy)
        Me.Controls.Add(Me.grpInput)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frmMain"
        Me.Text = "MAF Analyzer     [dankunkel@gmail.com]"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ctxDrillDown.ResumeLayout(False)
        Me.grpInput.ResumeLayout(False)
        Me.grpInput.PerformLayout()
        CType(Me.grdInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDummy.ResumeLayout(False)
        Me.grpDummy.PerformLayout()
        CType(Me.grdDummy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spinHzRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spinDummyColumns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFinal.ResumeLayout(False)
        Me.grpFinal.PerformLayout()
        CType(Me.grdFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuFileExit As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuHelpSupportBuyMeACoffee As ToolStripMenuItem
    Friend WithEvents mnuHelpSupportSendMeAPM As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuHelpHowToYoutubeVideoDemo As ToolStripMenuItem
    Friend WithEvents mnuHelpUseDynamicAir As ToolStripMenuItem
    Friend WithEvents mnuHelpManuallyCheckForNewerVersion As ToolStripMenuItem
    Friend WithEvents mnuHelpAbout As ToolStripMenuItem
    Friend WithEvents ctxDrillDown As ContextMenuStrip
    Friend WithEvents ctxGenerateFocusList25 As ToolStripMenuItem
    Friend WithEvents ctxGenerateFocusList50 As ToolStripMenuItem
    Friend WithEvents tmrCopied As Timer
    Friend WithEvents grpInput As GroupBox
    Friend WithEvents grpDummy As GroupBox
    Friend WithEvents grpFinal As GroupBox
    Friend WithEvents lnkInputTable As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lnkCopyDefaultColumnHeaders As LinkLabel
    Friend WithEvents lnkInputColumns As LinkLabel
    Friend WithEvents grdInput As DataGridView
    Friend WithEvents lblCopiedDefault As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblSoftWarn As Label
    Friend WithEvents lblCopiedDummy As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lnkCopyDummyColumnHeaders As LinkLabel
    Friend WithEvents spinHzRange As NumericUpDown
    Friend WithEvents spinDummyColumns As NumericUpDown
    Friend WithEvents radHzRange As RadioButton
    Friend WithEvents radColumns As RadioButton
    Friend WithEvents cmbHPTVersion As ComboBox
    Friend WithEvents grdDummy As DataGridView
    Friend WithEvents grdFinal As DataGridView
    Friend WithEvents lblCopiedFinal As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lnkOutputFinal As LinkLabel
    Friend WithEvents lnkInputExpanded As LinkLabel
    Friend WithEvents mnuFileClearStartOver As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ctxCopyColumnHeaders As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
End Class
