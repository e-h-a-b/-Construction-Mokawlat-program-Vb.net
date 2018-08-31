Imports System.Drawing.Drawing2D
Imports AdvanceMath
Imports Geometry3D
Imports System.IO
Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Public Class _3DCanvas0
     
#Region "EVENTS"

    '  Dim sc As New MSScriptControl.ScriptControl
    Private Sub _3DCanvas0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        shift = e.KeyCode
    End Sub

    Private Sub _3DCanvas0_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        shift = 0
    End Sub

    Private Sub _3DCanvas0_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        g = Me.CreateGraphics
        OrbitRadius = 200
        OrbitSpeed = 0.000001
        Rw = 1000
        Viewtheta = 0
        Viewfi = 0
        g000 = Me.CreateGraphics
        Focus3D = New Point3D(0, 0, 0)
        View2D.Centre.X = 0
        View2D.Centre.Y = 0
        ' sc.Language = "vbscript"
        'Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)


    End Sub

#End Region

    Public zoomfactor As Single = 1

    Private Axis(3) As Segment3D
    Private Axis1(3) As Segment3D
    ' Dim yAxis As Segment3D
    ' Dim zAxis As Segment3D

    Private Viewtheta, Viewfi As Single
    Private Focus3D As Point3D = Origin3D()

    Private LastMousePosition As Point

    Private pt3dC(7) As Point3D
    ' Dim Centre As Point3D

    Private OrbitRadius As Single
    Private OrbitSpeed As Single
    Private Cam3D As New Camera3D
    Private grxhi As Long, gryhi As Long 'Number of grids

    Const LStep As Long = 15 ' Need 360\LStep = integer
    Const zpi# = 3.1415927
    Const dtr# = zpi# / 180

    ' Public Light_Sources As New Collection
    Private Property Font As System.Drawing.Font
    Private Rw As Single
    Private shift As Integer


    Private Structure View2DParam
        Dim Centre As Point
    End Structure
    Dim l01, l11, l12 As Integer
    Dim l0 As Integer = 0
    Dim l1 As Integer = 0
    Dim l2 As Integer = 0
    Private Sub _3DCanvas0_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        LastMousePosition.X = e.X
        LastMousePosition.Y = e.Y
        'Form1.DataGridView1.Rows.Add({l01, l11, l12, l0, l1, l2})
        StopAutorotation()
    End Sub
    Private View2D As View2DParam
    Public Light_Sources As New Microsoft.VisualBasic.Collection
    Private Sub _3DCanvas0_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        xaxi = e.X
        yaxi = e.Y

        ' ListBox1.Items.Add("0 " & "0 " & "0 " & e.X & " " & e.Y & "0 " & "00")

        dx = e.X - LastMousePosition.X
        dy = e.Y - LastMousePosition.Y
        If Math.Abs(dx) + Math.Abs(dy) = 0 Then Exit Sub
        If e.Button = Windows.Forms.MouseButtons.Left Then Debug.Print(shift)

        If e.Button = Windows.Forms.MouseButtons.Left Then
            If shift = 88 Then '"X" is pressed: rotate about X axis
                Cam3D.RotateCamera(-dy * 1.2, 0, 0)
            ElseIf shift = 89 Then '"y" is pressed: rotate about y axis
                Cam3D.RotateCamera(0, -dx * 1.2, 0)
            ElseIf shift = 90 Then '"z" is pressed: rotate about z axis
                Cam3D.RotateCamera(0, 0, -dx * 1.2)
            ElseIf shift = 17 Then '"Ctrl" is pressed: rotate Light Source
                Light_Sources(1).rotate(150, dx * 0.6, -dy * 0.5)
            ElseIf shift = 16 Then '"Shift" is pressed: rotate Object
                ' object1.Rotate(-dx * 1.2, -dy * 0.9)
            Else
                Cam3D.RotateCamera(-dx * 1.2, -dy * 0.9)
            End If
            LastMousePosition.X = e.X
            LastMousePosition.Y = e.Y
            Me.Invalidate()
            Exit Sub
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            If shift = 0 Then 'translate Graph
                View2D.Centre.Y = View2D.Centre.Y + dy
                View2D.Centre.X = View2D.Centre.X + dx
            ElseIf shift = 16 Then 'Translate Object
                'object1.tr
            End If

            Me.Invalidate()
            LastMousePosition.X = e.X
            LastMousePosition.Y = e.Y
            Exit Sub
        End If

        LastMousePosition.X = e.X
        LastMousePosition.Y = e.Y

        Me.Invalidate()
    End Sub
    Public g000 As Graphics
    Private g As Graphics
    'Public b As New Bitmap("B:\photo\22.bmp")
    'Private Sub ComboObj_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboObj.SelectedIndexChanged

    '    Me.object1 = SHAPES(Form1.ComboObj.SelectedIndex)
    '    Me.object1.drawMode = DrawStyle.SOLID

    '    Dim m As Matrix4x4
    '    m = Matrix4x4.MatrixScale3D(2, 2, 1)
    '    ' object1.transform(m)
    '    'RotateSelfObject3D( 
    '    'object2 = cylinder ' AddObject3D(object1, cylinder)
    '    Me.Invalidate()
    '    'InvokePaint(c)
    '    'OnPaint()
    '    ' Drawaxis()
    'End Sub
    'Private Sub NumericUpDown1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown1.ValueChanged
    '    Me.Invalidate()

    '    DrawParam3d(Form1.NumericUpDown1.Value)
    'End Sub

    'Private Sub NumericUpDown2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles NumericUpDown2.ValueChanged
    '    Me.Invalidate()
    '    FillCombo()
    '    SHAPES(Form1.NumericUpDown2.Value, 18, 1, 100)
    'End Sub
    
    'Private Sub ComboFunction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboFunction.SelectedIndexChanged
    '    Dim tempS() As String
    '    Dim grxhi, gryhi As Single
    '    Dim zlim, ploti As Single
    '    Dim Svrx(,), Svry(,), Svrz(,) As Single
    '    Dim shape3d(,) As Point3D
    '    Dim cString As String
    '    Dim scx, scy As Single
    '    Dim ilx, ihx, ily, ihy, ilz, ihz As Integer
    '    Dim zpl, zpH As Single
    '    Dim scaleX, scaleY, sCalez As Single
    '    'zpH = 0.8 * picDisplay.ScaleWidth

    '    'Dim YH(0 To 0), YL(0 To 0), XH(0 To 0), XL(0 To 0), ZL(0 To 0), PD(0 To 0)
    '    Dim X, Y As Single
    '    tempS = Split(Form1.ListFunctions.Items.Item(Form1.ComboFunction.SelectedIndex), ",")
    '    '  NuXmin.Value = Val(tempS(2))
    '    '   NuXmax.Value = Val(tempS(3))
    '    ' NuYmin.Value = Val(tempS(4))
    '    '  NuYmax.Value = Val(tempS(5))
    '    '   NuZlimit.Value = Val(tempS(6))
    '    '   NuPlotInterval.Value = Val(tempS(7))

    '    zlim = 80
    '    ploti = 40
    '    grxhi = Val(40)
    '    gryhi = grxhi
    '    'Original function points
    '    ReDim Svrx(grxhi, gryhi)
    '    ReDim Svry(grxhi, gryhi)
    '    ReDim Svrz(grxhi, gryhi)
    '    ReDim shape3d(grxhi, gryhi)
    '    cString = LCase(tempS(0))
    '    SqueezeSpaces(cString)
    '    ' nleftbrackets = NumOccStr(cString, "(")
    '    ' nrightbrackets = NumOccStr(cString, ")")
    '    If NumOccStr(cString, "(") <> NumOccStr(cString, ")") Then
    '        MsgBox("Unmatched brackets")
    '        Exit Sub
    '    End If
    '    ReplaceLOG(cString)
    '    ReplaceASIN(cString)
    '    ReplaceACOS(cString)
    '    ReplaceSINH(cString)
    '    ReplaceCOSH(cString)
    '    ReplaceTANH(cString)
    '    ReplacePI(cString)
    '    ReplaceLN(cString)

    '    'Scale factors for converting grid points to x,y values
    '    scx = (0 - 0) / (grxhi - 1)
    '    scy = (0 - 0) / (gryhi - 1)
    '    zpl = 0.8 * Me.Width / (grxhi - 1)
    '    zpH = 0.2 * Me.Width
    '    scaleX = 0.5 * Me.Width / (0 - 0)
    '    scaleY = 0.5 * Me.Height / (0 - 0)
    '    ' Dim scfx, scfy As Single
    '    ' scfx = (zpH - zpl) / (Xmax - Xmin)
    '    For J = 0 To gryhi
    '        For I = 0 To grxhi
    '            Svrx(I, J) = (scx * (I - 1) + 0) '* 200
    '            Svry(I, J) = (scy * (J - 1) + 0) '* 20
    '            shape3d(I, J).x = (scx * (I - 1) + 0) * scaleX
    '            shape3d(I, J).y = (scy * (J - 1) + 0) * scaleY
    '        Next I
    '    Next J
    '    Dim eString As String
    '    'Fill svrz(i,j) with Func(x,y)
    '    For J = 0 To gryhi
    '        For I = 0 To grxhi
    '            X = Svrx(I, J)
    '            Y = Svry(I, J)
    '            Select Case Form1.ComboFunction.SelectedIndex
    '                Case 0 'Put Perspec On & roll into ball  & do Y-rot only
    '                    Svrz(I, J) = (X) ^ 2 + (Y) ^ 2
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 6 - 60 '* 20 ' scaleX
    '                Case 1 'Saddle
    '                    Svrz(I, J) = X ^ 2 - Y ^ 2
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 5 ' scaleX
    '                Case 2 'Balloon Perspec On & Y-rot only
    '                    Svrz(I, J) = (X ^ 2 + Y ^ 2) ^ 2
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 3 ' scaleX
    '                Case 3 'Butterfly 1
    '                    Svrz(I, J) = Sqrt(Abs((X - 6) ^ 2 - (Y - 6) ^ 2))
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 6 ' scaleX
    '                Case 4 'Butterfly 2
    '                    Svrz(I, J) = (X + Y) ^ 2
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 35 ' scaleX
    '                Case 5 'Bent strip 1
    '                    Svrz(I, J) = X ^ 2 + Abs(Y) ^ 0.5
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 9 ' scaleX
    '                Case 6 'Bent strip 2
    '                    Svrz(I, J) = Y ^ 4 - Y ^ 2 - X ^ 2
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 8 ' scaleX
    '                Case 7 'cornered cone
    '                    Svrz(I, J) = Sqrt(X ^ 2 + Y ^ 2)
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 15 ' scaleX
    '                Case 8 'Cubic twisted strip
    '                    Svrz(I, J) = X ^ 3 + 2 * X * Y + Y ^ 2
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 6 ' scaleX
    '                Case 9 'Edge spike
    '                    Svrz(I, J) = Exp(-(X ^ 2 + Y ^ 2))
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 100 ' scaleX
    '                Case 10 'Center spike 1
    '                    Svrz(I, J) = 2 * Sin(Sqrt((X / 4) ^ 2 + (Y / 4) ^ 2))
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 50 ' scaleX
    '                Case 11 'Center spike 2
    '                    Svrz(I, J) = Tanh((2 * X) ^ 2 + (2 * Y) ^ 2)
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 120 ' scaleX
    '                Case 12 'Concentric rings
    '                    Svrz(I, J) = Sin(Sqrt(X ^ 2 + Y ^ 2))
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 20 ' scaleX
    '                Case 13 'Trig hills Egg holder
    '                    Svrz(I, J) = Sin(X) + Cos(Y)
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 12 ' scaleX
    '                Case 14 'ledge
    '                    Svrz(I, J) = Sinh(X + Y)
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 12 ' scaleX
    '                Case 15 ' Bat wing
    '                    Svrz(I, J) = Cosh(X + Y)
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 12 ' scaleX
    '                Case 16 'Flying sheet
    '                    Svrz(I, J) = Tanh(X + Y)
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 50 ' scaleX
    '                Case 17 'Stingray
    '                    Svrz(I, J) = Sqrt(Abs(Tanh(X + Y)))
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 120 ' scaleX
    '                Case 18 'Sheet with bent corner
    '                    Svrz(I, J) = 2 * Acos(X / 22 + Y / 22)
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 80 - 100 ' scaleX
    '                Case 19 ' Log sheet(ignore error)
    '                    Svrz(I, J) = IIf(X + Y > 0, Log10(X + Y), 0)
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 12 ' scaleX
    '                Case 20 'Seat
    '                    Svrz(I, J) = Sinh(X) + Cosh(Y)
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) '* 4 ' scaleX
    '                Case 21 'Corrugated sheet
    '                    Svrz(I, J) = (X - Sin(X)) + (Y - Cos(X))
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 20 ' scaleX
    '                Case 22 'Shaver head
    '                    Svrz(I, J) = Cos(X) ^ 3 + Sin(X) ^ 3
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 20 ' scaleX
    '                Case 23 'Wicker chairs
    '                    Svrz(I, J) = (X ^ 3 + Y ^ 3) - 12 * X * Y
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 0.6 ' scaleX
    '                Case 24 'Escalators, 
    '                    Svrz(I, J) = X * Cos(Y)
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 10 ' scaleX
    '                Case 25 '3D corner
    '                    Svrz(I, J) = Exp(-2 * X * Y)
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 30 ' scaleX
    '                    shape3d(I, J).x = shape3d(I, J).x + 180
    '                    shape3d(I, J).y = shape3d(I, J).y + 140
    '                Case 26 ' Spiked waves
    '                    Svrz(I, J) = Exp(-Abs(Cos(X + Y)))
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 50 ' scaleX
    '                    shape3d(I, J).x = shape3d(I, J).x + 260
    '                    shape3d(I, J).y = shape3d(I, J).y + 190
    '                Case 27 'Domed surface
    '                    Svrz(I, J) = Exp(-Abs(Cos(X) + Sin(Y)))
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = -Svrz(I, J) * 120 + 110 ' scaleX
    '                    shape3d(I, J).x = shape3d(I, J).x + 260
    '                    shape3d(I, J).y = shape3d(I, J).y + 190
    '                Case 28 'Wavy sheet
    '                    Svrz(I, J) = Atan(Cos(X + Y) + Sin(X + Y))
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 80 ' scaleX
    '                Case 29 'Origami?
    '                    Svrz(I, J) = CInt(Cos(X + Y) + Sin(X + Y))
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 40 ' scaleX

    '                Case Else
    '                    eString$ = cString
    '                    ReplaceXY(eString$, X, Y)
    '                    '---------------------------------------------
    '                    Svrz(I, J) = Sin(X) + Cos(Y) 'sc.Eval(eString$)  'MS Script EvalCInt(Cos(X + Y) + Sin(X + Y)) 'Atan(Cos(X + Y) + Sin(X + Y)) '4 '
    '                    '---------------------------------------------
    '                    If Svrz(I, J) < -zlim Then Svrz(I, J) = -zlim
    '                    If Svrz(I, J) > zlim Then Svrz(I, J) = zlim
    '                    shape3d(I, J).z = Svrz(I, J) * 20 ' scaleX
    '            End Select
    '        Next I
    '    Next J

    '    'Exit Sub
    '    'Used with scaling factors
    '    'zpL = 0.2 * picDisplay.ScaleWidth
    '    'z'pH = 0.8 * picDisplay.ScaleWidth
    '    Dim Obj As New Object3D
    '    With Obj
    '        Obj.NumPages = (grxhi - 1) * (gryhi - 1)
    '        ReDim Obj.Page(Obj.NumPages - 1)
    '        .ColEdge = Color.White.ToArgb
    '        For i = 0 To grxhi - 2
    '            For j = 0 To gryhi - 2
    '                With .Page(i * (gryhi - 1) + j)
    '                    .Edgecolor = Color.Blue
    '                    .faceColor = Color.Black 'IIf(i = 0, Color.Red, Color.FromArgb(150, 255 - Math.Abs(z), (Math.Abs(2 * i)) Mod 255))
    '                    .filled = True
    '                    .AddPoint(shape3d(j, i))
    '                    .AddPoint(shape3d(j + 1, i))
    '                    .AddPoint(shape3d(j + 1, i + 1))
    '                    .AddPoint(shape3d(j, i + 1))
    '                    .NumPoints = 4
    '                    ReDim .Point(4)
    '                    .Point(1) = shape3d(j, i) 'Point3D(Shape3D(, y1, z)
    '                    .Point(2) = shape3d(j + 1, i) 'Point3D(x, y, z)
    '                    .Point(3) = shape3d(j + 1, i + 1) 'Point3D(x, y, z + dZ)
    '                    .Point(4) = shape3d(j, i + 1) 'Point3D(x1, y1, z + dZ)
    '                    .Point(0) = midPoint3D(midPoint3D(.Point(1), .Point(3)), midPoint3D(.Point(2), .Point(4))) 'Center point of page
    '                End With
    '            Next
    '        Next
    '    End With

    '    Me.object1 = Obj

    '    Me.Invalidate()

    'End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        ' _3DCanvas04.Refresh()

        '  _3DCanvas1.Invalidate()
        '  g000.Clear(Color.FromArgb(242, 242, 242))
        '  _3DCanvas04.CreateGraphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        ' _3DCanvas04.Refresh()










        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g000 = e.Graphics
        g000.Clear(Color.FromArgb(60, 70, 73))
        'For i = 0 To 2
        '    ' testing of z buffer ...> DrawLine3D(Cam3D.Project3Dto2D(FleshAxis(i).Point(1)), Cam3D.Project3Dto2D(FleshAxis(i).Point(2)), FleshAxis(i).Edgecolor)
        '    FleshAxis(i).drawEdge = True
        '    DrawPage3D(FleshAxis(i), DrawStyle.WIREFRAME)
        'Next
        'DrawObject3D(object1)
        '  gxs = _3DCanvas1.CreateGraphics
        'Dim cube3d As New Object3D
        'cube3d = MakeCube(100, 100, 100)

        'object1 = cube3d

        'cube3d.drawMode = DrawStyle.WIREFRAME

        'DrawObject3D(object1)
        'DrawObject3D(cube3d)


        'DrawParam3d(10)




        'Dim Axis3D As Object3D
        'Axis3D = ObjTest()
        'Axis3D.drawMode = DrawStyle.WIREFRAME

        'DrawObject3D(Axis3D)




        sd()
        Drawaxis()





    End Sub
    Private Axisf(2) As Segment3D
    Private col As Color
    Private pt1 As Point3D
    Private ico As Integer
    Private textaxies As String
    Private xaxi As Integer
    Private yaxi As Integer
    Public Sub Drawaxis()
        For i = 0 To 2

            If i = 0 Then col = Color.Red : textaxies = "x"
            If i = 1 Then col = Color.Green : textaxies = "y"
            If i = 2 Then col = Color.Blue : textaxies = "z"

            ' g.DrawString(Cam3D.Theta.ToString & ":" & Cam3D.Fi.ToString, Me.Font, New SolidBrush(Color.Coral), New PointF(10, 20))
            '   g000.DrawString(" X = " & Rw * Sin(Viewfi) * Cos(Viewtheta).ToString & "  :  " & " Y = " & Rw * Sin(Viewfi) * Sin(Viewtheta).ToString & "  :  " & _
            '   " Z = " & Rw * Cos(Viewfi).ToString, _3DCanvas0.Font, New SolidBrush(Color.Coral), New PointF(10, 10))

            drawaxies(textaxies, Axis(i).pt1, Axis(i).pt2, col)
            drawline1(Axis1(i).pt1, Axis1(i).pt2, col)
            drawaxiesmov(textaxies, Axis1(i).pt1, Axis1(i).pt2, Axis(0).pt1, col)
        Next
        'drawcube()
        '  AlphaImage(New Point3D(0, 0, 0), New Point3D(100, 100, 0), 3)
       For i = 0 To HDcount
            Axisf(0) = New Segment3D(New Point3D(HD1(i).x * zoomfactor, HD1(i).y * zoomfactor, HD1(i).z * zoomfactor), New Point3D(HD1(i).x1 * zoomfactor, HD1(i).y1 * zoomfactor, HD1(i).z1 * zoomfactor))
            drawline(Axisf(0).pt1, Axisf(0).pt2, Color.Black)
        Next
        : list()
        net()
        Return
        ' DrawWithoutHidden()
    End Sub

    Private chn As Boolean = False
#Region "drawline ,drawcircle , drawstring "
    Private pt2d1, pt2d2 As Point
    Private pt3d As Point3D
    Private pt2d10 As Point3D
    Private pt3d0 As Point3D
    Private eg As Integer = Math.Sqrt(pt2d10.x ^ 2 + pt2d10.y ^ 2)
    Private trnsRedBrush As New SolidBrush(Color.FromArgb(50, 0, 255, 0))
    Public marker As New Rectangle(50, 50, 100, 100)
    Sub drawline(ByVal pt1 As Point3D, ByVal pt2 As Point3D, Optional ByVal col As Color = Nothing, Optional ByVal width As Integer = 1)


        If col = Nothing Then col = Color.FromArgb(180, 80, 100)

        pt3d = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt1.x, pt1.y, pt1.z))
        pt2d1.X = pt3d.x + View2D.Centre.X + 200
        pt2d1.Y = -pt3d.y + View2D.Centre.Y + 200

        pt3d = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt2.x, pt2.y, pt2.z))

        pt2d2.X = pt3d.x + View2D.Centre.X + 200
        pt2d2.Y = -pt3d.y + View2D.Centre.Y + 200

        g000.DrawLine(New Pen(col, width), pt2d1, pt2d2)

        Return
    End Sub
    Sub drawaxiesmov(ByVal text As String, ByVal pt1 As Point3D, ByVal pt2 As Point3D, ByVal pt10 As Point3D, Optional ByVal col As Color = Nothing, Optional ByVal width As Integer = 1)


        If col = Nothing Then col = Color.FromArgb(180, 80, 100)

        pt3d = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt1.x, pt1.y, pt1.z))
        pt2d1.X = pt3d.x + xaxi
        pt2d1.Y = -pt3d.y + yaxi
        '60 >>> x
        '430  >>>> y
        pt3d = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt2.x, pt2.y, pt2.z))

        pt2d2.X = pt3d.x + xaxi
        pt2d2.Y = -pt3d.y + yaxi

        g000.DrawLine(New Pen(col, width), pt2d1, pt2d2)


        ' g000.DrawString(text, New Drawing.Font("Verdana", 10), New SolidBrush(Color.Black), pt2d2.X, pt2d2.Y)




        ' g000.DrawLine(New Pen(Color.Black, 1), xaxi, yaxi - 25, xaxi, yaxi + 25)
        '  g000.DrawLine(New Pen(Color.Black, 1), xaxi - 25, yaxi, xaxi + 25, yaxi)

        ' g000.DrawRectangle(New Pen(Color.Black, 1), xaxi - 5, yaxi - 5, 10, 10)




        pt3d0 = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt10.x, pt10.y, pt10.z))
        pt2d10.x = pt3d0.x + xaxi - View2D.Centre.X - 200
        pt2d10.y = pt3d0.y + yaxi - View2D.Centre.Y - 200

        pt2d10.z = pt3d0.z + eg

        g000.DrawString("x=" & pt2d10.x & vbCrLf & "y=" & pt2d10.y & vbCrLf & "Z=" & pt2d10.z, New System.Drawing.Font("Proxy 7", 9), Brushes.Black, xaxi + 10, yaxi + 10)
        l01 = pt2d10.x
        l11 = pt2d10.y
        l12 = pt2d10.z

        Return

    End Sub
    Sub drawline1(ByVal pt1 As Point3D, ByVal pt2 As Point3D, Optional ByVal col As Color = Nothing, Optional ByVal width As Integer = 1)


        If col = Nothing Then col = Color.FromArgb(180, 80, 100)

        pt3d = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt1.x, pt1.y, pt1.z))
        pt2d1.X = pt3d.x + View2D.Centre.X + 200
        pt2d1.Y = -pt3d.y + View2D.Centre.Y + 200

        pt3d = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt2.x, pt2.y, pt2.z))

        pt2d2.X = pt3d.x + View2D.Centre.X + 200
        pt2d2.Y = -pt3d.y + View2D.Centre.Y + 200

        g000.DrawLine(New Pen(col, width), pt2d1, pt2d2)

        Return
    End Sub
    Sub drawaxies(ByVal text As String, ByVal pt1 As Point3D, ByVal pt2 As Point3D, Optional ByVal col As Color = Nothing, Optional ByVal width As Integer = 5)




        If col = Nothing Then col = Color.FromArgb(180, 80, 100)

        pt3d = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt1.x, pt1.y, pt1.z))
        pt2d1.X = pt3d.x + 50
        pt2d1.Y = -pt3d.y + Me.Height - 50

        pt3d = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt2.x, pt2.y, pt2.z))

        pt2d2.X = pt3d.x + 50
        pt2d2.Y = -pt3d.y + Me.Height - 50

        g000.DrawLine(New Pen(col, width), pt2d1, pt2d2)

        g000.DrawString(text, New Drawing.Font("Verdana", 10), New SolidBrush(Color.Black), pt2d2.X, pt2d2.Y)

        Return
    End Sub
    Sub drawstring(ByVal pt1 As Point3D, ByVal pt2 As Point3D, Optional ByVal col As Color = Nothing, Optional ByVal width As Integer = 1)


        pt3d = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt1.x, pt1.y, pt1.z))
        pt2d1.X = pt3d.x + View2D.Centre.X + 200
        pt2d1.Y = -pt3d.y + View2D.Centre.Y + 200

        'If Form1.CheckBox1.Checked = True Then
        '    g000.DrawString("(" & HD1(ico).x & "&" & HD1(ico).y & "&" & HD1(ico).z & ")", New Drawing.Font("Verdana", 10), New SolidBrush(Color.Black), pt2d1.X, pt2d1.Y)

        'End If
        Return
    End Sub
    Sub drawcirl(ByVal pt1 As Point3D, ByVal pt2 As Point3D, Optional ByVal col As Color = Nothing, Optional ByVal width As Integer = 1)


        pt3d = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt1.x, pt1.y, pt1.z))
        pt2d1.X = pt3d.x + View2D.Centre.X + 200
        pt2d1.Y = -pt3d.y + View2D.Centre.Y + 200

        g000.DrawEllipse(New Pen(Color.Orange, width), pt2d1.X, pt2d1.Y, 5, 5)

        g000.FillEllipse(trnsRedBrush, pt2d1.X, pt2d1.Y, 5, 5)

        Return
    End Sub
    Sub AlphaImage(ByVal pt1 As Point3D, ByVal pt2 As Point3D, Optional ByVal Alpha As Byte = 127)

        Dim cm As New System.Drawing.Imaging.ColorMatrix()
        cm.Matrix33 = CSng(Alpha / 255)
        Using ia As New System.Drawing.Imaging.ImageAttributes
            ia.SetColorMatrix(cm)
            ' g000.DrawImage(b, marker, 0, 0, b.Width, b.Height, GraphicsUnit.Pixel, ia)
        End Using
        pt3d = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt1.x, pt1.y, pt1.z))
        pt2d1.X = pt3d.x + View2D.Centre.X + 200
        pt2d1.Y = -pt3d.y + View2D.Centre.Y + 200
        pt3d = Cam3D.Project3Dto2D(New Geometry3D.Point3D(pt1.x, pt1.y, pt1.z))
        pt2d2.X = pt3d.x + View2D.Centre.X + 200
        pt2d2.Y = -pt3d.y + View2D.Centre.Y + 200

        '  g000.DrawImage(b, New Rectangle(New Point(pt2d1.X, pt2d1.Y), New Point(pt2d2.X, pt2d2.Y)), marker, GraphicsUnit.Pixel)
        Return
    End Sub


