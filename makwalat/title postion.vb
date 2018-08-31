Public Class dak
    Public Shared Sub UpdateTextPosition(ByVal m As Form)
         
        Dim g As Graphics = m.CreateGraphics()
        Dim startingPoint As [Double] = (m.Width / 2) - (g.MeasureString(m.Text.Trim(), m.Font).Width / 2)
        Dim widthOfASpace As [Double] = g.MeasureString(" ", m.Font).Width
        Dim tmp As [String] = " "
        Dim tmpWidth As [Double] = 0

        While (tmpWidth + widthOfASpace) < startingPoint
            tmp += " "
            tmpWidth += widthOfASpace
        End While

        m.Text = tmp + m.Text.Trim()
    End Sub

    Public Shared Sub check(ByVal send As String)
        If send = "OK" Then
            Form2.TextBox1.Enabled = False
            Form2.TextBox2.Enabled = False
            Form2.TextBox3.Enabled = False
            Form2.TextBox4.Enabled = False
            Form2.TextBox5.Enabled = False
            Form2.TextBox6.Enabled = False
            Form2.TextBox7.Enabled = False
            Form2.Button1.Enabled = False

            monthly.TextBox1.Enabled = False
            monthly.TextBox2.Enabled = False
            monthly.TextBox3.Enabled = False
            monthly.TextBox4.Enabled = False
            monthly.TextBox5.Enabled = False
            monthly.TextBox6.Enabled = False
            monthly.Button1.Enabled = False

            Form6.TextBox1.Enabled = False
            Form6.TextBox2.Enabled = False
            Form6.TextBox3.Enabled = False
            Form6.TextBox4.Enabled = False
            Form6.TextBox5.Enabled = False
            Form6.TextBox6.Enabled = False
            Form6.TextBox7.Enabled = False
            Form6.TextBox8.Enabled = False
            Form6.TextBox9.Enabled = False
            Form6.TextBox10.Enabled = False
            Form6.TextBox11.Enabled = False
            Form6.TextBox12.Enabled = False
            Form6.TextBox13.Enabled = False
            Form6.TextBox14.Enabled = False
            Form6.TextBox15.Enabled = False
            Form6.Button1.Enabled = False

            offer.TextBox1.Enabled = False
            offer.TextBox2.Enabled = False
            offer.TextBox3.Enabled = False
            offer.TextBox4.Enabled = False
            offer.TextBox5.Enabled = False
            offer.TextBox6.Enabled = False
            offer.TextBox7.Enabled = False
            offer.TextBox8.Enabled = False
            offer.TextBox9.Enabled = False
            offer.Button1.Enabled = False

            Form8.TextBox1.Enabled = False
            Form8.TextBox2.Enabled = False
            Form8.TextBox3.Enabled = False
            Form8.TextBox4.Enabled = False
            Form8.TextBox5.Enabled = False
            Form8.TextBox6.Enabled = False
            Form8.TextBox7.Enabled = False
            Form8.Button1.Enabled = False
        End If
    End Sub
End Class