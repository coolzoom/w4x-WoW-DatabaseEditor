
Imports ClassLibWoWDatabaseManager
Imports ClassLibWoWCreatureItem
Imports ClassLibWoWTableManager

Public Class FormMain
    Private _locale As WoWClientLocale = WoWClientLocale.deDE ' select in what language the table text rows are shown
    Private _databaseManager As WoWDatabaseManager ' hold the store of all database properties
    Private _defaultDatabaseItem As WoWDatabaseItem
    Private _compareDatabaseItem As WoWDatabaseItem
    Private _creatureManager As WoWCreatureManager ' hold the part of all creature dialog
    Private _tableManager As WoWTableManager ' holds all table data

#Region " Main Form"

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _databaseManager = New WoWDatabaseManager
        _creatureManager = New WoWCreatureManager
        _defaultDatabaseItem = _databaseManager.GetDefaultWoWDatabaseItem
        _compareDatabaseItem = _databaseManager.GetCompareWoWDatabaseItem
        _tableManager = New WoWTableManager(_defaultDatabaseItem)
        ResizeGossip()
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
            s1 = "Host: " & _defaultDatabaseItem.ConnectionInfoString & "  "
            s1 &= "Database: " & _defaultDatabaseItem.CoreName & "  "
            s1 &= "Locale: " & _locale.ToString & "  "
        End If
        ToolStripStatusLabel1.Text = s1
    End Sub

    Private Sub FormMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Select Case TabControl1.SelectedTab.Text
            Case "Gossip"
                ResizeGossip()
        End Select
    End Sub

    Private Sub ResizeGossip()
        Dim h1 As Integer = TabControl1.Height - ListViewGossipMenuNpcText.Top - 31
        Dim h2 As Integer = h1 \ 2
        ListViewGossipMenuNpcText.Height = h2
        ListViewGossipMenuOption.Top = ListViewGossipMenuNpcText.Top + ListViewGossipMenuNpcText.Height + 3
        ListViewGossipMenuOption.Height = h2
    End Sub

    Private Sub LocaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocaleToolStripMenuItem.Click
        Dim frm As New WoWLocaleDialog(_locale) With {
            .Text = .Text & ": Select database locale"
        }
        If frm.ShowDialog = DialogResult.OK Then
            If _locale <> frm.GetSelectedLocale Then
                _locale = frm.GetSelectedLocale
                ShowStatusBar()
            End If
        End If

    End Sub

#End Region

#Region " Quest Search"

    Private Sub TextBoxSearchQuest_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchQuest.TextChanged

    End Sub

    Private Sub TextBoxSearchQuest_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchQuest.KeyPress
        If e.KeyChar = Chr(13) Then
            If IsNumeric(TextBoxSearchQuest.Text) Then
                Dim id As Integer = TextBoxSearchQuest.Text

            Else

            End If
        End If
    End Sub



#End Region

#Region " Creature Search"

    Private Sub TextBoxSearchCreature_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchCreature.TextChanged

    End Sub

    Private Sub TextBoxSearchCreature_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchCreature.KeyPress
        If e.KeyChar = Chr(13) Then
            If IsNumeric(TextBoxSearchCreature.Text) Then
                Dim id As Integer = TextBoxSearchCreature.Text
                'Dim cr1 As tablec _databaseManager.SearchCreatureGuid(id)
                '_databaseManager.SearchCreatureId(id)
                '_databaseManager.SearchCreatureEntry(id)
            Else

            End If
        End If
    End Sub


#End Region

#Region " GameObject Search"

    Private Sub TextBoxSearchGameObject_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchGameObject.TextChanged

    End Sub

    Private Sub TextBoxSearchGameObject_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchGameObject.KeyPress
        If e.KeyChar = Chr(13) Then
            If IsNumeric(TextBoxSearchGameObject.Text) Then

            Else

            End If
        End If
    End Sub


#End Region

#Region " Item Search"

    Private Sub TextBoxSearchItem_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchItem.TextChanged

    End Sub

    Private Sub TextBoxSearchItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchItem.KeyPress
        If e.KeyChar = Chr(13) Then
            If IsNumeric(TextBoxSearchItem.Text) Then

            Else

            End If
        End If
    End Sub


#End Region

#Region " Gossip Search"

    Private Sub TextBoxSearchGossip_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchGossip.TextChanged

    End Sub

    Private Sub TextBoxSearchGossip_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchGossip.KeyPress
        If e.KeyChar = Chr(13) Then
            If IsNumeric(TextBoxSearchGossip.Text) Then

            Else

            End If
        End If
    End Sub


#End Region



End Class
