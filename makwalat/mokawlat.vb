Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Text


Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.Data.DataTable
Public Class mokawlat

    Dim wClient As New System.Net.WebClient
    Dim n1, n2, n3, n4, n5, n6, n7, n8, n9, n10
    Dim result As String

    Sub fast()
        Dim ritxt As New TextBox
        DataGridView1.DataSource = Nothing
        'Remove Blank Lines

        ritxt.MaxLength = 99999999
        wClient.Encoding = Encoding.UTF8
        wClient.UseDefaultCredentials = True
        wClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        Dim IsFlagFound As Boolean = True
        Dim NewColName As String
        Dim cellvalue(20) As String
        Dim result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=readdata")
        ritxt.Clear()
        : ritxt.Text = result & vbCrLf
        : ritxt.Text = ritxt.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt.Text, vbCrLf & vbCrLf) = 0
            ritxt.Text = Replace(ritxt.Text, vbCrLf & vbCrLf, vbCrLf)
        Loop
        Dim col, col1, col2, col3, col4, col5, col6, col7, col8 As New DataGridViewTextBoxColumn
        col.DataPropertyName = "PropertyName"
        col.HeaderText = "city"
        col.Name = "city"
        DataGridView1.Columns.Add(col)
        col2.DataPropertyName = "PropertyName"
        col2.HeaderText = "area"
        col2.Name = "area"
        DataGridView1.Columns.Add(col2)
        'DataGridView1.Columns(1).Width = 450
        col3.DataPropertyName = "PropertyName3"
        col3.HeaderText = "companies"
        col3.Name = "companies"
        DataGridView1.Columns.Add(col3)
        DataGridView1.Columns(2).Width = 250
        col4.DataPropertyName = "PropertyName4"
        col4.HeaderText = "address"
        col4.Name = "address"
        DataGridView1.Columns.Add(col4)
        DataGridView1.Columns(3).Width = 350
        col5.DataPropertyName = "PropertyName5"
        col5.HeaderText = "phone"
        col5.Name = "phone"
        DataGridView1.Columns.Add(col5)
        DataGridView1.Columns(4).Width = 150
        col6.DataPropertyName = "PropertyName6"
        col6.HeaderText = "fax"
        col6.Name = "fax"
        DataGridView1.Columns.Add(col6)
        col7.DataPropertyName = "PropertyName7"
        col7.HeaderText = "email"
        col7.Name = "email"
        DataGridView1.Columns.Add(col7)
        DataGridView1.Columns(6).Width = 250
        col8.DataPropertyName = "PropertyName8"
        col8.HeaderText = "url"
        col8.Name = "url"
        DataGridView1.Columns.Add(col8)
        For i As Integer = 0 To ritxt.Lines.Length - 1

            Dim row = ritxt.Lines(i) & If(i < ritxt.Lines.Length - 1, Environment.NewLine, "")
            cellvalue = row.Split(","c) 'check what is ur separator
            If IsFlagFound Then
                'For l = 0 To cellvalue.Length - 1
                '    NewColName = Trim(cellvalue(l))
                '    NewColName = NewColName.Replace(vbNewLine, Nothing)
                '    DataGridView1.Columns.Add(NewColName, NewColName)

                'Next
                IsFlagFound = False
            Else

                DataGridView1.Rows.Add(cellvalue)
                '                DataGridView1.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))

            End If

        Next

        DataGridView1.AutoResizeRows( _
          DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)
        'For i = 0 To DataGridView1.Columns.Count - 1
        '    If i <> 1 Then '//restricted columns, 'i' is Your column index
        '        DataGridView1.Columns(i).ReadOnly = True
        '    End If
        'Next
        Dim ro As DataGridViewRow
        Dim n1 As Integer = 0
        For Each ro In DataGridView1.Rows

            DataGridView1.Rows(n1).HeaderCell.Value = (1 + n1).ToString
            DataGridView1.RowHeadersWidth = 80
            n1 += 1
        Next
    End Sub

    Private Sub downloaddata_Click(sender As System.Object, e As System.EventArgs) Handles downloaddata.Click
        fast()
        ToolStripLabel1.Text = "Num Of Comp :" & DataGridView1.Rows.Count - 2
    End Sub

    Private Sub uploaddata_Click(sender As System.Object, e As System.EventArgs) Handles uploaddata.Click

        For row As Integer = 0 To DataGridView1.RowCount - 1
            'DataGridView1.SelectedRows.Item(0).Cells (1).Value
            '  DataGridView1.SelectedRows.Item(0)
            ' n1 = DataGridView1(0, row).Value

            If IsDBNull(DataGridView1.Item(0, row).Value Is Nothing Or
                  DataGridView1.Item(1, row).Value Is Nothing Or
                  DataGridView1.Item(2, row).Value Is Nothing Or
                  DataGridView1.Item(3, row).Value Is Nothing Or
                  DataGridView1.Item(4, row).Value Is Nothing Or
                  DataGridView1.Item(5, row).Value Is Nothing Or
                  DataGridView1.Item(6, row).Value Is Nothing Or
                  DataGridView1.Item(7, row).Value Is Nothing) Then
            Else
                n1 = DataGridView1.Rows(row).Cells(0).Value
                n2 = DataGridView1.Rows(row).Cells(1).Value
                n3 = DataGridView1.Rows(row).Cells(2).Value
                n4 = DataGridView1.Rows(row).Cells(3).Value
                n5 = DataGridView1.Rows(row).Cells(4).Value
                n6 = DataGridView1.Rows(row).Cells(5).Value
                n7 = DataGridView1.Rows(row).Cells(6).Value
                n8 = DataGridView1.Rows(row).Cells(7).Value
                'city,area,companies,address,phone,fax,email,url
                result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=insertdata&city=" + n1 + "&area=" + n2 + "&companies=" + n3 + "&address=" + n4 +
                                                "&phone=" + n5 + "&fax=" + n6 + "&email=" + n7 + "&url=" + n8)

            End If

        Next

        If result = "1" Then
            MessageBox.Show("recored")
            Beep()
        ElseIf result = "0" Then

            MessageBox.Show("IThere was an error, please try again.")
        End If
        'chatbox.Text = result & vbCrLf
        'chatbox.Text = chatbox.Text.Replace("####", vbCrLf)

        '  id-code,date-pro,lat,lng,pric,nu,pernu,pernum,nuorworker,perid

        'chatbox.SelectionStart = chatbox.Text.Length
        'chatbox.ScrollToCaret()
        '  If result = "1" Then
        'msjbox.Clear()
        'MessageBox.Show("recored")
        '  Beep()
        '  ElseIf result = "0" Then

        '   MessageBox.Show("IThere was an error, please try again.")
        '   End If
        ToolStripLabel1.Text = "Num Of Comp :" & DataGridView1.Rows.Count - 2
    End Sub
    Dim path As String = "B:\New folder (3)\Civil\Company\comp.xls"

    Private Sub Readexcell_Click(sender As System.Object, e As System.EventArgs) Handles Readexcell.Click
        datagridview1.Datasource = Nothing

        Try

            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim dataSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            Dim texts = TextBox1.Text
            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;")

            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" + texts + "$]", MyConnection)

            dataSet = New System.Data.DataSet
            MyCommand.Fill(dataSet)
            DataGridView1.DataSource = dataSet.Tables(0)
            DataGridView1.AutoResizeRows( _
          DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)
            For i = 0 To DataGridView1.Columns.Count - 1
                If i <> 1 Then '//restricted columns, 'i' is Your column index
                    DataGridView1.Columns(i).ReadOnly = True
                End If
            Next

            DataGridView1.Columns(2).Width = 250

            DataGridView1.Columns(3).Width = 350

            DataGridView1.Columns(4).Width = 150

            DataGridView1.Columns(6).Width = 250
            Dim ro As DataGridViewRow
            Dim n1 As Integer = 0
            For Each ro In DataGridView1.Rows

                DataGridView1.Rows(n1).HeaderCell.Value = (1 + n1).ToString
                DataGridView1.RowHeadersWidth = 80
                n1 += 1
            Next
            MyConnection.Close()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        ToolStripLabel1.Text = "Num Of Comp :" & DataGridView1.Rows.Count - 2
    End Sub


    Private Sub Form13_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        DataGridView1.Width = Me.Width
        DataGridView1.Height = Me.Height * 0.9
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

    End Sub
    Private Sub DataGridView1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridView1.RowPrePaint

        'DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        Dim c As Color = Color.Gray
        For Each row As DataGridViewRow In DataGridView1.Rows
            row.DefaultCellStyle.BackColor = c
            c = If(c = Color.Gray, Color.DarkGray, Color.Gray)
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black
            ' End
        Next

    End Sub
    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter

        If e.RowIndex > -1 Then
            '  
            If DataGridView1.Rows(e.RowIndex).Selected = True Then
                DataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.DimGray
            End If
        End If
    End Sub
    Private Sub DataGridView1_CellMouseLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseLeave
        DataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub



    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dim rowindex As String
        Dim found As Boolean = False
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells.Item(ComboBox1.Text).Value = TTextBox1.Text Then
                rowindex = row.Index.ToString()
                found = True
                Dim actie As String = row.Cells(ComboBox1.Text).Value.ToString()

                Dim itemCount As Integer
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    DataGridView1.Rows(i).Selected = False
                    If (DataGridView1.Rows(i).Cells(ComboBox1.Text).Value = TTextBox1.Text) Then
                        'your logic
                        itemCount = itemCount + 1
                        'DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(ComboBox1.Text)

                        DataGridView1.Rows(i).Selected = True

                    End If
                Next
                MsgBox(itemCount & "=  " & actie)
                Exit For
            End If
        Next
        If Not found Then
            MsgBox("Item not found")
        End If
    End Sub

    Private Sub mokawlat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry


        main.Enabled = False
        ToolStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())

    End Sub

    Private Sub mokawlat_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SaveFormSize(Me)  'Get to save  size & Position of Form in Registry

        main.Enabled = True
    End Sub
    Private Sub DataGridView1_MouseLeave(sender As Object, e As System.EventArgs) Handles DataGridView1.MouseLeave
        DataGridView1.ScrollBars = ScrollBars.None
    End Sub

    Private Sub DataGridView1_MouseHover(sender As Object, e As System.EventArgs) Handles DataGridView1.MouseHover
        DataGridView1.ScrollBars = ScrollBars.Both
    End Sub
    Public Sub GetCsvData(ByVal Filename As String)
        Dim IsFlagFound As Boolean = True
        Dim NewColName As String

        Dim rowvalue As String
        Dim cellvalue(20) As String
        Dim streamReader As IO.StreamReader = New IO.StreamReader(Filename)
        'Reading CSV file content 


        While streamReader.Peek() <> -1
            Dim ro As DataGridViewRow
            Dim n1 As Integer = 0
            For Each ro In DataGridView1.Rows

                DataGridView1.Rows(n1).HeaderCell.Value = (1 + n1).ToString

                n1 += 1
            Next
            rowvalue = streamReader.ReadLine()
            cellvalue = rowvalue.Split(","c) 'check what is ur separator

            If IsFlagFound Then
                For i = 0 To cellvalue.Length - 1
                    NewColName = Trim(cellvalue(i))
                    NewColName = NewColName.Replace(vbNewLine, Nothing)
                    DataGridView1.Columns.Add(NewColName, NewColName)

                Next
                IsFlagFound = False
            Else

                DataGridView1.Rows.Add(cellvalue)
                '                DataGridView1.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))

            End If
        End While
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        On Error Resume Next
        If (Not System.IO.Directory.Exists("C:\mokawalat")) Then
            System.IO.Directory.CreateDirectory("C:\mokawalat")
            System.IO.Directory.CreateDirectory("C:\mokawalat\chat")
            System.IO.Directory.CreateDirectory("C:\mokawalat\lang")
            System.IO.Directory.CreateDirectory("C:\mokawalat\database")
            System.IO.Directory.CreateDirectory("C:\mokawalat\setup")
            System.IO.Directory.CreateDirectory("C:\mokawalat\setup")
            System.IO.Directory.CreateDirectory("C:\mokawalat\chat\Aduio")
            System.IO.File.Create("C:\mokawalat\setup\setup.reg").Dispose()

            System.IO.File.Create("C:\mokawalat\database\worker.busin").Dispose()
            System.IO.File.Create("C:\mokawalat\database\mokyasat.busin").Dispose()
            System.IO.File.Create("C:\mokawalat\lang\Arabic.ini").Dispose()
            System.IO.File.Create("C:\mokawalat\lang\English.ini").Dispose()
            System.IO.File.Create("C:\mokawalat\chat\chat.busin").Dispose()
        Else
            Dim text As New StringBuilder()
            For x As Integer = 0 To DataGridView1.Rows.Count - 1
                For v As Integer = 0 To DataGridView1.ColumnCount - 1
                    'extracting cell value from 0 to 9 and add it on list
                    If v > 0 Then text.Append(",")
                    text.Append(DataGridView1.Rows(x).Cells(v).Value.ToString())
                Next
                'adding new line to text
                'text.AppendLine()
            Next
            IO.File.WriteAllText("C:\mokawalat\database\company.busin", text.ToString())

        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        GetCsvData("C:\mokawalat\database\company.busin")

    End Sub

    Private Sub HtmlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HtmlToolStripMenuItem.Click
        html.saveashtml(DataGridView1, "C:\mokawalat\browser\Mokawlat" & DateTime.Today.ToString("dd-MMM-yyyy") & ".html")
    End Sub
End Class