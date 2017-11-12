
Imports ClassLibWoWDatabaseManager
Imports ClassLibWoWCreatureItem

Public Class FormMain
    Private _databaseManager As WoWDatabaseManager
    Private _defaultDatabaseItem As WoWDatabaseItem
    Private _creatureManager As WoWCreatureManager

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _databaseManager = New WoWDatabaseManager
        _creatureManager = New WoWCreatureManager
        _defaultDatabaseItem = _databaseManager.GetDefaultWoWDatabaseItem

    End Sub
End Class
