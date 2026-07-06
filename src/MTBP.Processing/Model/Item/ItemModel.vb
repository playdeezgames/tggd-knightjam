Imports MTBP.Persistence

Friend Class ItemModel
    Implements IItemModel

    Private Sub New(item As IItem)
        Me.Item = item
    End Sub

    Public ReadOnly Property Text As String Implements IItemModel.Text
        Get
            Return Item.GetName()
        End Get
    End Property

    Friend ReadOnly Item As IItem

    Public ReadOnly Property Verbs As IEnumerable(Of IVerbModel) Implements IItemModel.Verbs
        Get
            Return Item.Verbs.Select(AddressOf VerbModel.Create)
        End Get
    End Property

    Public ReadOnly Property Exists As Boolean Implements IItemModel.Exists
        Get
            Return Item.Exists
        End Get
    End Property

    Public Sub Drop() Implements IItemModel.Drop
        Dim world = Item.World
        world.ClearMessages()
        Dim character = world.Avatar
        Item.Inventory = character.Location.Inventory
        character.AddMessage($"{character.GetName} drops {Item.GetName}.")
    End Sub

    Public Sub Place(featureModel As IFeatureModel) Implements IItemModel.Place
        Dim feature = featureModel.GetFeature()
        Dim world = Item.World
        world.ClearMessages()
        Dim character = world.Avatar
        character.AddMessage($"{character.GetName()} places {Item.GetName()} on {feature.GetName()}.")
        Item.Inventory = feature.Inventory
        character.HandlePlaceItem(feature, Item)
    End Sub

    Public Sub Take() Implements IItemModel.Take
        Dim world = Item.World
        world.ClearMessages()
        Dim character = world.Avatar
        Item.Inventory = character.Inventory
        character.AddMessage($"{character.GetName} takes {Item.GetName}.")
    End Sub

    Friend Shared Function Create(item As IItem) As IItemModel
        Return New ItemModel(item)
    End Function

    Public Sub Describe() Implements IItemModel.Describe
        Dim world = Item.World
        Dim character = world.Avatar
        world.ClearMessages()
        character.AddMessage($"{character.GetName} examines {Item.GetName}:")
        character.AddMessage(Item.GetDescription)
    End Sub
End Class
