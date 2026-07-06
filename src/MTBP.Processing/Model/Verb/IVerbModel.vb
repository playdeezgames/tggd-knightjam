Public Interface IVerbModel
    ReadOnly Property Text As String
    Sub Perform(featureModel As IFeatureModel)
    Sub Perform(itemModel As IItemModel)
End Interface
