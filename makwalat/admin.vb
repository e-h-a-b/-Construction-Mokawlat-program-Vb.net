Imports System.Text
Imports System.Net

Public Class admin
    Private Sub LoadGridData(ByRef ThisGrid As DataGridView, ByVal Filename As String)
        ThisGrid.Rows.Clear()
        Dim TextLine As String = ""
        Dim SplitLine() As String
        Using objReader As New System.IO.StreamReader(Filename)
            Do While objReader.Peek() <> -1
                TextLine = objReader.ReadLine()
                If TextLine.Trim.Length > 0 AndAlso Not TextLine.StartsWith("#") Then
                    DataGridView2.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))
                End If
            Loop
        End Using
    End Sub
    Private Sub LoadColumnsInDGV(FileName As String)
        Try
            Dim sr As New System.IO.StreamReader(FileName)
            Dim TxtNewLine As String
            Dim IsFlagFound As Boolean = True
            Dim NewColName As String
            Dim SplitLine() As String

            Do While sr.Peek() > -1
                TxtNewLine = Trim(sr.ReadLine()) & vbNewLine
                SplitLine = Split(TxtNewLine, vbTab)
                If IsFlagFound Then
                    For i = 0 To SplitLine.Length - 1
                        NewColName = Trim(SplitLine(i))
                        NewColName = NewColName.Replace(vbNewLine, Nothing)
                        DataGridView2.Columns.Add(NewColName, NewColName)
                    Next
                    IsFlagFound = False
                Else
                    DataGridView2.Rows.Add(SplitLine)
                    '                DataGridView2.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))

                End If
            Loop
            sr.Close()
        Catch ex As Exception
            MsgBox("Error on Sub LoadColumnsInDGV " & vbCrLf & ex.Source & vbCrLf & ex.Message)
        End Try
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
            For Each ro In DataGridView2.Rows

                DataGridView2.Rows(n1).HeaderCell.Value = (1 + n1).ToString

                n1 += 1
            Next
            rowvalue = streamReader.ReadLine()
            cellvalue = rowvalue.Split(","c) 'check what is ur separator

            If IsFlagFound Then
                '    For i = 0 To cellvalue.Length - 1
                '        NewColName = Trim(cellvalue(i))
                '        NewColName = NewColName.Replace(vbNewLine, Nothing)
                '        DataGridView2.Columns.Add(NewColName, NewColName)

                '    Next
                '    IsFlagFound = False
                'Else

                DataGridView2.Rows.Add(cellvalue)
                '                DataGridView2.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))

            End If
        End While
    End Sub
    Dim listuser As New RichTextBox
    Sub fast()
        Dim ritxt As New TextBox
        DataGridView2.DataSource = Nothing
        'Remove Blank Lines
        DataGridView2.Rows.Clear()
        ' DataGridView2.Columns.Clear()
        Dim wClient As New WebClient
        ritxt.MaxLength = 99999999
        wClient.Encoding = Encoding.UTF8
        wClient.UseDefaultCredentials = True
        wClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        Dim IsFlagFound As Boolean = True
        Dim NewColName As String
        Dim cellvalue(20) As String
        Dim result0 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=perdata")
        ritxt.Clear()

        : ritxt.Text = result0 & vbCrLf
        : ritxt.Text = ritxt.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt.Text, vbCrLf & vbCrLf) = 0
            ritxt.Text = Replace(ritxt.Text, vbCrLf & vbCrLf, vbCrLf)
        Loop

        For i As Integer = 0 To ritxt.Lines.Length - 1

            Dim row = ritxt.Lines(i) & If(i < ritxt.Lines.Length - 1, Environment.NewLine, "")
            cellvalue = row.Split(","c) 'check what is ur separator
            'If IsFlagFound Then
            '    For l = 0 To cellvalue.Length - 1
            '        NewColName = Trim(cellvalue(l))
            '        NewColName = NewColName.Replace(vbNewLine, Nothing)
            '        DataGridView2.Columns.Add(NewColName, NewColName)

            '    Next
            '    IsFlagFound = False
            'Else

            DataGridView2.Rows.Add(cellvalue)
            '                DataGridView1.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))

            'End If

        Next

        DataGridView2.AutoResizeRows( _
          DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)
        'For i = 0 To DataGridView1.Columns.Count - 1
        '    If i <> 1 Then '//restricted columns, 'i' is Your column index
        '        DataGridView1.Columns(i).ReadOnly = True
        '    End If
        'Next
        Dim ro As DataGridViewRow
        Dim n1 As Integer = 0
        For Each ro In DataGridView2.Rows

            DataGridView2.Rows(n1).HeaderCell.Value = (1 + n1).ToString
            DataGridView2.RowHeadersWidth = 80
            n1 += 1
        Next
    End Sub


    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Form1.wClient.Encoding = Encoding.UTF8
        'Form1.wClient.UseDefaultCredentials = True
        'Form1.wClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry

        fast()
        ' LoadColumnsInDGV("C:\Users\Ihab majdy\Desktop\nj.txt"Users\" & Environment.UserName & "\Desktop\)
        ' GetCsvData("C:\Mokawalat\main.busin")

        'DataGridView2.Columns(1).Frozen = False


        'DataGridView2.AutoResizeRows( _
        '   DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)
        'For i = 0 To DataGridView2.Columns.Count - 1
        '    If i <> 1 Then '//restricted columns, 'i' is Your column index
        '        DataGridView2.Columns(i).ReadOnly = True
        '    End If
        'Next
        'Dim result = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren1" + "" + "&ren3" + "&ren4" + "&ren5" + "&ren6" + "&ren7" + "&ren8" + "&ren9" + "&ren10")
        'listuser.Clear()
        ': listuser.Text = result & vbCrLf
        ': listuser.Text = listuser.Text.Replace("####", vbCrLf)
        'RichTextBox1.Text = listuser.Text
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        On Error Resume Next

        Dim text As New StringBuilder()
        For x As Integer = 0 To DataGridView2.Rows.Count - 1
            For v As Integer = 0 To DataGridView2.ColumnCount - 1
                'extracting cell value from 0 to 9 and add it on list
                If v > 0 Then text.Append(",")
                text.Append(DataGridView2.Rows(x).Cells(v).Value.ToString())
            Next
            'adding new line to text
            text.AppendLine()
        Next
        IO.File.WriteAllText("C:\Mokawalat\main.busin", text.ToString())
        DataGridView2.Rows.Clear()
        GetCsvData("C:\Mokawalat\main.busin")
    End Sub

    Private Sub Form3_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Me.DataGridView2.Width = Me.Width - 22  '912; 530  890; 458
        Me.DataGridView2.Height = Me.Height - 72 '912; 530  890; 458
        '803; 467
        Button1.Location = New Point(Me.Width - 109, Me.Height - 63)  '962; 506  834; 425
        Button2.Location = New Point(Me.Width - 211, Me.Height - 63)  '962; 506  834; 425

        '701; 467
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim col As New DataGridViewTextBoxColumn
        col.DataPropertyName = "PropertyName"
        col.HeaderText = "SomeText"
        col.Name = "colWhateverName"
        DataGridView2.Columns.Add(col)
    End Sub


    Private Sub DataGridView2_MouseLeave(sender As Object, e As System.EventArgs) Handles DataGridView2.MouseLeave
        DataGridView2.ScrollBars = ScrollBars.None
    End Sub

    Private Sub DataGridView2_MouseHover(sender As Object, e As System.EventArgs) Handles DataGridView2.MouseHover
        DataGridView2.ScrollBars = ScrollBars.Both
    End Sub
    Private Sub DataGridView2_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

    End Sub
    Private Sub DataGridView2_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridView2.RowPrePaint

        'DataGridView2.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        Dim c As Color = Color.Gray
        For Each row As DataGridViewRow In DataGridView2.Rows
            row.DefaultCellStyle.BackColor = c
            c = If(c = Color.Gray, Color.DarkGray, Color.Gray)
            DataGridView2.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.LightBlue
            ' End
        Next

    End Sub
    Private Sub DataGridView2_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellMouseEnter

        If e.RowIndex > -1 Then
            '  
            If DataGridView2.Rows(e.RowIndex).Selected = True Then
                DataGridView2.RowsDefaultCellStyle.SelectionBackColor = Color.DarkOrange
            End If
        End If
    End Sub
    Private Sub DataGridView2_CellMouseLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellMouseLeave
        DataGridView2.RowsDefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub



    Private Sub mokawlat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        main.Enabled = False
    End Sub

    Private Sub mokawlat_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SaveFormSize(Me)  'Get to save  size & Position of Form in Registry

        main.Enabled = True
    End Sub
    Dim wClient As New System.Net.WebClient
    Dim n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15, n16, n17, n18, n19, n20, n21, n22, n23, n24, n25, n26, n27, n28, n29
    Dim result As String
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        For row As Integer = 0 To DataGridView2.RowCount - 1
            'DataGridView2.SelectedRows.Item(0).Cells (1).Value
            '  DataGridView2.SelectedRows.Item(0)
            ' n1 = DataGridView2(0, row).Value

            If IsDBNull(DataGridView2.Item(0, row).Value Is Nothing Or
                  DataGridView2.Item(1, row).Value Is Nothing Or
                  DataGridView2.Item(2, row).Value Is Nothing Or
                  DataGridView2.Item(3, row).Value Is Nothing Or
                  DataGridView2.Item(4, row).Value Is Nothing Or
                  DataGridView2.Item(5, row).Value Is Nothing Or
                  DataGridView2.Item(6, row).Value Is Nothing Or
                  DataGridView2.Item(7, row).Value Is Nothing Or
                  DataGridView2.Item(8, row).Value Is Nothing Or
                  DataGridView2.Item(9, row).Value Is Nothing Or
                  DataGridView2.Item(10, row).Value Is Nothing Or
                  DataGridView2.Item(11, row).Value Is Nothing Or
                  DataGridView2.Item(12, row).Value Is Nothing Or
                  DataGridView2.Item(13, row).Value Is Nothing Or
                  DataGridView2.Item(14, row).Value Is Nothing Or
                  DataGridView2.Item(15, row).Value Is Nothing Or
                  DataGridView2.Item(16, row).Value Is Nothing Or
                  DataGridView2.Item(17, row).Value Is Nothing Or
                  DataGridView2.Item(18, row).Value Is Nothing Or
                  DataGridView2.Item(19, row).Value Is Nothing Or
                  DataGridView2.Item(20, row).Value Is Nothing Or
                  DataGridView2.Item(21, row).Value Is Nothing Or
                  DataGridView2.Item(22, row).Value Is Nothing Or
                  DataGridView2.Item(23, row).Value Is Nothing Or
                  DataGridView2.Item(24, row).Value Is Nothing Or
                  DataGridView2.Item(25, row).Value Is Nothing Or
                  DataGridView2.Item(26, row).Value Is Nothing Or
                  DataGridView2.Item(27, row).Value Is Nothing Or
                  DataGridView2.Item(28, row).Value Is Nothing Or
                  DataGridView2.Item(29, row).Value Is Nothing) Then
            Else
                n1 = DataGridView2.Rows(row).Cells(0).Value
                n2 = DataGridView2.Rows(row).Cells(1).Value
                n3 = DataGridView2.Rows(row).Cells(2).Value
                n4 = DataGridView2.Rows(row).Cells(3).Value
                n5 = DataGridView2.Rows(row).Cells(4).Value
                n6 = DataGridView2.Rows(row).Cells(5).Value
                n7 = DataGridView2.Rows(row).Cells(6).Value
                n8 = DataGridView2.Rows(row).Cells(7).Value
                n9 = DataGridView2.Rows(row).Cells(8).Value
                n10 = DataGridView2.Rows(row).Cells(9).Value

                n11 = DataGridView2.Rows(row).Cells(10).Value
                n12 = DataGridView2.Rows(row).Cells(11).Value
                n13 = DataGridView2.Rows(row).Cells(12).Value
                n14 = DataGridView2.Rows(row).Cells(13).Value
                n15 = DataGridView2.Rows(row).Cells(14).Value
                n16 = DataGridView2.Rows(row).Cells(15).Value
                n17 = DataGridView2.Rows(row).Cells(16).Value
                n18 = DataGridView2.Rows(row).Cells(17).Value
                n19 = DataGridView2.Rows(row).Cells(18).Value
                n20 = DataGridView2.Rows(row).Cells(19).Value

                n21 = DataGridView2.Rows(row).Cells(20).Value
                n22 = DataGridView2.Rows(row).Cells(21).Value
                n23 = DataGridView2.Rows(row).Cells(22).Value
                n24 = DataGridView2.Rows(row).Cells(23).Value
                n25 = DataGridView2.Rows(row).Cells(24).Value
                n26 = DataGridView2.Rows(row).Cells(25).Value
                n27 = DataGridView2.Rows(row).Cells(26).Value
                n28 = DataGridView2.Rows(row).Cells(27).Value
                n29 = DataGridView2.Rows(row).Cells(28).Value
                result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=inserdata&nammatrl=" +
                                                n1 + "&unitdata=" + n2 + "&cta=" + n3 + "&ctb=" + n4 + "&ctc=" + n5 + "&ctd=" +
                                                n6 + "&cte=" + n7 + "&ctf=" + n8 + "&ctg=" + n9 + "&cth=" +
                                                n10 + "&cti=" + n11 + "&ctj=" + n12 + "&ctk=" + n13 + "&ctl=" +
                                                n14 + "&ctm=" + n15 + "&ctn=" + n16 + "&cto=" +
                                               n17 + "&ctp=" + n18 + "&ctq=" + n19 + "&ctr=" +
                                               n20 + "&cts=" + n21 + "&ctt=" + n22 + "&ctu=" +
                                                n23 + "&ctv=" + n24 + "&ctw=" + n25 + "&ctx=" +
                                                n26 + "&cty=" + n27 + "&ctz=" + n28 + "&ctaa=" + n29)

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
    End Sub
End Class