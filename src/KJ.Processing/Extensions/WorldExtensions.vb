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
    Friend Function CheckCombatFinished(world As IWorld) As Boolean
        Dim character = world.Avatar
        Return character.IsDead() OrElse character.Location.GetOtherCharacters(character).All(Function(x) x.IsDead)
    End Function
End Module