#End Region

    Const HD As Integer = 10000 'Set these as applicable
    Private HD1(HD + 2) As Hd3d 'Our points, the extra 2 are for the 3 points of the supertriangle
    Public HDcount As Integer = -1
    Private Structure Hd3d
        Dim x As Single
        Dim y As Single
        Dim z As Single
        Dim x1 As Single
        Dim y1 As Single
        Dim z1 As Single
    End Structure
    Public Sub Add(ByVal x As Single, ByVal y As Single, ByVal z As Single, ByVal x1 As Single, ByVal y1 As Single, ByVal z1 As Single)

        HDcount += 1
        HD1(HDcount).x = x
        HD1(HDcount).y = y
        HD1(HDcount).z = z
        HD1(HDcount).x1 = x1
        HD1(HDcount).y1 = y1
        HD1(HDcount).z1 = z1

    End Sub

    Sub list()


        'On Error Resume Next
        If Form1.CheckBox1.Checked Then
            HDcount = 0
        Else
            HDcount = -1
        End If

        'If Form1.CheckBox8.Checked Then

        'For i As Integer = 0 To Form1.ListBox2.Items.Count - 1

        '    Dim intSpacePos As Integer
        '    Dim strPoint As String = Form1.ListBox2.Items.Item(i)
        '    Dim t As String
        '    Dim r As Integer
        '    Dim u As Integer
        '    Dim y As Integer
        '    Dim y1 As Integer
        '    Dim y2 As Integer
        '    Dim y3 As String

        '    intSpacePos = InStr(strPoint, " ")
        '    t = Trim(Mid(strPoint, 1, intSpacePos)) * zoomfactor
        '    strPoint = Trim(Mid(strPoint, Trim(intSpacePos)))

        '    intSpacePos = InStr(strPoint, " ")
        '    r = Trim(Mid(strPoint, 1, intSpacePos)) * zoomfactor
        '    strPoint = Trim(Mid(strPoint, Trim(intSpacePos)))

        '    intSpacePos = InStr(strPoint, " ")
        '    u = Trim(Mid(strPoint, 1, intSpacePos)) * zoomfactor
        '    strPoint = Trim(Mid(strPoint, Trim(intSpacePos)))

        '    intSpacePos = InStr(strPoint, " ")
        '    y = Trim(Mid(strPoint, 1, intSpacePos)) * zoomfactor
        '    strPoint = Trim(Mid(strPoint, Trim(intSpacePos)))

        '    intSpacePos = InStr(strPoint, " ")
        '    y1 = Trim(Mid(strPoint, 1, intSpacePos)) * zoomfactor
        '    strPoint = Trim(Mid(strPoint, Trim(intSpacePos)))

        '    intSpacePos = InStr(strPoint, " ")
        '    y2 = Trim(Mid(strPoint, 1, intSpacePos)) * zoomfactor
        '    strPoint = Trim(Mid(strPoint, Trim(intSpacePos)))

        '    y3 = Trim(Mid(strPoint, 1, intSpacePos))

        '    Axisf(0) = New Segment3D(New Point3D(t, r, u), New Point3D(y, y1, y2))

        '    drawline(Axisf(0).pt1, Axisf(0).pt2, Color.Black)

        'Next
        'Else
        For w As Integer = 0 To Form1.DataGridView1.RowCount - 1

                Dim Axisf(2) As Segment3D
                Dim t As Integer = Form1.DataGridView1.Item(0, w).Value
                Dim r As Integer = Form1.DataGridView1.Item(1, w).Value
                Dim u As Integer = Form1.DataGridView1.Item(2, w).Value
                Dim y As Integer = Form1.DataGridView1.Item(3, w).Value
                Dim y1 As Integer = Form1.DataGridView1.Item(4, w).Value
                Dim y2 As Integer = Form1.DataGridView1.Item(5, w).Value

                Add(t, r, u, y, y1, y2)



        Next
        'End If




        'Dim graph2 As New Sphericalfunction
        'Me.object1 = graph2.getObject3D(Form1.NumericUpDown1.Value + 1, Me.Width, Me.Height)
        ''   doTest = False
        'Me.object1 = SHAPES(Form1.NumericUpDown1.Value + 1)

        'Me.object1.Scale(0.75)


        'Me.object1.transform(Matrix4x4.matrixTranslate3D(125, 125, 100))

        'Dim graph3 As New CartesianFunction
        'Me.object1 = graph3.getObject3D(Form1.ListFunctions.SelectedIndex, Me.Width, Me.Height, Form1.ListFunctions.Items.Item(1))


    End Sub
    Private Axi(2) As Segment3D
    Sub net()

        If Form1.CheckBox1.Checked = True Then
            For i As Integer = 1 To 10

                Axi(1) = New Segment3D(New Point3D(30 * zoomfactor, 30 * i * zoomfactor, 0), New Point3D(300 * zoomfactor, 30 * i * zoomfactor, 0))
                Axi(2) = New Segment3D(New Point3D(30 * i * zoomfactor, 30 * zoomfactor, 0), New Point3D(30 * i * zoomfactor, 300 * zoomfactor, 0))

                ' Axi(1) = New Segment3D(New Point3D(r, 10, 0), New Point3D(y1, 610, 0))

                drawline(Axi(1).pt1, Axi(1).pt2, Color.FromArgb(50, 0, 255, 0))
                drawline(Axi(2).pt1, Axi(2).pt2, Color.FromArgb(50, 0, 255, 0))

            Next
        Else
            For i As Integer = 1 To 10


                Axi(1) = New Segment3D(New Point3D(30, 30 * i, 0), New Point3D(300, 30 * i, 0))
                Axi(2) = New Segment3D(New Point3D(30 * i, 30, 0), New Point3D(30 * i, 300, 0))

                ' Axi(1) = New Segment3D(New Point3D(r, 10, 0), New Point3D(y1, 610, 0))

                drawline(Axi(1).pt1, Axi(1).pt2, Color.FromArgb(50, 0, 255, 0))
                drawline(Axi(2).pt1, Axi(2).pt2, Color.FromArgb(50, 0, 255, 0))

            Next
        End If

    End Sub
    Private ax As Integer = 1
    Private ax1 As Integer = 1
    Private ax2 As Integer = 40

    Private ax0 As Integer = 1 * zoomfactor
    Private ax10 As Integer = 50 * zoomfactor
    Private ax20 As Integer = 50 * zoomfactor
    Private axw As Integer = 10 * zoomfactor
    Private axw1 As Integer = 50 * zoomfactor
    Sub sd()



        Axis(0) = New Segment3D(New Point3D(ax1, ax, 0), New Point3D(ax2, ax, 0))
        Axis(1) = New Segment3D(New Point3D(ax, ax1, 0), New Point3D(ax, ax2, 0))
        Axis(2) = New Segment3D(New Point3D(ax, ax, ax1), New Point3D(ax, ax, ax2))

        Axis1(0) = New Segment3D(New Point3D(ax10, ax0, 0), New Point3D(-ax20, ax0, 0))
        Axis1(1) = New Segment3D(New Point3D(ax0, ax10, 0), New Point3D(ax0, -ax20, 0))
        Axis1(2) = New Segment3D(New Point3D(ax0, ax0, ax10), New Point3D(ax0, ax0, -ax20))



        pt3dC(0) = New Point3D(axw, axw, axw)
        pt3dC(1) = New Point3D(axw1, axw, axw)
        pt3dC(2) = New Point3D(axw1, axw1, axw)
        pt3dC(3) = New Point3D(axw, axw1, axw)
        pt3dC(4) = New Point3D(axw, axw, axw1)
        pt3dC(5) = New Point3D(axw1, axw, axw1)
        pt3dC(6) = New Point3D(axw1, axw1, axw1)
        pt3dC(7) = New Point3D(axw, axw1, axw1)
    End Sub

