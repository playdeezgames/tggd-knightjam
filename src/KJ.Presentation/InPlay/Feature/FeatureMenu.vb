
Imports KJ.Processing
Imports TGGD.Presentation

Friend Class FeatureMenu
    Inherits KJPickerMenu

    Private ReadOnly featureModel As IFeatureModel

    Private Sub New(context As IDisplayContext, model As IWorldModel, previous As DialogSource, featureModel As IFeatureModel)
        MyBase.New(context, model, previous)
        Me.featureModel = featureModel
    End Sub

    Public Overrides ReadOnly Property PromptText As String
        Get
            Return $"Do what with {featureModel.Name}?"
        End Get
    End Property

    Protected Overrides ReadOnly Property Launchers As IEnumerable(Of LaunchDelegate)
        Get
            Return Enumerable.Empty(Of LaunchDelegate).
                Append(AddressOf ChooseNeverMind)
        End Get
    End Property

    Friend Shared Function Launch(c As IDisplayContext, m As IWorldModel, p As DialogSource, featureModel As IFeatureModel) As DialogSource
        Return Function()
                   featureModel.Examine()
                   Return New FeatureMenu(c, m, p, featureModel)
               End Function
    End Function

    Private Function ChooseNeverMind(context As IDisplayContext, model As IWorldModel, previous As DialogSource) As IDialogChoice
        Return DialogChoice.CreateEnabled("Never Mind", FeaturesMenu.Launch(context, model, previous))
    End Function
End Class
