Imports System.Runtime.CompilerServices
Imports KJ.Persistence

Friend Module EntityExtensions
    <Extension>
    Friend Sub SetName(entity As IKJEntity, name As String)
        entity.SetMetadata(Metadatas.NAME, name)
    End Sub
    <Extension>
    Friend Sub SetDescription(entity As IKJEntity, description As String)
        entity.SetMetadata(Metadatas.DESCRIPTION, description)
    End Sub
End Module
