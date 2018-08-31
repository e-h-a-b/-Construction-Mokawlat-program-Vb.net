Public Class map

    Private Sub map_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        WebKitBrowser1.Navigate("http://www.ebank.esy.es")
        ' WebKitBrowser1.Navigate("http://www.google.com/search?hl=en&source=hp&q=" & TextBox1.Text)
        'WebBrowser1.ScriptErrorsSuppressed = True
        'WebBrowser1.Document.parentWindow.execScript("helloWorld()", "JScript")
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ' WebKitBrowser1.Navigate("http://www.ebank.esy.es/map1.html")
        ' WebKitBrowser1.Navigate("http://www.ebank.esy.es")
        ' WebKitBrowser1.Navigate("http://www.google.com/search?hl=en&source=hp&q=" & TextBox1.Text)
        'WebKitBrowser1.GoForward()
         MessageBox.Show("There are New Virsion", "caption", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button3, 0, "https://www.google.com/maps/dir/" + TextBox1.Text + "/" + TextBox1.Text + "/@" + TextBox1.Text + ",8z")

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            WebKitBrowser1.Navigate(TextBox1.Text)
        End If
    End Sub

    Private Sub map_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        WebKitBrowser1.Width = Me.Width
        WebKitBrowser1.Height = Me.Height
    End Sub
End Class