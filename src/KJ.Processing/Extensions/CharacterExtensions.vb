Imports System.Runtime.CompilerServices
Imports KJ.Persistence
Imports TGGD.Processing

Friend Module CharacterExtensions
    <Extension>
    Private Function IsAvatar(character As ICharacter) As Boolean
        Return If(character.World.Avatar?.CharacterId = character.CharacterId, False)
    End Function
    <Extension>
    Friend Function IsRat(character As ICharacter) As Boolean
        Return character.HasTag(Tags.RAT)
    End Function
    <Extension>
    Friend Sub SetRat(character As ICharacter)
        character.SetTag(Tags.RAT)
    End Sub
    <Extension>
    Friend Sub AddMessage(
                          character As ICharacter,
                          text As String,
                          Optional hints As IDictionary(Of String, String) = Nothing)
        If character.IsAvatar() Then
            character.World.AddMessage(text, hints)
        End If
    End Sub
    <Extension>
    Friend Sub Look(character As ICharacter)
        Dim location = character.Location
        character.AddMessage($"{character.GetName()} is in {location.GetName()}!")
        character.AddMessage(location.GetFlavor())
        ShowOtherCharacters(character)
        ShowExits(character)
        ShowFeatures(character)
        If location.Inventory.HasItems Then
            character.AddMessage("There are items on the ground.")
        End If
    End Sub

    <Extension>
    Friend Sub ShowOtherCharacters(character As ICharacter)
        Dim others = character.Location.GetOtherCharacters(character)
        If others.Any Then
            character.AddMessage("Characters:")
            For Each other In others
                character.AddMessage($"- {other.GetName}")
            Next
        End If
    End Sub

    <Extension>
    Friend Sub ShowFeatures(character As ICharacter)
        Dim features = character.Location.Features
        If features.Any Then
            character.AddMessage($"Features:")
            For Each feature In features
                character.AddMessage($"- {feature.GetName}")
            Next
        End If
    End Sub

    <Extension>
    Friend Sub ShowExits(character As ICharacter)
        Dim routes = character.Location.Routes
        If routes.Any() Then
            character.AddMessage($"Exits:")
            For Each route In routes
                character.AddMessage($"- {route.Direction}({route.GetName})")
            Next
        End If
    End Sub
    <Extension>
    Friend Sub Attack(attacker As ICharacter, defender As ICharacter)
        Dim world = attacker.World
        world.AddMessage($"{attacker.GetName} attacks {defender.GetName}!")
        Dim attackRoll = attacker.RollAttack()
        world.AddMessage($"{attacker.GetName} rolls an attack of {attackRoll}!")
        Dim defendRoll = defender.RollDefend()
        world.AddMessage($"{defender.GetName} rolls a defend of {defendRoll}!")
        Dim damage = Math.Max(0, attackRoll - defendRoll)
        If damage > 0 Then
            world.AddMessage($"{defender.GetName} takes {damage} damage!")
            defender.TakeDamage(damage)
            If defender.IsDead Then
                world.AddMessage($"{attacker.GetName} kills {defender.GetName}!")
                world.CheckCombatFinished()
            Else
                world.AddMessage($"{defender.GetName} has {defender.GetHealth()}/{defender.GetMaximumHealth()} health left.")
            End If
        Else
            world.AddMessage($"{attacker.GetName} misses!")
        End If
    End Sub
    <Extension>
    Friend Function IsDead(character As ICharacter) As Boolean
        Return character.IsCounterMinimum(Counters.HEALTH)
    End Function
    <Extension>
    Friend Function RollAttack(character As ICharacter) As Integer
        Return RNG.RollDice(character.GetMetadata(Metadatas.ATTACK_ROLL))
    End Function
    <Extension>
    Friend Function RollDefend(character As ICharacter) As Integer
        Return RNG.RollDice(character.GetMetadata(Metadatas.DEFEND_ROLL))
    End Function
    <Extension>
    Friend Sub TakeDamage(character As ICharacter, damage As Integer)
        character.ChangeCounter(Counters.HEALTH, -damage)
    End Sub
    <Extension>
    Friend Function GetHealth(character As ICharacter) As Integer
        Return character.GetCounter(Counters.HEALTH)
    End Function
    <Extension>
    Friend Function GetMaximumHealth(character As ICharacter) As Integer
        Return character.GetCounterMaximum(Counters.HEALTH)
    End Function
End Module
