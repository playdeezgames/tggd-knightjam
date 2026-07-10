Imports KJ.Persistence

Friend Class GroundModel
    Implements IGroundModel

    Private ReadOnly world As IWorld

    Private Sub New(world As IWorld)
        Me.world = world
    End Sub

    Public ReadOnly Property HasItems As Boolean Implements IGroundModel.HasItems
        Get
            Return world.Avatar.Location.Inventory.HasItems
        End Get
    End Property

    Friend Shared Function Create(entity As IWorld) As IGroundModel
        Return New GroundModel(entity)
    End Function
End Class
