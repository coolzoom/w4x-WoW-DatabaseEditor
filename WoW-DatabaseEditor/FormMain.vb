
Imports ClassLibWoWDatabaseManager
Imports ClassLibWoWDatabaseManager.WowModuleHelpers
Imports System.Text

Public Class FormMain

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
            For Each di As WoWDatabaseItem In _databaseManager.DatabaseStorage.Values
                If di.IsDefault Or di.IsCompare Then
                    _selectedDatabaseItem = di
                    If _tableManager.ContainsKey(_selectedDatabaseItem.GetKey) = False Then
                        SelectTableManager()
                        ShowStatusBar()
                        Exit Sub
                    End If
                End If
            Next
            _selectedDatabaseItem = _databaseManager.GetDefaultWoWDatabaseItem
            _selectedTableManager = _tableManager(_selectedDatabaseItem.GetKey)
            ShowStatusBar()
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
        Dim frm As New WoWDatabaseDialog(_databaseManager, "Database Dialog Editor: Edit entry", "OK")
        If frm.ShowDialog = DialogResult.OK Then
            SelectTableManager()
            ShowStatusBar()
        End If
    End Sub

    Private Sub SelectCurrentDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectDatabaseToolStripMenuItem.Click
        Dim frm As New WoWDatabaseDialog(_databaseManager, "Database Dialog Editor: Select item", "Select")
        If frm.ShowDialog = DialogResult.OK Then
            _selectedDatabaseItem = frm.SelectedDatabaseItem
            If _tableManager.ContainsKey(_selectedDatabaseItem.GetKey) Then
                _selectedTableManager = _tableManager(_selectedDatabaseItem.GetKey)
            Else
                SelectTableManager()
            End If
            ShowStatusBar()
        End If
    End Sub

    Private Sub SelectTableManager()
        Select Case _selectedDatabaseItem.CoreName
            Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                Select Case _selectedDatabaseItem.ClientVersionNumber
                    Case EClientVersionNumbers.V_4_3_4
                        _selectedTableManager = New ClassLibWoWTableManager_t434.WoWTableManager(_selectedDatabaseItem, _defaultLocale)
                    Case EClientVersionNumbers.V_7_x_x
                        _selectedTableManager = New ClassLibWoWTableManager_t725.WoWTableManager(_selectedDatabaseItem, _defaultLocale)
                    Case Else
                        Throw New Exception("Client Version not supported")
                End Select
            Case Else ' arkcore or compatible
                _selectedTableManager = New ClassLibWoWTableManager_a434.WoWTableManager(_selectedDatabaseItem, _defaultLocale)
        End Select
        If _tableManager.ContainsKey(_selectedTableManager.DbItem.GetKey) Then
            _tableManager.Item(_selectedTableManager.DbItem.GetKey) = _selectedTableManager
        Else
            _tableManager.Add(_selectedTableManager.DbItem.GetKey, _selectedTableManager)
        End If
        MenuStrip1.Enabled = False
        TabControl1.Enabled = False
        StatusStrip1.Enabled = False
        Timer1.Interval = 5000
        Timer1.Start()
    End Sub

    Private Sub ShowStatusBar()
        Dim s1 As String = ""
        If _selectedDatabaseItem.IsDone AndAlso _selectedDatabaseItem.IsConnectionAvaible = False Then
            s1 = "No Database found. The Connection to " & _selectedDatabaseItem.ConnectionInfoString & " is death."
        ElseIf IsNothing(_selectedDatabaseItem) = False AndAlso _databaseManager.Count > 0 Then
            s1 = "Host: " & _selectedDatabaseItem.ConnectionInfoString & "  "
            s1 &= "CoreName: " & _selectedDatabaseItem.CoreName & "  "
            s1 &= "Build: " & _selectedDatabaseItem.ClientVersionNumber.ToString & "  "
            s1 &= "Locale: " & _defaultLocale.ToString & "  "
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
        Dim frm As New WoWLocaleDialog(_defaultLocale) With {
            .Text = .Text & ": Select database locale"
        }
        If frm.ShowDialog = DialogResult.OK Then
            If _defaultLocale <> frm.GetSelectedLocale Then
                _defaultLocale = frm.GetSelectedLocale
                ShowStatusBar()
            End If
        End If

    End Sub

