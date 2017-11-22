
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

    Private Sub TextBoxSearchQuest_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchQuest.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim idList As New List(Of UInteger)
            If IsNumeric(TextBoxSearchQuest.Text) Then
                Dim id As Integer = TextBoxSearchQuest.Text
                Dim qt As TableQuestTemplateItem = _tableManager.StorageQuestTemplate.GetItem(id)
                Dim lq As TableLocalesQuestItem = _tableManager.StorageLocalesQuest.GetItem(id)
                If IsNothing(qt) = False Then
                    idList.Add(qt.Id)
                End If
                If IsNothing(lq) = False Then
                    If idList.Contains(lq.Id) = False Then
                        idList.Add(lq.Id)
                    End If
                End If
            Else
                Dim s1 As String = TextBoxSearchQuest.Text.Trim
                If String.IsNullOrWhiteSpace(s1) Then Exit Sub
                Dim q1() As TableQuestTemplateItem = _tableManager.StorageQuestTemplate.SearchFromTitlePart(s1)
                Dim q2() As TableLocalesQuestItem = _tableManager.StorageLocalesQuest.SearchFromTitlePart(s1, _locale)
                If IsNothing(q1) = False Then
                    For Each qt As TableQuestTemplateItem In q1
                        If idList.Contains(qt.Id) = False Then
                            idList.Add(qt.Id)
                        End If
                    Next
                End If
                If IsNothing(q2) = False Then
                    For Each qt As TableLocalesQuestItem In q2
                        If idList.Contains(qt.Id) = False Then
                            idList.Add(qt.Id)
                        End If
                    Next
                End If

            End If
            ShowListViewSearchQuest(idList.ToArray)
        End If
    End Sub

    Private Sub ShowListViewSearchQuest(ids() As UInteger)
        ListViewQuest.Items.Clear()
        For Each id As UInteger In ids
            Dim qti As TableQuestTemplateItem = _tableManager.StorageQuestTemplate.GetItem(id)
            Dim lqi As TableLocalesQuestItem = _tableManager.StorageLocalesQuest.GetItem(id)
            Dim questGiverNameList As New List(Of String)
            Dim qs1() As TableAreatriggerQuestenderItem = _tableManager.StorageAreatriggerQuestender.SearchWithQuest(id)
            Dim qs2() As TableAreatriggerQueststarterItem = _tableManager.StorageAreatriggerQueststarter.SearchWithQuest(id)
            Dim qs3() As TableCreatureQuestenderItem = _tableManager.StorageCreatureQuestender.SearchWithQuest(id)
            Dim qs4() As TableCreatureQueststarterItem = _tableManager.StorageCreatureQueststarter.SearchWithQuest(id)
            Dim qs5() As TableGameobjectQuestenderItem = _tableManager.StorageGameobjectQuestender.SearchWithQuest(id)
            Dim qs6() As TableGameobjectQueststarterItem = _tableManager.StorageGameobjectQueststarter.SearchWithQuest(id)
            '
            Dim lvi As New ListViewItem(id)
            If IsNothing(qti) Then
                lvi.SubItems.Add("")
            Else
                lvi.SubItems.Add(qti.Title)
            End If
            If IsNothing(lqi) Then
                lvi.SubItems.Add("")
            Else
                lvi.SubItems.Add(lqi.Title(_locale))
            End If
            ' finds there Area or Sector Names???  Maybe in Hotfixes???
            If IsNothing(qs3) = False Then
                For Each qi As TableCreatureQuestenderItem In qs3
                    Dim ci As TableCreatureTemplateItem = _tableManager.StorageCreatureTemplate.GetItem(qi.id)
                    If IsNothing(ci) = False Then
                        If questGiverNameList.Contains(ci.name) = False Then
                            questGiverNameList.Add(ci.name)
                        End If
                    End If
                Next
            End If
            If IsNothing(qs4) = False Then
                For Each qi As TableCreatureQueststarterItem In qs4
                    Dim ci As TableCreatureTemplateItem = _tableManager.StorageCreatureTemplate.GetItem(qi.id)
                    If IsNothing(ci) = False Then
                        If questGiverNameList.Contains(ci.name) = False Then
                            questGiverNameList.Add(ci.name)
                        End If
                    End If
                Next
            End If
            If IsNothing(qs5) = False Then
                For Each qi As TableGameobjectQuestenderItem In qs5
                    Dim ci As TableGameobjectTemplateItem = _tableManager.StorageGameobjectTemplate.GetItem(qi.id)
                    If IsNothing(ci) = False Then
                        If questGiverNameList.Contains(ci.name) = False Then
                            questGiverNameList.Add(ci.name)
                        End If
                    End If
                Next
            End If
            If IsNothing(qs6) = False Then
                For Each qi As TableGameobjectQueststarterItem In qs6
                    Dim ci As TableGameobjectTemplateItem = _tableManager.StorageGameobjectTemplate.GetItem(qi.id)
                    If IsNothing(ci) = False Then
                        If questGiverNameList.Contains(ci.name) = False Then
                            questGiverNameList.Add(ci.name)
                        End If
                    End If
                Next
            End If
            Dim s1 As String = ""
            Dim ko As Boolean = False
            For Each s2 As String In questGiverNameList
                If ko Then s1 &= ", "
                ko = True
                s1 &= s2
            Next
            lvi.SubItems.Add(s1)
            ListViewQuest.Items.Add(lvi)
        Next
    End Sub

    Private Sub ListViewQuest_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListViewQuest.MouseDoubleClick
        Dim lv As ListView = sender
        Dim slvic As ListView.SelectedListViewItemCollection = lv.SelectedItems
        If slvic.Count = 0 Then Exit Sub
        Dim entry As UInteger
        If UInteger.TryParse(slvic.Item(0).SubItems(0).Text, entry) Then
            Dim frm As New WoWQuestDialog_434(_databaseManager, _tableManager, entry, _locale)
            frm.Show()
        End If
    End Sub

