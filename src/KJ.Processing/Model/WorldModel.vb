Imports KJ.Persistence
Imports TGGD.Persistence
Imports TGGD.Processing

Public Class WorldModel
    Inherits BaseModel(Of IWorld)
    Implements IWorldModel

    Private Sub New(entity As IWorld, isQuittable As Boolean)
        MyBase.New(entity)
        Me.IsQuittable = isQuittable
    End Sub

    Public ReadOnly Property IsQuittable As Boolean Implements IWorldModel.IsQuittable

    Public Sub Embark() Implements IWorldModel.Embark
        Abandon()
        Entity.Initialize(InitializationContext.Create())
    End Sub

    Public Sub Abandon() Implements IWorldModel.Abandon
        Entity.Clear()
    End Sub

    Public Shared Async Function Create(quittable As Boolean, persister As IPersister) As Task(Of IWorldModel)
        Dim entity As IWorld
        Try
            entity = Await KJ.Persistence.World.Load(SAVE_FILENAME, persister)
        Catch ex As Exception
            entity = KJ.Persistence.World.Create(New Provision.WorldData, persister)
        End Try
        Return New WorldModel(entity, quittable)
    End Function
End Class
