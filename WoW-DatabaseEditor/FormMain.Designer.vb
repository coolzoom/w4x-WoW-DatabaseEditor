<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WorkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreatureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GameObjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ListViewGameObject = New System.Windows.Forms.ListView()
        Me.ColumnHeaderGameObjectEntry = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGameObjectName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGameOvjectNameLocale = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGameObjectSubName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGameObjectData = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListViewItem = New System.Windows.Forms.ListView()
        Me.ColumnHeaderItemEntry = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderItemName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderItemSubName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListViewGossipMenuNpcText = New System.Windows.Forms.ListView()
        Me.ColumnHeaderGossipId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderNpcTextId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderNpcText = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderNpcBroadcastId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderNpcEmote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderNpcLocaleText = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListViewGossipMenuOption = New System.Windows.Forms.ListView()
        Me.ColumnHeaderGossipOptionId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGossipOptionIndex = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGossipOptionText = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGossipOptionLocaleText = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGossipOptionBroadcast = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGossipOptionIcon = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGossipOptionNpcFlag = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGossipOptionBoxMoney = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGossipOptionBoxText = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderGossipOptionLocaleBoxText = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListViewCreature = New System.Windows.Forms.ListView()
        Me.ColumnHeaderCreatureEntry = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderCreatureName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderCreatureNameLoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderCreatureSubName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderCreatureLevel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderCreatureGossip = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListViewQuest = New System.Windows.Forms.ListView()
        Me.ColumnHeaderQuestId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderQuestTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderQuestLitleLoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderQuestInvolvedObjects = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageQuest = New System.Windows.Forms.TabPage()
        Me.TextBoxSearchQuest = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPageCreature = New System.Windows.Forms.TabPage()
        Me.TextBoxSearchCreature = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPageGameObject = New System.Windows.Forms.TabPage()
        Me.TextBoxSearchGameObject = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPageItem = New System.Windows.Forms.TabPage()
        Me.TextBoxSearchItem = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPageGossip = New System.Windows.Forms.TabPage()
        Me.TextBoxSearchGossip = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageQuest.SuspendLayout()
        Me.TabPageCreature.SuspendLayout()
        Me.TabPageGameObject.SuspendLayout()
        Me.TabPageItem.SuspendLayout()
        Me.TabPageGossip.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.WorkToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1031, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesToolStripMenuItem, Me.SelectDatabaseToolStripMenuItem, Me.LocaleToolStripMenuItem, Me.ToolStripMenuItem1, Me.QuitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.PropertiesToolStripMenuItem.Text = "Properties"
        '
        'SelectDatabaseToolStripMenuItem
        '
        Me.SelectDatabaseToolStripMenuItem.Name = "SelectDatabaseToolStripMenuItem"
        Me.SelectDatabaseToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.SelectDatabaseToolStripMenuItem.Text = "Select current Database"
        '
        'LocaleToolStripMenuItem
        '
        Me.LocaleToolStripMenuItem.Name = "LocaleToolStripMenuItem"
        Me.LocaleToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.LocaleToolStripMenuItem.Text = "Locale"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(194, 6)
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(197, 22)
        Me.QuitToolStripMenuItem.Text = "Quit"
        '
        'WorkToolStripMenuItem
        '
        Me.WorkToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreatureToolStripMenuItem, Me.GameObjectToolStripMenuItem})
        Me.WorkToolStripMenuItem.Name = "WorkToolStripMenuItem"
        Me.WorkToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.WorkToolStripMenuItem.Text = "Work"
        '
        'CreatureToolStripMenuItem
        '
        Me.CreatureToolStripMenuItem.Name = "CreatureToolStripMenuItem"
        Me.CreatureToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.CreatureToolStripMenuItem.Text = "Creature"
        '
        'GameObjectToolStripMenuItem
        '
        Me.GameObjectToolStripMenuItem.Name = "GameObjectToolStripMenuItem"
        Me.GameObjectToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.GameObjectToolStripMenuItem.Text = "GameObject"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 416)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1031, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ListViewGameObject
        '
        Me.ListViewGameObject.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewGameObject.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderGameObjectEntry, Me.ColumnHeaderGameObjectName, Me.ColumnHeaderGameOvjectNameLocale, Me.ColumnHeaderGameObjectSubName, Me.ColumnHeaderGameObjectData})
        Me.ListViewGameObject.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewGameObject.FullRowSelect = True
        Me.ListViewGameObject.GridLines = True
        Me.ListViewGameObject.Location = New System.Drawing.Point(3, 33)
        Me.ListViewGameObject.MultiSelect = False
        Me.ListViewGameObject.Name = "ListViewGameObject"
        Me.ListViewGameObject.Size = New System.Drawing.Size(1017, 318)
        Me.ListViewGameObject.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.ListViewGameObject, "Hit's on table quest_template")
        Me.ListViewGameObject.UseCompatibleStateImageBehavior = False
        Me.ListViewGameObject.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderGameObjectEntry
        '
        Me.ColumnHeaderGameObjectEntry.Text = "Entry"
        '
        'ColumnHeaderGameObjectName
        '
        Me.ColumnHeaderGameObjectName.Text = "Name"
        Me.ColumnHeaderGameObjectName.Width = 250
        '
        'ColumnHeaderGameOvjectNameLocale
        '
        Me.ColumnHeaderGameOvjectNameLocale.Text = "Name Locale"
        Me.ColumnHeaderGameOvjectNameLocale.Width = 250
        '
        'ColumnHeaderGameObjectSubName
        '
        Me.ColumnHeaderGameObjectSubName.Text = "SubName"
        Me.ColumnHeaderGameObjectSubName.Width = 250
        '
        'ColumnHeaderGameObjectData
        '
        Me.ColumnHeaderGameObjectData.Text = "Data0, Data1, Data(n...)"
        Me.ColumnHeaderGameObjectData.Width = 250
        '
        'ListViewItem
        '
        Me.ListViewItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewItem.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderItemEntry, Me.ColumnHeaderItemName, Me.ColumnHeaderItemSubName})
        Me.ListViewItem.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewItem.FullRowSelect = True
        Me.ListViewItem.GridLines = True
        Me.ListViewItem.Location = New System.Drawing.Point(3, 33)
        Me.ListViewItem.MultiSelect = False
        Me.ListViewItem.Name = "ListViewItem"
        Me.ListViewItem.Size = New System.Drawing.Size(975, 318)
        Me.ListViewItem.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.ListViewItem, "Hit's on table quest_template")
        Me.ListViewItem.UseCompatibleStateImageBehavior = False
        Me.ListViewItem.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderItemEntry
        '
        Me.ColumnHeaderItemEntry.Text = "Entry"
        '
        'ColumnHeaderItemName
        '
        Me.ColumnHeaderItemName.Text = "Name"
        Me.ColumnHeaderItemName.Width = 250
        '
        'ColumnHeaderItemSubName
        '
        Me.ColumnHeaderItemSubName.Text = "SubName"
        Me.ColumnHeaderItemSubName.Width = 250
        '
        'ListViewGossipMenuNpcText
        '
        Me.ListViewGossipMenuNpcText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewGossipMenuNpcText.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderGossipId, Me.ColumnHeaderNpcTextId, Me.ColumnHeaderNpcText, Me.ColumnHeaderNpcBroadcastId, Me.ColumnHeaderNpcEmote, Me.ColumnHeaderNpcLocaleText})
        Me.ListViewGossipMenuNpcText.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewGossipMenuNpcText.FullRowSelect = True
        Me.ListViewGossipMenuNpcText.GridLines = True
        Me.ListViewGossipMenuNpcText.Location = New System.Drawing.Point(3, 33)
        Me.ListViewGossipMenuNpcText.MultiSelect = False
        Me.ListViewGossipMenuNpcText.Name = "ListViewGossipMenuNpcText"
        Me.ListViewGossipMenuNpcText.Size = New System.Drawing.Size(975, 135)
        Me.ListViewGossipMenuNpcText.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.ListViewGossipMenuNpcText, "Hit's on table quest_template")
        Me.ListViewGossipMenuNpcText.UseCompatibleStateImageBehavior = False
        Me.ListViewGossipMenuNpcText.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderGossipId
        '
        Me.ColumnHeaderGossipId.Text = "GossipID"
        Me.ColumnHeaderGossipId.Width = 80
        '
        'ColumnHeaderNpcTextId
        '
        Me.ColumnHeaderNpcTextId.Text = "NpcTextID"
        Me.ColumnHeaderNpcTextId.Width = 80
        '
        'ColumnHeaderNpcText
        '
        Me.ColumnHeaderNpcText.Text = "Npc Text"
        Me.ColumnHeaderNpcText.Width = 250
        '
        'ColumnHeaderNpcBroadcastId
        '
        Me.ColumnHeaderNpcBroadcastId.Text = "NpcBroadcastId"
        Me.ColumnHeaderNpcBroadcastId.Width = 100
        '
        'ColumnHeaderNpcEmote
        '
        Me.ColumnHeaderNpcEmote.Text = "EmoteID"
        '
        'ColumnHeaderNpcLocaleText
        '
        Me.ColumnHeaderNpcLocaleText.Text = "Locale Npc Text"
        Me.ColumnHeaderNpcLocaleText.Width = 250
        '
        'ListViewGossipMenuOption
        '
        Me.ListViewGossipMenuOption.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewGossipMenuOption.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderGossipOptionId, Me.ColumnHeaderGossipOptionIndex, Me.ColumnHeaderGossipOptionText, Me.ColumnHeaderGossipOptionLocaleText, Me.ColumnHeaderGossipOptionBroadcast, Me.ColumnHeaderGossipOptionIcon, Me.ColumnHeaderGossipOptionNpcFlag, Me.ColumnHeaderGossipOptionBoxMoney, Me.ColumnHeaderGossipOptionBoxText, Me.ColumnHeaderGossipOptionLocaleBoxText})
        Me.ListViewGossipMenuOption.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewGossipMenuOption.FullRowSelect = True
        Me.ListViewGossipMenuOption.GridLines = True
        Me.ListViewGossipMenuOption.Location = New System.Drawing.Point(3, 174)
        Me.ListViewGossipMenuOption.MultiSelect = False
        Me.ListViewGossipMenuOption.Name = "ListViewGossipMenuOption"
        Me.ListViewGossipMenuOption.Size = New System.Drawing.Size(975, 181)
        Me.ListViewGossipMenuOption.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.ListViewGossipMenuOption, "Hit's on table quest_template")
        Me.ListViewGossipMenuOption.UseCompatibleStateImageBehavior = False
        Me.ListViewGossipMenuOption.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderGossipOptionId
        '
        Me.ColumnHeaderGossipOptionId.Text = "GossipID"
        '
        'ColumnHeaderGossipOptionIndex
        '
        Me.ColumnHeaderGossipOptionIndex.Text = "Index"
        '
        'ColumnHeaderGossipOptionText
        '
        Me.ColumnHeaderGossipOptionText.Text = "Option-Text"
        Me.ColumnHeaderGossipOptionText.Width = 150
        '
        'ColumnHeaderGossipOptionLocaleText
        '
        Me.ColumnHeaderGossipOptionLocaleText.Text = "Locale Option-Text"
        Me.ColumnHeaderGossipOptionLocaleText.Width = 150
        '
        'ColumnHeaderGossipOptionBroadcast
        '
        Me.ColumnHeaderGossipOptionBroadcast.Text = "Broadcast"
        Me.ColumnHeaderGossipOptionBroadcast.Width = 80
        '
        'ColumnHeaderGossipOptionIcon
        '
        Me.ColumnHeaderGossipOptionIcon.Text = "Icon"
        '
        'ColumnHeaderGossipOptionNpcFlag
        '
        Me.ColumnHeaderGossipOptionNpcFlag.Text = "NpcFlag"
        '
        'ColumnHeaderGossipOptionBoxMoney
        '
        Me.ColumnHeaderGossipOptionBoxMoney.Text = "Box-Money"
        Me.ColumnHeaderGossipOptionBoxMoney.Width = 70
        '
        'ColumnHeaderGossipOptionBoxText
        '
        Me.ColumnHeaderGossipOptionBoxText.Text = "Box-Text"
        Me.ColumnHeaderGossipOptionBoxText.Width = 150
        '
        'ColumnHeaderGossipOptionLocaleBoxText
        '
        Me.ColumnHeaderGossipOptionLocaleBoxText.Text = "Locale Box-Text"
        Me.ColumnHeaderGossipOptionLocaleBoxText.Width = 150
        '
        'ListViewCreature
        '
        Me.ListViewCreature.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewCreature.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderCreatureEntry, Me.ColumnHeaderCreatureName, Me.ColumnHeaderCreatureNameLoc, Me.ColumnHeaderCreatureSubName, Me.ColumnHeaderCreatureLevel, Me.ColumnHeaderCreatureGossip})
        Me.ListViewCreature.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewCreature.FullRowSelect = True
        Me.ListViewCreature.GridLines = True
        Me.ListViewCreature.Location = New System.Drawing.Point(3, 33)
        Me.ListViewCreature.MultiSelect = False
        Me.ListViewCreature.Name = "ListViewCreature"
        Me.ListViewCreature.Size = New System.Drawing.Size(975, 318)
        Me.ListViewCreature.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.ListViewCreature, "Hit's on table quest_template")
        Me.ListViewCreature.UseCompatibleStateImageBehavior = False
        Me.ListViewCreature.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderCreatureEntry
        '
        Me.ColumnHeaderCreatureEntry.Text = "Entry"
        '
        'ColumnHeaderCreatureName
        '
        Me.ColumnHeaderCreatureName.Text = "Name"
        Me.ColumnHeaderCreatureName.Width = 250
        '
        'ColumnHeaderCreatureNameLoc
        '
        Me.ColumnHeaderCreatureNameLoc.Text = "Locale Name"
        Me.ColumnHeaderCreatureNameLoc.Width = 250
        '
        'ColumnHeaderCreatureSubName
        '
        Me.ColumnHeaderCreatureSubName.Text = "SubName"
        Me.ColumnHeaderCreatureSubName.Width = 250
        '
        'ColumnHeaderCreatureLevel
        '
        Me.ColumnHeaderCreatureLevel.Text = "Level"
        '
        'ColumnHeaderCreatureGossip
        '
        Me.ColumnHeaderCreatureGossip.Text = "Gossip"
        '
        'ListViewQuest
        '
        Me.ListViewQuest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListViewQuest.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderQuestId, Me.ColumnHeaderQuestTitle, Me.ColumnHeaderQuestLitleLoc, Me.ColumnHeaderQuestInvolvedObjects})
        Me.ListViewQuest.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewQuest.FullRowSelect = True
        Me.ListViewQuest.GridLines = True
        Me.ListViewQuest.Location = New System.Drawing.Point(3, 33)
        Me.ListViewQuest.MultiSelect = False
        Me.ListViewQuest.Name = "ListViewQuest"
        Me.ListViewQuest.Size = New System.Drawing.Size(970, 326)
        Me.ListViewQuest.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.ListViewQuest, "Hit's on table quest_template")
        Me.ListViewQuest.UseCompatibleStateImageBehavior = False
        Me.ListViewQuest.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderQuestId
        '
        Me.ColumnHeaderQuestId.Text = "QuestID"
        Me.ColumnHeaderQuestId.Width = 80
        '
        'ColumnHeaderQuestTitle
        '
        Me.ColumnHeaderQuestTitle.Text = "Title"
        Me.ColumnHeaderQuestTitle.Width = 250
        '
        'ColumnHeaderQuestLitleLoc
        '
        Me.ColumnHeaderQuestLitleLoc.Text = "Title Locale"
        Me.ColumnHeaderQuestLitleLoc.Width = 250
        '
        'ColumnHeaderQuestInvolvedObjects
        '
        Me.ColumnHeaderQuestInvolvedObjects.Text = "Involved Objects"
        Me.ColumnHeaderQuestInvolvedObjects.Width = 250
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageQuest)
        Me.TabControl1.Controls.Add(Me.TabPageCreature)
        Me.TabControl1.Controls.Add(Me.TabPageGameObject)
        Me.TabControl1.Controls.Add(Me.TabPageItem)
        Me.TabControl1.Controls.Add(Me.TabPageGossip)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1031, 392)
        Me.TabControl1.TabIndex = 2
        '
        'TabPageQuest
        '
        Me.TabPageQuest.Controls.Add(Me.TextBoxSearchQuest)
        Me.TabPageQuest.Controls.Add(Me.Label1)
        Me.TabPageQuest.Controls.Add(Me.ListViewQuest)
        Me.TabPageQuest.Location = New System.Drawing.Point(4, 22)
        Me.TabPageQuest.Name = "TabPageQuest"
        Me.TabPageQuest.Size = New System.Drawing.Size(1023, 366)
        Me.TabPageQuest.TabIndex = 2
        Me.TabPageQuest.Text = "Quest"
        Me.TabPageQuest.UseVisualStyleBackColor = True
        '
        'TextBoxSearchQuest
        '
        Me.TextBoxSearchQuest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSearchQuest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TextBoxSearchQuest.Location = New System.Drawing.Point(115, 7)
        Me.TextBoxSearchQuest.Name = "TextBoxSearchQuest"
        Me.TextBoxSearchQuest.Size = New System.Drawing.Size(853, 20)
        Me.TextBoxSearchQuest.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Quest search string "
        '
        'TabPageCreature
        '
        Me.TabPageCreature.Controls.Add(Me.TextBoxSearchCreature)
        Me.TabPageCreature.Controls.Add(Me.Label2)
        Me.TabPageCreature.Controls.Add(Me.ListViewCreature)
        Me.TabPageCreature.Location = New System.Drawing.Point(4, 22)
        Me.TabPageCreature.Name = "TabPageCreature"
        Me.TabPageCreature.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageCreature.Size = New System.Drawing.Size(1023, 366)
        Me.TabPageCreature.TabIndex = 0
        Me.TabPageCreature.Text = "Creature"
        Me.TabPageCreature.UseVisualStyleBackColor = True
        '
        'TextBoxSearchCreature
        '
        Me.TextBoxSearchCreature.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSearchCreature.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TextBoxSearchCreature.Location = New System.Drawing.Point(121, 7)
        Me.TextBoxSearchCreature.Name = "TextBoxSearchCreature"
        Me.TextBoxSearchCreature.Size = New System.Drawing.Size(852, 20)
        Me.TextBoxSearchCreature.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Creature search string "
        '
        'TabPageGameObject
        '
        Me.TabPageGameObject.Controls.Add(Me.TextBoxSearchGameObject)
        Me.TabPageGameObject.Controls.Add(Me.Label3)
        Me.TabPageGameObject.Controls.Add(Me.ListViewGameObject)
        Me.TabPageGameObject.Location = New System.Drawing.Point(4, 22)
        Me.TabPageGameObject.Name = "TabPageGameObject"
        Me.TabPageGameObject.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageGameObject.Size = New System.Drawing.Size(1023, 366)
        Me.TabPageGameObject.TabIndex = 1
        Me.TabPageGameObject.Text = "GameObject"
        Me.TabPageGameObject.UseVisualStyleBackColor = True
        '
        'TextBoxSearchGameObject
        '
        Me.TextBoxSearchGameObject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSearchGameObject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TextBoxSearchGameObject.Location = New System.Drawing.Point(146, 7)
        Me.TextBoxSearchGameObject.Name = "TextBoxSearchGameObject"
        Me.TextBoxSearchGameObject.Size = New System.Drawing.Size(869, 20)
        Me.TextBoxSearchGameObject.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "GameObject search string "
        '
        'TabPageItem
        '
        Me.TabPageItem.Controls.Add(Me.TextBoxSearchItem)
        Me.TabPageItem.Controls.Add(Me.Label4)
        Me.TabPageItem.Controls.Add(Me.ListViewItem)
        Me.TabPageItem.Location = New System.Drawing.Point(4, 22)
        Me.TabPageItem.Name = "TabPageItem"
        Me.TabPageItem.Size = New System.Drawing.Size(1023, 366)
        Me.TabPageItem.TabIndex = 3
        Me.TabPageItem.Text = "Item"
        Me.TabPageItem.UseVisualStyleBackColor = True
        '
        'TextBoxSearchItem
        '
        Me.TextBoxSearchItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSearchItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TextBoxSearchItem.Location = New System.Drawing.Point(107, 7)
        Me.TextBoxSearchItem.Name = "TextBoxSearchItem"
        Me.TextBoxSearchItem.Size = New System.Drawing.Size(866, 20)
        Me.TextBoxSearchItem.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Item search string "
        '
        'TabPageGossip
        '
        Me.TabPageGossip.Controls.Add(Me.ListViewGossipMenuOption)
        Me.TabPageGossip.Controls.Add(Me.TextBoxSearchGossip)
        Me.TabPageGossip.Controls.Add(Me.Label5)
        Me.TabPageGossip.Controls.Add(Me.ListViewGossipMenuNpcText)
        Me.TabPageGossip.Location = New System.Drawing.Point(4, 22)
        Me.TabPageGossip.Name = "TabPageGossip"
        Me.TabPageGossip.Size = New System.Drawing.Size(1023, 366)
        Me.TabPageGossip.TabIndex = 4
        Me.TabPageGossip.Text = "Gossip"
        Me.TabPageGossip.UseVisualStyleBackColor = True
        '
        'TextBoxSearchGossip
        '
        Me.TextBoxSearchGossip.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSearchGossip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TextBoxSearchGossip.Location = New System.Drawing.Point(114, 7)
        Me.TextBoxSearchGossip.Name = "TextBoxSearchGossip"
        Me.TextBoxSearchGossip.Size = New System.Drawing.Size(859, 20)
        Me.TextBoxSearchGossip.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Gosip search string "
        '
        'Timer1
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(953, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(78, 24)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "All donations are used to help fund the cost of running and improving arkania. ")
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1031, 438)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.Text = "WoW Database Editor  (c) 2018 GPN39F"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageQuest.ResumeLayout(False)
        Me.TabPageQuest.PerformLayout()
        Me.TabPageCreature.ResumeLayout(False)
        Me.TabPageCreature.PerformLayout()
        Me.TabPageGameObject.ResumeLayout(False)
        Me.TabPageGameObject.PerformLayout()
        Me.TabPageItem.ResumeLayout(False)
        Me.TabPageItem.PerformLayout()
        Me.TabPageGossip.ResumeLayout(False)
        Me.TabPageGossip.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PropertiesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents QuitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageQuest As TabPage
    Friend WithEvents TextBoxSearchQuest As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ListViewQuest As ListView
    Friend WithEvents ColumnHeaderQuestId As ColumnHeader
    Friend WithEvents ColumnHeaderQuestTitle As ColumnHeader
    Friend WithEvents ColumnHeaderQuestInvolvedObjects As ColumnHeader
    Friend WithEvents TabPageCreature As TabPage
    Friend WithEvents TextBoxSearchCreature As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ListViewCreature As ListView
    Friend WithEvents ColumnHeaderCreatureEntry As ColumnHeader
    Friend WithEvents ColumnHeaderCreatureName As ColumnHeader
    Friend WithEvents TabPageGameObject As TabPage
    Friend WithEvents TextBoxSearchGameObject As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ListViewGameObject As ListView
    Friend WithEvents ColumnHeaderGameObjectEntry As ColumnHeader
    Friend WithEvents ColumnHeaderGameObjectName As ColumnHeader
    Friend WithEvents TabPageItem As TabPage
    Friend WithEvents TextBoxSearchItem As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ListViewItem As ListView
    Friend WithEvents ColumnHeaderItemEntry As ColumnHeader
    Friend WithEvents ColumnHeaderItemName As ColumnHeader
    Friend WithEvents ColumnHeaderItemSubName As ColumnHeader
    Friend WithEvents TabPageGossip As TabPage
    Friend WithEvents ListViewGossipMenuOption As ListView
    Friend WithEvents ColumnHeaderGossipOptionId As ColumnHeader
    Friend WithEvents ColumnHeaderGossipOptionIndex As ColumnHeader
    Friend WithEvents ColumnHeaderGossipOptionText As ColumnHeader
    Friend WithEvents TextBoxSearchGossip As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ListViewGossipMenuNpcText As ListView
    Friend WithEvents ColumnHeaderGossipId As ColumnHeader
    Friend WithEvents ColumnHeaderNpcTextId As ColumnHeader
    Friend WithEvents ColumnHeaderNpcText As ColumnHeader
    Friend WithEvents LocaleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeaderNpcBroadcastId As ColumnHeader
    Friend WithEvents WorkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreatureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GameObjectToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeaderCreatureSubName As ColumnHeader
    Friend WithEvents ColumnHeaderGameObjectSubName As ColumnHeader
    Friend WithEvents ColumnHeaderNpcEmote As ColumnHeader
    Friend WithEvents ColumnHeaderGossipOptionIcon As ColumnHeader
    Friend WithEvents ColumnHeaderGossipOptionNpcFlag As ColumnHeader
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ColumnHeaderCreatureLevel As ColumnHeader
    Friend WithEvents ColumnHeaderCreatureGossip As ColumnHeader
    Friend WithEvents ColumnHeaderQuestLitleLoc As ColumnHeader
    Friend WithEvents ColumnHeaderGameObjectData As ColumnHeader
    Friend WithEvents ColumnHeaderGameOvjectNameLocale As ColumnHeader
    Friend WithEvents ColumnHeaderCreatureNameLoc As ColumnHeader
    Friend WithEvents SelectDatabaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnHeaderNpcLocaleText As ColumnHeader
    Friend WithEvents ColumnHeaderGossipOptionLocaleText As ColumnHeader
    Friend WithEvents ColumnHeaderGossipOptionBroadcast As ColumnHeader
    Friend WithEvents ColumnHeaderGossipOptionBoxMoney As ColumnHeader
    Friend WithEvents ColumnHeaderGossipOptionBoxText As ColumnHeader
    Friend WithEvents ColumnHeaderGossipOptionLocaleBoxText As ColumnHeader
    Friend WithEvents PictureBox1 As PictureBox
End Class