#End Region

#Region " Quest Search"

    Private Sub TextBoxSearchQuest_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxSearchQuest.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim idList As New List(Of UInteger)
            Dim id As Integer
            Dim q1 As Object = Nothing
            Dim q2 As Object = Nothing
            If IsNumeric(TextBoxSearchQuest.Text) Then
                id = TextBoxSearchQuest.Text
                Select Case _selectedDatabaseItem.CoreName
                    Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                        Select Case _selectedDatabaseItem.ClientVersionNumber
                            Case EClientVersionNumbers.V_4_3_4
                                q1 = _selectedTableManager.StorageQuestTemplate.GetItem(id)
                                q2 = _selectedTableManager.StorageQuestTemplateLocale.GetItem(id)
                            Case EClientVersionNumbers.V_7_x_x, EClientVersionNumbers.V_7_x_x
                                q1 = _selectedTableManager.StorageQuestTemplate.GetItem(id)
                                q2 = _selectedTableManager.StorageQuestTemplateLocale.GetItem(id)
                            Case Else
                                Throw New Exception("Client Version not supported")
                        End Select
                    Case Else
                        q1 = _selectedTableManager.StorageQuestTemplate.GetItem(id)
                        q2 = _selectedTableManager.StorageLocalesQuest.GetItem(id)
                End Select
                If IsNothing(q1) = False Then
                    idList.Add(q1.Id)
                End If
                If IsNothing(q2) = False Then
                    If idList.Contains(q2.Id) = False Then
                        idList.Add(q2.Id)
                    End If
                End If
                Dim qg1() As Object = _selectedTableManager.StorageCreatureQuestEnder.SearchWithId(id)
                Dim qg2() As Object = _selectedTableManager.StorageCreatureQuestStarter.SearchWithId(id)
                Dim qg3() As Object = _selectedTableManager.StorageGameobjectQuestEnder.SearchWithId(id)
                Dim qg4() As Object = _selectedTableManager.StorageGameobjectQuestStarter.SearchWithId(id)
                For Each qe1 In qg1
                    Dim quest As UInteger = qe1.quest
                    If idList.Contains(quest) = False Then
                        idList.Add(quest)
                    End If
                Next
                For Each qe1 In qg2
                    Dim quest As UInteger = qe1.quest
                    If idList.Contains(quest) = False Then
                        idList.Add(quest)
                    End If
                Next
                For Each qe1 In qg3
                    Dim quest As UInteger = qe1.quest
                    If idList.Contains(quest) = False Then
                        idList.Add(quest)
                    End If
                Next
                For Each qe1 In qg4
                    Dim quest As UInteger = qe1.quest
                    If idList.Contains(quest) = False Then
                        idList.Add(quest)
                    End If
                Next



            Else
                Dim txtPart As String = TextBoxSearchQuest.Text.Trim
                If String.IsNullOrWhiteSpace(txtPart) Then Exit Sub
                Select Case _selectedDatabaseItem.CoreName
                    Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                        Select Case _selectedDatabaseItem.ClientVersionNumber
                            Case EClientVersionNumbers.V_4_3_4
                                q1 = _selectedTableManager.StorageQuestTemplate.SearchFromTitlePart(id)
                                q2 = _selectedTableManager.StorageQuestTemplateLocale.SearchFromTitlePart(id, _defaultLocale)
                            Case EClientVersionNumbers.V_7_x_x
                                q1 = _selectedTableManager.StorageQuestTemplate.SearchFromTitlePart(id)
                                q2 = _selectedTableManager.StorageQuestTemplateLocale.SearchFromTitlePart(id, _defaultLocale)
                            Case Else
                                Throw New Exception("Client Version not supported")
                        End Select
                    Case Else
                        q1 = _selectedTableManager.StorageQuestTemplate.SearchFromTitlePart(txtPart)
                        q2 = _selectedTableManager.StorageLocalesQuest.SearchFromTitlePart(txtPart, _defaultLocale)
                End Select
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
        Dim q1 As Object = Nothing
        Dim q2 As Object = Nothing
        For Each id As UInteger In ids
            Select Case _selectedDatabaseItem.CoreName
                Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                    Select Case _selectedDatabaseItem.ClientVersionNumber
                        Case EClientVersionNumbers.V_4_3_4
                            Dim locKey As String = ClassLibWoWTableManager_t434.TableQuestTemplateLocaleItem.GetKey(id, _defaultLocale.ToString)
                            q1 = _selectedTableManager.StorageQuestTemplate.GetItem(id)
                            q2 = _selectedTableManager.StorageQuestTemplateLocale.GetItem(locKey)
                        Case EClientVersionNumbers.V_7_x_x, EClientVersionNumbers.V_7_x_x
                            Dim locKey As String = ClassLibWoWTableManager_t725.TableQuestTemplateLocaleItem.GetKey(id, _defaultLocale.ToString)
                            q1 = _selectedTableManager.StorageQuestTemplate.GetItem(id)
                            q2 = _selectedTableManager.StorageQuestTemplateLocale.GetItem(locKey)
                        Case Else
                            Throw New Exception("Client Version not supported")
                    End Select
                Case Else
                    q1 = _selectedTableManager.StorageQuestTemplate.GetItem(id)
                    q2 = _selectedTableManager.StorageLocalesQuest.GetItem(id)
            End Select

            Dim questGiverNameList As New List(Of String)
            Dim qs1() As Object = Nothing
            Dim qs2() As Object = Nothing
            Dim qs3() As Object = Nothing
            Dim qs4() As Object = Nothing
            Dim qs5() As Object = Nothing
            Dim qs6() As Object = Nothing

            Select Case _selectedDatabaseItem.CoreName
                Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                    Select Case _selectedDatabaseItem.ClientVersionNumber
                        Case EClientVersionNumbers.V_4_3_4
                            qs3 = _selectedTableManager.StorageCreatureQuestEnder.SearchWithQuest(id)
                            qs4 = _selectedTableManager.StorageCreatureQuestStarter.SearchWithQuest(id)
                            qs5 = _selectedTableManager.StorageGameobjectQuestEnder.SearchWithQuest(id)
                            qs6 = _selectedTableManager.StorageGameobjectQuestStarter.SearchWithQuest(id)
                        Case EClientVersionNumbers.V_7_x_x, EClientVersionNumbers.V_7_x_x
                            qs3 = _selectedTableManager.StorageCreatureQuestEnder.SearchWithQuest(id)
                            qs4 = _selectedTableManager.StorageCreatureQuestStarter.SearchWithQuest(id)
                            qs5 = _selectedTableManager.StorageGameobjectQuestEnder.SearchWithQuest(id)
                            qs6 = _selectedTableManager.StorageGameobjectQuestStarter.SearchWithQuest(id)
                        Case Else
                            Throw New Exception("Client Version not supported")
                    End Select
                Case Else
                    qs1 = _selectedTableManager.StorageAreatriggerQuestender.SearchWithQuest(id)
                    qs2 = _selectedTableManager.StorageAreatriggerQueststarter.SearchWithQuest(id)
                    qs3 = _selectedTableManager.StorageCreatureQuestEnder.SearchWithQuest(id)
                    qs4 = _selectedTableManager.StorageCreatureQuestStarter.SearchWithQuest(id)
                    qs5 = _selectedTableManager.StorageGameobjectQuestEnder.SearchWithQuest(id)
                    qs6 = _selectedTableManager.StorageGameobjectQuestStarter.SearchWithQuest(id)
            End Select

            Dim lvi As New ListViewItem(id)
            If IsNothing(q1) Then
                lvi.SubItems.Add("")
            Else
                Select Case _selectedDatabaseItem.CoreName
                    Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                        lvi.SubItems.Add(q1.LogTitle)
                    Case Else
                        lvi.SubItems.Add(q1.Title)
                End Select
            End If
            If IsNothing(q2) Then
                lvi.SubItems.Add("")
            Else
                Select Case _selectedDatabaseItem.CoreName
                    Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                        lvi.SubItems.Add(q2.LogTitle)
                    Case Else
                        lvi.SubItems.Add(q2.Title(_defaultLocale))
                End Select
            End If
            If IsNothing(qs1) = False Then
                For Each qi As Object In qs1
                    Dim ci As Object = _selectedTableManager.StorageAreatriggerQuestender.GetItem(qi.id)
                    If IsNothing(ci) = False Then
                        If questGiverNameList.Contains(ci.name) = False Then
                            questGiverNameList.Add(ci.name)
                        End If
                    End If
                Next
            End If
            If IsNothing(qs2) = False Then
                For Each qi As Object In qs2
                    Dim ci As Object = _selectedTableManager.StorageAreatriggerQueststarter.GetItem(qi.id)
                    If IsNothing(ci) = False Then
                        If questGiverNameList.Contains(ci.name) = False Then
                            questGiverNameList.Add(ci.name)
                        End If
                    End If
                Next
            End If
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
            Select Case _selectedDatabaseItem.CoreName
                Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                    Select Case _selectedDatabaseItem.ClientVersionNumber
                        Case EClientVersionNumbers.V_4_3_4
                            Dim frm As New ClassLibWoWTableManager_t434.WoWQuestDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _defaultLocale)
                            frm.Show()
                        Case EClientVersionNumbers.V_7_x_x, EClientVersionNumbers.V_7_x_x
                            Dim frm As New ClassLibWoWTableManager_t725.WoWQuestDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _defaultLocale)
                            frm.Show()
                        Case Else
                            Throw New Exception("Client Version not supported")
                    End Select
                Case Else
                    Dim frm As New ClassLibWoWTableManager_a434.WoWQuestDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _defaultLocale)
                    frm.Show()
            End Select
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
            Dim cti As Object = Nothing
            Dim loc As Object = Nothing
            Dim _locName As String = ""
            Select Case _selectedDatabaseItem.CoreName
                Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                    Select Case _selectedDatabaseItem.ClientVersionNumber
                        Case EClientVersionNumbers.V_4_3_4
                            cti = _selectedTableManager.StorageCreatureTemplate.GetItem(entry)
                            loc = _selectedTableManager.StorageCreatureTemplateLocale.GetItem(ClassLibWoWTableManager_t434.TableCreatureTemplateLocaleItem.GetKey(entry, _defaultLocale.ToString))
                            If IsNothing(loc) = False Then
                                _locName = loc.name
                            End If
                        Case EClientVersionNumbers.V_7_x_x, EClientVersionNumbers.V_7_x_x
                            cti = _selectedTableManager.StorageCreatureTemplate.GetItem(entry)
                            loc = _selectedTableManager.StorageCreatureTemplateLocale.GetItem(ClassLibWoWTableManager_t725.TableCreatureTemplateLocaleItem.GetKey(entry, _defaultLocale.ToString))
                            If IsNothing(loc) = False Then
                                _locName = loc.name
                            End If
                        Case Else
                            Throw New Exception("Client Version not supported")
                    End Select
                Case Else
                    cti = _selectedTableManager.StorageCreatureTemplate.GetItem(entry)
                    loc = _selectedTableManager.StorageLocalesCreature.GetItem(entry)
                    If IsNothing(loc) = False Then
                        _locName = loc.Name(_defaultLocale)
                    End If
            End Select
            If IsNothing(cti) = False Then
                Dim lvi As ListViewItem = cti.GetListViewForCreatureTemplateSearch(_locName)
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
            Select Case _selectedDatabaseItem.CoreName
                Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                    Select Case _selectedDatabaseItem.ClientVersionNumber
                        Case EClientVersionNumbers.V_4_3_4
                            Dim frm As New ClassLibWoWTableManager_t434.WoWCreatureDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _defaultLocale)
                            frm.Show()
                        Case EClientVersionNumbers.V_7_x_x, EClientVersionNumbers.V_7_x_x
                            Dim frm As New ClassLibWoWTableManager_t725.WoWCreatureDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _defaultLocale)
                            frm.Show()
                        Case Else
                            Throw New Exception("Client Version not supported")
                    End Select
                Case Else
                    Dim frm As New ClassLibWoWTableManager_a434.WoWCreatureDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _defaultLocale)
                    frm.Show()
            End Select
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
                Dim c1(), c2() As Object
                Dim textPart As String = TextBoxSearchGameObject.Text.Trim
                If String.IsNullOrWhiteSpace(textPart) Then Exit Sub
                Select Case _selectedDatabaseItem.CoreName
                    Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                        Select Case _selectedDatabaseItem.ClientVersionNumber
                            Case EClientVersionNumbers.V_4_3_4
                                c1 = _selectedTableManager.StorageGameobjectTemplate.SearchFromNamePart(textPart)
                                c2 = _selectedTableManager.StorageGameobjectTemplateLocale.SearchFromNamePart(textPart, _defaultLocale)
                            Case EClientVersionNumbers.V_7_x_x, EClientVersionNumbers.V_7_x_x
                                c1 = _selectedTableManager.StorageGameobjectTemplate.SearchFromNamePart(textPart)
                                c2 = _selectedTableManager.StorageGameobjectTemplateLocale.SearchFromNamePart(textPart, _defaultLocale)
                            Case Else
                                Throw New Exception("Client Version not supported")
                        End Select
                    Case Else
                        c1 = _selectedTableManager.StorageGameobjectTemplate.SearchFromNamePart(textPart)
                        c2 = _selectedTableManager.StorageGameobjectTemplateLocale.SearchFromNamePart(textPart, _defaultLocale)
                End Select
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
        Dim cti, loc As Object
        Dim locKey As String
        Dim locName As String = ""
        For Each entry As UInteger In ids
            Select Case _selectedDatabaseItem.CoreName
                Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                    Select Case _selectedDatabaseItem.ClientVersionNumber
                        Case EClientVersionNumbers.V_4_3_4
                            locKey = ClassLibWoWTableManager_t434.TableGameobjectTemplateLocaleItem.GetKey(entry, _defaultLocale.ToString)
                            cti = _selectedTableManager.StorageGameobjectTemplate.GetItem(entry)
                            loc = _selectedTableManager.StorageGameobjectTemplateLocale.GetItem(locKey)
                            If IsNothing(loc) = False Then
                                locName = loc.name
                            End If
                        Case EClientVersionNumbers.V_7_x_x, EClientVersionNumbers.V_7_x_x
                            locKey = ClassLibWoWTableManager_t725.TableGameobjectTemplateLocaleItem.GetKey(entry, _defaultLocale.ToString)
                            cti = _selectedTableManager.StorageGameobjectTemplate.GetItem(entry)
                            loc = _selectedTableManager.StorageGameobjectTemplateLocale.GetItem(locKey)
                            If IsNothing(loc) = False Then
                                locName = loc.name
                            End If
                        Case Else
                            Throw New Exception("Client Version not supported")
                    End Select
                Case Else
                    locKey = entry
                    cti = _selectedTableManager.StorageGameobjectTemplate.GetItem(entry)
                    loc = _selectedTableManager.StorageLocalesGameobject.GetItem(entry)
                    If IsNothing(loc) = False Then
                        locName = loc.name(_defaultLocale)
                    End If
            End Select
            If IsNothing(cti) = False Then
                Dim lvi As ListViewItem = cti.GetListViewForGameObjectTemplateSearch(locName)
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
            Select Case _selectedDatabaseItem.CoreName
                Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                    Select Case _selectedDatabaseItem.ClientVersionNumber
                        Case EClientVersionNumbers.V_4_3_4
                            Dim frm As New ClassLibWoWTableManager_t434.WoWGameObjectDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _defaultLocale)
                            frm.Show()
                        Case EClientVersionNumbers.V_7_x_x, EClientVersionNumbers.V_7_x_x
                            Dim frm As New ClassLibWoWTableManager_t725.WoWGameObjectDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _defaultLocale)
                            frm.Show()
                        Case Else
                            Throw New Exception("Client Version not supported")
                    End Select
                Case Else
                    Dim frm As New ClassLibWoWTableManager_a434.WoWGameObjectDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _defaultLocale)
                    frm.Show()
            End Select
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
                Dim it2() As Object = _selectedTableManager.StorageLocalesItem.SearchFromNamePart(s1, _defaultLocale)
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
                Dim lvi As ListViewItem = cti.GetListViewForNameSearch(loc.Name(_defaultLocale))
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
            Select Case _selectedDatabaseItem.CoreName
                Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                    Select Case _selectedDatabaseItem.ClientVersionNumber
                        Case EClientVersionNumbers.V_4_3_4
                            Throw New Exception("Items are used by DBC")
                        Case EClientVersionNumbers.V_7_x_x, EClientVersionNumbers.V_7_x_x
                            Throw New Exception("Items are used by DBC")
                        Case Else
                            Throw New Exception("Client Version not supported")
                    End Select
                Case Else
                    Dim frm As New ClassLibWoWTableManager_a434.WoWItemDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, entry, _defaultLocale)
                    frm.Show()
            End Select
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
                Dim it3() As Object = _selectedTableManager.StorageLocalesGossipMenuOption.SearchFromOptionTextPart(s1, _defaultLocale)
                Dim it4() As Object = _selectedTableManager.StorageLocalesGossipMenuOption.SearchFromBoxTextPart(s1, _defaultLocale)
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
                        lvi.SubItems.Add(npc2.NpcText(0, _defaultLocale))
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
                        lvi.SubItems.Add(lgmo.OptionText(_defaultLocale))
                    End If
                    lvi.SubItems.Add(item.OptionBroadcastTextID)
                    lvi.SubItems.Add(item.option_icon)
                    lvi.SubItems.Add(item.npc_option_npcflag)
                    lvi.SubItems.Add(item.box_money)
                    lvi.SubItems.Add(item.box_text)
                    If IsNothing(lgmo) Then
                        lvi.SubItems.Add("")
                    Else
                        lvi.SubItems.Add(lgmo.BoxText(_defaultLocale))
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
        Select Case _selectedDatabaseItem.CoreName
            Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                Select Case _selectedDatabaseItem.ClientVersionNumber
                    Case EClientVersionNumbers.V_4_3_4
                        Dim frm As New ClassLibWoWTableManager_t434.WoWGossipMenuDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, menuId, _defaultLocale)
                        frm.Show()
                    Case EClientVersionNumbers.V_7_x_x, EClientVersionNumbers.V_7_x_x
                        Dim frm As New ClassLibWoWTableManager_t725.WoWGossipMenuDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, menuId, _defaultLocale)
                        frm.Show()
                    Case Else
                        Throw New Exception("Client Version not supported")
                End Select
            Case Else
                Dim frm As New ClassLibWoWTableManager_a434.WoWGossipMenuDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, menuId, _defaultLocale)
                frm.Show()
        End Select
    End Sub

    Private Sub ListViewGossipMenuOption_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListViewGossipMenuOption.MouseDoubleClick
        Dim lv As ListView = sender
        Dim slvic As ListView.SelectedListViewItemCollection = lv.SelectedItems
        If slvic.Count = 0 Then Exit Sub
        Dim lvi As ListViewItem = slvic.Item(0)
        Dim menuId As UInteger = lvi.SubItems(0).Text
        Select Case _selectedDatabaseItem.CoreName
            Case EServerCoreNames.Trinity.ToString, EServerCoreNames.ForgottenLand.ToString
                Select Case _selectedDatabaseItem.ClientVersionNumber
                    Case EClientVersionNumbers.V_4_3_4
                        Dim frm As New ClassLibWoWTableManager_t434.WoWGossipMenuDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, menuId, _defaultLocale)
                        frm.Show()
                    Case EClientVersionNumbers.V_7_x_x, EClientVersionNumbers.V_7_x_x
                        Dim frm As New ClassLibWoWTableManager_t725.WoWGossipMenuDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, menuId, _defaultLocale)
                        frm.Show()
                    Case Else
                        Throw New Exception("Client Version not supported")
                End Select
            Case Else
                Dim frm As New ClassLibWoWTableManager_a434.WoWGossipMenuDialog(_databaseManager, _selectedTableManager, _selectedDatabaseItem, menuId, _defaultLocale)
                frm.Show()
        End Select
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim url As String = "http://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=BE2MPYL9EQ25Q&item_name=ArkCORE%20NG%20Editor"
        System.Diagnostics.Process.Start(url)
    End Sub


