Imports System.Runtime.CompilerServices
Imports KJ.Persistence

Friend Module FeatureVerbExtensions
    Private Delegate Function CanPerformHandler(verb As IVerb, feature As IFeature) As Boolean
    Private Delegate Sub PerformHandler(verb As IVerb, feature As IFeature)

    Private ReadOnly canPerformTable As New Dictionary(Of String, CanPerformHandler) From
        {
        }

    <Extension>
    Friend Function CanPerform(verb As IVerb, feature As IFeature) As Boolean
        Dim handler As CanPerformHandler = Nothing
        If canPerformTable.TryGetValue(verb.VerbType, handler) Then
            Return handler.Invoke(verb, feature)
        End If
        Return True
    End Function

    Private ReadOnly performTable As New Dictionary(Of String, PerformHandler) From
        {
        }

    Private Sub CheckButthole(verb As IVerb, feature As IFeature)
        Dim character = verb.World.Avatar
        character.AddMessage(verb.GetFlavor())
    End Sub

    <Extension>
    Sub Perform(verb As IVerb, feature As IFeature)
        Dim handler As PerformHandler = Nothing
        verb.World.Avatar.AddMessage(verb.GetFlavor())
        If performTable.TryGetValue(verb.VerbType, handler) Then
            handler.Invoke(verb, feature)
            Return
        End If
    End Sub
End Module
