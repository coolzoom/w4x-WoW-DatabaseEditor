
Imports ClassLibWoWDatabaseManager
Imports ClassLibWoWCreatureItem

Public Class FormMain
    Private _databaseManager As WoWDatabaseManager
    Private _defaultDatabaseItem As WoWDatabaseItem
    Private _compareDatabaseItem As WoWDatabaseItem
    Private _creatureManager As WoWCreatureManager

#Region " Main Form"

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _databaseManager = New WoWDatabaseManager
        _creatureManager = New WoWCreatureManager
        _defaultDatabaseItem = _databaseManager.GetDefaultWoWDatabaseItem
        _compareDatabaseItem = _databaseManager.GetCompareWoWDatabaseItem
        ShowStatusBar()
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Application.Exit()
        End
    End Sub

    Private Sub PropertiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropertiesToolStripMenuItem.Click
        Dim frm As New WoWDatabaseDialog With {
            .Text = .Text & ": Edit Server Host Properties",
            .ButtonOKText = "OK",
            .DatabaseManager = _databaseManager
        }
        If frm.ShowDialog = DialogResult.OK Then            
            _defaultDatabaseItem = _databaseManager.GetDefaultWoWDatabaseItem
            _compareDatabaseItem = _databaseManager.GetCompareWoWDatabaseItem
            ShowStatusBar()
        End If
    End Sub

    Private Sub ShowStatusBar()
        Dim s1 As String = ""
        If IsNothing(_defaultDatabaseItem) = False AndAlso _databaseManager.Count > 0 Then
            s1 = "Host: " & _defaultDatabaseItem.HostConnectionItem.ConnectionInfoString & "  "
            s1 &= "Database: " & _defaultDatabaseItem.CoreName & "  "
        End If
        ToolStripStatusLabel1.Text = s1
    End Sub

    Private Sub CopyToForm()

    End Sub

    Private Sub FormMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize

    End Sub

    Private Sub LocaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocaleToolStripMenuItem.Click

    End Sub

#End Region



End Class
