Public Delegate Sub FeatureInitializer(feature As IFeature)
Public Interface IFeature
    Inherits IInventoriedEntity
    ReadOnly Property FeatureId As Guid
    ReadOnly Property Location As ILocation
    Function CreateVerb(verbType As String, Optional initializer As VerbInitializer = Nothing) As IVerb
End Interface
