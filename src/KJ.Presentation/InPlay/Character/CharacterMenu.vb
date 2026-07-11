
Imports KJ.Processing
Imports TGGD.Presentation

Friend Class CharacterMenu
    Inherits KJPickerMenu

    Private ReadOnly characterModel As ICharacterModel

    Public Sub New(context As IDisplayContext, model As IWorldModel, previous As DialogSource, characterModel As ICharacterModel)
        MyBase.New(context, model, previous)
        Me.characterModel = characterModel
    End Sub

    Public Overrides ReadOnly Property PromptText As String
        Get
            Return $"Do what with {characterModel.Name}?"
        End Get
    End Property

    Protected Overrides ReadOnly Property Launchers As IEnumerable(Of LaunchDelegate)
        Get
            Return Enumerable.Empty(Of LaunchDelegate).
                Append(AddressOf ChooseNeverMind)
        End Get
    End Property

    Friend Shared Function Launch(c As IDisplayContext, m As IWorldModel, p As DialogSource, characterModel As ICharacterModel) As DialogSource
        Return Function()
                   characterModel.Examine()
                   Return New CharacterMenu(c, m, p, characterModel)
               End Function
    End Function

    Private Function ChooseNeverMind(context As IDisplayContext, model As IWorldModel, previous As DialogSource) As IDialogChoice
        Return DialogChoice.CreateEnabled("Never Mind", CharactersMenu.Launch(context, model, previous))
    End Function
End Class
