Imports System.Runtime.CompilerServices
Imports KJ.Persistence

Friend Module WorldExtensions
    <Extension>
    Friend Sub EnterCombat(world As IWorld)
        world.SetTag(Tags.IN_COMBAT)
        Dim character = world.Avatar
        Dim enemies = character.Location.GetOtherCharacters(character)
    End Sub
    <Extension>
    Friend Function IsInCombat(world As IWorld) As Boolean
        Return world.HasTag(Tags.IN_COMBAT)
    End Function
    <Extension>
    Friend Sub CheckCombatFinished(world As IWorld)
        Dim character = world.Avatar
        If character.IsDead() OrElse character.Location.GetOtherCharacters(character).All(Function(x) x.IsDead) Then
            world.ClearTag(Tags.IN_COMBAT)
        End If
    End Sub
End Module
