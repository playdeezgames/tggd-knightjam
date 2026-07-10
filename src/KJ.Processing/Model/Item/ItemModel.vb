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

    Friend Shared Function Create(item As IItem) As IItemModel
        Return New ItemModel(item)
    End Function
End Class
