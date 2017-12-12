
Imports ClassLibWoWDatabaseManager

Public Class FormMain
    Private _locale As WoWClientLocale = WoWClientLocale.deDE ' select in what language the table text rows are shown
    Private _databaseManager As WoWDatabaseManager ' hold the store of all database properties
    Private _selectedDatabaseItem As WoWDatabaseItem
    Private _tableManager As New SortedDictionary(Of String, Object)
    Private _selectedTableManager As Object ' WoWTableManager can be 434 or 700' holds all table data

#Region " Main Form"

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _databaseManager = New WoWDatabaseManager
        _selectedDatabaseItem = _databaseManager.GetDefaultWoWDatabaseItem
        SelectTableManager()
        ResizeGossip()
        ShowStatusBar()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        If _selectedTableManager.CheckForFinishLoadAllTables() Then
            MenuStrip1.Enabled = True
            StatusStrip1.Enabled = True
            TabControl1.Enabled = True
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
            Stop
            ShowStatusBar()
        End If
    End Sub

    Private Sub SelectCurrentDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectDatabaseToolStripMenuItem.Click
        Dim frm As New WoWDatabaseDialog With {
           .Text = .Text & ": Select Current Server Database",
           .ButtonOKText = "Select",
           .DatabaseManager = _databaseManager
       }
        If frm.ShowDialog = DialogResult.OK Then
            _selectedDatabaseItem = frm.SelectedWoWDatabaseItem
            If _tableManager.ContainsKey(_selectedDatabaseItem.Key) Then
                _selectedTableManager = _tableManager(_selectedDatabaseItem.Key)
            Else
                SelectTableManager()
            End If
            ShowStatusBar()
        End If
    End Sub

    Private Sub SelectTableManager()
        Select Case _selectedDatabaseItem.ClientVersion.ToString
            Case "V_4_3_4"
                If _selectedDatabaseItem.CoreName = "Trinity" Then
                    _selectedTableManager = New ClassLibWoWTableManager_t434.WoWTableManager(_selectedDatabaseItem, _locale)
                Else
                    _selectedTableManager = New ClassLibWoWTableManager_a434.WoWTableManager(_selectedDatabaseItem, _locale)
                End If
            Case "V_7_2_5"
                _selectedTableManager = New ClassLibWoWTableManager_t725.WoWTableManager(_selectedDatabaseItem, _locale)
            Case Else
                Throw New Exception("ClientVersion not implemented")
        End Select
        _tableManager.Add(_selectedTableManager.GetKey, _selectedTableManager)
        MenuStrip1.Enabled = False
        TabControl1.Enabled = False
        StatusStrip1.Enabled = False
        Timer1.Interval = 5000
        Timer1.Start()
    End Sub

    Private Sub ShowStatusBar()
        Dim s1 As String = ""
        If IsNothing(_selectedDatabaseItem) = False AndAlso _databaseManager.Count > 0 Then
            s1 = "Host: " & _selectedDatabaseItem.ConnectionInfoString & "  "
            s1 &= "Database: " & _selectedDatabaseItem.CoreName & "  "
            s1 &= "Locale: " & _locale.ToString & "  "
        End If
        ToolStripStatusLabel1.Text = s1
    End Sub

    Private Sub FormMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Select Case TabControl1.SelectedTab.Text
            Case "Quest"
                ResizeQuest()
            Case "Creature"
                ResizeCreature()
            Case "GameObject"
                ResizeGameObject()
            Case "Item"
                ResizeItem()
            Case "Gossip"
                ResizeGossip()
        End Select
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedTab.Text
            Case "Quest"
                ResizeQuest()
            Case "Creature"
                ResizeCreature()
            Case "GameObject"
                ResizeGameObject()
            Case "Item"
                ResizeItem()
            Case "Gossip"
                ResizeGossip()
        End Select
    End Sub

    Private Sub ResizeQuest()
        Dim w1 As Integer = TabControl1.Width - 14
        Dim h1 As Integer = TabControl1.Height - ListViewQuest.Top - 30
        TextBoxSearchQuest.Width = w1 - TextBoxSearchQuest.Left
        ListViewQuest.Width = w1
        ListViewQuest.Height = h1
    End Sub

    Private Sub ResizeCreature()
        Dim w1 As Integer = TabControl1.Width - 14
        Dim h1 As Integer = TabControl1.Height - ListViewQuest.Top - 30
        TextBoxSearchCreature.Width = w1 - TextBoxSearchCreature.Left
        ListViewCreature.Width = w1
        ListViewCreature.Height = h1
    End Sub

    Private Sub ResizeGameObject()
        Dim w1 As Integer = TabControl1.Width - 14
        Dim h1 As Integer = TabControl1.Height - ListViewQuest.Top - 30
        TextBoxSearchGameObject.Width = w1 - TextBoxSearchGameObject.Left
        ListViewGameObject.Width = w1
        ListViewGameObject.Height = h1
    End Sub

    Private Sub ResizeItem()
        Dim w1 As Integer = TabControl1.Width - 14
        Dim h1 As Integer = TabControl1.Height - ListViewQuest.Top - 30
        TextBoxSearchItem.Width = w1 - TextBoxSearchItem.Left
        ListViewItem.Width = w1
        ListViewItem.Height = h1
    End Sub

    Private Sub ResizeGossip()
        Dim w1 As Integer = TabControl1.Width - 14
        Dim h1 As Integer = TabControl1.Height - ListViewGossipMenuNpcText.Top - 30
        Dim h2 As Integer = h1 \ 2
        TextBoxSearchGossip.Width = w1 - TextBoxSearchGossip.Left
        ListViewGossipMenuNpcText.Width = w1
        ListViewGossipMenuNpcText.Height = h2
        ListViewGossipMenuOption.Top = ListViewGossipMenuNpcText.Top + ListViewGossipMenuNpcText.Height + 3
        ListViewGossipMenuOption.Height = h2
        ListViewGossipMenuOption.Width = w1
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
                Dim qt As Object = _selectedTableManager.StorageQuestTemplate.GetItem(id)
                Dim lq As Object = _selectedTableManager.StorageLocalesQuest.GetItem(id)
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
                Dim q1() As Object = _selectedTableManager.StorageQuestTemplate.SearchFromTitlePart(s1)
                Dim q2() As Object = _selectedTableManager.StorageLocalesQuest.SearchFromTitlePart(s1, _locale)
                If IsNothing(q1) = False Then
                    For Each qt As Object In q1
                        If idList.Contains(qt.Id) = False Then
                            idList.Add(qt.Id)
                        End If
                    Next
                End If
                If IsNothing(q2) = False Then
                    For Each qt As Object In q2
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
            Dim qti As Object = _selectedTableManager.StorageQuestTemplate.GetItem(id)
            Dim lqi As Object = _selectedTableManager.StorageLocalesQuest.GetItem(id)
            Dim questGiverNameList As New List(Of String)
            Dim qs1() As Object = _selectedTableManager.StorageAreatriggerQuestender.SearchWithQuest(id)
            Dim qs2() As Object = _selectedTableManager.StorageAreatriggerQueststarter.SearchWithQuest(id)
            Dim qs3() As Object = _selectedTableManager.StorageCreatureQuestender.SearchWithQuest(id)
            Dim qs4() As Object = _selectedTableManager.StorageCreatureQueststarter.SearchWithQuest(id)
            Dim qs5() As Object = _selectedTableManager.StorageGameobjectQuestender.SearchWithQuest(id)
            Dim qs6() As Object = _selectedTableManager.StorageGameobjectQueststarter.SearchWithQuest(id)
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
                For Each qi As Object In qs3
                    Dim ci As Object = _selectedTableManager.StorageCreatureTemplate.GetItem(qi.id)
                    If IsNothing(ci) = False Then
                        If questGiverNameList.Contains(ci.name) = False Then
                            questGiverNameList.Add(ci.name)
                        End If
                    End If
                Next
            End If
            If IsNothing(qs4) = False Then
                For Each qi As Object In qs4
                    Dim ci As Object = _selectedTableManager.StorageCreatureTemplate.GetItem(qi.id)
                    If IsNothing(ci) = False Then
                        If questGiverNameList.Contains(ci.name) = False Then
                            questGiverNameList.Add(ci.name)
                        End If
                    End If
                Next
            End If
            If IsNothing(qs5) = False Then
                For Each qi As Object In qs5
                    Dim ci As Object = _selectedTableManager.StorageGameobjectTemplate.GetItem(qi.id)
                    If IsNothing(ci) = False Then
                        If questGiverNameList.Contains(ci.name) = False Then
                            questGiverNameList.Add(ci.name)
                        End If
                    End If
                Next
            End If
            If IsNothing(qs6) = False Then
                For Each qi As Object In qs6
                    Dim ci As Object = _selectedTableManager.StorageGameobjectTemplate.GetItem(qi.id)
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
            Dim frm As New ClassLibWoWTableManager_a434.WoWQuestDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _locale)
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
                Dim cr1 As Object = _selectedTableManager.StorageCreature.GetItem(id)
                Dim cr2() As Object = _selectedTableManager.StorageCreature.SearchWithId(id)
                If IsNothing(cr1) = False Then
                    idList.Add(cr1.id)
                End If
                If IsNothing(cr2) = False Then
                    For Each cr As Object In cr2
                        If idList.Count > 100 Then Exit For
                        If idList.Contains(cr.id) = False Then
                            idList.Add(cr.id)
                        End If
                    Next
                End If
                Dim ct1 As Object = _selectedTableManager.StorageCreatureTemplate.GetItem(id)
                If IsNothing(ct1) = False Then
                    If idList.Contains(ct1.entry) = False Then
                        idList.Add(ct1.entry)
                    End If
                End If
            Else
                Dim s1 As String = TextBoxSearchCreature.Text.Trim
                If String.IsNullOrWhiteSpace(s1) Then Exit Sub
                Dim c1() As Object = _selectedTableManager.StorageCreatureTemplate.SearchFromNamePart(s1)
                Dim c2() As Object = _selectedTableManager.StorageLocalesCreature.SearchFromNamePart(s1)
                If IsNothing(c1) = False Then
                    For Each ct As Object In c1
                        idList.Add(ct.entry)
                    Next
                End If
                If IsNothing(c2) = False Then
                    For Each ct As Object In c2
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
            Dim cti As Object = _selectedTableManager.StorageCreatureTemplate.GetItem(entry)
            Dim loc As Object = _selectedTableManager.StorageLocalesCreature.GetItem(entry)
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
            Stop
            Dim frm As New ClassLibWoWTableManager_a434.WoWCreatureDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _locale)
            frm.Show()
        End If
    End Sub

