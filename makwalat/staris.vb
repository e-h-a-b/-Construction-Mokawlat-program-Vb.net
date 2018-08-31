Public Class staris
    Dim by As New Bitmap(1000, 1000)
    Dim gdS As Graphics = Graphics.FromImage(by)


    Private Sub S20_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles S20.MouseDown

        Dim c As Integer = S3.Text
        Dim d As Integer = S4.Text
        S3.Text = e.X
        S4.Text = e.Y
        Dim a = e.X
        Dim b = e.Y
        S10.Text = S5.Text
        S9.Text = S6.Text
        Dim d1 As Integer = S5.Text
        Dim c1 As Integer = S6.Text

        Dim x1 As Integer = Math.Abs((c - a))
        Dim y1 As Integer = Math.Abs((d - b))
        S15.Text = x1
        S16.Text = y1

        S17.Text = S9.Text
        S18.Text = S10.Text

        If S7.Checked Then
            If S2.Text = 1 Then
                S2.Text = 0

                gdS.DrawLine(Pens.White, c + 10, d + 10, a + 10, b + 10)
                gdS.DrawLine(Pens.Green, c + 50, d, a + 50, b)
                gdS.FillEllipse(Brushes.Red, (c + c1) \ 2, (d + d1) \ 2, 5, 5)
                Dim dd As Integer = (c + c1) \ 2
                Dim xx As Integer = (d + d1) \ 2
                gdS.FillEllipse(Brushes.Green, (dd + c1) \ 2, (xx + d1) \ 2, 5, 5)
                gdS.FillEllipse(Brushes.Yellow, (dd + c) \ 2, (xx + d) \ 2, 5, 5)

                gdS.DrawLine(Pens.Red, c, d, (dd + c) \ 2, d)
                gdS.DrawLine(Pens.Orange, (dd + c) \ 2, (xx + d) \ 2, (dd + c) \ 2, d)
                gdS.DrawLine(Pens.Yellow, (dd + c) \ 2, (xx + d) \ 2, (c + c1) \ 2, (xx + d) \ 2)
                gdS.DrawLine(Pens.Green, (c + c1) \ 2, (d + d1) \ 2, (c + c1) \ 2, (xx + d) \ 2)
                gdS.DrawLine(Pens.Cyan, (c + c1) \ 2, (d + d1) \ 2, (dd + c1) \ 2, (d + d1) \ 2)

                gdS.DrawLine(Pens.Blue, (dd + c1) \ 2, (d + d1) \ 2, (dd + c1) \ 2, (xx + d1) \ 2)
                gdS.DrawLine(Pens.Brown, (dd + c1) \ 2, (xx + d1) \ 2, a, (xx + d1) \ 2)
                gdS.DrawLine(Pens.White, a, (xx + d1) \ 2, a, b)


                'Form1.DataGridView1.Rows.Add({ x,z, y, x1, z1, y1})


                'distance of mirror
                Dim q As Integer = 1000
                'height of mirror
                Dim ht As Integer = 100
                'length of block
                Dim qd As Integer = -700
                Dim cqd As Integer
                'intinal of block
                Dim int As Integer = -800
                'For i As Integer = 0 To 3
                cqd = 900
                qd += cqd + 100
                int += cqd + 100


                If ComboBox22.Text = "Stairs" Then
                    For i As Integer = 0 To Sketch.TextBox4.Text - 1
                        ht = ht + 100
                        Form1.DataGridView1.Rows.Add(int, -c + q, -d + ht, int, -(dd + c) \ 2 + q, -d + ht) 'red
                        Form1.DataGridView1.Rows.Add(int, -(dd + c) \ 2 + q, (-(xx + d) \ 2) + ht, int, -(dd + c) \ 2 + q, -d + ht) 'orange
                        Form1.DataGridView1.Rows.Add(int, -(dd + c) \ 2 + q, -(xx + d) \ 2 + ht, int, -(c + c1) \ 2 + q, -(xx + d) \ 2 + ht) 'yellow
                        Form1.DataGridView1.Rows.Add(int, -(c + c1) \ 2 + q, -(d + d1) \ 2 + ht, int, -(c + c1) \ 2 + q, -(xx + d) \ 2 + ht) 'green
                        Form1.DataGridView1.Rows.Add(int, -(c + c1) \ 2 + q, -(d + d1) \ 2 + ht, int, -(dd + c1) \ 2 + q, -(d + d1) \ 2 + ht) 'cyan
                        Form1.DataGridView1.Rows.Add(int, -(dd + c1) \ 2 + q, -(d + d1) \ 2 + ht, int, -(dd + c1) \ 2 + q, -(xx + d1) \ 2 + ht) 'blue
                        Form1.DataGridView1.Rows.Add(int, -(dd + c1) \ 2 + q, -(xx + d1) \ 2 + ht, int, -a + q, -(xx + d1) \ 2 + ht) 'brown
                        Form1.DataGridView1.Rows.Add(int, -a + q, -(xx + d1) \ 2 + ht, int, -a + q, -b + ht) 'white
                        Form1.DataGridView1.Rows.Add(int, -c + 10 + q, -(d + 10) + ht, int, -a + 10 + q, -(b + 10) + ht)


                        Form1.DataGridView1.Rows.Add(qd, -c + q, -d + ht, qd, -(dd + c) \ 2 + q, -d + ht) 'red
                        Form1.DataGridView1.Rows.Add(qd, -(dd + c) \ 2 + q, -(xx + d) \ 2 + ht, qd, -(dd + c) \ 2 + q, -d + ht) 'orange
                        Form1.DataGridView1.Rows.Add(qd, -(dd + c) \ 2 + q, -(xx + d) \ 2 + ht, qd, -(c + c1) \ 2 + q, -(xx + d) \ 2 + ht) 'yellow
                        Form1.DataGridView1.Rows.Add(qd, -(c + c1) \ 2 + q, -(d + d1) \ 2 + ht, qd, -(c + c1) \ 2 + q, -(xx + d) \ 2 + ht) 'green
                        Form1.DataGridView1.Rows.Add(qd, -(c + c1) \ 2 + q, -(d + d1) \ 2 + ht, qd, -(dd + c1) \ 2 + q, -(d + d1) \ 2 + ht) 'cyan
                        Form1.DataGridView1.Rows.Add(qd, -(dd + c1) \ 2 + q, -(d + d1) \ 2 + ht, qd, -(dd + c1) \ 2 + q, -(xx + d1) \ 2 + ht) 'blue
                        Form1.DataGridView1.Rows.Add(qd, -(dd + c1) \ 2 + q, -(xx + d1) \ 2 + ht, qd, -a + q, -(xx + d1) \ 2 + ht) 'brown
                        Form1.DataGridView1.Rows.Add(qd, -a + q, -(xx + d1) \ 2 + ht, qd, -a + q, -b + ht) 'white
                        Form1.DataGridView1.Rows.Add(qd, -c + 10 + q, -(d + 10) + ht, qd, -a + 10 + q, -(b + 10) + ht)

                        Form1.DataGridView1.Rows.Add(int, -(dd + c) \ 2 + q, -d + ht, qd, -(dd + c) \ 2 + q, -d + ht) 'red
                        Form1.DataGridView1.Rows.Add(int, -c + q, -d + ht, qd, -c + q, -d + ht) 'red
                        Form1.DataGridView1.Rows.Add(int, -(dd + c) \ 2 + q, -(xx + d) \ 2 + ht, qd, -(dd + c) \ 2 + q, -(xx + d) \ 2 + ht) 'orange
                        Form1.DataGridView1.Rows.Add(int, -(c + c1) \ 2 + q, -(xx + d) \ 2 + ht, qd, -(c + c1) \ 2 + q, -(xx + d) \ 2 + ht) 'yellow
                        Form1.DataGridView1.Rows.Add(int, -(c + c1) \ 2 + q, -(d + d1) \ 2 + ht, qd, -(c + c1) \ 2 + q, -(d + d1) \ 2 + ht) 'green
                        Form1.DataGridView1.Rows.Add(int, -(dd + c1) \ 2 + q, -(d + d1) \ 2 + ht, qd, -(dd + c1) \ 2 + q, -(d + d1) \ 2 + ht) 'cyan
                        Form1.DataGridView1.Rows.Add(int, -(dd + c1) \ 2 + q, -(xx + d1) \ 2 + ht, qd, -(dd + c1) \ 2 + q, -(xx + d1) \ 2 + ht) 'blue
                        Form1.DataGridView1.Rows.Add(int, -a + q, -(xx + d1) \ 2 + ht, qd, -a + q, -(xx + d1) \ 2 + ht) 'brown
                        Form1.DataGridView1.Rows.Add(int, -a + q, -b + ht, qd, -a + q, -b + ht) 'white

                        Form1.DataGridView1.Rows.Add(int, -c + 10 + q, -(d + 10) + ht, qd, -c + 10 + q, -(d + 10) + ht)
                        Form1.DataGridView1.Rows.Add(int, -a + 10 + q, -(b + 10) + ht, qd, -a + 10 + q, -(b + 10) + ht)


                        'Form1.DataGridView1.Rows.Add(int, c, -d, int, (dd + c) \ 2, -d) 'red
                        'Form1.DataGridView1.Rows.Add(int, (dd + c) \ 2, -(xx + d) \ 2, int, (dd + c) \ 2, -d) 'orange
                        'Form1.DataGridView1.Rows.Add(int, (dd + c) \ 2, -(xx + d) \ 2, int, (c + c1) \ 2, -(xx + d) \ 2) 'yellow
                        'Form1.DataGridView1.Rows.Add(int, (c + c1) \ 2, -(d + d1) \ 2, int, (c + c1) \ 2, -(xx + d) \ 2) 'green
                        'Form1.DataGridView1.Rows.Add(int, (c + c1) \ 2, -(d + d1) \ 2, int, (dd + c1) \ 2, -(d + d1) \ 2) 'cyan
                        'Form1.DataGridView1.Rows.Add(int, (dd + c1) \ 2, -(d + d1) \ 2, int, (dd + c1) \ 2, -(xx + d1) \ 2) 'blue
                        'Form1.DataGridView1.Rows.Add(int, (dd + c1) \ 2, -(xx + d1) \ 2, int, a, -(xx + d1) \ 2) 'brown
                        'Form1.DataGridView1.Rows.Add(int, a, -(xx + d1) \ 2, int, a, -b) 'white
                        'Form1.DataGridView1.Rows.Add(int, c + 10, -(d + 10), int, a + 10, -(b + 10))


                        'Form1.DataGridView1.Rows.Add(qd, c, -d, qd, (dd + c) \ 2, -d) 'red
                        'Form1.DataGridView1.Rows.Add(qd, (dd + c) \ 2, -(xx + d) \ 2, qd, (dd + c) \ 2, -d) 'orange
                        'Form1.DataGridView1.Rows.Add(qd, (dd + c) \ 2, -(xx + d) \ 2, qd, (c + c1) \ 2, -(xx + d) \ 2) 'yellow
                        'Form1.DataGridView1.Rows.Add(qd, (c + c1) \ 2, -(d + d1) \ 2, qd, (c + c1) \ 2, -(xx + d) \ 2) 'green
                        'Form1.DataGridView1.Rows.Add(qd, (c + c1) \ 2, -(d + d1) \ 2, qd, (dd + c1) \ 2, -(d + d1) \ 2) 'cyan
                        'Form1.DataGridView1.Rows.Add(qd, (dd + c1) \ 2, -(d + d1) \ 2, qd, (dd + c1) \ 2, -(xx + d1) \ 2) 'blue
                        'Form1.DataGridView1.Rows.Add(qd, (dd + c1) \ 2, -(xx + d1) \ 2, qd, a, -(xx + d1) \ 2) 'brown
                        'Form1.DataGridView1.Rows.Add(qd, a, -(xx + d1) \ 2, qd, a, -b) 'white
                        'Form1.DataGridView1.Rows.Add(qd, c + 10, -(d + 10), qd, a + 10, -(b + 10))

                        'Form1.DataGridView1.Rows.Add(int, (dd + c) \ 2, -d, qd, (dd + c) \ 2, -d) 'red
                        'Form1.DataGridView1.Rows.Add(int, c, -d, qd, c, -d) 'red
                        'Form1.DataGridView1.Rows.Add(int, (dd + c) \ 2, -(xx + d) \ 2, qd, (dd + c) \ 2, -(xx + d) \ 2) 'orange
                        'Form1.DataGridView1.Rows.Add(int, (c + c1) \ 2, -(xx + d) \ 2, qd, (c + c1) \ 2, -(xx + d) \ 2) 'yellow
                        'Form1.DataGridView1.Rows.Add(int, (c + c1) \ 2, -(d + d1) \ 2, qd, (c + c1) \ 2, -(d + d1) \ 2) 'green
                        'Form1.DataGridView1.Rows.Add(int, (dd + c1) \ 2, -(d + d1) \ 2, qd, (dd + c1) \ 2, -(d + d1) \ 2) 'cyan
                        'Form1.DataGridView1.Rows.Add(int, (dd + c1) \ 2, -(xx + d1) \ 2, qd, (dd + c1) \ 2, -(xx + d1) \ 2) 'blue
                        'Form1.DataGridView1.Rows.Add(int, a, -(xx + d1) \ 2, qd, a, -(xx + d1) \ 2) 'brown
                        'Form1.DataGridView1.Rows.Add(int, a, -b, qd, a, -b) 'white

                        'Form1.DataGridView1.Rows.Add(int, c + 10, -(d + 10), qd, c + 10, -(d + 10))
                        'Form1.DataGridView1.Rows.Add(int, a + 10, -(b + 10), qd, a + 10, -(b + 10))
                        '
                    Next
                End If




                If ComboBox22.Text = "Stadium" Then
                    int = int + 100
                    qd = qd + 100
                    For i As Integer = 0 To Sketch.TextBox4.Text - 1

                        ht = ht + 100
                        'Mirror


                        Form1.DataGridView1.Rows.Add(int, -c + q, -d + ht, int, -(dd + c) \ 2 + q, -d + ht) 'red
                        Form1.DataGridView1.Rows.Add(int, -(dd + c) \ 2 + q, (-(xx + d) \ 2) + ht, int, -(dd + c) \ 2 + q, -d + ht) 'orange
                        Form1.DataGridView1.Rows.Add(int, -(dd + c) \ 2 + q, -(xx + d) \ 2 + ht, int, -(c + c1) \ 2 + q, -(xx + d) \ 2 + ht) 'yellow
                        Form1.DataGridView1.Rows.Add(int, -(c + c1) \ 2 + q, -(d + d1) \ 2 + ht, int, -(c + c1) \ 2 + q, -(xx + d) \ 2 + ht) 'green
                        Form1.DataGridView1.Rows.Add(int, -(c + c1) \ 2 + q, -(d + d1) \ 2 + ht, int, -(dd + c1) \ 2 + q, -(d + d1) \ 2 + ht) 'cyan
                        Form1.DataGridView1.Rows.Add(int, -(dd + c1) \ 2 + q, -(d + d1) \ 2 + ht, int, -(dd + c1) \ 2 + q, -(xx + d1) \ 2 + ht) 'blue
                        Form1.DataGridView1.Rows.Add(int, -(dd + c1) \ 2 + q, -(xx + d1) \ 2 + ht, int, -a + q, -(xx + d1) \ 2 + ht) 'brown
                        Form1.DataGridView1.Rows.Add(int, -a + q, -(xx + d1) \ 2 + ht, int, -a + q, -b + ht) 'white
                        Form1.DataGridView1.Rows.Add(int, -c + 10 + q, -(d + 10) + ht, int, -a + 10 + q, -(b + 10) + ht)


                        Form1.DataGridView1.Rows.Add(qd, -c + q, -d + ht, qd, -(dd + c) \ 2 + q, -d + ht) 'red
                        Form1.DataGridView1.Rows.Add(qd, -(dd + c) \ 2 + q, -(xx + d) \ 2 + ht, qd, -(dd + c) \ 2 + q, -d + ht) 'orange
                        Form1.DataGridView1.Rows.Add(qd, -(dd + c) \ 2 + q, -(xx + d) \ 2 + ht, qd, -(c + c1) \ 2 + q, -(xx + d) \ 2 + ht) 'yellow
                        Form1.DataGridView1.Rows.Add(qd, -(c + c1) \ 2 + q, -(d + d1) \ 2 + ht, qd, -(c + c1) \ 2 + q, -(xx + d) \ 2 + ht) 'green
                        Form1.DataGridView1.Rows.Add(qd, -(c + c1) \ 2 + q, -(d + d1) \ 2 + ht, qd, -(dd + c1) \ 2 + q, -(d + d1) \ 2 + ht) 'cyan
                        Form1.DataGridView1.Rows.Add(qd, -(dd + c1) \ 2 + q, -(d + d1) \ 2 + ht, qd, -(dd + c1) \ 2 + q, -(xx + d1) \ 2 + ht) 'blue
                        Form1.DataGridView1.Rows.Add(qd, -(dd + c1) \ 2 + q, -(xx + d1) \ 2 + ht, qd, -a + q, -(xx + d1) \ 2 + ht) 'brown
                        Form1.DataGridView1.Rows.Add(qd, -a + q, -(xx + d1) \ 2 + ht, qd, -a + q, -b + ht) 'white
                        Form1.DataGridView1.Rows.Add(qd, -c + 10 + q, -(d + 10) + ht, qd, -a + 10 + q, -(b + 10) + ht)

                        Form1.DataGridView1.Rows.Add(int, -(dd + c) \ 2 + q, -d + ht, qd, -(dd + c) \ 2 + q, -d + ht) 'red
                        Form1.DataGridView1.Rows.Add(int, -c + q, -d + ht, qd, -c + q, -d + ht) 'red
                        Form1.DataGridView1.Rows.Add(int, -(dd + c) \ 2 + q, -(xx + d) \ 2 + ht, qd, -(dd + c) \ 2 + q, -(xx + d) \ 2 + ht) 'orange
                        Form1.DataGridView1.Rows.Add(int, -(c + c1) \ 2 + q, -(xx + d) \ 2 + ht, qd, -(c + c1) \ 2 + q, -(xx + d) \ 2 + ht) 'yellow
                        Form1.DataGridView1.Rows.Add(int, -(c + c1) \ 2 + q, -(d + d1) \ 2 + ht, qd, -(c + c1) \ 2 + q, -(d + d1) \ 2 + ht) 'green
                        Form1.DataGridView1.Rows.Add(int, -(dd + c1) \ 2 + q, -(d + d1) \ 2 + ht, qd, -(dd + c1) \ 2 + q, -(d + d1) \ 2 + ht) 'cyan
                        Form1.DataGridView1.Rows.Add(int, -(dd + c1) \ 2 + q, -(xx + d1) \ 2 + ht, qd, -(dd + c1) \ 2 + q, -(xx + d1) \ 2 + ht) 'blue
                        Form1.DataGridView1.Rows.Add(int, -a + q, -(xx + d1) \ 2 + ht, qd, -a + q, -(xx + d1) \ 2 + ht) 'brown
                        Form1.DataGridView1.Rows.Add(int, -a + q, -b + ht, qd, -a + q, -b + ht) 'white

                        Form1.DataGridView1.Rows.Add(int, -c + 10 + q, -(d + 10) + ht, qd, -c + 10 + q, -(d + 10) + ht)
                        Form1.DataGridView1.Rows.Add(int, -a + 10 + q, -(b + 10) + ht, qd, -a + 10 + q, -(b + 10) + ht)

                    Next
                End If

            End If
        End If
        If S8.Checked Then S1.Text += 1
        If S1.Text = 2 Then
            If S8.Checked Then
                '  graph.DrawLine(New Pen(Color.Green, 1), xx, yy, e.X, e.Y)
                gdS.DrawLine(Pens.White, c, d, a, b)

            End If
        Else
            S1.Text = 0
        End If
        S2.Text += 1
        S20.Image = by
    End Sub

    Private Sub S20_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles S20.MouseMove
        S20.Refresh()
        S6.Text = e.X
        S5.Text = e.Y
        Dim g As Graphics = S20.CreateGraphics
        Dim a As Integer = S3.Text
        Dim b As Integer = S4.Text
        Dim c As Integer = S6.Text
        Dim d As Integer = S5.Text

        g.DrawLine(New Pen(Color.White, 1), e.X, e.Y - 25, e.X, e.Y + 25)
        g.DrawLine(New Pen(Color.White, 1), e.X - 25, e.Y, e.X + 25, e.Y)

        g.DrawRectangle(New Pen(Color.White, 1), e.X - 5, e.Y - 5, 10, 10)
        S20.CreateGraphics.DrawString("x=" & e.X / 40 & vbCrLf & "y=" & e.Y / 40, New System.Drawing.Font("Proxy 7", 9), Brushes.White, e.X + 10, e.Y + 10)

        If S7.Checked Then
            g.DrawLine(Pens.Yellow, c, d, a, b)
            Dim d1 As Integer = S5.Text
            Dim xx As Integer = (d + d1) \ 2
            g.DrawLine(Pens.White, e.X, e.Y, a, (xx + d1) \ 2)
            g.DrawLine(Pens.White, a, (xx + d1) \ 2, a, b)
            S2.Text = 1
        End If




        ' Dim bm As New Bitmap(60, 60)                 'Or from a bitmap file
        'Dim g1 As Graphics = Graphics.FromImage(bm)
        '  g1.FillRectangle(Brushes.Blue, 0, 0, 100, 100)  'For a simple blue rectangle cursor
        ' Dim ptrCur As IntPtr = bm.GetHicon
        'Dim CustomCursor As Cursor
        'CustomCursor = New Cursor(ptrCur)
        'PictureBox1.Cursor = CustomCursor



        ' PictureBox1.Image = by
    End Sub

    Private Sub s11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S11.Click

        gdS.Clear(Color.FromArgb(60, 70, 73))
        'DataGridView6.Rows.Clear()
    End Sub

    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Form1.Show()
    End Sub
End Class