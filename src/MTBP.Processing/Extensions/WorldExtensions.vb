Imports System.Runtime.CompilerServices
Imports MTBP.Persistence

Friend Module WorldExtensions
    <Extension>
    Friend Function GetGodName(world As IWorld) As String
        Return world.GetMetadata(Metadatas.GOD_NAME)
    End Function
    <Extension>
    Friend Sub SetGodName(world As IWorld, godName As String)
        world.SetMetadata(Metadatas.GOD_NAME, godName)
    End Sub
    <Extension>
    Friend Function IsWinner(world As IWorld) As Boolean
        Return world.HasTag(Tags.WIN)
    End Function
    <Extension>
    Friend Sub SetWinner(world As IWorld)
        world.SetTag(Tags.WIN)
    End Sub
    <Extension>
    Friend Function CheckWinCondition(world As IWorld) As Boolean
        Return world.Features.Where(AddressOf IsAlcove).All(AddressOf HasCorrectRing)
    End Function

    Private Function HasCorrectRing(feature As IFeature) As Boolean
        Return feature.Inventory.Items.Any(IsCorrectRing(feature))
    End Function

    Private Function IsCorrectRing(feature As IFeature) As Func(Of IItem, Boolean)
        Return Function(item) item.HasTag(Tags.RING) AndAlso item.GetRingType() = feature.GetRingType()
    End Function
End Module