#End Region

#Region " GameObject Search"

    Private Sub TextBoxSearchGameObject_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchGameObject.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim idList As New List(Of UInteger)
            If IsNumeric(TextBoxSearchGameObject.Text) Then
                Dim id As Integer = TextBoxSearchGameObject.Text
                Dim gt1 As Object = _selectedTableManager.StorageGameobject.GetItem(id)
                Dim gt2() As Object = _selectedTableManager.StorageGameobject.SearchWithId(id)
                Dim gt3 As Object = _selectedTableManager.StorageGameobjectTemplate.GetItem(id)
                If IsNothing(gt1) = False Then
                    idList.Add(gt1.id)
                End If
                If IsNothing(gt2) = False Then
                    For Each ct As Object In gt2
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
                Dim c1() As Object = _selectedTableManager.StorageGameobjectTemplate.SearchFromNamePart(s1)
                Dim c2() As Object = _selectedTableManager.StorageLocalesGameobject.SearchFromNamePart(s1, _locale)
                If IsNothing(c1) = False Then
                    For Each ct As Object In c1
                        idList.Add(ct.entry)
                    Next
                End If
                If IsNothing(c2) = False Then
                    For Each ct As Object In c2
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
            Dim cti As Object = _selectedTableManager.StorageGameobjectTemplate.GetItem(entry)
            Dim loc As Object = _selectedTableManager.StorageLocalesGameobject.GetItem(entry)
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
            Stop
            Dim frm As New ClassLibWoWTableManager_a434.WoWGameObjectDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _locale)
            frm.Show()
        End If
    End Sub

