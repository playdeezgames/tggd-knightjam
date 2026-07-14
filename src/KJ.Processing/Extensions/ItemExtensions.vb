Imports System.Runtime.CompilerServices
Imports KJ.Persistence

Friend Module ItemExtensions
    <Extension>
    Friend Function IsRatTail(item As IItem) As Boolean
        Return item.ItemType = ItemTypes.RAT_TAIL
    End Function
End Module
