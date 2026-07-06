Imports MTBP.Persistence

Friend Module RectoryInitializer
    Friend Function Initialize(context As IInitializationContext) As LocationInitializer
        Return Sub(location)
                   location.SetName("Rectory")
                   location.SetDescription("A rectory is the place where a rector lives. A rector is a person who live in a rectory. The world sounds a lot like rectum. Which makes me giggle.")
                   location.CreateCharacter(InitializeRector(context))
                   location.Inventory.CreateItem(AddressOf InitializeNote)
                   context.Rectory = location
               End Sub
    End Function

    Private Sub InitializeNote(item As IItem)
        item.SetName("Note from Developer")
        item.SetDescription("OHAI! The developer here. You can thank IHeartFunnyBoys for the inclusion of this note in the game. It is true that how to play this game successfully is inobvious, which is sort of my thing. It's a metaphor. But as this game is going to be actually played on stream, and we mustn't confuse or bore the streamer. That is paramount! Here's how to play: you are collecting things, rings specifically, to place them into alcoves in the church. When finished, ring the bell. The rings are in the graveyard, as are clues to how to place the rings. The graveyard is toxic, per the jam's theme. Without immunity from the toxicity, you will eventually perish. There is a way to charge your immunity at the church. Similarly, you will eventually starve to death if you don't find a source of food. There is such a source in the abandoned house. Also, I seriously recommend using one of the worksheets found on the game's itch page, as you will find it helpful.")
    End Sub

    Private Function InitializeRector(context As IInitializationContext) As CharacterInitializer
        Return Sub(character)
                   character.SetName("Ölën Kÿrpä")
                   character.SetDescription("This is you.")
                   character.World.Avatar = character
                   character.SetCounter(Counters.IMMUNITY, MINIMUM_IMMUNITY)
                   character.SetCounterMaximum(Counters.IMMUNITY, MAXIMUM_IMMUNITY)
                   character.SetCounterMinimum(Counters.IMMUNITY, MINIMUM_IMMUNITY)
                   character.SetCounter(Counters.HEALTH, MAXIMUM_HEALTH)
                   character.SetCounterMaximum(Counters.HEALTH, MAXIMUM_HEALTH)
                   character.SetCounterMinimum(Counters.HEALTH, MINIMUM_HEALTH)
                   character.SetCounter(Counters.HUNGER_RATE, 1)
                   character.SetCounter(Counters.SATIETY, MAXIMUM_SATIETY)
                   character.SetCounterMaximum(Counters.SATIETY, MAXIMUM_SATIETY)
                   character.SetCounterMinimum(Counters.SATIETY, MINIMUM_SATIETY)
                   character.SetCounter(Counters.NAUSEA, MINIMUM_NAUSEA)
                   character.SetCounterMaximum(Counters.NAUSEA, MAXIMUM_NAUSEA)
                   character.SetCounterMinimum(Counters.NAUSEA, MINIMUM_NAUSEA)
                   If context.IsDebug Then
                       character.Inventory.CreateItem(AddressOf InitializeDeezNuts)
                   End If
               End Sub
    End Function

    Private Sub InitializeDeezNuts(item As IItem)
        item.SetName("Deeznuts")
        item.SetDescription("These are nuts. Which nuts are they? Deez. Hold them gently.")
        item.SetTag(Tags.RING)
        item.SetRingType(RingTypes.AMBER)
    End Sub
End Module