#End Region

#Region " Admin Test Area"

    Private Sub T1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles T1ToolStripMenuItem.Click
        CreateStuctureClass()
    End Sub

    Private Sub T2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles T2ToolStripMenuItem.Click
        Dim sb1 As New StringBuilder

        sb1.AppendLine(CreateVarNameChangeToUnderScorePart())

        If sb1.Length > 0 Then
            My.Computer.Clipboard.SetText(sb1.ToString.Replace(vbCrLf & vbCrLf, vbCrLf))
            SendInfoBoxClipboard()
        End If
    End Sub

    Private Sub CreateStuctureClass()
        Dim sb1 As New StringBuilder
        Dim _navicatTableStruct As List(Of String()) = GetNavicatTableStructData()
        sb1.AppendLine(CreateStructPrivateVarAndProperties(_navicatTableStruct))
        sb1.AppendLine(CreateStructProperties(_navicatTableStruct))

        If sb1.Length > 0 Then
            My.Computer.Clipboard.SetText(sb1.ToString.Replace(vbCrLf & vbCrLf, vbCrLf))
            SendInfoBoxClipboard()
        End If
    End Sub

    Private Function CreateStructPrivateVarAndProperties(nts As List(Of String())) As String
        Dim sb1 As New StringBuilder
        For Each v1() As String In nts
            If v1.Length = 17 Then
                Dim _name As String = v1(0)
                Dim _fName As String = GetVarNameToFunctionName(_name)
                Dim _type As String = TypeFromNavicatVarType(v1(1), v1(6)) ' type and unsigned
                Dim _isPrimaryKey As Boolean = BoolFromNavicatBoolType(v1(15))
                sb1.AppendLine(String.Format("private _{0} as {1}", _name, _type))
            End If
        Next
        sb1.AppendLine()
        sb1.AppendLine("private _isNew as Boolean")
        sb1.AppendLine("private _isChanged as Boolean")
        sb1.AppendLine()
        sb1.AppendLine("Public Sub New()")
        sb1.AppendLine("End Sub")
        sb1.AppendLine()

        Return sb1.ToString
    End Function

    Private Function CreateStructProperties(nts As List(Of String())) As String
        Dim sb1 As New StringBuilder
        sb1.AppendLine()
        sb1.AppendLine(String.Format("#Region {0} Properties{0}", Chr(34)))
        sb1.AppendLine()
        For Each v1() As String In nts
            If v1.Length = 17 Then
                Dim _name As String = v1(0)
                Dim _fName As String = GetVarNameToFunctionName(_name)
                Dim _type As String = TypeFromNavicatVarType(v1(1), v1(6)) ' type and unsigned
                Dim _isPrimaryKey As Boolean = BoolFromNavicatBoolType(v1(15))
                '
                sb1.AppendLine(String.Format("Public Property {0} As {1}", _fName, _type))
                sb1.AppendLine("Get")
                sb1.AppendLine(String.Format("Return _{0}", _name))
                sb1.AppendLine("End Get")
                sb1.AppendLine(String.Format("Set(value As {0})", _type))
                sb1.AppendLine(String.Format("If _{0} <> value Then", _name))
                sb1.AppendLine(String.Format("_{0} = value", _name))
                sb1.AppendLine("_isChanged = True")
                sb1.AppendLine("End If")
                sb1.AppendLine("End Set")
                sb1.AppendLine("End Property")
                sb1.AppendLine()
            End If
        Next
        '
        sb1.AppendLine("Public Property IsNew As Boolean")
        sb1.AppendLine("Get")
        sb1.AppendLine("Return _isNew")
        sb1.AppendLine("End Get")
        sb1.AppendLine("Set(value As Boolean)")
        sb1.AppendLine("_isNew = value")
        sb1.AppendLine("End Set")
        sb1.AppendLine("End Property")
        sb1.AppendLine()
        '
        sb1.AppendLine("Public Property IsChanged As Boolean")
        sb1.AppendLine("Get")
        sb1.AppendLine("Return _isChanged")
        sb1.AppendLine("End Get")
        sb1.AppendLine("Set(value As Boolean)")
        sb1.AppendLine("_isChanged = value")
        sb1.AppendLine("End Set")
        sb1.AppendLine("End Property")
        sb1.AppendLine()
        sb1.AppendLine("#End Region")
        sb1.AppendLine()
        '
        Return sb1.ToString
    End Function

    Private Function CreateVarNameChangeToUnderScorePart() As String
        Dim tLines() As String = GetClipboardTextLines()
        Dim sb1 As New StringBuilder

        Dim varNames As New SortedDictionary(Of String, String)

        For Each tLine As String In tLines
            Dim s2 As String = tLine.Trim
            Dim s3 As String = s2.ToLower
            Dim v1() As String = Split(s2, " = ", 4)
            Dim v2() As String = Split(s3, " ", 3)
            If v1.Length = 2 AndAlso (InStr(v1(0), v1(1)) = 2 Or InStr(v1(1), v1(0)) = 2) Then
                For i As Integer = 0 To 1
                    Select Case Mid(v1(i), 1, 1)  ' get leading char
                        Case "_"
                            Stop
                        Case "."
                            v1(i) = "._" & Mid(v1(i), 2)
                        Case Else
                            If varNames.ContainsKey(v1(i)) = False Then
                                varNames.Add(v1(i), "_" & v1(i))
                            End If
                            v1(i) = "_" & v1(i)
                    End Select
                Next
                sb1.AppendLine(Join(v1, " = "))
            Else
                ' prepare 
                Dim vars() As String = GetHiddenVarNames(tLine, varNames.Keys.ToArray)
                '
                If vars.Length = 0 Then
                    If v2(0) = "private" Or v2(0) = "public" Then
                        If v2(1) = "sub" Or v2(1) = "function" Or v2(1) = "shared" Then
                            sb1.AppendLine()
                        End If
                    End If
                    If v2(0) = "#region" Or v2(0) = "#end" Then
                        sb1.AppendLine()
                    End If
                    sb1.AppendLine(tLine)
                Else
                    Dim s1 As String = tLine
                    Dim b1 As Boolean = (InStr(tLine, ".AppendFormat(") > 0 Or InStr(tLine, "String.Format(") > 0)
                    Dim be2 As String = "", be3 As String = ""
                    For Each be1 As String In vars
                        Dim b2 As Boolean = (InStr(tLine.ToLower, Chr(34) & be1.ToLower & " ") > 0)
                        If b1 And b2 Then
                            be2 = "." & be1
                            be3 = "." & varNames(be1)
                        Else
                            be2 = be1
                            be3 = varNames(be1)
                        End If
                        s1 = Replace(s1, be2, be3)
                    Next
                    sb1.AppendLine(s1)
                End If
            End If
        Next

        Return sb1.ToString
    End Function

    Private Function GetHiddenVarNames(tLine As String, varNames() As String) As String()
        Dim r As New List(Of String)
        Dim lowList As New SortedDictionary(Of String, String)
        For Each n As String In varNames
            lowList.Add(n.ToLower, n)
        Next
        Dim s1 As String = tLine.Trim.ToLower
        Dim s1s As String = ""
        For Each c As Char In s1
            Dim b1 As Integer = Asc(c)
            Select Case b1
                Case 48 To 57 ' 0-9
                    s1s &= c
                Case 65 To 90 ' A-Z
                    s1s &= c
                Case 97 To 122 ' a-z
                    s1s &= c
                Case 95
                    s1s &= c
                Case Else
                    s1s &= " "
            End Select
        Next
        s1s = s1s.Trim.Replace("  ", " ")
        Dim v1() As String = Split(s1s, " ")
        For Each n1 As String In v1
            If lowList.ContainsKey(n1) Then
                Dim n2 As String = lowList(n1)
                If r.Contains(n2) = False Then
                    r.Add(n2)
                End If
            End If
        Next
        Return r.ToArray
    End Function

    Private Sub PhaseEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PhaseEditorToolStripMenuItem.Click
        Dim frm As New PhaseEditor
        If frm.ShowDialog = DialogResult.OK Then

        End If
    End Sub

#End Region

End Class
