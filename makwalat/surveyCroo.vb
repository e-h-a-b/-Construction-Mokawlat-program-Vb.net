Public Class surveyCroo

    'X0=200000!
    'Y0=700000!
    'X0=810000!
    'Y0=615000!
    'X0=1100000!
    'Y0=300000!
    '    27 >>> x=200000
    '   >>> y=700000

    '31 >>> x=810000
    '   >>> y=615000

    '35 >>> x=1100000
    '   >>> y=300000
    '******************************************************************************
    'PI=3.141592653589793
    'A1=6378200
    'E2=.006693421623
    'A0=A1*(1-E2/4-E2^2*3/64-E2^3*5/256)
    'B0=A1*3/8*(E2+E2^2/4+E2^3*15/128)
    'C0=A1*15/256*(E2^2+E2^3*3/4)
    'D0=A1*E2^3*35/3072
    'S$="0"
    'N0=30*PI/180
    'S0=A0*N0-B0*SIN(2*N0)+C0*SIN(4*N0)-D0*SIN(6*N0)
    '    REM CLS
    'I=0
    'CLS
    '*******************************************************************************
    'Latitude value <D,M,S>   if D<22 or D>32  out of range (STATION IS OUTSIDE AREA OF COMPUTATION)
    'Longitude value <D,M,S>  if D<24 OR D>37  out of range (STATION IS OUTSIDE AREA OF COMPUTATION)
    '*******************************************************************************

    'X=(D1+M1/60+S1/3600)*PI/180
    'Y=(D2+M2/60+S2/3600)*PI/180
    'S=A0*X-B0*SIN(2*X)+C0*SIN(4*X)-D0*SIN(6*X)
    'P=A1*(1-E2)/(1-E2*SIN(X)^2)^1.5
    'V=A1/(1-E2*SIN(X)^2)^.5
    'C=V/P
    'S=S-S0
    'W=Y-D3*PI/180
    'T=TAN(X)
    'O=W*COS(X)
    'N=S+V*SIN(X)*W*O/2+V*SIN(X)*W*O^3/24*(4*C^2+C-T^2)
    'N=N+V*SIN(X)*W*O^5/720*(8*C^4*(11-24*T^2)-28*C^3*(1-6*T^2))
    'N=N+V*SIN(X)*W*O^5/720*(C^2*(1-32*T^2)-C*2*T^2+T^4)
    'N=N+V*SIN(X)*W*O^7/40320!*(1385-3111*T^2+543*T^4-T^6)
    'N=X0+N
    '********************************************************************************
    'E=V*O+V*O^3/6*(C-T^2)
    'E=E+V*O^5/120*(4*C^3*(1-6*T^2)+C^2*(1+8*T^2)-C^2*T^2+T^4)
    'E=E+V*O^7/5040*(61-479*T^2+179*T^4-T^6)
    'E=E+Y0

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Dim D3 As Double
        Dim X0, Y0 As Double
        If a27.Checked = True Then D3 = 27 : X0 = 200000 : Y0 = 700000
        If a31.Checked = True Then D3 = 31 : X0 = 810000 : Y0 = 615000
        If a35.Checked = True Then D3 = 35 : X0 = 1100000 : Y0 = 300000


        Dim PI As Double = 3.1415926535897931
        Dim A1 As Double = 6378200 'دائرة نصف قطرها الاستوائية، م
        'Name  ellipsoid            Equatorial radius, m
        'Krasovskogo (1940)             6378245
        'International(1924)            6378388 
        'Clarke(1880)                   6378249 
        'Bessel (1841)                  6377397 
        'Erie (1830)                    6377563      
        'Everest(1830)                  6377276            
        'Helmert(1906)                  6378200 
        'WGS66 (1966)                   6378145 
        'GRS67 (1967)                   6378160
        'WGS72 (1972)                   6378135 
        'GRS80(1979)                    6378137
        'WGS84                          6378137
        Dim E2 As Double = 0.00669342162296594 'e^2 = 0.006693421623 > eccentricity  إختلاف المراكز
        Dim A0 As Double = A1 * (1 - E2 / 4 - E2 ^ 2 * 3 / 64 - E2 ^ 3 * 5 / 256)
        Dim B0 As Double = A1 * 3 / 8 * (E2 + E2 ^ 2 / 4 + E2 ^ 3 * 15 / 128)
        Dim C0 As Double = A1 * 15 / 256 * (E2 ^ 2 + E2 ^ 3 * 3 / 4)
        Dim D0 As Double = A1 * E2 ^ 3 * 35 / 3072

        Dim N0 As Double = 30 * PI / 180
        Dim S0 As Double = A0 * N0 - B0 * Math.Sin(2 * N0) + C0 * Math.Sin(4 * N0) - D0 * Math.Sin(6 * N0)


        Dim X As Double = (D1.Text + M1.Text / 60 + S1.Text / 3600) * PI / 180
        Dim Y As Double = (D2.Text + M2.Text / 60 + S2.Text / 3600) * PI / 180
        Dim S As Double = A0 * X - B0 * Math.Sin(2 * X) + C0 * Math.Sin(4 * X) - D0 * Math.Sin(6 * X)
        Dim P As Double = A1 * (1 - E2) / (1 - E2 * Math.Sin(X) ^ 2) ^ 1.5
        Dim V As Double = A1 / (1 - E2 * Math.Sin(X) ^ 2) ^ 0.5
        Dim C As Double = V / P
        S = S - S0
        Dim W As Double = Y - D3 * PI / 180
        Dim T As Double = Math.Tan(X)
        Dim O As Double = W * Math.Cos(X)
        Dim N As Double
        N = S + V * Math.Sin(X) * W * O / 2 + V * Math.Sin(X) * W * O ^ 3 / 24 * (4 * C ^ 2 + C - T ^ 2)
        N = N + V * Math.Sin(X) * W * O ^ 5 / 720 * (8 * C ^ 4 * (11 - 24 * T ^ 2) - 28 * C ^ 3 * (1 - 6 * T ^ 2))
        N = N + V * Math.Sin(X) * W * O ^ 5 / 720 * (C ^ 2 * (1 - 32 * T ^ 2) - C * 2 * T ^ 2 + T ^ 4)
        N = N + V * Math.Sin(X) * W * O ^ 7 / 40320.0! * (1385 - 3111 * T ^ 2 + 543 * T ^ 4 - T ^ 6)
        N = X0 + N

        Dim Ea As Double
        Ea = V * O + V * O ^ 3 / 6 * (C - T ^ 2)
        Ea = Ea + V * O ^ 5 / 120 * (4 * C ^ 3 * (1 - 6 * T ^ 2) + C ^ 2 * (1 + 8 * T ^ 2) - C ^ 2 * T ^ 2 + T ^ 4)
        Ea = Ea + V * O ^ 7 / 5040 * (61 - 479 * T ^ 2 + 179 * T ^ 4 - T ^ 6)
        Ea = Ea + Y0

        If D1.Text < 22 Or D1.Text > 32 Then
            Label11.Text = "Checking : --Latitude value  ERROR Outside Range --"
            Label11.BackColor = Color.Red
        Else
            Label11.Text = "Checking : --Latitude value  Inside Range --"
            Label11.BackColor = Color.LightGreen
            No.Text = N
        End If


        If D2.Text < 24 Or D2.Text > 37 Then
            Label12.Text = "Checking : --Longitude value ERROR Outside Range --"
            Label12.BackColor = Color.Red
        Else
            Label12.Text = "Checking : --Longitude value  Inside Range --"
            Label12.BackColor = Color.LightGreen
            Eas.Text = Ea
        End If




    End Sub
    Function Convert_Degree(Decimal_Deg) As Object
        'source: http://support.microsoft.com/kb/213449
        '
        'converts a decimal degree representation to deg min sec
        'as 10.46 returns 10° 27' 36"
        '
        Dim degrees As Object
        Dim minutes As Object
        Dim seconds As Object
        ' With Application
        'Set degree to Integer of Argument Passed
        degrees = Int(Decimal_Deg)
        'Set minutes to 60 times the number to the right
        'of the decimal for the variable Decimal_Deg
        minutes = (Decimal_Deg - degrees) * 60
        'Set seconds to 60 times the number to the right of the
        'decimal for the variable Minute
        seconds = Format(((minutes - Int(minutes)) * 60), "0")
        'Returns the Result of degree conversion
        '(for example, 10.46 = 10° 27' 36")
        Convert_Degree = " " & degrees & "° " & Int(minutes) & "' " _
            & seconds + Chr(34)
        ' End With

        If lat.Checked = True Then
            D1.Text = degrees
            M1.Text = Int(minutes)
            S1.Text = seconds

        End If
        If lon.Checked = True Then
            D2.Text = degrees
            M2.Text = Int(minutes)
            S2.Text = seconds
        End If
    End Function
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Convert_Degree(dec.Text)
    End Sub

End Class