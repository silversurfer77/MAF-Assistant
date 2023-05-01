
Imports System.IO
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Runtime.Remoting
Imports System.Security.Cryptography
Imports VVE_Assistant.clsMath

Public Class clsLib

    Public Enum MERGE_TYPE
        Full
        PartialPaste
    End Enum

    Public Enum MERGE_MATH
        OVERWRITE
        AVERAGE
    End Enum

    Public Enum HowToAveragePartialHistoPaste
        AsNewTable
        EditLastTable
    End Enum

    Public Sub New()

    End Sub


    Public Shared ReadOnly Property CURRENT_EXE_DATE As DateTime
        Get
            'Return File.GetCreationTime(Assembly.GetExecutingAssembly().Location)

            Dim myApp As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
            Dim myEXEInfo As New IO.FileInfo(myApp.Location)
            Return myEXEInfo.LastWriteTime
        End Get
    End Property

    Public Shared ReadOnly Property CURRENT_DLL_DATE As DateTime
        Get
            Dim myApp As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
            Dim myEXEInfo As New IO.FileInfo(myApp.Location)
            Dim myDLLInfo As New IO.FileInfo(myEXEInfo.DirectoryName & "\Graph3D.dll")
            Return myDLLInfo.LastWriteTime
        End Get
    End Property



    ' FILE MANAGEMENT STUFF
    Public Shared Function CurrentDirectory() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & Application.ProductName & "\"
    End Function

    Public Shared Function GetZoneFileName() As String
        Dim ZONE_FILE_NAME As String = "ZoneInfo"
        Return ZONE_FILE_NAME
    End Function

    Private Shared Function SCHEMA_FILE_SUFFIX() As String
        Return "_Schema.XML"
    End Function

    Private Shared Function DATA_FILE_SUFFIX() As String
        Return "_Data.XML"
    End Function

    Private Shared Function HEADER_FILE_SUFFIX() As String
        Return "_Row_Headers.XML"
    End Function

    Public Shared Function SaveProject(ByVal SAVED_PROJECT_PATH As String, ByVal SAVED_PROJECT_NAME As String) As String
        Dim arrIllegalChar(8) As String
        arrIllegalChar(0) = "<"
        arrIllegalChar(1) = ">"
        arrIllegalChar(2) = ":"
        arrIllegalChar(3) = "/"
        arrIllegalChar(4) = "\"
        arrIllegalChar(5) = "|"
        arrIllegalChar(6) = "?"
        arrIllegalChar(7) = "*"
        arrIllegalChar(8) = Chr(34) ' double quote

        Dim NEW_PROJ_NAME As String = ""
        Dim ILLEGAL_FOUND As Boolean = False
        Dim OK As Boolean = False
        Do
            If SAVED_PROJECT_PATH <> "" Then
                Exit Do
            End If

            NEW_PROJ_NAME = InputBox("Please enter the Project Name (ex. Dan's 2014 SS):", "Input Project Name", NEW_PROJ_NAME)

            ' see if user canceled
            If NEW_PROJ_NAME.Trim = "" Then
                Return ""
            End If

            ' check for illegal chars in name
            For i As Integer = 0 To arrIllegalChar.Length - 1
                If InStr(NEW_PROJ_NAME, arrIllegalChar(i)) > 0 Then
                    MsgBox("Windows cannot save this name due to the illegal character: " & arrIllegalChar(i), MsgBoxStyle.Exclamation, "Pick a Different Project Name")
                    ILLEGAL_FOUND = True
                    Exit For
                End If
            Next

            ' determine if we need to keep looping
            If ILLEGAL_FOUND Then
                OK = False
                ILLEGAL_FOUND = False 'reset for the next iteration
            Else
                SAVED_PROJECT_NAME = NEW_PROJ_NAME
                'UpdateTitleBar()
                OK = True
            End If
        Loop Until OK

        ' create the full path to the project save directory
        If SAVED_PROJECT_PATH = "" Then
            Dim NEW_PROJECT As String = clsLib.CurrentDirectory
            If Strings.Right(NEW_PROJECT, 1) <> "\" Then
                NEW_PROJECT += "\"
            End If
            NEW_PROJECT += NEW_PROJ_NAME

            If IO.Directory.Exists(NEW_PROJECT) Then
                If MsgBox("A project with the name of [" & NEW_PROJ_NAME & "] already exists! Do you wish to overwrite it?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Overwrite?") = MsgBoxResult.No Then
                    Return ""
                End If
            End If

            SAVED_PROJECT_PATH = NEW_PROJECT
        End If

        If Strings.Right(SAVED_PROJECT_PATH, 1) <> "\" Then
            SAVED_PROJECT_PATH += "\"
        End If


        My.Settings.SavedProjectDirectory = SAVED_PROJECT_PATH
        My.Settings.SavedProjectName = SAVED_PROJECT_NAME

        ' delete any old files in the project dir, if they exist
        If IO.Directory.Exists(SAVED_PROJECT_PATH) Then
            Dim OLD_PROJECT_FILES() As String = IO.Directory.GetFiles(SAVED_PROJECT_PATH, "*.XML", SearchOption.TopDirectoryOnly)
            For i As Integer = 0 To OLD_PROJECT_FILES.Length - 1
                My.Computer.FileSystem.DeleteFile(OLD_PROJECT_FILES(i), FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
            Next
        End If

        ' if the project dir doesn't exist, create it
        If Not IO.Directory.Exists(SAVED_PROJECT_PATH) Then
            IO.Directory.CreateDirectory(SAVED_PROJECT_PATH)
        End If


        Dim fileInf As IO.FileInfo

        ' copy the files from the cache dir to the virgin project dir
        Dim CACHE_FILES() As String = IO.Directory.GetFiles(clsLib.CurrentDirectory, "*.XML", SearchOption.TopDirectoryOnly)
        For i As Integer = 0 To CACHE_FILES.Length - 1
            fileInf = New FileInfo(CACHE_FILES(i))

            My.Computer.FileSystem.CopyFile(CACHE_FILES(i), SAVED_PROJECT_PATH & fileInf.Name, True)
        Next

        'DIRTY_DATA = False
        Return NEW_PROJ_NAME
    End Function





    ' DATATABLE STUFF
    Public Shared Function ClipboardToDatatable(ByRef arrRowHeaders() As String) As DataTable
        ' THIS CODE ASSUMES YOU HAVE COPIED FROM HPT (EDITOR OR SCANNER) WITH COLUMN AXIS
        ' WORKS ON BOTH GEN4 AND GEN5 PLATFORMS


        ' --------------------------------------------------------------------------------------------
        ' GET DATA FROM CLIPBOARD
        ' --------------------------------------------------------------------------------------------
        Dim lines() As String = Clipboard.GetText().Split(vbLf)
        If lines.Length = 0 Then
            Return New DataTable
        End If
        ' --------------------------------------------------------------------------------------------


        ' --------------------------------------------------------------------------------------------
        ' ADD THE COLUMNS
        '   Start with the second data element, since the first one is the row header
        ' --------------------------------------------------------------------------------------------
        Dim dt As New DataTable("ImportedTable")
        Dim cols_original() As String = lines(0).Split(vbTab)
        Dim col_trimmed(-1) As String

        ' look for any misc column header labels (units like % or RPM) and remove them.
        ' we need to do this now so we can get an accurate column count for the .Columns.Add()
        For i As Integer = 0 To cols_original.Length - 1
            If IsNumeric(cols_original(i)) Then
                ReDim Preserve col_trimmed(col_trimmed.Length)
                col_trimmed(col_trimmed.Length - 1) = cols_original(i).Replace(vbCrLf, "").Replace(vbCr, "").Replace(vbLf, "").Trim()
            End If
        Next

        ' now that we have the 'distilled' list of column headers, we can add them to the datatable
        For i As Integer = 0 To col_trimmed.Length - 1
            dt.Columns.Add(col_trimmed(i), Type.GetType("System.Decimal")) 'using string since we can't have a nullable decimal in a datatable/grid
            dt.Columns(i).AllowDBNull = True
        Next
        ' --------------------------------------------------------------------------------------------


        ' --------------------------------------------------------------------------------------------
        ' ADD THE ROWS
        '   Start with the second data element since the first one is the columns which were already accounted for
        ' --------------------------------------------------------------------------------------------
        ReDim arrRowHeaders(-1)
        Dim rows(-1) As String
        Dim newRow As DataRow

        Dim ROW_HEADER_DECIMALS As String = ""

        For i As Integer = 1 To lines.Length - 1

            ' ingore the last vbCrLf or other artifact (it will cause array index out of bounds) or a blank/useless row
            If lines(i).Trim = vbCrLf Or lines(i).Trim = "" Or lines(i).Trim.ToLower = "kpa" Or lines(i).Trim.ToLower = "mpa" Or lines(i).Trim.ToLower = "rpm" Then
                Exit For
            End If

            ' the last CRLF will cause array index out of bounds, we don't need it, get rid of it
            lines(i) = lines(i).Replace(vbCrLf, "")
            lines(i) = lines(i).Replace(vbCr, "")
            lines(i) = lines(i).Replace(vbLf, "")


            rows = lines(i).Split(vbTab) 'raw data for the row
            newRow = dt.NewRow() 'create the row itself

            For j As Integer = 0 To rows.Length - 1

                ' ---------------------------------------------
                ' ENSURE WE NEVER GET AN ARROW INDEX OUT OF BOUNDS
                ' ---------------------------------------------
                If j > col_trimmed.Length Then
                    Exit For
                End If
                ' ---------------------------------------------

                ' ---------------------------------------------
                ' CREATE THE ROW HEADERS
                ' ---------------------------------------------
                If j = 0 Then
                    ' ON THE FIRST PASS, IF THE ROW HEADER IS NUMERIC, DETERMINE IF WE ARE DEALING WITH GEN4 OR GEN5 VVE TABLES
                    ' BY LOOKING AT THE FIRST DATA ELEMENT.
                    '   BELOW 1 = GEN4 = ONE DECIMAL
                    '   ELSE    = GEN4 = THREE DECIMALS
                    If j = 0 And ROW_HEADER_DECIMALS = "" And IsNumeric(rows(j)) Then
                        If CDec(rows(j)) > 100 Then
                            ' 2 bar OS (columns are RPM and rows are MAP), don't want decimals for RPMs
                            ROW_HEADER_DECIMALS = "F0"
                        ElseIf CDec(rows(j)) > 1.0 Then
                            ' Numeric Row Headers
                            ' You will hit this when importing: 
                            '    Histograms from the Scanner
                            '    VVE/Zones from the Editor
                            ROW_HEADER_DECIMALS = "F1"
                        Else
                            ' If the row header value is under 1.0, assume you are dealing with Gen5 format where the columns
                            ' are MAP/Baro ratios (.100 - 1.00)
                            ' dealing with Gen5 MAP/Baro ratio: ex .370
                            ROW_HEADER_DECIMALS = "F3"
                        End If
                    End If


                    ' ADD THE ROW HEADERS IN THE DESIRED FORMAT
                    ReDim Preserve arrRowHeaders(arrRowHeaders.Length)
                    If IsNumeric(rows(j)) Then

                        arrRowHeaders(arrRowHeaders.Length - 1) = Format(CDec(rows(j)), ROW_HEADER_DECIMALS)

                        'If CDec(rows(j)) > 1.0 Then
                        '    arrRowHeaders(arrRowHeaders.Length - 1) = Format(CDec(rows(j)), ROW_HEADER_DECIMALS)
                        'Else
                        '    arrRowHeaders(arrRowHeaders.Length - 1) = Format(CDec(rows(j)), ROW_HEADER_DECIMALS)
                        'End If
                    Else
                        ' String row headers
                        ' You will hit this when importing: 
                        '    Coefficients for VVE and Cam
                        arrRowHeaders(arrRowHeaders.Length - 1) = rows(j)
                    End If

                    Continue For
                End If
                ' ---------------------------------------------



                ' ---------------------------------------------
                ' ADD DATA TO THE ROW
                ' ---------------------------------------------
                ' we can now add anything with this property set, including nulls!
                '   dt.Columns(i).AllowDBNull = True
                If rows(j).Trim = "" Then
                    newRow(j - 1) = DBNull.Value
                Else
                    If InStr(rows(j), "E-") Then
                        ' scientific notation, this will cause problems later on in the pro mode when you try to save the coefficients.
                        ' convert them all to a full decimal format
                        newRow(j - 1) = Decimal.Parse(rows(j), System.Globalization.NumberStyles.Float)
                    Else
                        ' blindly add the decimal value
                        newRow(j - 1) = rows(j)
                    End If
                End If
                ' ---------------------------------------------

            Next

            ' ---------------------------------------------
            ' ADD THE ROW TO THE TABLE
            ' ---------------------------------------------
            dt.Rows.Add(newRow)
            ' ---------------------------------------------
        Next
        ' --------------------------------------------------------------------------------------------


        Return dt

    End Function

    Public Shared Function ReadDataTableFromFile(ByVal GRD_NAME As String) As DataTable

        Dim SCHEMA_FILE As String = CurrentDirectory() & GRD_NAME & SCHEMA_FILE_SUFFIX()
        Dim DATA_FILE As String = CurrentDirectory() & GRD_NAME & DATA_FILE_SUFFIX()


        Dim myDataTable As System.Data.DataTable = New System.Data.DataTable()
        If IO.File.Exists(SCHEMA_FILE) And IO.File.Exists(SCHEMA_FILE) Then
            myDataTable.ReadXmlSchema(SCHEMA_FILE)
            myDataTable.ReadXml(DATA_FILE)
        End If
        Return myDataTable
    End Function

    Public Shared Sub WriteDataTableToFile(ByVal DT As DataTable, ByVal GRD_NAME As String)
        If DT Is Nothing Then
            Exit Sub
        End If

        If DT.Rows.Count = 0 Then
            Exit Sub
        End If

        If Not IO.Directory.Exists(CurrentDirectory()) Then
            IO.Directory.CreateDirectory(CurrentDirectory())
        End If

        DeleteDataTableFile(GRD_NAME)

        If DT Is Nothing Then
            Exit Sub
        End If

        If DT.Rows.Count = 0 Then
            Exit Sub
        End If

        DT.WriteXmlSchema(CurrentDirectory() & GRD_NAME & SCHEMA_FILE_SUFFIX())
        DT.WriteXml(CurrentDirectory() & GRD_NAME & DATA_FILE_SUFFIX())
    End Sub

    Public Shared Sub DeleteDataTableFile(ByVal GRD_NAME As String)
        If Not IO.Directory.Exists(CurrentDirectory()) Then
            Exit Sub
        End If

        If IO.File.Exists(CurrentDirectory() & GRD_NAME & DATA_FILE_SUFFIX()) Then
            IO.File.Delete(CurrentDirectory() & GRD_NAME & DATA_FILE_SUFFIX())
        End If

        If IO.File.Exists(CurrentDirectory() & GRD_NAME & SCHEMA_FILE_SUFFIX()) Then
            IO.File.Delete(CurrentDirectory() & GRD_NAME & SCHEMA_FILE_SUFFIX())
        End If
    End Sub

    Public Shared Sub FindMaxDataTableValue(ByVal objDT As DataTable, ByRef intMax As Integer, ByRef intMin As Integer)
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

        ' better performance?
        ' putting each row into an array
        ' sorting array
        ' start at index 0 and going up to look for the smallest number that exists
        ' start at last index and going down to look for the largest number that exists
        ' this way we only do a partial iteration for each row/col, rather than iterating across all of them

        'Dim MIN_TEST As Object
        'Dim MAX_TEST As Object
        Dim row(-1) As Object

        For i As Integer = 0 To objDT.Rows.Count - 1
            row = objDT.Rows(i).ItemArray

            ' THIS ERRORS ON DBNULL!
            ' NEED TO FIX IT SO WE CAN ITERATE LESS (bring back the Exit For)
            'Array.Sort(row)
            For j As Integer = 0 To row.Length - 1
                If IsNumeric(row(j)) Then
                    If row(j) < intMin Then
                        intMin = row(j)
                        'Exit For
                    End If
                End If
            Next

            For k As Integer = row.Length - 1 To 0 Step -1
                If IsNumeric(row(k)) Then
                    If row(k) > intMax Then
                        intMax = row(k)
                        'Exit For
                    End If
                End If
            Next
        Next

    End Sub

    Public Shared Function DT_To_2D_Array(ByVal DT_IN As DataTable) As Integer(,)
        Dim VVE(DT_IN.Rows.Count - 1, DT_IN.Columns.Count - 1) As Integer

        For i As Integer = 0 To DT_IN.Rows.Count - 1
            For j As Integer = 0 To DT_IN.Columns.Count - 1

                If IsNumeric(DT_IN.Rows(i).Item(j)) Then
                    VVE(i, j) = CInt(DT_IN.Rows(i).Item(j))
                Else
                    VVE(i, j) = 0
                End If
            Next
        Next

        Return VVE
    End Function

    Public Shared Function Verify_DTs_Match(ByVal DT_OLD As DataTable, ByVal DT_NEW As DataTable, ByRef ERR_REASON As String) As Boolean
        If DT_OLD Is Nothing Then
            Return True
        End If

        If DT_NEW Is Nothing Then
            Return True
        End If

        Dim ROWHEADERS() As String = clsLib.ReadArrayFromFile(clsLib.GetZoneFileName)

        If ROWHEADERS.Length <> DT_NEW.Rows.Count Then
            ERR_REASON = "New table has more [rows] than are defined in the zone definition."
            Return False
        End If

        If Not DT_OLD.Rows.Count = DT_NEW.Rows.Count Then
            ERR_REASON = "New table has more [rows] than are defined in the zone definition."
            Return False
        End If

        If Not DT_OLD.Columns.Count = DT_NEW.Columns.Count Then
            ERR_REASON = "New table has more [columns] than are defined in the zone definition."
            Return False
        End If

        For i As Integer = 0 To DT_OLD.Columns.Count - 1
            If DT_OLD.Columns(i).ColumnName <> DT_NEW.Columns(i).ColumnName Then
                ERR_REASON = "New table has different [column axis] than are defined in the zone definition. Hint: make sure you copy axis from the Editor to the Scanner."
                Return False
            End If
        Next

        Return True
    End Function

    Public Shared Sub Add_DT_For_Histo_Merge(ByRef DT_Histos() As DataTable, ByVal DT_Add As DataTable)
        ReDim Preserve DT_Histos(DT_Histos.Length)
        DT_Histos(DT_Histos.Length - 1) = DT_Add
    End Sub

    Public Shared Sub Update_DT_For_Histo_Merge(ByRef DT_Histos() As DataTable, ByVal DT_NEW As DataTable)
        If DT_Histos Is Nothing Then
            ReDim DT_Histos(DT_Histos.Length)
        End If
        If DT_Histos.Length = 0 Then
            ReDim DT_Histos(DT_Histos.Length)
        End If
        DT_Histos(DT_Histos.Length - 1) = DT_NEW
    End Sub

    Public Shared Sub Clear_DT_For_Histo_Merge(ByRef DT_Histos() As DataTable)
        ' wipe out all datatables in the array
        ReDim DT_Histos(-1)
    End Sub

    Public Shared Sub DT_Manually_Edited(ByRef DT_Histos() As DataTable, ByVal DT_Edited As DataTable)
        ' user manually edited a datatable, update the last datatable in the array
        If DT_Histos Is Nothing Then
            Exit Sub
        End If
        If DT_Histos.Length = 0 Then
            Exit Sub
        End If

        DT_Histos(DT_Histos.Length - 1) = DT_Edited
    End Sub

    Public Shared Function MergeDatatables(ByVal DT_OLD As DataTable, ByVal DT_NEW As DataTable, ByVal MERGE_OP As MERGE_OPERATION) As DataTable
        If DT_OLD Is Nothing Then
            Throw New Exception("clsMath.MergeDatatables(): Could not find existing table.")
        End If
        If DT_OLD.Rows.Count <> DT_NEW.Rows.Count Then
            Throw New Exception("clsMath.MergeDatatables(): The tables do not seem to match based on rows.")
        End If

        If DT_OLD.Columns.Count <> DT_NEW.Columns.Count Then
            Throw New Exception("clsMath.MergeDatatables(): The tables do not seem to match based on columns.")
        End If

        Dim DT_Final As DataTable
        DT_Final = DT_OLD.Clone()
        Dim objRow As DataRow

        Dim decOld As Decimal? = Nothing
        Dim decNew As Decimal? = Nothing
        Dim decFinal As Decimal? = Nothing

        For i As Integer = 0 To DT_OLD.Rows.Count - 1
            objRow = DT_OLD.Rows(i)

            For j As Integer = 0 To DT_OLD.Columns.Count - 1
                decFinal = Nothing

                If Not DT_OLD.Rows(i).Item(j) Is DBNull.Value Then
                    decOld = DT_OLD.Rows(i).Item(j)
                Else
                    decOld = Nothing
                End If

                If Not DT_NEW.Rows(i).Item(j) Is DBNull.Value Then
                    decNew = DT_NEW.Rows(i).Item(j)
                Else
                    decNew = Nothing
                End If

                If MERGE_OP = MERGE_OPERATION.AVERAGE Then
                    'average

                    If decOld IsNot Nothing And decNew IsNot Nothing Then
                        decFinal = (decOld + decNew) / 2D
                        decFinal = decFinal

                    ElseIf decOld IsNot Nothing And decNew Is Nothing Then
                        decFinal = decOld

                    ElseIf decOld Is Nothing And decNew IsNot Nothing Then
                        decFinal = decNew
                    End If

                ElseIf MERGE_OP = MERGE_OPERATION.KEEP_OLD Then
                    ' keep old
                    If decOld IsNot Nothing Then
                        decFinal = decOld

                    ElseIf decNew IsNot Nothing Then
                        decFinal = decNew
                    End If

                ElseIf MERGE_OP = MERGE_OPERATION.KEEP_NEW Then
                    ' use new

                    If decNew IsNot Nothing Then
                        decFinal = decNew

                    ElseIf decOld IsNot Nothing Then
                        decFinal = decOld
                    End If
                End If


                objRow(j) = IIf(decFinal.HasValue, decFinal, DBNull.Value)
            Next
            DT_Final.ImportRow(objRow)
        Next

        Return DT_Final
    End Function

    Public Shared Function Compute_Average_DT(ByVal DT() As DataTable) As DataTable
        If DT Is Nothing Then
            Return Nothing
        End If
        If DT.Length = 0 Then
            Return Nothing
        End If
        If DT.Length = 1 Then
            Return DT(0)
        End If

        Dim DT_AVE As DataTable = DT(0).Clone

        For Each col As DataColumn In DT_AVE.Columns
            col.AllowDBNull = True
        Next

        Dim ARR_COLS(DT(0).Columns.Count - 1) As Object
        Dim RUNNING_TOTAL As Decimal = 0.0
        Dim COUNT As Integer = 0
        Dim FOUND As Boolean = False

        For i As Integer = 0 To DT(0).Rows.Count - 1

            ' this is slow...and not needed due to the IF FOUND statement
            'ReDim ARR_COLS(DT(0).Columns.Count - 1)

            For j As Integer = 0 To DT(0).Columns.Count - 1
                FOUND = False
                COUNT = 0
                RUNNING_TOTAL = 0.0
                For k As Integer = 0 To DT.Length - 1
                    If IsNumeric(Get_DT_Value(DT(k), i, j)) Then
                        FOUND = True
                        COUNT += 1
                        RUNNING_TOTAL += Get_DT_Value(DT(k), i, j)
                    End If
                Next

                If FOUND Then
                    ARR_COLS(j) = RUNNING_TOTAL / COUNT
                Else
                    ARR_COLS(j) = DBNull.Value
                End If
            Next

            DT_AVE.Rows.Add(ARR_COLS)
        Next


        Return DT_AVE
    End Function

    Private Shared Function Get_DT_Value(ByVal DT_IN As DataTable, ByVal ROW As Integer, ByVal COL As Integer) As Object
        Try
            Return CDec(DT_IN.Rows(ROW).Item(COL))
        Catch ex As Exception
            Return DBNull.Value
        End Try
    End Function

    Public Shared Function CreatePartialDatatable(ByVal grd As DataGridView, ByVal INIT_ROW As Integer, INIT_COL As Integer) As DataTable
        ' call when a user wants to paste in part of a histrogram in place to an existing histogram.
        ' as opposed to pasting in the entire table with row and column headers

        Dim DT_SOURCE As DataTable = DirectCast(grd.DataSource, DataTable)
        If DT_SOURCE Is Nothing Then
            Return New DataTable
        End If
        If DT_SOURCE.Rows.Count = 0 Then
            Return New DataTable
        End If
        If DT_SOURCE.Columns.Count = 0 Then
            Return New DataTable
        End If

        ' create a replica of the source datatable, complete with empty rows and columns
        Dim DT_NEW As DataTable = DT_SOURCE.Clone
        Dim COL_DUMMY(DT_SOURCE.Columns.Count - 1) As Object
        For i As Integer = 0 To DT_SOURCE.Rows.Count - 1
            DT_NEW.Rows.Add(COL_DUMMY)
        Next

        Dim lines() As String = Clipboard.GetText().Split(vbLf)
        Dim cells(-1) As String
        Dim value As Object = Nothing
        For i As Integer = 0 To lines.Length - 1
            cells = lines(i).Split(vbTab)
            For j As Integer = 0 To cells.Length - 1
                value = cells(j)
                If IsNumeric(cells(j)) Then
                    DT_NEW.Rows(INIT_ROW + i).Item(INIT_COL + j) = CDec(value)
                Else
                    DT_NEW.Rows(INIT_ROW + i).Item(INIT_COL + j) = DBNull.Value
                End If
            Next
        Next

        Return DT_NEW
    End Function


    Public Shared Function AveragePartialDatatable(ByVal DT_Histos() As DataTable, ByVal INIT_ROW As Integer, INIT_COL As Integer, ByVal HowToImport As HowToAveragePartialHistoPaste) As DataTable
        If DT_Histos Is Nothing Then
            Return New DataTable("ImportedTable")
        End If
        If DT_Histos.Length = 0 Then
            Return New DataTable("ImportedTable")
        ElseIf DT_Histos.Length = 1 Then
            If DT_Histos(0) Is Nothing Then
                Return New DataTable("ImportedTable")
            End If
        End If

        Dim DT_New As DataTable = DT_Histos(0).Clone
        DT_New = DT_Histos(0).Copy()



        Dim lines() As String = Clipboard.GetText().Split(vbLf)
        Dim cells(-1) As String
        For i As Integer = 0 To lines.Length - 1
            If INIT_ROW + i > DT_Histos(0).Rows.Count - 1 Then
                Continue For
            End If
            DT_New.Rows.Add(DT_New.NewRow())

            cells = lines(i).Split(vbTab)
            For j As Integer = 0 To cells.Length - 1

                If INIT_COL + j > DT_Histos(0).Columns.Count - 1 Then
                    Continue For
                End If

                If IsNumeric(cells(j)) Then
                    DT_New.Rows(INIT_ROW + i).Item(INIT_COL + j) = CDec(cells(j))
                Else
                    '   leave this NULL so it doesn't skew the average or overwrite any values
                    DT_New.Rows(INIT_ROW + i).Item(INIT_COL + j) = DBNull.Value
                End If
            Next
        Next

        If HowToImport = HowToAveragePartialHistoPaste.AsNewTable Then
            'treat this is a new and complete seperate table
            Add_DT_For_Histo_Merge(DT_Histos, DT_New)
        Else
            'treat this as an edit of the last table imported
            DT_Manually_Edited(DT_Histos, DT_New)
        End If

        ' recalculate the average
        Return Compute_Average_DT(DT_Histos)
    End Function











    ' ROW HEADER STUFF
    Public Shared Sub WriteArrayToFile(ByVal ARR As String(), ByVal GRD_NAME As String)
        If Not IO.Directory.Exists(CurrentDirectory()) Then
            IO.Directory.CreateDirectory(CurrentDirectory())
        End If

        If IO.File.Exists(CurrentDirectory() & GRD_NAME & HEADER_FILE_SUFFIX()) Then
            IO.File.Delete(CurrentDirectory() & GRD_NAME & HEADER_FILE_SUFFIX())
        End If

        IO.File.WriteAllLines(CurrentDirectory() & GRD_NAME & HEADER_FILE_SUFFIX(), ARR)
    End Sub

    Public Shared Function ReadArrayFromFile(ByVal GRD_NAME As String) As String()
        If IO.File.Exists(CurrentDirectory() & GRD_NAME & HEADER_FILE_SUFFIX()) Then
            Dim arrMAP() As String = IO.File.ReadAllLines(CurrentDirectory() & GRD_NAME & HEADER_FILE_SUFFIX())
            Return arrMAP
        Else
            Return {}
        End If
    End Function

    Public Shared Function Verify_Row_Headers(ByVal OLD_HEADERS() As String, ByVal NEW_HEAEDERS() As String, Optional ByRef ARE_THEY_THE_SAME As Boolean = False) As String()

        If Not OLD_HEADERS.Length = NEW_HEAEDERS.Length Then
            ARE_THEY_THE_SAME = False
            Return NEW_HEAEDERS
        End If

        For i As Integer = 0 To OLD_HEADERS.Length - 1
            If OLD_HEADERS(i) <> NEW_HEAEDERS(i) Then
                ARE_THEY_THE_SAME = False
                Return NEW_HEAEDERS
            End If
        Next

        ARE_THEY_THE_SAME = True
        Return OLD_HEADERS
    End Function



    ' GRID STUFF
    Public Shared Sub AddRowHeaderLabels(ByVal GRD As DataGridView, ByVal ROW_HEADERS As String())

        If ROW_HEADERS Is Nothing Then
            Exit Sub
        End If

        If ROW_HEADERS.Length = 0 Then
            Exit Sub
        End If

        If GRD.Rows.Count = 0 Then
            Exit Sub
        End If

        For i As Integer = 0 To GRD.Rows.Count - 1
            If i <= ROW_HEADERS.Length - 1 Then
                GRD.Rows(i).HeaderCell.Value = ROW_HEADERS(i)
            End If
        Next

        AutoSizeGridColumns(GRD)
    End Sub

    Public Shared Sub AutoSizeGridColumns(ByVal GRD As DataGridView)
        GRD.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
        GRD.AutoResizeColumns()
    End Sub

    Public Shared Sub GridDecimalFormat(ByRef GRD As DataGridView, ByVal DECIMAL_PLACES As Integer)
        If GRD.ColumnCount = 0 Then
            Exit Sub
        End If

        Dim FORMAT_STRING As String = ""

        If DECIMAL_PLACES < 0 Then
            FORMAT_STRING = "" 'no format/raw data
        ElseIf DECIMAL_PLACES = 0 Then
            'FORMAT_STRING = "#" ' if the number is zero, this will suppress it from displaying (make it appear blank)
            FORMAT_STRING = "0" ' this will display one digit at least (so a zero will be zero, not blank)
        ElseIf DECIMAL_PLACES > 0 Then
            FORMAT_STRING = "0." & FORMAT_STRING.PadRight(DECIMAL_PLACES, "0"c)
        End If

        If GRD.Columns(0).DefaultCellStyle.Format = FORMAT_STRING Then
            Exit Sub
        End If

        ' SPEED UP APPLYING DECIMALS!!!
        ' remove all data, but clone the columns so the format can be applied, then re-apply the datasource
        Dim DT As DataTable = DirectCast(GRD.DataSource, DataTable)
        GRD.DataSource = Nothing
        GRD.DataSource = DT.Clone
        For i As Integer = 0 To GRD.ColumnCount - 1
            GRD.Columns(i).DefaultCellStyle.Format = FORMAT_STRING
        Next
        GRD.DataSource = DT
    End Sub

    Public Shared Sub PreventGridSort(ByVal grd As DataGridView)
        For Each objCol As DataGridViewColumn In grd.Columns
            objCol.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Public Shared Sub DoubleBufferGrids(ByVal grd As DataGridView)
        ' enable doublebuffering of datagrids. without this, painting with zones is super slow!
        ' https://stackoverflow.com/questions/118528/horrible-redraw-performance-of-the-datagridview-on-one-of-my-two-screens

        grd.GetType.InvokeMember("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, grd, New Object() {True})
    End Sub

    Public Shared Sub CopySelectedCellsOnly(ByVal dgv As DataGridView, ByVal IncludeHeaders As Boolean)
        If dgv.GetClipboardContent IsNot Nothing Then

            If IncludeHeaders Then
                dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            Else
                dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
            End If


            'dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
            Clipboard.SetDataObject(dgv.GetClipboardContent)
        End If
    End Sub

    Public Shared Function GetRowBasedOnHeaderLabel(ByVal grd As DataGridView, ByVal strHeaderLabel As String) As Integer

        ' first and most likely option, read the row header labels directly from the grid
        For i As Integer = 0 To grd.Rows.Count - 1
            If grd.Rows(i).HeaderCell.Value IsNot Nothing Then
                If grd.Rows(i).HeaderCell.Value.ToString = strHeaderLabel Then
                    'MsgBox(strHeaderLabel & " is row " & i)
                    Return i
                End If
            End If
        Next

        ' second option, check the grid.tag field to see if they were set but not displayed
        Dim arrTag() As String = DirectCast(grd.Tag, String())
        For i As Integer = 0 To arrTag.Length - 1
            If arrTag(i) IsNot Nothing Then
                If arrTag(i) = strHeaderLabel Then
                    Return i
                End If
            End If
        Next

        Return -1
    End Function







    ' GRID COLORING STUFF
    Private Shared Function GetZoneColor(ByVal intZoneNumber As Integer) As Color
        ' there are 5 columns, columns 1,3,5 get two unique alternating colors,
        ' columns 2,4 get their own unique alternating colors.
        If intZoneNumber <= 5 Or (intZoneNumber >= 12 And intZoneNumber <= 17) Or intZoneNumber >= 24 Then
            If intZoneNumber Mod 2 = 0 Then
                'blue
                Return Color.FromArgb(200, 255, 255)
            Else
                'green
                Return Color.FromArgb(200, 255, 200)
            End If
        Else
            If intZoneNumber Mod 2 = 0 Then
                'red
                Return Color.FromArgb(255, 200, 200)
            Else
                'yellow
                Return Color.FromArgb(255, 255, 200)
            End If
        End If
    End Function

    Public Shared Sub ChangeSingleCellColor(ByVal grd As DataGridView, ROW As Integer, COL As Integer, COLOR As Drawing.Color)
        If grd Is Nothing Then
            Exit Sub
        End If
        If grd.Rows.Count = 0 Or grd.Columns.Count = 0 Then
            Exit Sub
        End If
        grd.Rows(ROW).Cells.Item(COL).Style.BackColor = COLOR
    End Sub

    Public Shared Sub PaintQuickColor(ByRef grd As DataGridView, ByVal bolNumbersWillBeAPercent As Boolean)
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

        If bolNumbersWillBeAPercent Then
            decIntensityScale = 5.0
        Else
            FindMaxDataTableValue(CType(grd.DataSource, DataTable), decMax, decMin)

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

                        If My.Settings.HistoLow = System.Drawing.Color.Red Then
                            grd.Rows(i).Cells.Item(j).Style.BackColor = Color.FromArgb(255, decIntensity, decIntensity)

                        ElseIf My.Settings.HistoLow = System.Drawing.Color.Green Then
                            grd.Rows(i).Cells.Item(j).Style.BackColor = Color.FromArgb(decIntensity, 255, decIntensity)

                        ElseIf My.Settings.HistoLow = System.Drawing.Color.Blue Then
                            grd.Rows(i).Cells.Item(j).Style.BackColor = Color.FromArgb(decIntensity, decIntensity, 255)

                        ElseIf My.Settings.HistoLow = System.Drawing.Color.White Then
                            grd.Rows(i).Cells.Item(j).Style.BackColor = Color.FromArgb(255, 255, 255)
                        End If

                    ElseIf decValue > decMid Then
                        'lean/low values

                        If My.Settings.HistoHigh = System.Drawing.Color.Red Then
                            grd.Rows(i).Cells.Item(j).Style.BackColor = Color.FromArgb(255, decIntensity, decIntensity)

                        ElseIf My.Settings.HistoHigh = System.Drawing.Color.Green Then
                            grd.Rows(i).Cells.Item(j).Style.BackColor = Color.FromArgb(decIntensity, 255, decIntensity)

                        ElseIf My.Settings.HistoHigh = System.Drawing.Color.Blue Then
                            grd.Rows(i).Cells.Item(j).Style.BackColor = Color.FromArgb(decIntensity, decIntensity, 255)

                        ElseIf My.Settings.HistoHigh = System.Drawing.Color.White Then
                            grd.Rows(i).Cells.Item(j).Style.BackColor = Color.FromArgb(255, 255, 255)
                        End If

                    Else
                        grd.Rows(i).Cells.Item(j).Style.BackColor = Color.White
                    End If
                Else
                    grd.Rows(i).Cells.Item(j).Style.BackColor = Color.White
                End If
            Next
        Next
    End Sub

    Public Shared Function PaintGridZonesAndHeatmap(ByVal grd As DataGridView, ByVal objDT_All_Zones As DataTable,
                                                    ByVal intZoneNumber As Integer, ByRef intBookmarkRow As Integer,
                                                    ByRef intBookmarkCol As Integer, ByVal bolPaintZoneColor As Boolean,
                                                    ByVal bolNumbersWillBeAPercent As Boolean) As Rectangle()

        If grd Is Nothing Then
            Return Nothing
        End If
        If grd.Rows.Count = 0 Or grd.Columns.Count = 0 Then
            Return Nothing
        End If

        If objDT_All_Zones Is Nothing Then
            Return Nothing
        End If

        ' zone line vars
        Dim intLeftCol As Integer = -1
        Dim intTopRow As Integer = -1
        Dim bolFound As Boolean = False
        Dim arrRect(2) As Rectangle

        ' heatmap vars
        Dim decMin As Decimal = -5.0
        Dim decMax As Decimal = 5.0
        Dim decValue As Decimal = 0.0
        Dim decIntensity As Decimal = 0
        Dim decMid As Decimal = 0.0
        Dim decIntensityScale As Decimal = 5.0

        'If grd.Name = "grdHisto" Or grd.Name = "grdVVEPasteSpecial" Then
        '    'bolHeatmapGrid = True
        'End If

        If grd.Name = "grdVVEOld" Or grd.Name = "grdVVENew" Or grd.Name = "grdVVEDelta" Then
            bolNumbersWillBeAPercent = False
        End If


        ' we we are doing a heatmap using literal values (not the percent)
        ' we need to do some research to find the total range of values to
        ' apply the correct color intensity
        If Not bolPaintZoneColor Then 'And bolHeatmapGrid Then
            ' only hit this if doing a heatmap with literal values (not percent)
            FindMaxDataTableValue(CType(grd.DataSource, DataTable), decMax, decMin)

            ' think of this value as the high/low values for color assignment in the VCM scanner
            ' when using rich/lean % we will hardcode a value of +/- 5
            ' otherwise for regular values (as if you are looking at the VVE editor in VCM editor)
            ' we just need to find the midpoint of all the values
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
        End If



        ' 1) search for left-most column and top-most row as a starting point
        ' i removed the exit for statements because i decided to move the cellbackcolor painting here (since it will save time by preventing us from having to
        ' iterate through all the cells again at a different time), however, this means we need to iterate over it all, so no early exiting
        bolFound = False
        For i As Integer = intBookmarkCol To objDT_All_Zones.Columns.Count - 1
            For j As Integer = intBookmarkRow To objDT_All_Zones.Rows.Count - 1
                If CInt(objDT_All_Zones.Rows(j).Item(i)) = intZoneNumber Then
                    If Not bolFound Then
                        intLeftCol = i
                        intTopRow = j

                        bolFound = True
                    End If

                    If bolPaintZoneColor Then
                        ' paint backcolor: zone boundaries
                        grd.Rows(j).Cells.Item(i).Style.BackColor = GetZoneColor(CInt(objDT_All_Zones.Rows(j).Item(i)))
                    Else
                        ' paint backcolor: heatmap 
                        If IsNumeric(grd.Item(i, j).Value) Then 'And bolHeatmapGrid Then

                            ' determine the intensity percent
                            decValue = CDec(grd.Item(i, j).Value)
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
                                If My.Settings.HistoLow = System.Drawing.Color.Red Then
                                    grd.Rows(j).Cells.Item(i).Style.BackColor = Color.FromArgb(255, decIntensity, decIntensity)

                                ElseIf My.Settings.HistoLow = System.Drawing.Color.Green Then
                                    grd.Rows(j).Cells.Item(i).Style.BackColor = Color.FromArgb(decIntensity, 255, decIntensity)

                                ElseIf My.Settings.HistoLow = System.Drawing.Color.Blue Then
                                    grd.Rows(j).Cells.Item(i).Style.BackColor = Color.FromArgb(decIntensity, decIntensity, 255)

                                ElseIf My.Settings.HistoLow = System.Drawing.Color.White Then
                                    grd.Rows(j).Cells.Item(i).Style.BackColor = Color.FromArgb(255, 255, 255)
                                End If


                            ElseIf decValue > decMid Then
                                'lean/low values
                                If My.Settings.HistoHigh = System.Drawing.Color.Red Then
                                    grd.Rows(j).Cells.Item(i).Style.BackColor = Color.FromArgb(255, decIntensity, decIntensity)

                                ElseIf My.Settings.HistoHigh = System.Drawing.Color.Green Then
                                    grd.Rows(j).Cells.Item(i).Style.BackColor = Color.FromArgb(decIntensity, 255, decIntensity)

                                ElseIf My.Settings.HistoHigh = System.Drawing.Color.Blue Then
                                    grd.Rows(j).Cells.Item(i).Style.BackColor = Color.FromArgb(decIntensity, decIntensity, 255)

                                ElseIf My.Settings.HistoHigh = System.Drawing.Color.White Then
                                    grd.Rows(j).Cells.Item(i).Style.BackColor = Color.FromArgb(255, 255, 255)
                                End If

                            Else
                                grd.Rows(j).Cells.Item(i).Style.BackColor = Color.White
                            End If

                        Else
                            grd.Rows(j).Cells.Item(i).Style.BackColor = Color.White
                        End If
                    End If
                End If
            Next
        Next
        arrRect(0) = grd.GetCellDisplayRectangle(intLeftCol, intTopRow, True)
        'arrRect(0) = grd.GetCellDisplayRectangle(intLeftCol, intTopRow, False)


        ' 2) search for right-most column
        Dim intRightCol As Integer = -1
        bolFound = False
        For i As Integer = intLeftCol + 1 To objDT_All_Zones.Columns.Count - 1
            If CInt(objDT_All_Zones.Rows(intTopRow).Item(i)) <> intZoneNumber Then
                bolFound = True
                intRightCol = i - 1
                Exit For
            End If
        Next
        If Not bolFound Then
            intRightCol = objDT_All_Zones.Columns.Count - 1
        End If
        arrRect(1) = grd.GetCellDisplayRectangle(intRightCol, intTopRow, True)
        'arrRect(1) = grd.GetCellDisplayRectangle(intRightCol, intTopRow, False)


        ' 2) search for bottom-most row
        Dim intBottomRow As Integer = -1
        bolFound = False
        For j As Integer = intTopRow + 1 To objDT_All_Zones.Rows.Count - 1
            If CInt(objDT_All_Zones.Rows(j).Item(intRightCol)) <> intZoneNumber Then
                bolFound = True
                intBottomRow = j - 1
                Exit For
            End If
        Next
        If Not bolFound Then
            intBottomRow = objDT_All_Zones.Rows.Count - 1
        End If
        arrRect(2) = grd.GetCellDisplayRectangle(intRightCol, intBottomRow, True)
        'arrRect(2) = grd.GetCellDisplayRectangle(intRightCol, intBottomRow, False)

        ' save our progress for next time so we don't have to iterate over areas we have already been
        intBookmarkCol = intLeftCol
        intBookmarkRow = intBottomRow + 1
        If intBookmarkRow > objDT_All_Zones.Rows.Count - 1 Then
            intBookmarkRow = 0
        End If

        Return arrRect
    End Function




    Public Shared Sub QuickDrawZoneLines(ByVal grd As DataGridView, ByVal objDT_All_Zones As DataTable,
                                         ByRef ARR_TOP_X() As Integer, ByRef ARR_TOP_Y() As Integer,
                                         ByRef ARR_BOT_X() As Integer, ByRef ARR_BOT_Y() As Integer)
        If grd Is Nothing Then
            Exit Sub
        End If

        If grd.Rows.Count = 0 Or grd.Columns.Count = 0 Then
            Exit Sub
        End If

        If objDT_All_Zones Is Nothing Then
            Exit Sub
        End If

        ReDim ARR_TOP_X(5)
        ReDim ARR_TOP_Y(5)
        ReDim ARR_BOT_X(5)
        ReDim ARR_BOT_Y(5)

        Dim FirstRow As Integer = 0
        Dim FirstCol As Integer = 0
        Dim LastRow As Integer = grd.Rows.Count - 1
        Dim LastCol As Integer = grd.Columns.Count - 1


        'grd.GetColumnDisplayRectangle(0, True)
        'ARR_TOP_X(0) = grd.GetColumnDisplayRectangle(FirstCol, True).Left
        'ARR_TOP_Y(0) = grd.GetColumnDisplayRectangle(FirstCol, True).Bottom

        'ARR_BOT_X(0) = grd.GetColumnDisplayRectangle(FirstCol, True).Bottom
        'ARR_BOT_Y(0) = grd.GetColumnDisplayRectangle(FirstCol, True).Left




        ARR_TOP_X(0) = grd.GetCellDisplayRectangle(FirstCol, FirstRow, True).Right
        ARR_TOP_Y(0) = grd.GetCellDisplayRectangle(FirstCol, FirstRow, True).Top

        ARR_BOT_X(0) = grd.GetCellDisplayRectangle(FirstCol, LastRow, True).Left
        ARR_BOT_Y(0) = grd.GetCellDisplayRectangle(FirstCol, LastRow, True).Bottom




        ARR_TOP_X(5) = grd.GetCellDisplayRectangle(LastCol, FirstRow, True).Right
        ARR_TOP_Y(5) = grd.GetCellDisplayRectangle(LastCol, FirstRow, True).Top

        ARR_BOT_X(5) = grd.GetCellDisplayRectangle(LastCol, LastRow, True).Right
        ARR_BOT_Y(5) = grd.GetCellDisplayRectangle(LastCol, LastRow, True).Bottom


        Dim o As Object = Nothing


    End Sub








End Class
