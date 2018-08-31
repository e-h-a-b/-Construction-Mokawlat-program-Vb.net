Imports System.IO

Public Class autowrite

    Private Sub Label5_Click(sender As System.Object, e As System.EventArgs) Handles Label5.Click
        Form2.Show()
    End Sub

    Private Sub Label16_Click(sender As System.Object, e As System.EventArgs) Handles Label16.Click
        monthly.Show()
    End Sub

    Private Sub Label32_Click(sender As System.Object, e As System.EventArgs) Handles Label32.Click
        Form6.Show()
    End Sub

    Private Sub Label42_Click(sender As System.Object, e As System.EventArgs) Handles Label42.Click
        offer.Show()
    End Sub

    Private Sub Label50_Click(sender As System.Object, e As System.EventArgs) Handles Label50.Click
        Form8.Show()
    End Sub

    Sub readtxt()
        Dim lines() As String = IO.File.ReadAllLines("C:\Users\" & Environment.UserName & "\Desktop\Mokawalat*.txt")
        TextBox1.Text = lines(0) 'TextBox2.Text = lines(lines.Length - 1)
        TextBox2.Text = lines(1) : TextBox3.Text = lines(2) : TextBox4.Text = lines(3) : TextBox5.Text = lines(4)
        : TextBox6.Text = lines(5) : TextBox7.Text = lines(6) : TextBox8.Text = lines(7)
        : TextBox9.Text = lines(8)

        TextBox10.Text = lines(9) 'form4.TextBox2.Text = lines(lines.Length - 1)
        TextBox11.Text = lines(10) : TextBox12.Text = lines(11) : TextBox13.Text = lines(12) : TextBox14.Text = lines(13)
        : TextBox15.Text = lines(14) : TextBox16.Text = lines(15) : TextBox17.Text = lines(16)
        : TextBox18.Text = lines(17)

        TextBox19.Text = lines(18) 'form4.TextBox2.Text = lines(lines.Length - 1)
        TextBox20.Text = lines(19) : TextBox21.Text = lines(20) : TextBox22.Text = lines(21) : TextBox23.Text = lines(22)
        : TextBox24.Text = lines(23) : TextBox25.Text = lines(24) : TextBox26.Text = lines(25)
        : TextBox27.Text = lines(26)

        TextBox28.Text = lines(27) 'form4.TextBox2.Text = lines(lines.Length - 1)
        TextBox29.Text = lines(28) : TextBox30.Text = lines(29) : TextBox31.Text = lines(30) : TextBox32.Text = lines(31)
        : TextBox33.Text = lines(32) : TextBox34.Text = lines(33) : TextBox35.Text = lines(34)
        : TextBox36.Text = lines(35)

        TextBox37.Text = lines(36) 'form4.TextBox2.Text = lines(lines.Length - 1)
        TextBox38.Text = lines(37) : TextBox39.Text = lines(38) : TextBox40.Text = lines(39) : TextBox41.Text = lines(40)
        : TextBox42.Text = lines(41) : TextBox43.Text = lines(42) : TextBox44.Text = lines(43) : TextBox45.Text = lines(44)

    End Sub

    Private Sub Form4_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call GetFormSize(Me) 'Get to save  size & Position of Form in Registry


        Label51.Text = "C:\Users\" & Environment.UserName & "\Desktop\Mokawalat.txt"
        readtxt()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim filepath As String = IO.Path.Combine(Label51.Text) 'Some file path

        Using sw As New StreamWriter(filepath)
            'sw.Write(TextBox1.Text)
            'sw.WriteLine(" " & TextBox2.Text)
            'sw.Write(TextBox3.Text)
            'sw.WriteLine(" " & TextBox4.Text)
            sw.WriteLine(TextBox1.Text)
            sw.WriteLine(TextBox2.Text)
            sw.WriteLine(TextBox3.Text)
            sw.WriteLine(TextBox4.Text)
            sw.WriteLine(TextBox5.Text) : sw.WriteLine(TextBox6.Text) : sw.WriteLine(TextBox7.Text) : sw.WriteLine(TextBox8.Text)
            : sw.WriteLine(TextBox9.Text) : sw.WriteLine(TextBox10.Text) : sw.WriteLine(TextBox11.Text) : sw.WriteLine(TextBox12.Text)
            : sw.WriteLine(TextBox13.Text) : sw.WriteLine(TextBox14.Text) : sw.WriteLine(TextBox15.Text) : sw.WriteLine(TextBox16.Text)
            : sw.WriteLine(TextBox17.Text) : sw.WriteLine(TextBox18.Text) : sw.WriteLine(TextBox19.Text) : sw.WriteLine(TextBox20.Text)
            : sw.WriteLine(TextBox21.Text) : sw.WriteLine(TextBox22.Text) : sw.WriteLine(TextBox23.Text) : sw.WriteLine(TextBox24.Text)
            : sw.WriteLine(TextBox25.Text) : sw.WriteLine(TextBox26.Text) : sw.WriteLine(TextBox27.Text) : sw.WriteLine(TextBox28.Text)
            sw.WriteLine(TextBox29.Text) : sw.WriteLine(TextBox30.Text) : sw.WriteLine(TextBox31.Text) : sw.WriteLine(TextBox32.Text)
            sw.WriteLine(TextBox33.Text) : sw.WriteLine(TextBox34.Text) : sw.WriteLine(TextBox35.Text) : sw.WriteLine(TextBox36.Text)
            sw.WriteLine(TextBox37.Text) : sw.WriteLine(TextBox38.Text) : sw.WriteLine(TextBox39.Text) : sw.WriteLine(TextBox40.Text)
            sw.WriteLine(TextBox41.Text) : sw.WriteLine(TextBox42.Text) : sw.WriteLine(TextBox43.Text) : sw.WriteLine(TextBox44.Text)
            : sw.WriteLine(TextBox45.Text)
            'and so on
            '
        End Using
    End Sub


    Private Sub mokawlat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        main.Enabled = False
    End Sub

    Private Sub mokawlat_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call SaveFormSize(Me)  'Get to save  size & Position of Form in Registry

        main.Enabled = True
    End Sub
End Class