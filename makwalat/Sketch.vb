Imports System.Drawing.Drawing2D
Imports System
Imports System.IO
Imports Microsoft.VisualBasic.CompilerServices
Public Class Sketch
    Dim Dragged As Boolean = False
    Dim iniPointX, inipointY As Integer
    Public eventString As String
    Public p1 As Integer
    Public q1 As Integer
    Public LocalMousePosition As Point
    Dim T_lines As Integer
    'main
    Public bm As New Bitmap(2000, 10000)
    Public graph As Graphics = Graphics.FromImage(bm)
    Dim column As New List(Of Point)
    Dim d As Integer = 0
    Dim rec As Integer
    Dim rec1 As Integer
    Dim check As Boolean = True
    Private Sub Draw3DToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Draw3D.Click

        If Draw3D.CheckState = CheckState.Unchecked Then
            Draw3D.CheckState = CheckState.Checked
        Else
            Draw3D.CheckState = CheckState.Unchecked
        End If
    End Sub
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown

        If Draw3D.CheckState = CheckState.Checked Then
            d += 1
            If d = 1 Then
                TextBox10.Text = e.X
                TextBox9.Text = e.Y
            End If

            If d = 2 Then
                Dim rec As Integer
                Dim rec1 As Integer
                rec = TextBox10.Text
                rec1 = TextBox9.Text
                graph.DrawLine(Pens.Cyan, e.X, rec1, rec, rec1)
                graph.DrawLine(Pens.Cyan, rec, e.Y, rec, rec1)
                graph.DrawLine(Pens.Cyan, e.X, e.Y, e.X, rec1)
                graph.DrawLine(Pens.Cyan, e.X, e.Y, rec, e.Y)

                ' RichTextBox1.AppendText(vbCrLf & "world.addPlane( new Plane(" & """url(http://keithclark.co.uk/labs/css-fps/old/wall.jpg?3)""" & ", "& e.X &","& rec1 & "," & rec &","& -1000, -447, 270, 0,180"));")
                If check = True Then
                    RichTextBox1.AppendText(vbCrLf & "buildCube(" & """#eee""" & "," & e.X & "," & "3" & ",60," & rec & "," & rec1 & "," & " -30);")
                End If
                If check = False Then
                    RichTextBox1.AppendText(vbCrLf & "buildCube(" & """#eee""" & "," & "3" & "," & e.Y & ",60," & rec & "," & rec1 & "," & " -30);")
                End If

                PictureBox1.Image = bm
                d = 0
            End If
        End If
        If Yescolumn.Checked = True Then
            Dim pt As New Point
            pt.X = e.X
            pt.Y = e.Y
            column.Add(pt)

            graph.DrawRectangle(Pens.Black, e.X, e.Y, 10, 10)
            PictureBox1.Image = bm
            Nocolumn.Checked = False
        ElseIf Nocolumn.Checked = True Then

            Yescolumn.Checked = False
        End If






        If Yes.Checked = True Then
            ' ##################################################
            '################################################

            ' See what we're over.
            Dim mouse_pt As Point = SnapToGrid(e.Location)
            Dim hit_polygon As List(Of Point)
            Dim hit_point As Integer, hit_point2 As Integer
            Dim closest_point As Point

            If NewPolygon IsNot Nothing Then
                ' We are already drawing a polygon.
                ' If it's the right mouse button, finish this polygon.
                If e.Button = MouseButtons.Right Then
                    ' Finish this polygon.
                    If NewPolygon.Count > 2 Then
                        Polygons.Add(NewPolygon)
                    End If
                    NewPolygon = Nothing

                    ' We no longer are drawing.
                    AddHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove_NotDrawing
                    RemoveHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove_Drawing
                Else
                    ' Add a point to this polygon.
                    If NewPolygon(NewPolygon.Count - 1) <> mouse_pt Then
                        NewPolygon.Add(mouse_pt)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''    ListBox1.Items.Add(mouse_pt)

                    End If
                End If
            ElseIf MouseIsOverCornerPoint(mouse_pt, hit_polygon, hit_point) Then
                ' Start dragging this corner.
                RemoveHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove_NotDrawing
                AddHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove_MovingCorner
                AddHandler PictureBox1.MouseUp, AddressOf PictureBox1_MouseUp_MovingCorner

                ' Remember the polygon and point number.
                MovingPolygon = hit_polygon
                MovingPoint = hit_point

                ' Remember the offset from the mouse to the point.
                OffsetX = hit_polygon(hit_point).X - e.X
                OffsetY = hit_polygon(hit_point).Y - e.Y
            ElseIf MouseIsOverEdge(mouse_pt, hit_polygon, hit_point, hit_point2, closest_point) Then
                ' Add a point.
                hit_polygon.Insert(hit_point + 1, closest_point)
            ElseIf MouseIsOverPolygon(mouse_pt, hit_polygon) Then
                ' Start moving this polygon.
                RemoveHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove_NotDrawing
                AddHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove_MovingPolygon
                AddHandler PictureBox1.MouseUp, AddressOf PictureBox1_MouseUp_MovingPolygon

                ' Remember the polygon.
                MovingPolygon = hit_polygon

                ' Remember the offset from the mouse to the segment's first point.
                OffsetX = hit_polygon(0).X - e.X
                OffsetY = hit_polygon(0).Y - e.Y
            Else
                ' Start a new polygon.
                NewPolygon = New List(Of Point)()
                NewPoint = mouse_pt
                NewPolygon.Add(mouse_pt)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  ListBox1.Items.Add("NEW Polygon")
                ' Get ready to work on the new polygon.
                RemoveHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove_NotDrawing
                AddHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove_Drawing
            End If

            ' Redraw.
            PictureBox1.Invalidate()
            '##################################################
            '##################################################
        End If






        If DrawFreeLineToolStripMenuItem.Checked Then
            'freeline
            iniPointX = e.X
            inipointY = e.Y
            TextBox5.Text = ""
            '  p1 = e.X
            '  q1 = e.Y

            'Colour = RandomNumber(&HF0D2691E, &HFFD269EE)
            'Colour = RandomNumber(&HF002691E, &HFFFFFFFE)
            ' Timer1.Enabled = True

            Select Case e.Button
                Case MouseButtons.Left
                    eventString = "L"
                Case MouseButtons.Right
                    eventString = "R"
                Case MouseButtons.Middle
                    eventString = "M"
                Case MouseButtons.XButton1
                    eventString = "X1"
                Case MouseButtons.XButton2
                    eventString = "X2"
                Case MouseButtons.None
                    eventString = Nothing
            End Select


        End If
        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'dxf
        If DrawLineToolStripMenuItem.Checked = True Then
            'dxf.Text += 1
            TextBox10.Text = e.X
            TextBox9.Text = e.Y
            Dim x11 As Integer = TextBox10.Text
            Dim y1 As Integer = TextBox9.Text
            Dim x As Integer = TextBox8.Text
            Dim y As Integer = TextBox7.Text
            TextBox8.Text = e.X
            TextBox7.Text = e.Y

            graph.DrawLine(Pens.Red, x, y, x11, y1)
            TextBox6.Text = TextBox6.Text & vbCrLf & "0" & vbCrLf & "LINE" & vbCrLf & "8" & vbCrLf & TextBox13.Text & vbCrLf & "62" & vbCrLf & TextBox12.Text & vbCrLf & "10" & vbCrLf & -x11 / 100 & vbCrLf & "20" & vbCrLf & y1 / 100 & vbCrLf & "30" & vbCrLf & "0.0" & vbCrLf & "11" & vbCrLf & -x / 100 & vbCrLf & "21" & vbCrLf & y / 100 & vbCrLf & "31" & vbCrLf & "0"
            dxf.Text = 0
            PictureBox1.Image = bm
            DrawFreeLineToolStripMenuItem.Checked = False
        End If
    End Sub
