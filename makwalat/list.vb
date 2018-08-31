Imports System.Net.NetworkInformation
Imports System.Text

Public Class list
    Dim wClient As New System.Net.WebClient
    Dim n1, n2, n3, n4, n5, n6, n7, n8, n9, n10
    Dim result As String
    Private Function getMacAddress() As String
        Try
            Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim adapter As NetworkInterface
            Dim myMac As String = String.Empty

            For Each adapter In adapters
                Select Case adapter.NetworkInterfaceType
                    'Exclude Tunnels, Loopbacks and PPP
                    Case NetworkInterfaceType.Tunnel, NetworkInterfaceType.Loopback, NetworkInterfaceType.Ppp
                    Case Else
                        If Not adapter.GetPhysicalAddress.ToString = String.Empty And Not adapter.GetPhysicalAddress.ToString = "00000000000000E0" Then
                            myMac = adapter.GetPhysicalAddress.ToString
                            Exit For ' Got a mac so exit for
                        End If

                End Select
            Next adapter

            Return myMac
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        fast()

        Dim mac As String
        mac = getMacAddress()


        n1 = mac
        n2 = Label1.Text
        n3 = TextBox1.Text
        n4 = TextBox5.Text
        n5 = TextBox2.Text
        n6 = TextBox3.Text
        n7 = TextBox4.Text
        result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=insertmokysah&macji=" + n1 + "&numm=" + n2 + "&band=" + n3 + "&amal=" + n4 + "&unit=" + n5 + "&amount=" + n6 + "&total=" + n7)


        If result = "1" Then
            MessageBox.Show("recored")
            Beep()
        ElseIf result = "0" Then

            MessageBox.Show("IThere was an error, please try again.")
        End If
    End Sub
    Public Shared g As String
    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 11 Then
            Dim v As String = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            g = e.RowIndex
            Form2.Show()
            dak.UpdateTextPosition(Form2)
        End If

        If e.ColumnIndex = 0 Then
            Dim v As String = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            g = e.RowIndex
            Form2.Show()

        End If
        Form2.Label10.Text = g
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
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.LightBlue
            ' End
        Next

    End Sub
    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter

        If e.RowIndex > -1 Then
            '  
            If DataGridView1.Rows(e.RowIndex).Selected = True Then
                DataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.LightCyan
            End If
        End If
    End Sub
    Private Sub DataGridView1_CellMouseLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseLeave
        DataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub

    Sub ent(e As DataGridViewCellPaintingEventArgs)


    End Sub
    Dim ty
    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        '' hardcoded cell index 
        'If e.ColumnIndex = 2 AndAlso e.RowIndex = 1 Then
        '    ' draw the background and disable the drawing 
        '    e.PaintBackground(e.ClipBounds, True)
        '    e.Handled = True

        '    ' set the size of the cell 
        '    DataGridView1.Rows(1).Height = textControl1.Height
        '    DataGridView1.Columns(2).Width = textControl1.Width

        '    ' create the bitmap 
        '    Dim bmp As New Bitmap(textControl1.Width, textControl1.Height)
        '    textControl1.DrawToBitmap(bmp, New Rectangle(0, 0, textControl1.Width, textControl1.Height))

        '    ' draw the bitmap to the cell 
        '    e.Graphics.DrawImage(bmp, New Point(e.CellBounds.X, e.CellBounds.Y))
        'End If
        If CheckBox1.Checked = True Then
            'ty = e
            If e.Value Is Nothing Then
                Return
            End If
            Dim s = e.Graphics.MeasureString(e.Value.ToString(), DataGridView1.Font)
            If s.Width > DataGridView1.Columns(2).Width Then
                Using gridBrush As Brush = New SolidBrush(Me.DataGridView1.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)
                    Using gridLinePen As New Pen(gridBrush)
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1)
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)
                        e.Graphics.DrawString(e.Value.ToString(), DataGridView1.Font, Brushes.Black, e.CellBounds, StringFormat.GenericDefault)
                        DataGridView1.Rows(e.RowIndex).Height = CInt(s.Height * Math.Ceiling(s.Width / DataGridView1.Columns(2).Width))
                        e.Handled = True
                    End Using
                End Using
            End If


        End If
        ty = e

    End Sub

    Private Sub Form10_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry


        Label1.Text = Form8.g
        fast()
        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())

    End Sub




    Sub fast()
        Dim ritxt As New RichTextBox
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        'Remove Blank Lines

        Label1.Text = Form8.g

        wClient.Encoding = Encoding.UTF8
        wClient.UseDefaultCredentials = True
        wClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        Dim IsFlagFound As Boolean = True
        Dim NewColName As String
        Dim cellvalue(20) As String
        Dim result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=readmokysah&numm=" + Label1.Text)
        ritxt.Clear()
        : ritxt.Text = result & vbCrLf
        : ritxt.Text = ritxt.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt.Text, vbCrLf & vbCrLf) = 0
            ritxt.Text = Replace(ritxt.Text, vbCrLf & vbCrLf, vbCrLf)
        Loop
        Dim col, col1, col2, col3, col4, col5 As New DataGridViewTextBoxColumn
        col.DataPropertyName = "PropertyName"
        col.HeaderText = "بند"
        col.Name = "colWhateverName"
        DataGridView1.Columns.Add(col)
        col2.DataPropertyName = "PropertyName"
        col2.HeaderText = "الاعمال"
        col2.Name = "colWhateverName2"
        DataGridView1.Columns.Add(col2)
        DataGridView1.Columns(1).Width = 450
        col3.DataPropertyName = "PropertyName3"
        col3.HeaderText = "الوحدة"
        col3.Name = "colWhateverName"
        DataGridView1.Columns.Add(col3)
        col4.DataPropertyName = "PropertyName4"
        col4.HeaderText = "الكمية"
        col4.Name = "colWhateverName"
        DataGridView1.Columns.Add(col4)
        col5.DataPropertyName = "PropertyName5"
        col5.HeaderText = "الاجمالي"
        col5.Name = "colWhateverName"
        DataGridView1.Columns.Add(col5)
        If result = "0" Then

        Else
            For i As Integer = 0 To ritxt.Lines.Length - 1

                Dim row = ritxt.Lines(i) & If(i < ritxt.Lines.Length - 1, Environment.NewLine, "")
                cellvalue = row.Split(","c) 'check what is ur separator
                If IsFlagFound Then

                    IsFlagFound = False
                Else

                    DataGridView1.Rows.Add(cellvalue)
                    '                DataGridView1.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))

                End If

            Next
        End If

        Label2.Text = DataGridView1.RowCount - 2
        DataGridView1.AutoResizeRows( _
          DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)
        For i = 0 To DataGridView1.Columns.Count - 1
            If i <> 1 Then '//restricted columns, 'i' is Your column index
                ' DataGridView1.Columns(i).ReadOnly = True
                'DataGridView1.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                'DataGridView1.Columns(i).DefaultCellStyle.WrapMode = DataGridViewTriState.True

            End If
        Next
        Dim ro As DataGridViewRow
        Dim n1 As Integer = 0
        For Each ro In DataGridView1.Rows

            DataGridView1.Rows(n1).HeaderCell.Value = (1 + n1).ToString

            n1 += 1
        Next
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.Text = ""
        TextBox1.ForeColor = Color.Black
    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text = "" Then
            TextBox1.Text = "رقم البـــند"
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox2.Text = ""
        TextBox2.ForeColor = Color.Black
    End Sub
    Private Sub TextBox2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If TextBox2.Text = "" Then
            TextBox2.Text = "الوحــدة"
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox3_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        TextBox3.Text = ""
        TextBox3.ForeColor = Color.Black
    End Sub
    Private Sub TextBox3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        If TextBox3.Text = "" Then
            TextBox3.Text = "الكــمية"
            TextBox3.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox4_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus
        TextBox4.Text = ""
        TextBox4.ForeColor = Color.Black
    End Sub
    Private Sub TextBox4_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        If TextBox4.Text = "" Then
            TextBox4.Text = "الاجــمـالي"
            TextBox4.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox5_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.GotFocus
        TextBox5.Text = ""
        TextBox5.ForeColor = Color.Black
    End Sub
    Private Sub TextBox5_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus
        If TextBox5.Text = "" Then
            TextBox5.Text = "الاعمـــــال"
            TextBox5.ForeColor = Color.Gray
        End If
    End Sub


    Private Sub mokawlat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        main.Enabled = False
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

    Private Sub filesave_Click(sender As System.Object, e As System.EventArgs) Handles filesave.Click
        On Error Resume Next
        If (Not System.IO.Directory.Exists("C:\mokawalat")) Then
            System.IO.Directory.CreateDirectory("C:\mokawalat")
            System.IO.Directory.CreateDirectory("C:\mokawalat\chat")
            System.IO.Directory.CreateDirectory("C:\mokawalat\lang")
            System.IO.Directory.CreateDirectory("C:\mokawalat\database")
            System.IO.Directory.CreateDirectory("C:\mokawalat\setup")
            System.IO.Directory.CreateDirectory("C:\mokawalat\monthly")
            System.IO.Directory.CreateDirectory("C:\mokawalat\chat\Aduio")
            System.IO.File.Create("C:\mokawalat\setup\setup.reg").Dispose()
            System.IO.File.Create("C:\mokawalat\database\company.busin").Dispose()
            System.IO.File.Create("C:\mokawalat\database\engineer.busin").Dispose()
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
                text.AppendLine()
            Next
            IO.File.WriteAllText("C:\mokawalat\database\mokaysah.busin", text.ToString())

        End If
    End Sub

    Private Sub fileopen_Click(sender As System.Object, e As System.EventArgs) Handles fileopen.Click
        GetCsvData("C:\mokawalat\database\mokaysah.busin")

    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub fileexit_Click(sender As System.Object, e As System.EventArgs) Handles fileexit.Click
        Me.Close()
    End Sub

    Private Sub UploadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UploadToolStripMenuItem.Click
        fast()
    End Sub

    Private Sub HtmlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HtmlToolStripMenuItem.Click
        html.saveashtml(DataGridView1, "C:\mokawalat\browser\Mokaysah" & DateTime.Today.ToString("dd-MMM-yyyy") & ".html")
    End Sub



    Dim check As Boolean = True
    Private Sub Panel2_Click(sender As Object, e As System.EventArgs) Handles Panel2.Click
        Panel2.Height = Me.Height
        DataGridView1.Height = Me.Height - 67
        If check = True Then
            Panel1.Hide()
            DataGridView1.Width = Me.Width - 35
            Panel2.Location = New Point(Me.Width - 30, 25)
            Panel1.Location = New Point(Me.Width - 30, 25)
            check = False
        Else
            DataGridView1.Width = Me.Width - 175
            Panel2.Location = New Point(Me.Width - 170, 25)
            Panel1.Location = New Point(Me.Width - 170, 25)
            Panel1.Show()
            check = True
        End If
    End Sub
    Private Sub form10_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Panel2.Height = Me.Height
        Panel1.Height = Me.Height
        Button1.Location = New Point(20, Panel1.Height - 117)

        DataGridView1.Height = Me.Height - 67
        If check = True Then
            DataGridView1.Width = Me.Width - 175
            Panel2.Location = New Point(Me.Width - 170, 25)
            Panel1.Location = New Point(Me.Width - 170, 25)
        Else
            DataGridView1.Width = Me.Width - 35
            Panel2.Location = New Point(Me.Width - 30, 25)
            Panel1.Location = New Point(Me.Width - 30, 25)

            Panel1.Show()
        End If
    End Sub

    Function Add(kk As Geometry3D.Point3D()) As Integer
        Throw New NotImplementedException
    End Function

End Class