
Imports KJ.Processing
Imports TGGD.Presentation

Friend Class AttackActivity
    Inherits KJPickerMenu

    Private ReadOnly characterModel As ICharacterModel

    Private Sub New(context As IDisplayContext, model As IWorldModel, previous As DialogSource, characterModel As ICharacterModel)
        MyBase.New(context, model, previous)
        Me.characterModel = characterModel
    End Sub

    Public Overrides ReadOnly Property PromptText As String
        Get
            Return String.Empty
        End Get
    End Property

    Protected Overrides ReadOnly Property Launchers As IEnumerable(Of LaunchDelegate)
        Get
            Return Enumerable.Empty(Of LaunchDelegate).
                Append(AddressOf ChooseOk)
        End Get
    End Property

    Friend Shared Function Launch(c As IDisplayContext, m As IWorldModel, p As DialogSource, characterModel As ICharacterModel) As DialogSource
        Return Function()
                   characterModel.Attack()
                   Return New AttackActivity(c, m, p, characterModel)
               End Function
    End Function

    Private Function ChooseOk(context As IDisplayContext, model As IWorldModel, previous As DialogSource) As IDialogChoice
        Return DialogChoice.CreateEnabled("Ok", InPlay.Launch(context, model, previous))
    End Function
End Class
