Imports System.Net
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Text

Public Class Form12
    Public Function webDownloadImage(ByVal Url As String, Optional ByVal saveFile As Boolean = False, Optional ByVal location As String = "C:\") As Image

        Dim webClient As New System.Net.WebClient
        Dim bytes() As Byte = webClient.DownloadData(Url)
        Dim stream As New IO.MemoryStream(bytes)

        '  If saveFile Then My.Computer.FileSystem.WriteAllBytes(location, bytes, False)

        Return New System.Drawing.Bitmap(stream)

    End Function
    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click
        PictureBox1.Image = webDownloadImage(TextBox1.Text, True, "C:\temp.jpg")
        PictureBox2.Image = webDownloadImage(TextBox2.Text, True, "C:\temp.jpg")
        PictureBox3.Image = webDownloadImage(TextBox3.Text, True, "C:\temp.jpg")
        PictureBox4.Image = webDownloadImage(TextBox4.Text, True, "C:\temp.jpg")
        PictureBox5.Image = webDownloadImage(TextBox5.Text, True, "C:\temp.jpg")
        PictureBox6.Image = webDownloadImage(TextBox6.Text, True, "C:\temp.jpg")
        PictureBox7.Image = webDownloadImage(TextBox7.Text, True, "C:\temp.jpg")
        PictureBox8.Image = webDownloadImage(TextBox8.Text, True, "C:\temp.jpg")
        PictureBox9.Image = webDownloadImage(TextBox9.Text, True, "C:\temp.jpg")

    End Sub
    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click
        Dim tClient As WebClient = New WebClient
        Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(TextBox1.Text))) 'https://cache.eremnews.com/wp-content/uploads/2017/01/55555555-1.jpg")))'
        PictureBox9.Image = tImage
        Dim tImage1 As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(TextBox2.Text))) 'http://www.thaqafnafsak.com/wp-content/uploads/2014/10/%D8%A7%D9%84%D8%B4%D8%B1%D9%83%D8%A7%D8%AA-%D8%A7%D9%84%D9%85%D8%AA%D8%AD%D9%83%D9%85%D8%A9-%D9%81%D9%8A%D9%85%D8%A7-%D9%86%D8%A3%D9%83%D9%84%D8%8C-%D8%AB%D9%82%D9%81-%D9%86%D9%81%D8%B3%D9%83.jpg")))
        PictureBox1.Image = tImage1
        Dim tImage2 As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(TextBox3.Text))) 'http://www.ra2ed.com/big/261ltext.jpg")))
        PictureBox2.Image = tImage2
        Dim tImage3 As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(TextBox4.Text))) 'http://media.kenanaonline.com/photos/1173779/1173779092/large_1173779092.jpg")))
        PictureBox3.Image = tImage3
        Dim tImage4 As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(TextBox5.Text))) 'http://www.thaqafnafsak.com/wp-content/uploads/%D8%A3%D9%83%D8%A8%D8%B1-%D8%B4%D8%B1%D9%83%D8%A7%D8%AA-%D8%A7%D9%84%D8%AA%D9%82%D9%86%D9%8A%D8%A9-%D8%8C-%D8%AB%D9%82%D9%81-%D9%86%D9%81%D8%B3%D9%83-14.jpg")))
        PictureBox4.Image = tImage4
        Dim tImage5 As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(TextBox6.Text))) 'http://www.dekrisdesign.com/wp-content/uploads/2011/01/contemporary-home-office.jpg")))
        PictureBox5.Image = tImage5
        Dim tImage6 As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(TextBox7.Text))) 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSjmTasjRBoDnfih63PkqRnWcSiJV-646p3mB4ectDu4QQl2WemTQ")))
        PictureBox6.Image = tImage6
        Dim tImage7 As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(TextBox8.Text))) 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTLwWFLbEcQvOa-ebQcGXit62rJB1WjYjOgzn-DE04KexLapsw3")))
        PictureBox7.Image = tImage7
        Dim tImage8 As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(TextBox9.Text))) 'https://www.alsouria.net/sites/default/files/styles/img590x350/public/field/image/3-%D8%A7%D8%AC%D8%A7%D8%B2%D8%A7%D8%AA-%D8%A7%D8%B3%D8%AA%D9%8A%D8%B1%D8%A7%D8%AF-%D9%81%D9%8A-%D8%B7%D8%B1%D8%B7%D9%88%D8%B3-1024x681.jpg?itok=-zHysHWL")))
        PictureBox8.Image = tImage8



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
        'insertgallry
        'DB project >>>  num-nam-date-plac-phon-mob-usr
        Dim mac As String
        mac = getMacAddress()
        Label2.Text = main.g
        Dim result As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=insertgallry&macji=" + mac + "&numpic=" + Label2.Text + "&mac=" + mac + "&pic1=" + TextBox1.Text + "&pic2=" + TextBox2.Text + "&pic3=" + TextBox3.Text + "&pic4=" + TextBox4.Text + "&pic5=" + TextBox5.Text + "&pic6=" + TextBox6.Text + "&pic7=" + TextBox7.Text + "&pic8=" + TextBox8.Text + "&pic9=" + TextBox9.Text)

        If result = "1" Then

            MessageBox.Show("Successfully Registered")

        ElseIf result = "0" Then

            MessageBox.Show("IThere was an error, please try again.")
        End If
        'insidechat()
    End Sub
    Dim wClient As New System.Net.WebClient
    Dim n1, n2, n3, n4, n5, n6, n7, n8, n9, n10
    Dim result As String

    Sub fast()
        Label2.Text = main.g
        Dim ritxt As New RichTextBox
        Dim tex As New TextBox
        'Remove Blank Lines
        wClient.Encoding = Encoding.UTF8
        wClient.UseDefaultCredentials = True
        wClient.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
        Dim IsFlagFound As Boolean = True
        Dim NewColName As String
        Dim cellvalue(9) As String

        Dim result = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=readgallry&numpic=" + Label2.Text)
        ritxt.Clear()
        : ritxt.Text = result & vbCrLf
        : ritxt.Text = ritxt.Text.Replace("####", vbCrLf)
        Do Until InStr(ritxt.Text, vbCrLf & vbCrLf) = 0
            ritxt.Text = Replace(ritxt.Text, vbCrLf & vbCrLf, vbCrLf)
        Loop


        tex.Text = ritxt.Text.Replace(",", vbCrLf)
        For h = 0 To tex.Lines.Length - 1
            'ListBox1.Items.Add(TextBox1.Lines(h).ToString)
            TextBox1.Text = tex.Lines(0).ToString
            TextBox2.Text = tex.Lines(1).ToString
            TextBox3.Text = tex.Lines(2).ToString
            TextBox4.Text = tex.Lines(3).ToString
            TextBox5.Text = tex.Lines(4).ToString
            TextBox6.Text = tex.Lines(5).ToString
            TextBox7.Text = tex.Lines(6).ToString
            TextBox8.Text = tex.Lines(7).ToString
            TextBox9.Text = tex.Lines(8).ToString
        Next



    End Sub

    Private Sub Form12_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SaveFormSize(Me)  'Get to save  size & Position of Form in Registry

    End Sub

    Private Sub Form12_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry


        fast()
    End Sub

   
End Class