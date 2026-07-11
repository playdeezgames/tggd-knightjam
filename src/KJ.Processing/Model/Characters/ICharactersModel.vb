Public Interface ICharactersModel
    ReadOnly Property HasAny As Boolean
    ReadOnly Property Characters As IEnumerable(Of ICharacterModel)
End Interface
