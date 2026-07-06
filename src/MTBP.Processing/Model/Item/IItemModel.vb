Public Interface IItemModel
    ReadOnly Property Text As String
    Sub Drop()
    Sub Place(featureModel As IFeatureModel)
    Sub Take()
    Sub Describe()
    ReadOnly Property Verbs As IEnumerable(Of IVerbModel)
    ReadOnly Property Exists As Boolean
End Interface