#Region "moving polgon & Snap in Grid"

    ' The "size" of an object for mouse over purposes.
    Private Const object_radius As Integer = 3

    ' We're over an object if the distance squared
    ' between the mouse and the object is less than this.
    Private Const over_dist_squared As Integer = object_radius * object_radius

    ' Each polygon is represented by a List<Point>.
    Private Polygons As New List(Of List(Of Point))()

    ' Points for the new polygon.
    Private NewPolygon As List(Of Point) = Nothing

    ' The current mouse position while drawing a new polygon.
    Private NewPoint As Point

    ' The polygon and index of the corner we are moving.
    Private MovingPolygon As List(Of Point) = Nothing
    Private MovingPoint As Integer = -1
    Private OffsetX As Integer, OffsetY As Integer

    ' The add point cursor.
    Private AddPointCursor As Cursor

    ' Create the add point cursor.
    'Private Sub Form6_Load(sender As Object, e As EventArgs) Handles Me.Load
    ' AddPointCursor = New Cursor(Resources.add_point.png)
    '    MakeBackgroundGrid()
    'End Sub

    ' Start or continue drawing a new polygon,
    ' or start moving a corner or polygon.
    'Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown

    'End Sub

    ' Move the next point in the new polygon.
    Private Sub PictureBox1_MouseMove_Drawing(sender As Object, e As MouseEventArgs)
        NewPoint = SnapToGrid(e.Location)
        PictureBox1.Invalidate()
    End Sub

    ' Move the selected corner.
    Private Sub PictureBox1_MouseMove_MovingCorner(sender As Object, e As MouseEventArgs)
        ' Move the point.
        MovingPolygon(MovingPoint) = SnapToGrid(New Point(e.X + OffsetX, e.Y + OffsetY))

        ' Dim TransBrush As New SolidBrush(Color.FromArgb(128, 100, 255, 255))
        Dim TransBrush As New SolidBrush(Color.FromArgb(100, 80, 78, 76))
        ' Draw the old polygons.
        Dim hit_polygon As List(Of Point)
        Dim polygon0 As List(Of Point)

        For Each polygon As List(Of Point) In Polygons
            ' Draw the polygon.


            ' Draw the corners.
            For Each corner As Point In polygon
                Dim rect As New System.Drawing.Rectangle(corner.X - object_radius, corner.Y - object_radius, 2 * object_radius + 1, 2 * object_radius + 1)
                ' e.Graphics.FillEllipse(TransBrush, rect)

                ' e.Graphics.DrawEllipse(Pens.Black, rect)
            Next
        Next
        ' Redraw.
        PictureBox1.Invalidate()
    End Sub

    ' Finish moving the selected corner.
    Private Sub PictureBox1_MouseUp_MovingCorner(sender As Object, e As MouseEventArgs)
        AddHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove_NotDrawing
        RemoveHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove_MovingCorner
        RemoveHandler PictureBox1.MouseUp, AddressOf PictureBox1_MouseUp_MovingCorner
        Dim Ar As Single = 0
        Dim m As Single
        Dim h As Integer
        Dim mygraphic As Graphics = PictureBox1.CreateGraphics
        For m = 0 To MovingPolygon.Count - 2
            Ar = Ar + ((MovingPolygon(m).Y + MovingPolygon(m + 1).Y) * (MovingPolygon(m + 1).X - MovingPolygon(m).X) / 2)
            h = h + Math.Sqrt((MovingPolygon(m + 1).X - MovingPolygon(m).X) ^ 2 + (MovingPolygon(m + 1).Y - MovingPolygon(m).Y) ^ 2)
        Next
        Dim ty
        For i As Integer = 0 To TextBox4.Text - 1
            ty = ty + 100
            For v = 0 To MovingPolygon.Count - 2

                Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, ty, MovingPolygon(v + 1).Y, MovingPolygon(v + 1).X, ty)
                Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, ty + 15, MovingPolygon(v + 1).Y, MovingPolygon(v + 1).X, ty + 15)
                Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, ty, MovingPolygon(v).Y, MovingPolygon(v).X, ty + 15)

                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 200, MovingPolygon(v + 1).Y, MovingPolygon(v + 1).X, 200)
                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 200 + 15, MovingPolygon(v + 1).Y, MovingPolygon(v + 1).X, 200 + 15)
                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 200, MovingPolygon(v).Y, MovingPolygon(v).X, 200 + 15)

                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 300, MovingPolygon(v + 1).Y, MovingPolygon(v + 1).X, 300)
                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 300 + 15, MovingPolygon(v + 1).Y, MovingPolygon(v + 1).X, 300 + 15)
                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 300, MovingPolygon(v).Y, MovingPolygon(v).X, 300 + 15)

                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 400, MovingPolygon(v + 1).Y, MovingPolygon(v + 1).X, 400)
                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 400 + 15, MovingPolygon(v + 1).Y, MovingPolygon(v + 1).X, 400 + 15)
                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 400, MovingPolygon(v).Y, MovingPolygon(v).X, 400 + 15)

                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 500, MovingPolygon(v + 1).Y, MovingPolygon(v + 1).X, 500)
                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 500 + 15, MovingPolygon(v + 1).Y, MovingPolygon(v + 1).X, 500 + 15)
                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 500, MovingPolygon(v).Y, MovingPolygon(v).X, 500 + 15)

                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 600, MovingPolygon(v + 1).Y, MovingPolygon(v + 1).X, 600)
                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 600 + 15, MovingPolygon(v + 1).Y, MovingPolygon(v + 1).X, 600 + 15)
                'Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 600, MovingPolygon(v).Y, MovingPolygon(v).X, 600 + 15)

                Form1.DataGridView1.Rows.Add(MovingPolygon(v).Y, MovingPolygon(v).X, 100, MovingPolygon(v).Y, MovingPolygon(v).X, ty + 15)


            Next
        Next
        Dim level = 0

        For i As Integer = 0 To TextBox4.Text - 1
            For Each poin As Point In column
                Form1.DataGridView1.Rows.Add(poin.Y, poin.X + 10, level + 100, poin.Y + 10, poin.X + 10, level + 100)
                Form1.DataGridView1.Rows.Add(poin.Y + 10, poin.X, level + 100, poin.Y + 10, poin.X + 10, level + 100)
                Form1.DataGridView1.Rows.Add(poin.Y + 10, poin.X, level + 100, poin.Y, poin.X, level + 100)
                Form1.DataGridView1.Rows.Add(poin.Y, poin.X + 10, level + 100, poin.Y, poin.X, level + 100)
                Form1.DataGridView1.Rows.Add(poin.Y, poin.X, level + 100, poin.Y, poin.X, level)
                Form1.DataGridView1.Rows.Add(poin.Y, poin.X + 10, level + 100, poin.Y, poin.X + 10, level)
                Form1.DataGridView1.Rows.Add(poin.Y + 10, poin.X, level + 100, poin.Y + 10, poin.X, level)
                Form1.DataGridView1.Rows.Add(poin.Y + 10, poin.X + 10, level + 100, poin.Y + 10, poin.X + 10, level)
                Form1.DataGridView1.Rows.Add(poin.Y, poin.X + 10, level, poin.Y + 10, poin.X + 10, level)
                Form1.DataGridView1.Rows.Add(poin.Y + 10, poin.X, level, poin.Y + 10, poin.X + 10, level)
                Form1.DataGridView1.Rows.Add(poin.Y + 10, poin.X, level, poin.Y, poin.X, level)
                Form1.DataGridView1.Rows.Add(poin.Y, poin.X + 10, level, poin.Y, poin.X, level)
                'قاعدة مسلحة
                Form1.DataGridView1.Rows.Add(poin.Y - 50, poin.X + 50, 0, poin.Y + 50, poin.X + 50, 0)
                Form1.DataGridView1.Rows.Add(poin.Y + 50, poin.X - 50, 0, poin.Y + 50, poin.X + 50, 0)
                Form1.DataGridView1.Rows.Add(poin.Y + 50, poin.X - 50, 0, poin.Y - 50, poin.X - 50, 0)
                Form1.DataGridView1.Rows.Add(poin.Y - 50, poin.X + 50, 0, poin.Y - 50, poin.X - 50, 0)

                Form1.DataGridView1.Rows.Add(poin.Y - 50, poin.X + 50, -30, poin.Y + 50, poin.X + 50, -30)
                Form1.DataGridView1.Rows.Add(poin.Y + 50, poin.X - 50, -30, poin.Y + 50, poin.X + 50, -30)
                Form1.DataGridView1.Rows.Add(poin.Y + 50, poin.X - 50, -30, poin.Y - 50, poin.X - 50, -30)
                Form1.DataGridView1.Rows.Add(poin.Y - 50, poin.X + 50, -30, poin.Y - 50, poin.X - 50, -30)

                Form1.DataGridView1.Rows.Add(poin.Y - 50, poin.X + 50, -30, poin.Y - 50, poin.X + 50, 0)
                Form1.DataGridView1.Rows.Add(poin.Y - 50, poin.X - 50, -30, poin.Y - 50, poin.X - 50, 0)
                Form1.DataGridView1.Rows.Add(poin.Y + 50, poin.X - 50, -30, poin.Y + 50, poin.X - 50, 0)
                Form1.DataGridView1.Rows.Add(poin.Y + 50, poin.X + 50, -30, poin.Y + 50, poin.X + 50, 0)


                'قاعدة عادية
                Form1.DataGridView1.Rows.Add(poin.Y - 70, poin.X + 70, -30, poin.Y + 70, poin.X + 70, -30)
                Form1.DataGridView1.Rows.Add(poin.Y + 70, poin.X - 70, -30, poin.Y + 70, poin.X + 70, -30)
                Form1.DataGridView1.Rows.Add(poin.Y + 70, poin.X - 70, -30, poin.Y - 70, poin.X - 70, -30)
                Form1.DataGridView1.Rows.Add(poin.Y - 70, poin.X + 70, -30, poin.Y - 70, poin.X - 70, -30)

                Form1.DataGridView1.Rows.Add(poin.Y - 70, poin.X + 70, -60, poin.Y + 70, poin.X + 70, -60)
                Form1.DataGridView1.Rows.Add(poin.Y + 70, poin.X - 70, -60, poin.Y + 70, poin.X + 70, -60)
                Form1.DataGridView1.Rows.Add(poin.Y + 70, poin.X - 70, -60, poin.Y - 70, poin.X - 70, -60)
                Form1.DataGridView1.Rows.Add(poin.Y - 70, poin.X + 70, -60, poin.Y - 70, poin.X - 70, -60)

                Form1.DataGridView1.Rows.Add(poin.Y - 70, poin.X + 70, -60, poin.Y - 70, poin.X + 70, -30)
                Form1.DataGridView1.Rows.Add(poin.Y + 70, poin.X - 70, -60, poin.Y + 70, poin.X - 70, -30)
                Form1.DataGridView1.Rows.Add(poin.Y + 70, poin.X + 70, -60, poin.Y + 70, poin.X + 70, -30)
                Form1.DataGridView1.Rows.Add(poin.Y - 70, poin.X - 70, -60, poin.Y - 70, poin.X - 70, -30)
            Next
            level += 100
        Next
        Ar = Ar + ((MovingPolygon(0).Y + MovingPolygon(m).Y) * (MovingPolygon(0).X - MovingPolygon(m).X) / 2)
        Ar = (Ar / (mygraphic.DpiX * mygraphic.DpiY)) ' * 6.4516
        ' 1428.482856999640399281 pixel = 1 cm2
        ' 1 in.2  = 600 pixel
        Ar = Math.Abs(Ar)    'Clockwise/Counterclockwise
        Ar = (((Ar * 139.1199581) / 15.500031) / 1550.0031) * 1000
        TextBox3.Text = Ar ' mygraphic.DpiX * mygraphic.DpiY 'Math.Round(Ar, 9).ToString
        Label4.Text = Math.Round(Ar, 2) & "  م2  "
        Label5.Text = Math.Round(Ar / (0.35 * 0.35), 2) & " عدد  "
        Label8.Text = Math.Round(Ar * (TextBox1.Text / 100), 2) & "  م3  "
        Label9.Text = Math.Round(((h / 30) * 0.25 * TextBox2.Text) / (0.12 * 0.25 * 0.05), 2) 'طوبه
        Label12.Text = Math.Round(((h / 30) * 0.12 * TextBox2.Text) / (0.12 * 0.25 * 0.05), 2) 'نصف طوبة
        Label65.Text = TextBox4.Text & " دور"
        If RadioButton1.Checked Then
            Label13.Text = Math.Round((Ar * (0.817 * 10) / 1000) * 2, 2) & "  طن  "
            Label18.Text = Math.Round((Ar * (0.888 * 10) / 1000) * 2, 2) & "  طن  "
            Label19.Text = Math.Round((Ar * (1.58 * 10) / 1000) * 2, 2) & "  طن  "

            Label64.Text = Math.Round((Ar * (0.817 * 10) / 1000) * 2, 2) * TextBox4.Text
            Label63.Text = Math.Round((Ar * (0.888 * 10) / 1000) * 2, 2) * TextBox4.Text
            Label62.Text = Math.Round((Ar * (1.58 * 10) / 1000) * 2, 2) * TextBox4.Text
        ElseIf RadioButton2.Checked Then
            Label13.Text = Math.Round(Ar * (0.817 * 10) / 1000, 2) & "  طن  "
            Label18.Text = Math.Round(Ar * (0.888 * 10) / 1000, 2) & "  طن  "
            Label19.Text = Math.Round(Ar * (1.58 * 10) / 1000, 2) & "  طن  "

            Label64.Text = Math.Round((Ar * (0.817 * 10) / 1000), 2) * TextBox4.Text
            Label63.Text = Math.Round((Ar * (0.888 * 10) / 1000), 2) * TextBox4.Text
            Label62.Text = Math.Round((Ar * (1.58 * 10) / 1000), 2) * TextBox4.Text
        End If

        Label47.Text = Math.Round(Ar * (TextBox1.Text / 100) * TextBox11.Text, 2) & "  طن  " 'وزن الخرسانة
        Label48.Text = Math.Round((Ar * (TextBox1.Text / 100) * TextBox11.Text) / TextBox14.Text, 0) & "  عمود  " 'عدد الاعمدة

        Label22.Text = Math.Round(Ar * (TextBox1.Text / 100)) & "  م3  "   'نجارة
        Label27.Text = Math.Round(Ar * (TextBox1.Text / 100)) & "  م3  " 'حدادة
        Label28.Text = Math.Round(((h / 30) * TextBox2.Text) * 2) & "  م2  " 'محارة
        Label29.Text = Math.Round(((h / 30) * TextBox2.Text)) & "  م2  "  'نقاشة
        Label31.Text = "0" 'سباكة
        Label21.Text = (main.DataGridView2.Rows(3).Cells(3).Value.ToString() * (Math.Round(((h / 30) * 0.25 * TextBox2.Text) / (0.12 * 0.25 * 0.05), 2) / 1000)) +
                   (main.DataGridView2.Rows(9).Cells(3).Value.ToString() * Math.Round(Ar * (TextBox1.Text / 100), 2)) +
                    (main.DataGridView2.Rows(36).Cells(3).Value.ToString() * Math.Round(Ar * (1.58 * 10) / 1000, 2)) +
                   main.DataGridView2.Rows(53).Cells(3).Value.ToString() * Math.Round(Ar / (0.35 * 0.35), 2) +
                   main.DataGridView2.Rows(40).Cells(3).Value.ToString() * Math.Round(Ar * (TextBox1.Text / 100)) +
                  main.DataGridView2.Rows(43).Cells(3).Value.ToString() * Math.Round(Ar * (TextBox1.Text / 100)) & "ج"
        'طوب + خرسانة جاهزة +حديد +سيراميك +نجارة+حدادة
        'ناقص   نقاشة + محارة + كهرباء+تكلفة الارض +عزل+نجارة ابواب وشبابيك
        Label33.Text = ((main.DataGridView2.Rows(3).Cells(3).Value.ToString() * (Math.Round(((h / 30) * 0.25 * TextBox2.Text) / (0.12 * 0.25 * 0.05), 2) / 1000)) +
                   (main.DataGridView2.Rows(9).Cells(3).Value.ToString() * Math.Round(Ar * (TextBox1.Text / 100), 2)) +
                    (main.DataGridView2.Rows(36).Cells(3).Value.ToString() * Math.Round(Ar * (1.58 * 10) / 1000, 2)) +
                   main.DataGridView2.Rows(53).Cells(3).Value.ToString() * Math.Round(Ar / (0.35 * 0.35), 2) +
                   main.DataGridView2.Rows(40).Cells(3).Value.ToString() * Math.Round(Ar * (TextBox1.Text / 100)) +
                  main.DataGridView2.Rows(43).Cells(3).Value.ToString() * Math.Round(Ar * (TextBox1.Text / 100))) * TextBox4.Text

        Dim ammount = Label8.Text
        Dim num As Double = Conversion.Val(Me.ConcreteSt.Text) + 100
        Dim num1 As Double = Math.Round((1000 - (num / Conversion.Val(Me.Gc.Text) + 0.5 * num / 1000)) * (1 / Conversion.Val(Me.Gs.Text) + 1 / Conversion.Val(Me.SandGravel.Text) / Conversion.Val(Conversion.Val(Me.Gg.Text))))
        Me.SandW.Text = Conversions.ToString(Math.Round(num1 * Conversion.Val(ammount) * (1 + Conversion.Val(Me.DamagConc.Text) / 100), 1))
        Me.SandVoL.Text = Conversions.ToString(Math.Round(Math.Round(num1 / Conversion.Val(Me.VOLWight.Text), 1) * Conversion.Val(ammount) * (1 + Conversion.Val(Me.DamagConc.Text) / 100), 1))
        Me.GravelW.Text = Conversions.ToString(Math.Round(num1 / Conversion.Val(Me.SandGravel.Text) * Conversion.Val(ammount) * (1 + Conversion.Val(Me.DamagConc.Text) / 100), 1))
        Me.GravelVoL.Text = Conversions.ToString(Math.Round(Math.Round(Conversion.Val(Me.GravelW.Text) / Conversion.Val(Me.VOLWight.Text), 1) * Conversion.Val(ammount) * (1 + Conversion.Val(Me.DamagConc.Text) / 100), 1))
        Me.CementW.Text = Conversions.ToString(Math.Round(num * Conversion.Val(ammount) * (1 + Conversion.Val(Me.DamagConc.Text) / 100), 1))
        Me.CementVOL.Text = Conversions.ToString(Math.Round(Math.Round(num / 50) * Conversion.Val(ammount) * (1 + Conversion.Val(Me.DamagConc.Text) / 100)))
        Me.WaterW.Text = Conversions.ToString(Math.Round(num * Conversion.Val(Me.WaterCement.Text) * Conversion.Val(ammount) * (1 + Conversion.Val(Me.DamagConc.Text) / 100), 1))
        Label50.Text = CementW.Text & " كجم "
        Label58.Text = CementVOL.Text & " شكارة "
        Label52.Text = WaterW.Text & " لتر او كجم "

        Label54.Text = GravelW.Text & " كجم "
        Label60.Text = GravelVoL.Text & " م3 "

        Label56.Text = SandW.Text & " كجم  "
        Label61.Text = SandVoL.Text & " م3 "
    End Sub
    ' want to scale
    Public zoomfactor As Single = 1
    Private Sub PictureBox1_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseWheel
        If e.Delta > 0 Then
            If zoomfactor >= 20 Then zoomfactor = 20 : Exit Sub
            zoomfactor = zoomfactor + 0.1

            Me.Invalidate()

        ElseIf e.Delta < 0 Then
            If zoomfactor <= 0.08 Then zoomfactor = 0.08 : Exit Sub
            zoomfactor = zoomfactor - 0.1
            Me.Invalidate()

        End If
        ' See how far the first point will move.
        Dim new_x1 As Integer = e.X + OffsetX
        Dim new_y1 As Integer = e.Y + OffsetY

        Dim dx As Integer = new_x1 - MovingPolygon(0).X
        Dim dy As Integer = new_y1 - MovingPolygon(0).Y

        ' Snap the movement to a multiple of the grid distance.
        dx = GridGap * CInt(Math.Round(CSng(dx) / GridGap))
        dy = GridGap * CInt(Math.Round(CSng(dy) / GridGap))

        If dx = 0 AndAlso dy = 0 Then
            Return
        End If

        ' Move the polygon.
        For i As Integer = 0 To MovingPolygon.Count - 1
            MovingPolygon(i) = New Point(MovingPolygon(i).X + dx, MovingPolygon(i).Y + dy)
        Next

        ' Redraw.
        PictureBox1.Invalidate()
    End Sub
    ' Move the selected polygon.
    Private Sub PictureBox1_MouseMove_MovingPolygon(sender As Object, e As MouseEventArgs)
        ' See how far the first point will move.
        Dim new_x1 As Integer = e.X + OffsetX
        Dim new_y1 As Integer = e.Y + OffsetY

        Dim dx As Integer = new_x1 - MovingPolygon(0).X
        Dim dy As Integer = new_y1 - MovingPolygon(0).Y

        ' Snap the movement to a multiple of the grid distance.
        dx = GridGap * CInt(Math.Round(CSng(dx) / GridGap))
        dy = GridGap * CInt(Math.Round(CSng(dy) / GridGap))

        If dx = 0 AndAlso dy = 0 Then
            Return
        End If

        ' Move the polygon.
        For i As Integer = 0 To MovingPolygon.Count - 1
            MovingPolygon(i) = New Point(MovingPolygon(i).X + dx, MovingPolygon(i).Y + dy)
        Next

        ' Redraw.
        PictureBox1.Invalidate()
    End Sub

    ' Finish moving the selected polygon.
    Private Sub PictureBox1_MouseUp_MovingPolygon(sender As Object, e As MouseEventArgs)
        AddHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove_NotDrawing
        RemoveHandler PictureBox1.MouseMove, AddressOf PictureBox1_MouseMove_MovingPolygon
        RemoveHandler PictureBox1.MouseUp, AddressOf PictureBox1_MouseUp_MovingPolygon
    End Sub
    Dim mouse_pt0 As Point
    ' See if we're over a polygon or corner point.
    Private Sub PictureBox1_MouseMove_NotDrawing(sender As Object, e As MouseEventArgs)
        '      Dim new_cursor As Cursor = Cursors.Cross

        ' See what we're over.
        Dim mouse_pt As Point = SnapToGrid(e.Location)
        Dim hit_polygon As List(Of Point)
        Dim hit_point As Integer, hit_point2 As Integer
        Dim closest_point As Point
        mouse_pt0 = mouse_pt
        'If MouseIsOverCornerPoint(mouse_pt, hit_polygon, hit_point) Then
        '    new_cursor = Cursors.Arrow
        'ElseIf MouseIsOverEdge(mouse_pt, hit_polygon, hit_point, hit_point2, closest_point) Then
        '    new_cursor = AddPointCursor
        'ElseIf MouseIsOverPolygon(mouse_pt, hit_polygon) Then
        '    new_cursor = Cursors.Hand
        'End If

        ' Set the new cursor.
        'If PictureBox1.Cursor <> new_cursor Then
        '    PictureBox1.Cursor = new_cursor
        'End If
    End Sub

    ' Redraw old polygons in blue. Draw the new polygon in green.
    ' Draw the final segment dashed.
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        ' Dim TransBrush As New SolidBrush(Color.FromArgb(128, 100, 255, 255))
        Dim TransBrush As New SolidBrush(Color.FromArgb(100, 80, 78, 76))
        ' Draw the old polygons.
        Dim hit_polygon As List(Of Point)
        Dim polygon0 As List(Of Point)
        Dim area As Double
        For Each polygon As List(Of Point) In Polygons
            ' Draw the polygon.

            If MouseIsOverPolygon(mouse_pt0, hit_polygon) Then

                e.Graphics.DrawPolygon(Pens.Red, polygon.ToArray())

            End If
            e.Graphics.FillPolygon(TransBrush, polygon.ToArray())
            e.Graphics.DrawPolygon(Pens.Gray, polygon.ToArray())
            ' Draw the corners.
            For Each corner As Point In polygon



                Dim rect As New System.Drawing.Rectangle(corner.X - object_radius, corner.Y - object_radius, 2 * object_radius + 1, 2 * object_radius + 1)
                ' e.Graphics.FillEllipse(TransBrush, rect)
                e.Graphics.DrawRectangle(Pens.Gray, rect)
                ' e.Graphics.DrawEllipse(Pens.Black, rect)
            Next


        Next
        

        ' Draw the new polygon.
        If NewPolygon IsNot Nothing Then
            ' Draw the new polygon.
            If NewPolygon.Count > 1 Then
                '130, 176, 190
                Dim pn As New Pen(Color.FromArgb(51, 49, 47))
                e.Graphics.DrawLines(pn, NewPolygon.ToArray())

            End If

            ' Draw the newest edge.
            If NewPolygon.Count > 0 Then
                Using dashed_pen As New Pen(Color.Gray)
                    dashed_pen.DashPattern = New Single() {3, 3}
                    e.Graphics.DrawLine(dashed_pen, NewPolygon(NewPolygon.Count - 1), NewPoint)
                End Using
            End If
        End If
    End Sub

    ' See if the mouse is over a corner point.
    Private Function MouseIsOverCornerPoint(mouse_pt As Point, ByRef hit_polygon As List(Of Point), ByRef hit_pt As Integer) As Boolean
        ' See if we're over a corner point.
        For Each polygon As List(Of Point) In Polygons
            ' See if we're over one of the polygon's corner points.
            For i As Integer = 0 To polygon.Count - 1
                ' See if we're over this point.
                If FindDistanceToPointSquared(polygon(i), mouse_pt) < over_dist_squared Then
                    ' We're over this point.
                    hit_polygon = polygon
                    hit_pt = i
                    Return True
                End If
            Next
        Next

        hit_polygon = Nothing
        hit_pt = -1
        Return False
    End Function

    ' See if the mouse is over a polygon's edge.
    Private Function MouseIsOverEdge(mouse_pt As Point, ByRef hit_polygon As List(Of Point), ByRef hit_pt1 As Integer, ByRef hit_pt2 As Integer, ByRef closest_point As Point) As Boolean
        ' Examine each polygon.
        ' Examine them in reverse order to check the ones on top first.
        For pgon As Integer = Polygons.Count - 1 To 0 Step -1
            Dim polygon As List(Of Point) = Polygons(pgon)

            ' See if we're over one of the polygon's segments.
            For p1 As Integer = 0 To polygon.Count - 1
                ' Get the index of the polygon's next point.
                Dim p2 As Integer = (p1 + 1) Mod polygon.Count

                ' See if we're over the segment between these points.
                Dim closest As PointF
                If FindDistanceToSegmentSquared(mouse_pt, polygon(p1), polygon(p2), closest) < over_dist_squared Then
                    ' We're over this segment.
                    hit_polygon = polygon
                    hit_pt1 = p1
                    hit_pt2 = p2
                    closest_point = Point.Round(closest)
                    Return True
                End If
            Next
        Next

        hit_polygon = Nothing
        hit_pt1 = -1
        hit_pt2 = -1
        closest_point = New Point(0, 0)
        Return False
    End Function

    ' See if the mouse is over a polygon's body.
    Private Function MouseIsOverPolygon(mouse_pt As Point, ByRef hit_polygon As List(Of Point)) As Boolean
        ' Examine each polygon.
        ' Examine them in reverse order to check the ones on top first.
        For i As Integer = Polygons.Count - 1 To 0 Step -1
            ' Make a GraphicsPath representing the polygon.
            Dim path As New GraphicsPath()
            path.AddPolygon(Polygons(i).ToArray())

            ' See if the point is inside the GraphicsPath.
            If path.IsVisible(mouse_pt) Then
                hit_polygon = Polygons(i)
                Return True
            End If
        Next

        hit_polygon = Nothing
        Return False
    End Function

