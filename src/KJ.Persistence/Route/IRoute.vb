Public Delegate Sub RouteInitializer(route As IRoute)
Public Interface IRoute
    Inherits IKJEntity
    ReadOnly Property RouteId As Guid
    ReadOnly Property Direction As String
    ReadOnly Property Destination As ILocation
End Interface
