Module FormToRegistry
    'Author: Silas Martin
    'www.carolinatechnicalsolutions.com
    'Visit our website for more free software downloads

    'The code below can be pasted into any project as the use of 
    'Application.Name and frmAny.Name creates a unique registry entry
    'for any forms size and position data

    'save form size and position to registry - Call from the Closing event of the form
    Public Sub SaveFormSize(ByVal frmAny As Form)
        If frmAny.WindowState.ToString = "Normal" Then
            'top
            SaveSetting(Application.ProductName, "FormPositions", frmAny.Name & "_Top", frmAny.Top.ToString)
            'left
            SaveSetting(Application.ProductName, "FormPositions", frmAny.Name & "_Left", frmAny.Left.ToString)
            'height
            SaveSetting(Application.ProductName, "FormPositions", frmAny.Name & "_Height", frmAny.Height.ToString)
            'width
            SaveSetting(Application.ProductName, "FormPositions", frmAny.Name & "_Width", frmAny.Width.ToString)
            'windowstate
            SaveSetting(Application.ProductName, "FormPositions", frmAny.Name & "_WindowState", 0)
        End If
        If frmAny.WindowState.ToString = "Maximized" Then
            'windowstate
            SaveSetting(Application.ProductName, "FormPositions", frmAny.Name & "_WindowState", 2)
        End If
    End Sub

    'get form size and position from registry - Call from the Load event of the form
    Public Sub GetFormSize(ByVal frmAny As Form)
        frmAny.Top = GetSetting(Application.ProductName, "FormPositions", frmAny.Name & "_Top", frmAny.Top.ToString)
        frmAny.Left = GetSetting(Application.ProductName, "FormPositions", frmAny.Name & "_Left", frmAny.Left.ToString)
        frmAny.Height = GetSetting(Application.ProductName, "FormPositions", frmAny.Name & "_Height", frmAny.Height.ToString)
        frmAny.Width = GetSetting(Application.ProductName, "FormPositions", frmAny.Name & "_Width", frmAny.Width.ToString)
        frmAny.WindowState = GetSetting(Application.ProductName, "FormPositions", frmAny.Name & "_WindowState", 0)
    End Sub
End Module
