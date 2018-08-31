Imports System.Windows.Forms.DataGridViewLinkColumn
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Security
Imports System.Security.Principal
Imports System.Security.AccessControl
Imports Microsoft.Win32
Imports System.IO
Imports System.Threading

Public Class main
    Inherits System.Windows.Forms.Form
    Dim wClient As New System.Net.WebClient
    Private WithEvents conn As NetworkConnections
    Delegate Sub AddToList1Callback(ByVal ConnectionState As InternetConnectionState, ByVal IsStable As Boolean)
    Delegate Sub AddToList2Callback(ByVal ConnectionState As InternetConnectionState, ByVal IsStable As Boolean)
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
    Sub dag()
        If checkpaid = True And onoff = True Then

        Else



            Dim row = {"رمل", "م3", "10", "-", "-", "-", "43", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row)
            Dim row1 = {"زلط", "م3", "10", "-", "-", "-", "85", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row1)
            Dim row2 = {"طوب ", "1000 طوبة", "10", "-", "-", "-", "793", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row2)
            Dim row3 = {"أسمنت شيكارة", "50 كيلو", "10", "-", "-", "-", "40", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row3)
            Dim row4 = {" حفر ", "م3", "10", "-", "-", "-", "22", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row4)
            Dim row5 = {"ردم ", "م3", "10", "-", "-", "-", "13", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row5)
            Dim row6 = {"عزل ", "م2", "10", "-", "-", "-", "-", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row6)

            Dim row7 = {"صاج ", "م.ط", "10", "-", "-", "-", "70", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row7)
            Dim row8 = {" خرسانة جهزة ", "م3", "10", "-", "-", "-", "-", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row8)
            Dim row9 = {" السن ", "م3", "10", "-", "-", "-", "65", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row9)
            Dim row10 = {"الجبس ", "طن", "10", "-", "-", "-", "825", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row10)
            Dim row11 = {" الجير ", "م3", "10", "-", "-", "-", "1824", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row11)
            Dim row12 = {" حديد كريتال ", "م2", "10", "-", "-", "-", "185", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row12)
            Dim row13 = {"  بلاط مزايكو ", "م2", "10", "-", "-", "-", "-", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row13)

            Dim row14 = {"جيرنيت ", "م3", "10", "-", "-", "-", "-", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row14)
            Dim row15 = {"خشب ", "م3", "10", "-", "-", "-", "-", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row15)
            Dim row16 = {"مواسير ", "م", "10", "-", "-", "-", "-", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row16)
            Dim row17 = {"دهانات ", "م2", "10", "-", "-", "-", "-", "-", "-", "-", "-", "اضاف"}
            DataGridView2.Rows.Add(row17)
        End If
    End Sub
    Sub fast()
        Dim ritxt As New TextBox

        'Remove Blank Lines
         
        ritxt.MaxLength = 99999999
        wClient.Encoding = Encoding.UTF8
        
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
        If (Not System.IO.File.Exists("C:\mokawalat\main.busin")) Then

        Else

            System.IO.File.WriteAllText("C:\mokawalat\main.busin", "")
        End If
        For i As Integer = 0 To ritxt.Lines.Length - 1



            Dim row = ritxt.Lines(i) & If(i < ritxt.Lines.Length - 1, Environment.NewLine, "")
            cellvalue = row.Split(","c) 'check what is ur separator
            'DataGridView2.Rows.Add(cellvalue)
            Dim sw As StreamWriter
            If (Not System.IO.File.Exists("C:\mokawalat\main.busin")) Then
                sw = System.IO.File.CreateText("C:\mokawalat\main.busin")
                '  sw.WriteLine("Start Error Log for today")
            Else

                sw = System.IO.File.AppendText("C:\mokawalat\main.busin")
            End If
            sw.WriteLine(ritxt.Lines(i))
            'Dim row = ritxt.Lines(i) & If(i < ritxt.Lines.Length - 1, Environment.NewLine, "")
            'cellvalue = row.Split(","c) 'check what is ur separator

            'DataGridView2.Rows.Add(cellvalue)
            'End If

            '                DataGridView1.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))
            sw.Close()


        Next

        'Else
        'For I = 0 To DataGridView2.RowCount - 1
        '    With DataGridView2
        '        .Rows(I).Cells(0).Value = cellvalue(0)
        '        .Rows(I).Cells(1).Value = cellvalue(1)
        '        .Rows(I).Cells(2).Value = cellvalue(2)
        '        .Rows(I).Cells(3).Value = cellvalue(3)
        '        .Rows(I).Cells(4).Value = cellvalue(4)
        '        .Rows(I).Cells(5).Value = cellvalue(5)
        '        .Rows(I).Cells(6).Value = cellvalue(6)
        '        .Rows(I).Cells(7).Value = cellvalue(7)
        '        .Rows(I).Cells(8).Value = cellvalue(8)
        '        .Rows(I).Cells(9).Value = cellvalue(9)
        '        .Rows(I).Cells(10).Value = cellvalue(10)
        '        .Rows(I).Cells(11).Value = cellvalue(11)
        '        .Rows(I).Cells(12).Value = cellvalue(12)
        '        .Rows(I).Cells(13).Value = cellvalue(13)
        '        .Rows(I).Cells(14).Value = cellvalue(14)
        '        .Rows(I).Cells(15).Value = cellvalue(15)
        '        .Rows(I).Cells(16).Value = cellvalue(16)
        '        .Rows(I).Cells(17).Value = cellvalue(17)
        '        .Rows(I).Cells(18).Value = cellvalue(18)
        '        .Rows(I).Cells(19).Value = cellvalue(19)
        '        .Rows(I).Cells(20).Value = cellvalue(20)
        '        .Rows(I).Cells(21).Value = cellvalue(21)
        '        .Rows(I).Cells(22).Value = cellvalue(22)
        '        .Rows(I).Cells(23).Value = cellvalue(23)
        '        .Rows(I).Cells(24).Value = cellvalue(24)
        '        .Rows(I).Cells(25).Value = cellvalue(25)
        '        .Rows(I).Cells(26).Value = cellvalue(26)
        '        .Rows(I).Cells(27).Value = cellvalue(27)
        '        .Rows(I).Cells(28).Value = cellvalue(28)
        '        .Rows(I).Cells(29).Value = cellvalue(29)
        '        .Rows(I).Cells(30).Value = cellvalue(30)
        '        .Rows(I).Cells(31).Value = cellvalue(31)
        '    End With
        'Next
        'End If
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
    'Public Sub CheckAssociation()
    '      'open program using ur extansion
    '      My.Computer.Registry.ClassesRoot.CreateSubKey(".bus").SetValue("", "Business", Microsoft.Win32.RegistryValueKind.String)

    '      My.Computer.Registry.ClassesRoot.CreateSubKey("Business\shell\open\command").SetValue("", Application.ExecutablePath & " ""%1"" ", Microsoft.Win32.RegistryValueKind.String)
    '      My.Computer.Registry.ClassesRoot.CreateSubKey("Business\DefaultIcon").SetValue("", Application.StartupPath & "\f0.ico")
    '      'createsubkey    HKEY_CLASSES_ROOT*\shell\Scan with Apro   >>>>> Value : "Scan with Apro"
    '      'createsubkey        HKEY_CLASSES_ROOT*\shell\Scan with Apro\command     >>>>> Value : "\"C:\\Apro.exe\" \"%1\""

    '      'to make m
    '      My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\*\shell\Open MK Business", "NoWorkingDirectory", "", Microsoft.Win32.RegistryValueKind.String)
    '      My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\*\shell\Open MK Business\command", "IsolatedCommand", Application.ExecutablePath & " ""%1"" ", Microsoft.Win32.RegistryValueKind.String)
    '      'on right click
    '      My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\*\shell\Open MK Business", "", "", Microsoft.Win32.RegistryValueKind.String)

    '      My.Computer.Registry.SetValue("HKEY_CLASSES_ROOT\*\shell\Open MK Business\command", "", Application.ExecutablePath & " ""%1"" ", Microsoft.Win32.RegistryValueKind.String)

    '      'open in perview panel explorer folder

    '      My.Computer.Registry.ClassesRoot.CreateSubKey(".bus").SetValue("Content Type", "text/plain", Microsoft.Win32.RegistryValueKind.String)
    '      My.Computer.Registry.ClassesRoot.CreateSubKey(".bus").SetValue("PerceivedType", "text", Microsoft.Win32.RegistryValueKind.String)
    '  End Sub

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        Call SaveFormSize(Me)  'Get to save  size & Position of Form in Registry
        Dim mac As String
        mac = getMacAddress()

        Dim result As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=removeiwer&macvr=" + mac)

    End Sub
    Dim ConnectionStat As InternetConnectionState
    Dim mac As String = getMacAddress()
    Dim th As System.Threading.Timer
    Sub download(ByVal url As String, ByVal path As String)
        On Error Resume Next
        Dim myStringWebResource As String = Nothing
        Dim webRequest As HttpWebRequest = Net.WebRequest.Create(url)
        webRequest.Method = "GET"
        webRequest.ContentType = "application/x-www-form-urlencoded"
        'webRequest.CookieContainer = Cookie

        Dim bytesProcessed As Integer = 0
        Dim remoteStream As Stream
        Dim localStream As Stream
        Dim response As WebResponse

        response = webRequest.GetResponse()
        If Not response Is Nothing Then
            remoteStream = response.GetResponseStream()
            localStream = System.IO.File.Create(path)

            'Declare buffer as byte array
            Dim myBuffer As Byte()
            'Byte array initialization 
            ReDim myBuffer(1024)


            Dim bytesRead As Integer
            bytesRead = remoteStream.Read(myBuffer, 0, 1024)
            Do While (bytesRead > 0)
                localStream.Write(myBuffer, 0, bytesRead)
                bytesProcessed += bytesRead
                bytesRead = remoteStream.Read(myBuffer, 0, 1024)
            Loop
            localStream.Close()
        End If
    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        'loginin.Show()
        On Error Resume Next

        optionlanarab.PerformClick()
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry
          System.IO.Directory.CreateDirectory("C:\mokawalat")
            System.IO.Directory.CreateDirectory("C:\mokawalat\chat")
            System.IO.Directory.CreateDirectory("C:\mokawalat\lang")
            System.IO.Directory.CreateDirectory("C:\mokawalat\database")
            System.IO.Directory.CreateDirectory("C:\mokawalat\setup")
            System.IO.Directory.CreateDirectory("C:\mokawalat\browser")
            System.IO.Directory.CreateDirectory("C:\mokawalat\Monthly")
            System.IO.Directory.CreateDirectory("C:\mokawalat\chat\Aduio")
            System.IO.Directory.CreateDirectory("C:\mokawalat\chat\Aduio\send")
            System.IO.Directory.CreateDirectory("C:\mokawalat\chat\Aduio\receive")
            System.IO.Directory.CreateDirectory("C:\mokawalat\Style")

        If (Not System.IO.File.Exists("C:\mokawalat\main.busin")) Then
            System.IO.File.CreateText("C:\mokawalat\main.busin")
        Else
            GetCsvData("C:\mokawalat\main.busin")

        End If
        Dim myCallback As New System.Threading.TimerCallback(AddressOf mison2)

        th = New System.Threading.Timer(myCallback, Nothing, 100, 10000)

        If checkpaid = True Then
            Dim fileEntries As String() = Directory.GetFiles("C:\mokawalat\lang", "*.ini")
            ' Process the list of .txt files found in the directory. '
            Dim fileName As String

            For Each fileName In fileEntries
                optionlan.DropDownItems.Add(Path.GetFileName(fileName))
            Next
        Else
        End If


        ' MenuStrip1.DropDownItems.Add(SubItem2)


        Control.CheckForIllegalCrossThreadCalls = False
        MenuStrip1.Renderer = New ToolStripProfessionalRenderer(New ColorTable())
        'For i = 0 To 100
        '    DataGridView1.Rows.Add()
        '    DataGridView1.Item(0, i).Value = ""
        '    DataGridView1.Item(1, i).Value = ""
        conn = New NetworkConnections
        BackgroundWorker1.RunWorkerAsync()
        Timer1.Start()
        ' InternetStatus.Text = "Internet Status :Connected"
        InternetStatus.ForeColor = Color.Lime
        Dim mac As String
        mac = getMacAddress()

        ToolStripMenuItem2.Text = "Your Mac :" + mac
        ' readtxt()
        'Next
        ToolStripMenuItem1.ForeColor = Color.Lime

        If mac = "" Then
            MsgBox("sorry your mac hidden")
            Me.Close()

        End If

        'DB project >>>  num-nam-date-plac-phon-mob-usr
        Dim result As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=insertveiwer&macvr=" + mac + "&onuser=1" + "&offuser=0")


        Me.CenterToScreen()
        dak.UpdateTextPosition(Me)
        DataGridView2.RowHeadersWidth = 60

        'dag()

        DataGridView2.Columns(1).Frozen = True

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

        'Else

        '    Timer1.Stop()
        '    '  InternetStatus.Text = "Internet Status :disconnected"
        '    InternetStatus.ForeColor = Color.Red


        'End If




    End Sub
    Private Sub mison2(ByVal state As Object)
        If onoff = True Then
            If (Not System.IO.Directory.Exists("C:\mokawalat")) Then
                SetupToolStripMenuItem.Text = "Setup in C:\ Folder mokawalat"
                System.IO.Directory.CreateDirectory("C:\mokawalat")
                SetupToolStripMenuItem.Text = "Setup in C:\ browser Folder Html IN mokawalat "
                System.IO.Directory.CreateDirectory("C:\mokawalat\browser\")
                SetupToolStripMenuItem.Text = "Setup in C:\ Folder Chat IN mokawalat "
                System.IO.Directory.CreateDirectory("C:\mokawalat\chat")
                SetupToolStripMenuItem.Text = "Setup in C:\ Folder Lang IN mokawalat "
                System.IO.Directory.CreateDirectory("C:\mokawalat\lang")
                SetupToolStripMenuItem.Text = "Setup in C:\ Folder Database IN mokawalat "
                System.IO.Directory.CreateDirectory("C:\mokawalat\database")
                SetupToolStripMenuItem.Text = "Setup in C:\ Folder Setup IN mokawalat "
                System.IO.Directory.CreateDirectory("C:\mokawalat\setup")
                SetupToolStripMenuItem.Text = "Setup in C:\ Folder Monthly IN mokawalat "
                System.IO.Directory.CreateDirectory("C:\mokawalat\Monthly")
                SetupToolStripMenuItem.Text = "Setup in C:\ Folder Aduio IN mokawalat\chat "
                System.IO.Directory.CreateDirectory("C:\mokawalat\chat\Aduio")
                SetupToolStripMenuItem.Text = "Setup in C:\ Folder send IN mokawalat\chat\Aduio "
                System.IO.Directory.CreateDirectory("C:\mokawalat\chat\Aduio\send")
                SetupToolStripMenuItem.Text = "Setup in C:\ Folder receive IN mokawalat\chat\Aduio "
                System.IO.Directory.CreateDirectory("C:\mokawalat\chat\Aduio\receive")
                Dim path As String = "C:\mokawalat\Operations"
                ' or whatever 
                If Not System.IO.Directory.Exists(path) Then
                    Dim di As DirectoryInfo = Directory.CreateDirectory(path)
                    di.Attributes = FileAttributes.Directory Or FileAttributes.Hidden
                End If
                System.IO.Directory.CreateDirectory("C:\mokawalat\Style")
                'System.IO.File.Create("C:\mokawalat\setup\setup.reg").Dispose()
                SetupToolStripMenuItem.Text = "Setup Database "
                SetupToolStripMenuItem.Text = "Setup File company.busin in mokawalat\database "
                System.IO.File.Create("C:\mokawalat\database\company.busin").Dispose()
                SetupToolStripMenuItem.Text = "Setup File engineer.busin in mokawalat\database "
                System.IO.File.Create("C:\mokawalat\database\engineer.busin").Dispose()
                SetupToolStripMenuItem.Text = "Setup File worker.busin in mokawalat\database "
                System.IO.File.Create("C:\mokawalat\database\worker.busin").Dispose()
                SetupToolStripMenuItem.Text = "Setup File mokyasat.busin in mokawalat\database "
                System.IO.File.Create("C:\mokawalat\database\mokyasat.busin").Dispose()
                System.IO.File.Create("C:\mokawalat\Settings.ini").Dispose()
                System.IO.File.Create("C:\mokawalat\Autorun.ini").Dispose()
                System.IO.File.SetAttributes("C:\mokawalat\Autorun.ini", FileAttributes.Hidden)
                ' C:\Users\Ihab majdy\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup
                SetupToolStripMenuItem.Text = "Setup Folders Setup Correctly"
                'System.IO.File.Create("C:\mokawalat\lang\Arabic.ini").Dispose()
                'System.IO.File.Create("C:\mokawalat\lang\English.ini").Dispose()
                setup()
                arabic()
                english()
                System.IO.File.Create("C:\mokawalat\chat\chat.busin").Dispose()

            End If

            If (Not System.IO.File.Exists("C:\mokawalat\f0.ico")) Then
                SetupToolStripMenuItem.Text = "Setup Icon"
                download("http://download1525.mediafireuserdownload.com/ewlr0i1w3ejg/zfd72q1ts17l270/f0.ico", "C:\mokawalat\f0.ico")
                Thread.Sleep(60)
                SetupToolStripMenuItem.Text = "Setup Complate"
                SetupToolStripMenuItem.Text = "Status Setup : Done"
            End If
            If (Not System.IO.File.Exists("C:\mokawalat\setup\setup.reg")) Then
                SetupToolStripMenuItem.Text = "Setup Registry"
                download("http://download948.mediafireuserdownload.com/66zqg89y6wng/gggc2tlqt1p15tl/setup.reg", "C:\mokawalat\setup\setup.reg")
                SetupToolStripMenuItem.Text = "Setup Complate"
                SetupToolStripMenuItem.Text = "Status Setup : Done"
            End If
            If (Not System.IO.File.Exists("C:\mokawalat\lang\English.ini")) Or (Not System.IO.File.Exists("C:\mokawalat\lang\Arabic.ini")) Then
                SetupToolStripMenuItem.Text = "Setup Lang"
                download("http://download1320.mediafireuserdownload.com/qiw1nbddy3zg/8mrk1r16bxq9cuw/Arabic.ini", "C:\mokawalat\lang\Arabic.ini")
                SetupToolStripMenuItem.Text = "Setup Arabic Complate"
                download("http://download1513.mediafireuserdownload.com/ykf7ir6t42zg/1s6tibomftqjt7y/English.ini", "C:\mokawalat\lang\English.ini")
                SetupToolStripMenuItem.Text = "Setup English Complate"

                Thread.Sleep(100)
                SetupToolStripMenuItem.Text = "Status Setup : Done"
            End If

            Try
                ' fast()
                Dim resultm As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=numver")
                ToolStripMenuItem1.ForeColor = Color.Lime
                If rla = True Then
                    ToolStripMenuItem1.Text = "المتواجدين : " + resultm
                ElseIf rla = False Then
                    ToolStripMenuItem1.Text = "Online:  " + resultm
                End If
                Dim ritxt As New TextBox
                ritxt.MaxLength = 99999999
                wClient.Encoding = Encoding.UTF8
                wClient.UseDefaultCredentials = True
                wClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
                Dim IsFlagFound As Boolean = True
                Dim NewColName As String
                Dim cellvalue(20) As String
                Dim result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=readchat")
                ritxt.Clear()
                : ritxt.Text = result & vbCrLf
                : ritxt.Text = ritxt.Text.Replace("####", vbCrLf)
                Do Until InStr(ritxt.Text, vbCrLf & vbCrLf) = 0
                    ritxt.Text = Replace(ritxt.Text, vbCrLf & vbCrLf, vbCrLf)
                Loop
                RichTextBox1.Text = ritxt.Text
                For i As Integer = 0 To RichTextBox1.Lines.Length - 1
                    Dim Linez1 As Integer = RichTextBox1.GetFirstCharIndexFromLine(i)
                    RichTextBox1.[Select](Linez1, RichTextBox1.Lines(i).Length)
                    RichTextBox1.SelectionBackColor = If((i Mod 2 = 0), Color.Gray, Color.DimGray)
                Next

                Dim result1 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=reemd")
                Dim result2 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=recompany")
                Dim result3 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=reengineer")
                Dim result4 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=reworker")
                Dim result5 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=reproject")
                Dim result6 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=remokysah")
                Label2.Text = result2
                Label3.Text = result5
                Label5.Text = result3
                Label7.Text = result4
                Label9.Text = result1
                Label11.Text = result6
                Dim result7 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=checkvirsion")
                '   GetCsvData("C:\mokawalat\main.busin")
                Dim checkvirsio As String = "Business V1.0.3"
                If result7 = "V 1.0.3" Then
                    If rla = True Then
                        checkvirsion.Text = "أعمــال V 1.0.3" + " اخر تحديث"
                    ElseIf rla = False Then
                        checkvirsion.Text = "Business V 1.0.3" + " Last update"
                    End If

                Else
                    If rla = True Then
                        checkvirsion.Text = " يوجد نسخة جديدة حمل"

                    ElseIf rla = False Then
                        checkvirsion.Text = " check new virsion Download it"
                    End If

                End If

                Try
                    RichTextBox1.Select(RichTextBox1.GetFirstCharIndexFromLine(RichTextBox1.Lines.Length - 1),
                    RichTextBox1.Lines(RichTextBox1.Lines.Length - 1).Length)

                Catch ex As Exception
                End Try





            Catch ex As Exception
                ToolStripMenuItem1.ForeColor = Color.Red
                If rla = True Then

                    ToolStripMenuItem1.Text = "جاري الاتصال"
                ElseIf rla = False Then
                    ToolStripMenuItem1.Text = "Connecting..."
                End If
            End Try

        Else


            ToolStripMenuItem1.ForeColor = Color.Orange
            If rla = True Then
                ToolStripMenuItem1.Text = "غير مباشر"
            ElseIf rla = False Then
                ToolStripMenuItem1.Text = "offline"
            End If
        End If


    End Sub
    'Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    Me.Dispose()
    '    Dim mac As String
    '    mac = getMacAddress()
    '    Dim result As String = Form1.wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=removeiwer&macvr=" + mac)

    'End Sub
    Sub settings()

    End Sub
    Public Shared g As String
    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        If e.ColumnIndex = 11 Then
            Dim v As String = DataGridView2.Rows(e.RowIndex).Cells(0).Value
            g = e.RowIndex
            Form2.Show()
            dak.UpdateTextPosition(Form2)
        End If

        If e.ColumnIndex = 0 Then
            Dim v As String = DataGridView2.Rows(e.RowIndex).Cells(0).Value
            g = e.RowIndex
            Form2.Show()

        End If
        Form2.Label10.Text = g
    End Sub
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
    Sub resi()
        Me.DataGridView2.Width = Me.Width - 15   '962; 506  826; 465
        Me.DataGridView2.Height = Me.Height - 90 '962; 506  826; 465
        'Button1.Location = New Point(Me.Width - 128, Me.Height - 81)  '962; 506  834; 425
        'Button2.Location = New Point(Me.Width - 128, Me.Height - 112) '962; 506  834; 394
        'Button3.Location = New Point(Me.Width - 128, Me.Height - 143) '962; 506  834; 363
        'Button4.Location = New Point(Me.Width - 128, Me.Height - 174) '962; 506  834; 332
        'Button5.Location = New Point(Me.Width - (962 - 834), Button5.Location.Y) '962; 506  834; 332

        'Label01.Location = New Point(Me.Width - 114, 1)  '962; 506  848; 1
        'Label02.Location = New Point(Me.Width - 114, 17)  '962; 506  848; 17
        'Label03.Location = New Point(Me.Width - 114, 30)  '962; 506  848; 30
        'Label04.Location = New Point(Me.Width - 100, 43)  '962; 506  862; 43

        'Label1.Location = New Point(Me.Width - (962 - 834), Label1.Location.Y)
        'Label2.Location = New Point(Me.Width - (962 - 848), Label2.Location.Y)  '962; 506  862; 43
        'CheckBox1.Location = New Point(Me.Width - (962 - 848), CheckBox1.Location.Y)

        'Label09.Location = New Point(Me.Width - 128, 121)  '962; 506  834; 121
        ''label2       848; 173
        'label1       834; 160
        'checkbox1  848; 278
        'button5       834; 301
        If rla = True Then
            Panel1.Location = New Point(Me.Width - Me.Width, Me.Height - 255)
        ElseIf rla = False Then
            Panel1.Location = New Point(Me.Width - 405, Me.Height - 255)
        End If

    End Sub
    Private Sub Form1_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        resi()
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        offer.Show()
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = "Status : Check internet "
        ToolStripStatusLabel1.Text = "Status : Connect to DataBase"
        InternetStatus.Text = "Internet Status :Check"
        InternetStatus.ForeColor = Color.Lime
        conn = New NetworkConnections

        BackgroundWorker1.RunWorkerAsync()
        Form2.fast()
        monthly.fast()
        Form6.fast()
        offer.fast()
        Form8.fast()
        '  DataGridView1.Rows.Clear()


        Timer1.Stop()
        ToolStripStatusLabel1.Text = "Status : Done"

        '    Dim resultm As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=numver")

        '    ToolStripMenuItem1.Text = "Online:  " + resultm


        '    ToolStripStatusLabel1.Text = "Status : Sorry You Computer Not Connected to Internet"
        '    InternetStatus.Text = "Internet Status :disconnected"
        '    InternetStatus.ForeColor = Color.Red

    End Sub
    Private Sub PlaceOfProjectToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Newplace.Click
        Form8.Show()
    End Sub
    Private Sub EndClauseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles newendclause.Click
        offer.Show()
    End Sub
    Private Sub RentMachineToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles newrent.Click
        Form6.Show()
    End Sub
    Private Sub MonthlySubscriptionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles newmonthly.Click
        monthly.Show()
    End Sub
    Private Sub AutomaticWriteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles newautomatic.Click
        autowrite.Show()
    End Sub
    Private Sub AdminToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles AdminToolStripMenuItem1.Click
        admin.Show()
    End Sub
    Private Sub ConstructionCompanyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Databasecons.Click
        mokawlat.Show()
    End Sub
    Private Sub optionupdate_Click(sender As System.Object, e As System.EventArgs) Handles optionupdate.Click
        Timer1.Start()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles fileexit.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Dim rla As Boolean
    Private Sub ArabicToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles optionlanarab.Click
        rla = True
        Panel1.Location = New Point(Me.Width - Me.Width, Me.Height - 255)
        MenuStrip1.RightToLeft = Windows.Forms.RightToLeft.Yes
        DataGridView2.RightToLeft = Windows.Forms.RightToLeft.Yes
        File.Text = "ملف"
        NewTool.Text = "جديد"
        DataBase.Text = "قاعدة البيانات"
        OptionTool.Text = "خصائص"
        fileopen.Text = "فتح" : filesave.Text = "حفظ" : fileexit.Text = "خروج"
        Newplace.Text = "أماكن مشروعات" : newendclause.Text = "انهاء بنود" : newrent.Text = "تأجير معدات" : newmonthly.Text = "الاشتراك الشهري"
        : newperview.Text = "المعرض" : newautomatic.Text = "حفظ الادخالات" : newrecoredvoice.Text = "ارسال ملف صوتي"
        Databasecons.Text = "شركات المقاولات العامة" : Databaseengineer.Text = "المهندسين" : Databaseindustrial.Text = "العمال والصنيعية"
        optionlan.Text = "اللغة" : optionlanarab.Text = "العربية" : optionlanenglish.Text = "English"
        optionhelp.Text = "المساعدة"
        optionsettings.Text = "الاعدادات"
        optionupdate.Text = "تحديث" : optionupdatedata.Text = "تحديث البيانات" : optionupdateprogram.Text = "تحديث البرنامج"
        optionstyle.Text = "الوجهه"
        CalculationToolStripMenuItem.Text = "الاله الحاسبة"
        ClearToolStripMenuItem.Text = "حذف"
        KrokyToolStripMenuItem.Text = "رسم كروكي"
        UpdateToolStripMenuItem.Text = "تحديث البيانات"
        EveryHourToolStripMenuItem.Text = "تحديث كل ساعة"
        Every30SecToolStripMenuItem.Text = "تحديث كل نصف ساعة"
        Every1MinToolStripMenuItem.Text = "تحديث كل دقيقة"
        HideChatToolStripMenuItem.Text = "المحادثات"
        HideToolStripMenuItem.Text = "اخفاء"
        PerviewToolStripMenuItem.Text = "اظهار"
    End Sub
    Private Sub EnglishToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles optionlanenglish.Click
        rla = False
        Panel1.Location = New Point(Me.Width - 340, Me.Height - 255)

        MenuStrip1.RightToLeft = Windows.Forms.RightToLeft.No
        DataGridView2.RightToLeft = Windows.Forms.RightToLeft.No
        File.Text = "File"
        NewTool.Text = "New"
        DataBase.Text = "Data Base"
        OptionTool.Text = "Option"
        fileopen.Text = "Open" : filesave.Text = "Save" : fileexit.Text = "Exit"
        Newplace.Text = "Place of project" : newendclause.Text = "End of Clause" : newrent.Text = "Rent Machine" : newmonthly.Text = "Renew Sub monthly"
        : newperview.Text = "Gallery of Company" : newautomatic.Text = "Save Input" : newrecoredvoice.Text = "Send Voice File"
        Databasecons.Text = "Couns.. Public Company" : Databaseengineer.Text = "Engineer" : Databaseindustrial.Text = "Worker"
        optionlan.Text = "Langauge" : optionlanarab.Text = "العربية" : optionlanenglish.Text = "English"
        optionhelp.Text = "Help"
        optionsettings.Text = "Settings"
        optionupdate.Text = "Update" : optionupdatedata.Text = "Update Data" : optionupdateprogram.Text = "Update Program"
        optionstyle.Text = "Style"
        CalculationToolStripMenuItem.Text = "Calculation"
        ClearToolStripMenuItem.Text = "clear"
        KrokyToolStripMenuItem.Text = "Sketch"
        UpdateToolStripMenuItem.Text = "Update Data"
        EveryHourToolStripMenuItem.Text = "Every 60 Min"
        Every30SecToolStripMenuItem.Text = "Every 30 Min"
        Every1MinToolStripMenuItem.Text = "Every 1 Min"

        HideChatToolStripMenuItem.Text = "Chat"
        HideToolStripMenuItem.Text = "Hide"
        PerviewToolStripMenuItem.Text = "Perview"
    End Sub
    Sub arabic()
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\mokawalat\lang\Arabic.ini", True)
        file.WriteLine("Language Database Of Business Software")
        file.WriteLine("################")
        file.WriteLine("#Master Windows#")
        file.WriteLine("################")
        file.WriteLine("main.MenuStrip1=RightToLeft.Yes")
        file.WriteLine("main.DataGridView2=RightToLeft.Yes")
        file.WriteLine("main.File=ملف")
        file.WriteLine("main.NewTool=جديد")
        file.WriteLine("main.DataBase=قاعدة البيانات")
        file.WriteLine("main.OptionTool=خصائص")
        file.WriteLine("main.fileopen=فتح")
        file.WriteLine("main.filesave=حفظ")
        file.WriteLine("main.fileexit=خروج")
        file.WriteLine("main.Newplace=أماكن مشروعات")
        file.WriteLine("main.newendclause=انهاء بنود")
        file.WriteLine("main.newrent=تأجير معدات")
        file.WriteLine("main.newmonthly=الاشتراك الشهري")
        file.WriteLine("main.newperview=المعرض")
        file.WriteLine("main.newautomatic=حفظ الادخالات")
        file.WriteLine("main.newrecoredvoice=ارسال ملف صوتي")
        file.WriteLine("main.Databasecons=شركات المقاولات العامة")
        file.WriteLine("main.Databaseengineer=المهندسين")
        file.WriteLine("main.Databaseindustrial=العمال والصنيعية")
        file.WriteLine("main.optionlan=اللغة")
        file.WriteLine("main.optionlanarab=العربية")
        file.WriteLine("main.optionlanenglish=English")
        file.WriteLine("main.optionhelp=المساعدة")
        file.WriteLine("main.optionsettings=الاعدادات")
        file.WriteLine("main.optionupdate=تحديث")
        file.WriteLine("main.optionupdatedata=تحديث البيانات")
        file.WriteLine("main.optionupdateprogram=تحديث البرنامج")
        file.WriteLine("main.optionstyle=الوجهه")
        file.WriteLine("##################")
        file.WriteLine("#Engineer Windows#")
        file.WriteLine("##################")
        file.WriteLine("engineer.TextBox1=")
        file.WriteLine("engineer.TextBox2=")
        file.WriteLine("engineer.TextBox3=")
        file.WriteLine("engineer.TextBox4=")
        file.WriteLine("engineer.TextBox5=")
        file.WriteLine("engineer.TextBox6=")
        file.WriteLine("engineer.TextBox7=")
        file.WriteLine("engineer.TextBox8=")
        file.WriteLine("engineer.TextBox9=")
        file.WriteLine("engineer.TextBox10=")
        file.WriteLine("engineer.TextBox11=")
        file.WriteLine("engineer.TextBox12=")
        file.WriteLine("engineer.Button1=")
        file.WriteLine("engineer.Button2=")
        file.WriteLine("##################")
        file.Close()
    End Sub
    Sub english()
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\mokawalat\lang\English.ini", True)
        file.WriteLine("Language Database Of Business Software")
        file.WriteLine("################")
        file.WriteLine("#Master Windows#")
        file.WriteLine("################")
        file.WriteLine("main.MenuStrip1=RightToLeft.No")
        file.WriteLine("main.DataGridView2=RightToLeft.No")
        file.WriteLine("main.File=File")
        file.WriteLine("main.NewTool=New")
        file.WriteLine("main.DataBase=Data Base")
        file.WriteLine("main.OptionTool=Option")
        file.WriteLine("main.fileopen=Open")
        file.WriteLine("main.filesave=Save")
        file.WriteLine("main.fileexit=Exit")
        file.WriteLine("main.Newplace=Place of project")
        file.WriteLine("main.newendclause=End of Clause")
        file.WriteLine("main.newrent=Rent Machine")
        file.WriteLine("main.newmonthly=Renew Sub monthly")
        file.WriteLine("main.newperview=Gallery of Company")
        file.WriteLine("main.newautomatic=Save Input")
        file.WriteLine("main.newrecoredvoice=Send Voice File")
        file.WriteLine("main.Databasecons=Couns.. Public Company")
        file.WriteLine("main.Databaseengineer=Engineer")
        file.WriteLine("main.Databaseindustrial=Worker")
        file.WriteLine("main.optionlan=Langauge")
        file.WriteLine("main.optionlanarab=العربية")
        file.WriteLine("main.optionlanenglish=English")
        file.WriteLine("main.optionhelp=Help")
        file.WriteLine("main.optionsettings=Settings")
        file.WriteLine("main.optionupdate=Update")
        file.WriteLine("main.optionupdatedata=Update Data")
        file.WriteLine("main.optionupdateprogram=Update Program")
        file.WriteLine("main.optionstyle=Style")
        file.WriteLine("##################")
        file.WriteLine("#Engineer Windows#")
        file.WriteLine("##################")
        file.WriteLine("engineer.TextBox1=")
        file.WriteLine("engineer.TextBox2=")
        file.WriteLine("engineer.TextBox3=")
        file.WriteLine("engineer.TextBox4=")
        file.WriteLine("engineer.TextBox5=")
        file.WriteLine("engineer.TextBox6=")
        file.WriteLine("engineer.TextBox7=")
        file.WriteLine("engineer.TextBox8=")
        file.WriteLine("engineer.TextBox9=")
        file.WriteLine("engineer.TextBox10=")
        file.WriteLine("engineer.TextBox11=")
        file.WriteLine("engineer.TextBox12=")
        file.WriteLine("engineer.Button1=")
        file.WriteLine("engineer.Button2=")
        file.WriteLine("##################")
        file.Close()
    End Sub
    Sub setup()
        'Dim file As System.IO.StreamWriter
        'file = My.Computer.FileSystem.OpenTextFileWriter("C:\mokawalat\setup\setup.reg", True)
        'file.WriteLine("Windows Registry Editor Version 5.00")
        'file.WriteLine("""")
        'file.WriteLine("[HKEY_CLASSES_ROOT\.busin]")
        'file.WriteLine("@=" & Convert.ToChar(34) & Convert.ToChar(34))
        'file.WriteLine("[HKEY_CLASSES_ROOT\.busin\Business]")
        'file.WriteLine("@=" & Convert.ToChar(34) & Convert.ToChar(34))
        'file.WriteLine("[HKEY_CLASSES_ROOT\.busin\shell]")
        'file.WriteLine("@=" & Convert.ToChar(34) & Convert.ToChar(34))
        'file.WriteLine("[HKEY_CLASSES_ROOT\.busin\DefaultIcon]")
        'file.WriteLine("@=" & Convert.ToChar(34) & "C:\\mokawalat\\f0.ico" & Convert.ToChar(34))
        'file.WriteLine("[HKEY_CLASSES_ROOT\.busin\shell\Open MK Business]")
        'file.WriteLine("@=" & Chr(34) & Convert.ToChar(34))
        'file.WriteLine("[HKEY_CLASSES_ROOT\.busin\shell\Open MK Business\command]")
        'file.WriteLine("@=" & Convert.ToChar(34) & "C:\\mokawalat\\Mokawalat.exe" & Convert.ToChar(34))
        'file.Close()
    End Sub
    Private Sub conn_InternetConnectionStableChanged(IsStable As Boolean, ConnectionState As InternetConnectionState) Handles conn.InternetConnectionStableChanged
        AddToList1(ConnectionState, IsStable)
    End Sub
    Sub AddToList1(ByVal ConnectionState As InternetConnectionState, ByVal IsStable As Boolean)
        If Me.InvokeRequired = True Then
            Dim d As New AddToList1Callback(AddressOf AddToList1)
            Me.Invoke(d, ConnectionState, IsStable)

        Else
            ToolStripStatusLabel1.Text = Now & " - State: " & ConnectionState.ToString() & ", Stable: " & IsStable

        End If
        If ConnectionState = InternetConnectionState.Disconnected Then
            ToolStripStatusLabel1.Text = "Status : Done   Today :" & Now & " - State: " & ConnectionState.ToString() & ", Stable: " & IsStable

            InternetStatus.ForeColor = Color.Red
            InternetStatus.Text = "Status : Sorry You Computer Not Connected to Internet"
        Else

            InternetStatus.Text = "Status : Connected to DataBase"
            InternetStatus.ForeColor = Color.Lime
            ToolStripStatusLabel1.Text = "Status : Done   Today :" & Now & " - State: " & ConnectionState.ToString() & ", Stable: " & IsStable

        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        conn.StartMonitoring()

    End Sub
    Private Sub PerviewGalleryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles newperview.Click
        Form12.Show()
    End Sub
    Private Sub RecoredVoiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Form11.Show()
    End Sub
    Private Sub EngineerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Databaseengineer.Click
        engineer.Show()
    End Sub
    Private Sub IndustrialAndWorkersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Databaseindustrial.Click
        Worker.Show()
    End Sub
    Private Sub DataGridView1_MouseLeave(sender As Object, e As System.EventArgs) Handles DataGridView2.MouseLeave
        DataGridView2.ScrollBars = ScrollBars.None
        If HideToolStripMenuItem.Checked = True Then
            Panel1.Visible = False

        ElseIf PerviewToolStripMenuItem.Checked = True Then
            Panel1.Visible = True
        End If

    End Sub
    Private Sub DataGridView1_MouseHover(sender As Object, e As System.EventArgs) Handles DataGridView2.MouseHover
        DataGridView2.ScrollBars = ScrollBars.Both
        Panel1.Visible = False
    End Sub
    Private Sub mison3(ByVal state As Object)

        Try

        Catch

        End Try

    End Sub
    Dim macv As String
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'DB project >>>  num-nam-date-plac-phon-mob-usr
        'num,nam,rent,date,phon,mob,plac,mach1,mach2,mach3,mach4,mach5,mach6,mach7,mach8
        Dim nam As String = autowrite.TextBox46.Text
        macv = getMacAddress()



        Dim result As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=insertchat&macji=" + macv + "&alltext=" + TextBox1.Text)

        If result = "1" Then
            MessageBox.Show("Successfully Registered")
        ElseIf result = "0" Then
            MessageBox.Show("IThere was an error, please try again.")
        End If
        TextBox1.Text = ""
        mison2(RightToLeft)

    End Sub
    Private Sub optionhelp_Click(sender As System.Object, e As System.EventArgs) Handles optionhelp.Click
        Help.Show()
    End Sub

    Private Sub newrecoredvoice_Click(sender As System.Object, e As System.EventArgs) Handles newrecoredvoice.Click
        Form11.Show()
        Me.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Form11.Show()
        Me.Enabled = False
    End Sub

    Private Sub SetupToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SetupToolStripMenuItem.Click
        On Error Resume Next
        If checkpaid = True Then
            Process.Start("C:\mokawalat\setup\setup.reg")
        End If

    End Sub
    Public Sub GetCsvData(ByVal Filename As String)
        Dim IsFlagFound As Boolean = True
        Dim NewColName As String

        Dim rowvalue As String
        Dim cellvalue(20) As String
        Dim streamReader As IO.StreamReader = New IO.StreamReader(Filename)
        'Reading CSV file content 
        DataGridView2.Rows.Clear()

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
                '                DataGridView1.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))
                DataGridView2.Invalidate()
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
            System.IO.Directory.CreateDirectory("C:\mokawalat\browser")
            System.IO.Directory.CreateDirectory("C:\mokawalat\Monthly")
            System.IO.Directory.CreateDirectory("C:\mokawalat\chat\Aduio")
            System.IO.Directory.CreateDirectory("C:\mokawalat\chat\Aduio\send")
            System.IO.Directory.CreateDirectory("C:\mokawalat\chat\Aduio\receive")
            System.IO.Directory.CreateDirectory("C:\mokawalat\Style")
            Dim path As String = "C:\mokawalat\Operations"
            ' or whatever 
            If Not System.IO.Directory.Exists(path) Then
                Dim di As DirectoryInfo = Directory.CreateDirectory(path)
                di.Attributes = FileAttributes.Directory Or FileAttributes.Hidden
            End If
            If Not System.IO.File.Exists("C:\mokawalat\Autorun.ini") Then System.IO.File.SetAttributes("C:\mokawalat\Autorun.ini", FileAttributes.Hidden)

            System.IO.File.Create("C:\mokawalat\Settings.ini").Dispose()
            System.IO.File.Create("C:\mokawalat\setup\setup.reg").Dispose()
            System.IO.File.Create("C:\mokawalat\database\company.busin").Dispose()
            System.IO.File.Create("C:\mokawalat\database\engineer.busin").Dispose()
            System.IO.File.Create("C:\mokawalat\database\worker.busin").Dispose()
            System.IO.File.Create("C:\mokawalat\Monthly\monthly.busin").Dispose()
            System.IO.File.Create("C:\mokawalat\database\mokyasat.busin").Dispose()
            System.IO.File.Create("C:\mokawalat\database\project-place.busin").Dispose()
            System.IO.File.Create("C:\mokawalat\lang\Arabic.ini").Dispose()
            System.IO.File.Create("C:\mokawalat\lang\English.ini").Dispose()
            setup()
            arabic()
            english()
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
            IO.File.WriteAllText("C:\mokawalat\main.busin", text.ToString())
            DataGridView2.Rows.Clear()
            GetCsvData("C:\mokawalat\main.busin")
            Dim tes As New StringBuilder()
            For l As Integer = 0 To RichTextBox1.Lines.Length - 1
                tes.Append(RichTextBox1.Lines(l))
                tes.AppendLine()
            Next
            IO.File.WriteAllText("C:\mokawalat\chat\chat.busin", tes.ToString())

        End If

    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        DataGridView2.Rows.Clear()
        GetCsvData("C:\mokawalat\main.busin")
    End Sub

    Private Sub fileopen_Click(sender As System.Object, e As System.EventArgs) Handles fileopen.Click
        GetCsvData("C:\mokawalat\main.busin")
    End Sub

    Private Sub checkvirsion_Click(sender As System.Object, e As System.EventArgs) Handles checkvirsion.Click
        'WebClient does not support concurrent I/O operations.
        If wClient.IsBusy = False Then
            Dim result7 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=virsionlink")
            Dim result1 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=checkvirsion")

            Dim checkvirsio As String = "Business V1.0.3"
            If result1 = "V 1.0.3" Then
                MessageBox.Show("Last Update Virsion", "caption")
                'MessageBox.Show("There are New Virsion", "caption", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button3, 0, "https://www.google.com/maps/dir/30.5827541,32.2570957/30.5827541,32.2570957/@30.2805886,32.7579636,8z")
            Else
                MessageBox.Show("There are New Virsion", "caption", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button3, 0, result7)

            End If

        End If

    End Sub

    Private Sub HtmlToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HtmlToolStripMenuItem.Click
        html.saveashtml(DataGridView2, "C:\mokawalat\browser\mainPrice" & DateTime.Today.ToString("dd-MMM-yyyy") & ".html")
    End Sub
    Dim ad As Integer = 0
    Dim checkpaid As Boolean = False
    Dim onoff As Boolean = False
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    Function checkpaidnum(ByVal num As Double)
        GetRandom(0, 9)

        Dim A, B, C, D, E, F, G, H, I, J, K, L, M, N As Integer '020125345025=100
        If A + B + C + D + E + F + G + H + I + J + K + L + M + N = 100 Then
            If A = B + C Then A = 0
            If B = E + 2 Then B = 0
            If C = D + 4 Then C = 0
            If D = 0 Then D = 0
            If E = A + 5 Then E = 0
            If F = E + C Then F = 0
            If G = E + F Then G = 0
            If H = 12 Then H = 0

        End If


        Dim serial As Integer ' = A
        If num <> num Then

        Else

        End If
        Return checkpaid
    End Function
    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Dim startdate As DateTime = DateTime.Parse(Date.Now)
        Dim enddate As DateTime = DateTime.Parse("2017-10-03 18:00")
        Dim ts As TimeSpan = enddate.Subtract(startdate)
        Dim td As String
        checkpaidnum(1000)
        td = (Convert.ToInt32(ts.Days) & " Days, " & (Convert.ToInt32(ts.TotalHours - (24 * Convert.ToInt32(ts.Days)))).ToString & " hours, " & _
                           (Convert.ToInt32(ts.TotalMinutes - (60 * Convert.ToInt32(ts.TotalHours)))).ToString() & " min," & _
                           (Convert.ToInt32(ts.TotalSeconds - (60 * Convert.ToInt32(ts.TotalMinutes)))).ToString & "second")

        If checkpaid = True Then
            ' Me.Close()
            onoff = True

            Label13.Visible = False
            'DataGridView2.Size = New Point(DataGridView2.Width, Me.Height - 110)
            DataGridView2.Location = New Point(0, 27)
        Else
            Label13.Visible = True
            DataGridView2.Location = New Point(0, 46)


            onoff = False
            ad = ad + 2
            Label13.Location = New Point(ad, Label13.Location.Y)
            Label13.Text = "هذه النسخة مجانية اذا كنت ترغب بتطوير البرنامج فقم بضغط على الشريط"
            Label13.ForeColor = Color.Lime
            SetupToolStripMenuItem.ForeColor = Color.Lime
            If ad = 878 Then
                ad = 0
            End If
        End If
    End Sub

    Private Sub TtttToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TtttToolStripMenuItem.Click
        If checkpaid = True And onoff = True Then
            checkpaid = False
            onoff = False
            TtttToolStripMenuItem.Text = "Go to Online"
            TtttToolStripMenuItem.ForeColor = Color.Lime
        Else
            checkpaid = True
            onoff = True
            TtttToolStripMenuItem.Text = "Go to Offline"
            TtttToolStripMenuItem.ForeColor = Color.Orange

        End If
    End Sub

    Private Sub optionupdateprogram_Click(sender As System.Object, e As System.EventArgs) Handles optionupdateprogram.Click
        Dim result7 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=virsionlink")
        Dim result1 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=checkvirsion")

        Dim checkvirsio As String = "Business V1.0.2"
        If result1 = "V 1.0.2" Then
            MessageBox.Show("Last Update Virsion", "caption")

        Else
            MessageBox.Show("There are New Virsion", "caption", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button3, 0, result7)

        End If
    End Sub

    Private Sub HtmlToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles HtmlToolStripMenuItem1.Click
        Perviewhtml.Show()
        If (Not System.IO.Directory.Exists("C:\mokawalat\browser\")) Then
            System.IO.Directory.CreateDirectory("C:\mokawalat\browser\")
        End If
        Dim txtFiles = Directory.GetFiles("C:\mokawalat\browser\", "*.html", SearchOption.TopDirectoryOnly).
        [Select](Function(nm) Path.GetFileName(nm))

        For Each filenm As String In txtFiles
            Perviewhtml.ListBox1.Items.Add(filenm)

        Next
        '  

    End Sub
     
    Private Sub CalculationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CalculationToolStripMenuItem.Click
        calculaction.Show()
    End Sub

    Private Sub KrokyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles KrokyToolStripMenuItem.Click
        Sketch.Show()
    End Sub



    Dim nms As Integer = 60000
    Dim xSub As New SampleCallEveryXMinute(nms) ' 1000 ms = 1 sec so 60000 ms = 1 min

     
    Private Sub EveryHourToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EveryHourToolStripMenuItem.Click
        nms = 3600000
        EveryHourToolStripMenuItem.Checked = True
        Every30SecToolStripMenuItem.Checked = False
        Every1MinToolStripMenuItem.Checked = False
        xSub.StartTimer()
    End Sub

    Private Sub Every30SecToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Every30SecToolStripMenuItem.Click
        nms = 1800000
        EveryHourToolStripMenuItem.Checked = False
        Every30SecToolStripMenuItem.Checked = True
        Every1MinToolStripMenuItem.Checked = False
        xSub.StartTimer()
    End Sub

    Private Sub Every1MinToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Every1MinToolStripMenuItem.Click
        nms = 60000
        EveryHourToolStripMenuItem.Checked = False
        Every30SecToolStripMenuItem.Checked = False
        Every1MinToolStripMenuItem.Checked = True
        xSub.StartTimer()
    End Sub
     
    Private Sub HideToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HideToolStripMenuItem.Click
        Panel1.Visible = False
        HideToolStripMenuItem.Checked = True
        PerviewToolStripMenuItem.Checked = False
    End Sub

    Private Sub PerviewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PerviewToolStripMenuItem.Click
        Panel1.Visible = True
        HideToolStripMenuItem.Checked = False
        PerviewToolStripMenuItem.Checked = True
    End Sub

     
    Private Sub Label13_Click(sender As System.Object, e As System.EventArgs) Handles Label13.Click
        buy.Show()
    End Sub

    Private Sub UTMToETMToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UTMToETMToolStripMenuItem.Click
        surveyCroo.Show()
    End Sub
End Class