#Region "DistanceFunctions"

    ' Calculate the distance squared between two points.
    Private Function FindDistanceToPointSquared(pt1 As Point, pt2 As Point) As Integer
        Dim dx As Integer = pt1.X - pt2.X
        Dim dy As Integer = pt1.Y - pt2.Y
        Return dx * dx + dy * dy
    End Function

    ' Calculate the distance squared between
    ' point pt and the segment p1 --> p2.
    Private Function FindDistanceToSegmentSquared(pt As PointF, p1 As PointF, p2 As PointF, ByRef closest As PointF) As Double
        Dim dx As Single = p2.X - p1.X
        Dim dy As Single = p2.Y - p1.Y
        If (dx = 0) AndAlso (dy = 0) Then
            ' It's a point not a line segment.
            closest = p1
            dx = pt.X - p1.X
            dy = pt.Y - p1.Y
            Return Math.Sqrt(dx * dx + dy * dy)
        End If

        ' Calculate the t that minimizes the distance.
        Dim t As Single = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) / (dx * dx + dy * dy)

        ' See if this represents one of the segment's
        ' end points or a point in the middle.
        If t < 0 Then
            closest = New PointF(p1.X, p1.Y)
            dx = pt.X - p1.X
            dy = pt.Y - p1.Y
        ElseIf t > 1 Then
            closest = New PointF(p2.X, p2.Y)
            dx = pt.X - p2.X
            dy = pt.Y - p2.Y
        Else
            closest = New PointF(p1.X + t * dx, p1.Y + t * dy)
            dx = pt.X - closest.X
            dy = pt.Y - closest.Y
        End If

        ' return Math.Sqrt(dx * dx + dy * dy);
        Return dx * dx + dy * dy
    End Function