#End Region

#Region " Creature Search"

    Private Sub TextBoxSearchCreature_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchCreature.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim idList As New List(Of UInteger)
            If IsNumeric(TextBoxSearchCreature.Text) Then
                Dim id As Integer = TextBoxSearchCreature.Text
                Dim cr1 As TableCreatureItem = _tableManager.StorageCreature.GetItem(id)
                Dim cr2() As TableCreatureItem = _tableManager.StorageCreature.SearchWithId(id)
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
                Dim ct1 As TableCreatureTemplateItem = _tableManager.StorageCreatureTemplate.GetItem(id)
                If IsNothing(ct1) = False Then
                    If idList.Contains(ct1.entry) = False Then
                        idList.Add(ct1.entry)
                    End If
                End If
            Else
                Dim s1 As String = TextBoxSearchCreature.Text.Trim
                If String.IsNullOrWhiteSpace(s1) Then Exit Sub
                Dim c1() As TableCreatureTemplateItem = _tableManager.StorageCreatureTemplate.SearchFromNamePart(s1)
                Dim c2() As TableLocalesCreatureItem = _tableManager.StorageLocalesCreature.SearchFromNamePart(s1)
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
            End If
            ShowListViewSearchCreature(idList.ToArray)
        End If
    End Sub

    Private Sub ShowListViewSearchCreature(ids() As UInteger)
        ListViewCreature.Items.Clear()
        For Each entry As UInteger In ids
            Dim cti As TableCreatureTemplateItem = _tableManager.StorageCreatureTemplate.GetItem(entry)
            Dim loc As TableLocalesCreatureItem = _tableManager.StorageLocalesCreature.GetItem(entry)
            If IsNothing(cti) = False Then
                Dim lvi As ListViewItem = cti.GetListViewForCreatureTemplateSearch(loc.Name(_locale))
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

    Private Sub TextBoxSearchGameObject_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchGameObject.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim idList As New List(Of UInteger)
            If IsNumeric(TextBoxSearchGameObject.Text) Then
                Dim id As Integer = TextBoxSearchCreature.Text
                Dim gt1 As TableGameobjectItem = _tableManager.StorageGameobject.GetItem(id)
                Dim gt2() As TableGameobjectItem = _tableManager.StorageGameobject.SearchWithId(id)
                Dim gt3 As TableGameobjectTemplateItem = _tableManager.StorageGameobjectTemplate.GetItem(id)
                If IsNothing(gt1) = False Then
                    idList.Add(gt1.id)
                End If
                If IsNothing(gt2) = False Then
                    For Each ct As TableGameobjectItem In gt2
                        If idList.Count > 100 Then Exit For
                        If idList.Contains(ct.id) = False Then
                            idList.Add(ct.id)
                        End If
                    Next
                End If
                If IsNothing(gt3) = False Then
                    If idList.Contains(gt3.entry) = False Then
                        idList.Add(gt3.entry)
                    End If
                End If
            Else
                Dim s1 As String = TextBoxSearchGameObject.Text.Trim
                If String.IsNullOrWhiteSpace(s1) Then Exit Sub
                Dim c1() As TableGameobjectTemplateItem = _tableManager.StorageGameobjectTemplate.SearchFromNamePart(s1)
                Dim c2() As TableLocalesGameobjectItem = _tableManager.StorageLocalesGameobject.SearchFromNamePart(s1, _locale)
                If IsNothing(c1) = False Then
                    For Each ct As TableGameobjectTemplateItem In c1
                        idList.Add(ct.entry)
                    Next
                End If
                If IsNothing(c2) = False Then
                    For Each ct As TableLocalesGameobjectItem In c2
                        idList.Add(ct.entry)
                    Next
                End If
            End If
            ShowListViewSearchGameObject(idList.ToArray)
        End If
    End Sub

    Private Sub ShowListViewSearchGameObject(ids() As UInteger)
        ListViewGameObject.Items.Clear()
        For Each entry As UInteger In ids
            Dim cti As TableGameobjectTemplateItem = _tableManager.StorageGameobjectTemplate.GetItem(entry)
            Dim loc As TableLocalesGameobjectItem = _tableManager.StorageLocalesGameobject.GetItem(entry)
            If IsNothing(cti) = False Then
                Dim lvi As ListViewItem = cti.GetListViewForGameObjectTemplateSearch(loc.Name(_locale))
                ListViewGameObject.Items.Add(lvi)
            End If
        Next
    End Sub

    Private Sub ListViewGameObject_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListViewGameObject.MouseDoubleClick
        Dim lv As ListView = sender
        Dim slvic As ListView.SelectedListViewItemCollection = lv.SelectedItems
        If slvic.Count = 0 Then Exit Sub
        Dim entry As UInteger
        If UInteger.TryParse(slvic.Item(0).SubItems(0).Text, entry) Then
            'Dim frm As New WoWGameObjectDialog_434(_databaseManager, _tableManager, entry, _locale)
            'frm.Show()
        End If
    End Sub

