Imports System.Runtime.CompilerServices
Imports MTBP.Persistence
Imports TGGD.Processing
Friend Delegate Function CharacterFeatureItemHandler(character As ICharacter, feature As IFeature, item As IItem) As Boolean
Friend Delegate Function CharacterFeatureVerbHandler(character As ICharacter, feature As IFeature, verb As IVerb) As Boolean
Friend Delegate Function CharacterItemVerbHandler(character As ICharacter, item As IItem, verb As IVerb) As Boolean
Friend Module CharacterExtensions
    <Extension>
    Friend Function IsAvatar(character As ICharacter) As Boolean
        Return character IsNot Nothing AndAlso
            character.World.Avatar IsNot Nothing AndAlso
            character.CharacterId = character.World.Avatar.CharacterId
    End Function
    <Extension>
    Friend Sub AddMessage(character As ICharacter, message As String)
        If character.IsAvatar Then
            character.World.AddMessage(message)
        End If
    End Sub
    <Extension>
    Friend Function IsDead(character As ICharacter) As Boolean
        Return character.GetHealth() = character.GetCounterMinimum(Counters.HEALTH)
    End Function
    <Extension>
    Friend Sub HandleToxicity(character As ICharacter)
        Dim toxicity = character.Location.GetToxicity()
        If toxicity <= 0 Then
            Return
        End If
        character.AddMessage($"{character.GetName} reacts to {toxicity} toxicity.")
        Dim immunity = Math.Min(toxicity, character.GetImmunity())
        If immunity > 0 Then
            character.AddMessage($"{character.GetName} loses {immunity} immunity.")
            character.ChangeCounter(Counters.IMMUNITY, -immunity)
            character.AddMessage($"{character.GetName} now has {character.GetImmunity()}/{character.GetMaximumImmunity()} immunity.")
        End If
        toxicity -= immunity
        If toxicity > 0 Then
            character.AddMessage($"{character.GetName} loses {toxicity} health.")
            character.ChangeCounter(Counters.HEALTH, -toxicity)
            character.AddMessage($"{character.GetName} now has {character.GetHealth()}/{character.GetMaximumHealth()} health.")
        End If
    End Sub
    <Extension>
    Friend Sub HandleHunger(character As ICharacter)
        Dim hunger = If(character.TryGetCounter(Counters.HUNGER_RATE), 0)
        If hunger = 0 Then
            Return
        End If
        character.AddMessage($"{character.GetName} experiences {hunger} hunger!")
        Dim satiety = Math.Min(hunger, character.GetSatiety())
        If satiety > 0 Then
            character.AddMessage($"{character.GetName} loses {satiety} satiety!")
            character.ChangeCounter(Counters.SATIETY, -satiety)
            character.AddMessage($"{character.GetName} now has {character.GetSatiety()}/{character.GetMaximumSatiety()} satiety.")
        End If
        hunger -= satiety
        If hunger > 0 Then
            character.AddMessage($"{character.GetName} loses {hunger} health!")
            character.ChangeCounter(Counters.HEALTH, -hunger)
            character.AddMessage($"{character.GetName} now has {character.GetHealth()}/{character.GetMaximumHealth()} health.")
        End If
    End Sub
    <Extension>
    Friend Sub ShowStatus(character As ICharacter)
        character.AddMessage($"{character.GetName}'s Status:")
        character.AddMessage($"Health: {character.GetHealth}/{character.GetMaximumHealth}")
        character.AddMessage($"Satiety: {character.GetSatiety}/{character.GetMaximumSatiety}")
        character.AddMessage($"Immunity: {character.GetImmunity}/{character.GetMaximumImmunity}")
        If character.HasNausea() Then
            character.AddMessage($"Nausea: {character.GetNausea}/{character.GetMaximumNausea}")
        End If
    End Sub
    <Extension>
    Sub Look(character As ICharacter)
        If character.IsDead() Then
            character.AddMessage($"{character.GetName} is dead.")
            Return
        End If
        Dim location = character.Location
        character.AddMessage($"{character.GetName} is in {location.GetName}.")
        character.AddMessage($"Local Toxicity Level: {location.GetToxicity()}")
        Dim features = location.Features
        If features.Any Then
            character.AddMessage("Features:")
            For Each feature As IFeature In features
                character.AddMessage($"- {feature.GetName}")
            Next
        End If
        Dim routes = location.Routes
        If routes.Any Then
            character.AddMessage("Exits:")
            For Each route In routes
                character.AddMessage($"- {route.Key}: {route.Value.GetName}")
            Next
        End If
        If location.Inventory.HasItems Then
            character.AddMessage("There are items on the ground.")
        End If
    End Sub
    <Extension>
    Friend Sub Describe(character As ICharacter, feature As IFeature)
        character.AddMessage($"Inspecting {feature.GetName}:")
        character.AddMessage(feature.GetDescription())
        Dim items = feature.Inventory.Items
        If items.Any Then
            character.AddMessage("Items:")
            For Each item In items
                character.AddMessage($"- {item.GetName}")
            Next
        End If
    End Sub

    Private ReadOnly placeItemHandlers As IEnumerable(Of CharacterFeatureItemHandler) =
        {
            AddressOf PlaceRingInAlcove
        }

    Private Function PlaceRingInAlcove(character As ICharacter, feature As IFeature, item As IItem) As Boolean
        If Not feature.IsAlcove() OrElse Not item.IsRing() Then
            Return False
        End If
        If feature.GetRingType() <> item.GetRingType() Then
            character.AddMessage($"{character.GetName} has placed the wrong ring in the wrong alcove. As a result, the god {character.World.GetGodName()} has liquified his innards, and they squirt endlessly out of his butthole until he is dead. Yes, the spray is so heavy that some of it gets into {character.GetName}'s mouth prior to his demise.")
            character.Kill()
            Return True
        End If
        Return False
    End Function

    <Extension>
    Friend Sub HandlePlaceItem(character As ICharacter, feature As IFeature, item As IItem)
        For Each handler In placeItemHandlers
            If handler.Invoke(character, feature, item) Then
                Return
            End If
        Next
        character.AddMessage($"Nothing special happens!")
    End Sub
    <Extension>
    Friend Sub Kill(character As ICharacter)
        character.SetCounter(Counters.HEALTH, character.GetCounterMinimum(Counters.HEALTH))
    End Sub

    Private ReadOnly featureVerbHandlers As IEnumerable(Of CharacterFeatureVerbHandler) =
        {
            AddressOf PullRope,
            AddressOf HangSelf,
            AddressOf PrayAtAltar
        }

    Private Function PrayAtAltar(character As ICharacter, feature As IFeature, verb As IVerb) As Boolean
        If Not verb.GetVerbType() = VerbTypes.PRAY Then
            Return False
        End If
        character.AddMessage($"{character.GetName} prays sincerely to the invisible sky-man.")
        character.AddMessage($"While {character.GetName} is praying, a saunaklonkku shoves an iodine pill up his arse.")
        character.AddMessage($"As a result, {character.GetName}'s immunity is refilled.")
        character.SetImmunity(character.GetMaximumImmunity())
        character.AddMessage($"{character.GetName}'s immunity is now {character.GetImmunity}/{character.GetMaximumImmunity}.")
        character.AddMessage($"Also, {character.GetName}'s butthole hurts a little, but in a good way.")
        Return True
    End Function

    Private Function PullRope(character As ICharacter, feature As IFeature, verb As IVerb) As Boolean
        If Not verb.GetVerbType() = VerbTypes.PULL_ROPE Then
            Return False
        End If
        character.AddMessage($"{character.GetName} pulls the rope, and the bell chimes.")
        Dim world = character.World
        If Not world.IsWinner() AndAlso world.CheckWinCondition() Then
            character.Win()
        End If
        Return True
    End Function

    Private Function HangSelf(character As ICharacter, feature As IFeature, verb As IVerb) As Boolean
        If Not verb.GetVerbType() = VerbTypes.HANG_SELF Then
            Return False
        End If
        character.AddMessage($"{character.GetName} wraps the rope a number of times around his neck, and jumps off of the altar. Instead of cleanly breaking his neck, he asphyxiates himself over the next several minutes, as the bell chimes.")
        character.Kill()
        Return True
    End Function

    <Extension>
    Friend Sub PerformFeatureVerb(character As ICharacter, feature As IFeature, verb As IVerb)
        For Each handler In featureVerbHandlers
            If handler.Invoke(character, feature, verb) Then
                Return
            End If
        Next
        character.AddMessage($"Nothing happens!")
    End Sub

    <Extension>
    Friend Sub Win(character As ICharacter)
        character.World.SetWinner()
        character.AddMessage($"{character.GetName} wins, and receives a certificate of completion!")
        character.Inventory.CreateItem(AddressOf InitializeCertificate)
    End Sub

    Private Sub InitializeCertificate(item As IItem)
        item.SetName("Certificate of Completion")
        item.SetDescription("The bearer of this certificate has completed `Toxic City of SPLORR!!` successfully. Signed, TheGrumpyGameDev. Thanks for engaging with the metaphor!")
    End Sub
    Private ReadOnly itemVerbHandlers As IEnumerable(Of CharacterItemVerbHandler) =
        {
            AddressOf HandleReachIn,
            AddressOf HandleEatDick,
            AddressOf HandleQuaffPotion
        }
    Private Function HandleQuaffPotion(character As ICharacter, item As IItem, verb As IVerb) As Boolean
        If verb.GetVerbType() <> VerbTypes.QUAFF_POTION Then
            Return False
        End If
        character.AddMessage($"{character.GetName} quaffs {item.GetName}.")
        character.AddMessage($"No, it's not chocolate flavored, but at this point, are you surprised?")
        character.HealFully()
        character.AddMessage($"{character.GetName}'s health is fully restored!")
        character.HalveNauseaCapacity()
        character.AddMessage($"{character.GetName} resistance to nausea is halved!")
        item.Destroy()
        Return True
    End Function

    <Extension>
    Private Sub HealFully(character As ICharacter)
        character.SetCounter(Counters.HEALTH, character.GetMaximumHealth())
    End Sub

    <Extension>
    Private Sub HalveNauseaCapacity(character As ICharacter)
        character.SetCounterMaximum(Counters.NAUSEA, Grimoire.MAXIMUM_NAUSEA \ 2)
    End Sub

    Private Function HandleEatDick(character As ICharacter, item As IItem, verb As IVerb) As Boolean
        If verb.GetVerbType() <> VerbTypes.EAT_DICK Then
            Return False
        End If
        If character.GetSatiety() > Grimoire.MAXIMUM_SATIETY \ 2 Then
            character.AddMessage($"{character.GetName} is not hungry enough to eat {item.GetName}.")
            Return True
        End If
        character.AddMessage($"{character.GetName} eats {item.GetName}.")
        character.SetSatiety(character.GetMaximumSatiety())
        character.AddMessage($"{character.GetName} has {character.GetSatiety}/{character.GetMaximumSatiety} satiety.")
        item.Destroy()
        character.IncreaseNausea()
        Return True
    End Function

    <Extension>
    Private Sub IncreaseNausea(character As ICharacter)
        Dim nausea = RNG.RollDice(Grimoire.NAUSEA_INCREASE_DICE)
        character.AddMessage($"{character.GetName}'s nausea goes up by {nausea}.")
        character.ChangeCounter(Counters.NAUSEA, nausea)
        If character.GetNausea() < character.GetMaximumNausea() Then
            character.AddMessage($"{character.GetName} is able to hold it down, for now.")
        Else
            character.AddMessage($"{character.GetName} vomits violently, leaving a puddle of hairy, salty, foul-smelling penis chunks.")
            Dim location = character.Location
            character.ChangeCounter(Counters.NAUSEA, -RNG.RollDice(Grimoire.NAUSEA_DECREASE_DICE))
            location.IncreaseToxicity()
            location.CreateFeature(AddressOf InitializeVomit)
            character.AddMessage($"{character.GetName()} feels better after the event, but has increased the toxicity of the area to {location.GetToxicity()}.")
        End If
        character.AddMessage($"Nausea: {character.GetNausea}/{character.GetMaximumNausea}.")
    End Sub

    Private Sub InitializeVomit(feature As IFeature)
        feature.SetName("puddle of vomit")
        feature.SetDescription("This is a puddle of vomit. Specifically, it is a puddle of your vomit. It consists of partially digested, salty, unwashed penis chunks.")
    End Sub

    Private Function HandleReachIn(character As ICharacter, item As IItem, verb As IVerb) As Boolean
        If verb.GetVerbType() <> VerbTypes.REACH_IN Then
            Return False
        End If
        character.AddMessage($"{character.GetName} reaches in to the {item.GetName}.")
        Dim generatedItem = character.Inventory.CreateItem(AddressOf InitializeSaltyUnwashedDick)
        character.AddMessage($"{character.GetName} finds {generatedItem.GetName} within.")
        Return True
    End Function

    Private Sub InitializeSaltyUnwashedDick(item As IItem)
        item.SetName("Salty, Unwashed Dick")
        item.SetDescription("This dick is both salty and unwashed. It smells exactly as you expect, and was obviously stored with its `brethren` for a... very... long... time. Did I mention that is it also extremely hairy?")
        item.CreateVerb(AddressOf InitializeEatDick)
    End Sub

    Private Sub InitializeEatDick(verb As IVerb)
        verb.SetName("Eat")
        verb.SetDescription("It makes you nauseous even to think about it. But as there is literally no other food source in this metaphor, I don't think you have a choice.")
        verb.SetVerbType(VerbTypes.EAT_DICK)
    End Sub

    <Extension>
    Friend Sub PerformItemVerb(character As ICharacter, item As IItem, verb As IVerb)
        For Each handler In itemVerbHandlers
            If handler.Invoke(character, item, verb) Then
                Return
            End If
        Next
        character.AddMessage($"Nothing happens!")
    End Sub
End Module
