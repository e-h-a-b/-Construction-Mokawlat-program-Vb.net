Imports System.IO

Public Class html
    'Dim file As System.IO.StreamWriter
    'file = My.Computer.FileSystem.OpenTextFileWriter("C:\mokawalat\lang\English.ini", True)
    'file.WriteLine("Language Database Of Business Software")
    'file.Close()

    Public Shared Sub saveashtml(ByRef tb As DataGridView, ByVal strFile As String)
        On Error Resume Next
        Dim col1 As String
        Dim col2 As String

        Dim Count As Integer = 1


        Dim sw As StreamWriter
       
         
            If (Not File.Exists(strFile)) Then
                sw = File.CreateText(strFile)
                '  sw.WriteLine("Start Error Log for today")
            Else
                sw = File.AppendText(strFile)
            End If
 







        sw.WriteLine("<html>")
        sw.WriteLine("<style>")
        sw.WriteLine(" td, th {")
        sw.WriteLine("border: 1px solid black;text-align: left; padding: 8px;")
        sw.WriteLine("}")

        sw.WriteLine("table {")
        sw.WriteLine("border-collapse: collapse;border: 1px solid black;")
        sw.WriteLine("width: 100%;")
        sw.WriteLine("}th { background-color: #4CAF50;color: white;}")

        sw.WriteLine("th, td {")
        sw.WriteLine("text-align: left;padding: 8px;")
        sw.WriteLine("}tr:nth-child(even){background-color: #f2f2f2}")
        sw.WriteLine("</style>")
        sw.WriteLine("<body>")

        sw.WriteLine("<h2>THIS IS MAIN PIRCE OF BUSINESS PROJECT</h2>")
        sw.WriteLine("<p>great table and easy</p>")
        sw.WriteLine("<button onclick=" & Chr(34) & "myFunction()" & Chr(34) & ">Save As Pdf</button>")

        sw.WriteLine("<script>")
        sw.WriteLine("function myFunction() {")
        sw.WriteLine("    window.print();")
        sw.WriteLine("}")
        sw.WriteLine("</script>")
        sw.WriteLine("<table>")
        Dim text
        sw.WriteLine("<tr>")
        For v As Integer = 0 To tb.ColumnCount - 1
            'extracting cell value from 0 to 9 and add it on list

            text = tb.Columns(v).HeaderText

            If text = "" Then
            Else
                sw.WriteLine("<th>" & text & "</th>")
            End If
        Next
        sw.WriteLine("</tr>")

        For x As Integer = 0 To tb.Rows.Count - 1
            sw.WriteLine("<tr>")
            For v As Integer = 0 To tb.ColumnCount - 1
                'extracting cell value from 0 to 9 and add it on list

                text = tb.Rows(x).Cells(v).Value.ToString

                If text = "" Then
                Else
                    sw.WriteLine("<td>" & text & "</td>")
                End If
            Next
            sw.WriteLine("</tr>")
        Next
        sw.WriteLine("</table>")

        sw.WriteLine("</body>")
        sw.WriteLine("</html>")
        sw.Close()

        'End If
        'For i As Integer = 0 To tb.Rows.Count - 1


        '        For Each row As DataGridViewRow In tb.Rows

        '            If Not row.IsNewRow Then

        '                col1 = row.Cells(0).Value.ToString
        '                col2 = row.Cells(1).Value.ToString
        '                Dim sw As StreamWriter
        '                Try
        '                    If (Not File.Exists(strFile)) Then
        '                        sw = File.CreateText(strFile)
        '                        sw.WriteLine("Start Error Log for today")
        '                    Else
        '                        sw = File.AppendText(strFile)
        '                    End If
        '                    sw.WriteLine("<tr><td>" & col1 & " " & col2 & "</td></tr>")
        '                    sw.Close()
        '                Catch ex As IOException
        '                    MsgBox("Error writing to log file.")
        '                End Try

        '                Count = 0
        '            End If
        '        Next
        'Next
        'ElseIf Not Count = 5 Then

        '    For j As Integer = 0 To tb.Rows.Count - 1
        '        For Each row2 As DataGridViewRow In tb.Rows

        '            If Not row2.IsNewRow Then

        '                col1 = row2.Cells(0).Value.ToString
        '                col2 = row2.Cells(1).Value.ToString
        '                Dim sw As StreamWriter
        '                Try
        '                    If (Not File.Exists(strFile)) Then
        '                        sw = File.CreateText(strFile)
        '                        sw.WriteLine("Start Error Log for today")
        '                    Else
        '                        sw = File.AppendText(strFile)
        '                    End If
        '                    sw.WriteLine("<td>" & col1 & " " & col2 & "</td>")
        '                    sw.Close()
        '                Catch ex As IOException
        '                    MsgBox("Error writing to log file.")
        '                End Try


        '            End If
        '        Next
        '        Count = +1
        '    Next
        'End If


    End Sub

End Class
