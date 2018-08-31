Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Net
Imports System.IO

Public Class Form11
    Dim wClient As New WebClient
    <DllImport("winmm.dll")> _
    Private Shared Function mciSendString(ByVal command As String, ByVal buffer As StringBuilder, ByVal bufferSize As Integer, ByVal hwndCallback As IntPtr) As Integer
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        
          Try
            Dim i As Integer
            i = mciSendString("open new type waveaudio alias capture", Nothing, 0, 0)
            i = mciSendString("set capture bitspersample 16", Nothing, 0, 0)
            i = mciSendString("set capture samplespersec 44100", Nothing, 0, 0)
            i = mciSendString("set capture channels 1", Nothing, 0, 0)
            i = mciSendString("record capture", Nothing, 0, 0)
            Label1.Text = "Recording"
            Label1.BackColor = Color.Green
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Dim n As String = Environment.UserName
    'Dim path As String = "C:\\SoundTest.wav"
    'Dim path2 As String = "C:\Users\Ihab majdy\Desktop\mokawalat\chat\Aduio\send\SoundTest.wav"
    'Dim sp = Environment.GetFolderPath(Environment.SpecialFolder.CommonTemplates)
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim i As Integer
            ' i = mciSendString("save capture " & "C:\" + fileName, Nothing, 0, 0)
            i = mciSendString("stop capture", Nothing, 0, 0)
            i = mciSendString("save capture C:\mokawalat\chat\Aduio\send\SoundTest.wav", Nothing, 0, IntPtr.Zero)

            i = mciSendString("close capture", Nothing, 0, 0)
            Label1.Text = "Idle"
            Label1.BackColor = Color.Yellow
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'Try
        '    If File.Exists(path) = False Then
        '        ' This statement ensures that the file is created,
        '        ' but the handle is not kept.
        '        Dim fs As FileStream = File.Create(path)
        '        fs.Close()
        '    End If

        '    ' Ensure that the target does not exist.
        '    If File.Exists(path2) Then
        '        File.Delete(path2)
        '    End If
        '    File.Move(path, path2)
        'Catch
        'End Try
    End Sub

    Private Sub mokawlat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry


        main.Enabled = False
        Dim ritxt As New TextBox

        Dim result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=reaudio")
        ListBox1.Items.Clear()
        : ritxt.Text = result & vbCrLf


        : ritxt.Text = ritxt.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt.Text, vbCrLf & vbCrLf) = 0
            ritxt.Text = Replace(ritxt.Text, vbCrLf & vbCrLf, vbCrLf)

        Loop
        For l As Integer = 0 To ritxt.Lines.Length - 1
            ListBox1.Items.Add(ritxt.Lines(l).ToString)
        Next
        Dim ritxt1 As New TextBox

        Dim result1 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=reaudiopath")
        ListBox2.Items.Clear()
        : ritxt1.Text = result1 & vbCrLf


        : ritxt1.Text = ritxt1.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt1.Text, vbCrLf & vbCrLf) = 0
            ritxt1.Text = Replace(ritxt1.Text, vbCrLf & vbCrLf, vbCrLf)

        Loop
        For l As Integer = 0 To ritxt1.Lines.Length - 1
            ListBox2.Items.Add(ritxt1.Lines(l).ToString)
        Next
    End Sub

    Private Sub mokawlat_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SaveFormSize(Me)  'Get to save  size & Position of Form in Registry

        main.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim ritxt As New TextBox

        Dim result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=reaudio")
        ListBox1.Items.Clear()
        : ritxt.Text = result & vbCrLf


        : ritxt.Text = ritxt.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt.Text, vbCrLf & vbCrLf) = 0
            ritxt.Text = Replace(ritxt.Text, vbCrLf & vbCrLf, vbCrLf)

        Loop
        For l As Integer = 0 To ritxt.Lines.Length - 1
            ListBox1.Items.Add(ritxt.Lines(l).ToString)
        Next
        Dim ritxt1 As New TextBox

        Dim result1 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=reaudiopath")
        ListBox2.Items.Clear()
        : ritxt1.Text = result1 & vbCrLf


        : ritxt1.Text = ritxt1.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt1.Text, vbCrLf & vbCrLf) = 0
            ritxt1.Text = Replace(ritxt1.Text, vbCrLf & vbCrLf, vbCrLf)

        Loop
        For l As Integer = 0 To ritxt1.Lines.Length - 1
            ListBox2.Items.Add(ritxt1.Lines(l).ToString)
        Next
        Dim tes As New StringBuilder()
        For l As Integer = 0 To ListBox1.Items.Count - 1
            tes.Append(ListBox1.Items(l))
            tes.AppendLine()
        Next
        IO.File.WriteAllText("C:\mokawalat\chat\Aduio\List.busin", tes.ToString())
        Dim tesr As New StringBuilder()
        For l As Integer = 0 To ListBox2.Items.Count - 1
            tesr.Append("http://ebank.esy.es/aduio/" & ListBox2.Items(l))
            tesr.AppendLine()
        Next
        IO.File.WriteAllText("C:\mokawalat\chat\Aduio\Listlink.busin", tesr.ToString())
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        'userjob()
        'username()
        'Name
        'tmpname()
        'Size
        'Dim result As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=insertchat&=" + path2)

        'If result = "1" Then

        '    MessageBox.Show("Successfully Registered")

        'ElseIf result = "0" Then

        '    MessageBox.Show("IThere was an error, please try again.")
        StartUpload("http://ebank.esy.es/aduio/", "C:\mokawalat\chat\Aduio\send\SoundTest.wav")
        'End If
        ' Dim result As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=upload&name=" + destinationFilePath + "&tmpname=" + sourceFilePath + "&size=" + sizeInBytes)
        My.Computer.Network.UploadFile("C:\mokawalat\chat\Aduio\send\SoundTest.wav", "http://ebank.esy.es/makwalat.php?action=upload&username=kmkmkmk" + "&userjob=5151")
        Dim ritxt As New TextBox

        Dim result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=reaudio")
        ListBox1.Items.Clear()
        : ritxt.Text = result & vbCrLf


        : ritxt.Text = ritxt.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt.Text, vbCrLf & vbCrLf) = 0
            ritxt.Text = Replace(ritxt.Text, vbCrLf & vbCrLf, vbCrLf)

        Loop
        For l As Integer = 0 To ritxt.Lines.Length - 1
            ListBox1.Items.Add(ritxt.Lines(l).ToString)
        Next
        Dim ritxt1 As New TextBox

        Dim result1 = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=reaudiopath")
        ListBox2.Items.Clear()
        : ritxt1.Text = result1 & vbCrLf


        : ritxt1.Text = ritxt1.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt1.Text, vbCrLf & vbCrLf) = 0
            ritxt1.Text = Replace(ritxt1.Text, vbCrLf & vbCrLf, vbCrLf)

        Loop
        For l As Integer = 0 To ritxt1.Lines.Length - 1
            ListBox2.Items.Add(ritxt1.Lines(l).ToString)
        Next
        Dim tes As New StringBuilder()
        For l As Integer = 0 To ListBox1.Items.Count - 1
            tes.Append(ListBox1.Items(l))
            tes.AppendLine()
        Next
        IO.File.WriteAllText("C:\mokawalat\chat\Aduio\List.busin", tes.ToString())
        Dim tesr As New StringBuilder()
        For l As Integer = 0 To ListBox2.Items.Count - 1
            tesr.Append("http://ebank.esy.es/aduio/" & ListBox2.Items(l))
            tesr.AppendLine()
        Next
        IO.File.WriteAllText("C:\mokawalat\chat\Aduio\Listlink.busin", tesr.ToString())
    End Sub
    Dim WithEvents client As New System.Net.WebClient()

    Public Sub StartUpload(ByVal targetUrl As String, ByVal filename As String)

        Dim uriString As New System.Uri(targetUrl)

        Me.client.UploadFileAsync(uriString, filename)

    End Sub

    Sub FileUploadCompleted(ByVal sender As Object, ByVal e As System.Net.UploadFileCompletedEventArgs) Handles client.UploadFileCompleted
        Dim response As String = System.Text.Encoding.ASCII.GetString(e.Result)
        MsgBox("complated")
        ' further process your response string
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox2.SelectedIndex = ListBox1.SelectedIndex
        TextBox1.Text = "http://ebank.esy.es/aduio/" & ListBox2.SelectedItem
        Dim fileName As String = ListBox2.SelectedItem
        Dim remoteUri As String = TextBox1.Text

        Dim myStringWebResource As String = Nothing
        Dim webRequest As HttpWebRequest = Net.WebRequest.Create(TextBox1.Text)
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
            localStream = File.Create("C:\mokawalat\chat\Aduio\receive\" & fileName)

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
        MsgBox("Download complate")
        My.Computer.Audio.Play("C:\mokawalat\chat\Aduio\receive\" + fileName)
        Dim myFile As New FileInfo("C:\mokawalat\chat\Aduio\receive\" + fileName)
        Dim sizeInBytes As Long = myFile.Length
        Label2.Text = sizeInBytes
        Label3.Text = "C:\mokawalat\chat\Aduio\receive\" + fileName
        Label4.Text = fileName
    End Sub
    
    
End Class