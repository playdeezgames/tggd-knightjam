Imports KJ.Processing
Imports TGGD.Presentation

Public Class Title
    Inherits StackedModelDialog(Of IDisplayContext, IWorldModel)
    Implements IDialog

    Private Sub New(context As IDisplayContext, model As IWorldModel, exitDialog As DialogSource)
        MyBase.New(context, model, exitDialog)
    End Sub

    Public Overrides Function Run() As IDialogPrompt
        Context.Render("Yermom's Tits of SPLORR!!", New Dictionary(Of String, String) From {{HintNames.ELEMENT_TYPE, ElementTypes.TITLE}})
        Context.Render("A Production of TheGrumpyGameDev")
        Context.Render("Sponsored by: UMLAUT.FYI!", New Dictionary(Of String, String) From {{HintNames.ELEMENT_TYPE, ElementTypes.LINK}, {HintNames.URL, "https://umlaut.fyi/"}})
        Return DialogPrompt.CreateChoicePrompt(
            "",
            DialogChoice.Create(True, "OK", MainMenu.Launch(Context, Model, PreviousDialog)))
    End Function

    Public Shared Function Launch(context As IDisplayContext, model As IWorldModel, exitDialog As DialogSource) As DialogSource
        Return Function() New Title(context, model, exitDialog)
    End Function

End Class