#End Region

    ' The grid spacing.
    Private Const GridGap As Integer = 20

    ' Snap to the nearest grid point.
    Private Function SnapToGrid(point As Point) As Point
        Dim x As Integer = GridGap * CInt(Math.Round(CSng(point.X) / GridGap))
        Dim y As Integer = GridGap * CInt(Math.Round(CSng(point.Y) / GridGap))
        Return New Point(x, y)
    End Function

    ' Give the PictureBox a grid background.
    Private Sub PictureBox1_Resize(sender As Object, e As EventArgs) Handles PictureBox1.Resize
        MakeBackgroundGrid()
    End Sub
    Private Sub MakeBackgroundGrid()
        'Dim bm As New Bitmap(PictureBox1.ClientSize.Width, PictureBox1.ClientSize.Height)
        Dim x As Integer = 0
        While x < PictureBox1.ClientSize.Width
            Dim y As Integer = 0
            While y < PictureBox1.ClientSize.Height
                bm.SetPixel(x, y, Color.Green)
                y += GridGap
            End While
            x += GridGap
        End While

        PictureBox1.BackgroundImage = bm
    End Sub
#End Region
    Public IsDragging As Boolean = False
    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        'PictureBox1.Refresh()
        If e.X > rec Then
            check = True
        End If
        If e.Y > rec1 Then
            check = False
        End If
        If d = 1 Then

          

            PictureBox1.Refresh()
            PictureBox1.CreateGraphics.DrawLine(Pens.Cyan, e.X, rec1, rec, rec1)
            PictureBox1.CreateGraphics.DrawLine(Pens.Cyan, rec, e.Y, rec, rec1)
            PictureBox1.CreateGraphics.DrawLine(Pens.Cyan, e.X, e.Y, e.X, rec1)
            PictureBox1.CreateGraphics.DrawLine(Pens.Cyan, e.X, e.Y, rec, e.Y)
            rec = TextBox10.Text
            rec1 = TextBox9.Text

        End If



        If DrawFreeLineToolStripMenuItem.Checked Then


            'free line
            LocalMousePosition = PictureBox1.PointToClient(Cursor.Position)
            'Dim PurplePen As New Pen(Color.Purple, 3)
            Dim myArray As Point() = {New Point(p1, q1), New Point(e.X, e.Y)}
            Dim myPath As New GraphicsPath
            'Label2.Text = "(X=" & LocalMousePosition.X & "  " & "Y=" & LocalMousePosition.Y & ")"
            '-----
            ' myGraphics.DpiX.ToString & " " & myGraphics.DpiY.ToString ===96dpi
            '-----
            Dim v = Label1.Text
            Dim qq1 = Label2.Text
            If Label1.Text.Count = 1 Then v = "000" + v
            If Label1.Text.Count = 2 Then v = "00" + v
            If Label1.Text.Count = 3 Then v = "0" + v

            If Label2.Text.Count = 1 Then qq1 = "000" + qq1
            If Label2.Text.Count = 2 Then qq1 = "00" + qq1
            If Label2.Text.Count = 3 Then qq1 = "0" + qq1

            If eventString = "L" Then
                myPath.StartFigure()
                myPath.AddLines(myArray)
                myPath.CloseFigure()
                graph.DrawPath(Pens.Blue, myPath)

                ' TextBox10.Text = e.X
                ' TextBox9.Text = e.Y
                Dim x11 As Integer = iniPointX
                Dim y1 As Integer = inipointY
                Dim x As Integer = p1
                Dim y As Integer = q1
                Dim thin As Integer = 10
                Dim hegh As Integer = 10
                '  TextBox8.Text = e.X
                '  TextBox7.Text = e.Y
                'If dxf.Text = 2 Then
                graph.DrawLine(Pens.Red, p1, q1, e.X, e.Y)
                TextBox6.Text = TextBox6.Text & vbCrLf & "0" & vbCrLf & "LINE" & vbCrLf & "8" & vbCrLf & TextBox13.Text & vbCrLf & "62" & vbCrLf & TextBox12.Text & vbCrLf & "10" & vbCrLf & -e.X / 100 & vbCrLf & "20" & vbCrLf & e.Y / 100 & vbCrLf & "30" & vbCrLf & "0.0" & vbCrLf & "11" & vbCrLf & -p1 / 100 & vbCrLf & "21" & vbCrLf & q1 / 100 & vbCrLf & "31" & vbCrLf & "0"
                Form1.DataGridView1.Rows.Add(p1, q1, hegh, e.X, e.Y, hegh)
                Form1.DataGridView1.Rows.Add(p1, q1, hegh + thin, e.X, e.Y, hegh + thin)
                Dim sw As StreamWriter
                If (Not System.IO.File.Exists("C:\mokawalat\kroky.dxf")) Then
                    sw = System.IO.File.CreateText("C:\mokawalat\kroky.dxf")
                    '  sw.WriteLine("Start Error Log for today")
                Else

                    sw = System.IO.File.AppendText("C:\mokawalat\kroky.dxf")
                End If
                sw.WriteLine(TextBox6.Text)
                'Dim row = ritxt.Lines(i) & If(i < ritxt.Lines.Length - 1, Environment.NewLine, "")
                'cellvalue = row.Split(","c) 'check what is ur separator

                'DataGridView2.Rows.Add(cellvalue)
                'End If

                '                DataGridView1.Rows.Add(TextLine.Split(" ")(0), TextLine.Replace(TextLine.Split(" ")(0), "").Substring(1))
                sw.Close()










                dxf.Text = 0
                'PictureBox1.Image = bm
                'End If
                If YesToolStripMenuItem.Checked Then
                    FileOpen(1, ToolStripTextBox2.Text, OpenMode.Append)
                    ' FileOpen(2, "E:\hh.txt", OpenMode.Append)

                    PrintLine(1, v & " " & qq1)

                    ' PrintLine(2, v & " " & qq1 & " " & z1.Text)
                    FileClose(1)
                    ' FileClose(2)
                    NoToolStripMenuItem.Checked = False
                End If
                If Not (p1 = e.X And q1 = e.Y) Then 'Weed out consecutive points with same coordinates
                    ' TextBox5.Text = TextBox5.Text & LocalMousePosition.X & "," & LocalMousePosition.Y & vbNewLine
                    '  ListBox1.Items.Add(p1)
                    'ListBox2.Items.Add(q1)
                End If
                T_lines += 1 'Textbox Line #
                dxf.Text += 1
                Dragged = True
                ' Button4.Enabled = False
                '  Button1.Enabled = True
            End If


            If eventString = Nothing Then
                myPath.Reset()
                graph.Flush()
            End If


            p1 = e.X
            q1 = e.Y
            PictureBox1.Image = bm
        End If

        '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        'dxf
        If DrawLineToolStripMenuItem.Checked = True Then
            PictureBox1.Refresh()
            Dim x As Integer = TextBox8.Text
            Dim y As Integer = TextBox7.Text
            Dim gr As Graphics = Me.PictureBox1.CreateGraphics
            If dxf.Text = 1 Then
                ' gr.DrawLine(Pens.Red, x, y, e.X, e.Y)
            End If
            PictureBox1.CreateGraphics.DrawString("x=" & e.X & "," & "y=" & e.Y, New Font("Proxy 7", 9), Brushes.White, e.X + 10, e.Y + 10)
            DrawFreeLineToolStripMenuItem.Checked = False
        End If
    End Sub
    Private Sub HandMovePoints()
        Dim counter As Integer = 2
        Dim list As String = Trim(TextBox5.Text)
        Dim pts() As String = TextBox5.Text.Split(CChar(vbNewLine)) '(New Char() {" "c})
        Dim pts1() As String
        Dim Area As Double
        Dim ArStruct As New ArrayList
        Dim myPath As New GraphicsPath
        ' Dim TransBrush As New SolidBrush(Color.FromArgb(128, 100, 255, 255))


        list = ""

        Dim word As String
        For Each word In pts
            If word.Length > 2 Then
                list = list & word & vbNewLine
                counter += 1
            End If
        Next
        TextBox5.Text = iniPointX.ToString & "," & inipointY.ToString & vbNewLine & list & iniPointX.ToString & "," & inipointY.ToString

        list = ""
        pts = Nothing
        Label2.Text = "Trace Points:" & (counter.ToString)
        pts = TextBox5.Text.Split(CChar(vbNewLine))
        ' MessageBox.Show(UBound(pts).ToString)
        Dim px(pts.Count + 1) As Point
        For counter = 0 To UBound(pts)

            Dim ms As New MyStruct1
            pts1 = pts(counter).Split(","c)

            'create path for fill polygon here here?
            'Dim myArray As Point() = {New Point(p1, q1), New Point(ms.L, ms.R)}
            'myPath.AddLines(myArray)
            px(counter).X = CInt(pts1(0))
            px(counter).Y = CInt(pts1(1))
            ms.L = CDbl(pts1(0))
            ms.R = CDbl(pts1(1))
            ArStruct.Add(ms)

        Next
        px(UBound(pts)) = px(0)
        'Dim TransBrush As New SolidBrush(ColorDialog1.Color)
        Dim r1 As Integer = 5
        Dim r2 As Integer = 10
        Dim r3 As Integer = 100
        Dim r4 As Integer = 10
        'If CheckBox15.Checked Then

        '    Dim TransBrush As New SolidBrush(Color.FromArgb(r1, r2, r3, r4))
        '    graph.FillPolygon(TransBrush, px)
        '    'If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    'Dim mypen As New System.Drawing.Pen(ColorDialog1.Color)
        '    ' mypen.Color = ColorDialog1.Color
        '    ' End If
        'Else
        '    If CheckBox18.Checked Then
        '        Dim TransBrush As New SolidBrush(Color.FromArgb(128, 100, 255, 255))
        '        graph.FillPolygon(TransBrush, px)
        '    End If
        'End If
        ' d.FillPolygon(TransBrush, px)
        For counter = 0 To ArStruct.Count - 2
            Area = Area + (ArStruct(counter).L + ArStruct(counter + 1).L) * (ArStruct(counter + 1).R - ArStruct(counter).R) / 2
        Next
        Area = Math.Abs(Area)
        ' Label3.Text = "Area= " & (Area / (myGraphics1.DpiX * myGraphics1.DpiY)).ToString & " In.²"
        PictureBox1.Image = bm
    End Sub
    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        eventString = Nothing
        'If Dragged = True Then Button4.Enabled = False
        If DrawFreeLineToolStripMenuItem.Checked Then
            HandMovePoints()

        End If
    End Sub
    Structure MyStruct1

        Property L As Integer

        Property R As Integer

    End Structure


    Private Sub Sketch_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SaveFormSize(Me)  'Get to save  size & Position of Form in Registry

        main.Enabled = True
    End Sub
    Private Sub Sketch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ToolStripTextBox1.Text = "C:\mokawalat\kroky.dxf"
        ToolStripTextBox2.Text = "C:\mokawalat\kroky.txt"
        PictureBox1.BackColor = Color.FromArgb(60, 70, 73)
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry
        Centimetres()
        PictureBox1.Image = bm
    End Sub

    Private Sub DrawLineToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DrawLineToolStripMenuItem.Click
        DrawLineToolStripMenuItem.Checked = True
        DrawFreeLineToolStripMenuItem.Checked = False
    End Sub

    Private Sub DrawFreeLineToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DrawFreeLineToolStripMenuItem.Click
        DrawLineToolStripMenuItem.Checked = False
        DrawFreeLineToolStripMenuItem.Checked = True
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Polygons.Clear()
        PictureBox1.Invalidate()

        If (Not System.IO.File.Exists("C:\mokawalat\kroky.dxf")) Then
        Else
            System.IO.File.WriteAllText("C:\mokawalat\kroky.dxf", "")
        End If
        graph.Clear(Color.FromArgb(60, 70, 73))
        TextBox6.Text = ""
        TextBox6.Text = TextBox6.Text & "0" & vbCrLf & "SECTION" & vbCrLf & "  2" & vbCrLf & "ENTITIES"
        PictureBox1.Refresh()
        TextBox10.Text = "0"
        TextBox9.Text = "0"
        TextBox8.Text = "0"
        TextBox7.Text = "0"
        Centimetres()
        PictureBox1.Image = bm
    End Sub

    Private Sub filesave_Click(sender As System.Object, e As System.EventArgs) Handles filesave.Click
        ' Dim fp1 As New Process()
        'fp1.StartInfo = New ProcessStartInfo("C:\Users\ehab magdy\Desktop\New folder\GraphicsDisplay\GraphicsDisplay\bin\Debug\GraphicsDisplay.exe")
        'fp1.Start()
        ' form2.Show()
        TextBox6.Text = TextBox6.Text & vbCrLf & "0" & vbCrLf & "ENDSEC" & vbCrLf & "0" & vbCrLf & "EOF"
        My.Computer.FileSystem.WriteAllText(ToolStripTextBox1.Text, Me.TextBox6.Text, False, System.Text.Encoding.ASCII)
    End Sub

    Private Sub NoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NoToolStripMenuItem.Click
        YesToolStripMenuItem.Checked = False

        NoToolStripMenuItem.Checked = True
    End Sub

    Private Sub YesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles YesToolStripMenuItem.Click
        YesToolStripMenuItem.Checked = True

        NoToolStripMenuItem.Checked = False
    End Sub

    Private Sub DToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DToolStripMenuItem.Click
        Form1.Show()
    End Sub


    Private Sub Form5_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        PictureBox1.Size = Me.Size
    End Sub

    Public Function Centimetres() As System.Drawing.Image
        Dim Afont As New System.Drawing.Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Pixel)
        ' Dim gfr As Graphics = Graphics.FromImage(bm)
        ' Dim Cm As Single = 5.08
        Dim colr As New Pen(Color.FromArgb(45, 47, 49))
        For m As Integer = 0 To bm.Height - 1 Step 5
            ' gfr.DrawLine(SystemPens.ButtonFace, 0, m, 2, m)
            graph.DrawLine(Pens.Gray, 0, m, 2, m)



            Select Case m Mod 40

                Case 20

                    graph.DrawLine(colr, 0, m, 3000, m)

                Case 0

                    graph.DrawLine(colr, 0, m, 3000, m)

                    If m > 6 Then
                        graph.DrawString(((m) \ 40).ToString, Afont, Brushes.Orange, 11, (m) - 6)

                    End If


            End Select
        Next
        For m As Integer = 0 To bm.Width - 1 Step 5

            graph.DrawLine(Pens.Gray, m, 0, m, 2)

            Select Case m Mod 40

                Case 20
                    graph.DrawLine(colr, m, 0, m, 3000)

                Case 0
                    graph.DrawLine(colr, m, 0, m, 3000)

                    If m > 3 Then
                        graph.DrawString(((m + 1) \ 40).ToString, Afont, Brushes.Orange, m - 3, 11)

                    End If


            End Select
        Next
        graph.DrawString("0", Afont, Brushes.Orange, 2, 1)

        ' Return bm
    End Function
    Private Sub no_Click(sender As System.Object, e As System.EventArgs) Handles No.Click
        Yes.Checked = False
        No.Checked = True
    End Sub
    Private Sub Yes_Click(sender As System.Object, e As System.EventArgs) Handles Yes.Click
        Yes.Checked = True
        No.Checked = False
    End Sub

    Private Sub DrawWithSnapToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DrawWithSnapToolStripMenuItem.Click

    End Sub

    Private Sub Yescolumn_Click(sender As System.Object, e As System.EventArgs) Handles Yescolumn.Click
        Yescolumn.Checked = True
        Nocolumn.Checked = False
    End Sub

    Private Sub Nocolumn_Click(sender As System.Object, e As System.EventArgs) Handles Nocolumn.Click
        Yescolumn.Checked = False
        Nocolumn.Checked = True
    End Sub

    Private Sub DrawStarisToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DrawStarisToolStripMenuItem.Click
        staris.Show()
    End Sub



    'Add these to your form class
    Private MouseIsDown As Boolean = False
    Private MouseIsDownLoc As Point = Nothing
     
    'This is the MouseMove event of your panel
    Private Sub Panel1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
      
        If e.Button = MouseButtons.Left Then

            If MouseIsDown = False Then
                MouseIsDown = True
                MouseIsDownLoc = New Point(e.X, e.Y)
            End If
            Me.Invalidate()
            Panel1.Location = New Point(Panel1.Location.X + e.X - MouseIsDownLoc.X, Panel1.Location.Y + e.Y - MouseIsDownLoc.Y)

        End If
    End Sub

    'And the MouseUp event of your panel
    Private Sub Panel1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        MouseIsDown = False
    End Sub
    Dim yu As Boolean = True

    Private Sub Label59_Click(sender As System.Object, e As System.EventArgs) Handles Label59.Click

        If yu = True Then
            Panel1.Size = New Point(221, 632)
            yu = False
        ElseIf yu = False Then
            Panel1.Size = New Point(221, 22)
            yu = True
        End If


    End Sub

   
End Class