#End Region

#Region " Item Search"

    Private Sub TextBoxSearchItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchItem.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim idList As New List(Of UInteger)
            If IsNumeric(TextBoxSearchItem.Text) Then
                Dim id As Integer = TextBoxSearchItem.Text
                Dim it1 As TableItemTemplateItem = _tableManager.StorageItemTemplate.GetItem(id)
                Dim it2 As TableLocalesItemItem = _tableManager.StorageLocalesItem.GetItem(id)
                If IsNothing(it1) = False Then
                    idList.Add(it1.entry)
                End If
                If IsNothing(it2) = False Then
                    If idList.Contains(it2.entry) = False Then
                        idList.Add(it2.entry)
                    End If
                End If
            Else
                Dim s1 As String = TextBoxSearchItem.Text.Trim
                If String.IsNullOrWhiteSpace(s1) Then Exit Sub
                Dim it1() As TableItemTemplateItem = _tableManager.StorageItemTemplate.SearchFromNamePart(s1)
                Dim it2() As TableLocalesItemItem = _tableManager.StorageLocalesItem.SearchFromNamePart(s1, _locale)                
                If IsNothing(it1) = False Then
                    For Each it As TableItemTemplateItem In it1
                        idList.Add(it.entry)
                    Next
                End If
                If IsNothing(it2) = False Then
                    For Each it As TableLocalesItemItem In it2
                        idList.Add(it.entry)
                    Next
                End If
            End If
            ShowListViewSearchItem(idList.ToArray)
        End If
    End Sub

    Private Sub ShowListViewSearchItem(ids() As UInteger)
        ListViewItem.Items.Clear()
        For Each entry As UInteger In ids
            Dim cti As TableItemTemplateItem = _tableManager.StorageItemTemplate.GetItem(entry)
            Dim loc As TableLocalesItemItem = _tableManager.StorageLocalesItem.GetItem(entry)
            If IsNothing(cti) = False Then
                Dim lvi As ListViewItem = cti.GetListViewForNameSearch(loc.Name(_locale))
                ListViewItem.Items.Add(lvi)
            End If
        Next
    End Sub

    Private Sub ListViewItem_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListViewItem.MouseDoubleClick
        Dim lv As ListView = sender
        Dim slvic As ListView.SelectedListViewItemCollection = lv.SelectedItems
        If slvic.Count = 0 Then Exit Sub
        Dim entry As UInteger
        If UInteger.TryParse(slvic.Item(0).SubItems(0).Text, entry) Then
            'Dim frm As New WoWItemDialog_434(_databaseManager, _tableManager, entry, _locale)
            'frm.Show()
        End If
    End Sub

