 
Imports System.Threading
Imports System.Net.NetworkInformation
Imports System.IO
Imports System.Net

Public Class Form10000
    Dim i As Integer
    Dim g As Integer
    Dim theard As System.Threading.Thread
    Dim theard1 As System.Threading.Thread
    Dim wClient As New WebClient
    Private Sub mison1()
        Do Until i = 10000
            i = i + 1
            Label1.Text = i
            main.Refresh()
        Loop
        If i = 1000 Then

            i = 0
            theard = New System.Threading.Thread(AddressOf mison1)
            theard.Start()

            Return
        End If
    End Sub
    Private Sub mison2(ByVal state As Object)

        Try
            Dim resultm As String = wClient.DownloadString("http://ebank.esy.es/makwalat.php?action=numver")

            Label3.Text = "Online:  " + resultm
        Catch ex As Exception
            '  MessageBox.Show(ex.Message)
            MsgBox("Your Internet Is closed")
            Label3.Text = "Online:  "
        End Try

    End Sub
    Dim th As System.Threading.Timer
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ' theard = New System.Threading.Thread(AddressOf mison1)

        ' th = New System.Threading.Timer(AddressOf mison1)

        'theard.Start()


    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        theard1 = New System.Threading.Thread(AddressOf mison2)
        theard1.Start()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SaveFormSize(Me)  'Get to save  size & Position of Form in Registry

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry

         

        For i = 1 To 20
            Chart1.Series(0).Points.AddXY(i, i ^ 2)
        Next


        Control.CheckForIllegalCrossThreadCalls = False
        Dim myCallback As New System.Threading.TimerCallback(AddressOf mison2)

        th = New System.Threading.Timer(myCallback, Nothing, 100, 10000)

    End Sub
     
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'Dim file As System.IO.StreamWriter
        'file = My.Computer.FileSystem.OpenTextFileWriter("C:\mokawalat\" & DateTime.Today.ToString("dd-MMM-yyyy") & ".txt", True)
        'file.WriteLine("Language Database Of Business Software")
        'file.Close()
        Dim strFile As String = "C:\mokawalat\" & DateTime.Today.ToString("dd-MMM-yyyy") & ".txt"
        Dim sw As StreamWriter
        Try
            If (Not file.Exists(strFile)) Then
                sw = file.CreateText(strFile)
                sw.WriteLine("Start Error Log for today")
            Else
                sw = file.AppendText(strFile)
            End If
            sw.WriteLine("Error Message in  Occured at-- " & DateTime.Now)
            sw.Close()
        Catch ex As IOException
            MsgBox("Error writing to log file.")
        End Try
    End Sub


















    Dim ToolTipProvider As New ToolTip

      
    Private Sub Chart1_MouseMove(sender As Object, e As MouseEventArgs)
        Dim h As Windows.Forms.DataVisualization.Charting.HitTestResult = Chart1.HitTest(e.X, e.Y)
        If h.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
            ToolTipProvider.SetToolTip(Chart1, h.Series.Points(h.PointIndex).XValue & " x " & h.Series.Points(h.PointIndex).YValues(0))
        End If
    End Sub


End Class