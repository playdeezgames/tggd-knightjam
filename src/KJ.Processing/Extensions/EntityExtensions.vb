Imports System.Runtime.CompilerServices
Imports KJ.Persistence

Friend Module EntityExtensions
    <Extension>
    Friend Sub SetName(entity As IKJEntity, name As String)
        entity.SetMetadata(Metadatas.NAME, name)
    End Sub
    <Extension>
    Friend Sub SetFlavor(entity As IKJEntity, description As String)
        entity.SetMetadata(Metadatas.FLAVOR, description)
    End Sub
    <Extension>
    Friend Function GetName(entity As IKJEntity) As String
        Return entity.GetMetadata(Metadatas.NAME)
    End Function
    <Extension>
    Friend Function GetFlavor(entity As IKJEntity) As String
        Return entity.GetMetadata(Metadatas.FLAVOR)
    End Function
End Module
