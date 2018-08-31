Public Class checkpaid
    Public Shared Sub freeze(ByVal sett As Boolean, ByVal ty As String)
        main.Enabled = sett
        main.MenuStrip1.Enabled = sett
        main.DataGridView2.Enabled = sett
        main.File.Enabled = sett
        main.NewTool.Enabled = sett
        main.DataBase.Enabled = sett
        main.OptionTool.Enabled = sett
        main.fileopen.Enabled = sett : main.filesave.Enabled = sett : main.fileexit.Enabled = sett
        main.Newplace.Enabled = sett : main.newendclause.Enabled = sett : main.newrent.Enabled = sett : main.newmonthly.Enabled = sett : main.newperview.Enabled = sett : main.newautomatic.Enabled = sett : main.newrecoredvoice.Enabled = sett
        main.Databasecons.Enabled = sett : main.Databaseengineer.Enabled = sett : main.Databaseindustrial.Enabled = sett
        main.optionlan.Enabled = sett : main.optionlanarab.Enabled = sett : main.optionlanenglish.Enabled = sett : main.optionhelp.Enabled = sett : main.optionsettings.Enabled = sett : main.optionupdate.Enabled = sett : main.optionupdatedata.Enabled = sett : main.optionupdateprogram.Enabled = sett : main.optionstyle.Enabled = sett



    End Sub

End Class
