Imports System.Runtime.CompilerServices
Imports MTBP.Persistence

Friend Module EntityExtensions
    <Extension>
    Friend Sub SetName(entity As IMTBPEntity, name As String)
        entity.SetMetadata(Metadatas.NAME, name)
    End Sub
    <Extension>
    Friend Function GetName(entity As IMTBPEntity) As String
        Return entity.GetMetadata(Metadatas.NAME)
    End Function
    <Extension>
    Friend Function GetToxicity(entity As IMTBPEntity) As Integer
        Return If(entity.TryGetCounter(Counters.TOXICITY), 0)
    End Function
    <Extension>
    Friend Function GetHealth(entity As IMTBPEntity) As Integer
        Return If(entity.TryGetCounter(Counters.HEALTH), 0)
    End Function
    <Extension>
    Friend Function GetMaximumHealth(entity As IMTBPEntity) As Integer
        Return entity.GetCounterMaximum(Counters.HEALTH)
    End Function
    <Extension>
    Friend Function GetImmunity(entity As IMTBPEntity) As Integer
        Return If(entity.TryGetCounter(Counters.IMMUNITY), 0)
    End Function
    <Extension>
    Friend Sub SetImmunity(entity As IMTBPEntity, immunity As Integer)
        entity.SetCounter(Counters.IMMUNITY, immunity)
    End Sub
    <Extension>
    Friend Function GetMaximumImmunity(entity As IMTBPEntity) As Integer
        Return entity.GetCounterMaximum(Counters.IMMUNITY)
    End Function
    <Extension>
    Friend Function GetSatiety(entity As IMTBPEntity) As Integer
        Return entity.GetCounter(Counters.SATIETY)
    End Function
    <Extension>
    Friend Function GetMaximumSatiety(entity As IMTBPEntity) As Integer
        Return entity.GetCounterMaximum(Counters.SATIETY)
    End Function
    <Extension>
    Friend Sub SetSatiety(entity As IMTBPEntity, satiety As Integer)
        entity.SetCounter(Counters.SATIETY, satiety)
    End Sub
    <Extension>
    Friend Function GetDescription(entity As IMTBPEntity) As String
        Return entity.GetMetadata(Metadatas.DESCRIPTION)
    End Function
    <Extension>
    Friend Sub SetDescription(entity As IMTBPEntity, description As String)
        entity.SetMetadata(Metadatas.DESCRIPTION, description)
    End Sub
    <Extension>
    Friend Function GetRingType(entity As IMTBPEntity) As String
        Return entity.GetMetadata(Metadatas.RING_TYPE)
    End Function
    <Extension>
    Friend Sub SetRingType(entity As IMTBPEntity, ringType As String)
        entity.SetMetadata(Metadatas.RING_TYPE, ringType)
    End Sub
    <Extension>
    Friend Function HasNausea(entity As IMTBPEntity) As Boolean
        Return entity.GetCounter(Counters.NAUSEA) > entity.GetCounterMinimum(Counters.NAUSEA)
    End Function
    <Extension>
    Friend Function GetNausea(entity As IMTBPEntity) As Integer
        Return entity.GetCounter(Counters.NAUSEA)
    End Function
    <Extension>
    Friend Function GetMaximumNausea(entity As IMTBPEntity) As Integer
        Return entity.GetCounterMaximum(Counters.NAUSEA)
    End Function
    <Extension>
    Friend Sub IncreaseToxicity(entity As IMTBPEntity)
        entity.SetCounter(Counters.TOXICITY, entity.GetToxicity() + 1)
    End Sub
End Module
