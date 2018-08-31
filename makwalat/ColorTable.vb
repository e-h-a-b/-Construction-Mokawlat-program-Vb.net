 
Public Class ColorTable
    Inherits ProfessionalColorTable
    'Dim dropDownMenu = DirectCast(Me.DataBaseToolStripMenuItem.DropDown, ToolStripDropDownMenu)
    'dropDownMenu.ShowImageMargin = False
    'dropDownMenu.BackColor = Color.DarkGray
    'Dim dropDownMenu1 = DirectCast(Me.FileToolStripMenuItem.DropDown, ToolStripDropDownMenu)
    'dropDownMenu1.ShowImageMargin = False
    'dropDownMenu1.BackColor = Color.DarkGray
    'Dim dropDownMenu2 = DirectCast(Me.NewToolStripMenuItem.DropDown, ToolStripDropDownMenu)
    'dropDownMenu2.ShowImageMargin = False
    'dropDownMenu2.BackColor = Color.DarkGray
    'Dim dropDownMenu3 = DirectCast(Me.OptionToolStripMenuItem.DropDown, ToolStripDropDownMenu)
    'dropDownMenu3.ShowImageMargin = False
    'dropDownMenu3.BackColor = Color.DarkGray
    'For Each blah As ToolStripMenuItem In MenuStrip1.Items
    '    blah.BackColor = Color.Black
    '    blah.ForeColor = Color.Red
    '    For Each meh As ToolStripMenuItem In blah.DropDownItems
    '        meh.BackColor = Color.Black
    '        meh.ForeColor = Color.Red
    '        For Each lolCat As ToolStripMenuItem In meh.DropDownItems
    '            lolCat.BackColor = Color.Black
    '            lolCat.ForeColor = Color.Red
    '        Next
    '    Next
    'Next
    'Dim Color1 = Color.FromArgb(30, 38, 44)
    'Dim Color2 = Color.FromArgb(75, 81, 88)
    Dim Color1 = Color.DarkGray
    Dim Color2 = Color.FromArgb(75, 81, 88)
    Public Overrides ReadOnly Property ImageMarginGradientBegin() As System.Drawing.Color
        Get
            Return Color1
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginGradientEnd() As System.Drawing.Color
        Get
            Return Color1
        End Get
    End Property
    Public Overrides ReadOnly Property ImageMarginGradientMiddle() As System.Drawing.Color
        Get
            Return Color1
        End Get
    End Property
    Public Overrides ReadOnly Property MenuBorder() As Color
        Get
            Return Color1
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelectedGradientBegin() As Color
        Get
            Return Color2
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelectedGradientEnd() As Color
        Get
            Return Color2
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelected() As Color
        Get
            Return Color2
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemBorder() As Color
        Get
            Return Color1
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientBegin() As Color
        Get
            Return Color2
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemPressedGradientEnd() As Color
        Get
            Return Color2
        End Get
    End Property
    Public Overrides ReadOnly Property SeparatorDark() As Color
        Get
            Return Color1
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
        Get
            Return Color1
        End Get
    End Property
End Class