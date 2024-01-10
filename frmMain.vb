
Imports System.Runtime.CompilerServices.RuntimeHelpers

Public Class frmMain

    Dim FORM_LOADING As Boolean = True

    ' FORM EVENTS
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Me.Cursor = Cursors.WaitCursor

            ' will be used as as visual indicator that the send to clipboard was completed
            lnkCopyDefaultColumnHeaders.Tag = lblCopiedDefault
            lnkCopyDummyColumnHeaders.Tag = lblCopiedDummy
            lnkOutputFinal.Tag = lblCopiedFinal

            'double buffer grid for visual appeal
            grdInput.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, grdInput, New Object() {True})
            grdDummy.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, grdDummy, New Object() {True})
            grdFinal.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, grdFinal, New Object() {True})

            FillCombo()
            SetUserPrefs()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
            FORM_LOADING = False
        End Try
    End Sub

    Private Sub frmMain_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Try
            'save user preferences for next time
            My.Settings.Hz = radHzRange.Checked
            My.Settings.Hz_Range = spinHzRange.Value
            My.Settings.Cols = spinDummyColumns.Value
            My.Settings.HPT_Ver = cmbHPTVersion.SelectedValue

        Catch ex As Exception
            MsgBox("frmMain_Closed(): " * ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' manually set the width for the groupboxes and datagrids upon form resize. leave height alone.
        Try
            'me 1000, 466
            'grpInput 978, 120
            'grpDummy 978, 154
            'grpFinal 978, 120

            'grdInput 968, 67
            'grdDummy 968, 67
            'grdFinal 968, 67

            For Each cntrl In Me.Controls
                If TypeOf cntrl Is GroupBox Then
                    DirectCast(cntrl, GroupBox).Size = New Size(Me.Width - 22, DirectCast(cntrl, GroupBox).Size.Height)
                End If
            Next

            grdInput.Size = New Size(grpInput.Size.Width - 10, grdInput.Size.Height)
            grdDummy.Size = New Size(grpDummy.Size.Width - 10, grdDummy.Size.Height)
            grdFinal.Size = New Size(grpFinal.Size.Width - 10, grdFinal.Size.Height)

        Catch ex As Exception
            MsgBox("frmMain_Resize(): " * ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub mnuFileClearStartOver_Click(sender As Object, e As EventArgs) Handles mnuFileClearStartOver.Click
        Try
            grdInput.DataSource = Nothing
            grdDummy.DataSource = Nothing
            grdFinal.DataSource = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles mnuFileExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub mnuHelpSupportBuyMeACoffee_Click(sender As Object, e As EventArgs) Handles mnuHelpSupportBuyMeACoffee.Click
        Try
            'MsgBox("Paypal: dankunkel@gmail.com", MsgBoxStyle.Information, "Stay Golden Pony Boy")
            Dim objFrm As New frmPayPal
            objFrm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub mnuHelpSupportSendMeAPM_Click(sender As Object, e As EventArgs) Handles mnuHelpSupportSendMeAPM.Click
        Try
            Dim uri = "https://forum.hptuners.com/private.php?do=newpm&u=83494"
            Dim psi = New ProcessStartInfo With {
                                                 .UseShellExecute = True,
                                                 .FileName = uri
            }
            Process.Start(psi)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub mnuHelpHowToYoutubeVideoDemo_Click(sender As Object, e As EventArgs) Handles mnuHelpHowToYoutubeVideoDemo.Click
        Try
            Dim uri = "https://youtu.be/ccF7pv1B-Xg"
            Dim psi = New ProcessStartInfo With {
                                                 .UseShellExecute = True,
                                                 .FileName = uri
            }
            Process.Start(psi)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub mnuHelpUseDynamicAir_Click(sender As Object, e As EventArgs) Handles mnuHelpUseDynamicAir.Click
        Try
            Dim uri = "https://youtu.be/xRZaTblSQ_0"
            Dim psi = New ProcessStartInfo With {
                                                 .UseShellExecute = True,
                                                 .FileName = uri
            }
            Process.Start(psi)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub mnuHelpManuallyCheckForNewerVersion_Click(sender As Object, e As EventArgs) Handles mnuHelpManuallyCheckForNewerVersion.Click
        Try
            Dim uri = "https://drive.google.com/open?id=15olAwFXUWNzrb7bTbqhRGzLJ5k-Uvizv&authuser=dankunkel%40gmail.com&usp=drive_fs"
            Dim psi = New ProcessStartInfo With {
                                                 .UseShellExecute = True,
                                                 .FileName = uri
            }
            Process.Start(psi)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub mnuHelpAbout_Click(sender As Object, e As EventArgs) Handles mnuHelpAbout.Click
        Try
            MsgBox("MAF Assistant v1.0.",
                   MsgBoxStyle.Information,
                   "dankunkel@gmail.com")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub




    ' HOUSEKEEPING SUBS/FUNCTIONS
    Private Sub FillCombo()
        Dim DT_Ver As New DataTable
        Dim COL_Ver As DataColumn
        Dim ROW_Ver As DataRow

        COL_Ver = New DataColumn
        COL_Ver.DataType = System.Type.GetType("System.String")
        COL_Ver.ColumnName = "Display"
        DT_Ver.Columns.Add(COL_Ver)

        COL_Ver = New DataColumn
        COL_Ver.DataType = System.Type.GetType("System.Byte")
        COL_Ver.ColumnName = "Value"
        DT_Ver.Columns.Add(COL_Ver)

        ROW_Ver = DT_Ver.NewRow
        ROW_Ver("Value") = 4
        ROW_Ver("Display") = "HP Tuners version 4.x"
        DT_Ver.Rows.Add(ROW_Ver)

        ROW_Ver = DT_Ver.NewRow
        ROW_Ver("Value") = 5
        ROW_Ver("Display") = "HP Tuners version 5.x"
        DT_Ver.Rows.Add(ROW_Ver)

        ROW_Ver = DT_Ver.NewRow
        ROW_Ver("Value") = 0
        ROW_Ver("Display") = "< don't warn me bro, I am a pro >"
        DT_Ver.Rows.Add(ROW_Ver)

        cmbHPTVersion.DataSource = DT_Ver
        cmbHPTVersion.DisplayMember = "Display"
        cmbHPTVersion.ValueMember = "Value"
        cmbHPTVersion.SelectedIndex = 0
    End Sub

    Private Sub SetUserPrefs()
        ' attempt to set each preference individually
        ' if it fails, load a default value
        Try
            radHzRange.Checked = My.Settings.Hz
            radColumns.Checked = Not My.Settings.Hz
        Catch ex As Exception
            radHzRange.Checked = True
            radColumns.Checked = False
        End Try

        Try
            spinHzRange.Value = My.Settings.Hz_Range
        Catch ex As Exception
            spinHzRange.Value = 50
        End Try

        Try
            spinDummyColumns.Value = My.Settings.Cols
        Catch ex As Exception
            spinDummyColumns.Value = 2
        End Try

        Try
            cmbHPTVersion.SelectedValue = My.Settings.HPT_Ver
        Catch ex As Exception
            cmbHPTVersion.SelectedIndex = 0
        End Try
    End Sub

    Private Function MAF_ClipboardToDatatable() As DataTable
        ' --------------------------------------------------------------------------------------------
        ' GET DATA FROM CLIPBOARD
        ' --------------------------------------------------------------------------------------------
        Dim lines() As String = Clipboard.GetText().Split(vbLf)
        If lines.Length = 0 Then
            Return New DataTable
        End If
        ' --------------------------------------------------------------------------------------------


        ' --------------------------------------------------------------------------------------------
        ' ADD COLUMNS WITH NAMES
        ' --------------------------------------------------------------------------------------------
        Dim dt As New DataTable("ImportedTable")
        Dim cols() As String = lines(0).Split(vbTab)
        For i As Integer = 0 To cols.Length - 1
            dt.Columns.Add(cols(i).Replace(vbCrLf, "").Replace(vbCr, "").Replace(vbLf, "").Trim(), GetType(Object))
            dt.Columns(i).AllowDBNull = True
        Next
        ' --------------------------------------------------------------------------------------------


        ' --------------------------------------------------------------------------------------------
        ' ADD ROWS WITH DATA
        ' --------------------------------------------------------------------------------------------
        Dim rows(-1) As String
        Dim newRow As DataRow
        For i As Integer = 1 To lines.Length - 1
            lines(i) = lines(i).Replace(vbCrLf, "")
            lines(i) = lines(i).Replace(vbCr, "")
            lines(i) = lines(i).Replace(vbLf, "")
            If lines(i).Trim = "" Then
                Exit For
            End If
            rows = lines(i).Split(vbTab)
            newRow = dt.NewRow()
            For j As Integer = 0 To rows.Length - 1
                newRow(j) = rows(j)
            Next
            dt.Rows.Add(newRow)
        Next
        ' --------------------------------------------------------------------------------------------


        ' --------------------------------------------------------------------------------------------
        ' REMOVE ANY JUNK COLUMNS
        '   since we don't know if this was collected from: HPT Editor, HPT Scanner, Excel, etc
        ' --------------------------------------------------------------------------------------------
        For i As Integer = dt.Columns.Count - 1 To 0 Step -1
            If Not IsNumeric(dt.Columns(i).ColumnName) Then
                dt.Columns.RemoveAt(i)
            End If
        Next
        ' --------------------------------------------------------------------------------------------

        Return dt
    End Function

    Private Sub FindMaxDataTableValue(ByVal objDT As DataTable, ByRef intMax As Integer, ByRef intMin As Integer)
        ' iterate through every cell to determine the absolute min and max values
        ' we will need this information to apply the heatmap backcolors

        If objDT Is Nothing Then
            Exit Sub
        End If

        If objDT.Rows.Count = 0 Then
            Exit Sub
        End If

        If objDT.Columns.Count = 0 Then
            Exit Sub
        End If

        intMax = Integer.MinValue
        intMin = Integer.MaxValue
        Dim row(-1) As Object
        For i As Integer = 0 To objDT.Rows.Count - 1
            row = objDT.Rows(i).ItemArray
            For j As Integer = 0 To row.Length - 1
                If IsNumeric(row(j)) Then
                    If row(j) < intMin Then
                        intMin = row(j)
                    End If
                End If
            Next
            For k As Integer = row.Length - 1 To 0 Step -1
                If IsNumeric(row(k)) Then
                    If row(k) > intMax Then
                        intMax = row(k)
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub DatatableToClipboard(ByVal grd As DataGridView, ByVal IncludeHeaders As Boolean)
        If grd.GetClipboardContent IsNot Nothing Then

            If IncludeHeaders Then
                grd.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            Else
                grd.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
            End If

            Clipboard.SetDataObject(grd.GetClipboardContent)

            tmrCopied.Tag = lnkOutputFinal.Tag
            If tmrCopied.Tag IsNot Nothing Then
                If TypeOf tmrCopied.Tag Is Label Then
                    DirectCast(tmrCopied.Tag, Label).Visible = True
                End If
            End If
            tmrCopied.Enabled = True
        End If
    End Sub




    ' INPUT GRID
    Private Sub lnkInputTable_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkInputTable.LinkClicked
        Try
            Me.Cursor = Cursors.WaitCursor
            FORM_LOADING = True

            grdInput.DataSource = Nothing
            grdDummy.DataSource = Nothing
            grdFinal.DataSource = Nothing

            FORM_LOADING = False
            grdInput.DataSource = MAF_ClipboardToDatatable()

            CreateDummyColumns()
        Catch ex As Exception
            MsgBox("lnkInputTable_LinkClicked(): " & ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
            FORM_LOADING = False
        End Try
    End Sub

    Private Sub lnkInputColumns_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkInputColumns.LinkClicked
        Try
            Me.Cursor = Cursors.WaitCursor
            FORM_LOADING = True

            Dim lines() As String = Clipboard.GetText().Split(vbLf)
            Dim cols(-1) As String

            Dim DT_NEW As New DataTable("Columns Only")
            For i As Integer = 0 To lines.Length
                cols = lines(i).Replace(vbTab, " ").Split(" ")
                For j As Integer = 0 To cols.Length - 1
                    DT_NEW.Columns.Add(New DataColumn(cols(j).Replace(",", "").Replace(",", ""), GetType(Object)))
                Next
                Exit For
            Next

            FORM_LOADING = False
            grdInput.DataSource = DT_NEW

            CreateDummyColumns()

        Catch ex As Exception
            MsgBox("lnkInputColumns_LinkClicked(): " & ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
            FORM_LOADING = False
        End Try
    End Sub

    Private Sub lnkCopyDefaultColumnHeaders_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCopyDefaultColumnHeaders.LinkClicked
        Try
            Me.Cursor = Cursors.WaitCursor
            If grdInput.Columns.Count = 0 Then
                Exit Sub
            End If

            Dim DT_DEFAULT As DataTable = DirectCast(grdInput.DataSource, DataTable).Copy
            Dim COL_LIST As String = ""

            For Each col As DataColumn In DT_DEFAULT.Columns
                COL_LIST += col.ColumnName & " "
            Next
            COL_LIST = COL_LIST.Trim

            Clipboard.SetText(COL_LIST)

            tmrCopied.Tag = lnkCopyDefaultColumnHeaders.Tag
            If tmrCopied.Tag IsNot Nothing Then
                If TypeOf tmrCopied.Tag Is Label Then
                    DirectCast(tmrCopied.Tag, Label).Visible = True
                End If
            End If
            tmrCopied.Enabled = True


        Catch ex As Exception
            MsgBox("lnkCopyDummyColumnHeaders_LinkClicked(): " & ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub






    ' DUMMY SETUP
    Private Sub spinBox_KeyDown(sender As Object, e As KeyEventArgs) Handles spinHzRange.KeyDown, spinDummyColumns.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.Cursor = Cursors.WaitCursor
                CreateDummyColumns()
            End If
        Catch ex As Exception
            MsgBox("spinBox_KeyDown(): " & ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub spinBox_ValueChanged(sender As Object, e As EventArgs) Handles spinDummyColumns.ValueChanged, spinHzRange.ValueChanged
        Try
            If FORM_LOADING Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            CreateDummyColumns()

        Catch ex As Exception
            MsgBox("spinBox_ValueChanged(): " & ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub rad_CheckedChanged(sender As Object, e As EventArgs) Handles radColumns.CheckedChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            spinDummyColumns.Enabled = radColumns.Checked
            spinHzRange.Enabled = radHzRange.Checked

            CreateDummyColumns()

        Catch ex As Exception
            MsgBox("rad_CheckedChanged()" & ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CreateDummyColumns()
        FORM_LOADING = True

        Dim COLS_TO_ADD As Integer
        If radColumns.Checked Then
            COLS_TO_ADD = spinDummyColumns.Value
        Else
            COLS_TO_ADD = 2
        End If
        Dim RANGE As Integer
        If radHzRange.Checked Then
            RANGE = spinHzRange.Value
        Else
            RANGE = -99
        End If

        FORM_LOADING = True
        If grdInput.Columns.Count = 0 Then
            Exit Sub
        End If

        If COLS_TO_ADD = 0 And radColumns.Checked Then
            ' no changes: dummy grid = input grid
            ' save time and exit now
            FORM_LOADING = False
            grdDummy.DataSource = DirectCast(grdInput.DataSource, DataTable).Copy
            ValidateColumnLength(False, True)
            Exit Sub
        End If

        If RANGE = 0 And radHzRange.Checked Then
            ' no changes: dummy grid = input grid
            ' save time and exit now
            FORM_LOADING = False
            grdDummy.DataSource = DirectCast(grdInput.DataSource, DataTable).Copy
            ValidateColumnLength(False, True)
            Exit Sub
        End If

        Dim DT_NEW As New DataTable("Dummy")

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim DT_OLD As DataTable = DirectCast(grdInput.DataSource, DataTable).Copy
            If DT_OLD Is Nothing Then
                Exit Sub
            End If
            If DT_OLD.Columns.Count = 0 Then
                Exit Sub
            End If

            grdDummy.DataSource = Nothing
            grdFinal.DataSource = Nothing

            Dim COL As DataColumn
            Dim CURRENT_HZ As Object
            Dim NEXT_HZ As Object
            Dim INTERVAL_HZ As Integer
            Dim DUMMY_HZ As Integer
            Dim DUMMY_COLUMNS As Integer = CInt(COLS_TO_ADD) + 1

            For i As Integer = 0 To DT_OLD.Columns.Count - 1


                If radColumns.Checked Then ' user wants to add a specified number of columns

                    ' ------------------------------------------------
                    ' ADD THE CURRENT (DEFAULT) MAF HZ BREAKPOINT
                    ' ------------------------------------------------
                    CURRENT_HZ = DT_OLD.Columns(i).ColumnName
                    If Not IsNumeric(CURRENT_HZ) Then
                        Throw New Exception("Unable to add additional columns since at least one of them does not contain numerical data. " &
                                            "Please check/correct source data, specifically column labeled: [" & CURRENT_HZ.ToString & "]")
                    End If
                    COL = New DataColumn(CURRENT_HZ.ToString, GetType(Object))
                    DT_NEW.Columns.Add(COL)
                    ' ------------------------------------------------


                    ' ------------------------------------------------
                    ' IF THIS IS THE LAST COLUMN, THEN BREAKOUT. NO NEED TO ADD BEYOND THE FINAL HZ.
                    ' ------------------------------------------------
                    If i = DT_OLD.Columns.Count - 1 Then
                        Exit For
                    End If
                    ' ------------------------------------------------


                    ' ------------------------------------------------
                    ' IF WE DON'T HAVE VALID NUMERICAL DATA FOR A COLUMN HEADER,
                    ' THEN WE CANNOT INTERPOLATE ANYTHING.
                    ' ------------------------------------------------
                    NEXT_HZ = DT_OLD.Columns(i + 1).ColumnName
                    If Not IsNumeric(NEXT_HZ) Then
                        Throw New Exception("Unable to add additional columns since at least one of them does not contain numerical data. " &
                                            "Please check/correct source data, specifically column labeled: [" & NEXT_HZ.ToString & "]")
                    End If
                    ' ------------------------------------------------


                    ' ------------------------------------------------
                    ' INTERPOLATE THE COLUMN BREAKPOINTS FROM THE CURRENT DEFAULT COLUMN TO THE NEXT ONE ON THE RIGHT
                    ' ------------------------------------------------
                    INTERVAL_HZ = (NEXT_HZ - CURRENT_HZ) / DUMMY_COLUMNS
                    ' ------------------------------------------------



                    ' ------------------------------------------------
                    ' ADD THE NEW INTERMEDIATE HZ BREAKPOINTS TO THE RIGHT OF THE DEFAULT COLUMN
                    ' (BETWEEN THE CURRENT DEFAULT COLUMN AND THE NEXT DEFAULT COLUMN)
                    ' ------------------------------------------------
                    For j As Integer = 1 To DUMMY_COLUMNS - 1
                        DUMMY_HZ = CURRENT_HZ + (j * INTERVAL_HZ)

                        If DT_NEW.Columns.IndexOf(DUMMY_HZ.ToString) < 0 Then
                            COL = New DataColumn(DUMMY_HZ.ToString, GetType(Object))
                            DT_NEW.Columns.Add(COL)
                        End If

                    Next
                    ' ------------------------------------------------


                Else ' user wants to add left/right +/- columns

                    ' ------------------------------------------------
                    ' GET THE DEFAULT COLUMN
                    ' ------------------------------------------------
                    COL = New DataColumn(DT_OLD.Columns(i).ColumnName, GetType(Object))
                    ' ------------------------------------------------


                    ' ------------------------------------------------
                    ' ADD A COLUMN TO THE LEFT OF THE DEFAULT COLUMN
                    ' ------------------------------------------------
                    If i > 0 Then
                        If DT_NEW.Columns.IndexOf(CStr(CInt(COL.ColumnName) - RANGE)) < 0 Then
                            DT_NEW.Columns.Add(New DataColumn(CInt(COL.ColumnName) - RANGE, GetType(Object)))
                        End If
                    End If
                    ' ------------------------------------------------


                    ' ------------------------------------------------
                    ' ADD THE MIDDLE (DEFAULT) COLUMN
                    ' ------------------------------------------------
                    If DT_NEW.Columns.IndexOf(COL.ColumnName) < 0 Then
                        DT_NEW.Columns.Add(COL)
                    End If
                    ' ------------------------------------------------


                    ' ------------------------------------------------
                    ' ADD A COLUMN TO THE RIGHT OF THE DEFAULT COLUMN
                    ' ------------------------------------------------
                    If i < DT_OLD.Columns.Count - 1 Then
                        If DT_NEW.Columns.IndexOf(CStr(CInt(COL.ColumnName) + RANGE)) < 0 Then
                            DT_NEW.Columns.Add(New DataColumn(CInt(COL.ColumnName) + RANGE, GetType(Object)))
                        End If
                    End If
                End If
            Next

            ' ------------------------------------------------
            ' IF THE INPUT GRID HAS A DATAROW, WE WILL ADD THOSE VALUES TO THE DUMMY GRID
            '   we will have to search and harvest the values from the Dummy grid though
            ' ------------------------------------------------
            If DT_OLD.Rows.Count > 0 Then
                Dim COL_INDEX As Integer
                Dim ARR_ROW_DATA(DT_NEW.Columns.Count - 1) As Object
                For i As Integer = 0 To DT_NEW.Columns.Count - 1
                    COL_INDEX = DT_OLD.Columns.IndexOf(DT_NEW.Columns(i).ColumnName)
                    If COL_INDEX <> -1 Then
                        ARR_ROW_DATA(i) = DT_OLD.Rows(0).Item(COL_INDEX)
                    End If
                Next
                DT_NEW.Rows.Add(ARR_ROW_DATA)
            End If

            FORM_LOADING = False
            grdDummy.DataSource = DT_NEW
            ' ------------------------------------------------



            ' ------------------------------------------------
            ' CHECK FOR EXCESSIVE LENGTH
            '   for compatibility issues with HPT Scanner
            ' ------------------------------------------------
            ValidateColumnLength(False, True)
            ' ------------------------------------------------



        Catch ex As Exception
            MsgBox("AddDummyColumns(): " & ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
            FORM_LOADING = False
        End Try
    End Sub

    Private Sub lnkCopyDummyColumnHeaders_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCopyDummyColumnHeaders.LinkClicked
        Try
            Me.Cursor = Cursors.WaitCursor
            ValidateColumnLength(True, False)

        Catch ex As Exception
            MsgBox("lnkCopyDummyColumnHeaders_LinkClicked(): " & ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ValidateColumnLength(ByVal SEND_TO_CLIPBOARD As Boolean, ByVal SOFT_WARN_ONLY As Boolean)
        If grdDummy.Columns.Count = 0 Then
            Exit Sub
        End If

        ' ---------------------------------------------------------------------------------
        ' GENERATE THE AXIS PARAMETER LIST FOR HPT SCANNER
        ' ---------------------------------------------------------------------------------
        Dim DT_DUMMY As DataTable = DirectCast(grdDummy.DataSource, DataTable).Copy
        Dim COL_LIST As String = ""

        For Each col As DataColumn In DT_DUMMY.Columns
            COL_LIST += col.ColumnName & " "
        Next
        COL_LIST = COL_LIST.Trim
        ' ---------------------------------------------------------------------------------


        ' ---------------------------------------------------------------------------------
        ' WARN USER AS NECESSARY
        ' ---------------------------------------------------------------------------------
        Dim WARN As Boolean = False
        Dim LIST_LEN As Integer = COL_LIST.Length
        Dim COL_LEN As Integer = grdDummy.ColumnCount

        Dim LIST_LEN_MAX As Integer = 1024 'default v4.x
        Dim COL_LEN_MAX As Integer = 280 'Default v4.x

        If cmbHPTVersion.SelectedValue = 5 Then
            LIST_LEN_MAX = 2048 'default v5.x
            COL_LEN_MAX = 400 'default v5.x
        End If


        If LIST_LEN > LIST_LEN_MAX And cmbHPTVersion.SelectedValue <> 0 Then
            WARN = True
        End If
        If COL_LEN > COL_LEN_MAX And cmbHPTVersion.SelectedValue <> 0 Then
            WARN = True
        End If
        lblSoftWarn.Visible = WARN

        If WARN Then
            lblSoftWarn.Text = "Excessive Columns for " & cmbHPTVersion.Text

            If Not SOFT_WARN_ONLY Then
                Dim WARN_MESSAGE As String = ""
                WARN_MESSAGE = "Warning, you have a lot of columns, probably more than " & cmbHPTVersion.Text & " can handle" & vbCrLf
                WARN_MESSAGE += "     Column Count: " & COL_LEN & " (over " & COL_LEN_MAX & " columnns can lead to truncation)" & vbCrLf
                WARN_MESSAGE += "     Column List Length: " & LIST_LEN & " (over " & LIST_LEN_MAX & " characters can lead to truncation)" & vbCrLf
                WARN_MESSAGE += "HPT Version 5.x should be OK, but you need to verify all columns are present in the Scanner Histo"
                MsgBox(WARN_MESSAGE, MsgBoxStyle.Exclamation, "Too Much Data for " & cmbHPTVersion.Text)
            End If
        Else
            lblSoftWarn.Visible = False
        End If
        ' ---------------------------------------------------------------------------------


        ' ---------------------------------------------------------------------------------
        ' SEND TO CLIPBOARD
        ' ---------------------------------------------------------------------------------
        If SEND_TO_CLIPBOARD Then
            Clipboard.SetText(COL_LIST)

            tmrCopied.Tag = lnkCopyDummyColumnHeaders.Tag
            If tmrCopied.Tag IsNot Nothing Then
                If TypeOf tmrCopied.Tag Is Label Then
                    DirectCast(tmrCopied.Tag, Label).Visible = True
                End If
            End If
            tmrCopied.Enabled = True
        End If
        ' ---------------------------------------------------------------------------------

    End Sub

    Private Sub cmbHPTVersion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbHPTVersion.SelectedValueChanged
        Try
            If FORM_LOADING Then
                Exit Sub
            End If
            ValidateColumnLength(False, True)
        Catch ex As Exception
            MsgBox("cmbHPTVersion_SelectedValueChanged(): " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub grdDummy_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles grdDummy.ColumnAdded
        ' This event solves the error when adding a lot of columns...
        '       Exception: Sum of the columns' FillWeight values cannot exceed 65535.
        '
        'Source: https://social.msdn.microsoft.com/Forums/windows/en-US/327ff3e0-098c-4657-9af4-20d31fe5d6f0/sum-of-the-columns-fillweight-values-cannot-exceed-65535?forum=winformsdatacontrols
        '   There Is an easy solution that will allow up To 65, 535 columns in a DataGridView.
        '   In the Windows Forms "designer", click where you have positioned your DataGridView (named My_DataGridView in the example below),
        '   change the object properties view for My_DataGridView to show available events (the lightning symbol) And double click the item
        '   named ColumnAdded.  It will generate an empty ColumnAdded event in your code.  Then add the line e.Column.Fillweight = 1 as follows

        Try
            e.Column.FillWeight = 1
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable 'this shouldn't matter since we should only be dealing with one row...but better be safe
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub



    ' FINAL
    Private Sub lnkInputExpanded_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkInputExpanded.LinkClicked
        ' Take the data (with dummy columns) from HPT scanner
        ' strip out the dummy columns by comparing to the input grid
        Try
            Me.Cursor = Cursors.WaitCursor

            If grdInput.Columns.Count = 0 Then
                Exit Sub
            End If

            Dim DT_ORIG As DataTable = DirectCast(grdInput.DataSource, DataTable).Copy
            Dim DT_FINAL As DataTable = MAF_ClipboardToDatatable()
            If grdDummy.Columns.Count = 0 Then
                Exit Sub
            End If

            'Dim COL_NAME As String = ""
            'Dim INDX As Integer = -9

            For i As Integer = DT_FINAL.Columns.Count - 1 To 0 Step -1
                'COL_NAME = DT_FINAL.Columns(i).ColumnName
                'INDX = DT_ORIG.Columns.IndexOf(DT_FINAL.Columns(i).ColumnName)

                'If COL_NAME = "7650" Then
                '    MsgBox("attention")
                'End If

                If DT_ORIG.Columns.IndexOf(DT_FINAL.Columns(i).ColumnName) = -1 Then
                    DT_FINAL.Columns.RemoveAt(i)
                End If
            Next

            grdFinal.DataSource = DT_FINAL

        Catch ex As Exception
            MsgBox("lnkInputExpanded_LinkClicked(): " & ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub lnkOutputFinal_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkOutputFinal.LinkClicked
        ' get the row data so it can be paste special'd into HPT Editor's MAF table
        Try
            Me.Cursor = Cursors.WaitCursor
            grdFinal.SelectAll()
            DatatableToClipboard(grdFinal, False)

        Catch ex As Exception
            MsgBox("lnkOutputFinal_LinkClicked(): " & ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub







    ' GRID EVENT HELPERS
    Private Sub grd_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles grdInput.DataBindingComplete,
                                                                                                             grdDummy.DataBindingComplete,
                                                                                                             grdFinal.DataBindingComplete

        Try
            If FORM_LOADING Then
                Exit Sub
            End If


            Me.Cursor = Cursors.WaitCursor
            Dim grd As DataGridView = DirectCast(sender, DataGridView)
            PaintQuickColor(grd, True)
            grd.AutoResizeColumns()

            grpInput.Text = "Default MAF Columns: " & grdInput.Columns.Count
            grpDummy.Text = "Add Dummy Columns: " & grdDummy.Columns.Count
            grpFinal.Text = "Remove Dummy Columns: " & grdFinal.Columns.Count

        Catch ex As Exception
            MsgBox("grd_DataBindingComplete(): " & ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub PaintQuickColor(ByRef grd As DataGridView, ByVal bolNumbersWillBeAPercent As Boolean)
        ' add red/green color to the grid cells to indicate high/low values

        If grd Is Nothing Then
            Exit Sub
        End If
        If grd.Rows.Count = 0 Or grd.Columns.Count = 0 Then
            Exit Sub
        End If

        ' heatmap vars
        Dim decMin As Decimal = -5.0
        Dim decMax As Decimal = 5.0
        Dim decValue As Decimal = 0.0
        Dim decIntensity As Decimal = 0
        Dim decMid As Decimal = 0.0
        Dim decIntensityScale As Decimal = 5.0
        Dim decExtraIntensityFactor As Decimal = 1

        ' are we dealing with a histo or the full MAF table? let's find out...
        FindMaxDataTableValue(CType(grd.DataSource, DataTable), decMax, decMin)
        If decMax > 100 Then
            bolNumbersWillBeAPercent = False
        Else
            bolNumbersWillBeAPercent = True
        End If

        If bolNumbersWillBeAPercent Then
            decIntensityScale = 5.0
        Else
            decMid = (decMax + decMin) / 2
            decIntensityScale = decMid
        End If

        ' just in case, prevent any divide by zero errors
        If decIntensityScale = 0.0 Then
            decIntensityScale = 0.00001
        End If

        For i As Integer = 0 To grd.Rows.Count - 1
            For j As Integer = 0 To grd.Columns.Count - 1
                ' paint backcolor: heatmap 
                If IsNumeric(grd.Item(j, i).Value) Then

                    ' determine the intensity percent
                    decValue = CDec(grd.Item(j, i).Value)
                    decIntensity = Math.Abs(decValue - decMid) / Math.Abs(decIntensityScale)
                    decIntensity = 255 - (255 * decIntensity)

                    ' ensure we do not exceed the RGB color max/min (0-255)
                    If decIntensity > 255 Then
                        decIntensity = 255
                    End If
                    If decIntensity < 0 Then
                        decIntensity = 0
                    End If

                    ' apply backcolor to cell
                    If decValue < decMid Then
                        'rich/high values
                        grd.Rows(i).Cells.Item(j).Style.BackColor = Color.FromArgb(decIntensity, 255, decIntensity)
                    ElseIf decValue > decMid Then
                        'lean/low values
                        grd.Rows(i).Cells.Item(j).Style.BackColor = Color.FromArgb(255, decIntensity, decIntensity)
                    Else
                        grd.Rows(i).Cells.Item(j).Style.BackColor = Color.White
                    End If
                Else
                    grd.Rows(i).Cells.Item(j).Style.BackColor = Color.White
                End If
            Next
        Next
    End Sub

    Private Sub grd_Scroll(sender As Object, e As ScrollEventArgs) Handles grdFinal.Scroll
        ' link the scroll bars
        ' bottom grid controls the top two grids

        Try
            If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
                Exit Sub
            End If

            Try
                ' the input and final grids should be identical in terms of columns (number and names)
                grdInput.FirstDisplayedScrollingColumnIndex = grdFinal.FirstDisplayedScrollingColumnIndex
            Catch
            End Try

            Try
                ' the dummy grid will have a lot of extra columns, so we will have to search for
                ' the particular column of interest and scroll to it.
                Dim COL_NAME As String = grdInput.Columns(grdInput.FirstDisplayedScrollingColumnIndex).Name
                Dim INDX As Integer = 0
                For INDX = 0 To grdDummy.Columns.Count - 1
                    If grdDummy.Columns(INDX).Name = COL_NAME Then
                        Exit For
                    End If
                Next
                grdDummy.FirstDisplayedScrollingColumnIndex = INDX
            Catch
            End Try

        Catch ex As Exception
            MsgBox("grd_Scroll(): " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub



    Private Sub grd_MouseClick(sender As Object, e As MouseEventArgs) Handles grdInput.MouseClick,
                                                                              grdDummy.MouseClick,
                                                                              grdFinal.MouseClick
        Try


            Dim grd As DataGridView = DirectCast(sender, DataGridView)
            ctxCopyColumnHeaders.Tag = grd

            ctxDrillDown.Tag = Nothing

            Dim hit As DataGridView.HitTestInfo = grd.HitTest(e.Location.X, e.Location.Y)
            If hit.ColumnIndex = -1 Then
                Exit Sub
            End If

            If e.Button = MouseButtons.Right Then
                ctxDrillDown.Tag = grd.Columns(hit.ColumnIndex).Name

                Dim CURRENT As String = grd.Columns(hit.ColumnIndex).Name

                ctxGenerateFocusList25.Text = "Generate Focus List for: " & CURRENT & "Hz +/-" & ctxGenerateFocusList25.Tag.ToString
                ctxGenerateFocusList50.Text = "Generate Focus List for: " & CURRENT & "Hz +/-" & ctxGenerateFocusList50.Tag.ToString


                ' remove any previously add dynamic items
                If ctxDrillDown.Items.Count > 4 Then
                    For i As Integer = ctxDrillDown.Items.Count - 1 To 4 Step -1
                        ctxDrillDown.Items.RemoveAt(i)
                    Next
                End If

                ' add dynamic items to the list of options
                ctxDrillDown.Items.AddRange({New ToolStripSeparator()})
                Dim PREV_COL As String = ""
                Dim NEXT_COL As String = ""
                Dim INDX As Integer = ctxDrillDown.Items.Count - 1

                If hit.ColumnIndex > 0 Then
                    PREV_COL = grd.Columns(hit.ColumnIndex - 1).Name
                    ctxDrillDown.Items.Add("Generate Focus List for " & PREV_COL & " - " & CURRENT & " Hz")

                    INDX += 1
                    AddHandler ctxDrillDown.Items(INDX).Click, AddressOf GenerateFocusListLarge
                    ctxDrillDown.Items(INDX).Tag = PREV_COL & "|" & CURRENT
                End If

                If hit.ColumnIndex < grd.ColumnCount - 1 Then
                    NEXT_COL = grd.Columns(hit.ColumnIndex + 1).Name
                    ctxDrillDown.Items.Add("Generate Focus List for " & CURRENT & " - " & NEXT_COL & " Hz")

                    INDX += 1
                    AddHandler ctxDrillDown.Items(INDX).Click, AddressOf GenerateFocusListLarge
                    ctxDrillDown.Items(INDX).Tag = CURRENT & "|" & NEXT_COL
                End If

                If hit.ColumnIndex > 0 And hit.ColumnIndex < grd.ColumnCount - 1 Then
                    ctxDrillDown.Items.Add("Generate Focus List for " & PREV_COL & " - " & NEXT_COL & " Hz")

                    INDX += 1
                    AddHandler ctxDrillDown.Items(INDX).Click, AddressOf GenerateFocusListLarge
                    ctxDrillDown.Items(INDX).Tag = PREV_COL & "|" & NEXT_COL
                End If

                If grd.Rows.Count > 0 Then
                    grd.CurrentCell = grd(hit.ColumnIndex, 0)
                End If

                ctxDrillDown.Show(New System.Drawing.Point(MousePosition))
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ctxGenerateFocusList_Click(sender As Object, e As EventArgs) Handles ctxGenerateFocusList25.Click, ctxGenerateFocusList50.Click
        Try
            GenerateFocusList(ctxDrillDown.Tag, DirectCast(sender, ToolStripMenuItem).Tag)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub tmrCopied_Tick(sender As Object, e As EventArgs) Handles tmrCopied.Tick
        Try
            tmrCopied.Enabled = False
            If tmrCopied.Tag IsNot Nothing Then
                If TypeOf tmrCopied.Tag Is Label Then
                    DirectCast(tmrCopied.Tag, Label).Visible = False
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub





    'Private Sub Focus_Prev_Current()
    '    Dim HZ() As Object = ctxDrillDown.Tag.split("|")
    '    If HZ Is Nothing Then
    '        Exit Sub
    '    End If
    '    If HZ.Length = 2 Then
    '        GenerateLargerFocusList(HZ(0), HZ(1))
    '    End If
    'End Sub

    'Private Sub Focus_Current_Next()
    '    MsgBox("2")
    'End Sub

    'Private Sub Focus_Prev_Current_Next()
    '    MsgBox("3")
    'End Sub


    Private Sub GenerateFocusList(ByVal FOCUS_HZ As Object, ByVal RANGE As Object)
        Clipboard.Clear()
        If FOCUS_HZ = Nothing Then
            Exit Sub
        End If
        If Not IsNumeric(FOCUS_HZ) Then
            Exit Sub
        End If
        If RANGE = Nothing Then
            Exit Sub
        End If
        If Not IsNumeric(RANGE) Then
            Exit Sub
        End If

        FOCUS_HZ = Math.Abs(CInt(FOCUS_HZ))
        RANGE = Math.Abs(CInt(RANGE))

        Dim MIN As Integer = RANGE * -1
        Dim MAX As Integer = RANGE
        Dim INTERVAL As Integer = 1
        Dim LIST As String = ""
        Dim CURRENT As Integer = CInt(FOCUS_HZ)

        For i As Integer = MIN To MAX
            LIST += CURRENT + i & " "
        Next
        LIST = LIST.Trim

        Clipboard.SetText(LIST)
    End Sub

    Private Sub GenerateFocusListLarge(sender As Object, e As EventArgs)
        Clipboard.Clear()




        'Dim HZ() As Object = ctxDrillDown.Tag.split("|")
        Dim HZ() As Object = DirectCast(sender, ToolStripMenuItem).Tag.split("|")
        If HZ Is Nothing Then
            Exit Sub
        End If

        Dim MIN_HZ As Object
        Dim MAX_HZ As Object

        If HZ.Length = 2 Then
            MIN_HZ = HZ(0)
            MAX_HZ = HZ(1)
        Else
            Exit Sub
        End If


        If MIN_HZ = Nothing Then
            Exit Sub
        End If
        If Not IsNumeric(MIN_HZ) Then
            Exit Sub
        End If
        If MAX_HZ = Nothing Then
            Exit Sub
        End If
        If Not IsNumeric(MAX_HZ) Then
            Exit Sub
        End If

        If MIN_HZ > MAX_HZ Then
            Dim TMP_HZ As Object = MIN_HZ
            MIN_HZ = MAX_HZ
            MAX_HZ = TMP_HZ
        End If

        Dim LIST As String = ""
        'Dim CURRENT As Integer = CInt(MIN_HZ)

        For i As Integer = 0 To MAX_HZ - MIN_HZ
            'LIST += CURRENT + i & " "
            LIST += MIN_HZ + i & " "
        Next
        LIST = LIST.Trim

        Clipboard.SetText(LIST)

    End Sub

    Private Sub ctxCopyColumnHeaders_Click(sender As Object, e As EventArgs) Handles ctxCopyColumnHeaders.Click
        Try
            If ctxCopyColumnHeaders.Tag Is Nothing Then
                Exit Sub
            End If

            Dim DT As DataTable = DirectCast(DirectCast(ctxCopyColumnHeaders.Tag, DataGridView).DataSource, DataTable)
            Dim headers As String = ""
            For Each col As DataColumn In DT.Columns
                headers += col.ColumnName + " "
            Next

            Clipboard.SetText(headers.Trim)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class