#End Region

#Region " Item Search"

    Private Sub TextBoxSearchItem_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchItem.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim idList As New List(Of UInteger)
            If IsNumeric(TextBoxSearchItem.Text) Then
                Dim id As Integer = TextBoxSearchItem.Text
                Dim it1 As Object = _selectedTableManager.StorageItemTemplate.GetItem(id)
                Dim it2 As Object = _selectedTableManager.StorageLocalesItem.GetItem(id)
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
                Dim it1() As Object = _selectedTableManager.StorageItemTemplate.SearchFromNamePart(s1)
                Dim it2() As Object = _selectedTableManager.StorageLocalesItem.SearchFromNamePart(s1, _locale)
                If IsNothing(it1) = False Then
                    For Each it As Object In it1
                        idList.Add(it.entry)
                    Next
                End If
                If IsNothing(it2) = False Then
                    For Each it As Object In it2
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
            Dim cti As Object = _selectedTableManager.StorageItemTemplate.GetItem(entry)
            Dim loc As Object = _selectedTableManager.StorageLocalesItem.GetItem(entry)
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
            Stop
            Dim frm As New ClassLibWoWTableManager_a434.WoWItemDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _locale)
            frm.Show()
        End If
    End Sub

#End Region

#Region " Gossip Search"

    Private Sub TextBoxSearchGossip_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchGossip.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim idList As New List(Of UInteger)
            If IsNumeric(TextBoxSearchGossip.Text) Then
                Dim id As Integer = TextBoxSearchGossip.Text
                Dim gm1 As Object = _selectedTableManager.StorageGossipMenu.GetItem(id)
                Dim gm2() As Object = _selectedTableManager.StorageGossipMenuOption.SearchWithMenu_id(id)
                If IsNothing(gm1) = False Then
                    idList.Add(gm1.entry)
                End If
                If IsNothing(gm2) = False Then
                    For Each gm As Object In gm2
                        If idList.Contains(gm.menu_id) = False Then
                            idList.Add(gm.menu_id)
                        End If
                    Next
                End If
            Else
                Dim s1 As String = TextBoxSearchItem.Text.Trim
                If String.IsNullOrWhiteSpace(s1) Then Exit Sub
                Dim it1() As Object = _selectedTableManager.StorageGossipMenuOption.SearchFromOptionTextPart(s1)
                Dim it2() As Object = _selectedTableManager.StorageGossipMenuOption.SearchFromBoxTextPart(s1)
                Dim it3() As Object = _selectedTableManager.StorageLocalesGossipMenuOption.SearchFromOptionTextPart(s1, _locale)
                Dim it4() As Object = _selectedTableManager.StorageLocalesGossipMenuOption.SearchFromBoxTextPart(s1, _locale)
                If IsNothing(it1) = False Then
                    For Each item As Object In it1
                        If idList.Contains(item.menu_id) = False Then
                            idList.Add(item.menu_id)
                        End If
                    Next
                End If
                If IsNothing(it2) = False Then
                    For Each item As Object In it2
                        If idList.Contains(item.menu_id) = False Then
                            idList.Add(item.menu_id)
                        End If
                    Next
                End If
                If IsNothing(it3) = False Then
                    For Each item As Object In it3
                        If idList.Contains(item.menu_id) = False Then
                            idList.Add(item.menu_id)
                        End If
                    Next
                End If
                If IsNothing(it4) = False Then
                    For Each item As Object In it4
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
        ListViewGossipMenuNpcText.Items.Clear()
        For Each menuId As UInteger In gossipIds
            Dim gmi() As Object = _selectedTableManager.StorageGossipMenu.SearchWithEntry(menuId)
            If IsNothing(gmi) = False Then
                For Each item As Object In gmi
                    Dim npc1 As Object = _selectedTableManager.StorageNpcText.GetItem(item.text_id)
                    Dim npc2 As Object = _selectedTableManager.StorageLocalesNpcText.GetItem(item.text_id)
                    Dim lvi As New ListViewItem(menuId)
                    lvi.SubItems.Add(item.text_id)
                    If IsNothing(npc1) Then
                        lvi.SubItems.Add("")
                        lvi.SubItems.Add("")
                        lvi.SubItems.Add("")
                    Else
                        lvi.SubItems.Add(npc1.NpcText(0))
                        lvi.SubItems.Add(npc1.BroadcastTextID(0))
                        lvi.SubItems.Add(npc1.em0(0))
                    End If
                    If IsNothing(npc2) Then
                        lvi.SubItems.Add("")
                    Else
                        lvi.SubItems.Add(npc2.NpcText(0, _locale))
                    End If
                    ListViewGossipMenuNpcText.Items.Add(lvi)
                Next
            End If
        Next
    End Sub

    Private Sub ShowListViewSearchGossipMenuOption(gossipIds() As UInteger)        
        ListViewGossipMenuOption.Items.Clear()
        For Each menuId As UInteger In gossipIds
            Dim gmi() As Object = _selectedTableManager.StorageGossipMenuOption.SearchWithMenu_id(menuId)
            If IsNothing(gmi) = False Then
                For Each item As Object In gmi
                    Dim lgmo As Object = _selectedTableManager.StorageLocalesGossipMenuOption.GetItem(item.GetKey)
                    Dim lvi As New ListViewItem(item.menu_id.ToString)
                    lvi.SubItems.Add(item.id)
                    lvi.SubItems.Add(item.option_text)
                    If IsNothing(lgmo) Then
                        lvi.SubItems.Add("")
                    Else
                        lvi.SubItems.Add(lgmo.OptionText(_locale))
                    End If
                    lvi.SubItems.Add(item.OptionBroadcastTextID)
                    lvi.SubItems.Add(item.option_icon)
                    lvi.SubItems.Add(item.npc_option_npcflag)
                    lvi.SubItems.Add(item.box_money)
                    lvi.SubItems.Add(item.box_text)
                    If IsNothing(lgmo) Then
                        lvi.SubItems.Add("")
                    Else
                        lvi.SubItems.Add(lgmo.BoxText(_locale))
                    End If
                    ListViewGossipMenuOption.Items.Add(lvi)
                Next
            End If

        Next
    End Sub

    Private Sub ListViewGossipMenuNpcText_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListViewGossipMenuNpcText.MouseDoubleClick
        Dim lv As ListView = sender
        Dim slvic As ListView.SelectedListViewItemCollection = lv.SelectedItems
        If slvic.Count = 0 Then Exit Sub
        Dim lvi As ListViewItem = slvic.Item(0)
        Dim menuId As UInteger = lvi.SubItems(0).Text
        Stop
        Dim frm As New ClassLibWoWTableManager_a434.WoWGossipMenuDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, menuId, _locale)
        frm.Show()
    End Sub

    Private Sub ListViewGossipMenuOption_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListViewGossipMenuOption.MouseDoubleClick        
        Dim lv As ListView = sender
        Dim slvic As ListView.SelectedListViewItemCollection = lv.SelectedItems
        If slvic.Count = 0 Then Exit Sub
        Dim lvi As ListViewItem = slvic.Item(0)
        Dim menuId As UInteger = lvi.SubItems(0).Text
        Stop
        Dim frm As New ClassLibWoWTableManager_a434.WoWGossipMenuDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, menuId, _locale)
        frm.Show()
    End Sub

#End Region



End Class
