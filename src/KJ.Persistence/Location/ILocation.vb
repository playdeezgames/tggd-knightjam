Public Delegate Sub LocationInitializer(location As ILocation)
Public Interface ILocation
    Inherits IKJEntity
    ReadOnly Property LocationId As Guid
End Interface