#Region " autorotation"
    Private Timer_dThetaX, Timer_dThetaY As Single

    Public Sub StartAutorotation(ByVal dThetaX As Single, ByVal dThetay As Single)

        Timer_dThetaX = dThetaX + 1
        Timer_dThetaY = dThetay + 1
        '  Timer1.Enabled = True
    End Sub

    'Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
    '    Cam3D.RotateCamera(Timer_dThetaX, Timer_dThetaY)
    '    Me.Invalidate()
    'End Sub
    Public Sub StopAutorotation()
        ' Timer1.Enabled = False
    End Sub

    Private dx, dy As Single

    Private Sub _3DCanvas0_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If (Math.Abs(dx) >= 2) Or (Math.Abs(dy) >= 2) Then
            If dx > 2 Then dx = 3 : If dx <= -2 Then dx = -2
            If dy > 2 Then dy = 3 : If dy <= -2 Then dy = -2
            If Abs(dx) <= 1 Then dx = 0
            If Abs(dy) <= 1 Then dy = 0
            StartAutorotation(-dx * 0.8, -dy * 0.8)
            dx = 0
            dy = 0
        End If

    End Sub
#End Region
    Private Sub _3DCanvas0_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel

        If e.Delta > 0 Then
            If zoomfactor >= 20 Then zoomfactor = 20 : Exit Sub
            zoomfactor = zoomfactor + 0.1

            Me.Invalidate()

        ElseIf e.Delta < 0 Then
            If zoomfactor <= 0.08 Then zoomfactor = 0.08 : Exit Sub
            zoomfactor = zoomfactor - 0.1
            Me.Invalidate()

        End If
    End Sub

End Class
