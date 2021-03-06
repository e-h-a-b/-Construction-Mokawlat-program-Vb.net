﻿Imports System.Text
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.IO

Public Class monthly
    Dim wClient As New WebClient
    Public Function GetEmptyWebProxy() As IWebProxy

        wClient.Proxy = GetEmptyWebProxy()
    End Function
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
    Dim mac As String
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'DB project >>>  num-nam-date-plac-phon-mob-usr

        mac = getMacAddress()
        Dim result As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=insertjoin&phonji=" + TextBox1.Text + "&mobji=" + TextBox3.Text + "&timrji=" + TextBox4.Text + "&macji=" + mac + "&facji=" + TextBox6.Text + "&namji=" + TextBox5.Text)

        If result = "1" Then

            MessageBox.Show("Successfully Registered")

        ElseIf result = "0" Then

            MessageBox.Show("IThere was an error, please try again.")
        End If
        'insidechat()
        fast()
    End Sub
    'Public Shared result As String
    'Dim listuser As New RichTextBox
    'Dim listuser1 As New RichTextBox
    'Dim listuser2, listuser3, listuser4, listuser5, listuser6, listuser7 As New RichTextBox

    'Dim lst As New ListBox
    'Sub insidechat()
    '    DataGridView2.Rows.Clear()
    '    '//DB project >>>  num-nam-date-plac-phon-mob-usr-lag-lth
    '    On Error Resume Next
    '    Form1.wClient.Encoding = Encoding.UTF8
    '    Form1.wClient.UseDefaultCredentials = True
    '    Form1.wClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
    '    Dim result = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=pr")
    '    Dim result1 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=pr1")
    '    Dim result2 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=pr2")
    '    Dim result3 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=pr3")
    '    Dim result4 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=pr4")
    '    Dim result5 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=pr5")
    '    Dim result6 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=pr6")
    '    Dim result7 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=pr7")
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
    '        l2 = ListBox1.GetItemText(ListBox1.SelectedItem)
    '        l3 = ListBox2.GetItemText(ListBox2.SelectedItem)
    '        l4 = ListBox3.GetItemText(ListBox3.SelectedItem)
    '        l5 = ListBox4.GetItemText(ListBox4.SelectedItem)
    '        l6 = ListBox5.GetItemText(ListBox5.SelectedItem)
    '        l7 = ListBox6.GetItemText(ListBox6.SelectedItem)
    '        l8 = ListBox7.GetItemText(ListBox7.SelectedItem)
    '        Dim row = {l1, l2, l3, l4, l5, l6, l7, l8}
    '        DataGridView2.Rows.Add(row)
    '    Next



    'End Sub

    Sub readdata()
        TextBox6.Text = autowrite.TextBox9.Text
        TextBox5.Text = autowrite.TextBox10.Text
        TextBox4.Text = autowrite.TextBox11.Text
        TextBox3.Text = autowrite.TextBox12.Text
        TextBox2.Text = autowrite.TextBox13.Text
        TextBox1.Text = autowrite.TextBox14.Text

    End Sub

    Sub fast()
        On Error Resume Next
        Dim ritxt As New RichTextBox
        DataGridView2.Rows.Clear()
        DataGridView2.Columns.Clear()

        wClient.Encoding = Encoding.UTF8
        wClient.UseDefaultCredentials = True
        wClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        Dim IsFlagFound As Boolean = True
        Dim NewColName As String
        Dim cellvalue(20) As String
        Dim result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=jointotal")
        ritxt.Clear()
        : ritxt.Text = result & vbCrLf
        : ritxt.Text = ritxt.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt.Text, vbCrLf & vbCrLf) = 0
            ritxt.Text = Replace(ritxt.Text, vbCrLf & vbCrLf, vbCrLf)
        Loop
        If (Not System.IO.File.Exists("C:\mokawalat\monthly\monthly.busin")) Then

        Else

            System.IO.File.WriteAllText("C:\mokawalat\monthly\monthly.busin", "")
        End If
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
                Dim sw As StreamWriter
                If (Not System.IO.File.Exists("C:\mokawalat\monthly\monthly.busin")) Then
                    sw = System.IO.File.CreateText("C:\mokawalat\monthly\monthly.busin")
                    '  sw.WriteLine("Start Error Log for today")
                Else

                    sw = System.IO.File.AppendText("C:\mokawalat\monthly\monthly.busin")
                End If
                sw.WriteLine(ritxt.Lines(i))
                sw.Close()
                DataGridView2.Rows.Add(cellvalue)
                '                DataGridView2.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))

            End If

        Next
        Label10.Text = DataGridView2.RowCount - 2

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
    Private Sub Form5_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry

        TextBox2.Text = getMacAddress()
        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())

        dak.UpdateTextPosition(Me)
        ' DataGridView2.Columns(1).Frozen = True
        readdata()
        Dim send As Integer
        dak.check(send)
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
        'insidechat()
        fast()
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
    Private Sub Form5_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
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
    'Private Sub Form5_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
    '718; 434
    '908; 484
    'Me.DataGridView2.Width = Me.Width - 202  '962; 506  826; 465
    'Me.DataGridView2.Height = Me.Height - 50 '962; 506  826; 465


    '722; 443
    '907; 493
    'Me.DataGridView2.Width = Me.Width - 185  '962; 506  826; 465
    'Me.DataGridView2.Height = Me.Height - 50 '962; 506  826; 465

    'Label1.Location = New Point(Me.Width - (904 - 760), Label1.Location.Y)  '962; 506  848; 1
    'Label2.Location = New Point(Me.Width - (904 - 765), Label2.Location.Y)
    'Label3.Location = New Point(Me.Width - (904 - 764), Label3.Location.Y)
    'Label4.Location = New Point(Me.Width - (904 - 772), Label4.Location.Y)
    'Label5.Location = New Point(Me.Width - (904 - 760), Label5.Location.Y)
    'Label6.Location = New Point(Me.Width - (904 - 769), Label6.Location.Y)
    'Label10.Location = New Point(Me.Width - (904 - 772), Label10.Location.Y)
    'Label11.Location = New Point(Me.Width - (904 - 772), Label11.Location.Y)



    'TextBox1.Location = New Point(Me.Width - (904 - 729), TextBox1.Location.Y)
    'TextBox2.Location = New Point(Me.Width - (904 - 729), TextBox2.Location.Y)
    'TextBox3.Location = New Point(Me.Width - (904 - 729), TextBox3.Location.Y)
    'TextBox4.Location = New Point(Me.Width - (904 - 729), TextBox4.Location.Y)
    'TextBox5.Location = New Point(Me.Width - (904 - 729), TextBox5.Location.Y)
    'TextBox6.Location = New Point(Me.Width - (904 - 729), TextBox6.Location.Y)

    'Button1.Location = New Point(Me.Width - (904 - 726), Button1.Location.Y)  '962; 506  834; 425
    'Button2.Location = New Point(Me.Width - (904 - 726), Button2.Location.Y) '962; 506  834; 394

    'End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.Text = ""
        TextBox1.ForeColor = Color.Black
    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text = "" Then
            TextBox1.Text = "رقم الهاتف"
            TextBox1.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox2.Text = ""
        TextBox2.ForeColor = Color.Black
    End Sub
    Private Sub TextBox2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If TextBox2.Text = "" Then
            TextBox2.Text = "رقم الجهــاز"
            TextBox2.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox3_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        TextBox3.Text = ""
        TextBox3.ForeColor = Color.Black
    End Sub
    Private Sub TextBox3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        If TextBox3.Text = "" Then
            TextBox3.Text = "الموبيل"
            TextBox3.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox4_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus
        TextBox4.Text = ""
        TextBox4.ForeColor = Color.Black
    End Sub
    Private Sub TextBox4_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        If TextBox4.Text = "" Then
            TextBox4.Text = "مدة الاشتراك"
            TextBox4.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox5_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.GotFocus
        TextBox5.Text = ""
        TextBox5.ForeColor = Color.Black
    End Sub
    Private Sub TextBox5_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus
        If TextBox5.Text = "" Then
            TextBox5.Text = "الاسم"
            TextBox5.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox6_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.GotFocus
        TextBox6.Text = ""
        TextBox6.ForeColor = Color.Black
    End Sub
    Private Sub TextBox6_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus
        If TextBox6.Text = "" Then
            TextBox6.Text = "الفيس بوك"
            TextBox6.ForeColor = Color.Gray
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

    Private Sub DataGridView1_MouseHover(sender As Object, e As System.EventArgs) Handles DataGridView2.MouseHover
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
            IO.File.WriteAllText("C:\mokawalat\monthly\monthly.busin", text.ToString())

        End If
    End Sub

    Private Sub fileopen_Click(sender As System.Object, e As System.EventArgs) Handles fileopen.Click
        GetCsvData("C:\mokawalat\monthly\monthly.busin")

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
        html.saveashtml(DataGridView2, "C:\mokawalat\browser\monthly" & DateTime.Today.ToString("dd-MMM-yyyy") & ".html")
    End Sub

End Class