#End Region

#Region " Gossip Search"

    Private Sub TextBoxSearchGossip_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchGossip.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim idList As New List(Of UInteger)
            If IsNumeric(TextBoxSearchGossip.Text) Then
                Dim id As Integer = TextBoxSearchGossip.Text
                Dim gm1 As TableGossipMenuItem = _tableManager.StorageGossipMenu.GetItem(id)
                Dim gm2() As TableGossipMenuOptionItem = _tableManager.StorageGossipMenuOption.SearchWithMenu_id(id)
                Stop
                If IsNothing(gm1) = False Then
                    idList.Add(gm1.entry)
                End If
                If IsNothing(gm2) = False Then
                    For Each gm As TableGossipMenuOptionItem In gm2
                        If idList.Contains(gm.menu_id) = False Then
                            idList.Add(gm.menu_id)
                        End If
                    Next
                End If
            Else
                Dim s1 As String = TextBoxSearchItem.Text.Trim
                If String.IsNullOrWhiteSpace(s1) Then Exit Sub
                Dim it1() As TableGossipMenuOptionItem = _tableManager.StorageGossipMenuOption.SearchFromOptionTextPart(s1)
                Dim it2() As TableGossipMenuOptionItem = _tableManager.StorageGossipMenuOption.SearchFromBoxTextPart(s1)
                Dim it3() As TableLocalesGossipMenuOptionItem = _tableManager.StorageLocalesGossipMenuOption.SearchFromOptionTextPart(s1, _locale)
                Dim it4() As TableLocalesGossipMenuOptionItem = _tableManager.StorageLocalesGossipMenuOption.SearchFromBoxTextPart(s1, _locale)
                If IsNothing(it1) = False Then
                    For Each item As TableGossipMenuOptionItem In it1
                        If idList.Contains(item.menu_id) = False Then
                            idList.Add(item.menu_id)
                        End If
                    Next
                End If
                If IsNothing(it2) = False Then
                    For Each item As TableGossipMenuOptionItem In it2
                        If idList.Contains(item.menu_id) = False Then
                            idList.Add(item.menu_id)
                        End If
                    Next
                End If
                If IsNothing(it3) = False Then
                    For Each item As TableLocalesGossipMenuOptionItem In it3
                        If idList.Contains(item.menu_id) = False Then
                            idList.Add(item.menu_id)
                        End If
                    Next
                End If
                If IsNothing(it4) = False Then
                    For Each item As TableLocalesGossipMenuOptionItem In it4
                        If idList.Contains(item.menu_id) = False Then
                            idList.Add(item.menu_id)
                        End If
                    Next
                End If
            End If
            ShowListViewSearchGossipMenu(idList.ToArray)
            ShowListViewSearchGossipMenuOption(idList.ToArray)
        End If
    End Sub

    Private Sub ShowListViewSearchGossipMenu(gossipIds() As UInteger)
        Stop
    End Sub

    Private Sub ShowListViewSearchGossipMenuOption(gossipIds() As UInteger)
        Stop
    End Sub

#End Region



End Class
