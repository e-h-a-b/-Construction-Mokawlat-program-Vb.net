Imports System.Text

Public Class loginin

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        buy.Show()
    End Sub
    Private Sub Form3_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main.Visible = True
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        signup.Show()
    End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        Dim text As New StringBuilder()
        Dim s As String

        s = TextBox2.Text
        ' Name = Name.Replace("""", " ")


        text.Append(s & vbCrLf)
        text.Append(s & vbCrLf)
        text.Append(s & vbCrLf)
        text.Append(s & vbCrLf)
        text.Append(s & vbCrLf)
        text.Append(s & vbCrLf)
        text.Append(s & vbCrLf)
        text.Append(GetRandom(0, 10))
        text.AppendLine()

        IO.File.WriteAllText("C:\mokawalat\" & s & ".busin", text.ToString())
        '
        'Loop



    End Sub
End Class