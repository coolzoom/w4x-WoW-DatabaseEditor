
Imports ClassLibWoWDatabaseManager
Imports ClassLibWoWTableDialog
Imports ClassLibWoWTableManager

Public Class FormMain
    Private _locale As WoWClientLocale = WoWClientLocale.deDE ' select in what language the table text rows are shown
    Private _databaseManager As WoWDatabaseManager ' hold the store of all database properties
    Private _defaultDatabaseItem As WoWDatabaseItem
    Private _compareDatabaseItem As WoWDatabaseItem
    Private _tableManager As WoWTableManager ' holds all table data

#Region " Main Form"

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _databaseManager = New WoWDatabaseManager
        _defaultDatabaseItem = _databaseManager.GetDefaultWoWDatabaseItem
        _compareDatabaseItem = _databaseManager.GetCompareWoWDatabaseItem
        _tableManager = New WoWTableManager(_defaultDatabaseItem, _locale)
        ResizeGossip()
        ShowStatusBar()
        MenuStrip1.Enabled = False
        StatusStrip1.Enabled = False
        Timer1.Interval = 5000
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        If _tableManager.CheckForFinishLoadAllTables() Then
            MenuStrip1.Enabled = True
            StatusStrip1.Enabled = True
        Else
            Timer1.Interval = 500
            Timer1.Start()
        End If
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

    Private Sub ShowListViewSearchQuest(ids() As UInteger)

    End Sub

#End Region

#Region " Creature Search"

    Private Sub TextBoxSearchCreature_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchCreature.KeyPress
        If e.KeyChar = Chr(13) Then
            If IsNumeric(TextBoxSearchCreature.Text) Then
                Dim id As Integer = TextBoxSearchCreature.Text
                Dim cr1 As TableCreatureItem = _tableManager.StorageCreature.SearchGuid(id)
                Dim cr2() As TableCreatureItem = _tableManager.StorageCreature.SearchWithId(id)
                Dim idList As New List(Of UInteger)
                If IsNothing(cr1) = False Then
                    idList.Add(cr1.id)
                End If
                If IsNothing(cr2) = False Then
                    For Each cr As TableCreatureItem In cr2
                        If idList.Count > 100 Then Exit For
                        If idList.Contains(cr.id) = False Then
                            idList.Add(cr.id)
                        End If
                    Next
                End If
                Dim ct1 As TableCreatureTemplateItem = _tableManager.StorageCreatureTemplate.SearchEntry(id)
                If IsNothing(ct1) = False Then
                    If idList.Contains(ct1.entry) = False Then
                        idList.Add(ct1.entry)
                    End If
                End If
                ShowListViewSearchCreature(idList.ToArray)
            Else
                Dim c1() As TableCreatureTemplateItem = _tableManager.StorageCreatureTemplate.SearchFromNamePart(TextBoxSearchCreature.Text)
                Dim c2() As TableLocalesCreatureItem = _tableManager.StorageLocalesCreature.SearchFromNamePart(TextBoxSearchCreature.Text)
                Dim idList As New List(Of UInteger)
                If IsNothing(c1) = False Then
                    For Each ct As TableCreatureTemplateItem In c1
                        idList.Add(ct.entry)
                    Next
                End If
                If IsNothing(c2) = False Then
                    For Each ct As TableLocalesCreatureItem In c2
                        idList.Add(ct.entry)
                    Next
                End If
                ShowListViewSearchCreature(idList.ToArray)
            End If
        End If
    End Sub

    Private Sub ShowListViewSearchCreature(ids() As UInteger)
        ListViewCreature.Items.Clear()
        For Each entry As UInteger In ids
            Dim cti As TableCreatureTemplateItem = _tableManager.StorageCreatureTemplate.GetItem(entry)
            If IsNothing(cti) = False Then
                Dim lvi As ListViewItem = cti.GetGetListViewForCreatureTemplateSearch
                ListViewCreature.Items.Add(lvi)
            End If
        Next
    End Sub

    Private Sub ListViewCreature_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListViewCreature.MouseDoubleClick
        Dim lv As ListView = sender
        Dim slvic As ListView.SelectedListViewItemCollection = lv.SelectedItems
        If slvic.Count = 0 Then Exit Sub
        Dim entry As UInteger
        If UInteger.TryParse(slvic.Item(0).SubItems(0).Text, entry) Then
            Dim frm As New WoWCreatureDialog_434(_databaseManager, _tableManager, entry, _locale)
            frm.Show()
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

    Private Sub ShowListViewSearchGameObject(ids() As UInteger)

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

    Private Sub ShowListViewSearchItem(ids() As UInteger)

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

    Private Sub ShowListViewSearchGossipMenu(gossipIds() As UInteger)

    End Sub

    Private Sub ShowListViewSearchGossipMenuOption(gossipIds() As UInteger)

    End Sub

#End Region



End Class
