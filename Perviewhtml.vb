Public Class Perviewhtml

    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Process.Start("C:\mokawalat\browser\" & ListBox1.SelectedItem)
    End Sub
End Class