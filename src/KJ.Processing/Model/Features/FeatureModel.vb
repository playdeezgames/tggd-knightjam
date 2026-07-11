Imports KJ.Persistence

Friend Class FeatureModel
    Implements IFeatureModel

    Private ReadOnly feature As IFeature

    Private Sub New(feature As IFeature)
        Me.feature = feature
    End Sub

    Public ReadOnly Property Name As String Implements IFeatureModel.Name
        Get
            Return feature.GetName()
        End Get
    End Property

    Public Sub Examine() Implements IFeatureModel.Examine
        Dim world = feature.World
        world.ClearMessages()
        Dim character = world.Avatar
        character.AddMessage($"{character.GetName} interacts with {feature.GetName}.")
        character.AddMessage(feature.GetFlavor())
    End Sub

    Friend Shared Function Create(feature As IFeature) As IFeatureModel
        Return New FeatureModel(feature)
    End Function
End Class
