
Imports KJ.Processing
Imports TGGD.Presentation

Friend Class CharactersMenu
    Inherits KJPickerMenu

    Private Sub New(context As IDisplayContext, model As IWorldModel, previous As DialogSource)
        MyBase.New(context, model, previous)
    End Sub

    Public Overrides ReadOnly Property PromptText As String
        Get
            Return "Which Character?"
        End Get
    End Property

    Protected Overrides ReadOnly Property Launchers As IEnumerable(Of LaunchDelegate)
        Get
            Return Enumerable.Empty(Of LaunchDelegate).
                Append(AddressOf ChooseNeverMind)
        End Get
    End Property

    Friend Shared Function Launch(context As IDisplayContext, model As IWorldModel, previous As DialogSource) As DialogSource
        Return Function() New CharactersMenu(context, model, previous)
    End Function

    Private Function ChooseNeverMind(context As IDisplayContext, model As IWorldModel, previous As DialogSource) As IDialogChoice
        Return DialogChoice.CreateEnabled("Never Mind", InPlay.Launch(context, model, previous))
    End Function
End Class
