Imports System.Runtime.CompilerServices
Imports KJ.Persistence

Friend Module CharacterVerbExtensions
    Private Delegate Function CanPerformHandler(verb As IVerb, character As ICharacter) As Boolean
    Private Delegate Sub PerformHandler(verb As IVerb, character As ICharacter)

    Private ReadOnly canPerformTable As New Dictionary(Of String, CanPerformHandler) From
        {
            {VerbTypes.CELLAR_QUEST, AddressOf CanAcceptCellarQuest}
        }

    Private Function CanAcceptCellarQuest(verb As IVerb, character As ICharacter) As Boolean
        Return Not verb.World.Avatar.HasTag(Tags.QUEST_RATS)
    End Function

    <Extension>
    Friend Function CanPerform(verb As IVerb, character As ICharacter) As Boolean
        Dim handler As CanPerformHandler = Nothing
        If canPerformTable.TryGetValue(verb.VerbType, handler) Then
            Return handler.Invoke(verb, character)
        End If
        Return True
    End Function

    Private ReadOnly performTable As New Dictionary(Of String, PerformHandler) From
        {
            {VerbTypes.CELLAR_QUEST, AddressOf AcceptCellarQuest},
            {VerbTypes.FIGHT, AddressOf HandleFight}
        }

    Private Sub HandleFight(verb As IVerb, character As ICharacter)
        character.SetTag(Tags.ENEMY)
    End Sub

    Private Sub AcceptCellarQuest(verb As IVerb, character As ICharacter)
        Dim avatar = verb.World.Avatar
        avatar.SetTag(Tags.QUEST_RATS)
        avatar.AddMessage($"{avatar.GetName} accepts the job.")
    End Sub

    <Extension>
    Sub Perform(verb As IVerb, character As ICharacter)
        Dim handler As PerformHandler = Nothing
        verb.World.Avatar.AddMessage(verb.GetFlavor())
        If performTable.TryGetValue(verb.VerbType, handler) Then
            handler.Invoke(verb, character)
            Return
        End If
    End Sub
End Module
