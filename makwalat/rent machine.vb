Imports System.Text
Imports System.Net

Public Class Form6
    Dim wClient As New WebClient
    Public Function GetEmptyWebProxy() As IWebProxy
        wClient.Proxy = GetEmptyWebProxy()
    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'DB project >>>  num-nam-date-plac-phon-mob-usr
        'num,nam,rent,date,phon,mob,plac,mach1,mach2,mach3,mach4,mach5,mach6,mach7,mach8
        Dim result As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=insertrent&placre=" + TextBox4.Text + "&namre=" + TextBox1.Text + "&phonre=" + TextBox2.Text + "&mobre=" + TextBox3.Text + "&mach1=" + TextBox5.Text + "&mach2=" + TextBox6.Text + "&mach3=" + TextBox7.Text + "&mach4=" + TextBox8.Text + "&mach5=" + TextBox9.Text + "&mach6=" + TextBox10.Text + "&mach7=" + TextBox11.Text + "&mach8=" + TextBox12.Text + "&mach9=" + TextBox13.Text + "&mach10=" + TextBox14.Text + "&mach11=" + TextBox15.Text)

        If result = "1" Then

            MessageBox.Show("Successfully Registered")

        ElseIf result = "0" Then

            MessageBox.Show("IThere was an error, please try again.")
        End If
        ' DataGridView2.Columns(1).Frozen = True

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
        fast()
        ' insidechat()
    End Sub

    'Dim listuser As New RichTextBox
    'Dim listuser1 As New RichTextBox
    'Dim listuser2, listuser3, listuser4, listuser5, listuser6, listuser7 As New RichTextBox
    'Dim listuser8, listuser9, listuser10, listuser11, listuser12, listuser13, listuser14 As New RichTextBox
    'Dim lst As New ListBox
    'Dim result, result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14

    'Sub insidechat()
    '    DataGridView2.Rows.Clear()
    '    '//DB project >>>  num-nam-date-plac-phon-mob-usr-lag-lth
    '    On Error Resume Next
    '    Form1.wClient.Encoding = Encoding.UTF8
    '    Form1.wClient.UseDefaultCredentials = True
    '    Form1.wClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials

    '    result = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren1")
    '    : result1 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren2")
    '    : result2 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren3")
    '    : result3 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren4")
    '    : result4 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren5")
    '    : result5 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren6")
    '    : result6 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren7")
    '    : result7 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren8")
    '    : result8 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren9")
    '    : result9 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren10")
    '    : result10 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren11")
    '    : result11 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren12")
    '    : result12 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren13")
    '    : result13 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren14")
    '    result14 = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=ren15")


    '    listuser.Clear()

    '    : listuser.Text = result & vbCrLf
    '    : listuser.Text = listuser.Text.Replace("####", vbCrLf)
    '    lstfrnds.Items.Clear()

    '    listuser1.Clear()

    '    : listuser1.Text = result1 & vbCrLf
    '    : listuser1.Text = listuser1.Text.Replace("####", vbCrLf)
    '    ListBox1.Items.Clear()

    '    listuser2.Clear()

    '    : listuser2.Text = result2 & vbCrLf
    '    : listuser2.Text = listuser2.Text.Replace("####", vbCrLf)
    '    ListBox2.Items.Clear()

    '    : listuser3.Clear() : listuser4.Clear() : listuser5.Clear() : listuser6.Clear() : listuser7.Clear()
    '    : listuser8.Clear() : listuser9.Clear() : listuser10.Clear() : listuser11.Clear() : listuser12.Clear()
    '    : listuser13.Clear() : listuser14.Clear()

    '    : listuser3.Text = result3 & vbCrLf : listuser4.Text = result4 & vbCrLf : listuser5.Text = result5 & vbCrLf
    '    : listuser6.Text = result6 & vbCrLf : listuser7.Text = result7 & vbCrLf

    '    : listuser8.Text = result8 & vbCrLf : listuser9.Text = result9 & vbCrLf : listuser10.Text = result10 & vbCrLf
    '    : listuser11.Text = result11 & vbCrLf : listuser12.Text = result12 & vbCrLf : listuser13.Text = result13 & vbCrLf
    '    : listuser14.Text = result14 & vbCrLf

    '    listuser3.Text = listuser3.Text.Replace("####", vbCrLf)
    '    : listuser4.Text = listuser4.Text.Replace("####", vbCrLf)
    '    : listuser5.Text = listuser5.Text.Replace("####", vbCrLf)
    '    : listuser6.Text = listuser6.Text.Replace("####", vbCrLf)
    '    : listuser7.Text = listuser7.Text.Replace("####", vbCrLf)
    '    : listuser8.Text = listuser8.Text.Replace("####", vbCrLf)
    '    : listuser9.Text = listuser9.Text.Replace("####", vbCrLf)
    '    : listuser10.Text = listuser10.Text.Replace("####", vbCrLf)
    '    : listuser11.Text = listuser11.Text.Replace("####", vbCrLf)
    '    : listuser12.Text = listuser12.Text.Replace("####", vbCrLf)
    '    : listuser13.Text = listuser13.Text.Replace("####", vbCrLf)
    '    : listuser14.Text = listuser14.Text.Replace("####", vbCrLf)
    '    : ListBox3.Items.Clear()
    '    : ListBox4.Items.Clear()
    '    : ListBox5.Items.Clear()
    '    : ListBox6.Items.Clear() : ListBox7.Items.Clear()
    '    : ListBox8.Items.Clear() : ListBox9.Items.Clear() : ListBox10.Items.Clear() : ListBox11.Items.Clear()
    '    : ListBox12.Items.Clear() : ListBox13.Items.Clear() : ListBox14.Items.Clear()

    '    : lstfrnds.Items.AddRange(listuser.Lines)
    '    : ListBox1.Items.AddRange(listuser1.Lines)
    '    : ListBox2.Items.AddRange(listuser2.Lines)
    '    : ListBox3.Items.AddRange(listuser3.Lines)
    '    : ListBox4.Items.AddRange(listuser4.Lines)
    '    : ListBox5.Items.AddRange(listuser5.Lines)
    '    : ListBox6.Items.AddRange(listuser6.Lines)
    '    : ListBox7.Items.AddRange(listuser7.Lines)
    '    : ListBox8.Items.AddRange(listuser8.Lines)
    '    : ListBox9.Items.AddRange(listuser9.Lines)
    '    : ListBox10.Items.AddRange(listuser10.Lines)
    '    : ListBox11.Items.AddRange(listuser11.Lines)
    '    : ListBox12.Items.AddRange(listuser12.Lines)
    '    : ListBox13.Items.AddRange(listuser13.Lines)
    '    : ListBox14.Items.AddRange(listuser14.Lines)
    '    For i = 0 To lstfrnds.Items.Count - 1
    '        lstfrnds.SetSelected(i, True)
    '        : ListBox1.SetSelected(i, True)
    '        : ListBox2.SetSelected(i, True)
    '        : ListBox3.SetSelected(i, True)
    '        : ListBox4.SetSelected(i, True)
    '        : ListBox5.SetSelected(i, True)
    '        : ListBox6.SetSelected(i, True)
    '        : ListBox7.SetSelected(i, True)
    '        : ListBox8.SetSelected(i, True)
    '        : ListBox9.SetSelected(i, True)
    '        : ListBox10.SetSelected(i, True)
    '        : ListBox11.SetSelected(i, True)
    '        : ListBox12.SetSelected(i, True)
    '        : ListBox13.SetSelected(i, True)
    '        ListBox14.SetSelected(i, True)
    '        Dim l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15
    '        l1 = lstfrnds.GetItemText(lstfrnds.SelectedItem)
    '        : l2 = ListBox1.GetItemText(ListBox1.SelectedItem)
    '        : l3 = ListBox2.GetItemText(ListBox2.SelectedItem)
    '        : l4 = ListBox3.GetItemText(ListBox3.SelectedItem)
    '        : l5 = ListBox4.GetItemText(ListBox4.SelectedItem)
    '        : l6 = ListBox5.GetItemText(ListBox5.SelectedItem)
    '        : l7 = ListBox6.GetItemText(ListBox6.SelectedItem)
    '        : l8 = ListBox7.GetItemText(ListBox7.SelectedItem)
    '        : l9 = lstfrnds.GetItemText(ListBox8.SelectedItem)
    '        : l10 = ListBox1.GetItemText(ListBox9.SelectedItem)
    '        : l11 = ListBox2.GetItemText(ListBox10.SelectedItem)
    '        : l12 = ListBox3.GetItemText(ListBox11.SelectedItem)
    '        : l13 = ListBox4.GetItemText(ListBox12.SelectedItem)
    '        : l14 = ListBox5.GetItemText(ListBox13.SelectedItem)
    '        : l15 = ListBox6.GetItemText(ListBox14.SelectedItem)
    '        Dim row = {l13, l14, l15, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l1}
    '        DataGridView2.Rows.Add(row)
    '    Next



    'End Sub
    Sub readdata()
        TextBox15.Text = autowrite.TextBox15.Text
        TextBox14.Text = autowrite.TextBox17.Text
        TextBox13.Text = autowrite.TextBox16.Text
        TextBox12.Text = autowrite.TextBox18.Text
        TextBox11.Text = autowrite.TextBox19.Text
        TextBox10.Text = autowrite.TextBox20.Text
        TextBox9.Text = autowrite.TextBox22.Text
        TextBox8.Text = autowrite.TextBox21.Text
        TextBox7.Text = autowrite.TextBox23.Text
        TextBox6.Text = autowrite.TextBox24.Text
        TextBox5.Text = autowrite.TextBox25.Text
        TextBox4.Text = autowrite.TextBox26.Text
        TextBox3.Text = autowrite.TextBox27.Text
        TextBox2.Text = autowrite.TextBox28.Text
        TextBox1.Text = autowrite.TextBox29.Text

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
        Dim result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=rentotal")
        ritxt.Clear()
        : ritxt.Text = result & vbCrLf
        : ritxt.Text = ritxt.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt.Text, vbCrLf & vbCrLf) = 0
            ritxt.Text = Replace(ritxt.Text, vbCrLf & vbCrLf, vbCrLf)
        Loop
        Dim col, col1, col2, col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15, col16 As New DataGridViewTextBoxColumn
        col.DataPropertyName = "PropertyName"
        col.HeaderText = "خلطات"
        col.Name = "name"
        DataGridView2.Columns.Add(col)
        col2.DataPropertyName = "PropertyName2"
        col2.HeaderText = "المكان"
        col2.Name = "date"
        DataGridView2.Columns.Add(col2)
        'DataGridView1.Columns(1).Width = 450
        col3.DataPropertyName = "PropertyName3"
        col3.HeaderText = "لودار"
        col3.Name = "place"
        DataGridView2.Columns.Add(col3)
        DataGridView2.Columns(2).Width = 250
        col4.DataPropertyName = "PropertyName4"
        col4.HeaderText = "حفار"
        col4.Name = "phone"
        DataGridView2.Columns.Add(col4)
        DataGridView2.Columns(3).Width = 350
        col5.DataPropertyName = "PropertyName5"
        col5.HeaderText = "أوناش"
        col5.Name = "mob"
        DataGridView2.Columns.Add(col5)
        DataGridView2.Columns(4).Width = 150
        col6.DataPropertyName = "PropertyName6"
        col6.HeaderText = "نقالات"
        col6.Name = "user"
        DataGridView2.Columns.Add(col6)
        col7.DataPropertyName = "PropertyName7"
        col7.HeaderText = "مأتورة"
        col7.Name = "lang"
        DataGridView2.Columns.Add(col7)
        DataGridView2.Columns(6).Width = 250
        col8.DataPropertyName = "PropertyName8"
        col8.HeaderText = "جرارات"
        col8.Name = "lth1"
        DataGridView2.Columns.Add(col8)
        col9.DataPropertyName = "PropertyName9"
        col9.HeaderText = "جرايدار"
        col9.Name = "lth2"
        DataGridView2.Columns.Add(col9)
        col10.DataPropertyName = "PropertyName10"
        col10.HeaderText = "بلدوزار"
        col10.Name = "lth3"
        DataGridView2.Columns.Add(col10)
        col11.DataPropertyName = "PropertyName11"
        col11.HeaderText = "فناطيس"
        col11.Name = "lth4"
        DataGridView2.Columns.Add(col11)
        col12.DataPropertyName = "PropertyName12"
        col12.HeaderText = "هزازات"
        col12.Name = "lth5"
        DataGridView2.Columns.Add(col12)
        col13.DataPropertyName = "PropertyName13"
        col13.HeaderText = "الاسم"
        col13.Name = "lth6"
        DataGridView2.Columns.Add(col13)
        col14.DataPropertyName = "PropertyName14"
        col14.HeaderText = "الهاتف"
        col14.Name = "lth7"
        DataGridView2.Columns.Add(col14)
        col15.DataPropertyName = "PropertyName15"
        col15.HeaderText = "الموبيل"
        col15.Name = "lth8"
        DataGridView2.Columns.Add(col15)
        col16.DataPropertyName = "PropertyName16"
        col16.HeaderText = "التاريخ"
        col16.Name = "lth9"
        DataGridView2.Columns.Add(col16)

        For i As Integer = 0 To ritxt.Lines.Length - 1

            Dim row = ritxt.Lines(i) & If(i < ritxt.Lines.Length - 1, Environment.NewLine, "")
            cellvalue = row.Split(","c) 'check what is ur separator
            If IsFlagFound Then
                '    For l = 0 To cellvalue.Length - 1
                '        NewColName = Trim(cellvalue(l))
                '        NewColName = NewColName.Replace(vbNewLine, Nothing)
                '        DataGridView2.Columns.Add(NewColName, NewColName)

                '    Next
                '    IsFlagFound = False
                'Else

                DataGridView2.Rows.Add(cellvalue)
                '                DataGridView2.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))

            End If

        Next
        Label17.Text = DataGridView2.RowCount - 2

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
    Private Sub Form6_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry


        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())

        dak.UpdateTextPosition(Me)
        fast()
        readdata()
        Dim send As Integer
        dak.check(send)
        ' insidechat()
    End Sub
    Public Shared g As String
    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

    End Sub
    Private Sub DataGridView1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridView2.RowPrePaint

        'DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        Dim c As Color = Color.Gray
        For Each row As DataGridViewRow In DataGridView2.Rows
            row.DefaultCellStyle.BackColor = c
            c = If(c = Color.Gray, Color.DarkGray, Color.Gray)
            DataGridView2.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.LightBlue
            ' End
        Next

    End Sub
    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellMouseEnter

        If e.RowIndex > -1 Then
            '  
            If DataGridView2.Rows(e.RowIndex).Selected = True Then
                DataGridView2.RowsDefaultCellStyle.SelectionBackColor = Color.DarkOrange
            End If
        End If
    End Sub
    Private Sub DataGridView1_CellMouseLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellMouseLeave
        DataGridView2.RowsDefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub
    Private Sub DataGridView2_MouseLeave(sender As Object, e As System.EventArgs) Handles DataGridView2.MouseLeave
        DataGridView2.ScrollBars = ScrollBars.None
    End Sub

    Private Sub DataGridView2_MouseHover(sender As Object, e As System.EventArgs) Handles DataGridView2.MouseHover
        DataGridView2.ScrollBars = ScrollBars.Both
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        fast()
    End Sub

    'Private Sub Form6_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
    '    '709; 452
    '911; 496
    'Me.DataGridView2.Width = Me.Width - 202  '962; 506  826; 465
    'Me.DataGridView2.Height = Me.Height - 44 '962; 506  826; 465


    'Label16     810; 4
    'Label17     762; 4
    'Label1       791; 24
    'TextBox1   739; 40
    'Label10      788; 59
    'TextBox2   742; 75
    'Label11      785; 98
    'TextBox3    742; 114
    'Label12      791; 136
    'TextBox4   742; 152
    'Label2       834; 172
    'Label3       747; 172
    'TextBox6   815; 188
    'TextBox5   742; 188
    'Label4       834; 208
    'Label5       747; 208
    'TextBox8   814; 226
    'TextBox7   742; 226
    'Label6       831; 249
    'Label7       747; 249
    'TextBox10   815; 264
    'TextBox9    742; 265
    'Label9        834; 287
    'Label8        750; 287
    'TextBox12  813; 303
    'TextBox11  742; 303
    'Label14      834; 334
    'Label13       750; 334
    'TextBox14   815; 350
    'TextBox13   742; 350
    'Label15       791; 366
    'TextBox15   742; 382
    'Button2       739; 408
    'Button1       739; 434 
    'Label1.Location = New Point(Me.Width - (904 - 791), Label1.Location.Y)  '962; 506  848; 1
    'Label2.Location = New Point(Me.Width - (904 - 834), Label2.Location.Y)
    'Label3.Location = New Point(Me.Width - (904 - 747), Label3.Location.Y)
    'Label4.Location = New Point(Me.Width - (904 - 834), Label4.Location.Y)
    'Label5.Location = New Point(Me.Width - (904 - 747), Label5.Location.Y)
    'Label6.Location = New Point(Me.Width - (904 - 831), Label6.Location.Y)
    'Label7.Location = New Point(Me.Width - (904 - 747), Label7.Location.Y)
    'Label8.Location = New Point(Me.Width - (904 - 750), Label8.Location.Y)
    'Label9.Location = New Point(Me.Width - (904 - 834), Label9.Location.Y)
    'Label10.Location = New Point(Me.Width - (904 - 788), Label10.Location.Y)
    'Label11.Location = New Point(Me.Width - (904 - 785), Label11.Location.Y)
    'Label12.Location = New Point(Me.Width - (904 - 834), Label12.Location.Y)
    'Label13.Location = New Point(Me.Width - (904 - 750), Label13.Location.Y)
    'Label14.Location = New Point(Me.Width - (904 - 834), Label14.Location.Y)
    'Label15.Location = New Point(Me.Width - (904 - 747), Label15.Location.Y)
    '    Label16.Location = New Point(Me.Width - (904 - 747), Label16.Location.Y)
    '    Label17.Location = New Point(Me.Width - (904 - 747), Label17.Location.Y)


    '    TextBox1.Location = New Point(Me.Width - (904 - 739), TextBox1.Location.Y)
    '    TextBox2.Location = New Point(Me.Width - (904 - 739), TextBox2.Location.Y)
    '    TextBox3.Location = New Point(Me.Width - (904 - 739), TextBox3.Location.Y)
    '    TextBox4.Location = New Point(Me.Width - (904 - 739), TextBox4.Location.Y)
    '    TextBox5.Location = New Point(Me.Width - (904 - 739), TextBox5.Location.Y)
    '    TextBox6.Location = New Point(Me.Width - (904 - 815), TextBox6.Location.Y)
    '    TextBox7.Location = New Point(Me.Width - (904 - 739), TextBox7.Location.Y)
    '    TextBox8.Location = New Point(Me.Width - (904 - 815), TextBox8.Location.Y)
    '    TextBox9.Location = New Point(Me.Width - (904 - 739), TextBox9.Location.Y)
    '    TextBox10.Location = New Point(Me.Width - (904 - 815), TextBox10.Location.Y)
    '    TextBox11.Location = New Point(Me.Width - (904 - 739), TextBox11.Location.Y)
    '    TextBox12.Location = New Point(Me.Width - (904 - 815), TextBox12.Location.Y)
    '    TextBox13.Location = New Point(Me.Width - (904 - 739), TextBox13.Location.Y)
    '    TextBox14.Location = New Point(Me.Width - (904 - 815), TextBox14.Location.Y)
    '    TextBox15.Location = New Point(Me.Width - (904 - 739), TextBox15.Location.Y)

    '    Button1.Location = New Point(Me.Width - (904 - 739), Button1.Location.Y)  '962; 506  834; 425
    '    Button2.Location = New Point(Me.Width - (904 - 739), Button2.Location.Y) '962; 506  834; 394
    'End Sub

    Private Sub TextBox14_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox14.TextChanged

    End Sub
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
            TextBox2.Text = "الهاتف"
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
            TextBox4.Text = "المكان"
            TextBox4.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox5_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.GotFocus
        TextBox5.Text = ""
        TextBox5.ForeColor = Color.Black
    End Sub
    Private Sub TextBox5_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus
        If TextBox5.Text = "" Then
            TextBox5.Text = "لودار"
            TextBox5.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox6_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.GotFocus
        TextBox6.Text = ""
        TextBox6.ForeColor = Color.Black
    End Sub
    Private Sub TextBox6_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus
        If TextBox6.Text = "" Then
            TextBox6.Text = "حفار"
            TextBox6.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox7_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.GotFocus
        TextBox7.Text = ""
        TextBox7.ForeColor = Color.Black
    End Sub
    Private Sub TextBox7_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.LostFocus
        If TextBox7.Text = "" Then
            TextBox7.Text = "اوناش"
            TextBox7.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox8_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.GotFocus
        TextBox8.Text = ""
        TextBox8.ForeColor = Color.Black
    End Sub
    Private Sub TextBox8_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.LostFocus
        If TextBox8.Text = "" Then
            TextBox8.Text = "نقــالات"
            TextBox8.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox9_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.GotFocus
        TextBox9.Text = ""
        TextBox9.ForeColor = Color.Black
    End Sub
    Private Sub TextBox9_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.LostFocus
        If TextBox9.Text = "" Then
            TextBox9.Text = "مأتورة"
            TextBox9.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBox10_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.GotFocus
        TextBox10.Text = ""
        TextBox10.ForeColor = Color.Black
    End Sub
    Private Sub TextBox10_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.LostFocus
        If TextBox10.Text = "" Then
            TextBox10.Text = "جرارات"
            TextBox10.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox11_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.GotFocus
        TextBox11.Text = ""
        TextBox11.ForeColor = Color.Black
    End Sub
    Private Sub TextBox11_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.LostFocus
        If TextBox11.Text = "" Then
            TextBox11.Text = "جريدار"
            TextBox11.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox12_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.GotFocus
        TextBox12.Text = ""
        TextBox12.ForeColor = Color.Black
    End Sub
    Private Sub TextBox12_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.LostFocus
        If TextBox12.Text = "" Then
            TextBox12.Text = "بلدوزار"
            TextBox12.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox13_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.GotFocus
        TextBox13.Text = ""
        TextBox13.ForeColor = Color.Black
    End Sub
    Private Sub TextBox13_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.LostFocus
        If TextBox13.Text = "" Then
            TextBox13.Text = "فناطيس"
            TextBox13.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox14_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.GotFocus
        TextBox14.Text = ""
        TextBox14.ForeColor = Color.Black
    End Sub
    Private Sub TextBox14_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.LostFocus
        If TextBox14.Text = "" Then
            TextBox14.Text = "هزازات"
            TextBox14.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub TextBox15_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.GotFocus
        TextBox15.Text = ""
        TextBox15.ForeColor = Color.Black
    End Sub
    Private Sub TextBox15_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox15.LostFocus
        If TextBox15.Text = "" Then
            TextBox15.Text = "خلطات"
            TextBox15.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub mokawlat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        main.Enabled = False
    End Sub

    Private Sub mokawlat_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SaveFormSize(Me)  'Get to save  size & Position of Form in Registry

        main.Enabled = True
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
            IO.File.WriteAllText("C:\mokawalat\database\rentmachine.busin", text.ToString())

        End If
    End Sub

    Private Sub fileopen_Click(sender As System.Object, e As System.EventArgs) Handles fileopen.Click
        GetCsvData("C:\mokawalat\database\rentmachine.busin")

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
        html.saveashtml(DataGridView2, "C:\mokawalat\browser\Rentmachine" & DateTime.Today.ToString("dd-MMM-yyyy") & ".html")
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
    Private Sub form6_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
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