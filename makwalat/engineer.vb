Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Net
Imports System.IO

Public Class engineer
    Dim wClient As New WebClient
    Private Sub TextBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.Text = ""
        TextBox1.ForeColor = Color.Black
    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text = "" Then
            TextBox1.Text = "الاسم"
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox2.Text = ""
        TextBox2.ForeColor = Color.Black
    End Sub
    Private Sub TextBox2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If TextBox2.Text = "" Then
            TextBox2.Text = "الســـن"
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox3_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        TextBox3.Text = ""
        TextBox3.ForeColor = Color.Black
    End Sub
    Private Sub TextBox3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        If TextBox3.Text = "" Then
            TextBox3.Text = "العنوان"
            TextBox3.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox4_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus
        TextBox4.Text = ""
        TextBox4.ForeColor = Color.Black
    End Sub
    Private Sub TextBox4_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        If TextBox4.Text = "" Then
            TextBox4.Text = "المحافظة"
            TextBox4.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox5_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.GotFocus
        TextBox5.Text = ""
        TextBox5.ForeColor = Color.Black
    End Sub
    Private Sub TextBox5_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus
        If TextBox5.Text = "" Then
            TextBox5.Text = "التخصص"
            TextBox5.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox6_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.GotFocus
        TextBox6.Text = ""
        TextBox6.ForeColor = Color.Black
    End Sub
    Private Sub TextBox6_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus
        If TextBox6.Text = "" Then
            TextBox6.Text = "الحالة الاجتماعية"
            TextBox6.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox7_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.GotFocus
        TextBox7.Text = ""
        TextBox7.ForeColor = Color.Black
    End Sub
    Private Sub TextBox7_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.LostFocus
        If TextBox7.Text = "" Then
            TextBox7.Text = "الراتب"
            TextBox7.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox8_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.GotFocus
        TextBox8.Text = ""
        TextBox8.ForeColor = Color.Black
    End Sub
    Private Sub TextBox8_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.LostFocus
        If TextBox8.Text = "" Then
            TextBox8.Text = "الفيس بوك"
            TextBox8.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox9_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.GotFocus
        TextBox9.Text = ""
        TextBox9.ForeColor = Color.Black
    End Sub
    Private Sub TextBox9_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.LostFocus
        If TextBox9.Text = "" Then
            TextBox9.Text = "لينك خارجي"
            TextBox9.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox10_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.GotFocus
        TextBox10.Text = ""
        TextBox10.ForeColor = Color.Black
    End Sub
    Private Sub TextBox10_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.LostFocus
        If TextBox10.Text = "" Then
            TextBox10.Text = "يعمل او لايعمل"
            TextBox10.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox11_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.GotFocus
        TextBox11.Text = ""
        TextBox11.ForeColor = Color.Black
    End Sub
    Private Sub TextBox11_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.LostFocus
        If TextBox11.Text = "" Then
            TextBox11.Text = "رقم عضوية فى النقابة"
            TextBox11.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox12_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.GotFocus
        TextBox12.Text = ""
        TextBox12.ForeColor = Color.Black
    End Sub
    Private Sub TextBox12_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.LostFocus
        If TextBox12.Text = "" Then
            TextBox12.Text = "الرقم القومي"
            TextBox12.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub DataGridView1_MouseLeave(sender As Object, e As System.EventArgs) Handles DataGridView1.MouseLeave
        DataGridView1.ScrollBars = ScrollBars.None
    End Sub

    Private Sub DataGridView1_MouseHover(sender As Object, e As System.EventArgs) Handles DataGridView1.MouseHover
        DataGridView1.ScrollBars = ScrollBars.Both
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
                DataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.DarkOrange
            End If
        End If
    End Sub
    Private Sub DataGridView1_CellMouseLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseLeave
        DataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub


    Private Sub engineer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry


        main.Enabled = False
        fast()
        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())

    End Sub

    Private Sub mokawlat_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SaveFormSize(Me)  'Get to save  size & Position of Form in Registry

        main.Enabled = True
    End Sub
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

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'DB project >>>  num-nam-date-plac-phon-mob-usr
        'nam,age,adrs,city,perjob,relation,sallery,fb,link,statwork,numinco,idnum


        ' macji
        Dim mac As String
        mac = getMacAddress()

        Dim result As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=insertengineer&macji=" + mac + "&nam=" +
        TextBox1.Text + "&age=" + TextBox2.Text + "&adrs=" + TextBox3.Text +
        "&city=" + TextBox4.Text + "&perjob=" + TextBox5.Text + "&relation=" + TextBox6.Text +
         "&sallery=" + TextBox7.Text + "&fb=" + TextBox8.Text + "&link=" + TextBox9.Text +
         "&statwork=" + TextBox10.Text + "&numinco=" + TextBox11.Text + "&idnum=" + TextBox12.Text)

        If result = "1" Then

            MessageBox.Show("Successfully Registered")

        ElseIf result = "0" Then

            MessageBox.Show("IThere was an error, please try again.")
        End If
        fast()
    End Sub

    Sub fast()
        Dim ritxt As New TextBox
        DataGridView1.DataSource = Nothing
        'Remove Blank Lines
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        Dim wClient As New WebClient
        ritxt.MaxLength = 99999999
        wClient.Encoding = Encoding.UTF8
        wClient.UseDefaultCredentials = True
        wClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        Dim IsFlagFound As Boolean = True
        Dim NewColName As String
        Dim cellvalue(20) As String
        Dim result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=readeng")
        ritxt.Clear()

        : ritxt.Text = result & vbCrLf
        : ritxt.Text = ritxt.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt.Text, vbCrLf & vbCrLf) = 0
            ritxt.Text = Replace(ritxt.Text, vbCrLf & vbCrLf, vbCrLf)
        Loop

        Dim col, col1, col2, col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13 As New DataGridViewTextBoxColumn
        col.DataPropertyName = "PropertyName"
        col.HeaderText = "الاسم"
        col.Name = "nam"
        DataGridView1.Columns.Add(col)
        col2.DataPropertyName = "PropertyName2"
        col2.HeaderText = "السن"
        col2.Name = "age"
        DataGridView1.Columns.Add(col2)
        'DataGridView1.Columns(1).Width = 450
        col3.DataPropertyName = "PropertyName3"
        col3.HeaderText = "العنوان"
        col3.Name = "adrs"
        DataGridView1.Columns.Add(col3)
        DataGridView1.Columns(2).Width = 250
        col4.DataPropertyName = "PropertyName4"
        col4.HeaderText = "المحافطة"
        col4.Name = "address"
        DataGridView1.Columns.Add(col4)
        DataGridView1.Columns(3).Width = 350
        col5.DataPropertyName = "PropertyName5"
        col5.HeaderText = "التخصص"
        col5.Name = "phone"
        DataGridView1.Columns.Add(col5)
        DataGridView1.Columns(4).Width = 150
        col6.DataPropertyName = "PropertyName6"
        col6.HeaderText = "الحالة الاجتماعية"
        col6.Name = "fax"
        DataGridView1.Columns.Add(col6)
        col7.DataPropertyName = "PropertyName7"
        col7.HeaderText = "الراتب"
        col7.Name = "email"
        DataGridView1.Columns.Add(col7)
        DataGridView1.Columns(6).Width = 250
        col8.DataPropertyName = "PropertyName8"
        col8.HeaderText = "الفيس بوك"
        col8.Name = "urlfac"
        DataGridView1.Columns.Add(col8)
        col9.DataPropertyName = "PropertyName9"
        col9.HeaderText = "لينك خارجي"
        col9.Name = "urllink"
        DataGridView1.Columns.Add(col9)
        col10.DataPropertyName = "PropertyName10"
        col10.HeaderText = "حالة العمل"
        col10.Name = "urlstate"
        DataGridView1.Columns.Add(col10)
        col11.DataPropertyName = "PropertyName11"
        col11.HeaderText = "رقم العضوية فى النقابة"
        col11.Name = "urlid"
        DataGridView1.Columns.Add(col11)
        col12.DataPropertyName = "PropertyName12"
        col12.HeaderText = "رقم البطاقة"
        col12.Name = "urdl"
        DataGridView1.Columns.Add(col12)
        col13.DataPropertyName = "PropertyName13"
        col13.HeaderText = "رقم العضوية فى النقابة"
        col13.Name = "urdkl"
        DataGridView1.Columns.Add(col13)
        If (Not System.IO.File.Exists("C:\mokawalat\database\engineer.busin")) Then

        Else

            System.IO.File.WriteAllText("C:\mokawalat\database\engineer.busin", "")
        End If
        For i As Integer = 0 To ritxt.Lines.Length - 1

            Dim row = ritxt.Lines(i) & If(i < ritxt.Lines.Length - 1, Environment.NewLine, "")
            cellvalue = row.Split(","c) 'check what is ur separator
            'If IsFlagFound Then
            '    'For l = 0 To cellvalue.Length - 1
            '    NewColName = Trim(cellvalue(l))
            '    NewColName = NewColName.Replace(vbNewLine, Nothing)
            '    DataGridView1.Columns.Add(NewColName, NewColName)

            'Next
            '    IsFlagFound = False
            'Else
            Dim sw As StreamWriter
            If (Not System.IO.File.Exists("C:\mokawalat\database\engineer.busin")) Then
                sw = System.IO.File.CreateText("C:\mokawalat\database\engineer.busin")
                '  sw.WriteLine("Start Error Log for today")
            Else

                sw = System.IO.File.AppendText("C:\mokawalat\database\engineer.busin")
            End If
            sw.WriteLine(ritxt.Lines(i))
            sw.Close()
            DataGridView1.Rows.Add(cellvalue)
            '                DataGridView1.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))

            'End If

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
            ' System.IO.Directory.CreateDirectory("C:\Users\" & Environment.UserName & "\Desktop\mokawalat")
            System.IO.Directory.CreateDirectory("C:\mokawalat")
            System.IO.Directory.CreateDirectory("C:\mokawalat\chat")
            System.IO.Directory.CreateDirectory("C:\mokawalat\lang")
            System.IO.Directory.CreateDirectory("C:\mokawalat\database")
            System.IO.Directory.CreateDirectory("C:\mokawalat\setup")
            System.IO.Directory.CreateDirectory("C:\mokawalat\setup")
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
            IO.File.WriteAllText("C:\mokawalat\database\engineer.busin", text.ToString())

        End If
    End Sub

    Private Sub fileopen_Click(sender As System.Object, e As System.EventArgs) Handles fileopen.Click
        GetCsvData("C:\mokawalat\database\engineer.busin")

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
        html.saveashtml(DataGridView1, "C:\mokawalat\browser\engineer" & DateTime.Today.ToString("dd-MMM-yyyy") & ".html")
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
    Private Sub engineer_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Panel2.Height = Me.Height
        Panel1.Height = Me.Height
        Button1.Location = New Point(20, Panel1.Height - 117)
        Button2.Location = New Point(20, Panel1.Height - 93)
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
     
End Class