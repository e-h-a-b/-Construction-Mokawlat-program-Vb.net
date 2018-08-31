Imports System.Text
Public Class calculaction

    Private Sub Form5_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim text As New StringBuilder()
        For x As Integer = 0 To main.DataGridView2.Rows.Count - 1

            ComboBox1.Items.Add(main.DataGridView2.Rows(x).Cells(0).Value.ToString())

        Next

    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim x = ComboBox1.SelectedIndex
        Dim c = ComboBox2.SelectedIndex + 3
        Dim row = {main.DataGridView2.Rows(x).Cells(0).Value.ToString(), main.DataGridView2.Rows(x).Cells(1).Value.ToString(), main.DataGridView2.Rows(x).Cells(c).Value.ToString()}
        DataGridView1.Rows.Add(row)
    End Sub
    Private Sub CellValueChanged(ByVal sender As Object, _
    ByVal e As DataGridViewCellEventArgs) _
    Handles DataGridView1.CellValueChanged

        On Error Resume Next
        Dim iTax As Integer = 0
        Dim iTax1 As Integer = 0

        For index1 As Integer = 0 To DataGridView1.RowCount - 1
            If DataGridView1.Rows(index1).Cells(3).Value = Nothing Or DataGridView1.Rows(index1).Cells(2).Value = Nothing Then
                '  DataGridView1.Rows(index1).Cells(3).Value = 0
                '  DataGridView1.Rows(index1).Cells(2).Value = 0
                iTax1 = Convert.ToInt32(DataGridView1.Rows(index1).Cells(3).Value) * Convert.ToInt32(DataGridView1.Rows(index1).Cells(2).Value)
                DataGridView1.Rows(index1).Cells(4).Value = iTax1
            Else
                If DataGridView1.Rows(index1).Cells(0).Value = "طوب " Then
                    iTax1 = (Convert.ToInt32(DataGridView1.Rows(index1).Cells(3).Value) / 1000) * Convert.ToInt32(DataGridView1.Rows(index1).Cells(2).Value)
                    DataGridView1.Rows(index1).Cells(4).Value = iTax1
                Else
                    iTax1 = Convert.ToInt32(DataGridView1.Rows(index1).Cells(3).Value) * Convert.ToInt32(DataGridView1.Rows(index1).Cells(2).Value)
                    DataGridView1.Rows(index1).Cells(4).Value = iTax1
                End If

            End If
        Next
        For index As Integer = 0 To DataGridView1.RowCount - 1
            iTax += Convert.ToInt32(DataGridView1.Rows(index).Cells(4).Value)

        Next
        Label2.Text = iTax

    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        On Error Resume Next

        Dim c = 3
        For x As Integer = 0 To main.DataGridView2.RowCount - 1
            Dim row = {main.DataGridView2.Rows(x).Cells(0).Value.ToString(), main.DataGridView2.Rows(x).Cells(1).Value.ToString(), main.DataGridView2.Rows(x).Cells(c).Value.ToString()}
            DataGridView1.Rows.Add(row)
        Next
    End Sub
    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter

    End Sub
    Private Sub DataGridView1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridView1.RowPrePaint

        'DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
        Dim c As Color = Color.Gray
        For Each row As DataGridViewRow In DataGridView1.Rows
            row.DefaultCellStyle.BackColor = c
            c = If(c = Color.Gray, Color.DarkGray, Color.Gray)
            DataGridView1.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.LightBlue
            ' End
        Next

    End Sub
    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseEnter

        If e.RowIndex > -1 Then
            '  
            If DataGridView1.Rows(e.RowIndex).Selected = True Then
                DataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.DarkOrange
            End If
        End If
    End Sub
    Private Sub DataGridView1_CellMouseLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellMouseLeave
        DataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Orange
    End Sub
     
End Class