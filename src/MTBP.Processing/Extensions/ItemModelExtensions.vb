Imports System.Runtime.CompilerServices
Imports MTBP.Persistence

Friend Module ItemModelExtensions
    <Extension>
    Friend Function GetItem(itemModel As IItemModel) As IItem
        Return CType(itemModel, ItemModel).Item
    End Function
End Module
