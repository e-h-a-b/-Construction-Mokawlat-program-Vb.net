Option Strict On
Imports System.CodeDom.Compiler


Public Class Form7
    Inherits System.Windows.Forms.Form

    Friend Function CreateConsoleApplication(ByVal VBSourceCode As String, ByVal WhereToSave As String) As Boolean
        Try

            'VBSourceCode = "Module Module1" & vbCrLf & "Sub Main()" & vbCrLf & "Dim UserInfo As String = ""Name: User1""" & vbCrLf & "System.Console.WriteLine(UserInfo)" & vbCrLf & "System.Console.ReadLine()" & vbCrLf & "End Sub" & vbCrLf & "End Module"
            'WhereToSave = "C:\TestConsole.exe"

            Dim provider As Microsoft.VisualBasic.VBCodeProvider
            Dim compiler As System.CodeDom.Compiler.ICodeCompiler
            Dim params As System.CodeDom.Compiler.CompilerParameters
            Dim results As System.CodeDom.Compiler.CompilerResults

            params = New System.CodeDom.Compiler.CompilerParameters
            params.GenerateInMemory = False

            params.TreatWarningsAsErrors = False
            params.WarningLevel = 4
            'Put any references you need here - even you own dll's, if you want to use one

            Dim refs() As String = {"System.dll", "Microsoft.VisualBasic.dll"}
            params.ReferencedAssemblies.AddRange(refs)
            params.GenerateExecutable = True
            params.OutputAssembly = WhereToSave

            provider = New Microsoft.VisualBasic.VBCodeProvider
            results = provider.CompileAssemblyFromSource(params, VBSourceCode)

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click, button2.Click
        Dim codeProvider As New VBCodeProvider()
        Dim icc As ICodeCompiler = codeProvider.CreateCompiler
        Dim Output As String = "Out.exe"
        Dim ButtonObject As Button = CType(sender, Button)
        CreateConsoleApplication("Module Module1" & vbCrLf & "Sub Main()" & vbCrLf & "Dim UserInfo As String = ""Name: User1""" & vbCrLf & "System.Console.WriteLine(UserInfo)" & vbCrLf & "System.Console.ReadLine()" & vbCrLf & "End Sub" & vbCrLf & "End Module", "C:\mokawalat\tnt.exe")
        textBox2.Text = ""
        Dim parameters As New CompilerParameters()
        Dim results As CompilerResults
        'Make sure we generate an EXE, not a DLL
        parameters.GenerateExecutable = True
        parameters.OutputAssembly = Output
        results = icc.CompileAssemblyFromSource(parameters, textBox1.Text)

        If results.Errors.Count > 0 Then
            'There were compiler errors
            textBox2.ForeColor = Color.Red
            Dim CompErr As CompilerError
            For Each CompErr In results.Errors
                textBox2.Text = textBox2.Text & _
                "Line number " & CompErr.Line & _
                ", Error Number: " & CompErr.ErrorNumber & _
                ", '" & CompErr.ErrorText & ";" & _
                Environment.NewLine & Environment.NewLine
            Next
        Else
            'Successful Compile
            textBox2.ForeColor = Color.Blue
            textBox2.Text = "Success!"
            'If we clicked run then launch the EXE
            If ButtonObject.Text = "Run" Then Process.Start(Output)
        End If

    End Sub

End Class