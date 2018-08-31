Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Net

Public Class Form2

    Public Function GetEmptyWebProxy() As IWebProxy
        wClient.Proxy = GetEmptyWebProxy()
    End Function
    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry


        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())

        dak.UpdateTextPosition(Me)
        Dim v As String = main.DataGridView2.Rows(main.g).Cells(0).Value()
        Me.Text = "اضف شركتك فى بند  " + v
        Label13.Text = v
        Dim send As Integer
        dak.check(send)
        'insidechat()
        fast()
        readdata()
        Label14.Text = Label10.Text + 1
    End Sub
    'Public Shared result As String
    'Dim listuser As New RichTextBox
    'Dim listuser1 As New RichTextBox
    'Dim listuser2, listuser3, listuser4, listuser5, listuser6, listuser7 As New RichTextBox

    'Dim lst As New ListBox
    'Sub insidechat()
    '    Form1.wClient.Headers.Add("User-Agent: Other")
    '    DataGridView1.Rows.Clear()
    '    '//DB project >>>  num-nam-date-plac-phon-mob-usr-lag-lth
    '    On Error Resume Next
    '    Dim mac As String
    '    mac = getMacAddress()
    '    Form1.wClient.Encoding = Encoding.UTF8
    '    Form1.wClient.UseDefaultCredentials = True
    '    Form1.wClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
    '    Dim result = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=cop1" + "&mac" + mac)
    '    Dim result1 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=cop1" + "&mac" + mac)
    '    Dim result2 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=cop2" + "&mac" + mac)
    '    Dim result3 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=cop3" + "&mac" + mac)
    '    Dim result4 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=cop4" + "&mac" + mac)
    '    Dim result5 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=cop5" + "&mac" + mac)
    '    Dim result6 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=cop6" + "&mac" + mac)
    '    Dim result7 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=cop7" + "&mac" + mac)
    '    Dim g1, g2, g3, g4, g5, g6, g7, g8 As String
    '    'g1 = result : g2 = result1 : g3 = result2 : g4 = result3 : g5 = result4 : g6 = result5 : g7 = result6 : g8 = result7
    '    'If g1 = "####" Or g2 = "####" Or g3 = "####" Or g4 = "####" Or g5 = "####" Or g6 = "####" Or g7 = "####" Or g8 = "####" Then

    '    'Else


    '    'End If

    '    listuser.Clear()

    '    listuser.Text = result & vbCrLf
    '    listuser.Text = listuser.Text.Replace("####", vbCrLf)
    '    lstfrnds.Items.Clear()

    '    listuser1.Clear()

    '    listuser1.Text = result1 & vbCrLf
    '    listuser1.Text = listuser1.Text.Replace("####", vbCrLf)
    '    ListBox1.Items.Clear()

    '    listuser2.Clear()

    '    listuser2.Text = result2 & vbCrLf
    '    listuser2.Text = listuser2.Text.Replace("####", vbCrLf)
    '    ListBox2.Items.Clear()

    '    listuser3.Clear() : listuser4.Clear() : listuser5.Clear() : listuser6.Clear() : listuser7.Clear()

    '    listuser3.Text = result3 & vbCrLf : listuser4.Text = result4 & vbCrLf : listuser5.Text = result5 & vbCrLf
    '    listuser6.Text = result6 & vbCrLf : listuser7.Text = result7 & vbCrLf

    '    listuser3.Text = listuser3.Text.Replace("####", vbCrLf)
    '    listuser4.Text = listuser4.Text.Replace("####", vbCrLf)
    '    listuser5.Text = listuser5.Text.Replace("####", vbCrLf)
    '    listuser6.Text = listuser6.Text.Replace("####", vbCrLf)
    '    listuser7.Text = listuser7.Text.Replace("####", vbCrLf)
    '    ListBox3.Items.Clear()
    '    ListBox4.Items.Clear()
    '    ListBox5.Items.Clear()
    '    ListBox6.Items.Clear() : ListBox7.Items.Clear()

    '    lstfrnds.Items.AddRange(listuser.Lines)
    '    ListBox1.Items.AddRange(listuser1.Lines)
    '    ListBox2.Items.AddRange(listuser2.Lines)
    '    ListBox3.Items.AddRange(listuser3.Lines)
    '    ListBox4.Items.AddRange(listuser4.Lines)
    '    ListBox5.Items.AddRange(listuser5.Lines)
    '    ListBox6.Items.AddRange(listuser6.Lines)
    '    ListBox7.Items.AddRange(listuser7.Lines)
    '    For i = 0 To lstfrnds.Items.Count - 1
    '        lstfrnds.SetSelected(i, True)
    '        ListBox1.SetSelected(i, True)
    '        ListBox2.SetSelected(i, True)
    '        ListBox3.SetSelected(i, True)
    '        ListBox4.SetSelected(i, True)
    '        ListBox5.SetSelected(i, True)
    '        ListBox6.SetSelected(i, True)
    '        ListBox7.SetSelected(i, True)

    '        Dim l1, l2, l3, l4, l5, l6, l7, l8, l9
    '        l1 = lstfrnds.GetItemText(lstfrnds.SelectedItem)
    '        l2 = ListBox1.GetItemText(ListBox1.SelectedItem) 'nam
    '        l3 = ListBox2.GetItemText(ListBox2.SelectedItem) 'phon
    '        l4 = ListBox3.GetItemText(ListBox3.SelectedItem) 'mob
    '        l5 = ListBox4.GetItemText(ListBox4.SelectedItem) 'adrs
    '        l6 = ListBox5.GetItemText(ListBox5.SelectedItem) 'datl
    '        l7 = ListBox6.GetItemText(ListBox6.SelectedItem) 'faxco
    '        l8 = ListBox7.GetItemText(ListBox7.SelectedItem) 'prico
    '        Dim row = {l1, l5, l3, l4, l6, l8, l7}
    '        DataGridView1.Rows.Add(row)
    '    Next



    'End Sub

    Sub readdata()
        TextBox1.Text = autowrite.TextBox1.Text
        TextBox2.Text = autowrite.TextBox2.Text
        TextBox3.Text = autowrite.TextBox3.Text
        TextBox4.Text = autowrite.TextBox4.Text
        TextBox5.Text = autowrite.TextBox5.Text
        TextBox6.Text = autowrite.TextBox6.Text
        TextBox7.Text = autowrite.TextBox7.Text
        TextBox8.Text = autowrite.TextBox8.Text
    End Sub
    Dim wClient As New WebClient
    Sub fast()
        On Error Resume Next
        Dim ritxt As New RichTextBox
        DataGridView2.Rows.Clear()
        DataGridView2.Columns.Clear()
        'Remove Blank Lines

        Label10.Text = main.g

        wClient.Encoding = Encoding.UTF8
        wClient.UseDefaultCredentials = True
        wClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        Dim IsFlagFound As Boolean = True
        Dim NewColName As String
        Dim cellvalue(20) As String
        Dim result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=coptotal&kind=" + Label10.Text)
        ritxt.Clear()
        : ritxt.Text = result & vbCrLf
        : ritxt.Text = ritxt.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt.Text, vbCrLf & vbCrLf) = 0
            ritxt.Text = Replace(ritxt.Text, vbCrLf & vbCrLf, vbCrLf)
        Loop

        For i As Integer = 0 To ritxt.Lines.Length - 1

            Dim row = ritxt.Lines(i) & If(i < ritxt.Lines.Length - 1, Environment.NewLine, "")
            cellvalue = row.Split(","c) 'check what is ur separator
            If IsFlagFound Then
                For l = 0 To cellvalue.Length - 1
                    NewColName = Trim(cellvalue(l))
                    NewColName = NewColName.Replace(vbNewLine, Nothing)
                    DataGridView2.Columns.Add(NewColName, NewColName)

                Next
                IsFlagFound = False
            Else

                DataGridView2.Rows.Add(cellvalue)
                '                DataGridView1.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))

            End If

        Next
        Label9.Text = DataGridView2.RowCount - 2

        DataGridView2.AutoResizeRows( _
          DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)
        For i = 0 To DataGridView2.Columns.Count - 1
            If i <> 1 Then '//restricted columns, 'i' is Your column index
                DataGridView2.Columns(i).ReadOnly = True
            End If
        Next
        Dim ro As DataGridViewRow
        Dim n1 As Integer = 0
        For Each ro In DataGridView2.Rows

            DataGridView2.Rows(n1).HeaderCell.Value = (1 + n1).ToString

            n1 += 1
        Next
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim mac As String
        mac = getMacAddress()
        'DB project >>>  num-nam-date-plac-phon-mob-usr
        'num,nam,phon,mob,date,timr,mac,adrs,datl,faxco,prico
        ''1','$namco','$phonco','$mobco','$date','$timr','$mac','$adrs','$datl','$faxco','$prico'
        Dim result As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=insertcompany&namco=" +
                                                      TextBox1.Text + "&adrs=" + TextBox2.Text + "&phonco=" +
                                                      TextBox3.Text + "&mobco=" + TextBox4.Text + "&datl=" +
                                                      TextBox5.Text + "&prico=" + TextBox6.Text + "&mac=" + mac +
                                                      "&faxco=" + TextBox7.Text + "&kind=" + Label10.Text +
                                                      "&city=" + TextBox8.Text)

        If result = "1" Then

            MessageBox.Show("Successfully Registered")

        ElseIf result = "0" Then

            MessageBox.Show("IThere was an error, please try again.")
        End If
        ' insidechat()
        fast()

    End Sub


    Private Sub DataGridView2_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

    End Sub
    Private Sub DataGridView2_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridView2.RowPrePaint

        'DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
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
                DataGridView2.RowsDefaultCellStyle.SelectionBackColor = Color.LightCyan
            End If
        End If
    End Sub
    Private Sub DataGridView2_CellMouseLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellMouseLeave
        DataGridView2.RowsDefaultCellStyle.SelectionBackColor = Color.DimGray
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        fast()
    End Sub

    'Private Sub Form2_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
    '    '748; 481
    '904; 522
    'label5.text   785; 9
    'label9         805; 22
    'label1         785; 45
    'textbox1     754; 61
    'label4         797; 84
    'textbox2     754; 100
    'label2        800; 123
    'textbox3    754; 139
    'label7        797; 162
    'textbox4    754; 178
    'label8        797; 201
    'textbox5    754; 217
    'label6        794; 240
    'textbox6    754; 256
    'label3        789; 279
    'textbox7    754; 295
    'label15      789; 316
    'textbox8    754; 332
    'label12       789; 364
    'label13       792; 379
    'label11       789; 392
    'label14       812; 405
    'button2       751; 421
    'button1       751; 447
    'Me.DataGridView2.Width = Me.Width - 156  '962; 506  826; 465
    'Me.DataGridView2.Height = Me.Height - 41 '962; 506  826; 465
    'Label1.Location = New Point(Me.Width - (904 - 785), 45)  '962; 506  848; 1
    'Label2.Location = New Point(Me.Width - (904 - 800), 123)
    'Label3.Location = New Point(Me.Width - (904 - 789), Label3.Location.Y)
    'Label4.Location = New Point(Me.Width - (904 - 797), Label4.Location.Y)
    'Label5.Location = New Point(Me.Width - (904 - 785), Label5.Location.Y)
    'Label6.Location = New Point(Me.Width - (904 - 794), Label6.Location.Y)
    'Label7.Location = New Point(Me.Width - (904 - 797), Label7.Location.Y)
    'Label8.Location = New Point(Me.Width - (904 - 797), Label8.Location.Y)
    'Label9.Location = New Point(Me.Width - (904 - 805), Label9.Location.Y)
    'Label10.Location = New Point(Me.Width - (904 - Label10.Location.X), Label10.Location.Y)
    'Label11.Location = New Point(Me.Width - (904 - 789), Label11.Location.Y)
    'Label12.Location = New Point(Me.Width - (904 - 789), Label12.Location.Y)
    'Label13.Location = New Point(Me.Width - (904 - 792), Label13.Location.Y)
    'Label14.Location = New Point(Me.Width - (904 - 812), Label14.Location.Y)
    'Label15.Location = New Point(Me.Width - (904 - 789), Label15.Location.Y)

    '    TextBox1.Location = New Point(Me.Width - (904 - 754), TextBox1.Location.Y)
    '    TextBox2.Location = New Point(Me.Width - (904 - 754), TextBox2.Location.Y)
    '    TextBox3.Location = New Point(Me.Width - (904 - 754), TextBox3.Location.Y)
    '    TextBox4.Location = New Point(Me.Width - (904 - 754), TextBox4.Location.Y)
    '    TextBox5.Location = New Point(Me.Width - (904 - 754), TextBox5.Location.Y)
    '    TextBox6.Location = New Point(Me.Width - (904 - 754), TextBox6.Location.Y)
    '    TextBox7.Location = New Point(Me.Width - (904 - 754), TextBox7.Location.Y)
    '    TextBox8.Location = New Point(Me.Width - (904 - 754), TextBox8.Location.Y)

    '    Button1.Location = New Point(Me.Width - (904 - 751), Button1.Location.Y)  '962; 506  834; 425
    '    Button2.Location = New Point(Me.Width - (904 - 751), Button2.Location.Y) '962; 506  834; 394

    'End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.Text = ""
        TextBox1.ForeColor = Color.Black
    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text = "" Then
            TextBox1.Text = "اسم الشركة"
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox2.Text = ""
        TextBox2.ForeColor = Color.Black
    End Sub
    Private Sub TextBox2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If TextBox2.Text = "" Then
            TextBox2.Text = "العنوان"
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox3_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        TextBox3.Text = ""
        TextBox3.ForeColor = Color.Black
    End Sub
    Private Sub TextBox3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        If TextBox3.Text = "" Then
            TextBox3.Text = "الهاتف"
            TextBox3.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox4_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus
        TextBox4.Text = ""
        TextBox4.ForeColor = Color.Black
    End Sub
    Private Sub TextBox4_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        If TextBox4.Text = "" Then
            TextBox4.Text = "الموبيل"
            TextBox4.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox5_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.GotFocus
        TextBox5.Text = ""
        TextBox5.ForeColor = Color.Black
    End Sub
    Private Sub TextBox5_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus
        If TextBox5.Text = "" Then
            TextBox5.Text = "تفاصيل"
            TextBox5.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox6_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.GotFocus
        TextBox6.Text = ""
        TextBox6.ForeColor = Color.Black
    End Sub
    Private Sub TextBox6_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus
        If TextBox6.Text = "" Then
            TextBox6.Text = "السعر"
            TextBox6.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox7_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.GotFocus
        TextBox7.Text = ""
        TextBox7.ForeColor = Color.Black
    End Sub
    Private Sub TextBox7_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.LostFocus
        If TextBox7.Text = "" Then
            TextBox7.Text = "الفاكس"
            TextBox7.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox8_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.GotFocus
        TextBox8.Text = ""
        TextBox8.ForeColor = Color.Black
    End Sub
    Private Sub TextBox8_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.LostFocus
        If TextBox8.Text = "" Then
            TextBox8.Text = "المحافظة"
            TextBox8.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub mokawlat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        main.Enabled = False
    End Sub

    Private Sub mokawlat_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SaveFormSize(Me)  'Get to save  size & Position of Form in Registry

        main.Enabled = True
    End Sub
    Private Sub DataGridView2_MouseLeave(sender As Object, e As System.EventArgs) Handles DataGridView2.MouseLeave
        DataGridView2.ScrollBars = ScrollBars.None
    End Sub

    Private Sub DataGridView2_MouseHover(sender As Object, e As System.EventArgs) Handles DataGridView2.MouseHover
        DataGridView2.ScrollBars = ScrollBars.Both
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
                For i = 0 To cellvalue.Length - 1
                    NewColName = Trim(cellvalue(i))
                    NewColName = NewColName.Replace(vbNewLine, Nothing)
                    DataGridView2.Columns.Add(NewColName, NewColName)

                Next
                IsFlagFound = False
            Else

                DataGridView2.Rows.Add(cellvalue)
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
            For x As Integer = 0 To DataGridView2.Rows.Count - 1
                For v As Integer = 0 To DataGridView2.ColumnCount - 1
                    'extracting cell value from 0 to 9 and add it on list
                    If v > 0 Then text.Append(",")
                    text.Append(DataGridView2.Rows(x).Cells(v).Value.ToString())
                Next
                'adding new line to text
                text.AppendLine()
            Next
            IO.File.WriteAllText("C:\mokawalat\database\speicalcomp.busin", text.ToString())

        End If
    End Sub

    Private Sub fileopen_Click(sender As System.Object, e As System.EventArgs) Handles fileopen.Click
        GetCsvData("C:\mokawalat\database\speicalcomp.busin")

    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        DataGridView2.Rows.Clear()
    End Sub

    Private Sub fileexit_Click(sender As System.Object, e As System.EventArgs) Handles fileexit.Click
        Me.Close()
    End Sub

    Private Sub UploadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UploadToolStripMenuItem.Click
        fast()
    End Sub

    Private Sub HtmlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HtmlToolStripMenuItem.Click
        html.saveashtml(DataGridView2, "C:\mokawalat\browser\Peri-comp" & DateTime.Today.ToString("dd-MMM-yyyy") & ".html")
    End Sub


    Dim check As Boolean = True
    Private Sub Panel2_Click(sender As Object, e As System.EventArgs) Handles Panel2.Click
        Panel2.Height = Me.Height
        DataGridView2.Height = Me.Height - 67
        If check = True Then
            Panel1.Hide()
            DataGridView2.Width = Me.Width - 35
            Panel2.Location = New Point(Me.Width - 30, 25)
            Panel1.Location = New Point(Me.Width - 30, 25)
            check = False
        Else
            DataGridView2.Width = Me.Width - 175
            Panel2.Location = New Point(Me.Width - 170, 25)
            Panel1.Location = New Point(Me.Width - 170, 25)
            Panel1.Show()
            check = True
        End If
    End Sub
    Private Sub form2_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Panel2.Height = Me.Height
        Panel1.Height = Me.Height
        Button1.Location = New Point(20, Panel1.Height - 117)
        Button2.Location = New Point(20, Panel1.Height - 93)
        DataGridView2.Height = Me.Height - 67
        If check = True Then
            DataGridView2.Width = Me.Width - 175
            Panel2.Location = New Point(Me.Width - 170, 25)
            Panel1.Location = New Point(Me.Width - 170, 25)
        Else
            DataGridView2.Width = Me.Width - 35
            Panel2.Location = New Point(Me.Width - 30, 25)
            Panel1.Location = New Point(Me.Width - 30, 25)

            Panel1.Show()
        End If
    End Sub
End Class