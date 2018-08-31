Imports System.IO
Imports System.Text
Imports System.Net
Imports System.ComponentModel

Public Class SampleCallEveryXMinute

    Private WithEvents xTimer As New System.Windows.Forms.Timer
    Public Shared Wclient As New WebClient
    Public Shared Workers As New BackgroundWorker
    Public Sub New(TickValue As Integer)
        xTimer = New System.Windows.Forms.Timer
        xTimer.Interval = TickValue

    End Sub

    Public Sub StartTimer()
        xTimer.Start()
        'NumWorkers = NumWorkers + 1
        'ReDim Workers(NumWorkers)
        'Workers(NumWorkers) = New BackgroundWorker
        'Workers(NumWorkers).WorkerReportsProgress = True
        'Workers(NumWorkers).WorkerSupportsCancellation = True
        'AddHandler Workers(NumWorkers).DoWork, AddressOf WorkerDoWork
        'AddHandler Workers(NumWorkers).ProgressChanged, AddressOf WorkerProgressChanged
        'AddHandler Workers(NumWorkers).RunWorkerCompleted, AddressOf WorkerCompleted
        'Workers(NumWorkers).RunWorkerAsync()

    End Sub

    Public Sub StopTimer()
        xTimer.Stop()
    End Sub
    ' Private Workers() As BackgroundWorker

    'Private NumWorkers = 0
    'Public Shared Sub WorkerDoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
    '    ' Do some work

    'End Sub

    'Private Sub WorkerProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
    '    ' I did something!
    'End Sub

    'Private Sub WorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs)
    '    ' I'm done!
    'End Sub

    Private Sub Timer_Tick() Handles xTimer.Tick
        'Workers.RunWorkerAsync()
        SampleProcedure()
    End Sub

    Public Sub SampleProcedure()
        'SomeCodesHERE
        Try
            Dim ritxt As New TextBox

            'Remove Blank Lines

            ritxt.MaxLength = 99999999
            Wclient.Encoding = Encoding.UTF8

            Dim IsFlagFound As Boolean = True
            Dim NewColName As String
            Dim cellvalue(20) As String
            Dim result0 = Wclient.DownloadString("http://ebank.esy.es/makwalat.php?action=perdata")
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
            main.DataGridView2.AutoResizeRows( _
              DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders)
            'For i = 0 To DataGridView1.Columns.Count - 1
            '    If i <> 1 Then '//restricted columns, 'i' is Your column index
            '        DataGridView1.Columns(i).ReadOnly = True
            '    End If
            'Next
            Dim ro As DataGridViewRow
            Dim n1 As Integer = 0
            For Each ro In main.DataGridView2.Rows

                main.DataGridView2.Rows(n1).HeaderCell.Value = (1 + n1).ToString
                main.DataGridView2.RowHeadersWidth = 80
                n1 += 1
            Next
            main.GetCsvData("C:\mokawalat\main.busin")
        Catch

        End Try
    End Sub

End Class