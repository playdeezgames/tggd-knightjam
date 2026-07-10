Imports KJ.Persistence

Friend Class ItemModel
    Implements IItemModel

    Private ReadOnly item As IItem

    Private Sub New(item As IItem)
        Me.item = item
    End Sub

    Public ReadOnly Property Name As String Implements IItemModel.Name
        Get
            Return item.GetName()
        End Get
    End Property

    Public Sub Take() Implements IItemModel.Take
        Dim world = item.World
        Dim character = world.Avatar
        world.ClearMessages()
        character.AddMessage($"{character.GetName} takes {item.GetName}.")
        character.AddMessage(item.GetFlavor)
        item.Inventory = character.Inventory
    End Sub

    Public Sub Drop() Implements IItemModel.Drop
        Dim world = item.World
        Dim character = world.Avatar
        world.ClearMessages()
        character.AddMessage($"{character.GetName} drops {item.GetName}.")
        item.Inventory = character.Location.Inventory
    End Sub

    Friend Shared Function Create(item As IItem) As IItemModel
        Return New ItemModel(item)
    End Function
End Class
