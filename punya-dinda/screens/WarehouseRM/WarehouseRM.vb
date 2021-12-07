Public Class WarehouseRM
    Dim repository As Repository = Repository.getInstance()
    Dim logistic = LogisticControllers.getInstance()

    Private Sub WarehouseRM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        canWeAccessThis(New List(Of String)({"rm", "admin"}), Me)
        Dim rawStock = logistic.getRawStock()
        For Each raw In rawStock
            ListView2.Items.Add(New ListViewItem(New String() {raw.id, raw.name, raw.quantity}))
        Next
    End Sub
End Class