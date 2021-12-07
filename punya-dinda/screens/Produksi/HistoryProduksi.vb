Public Class HistoryProduksi
    Dim repo As Repository = Repository.getInstance()
    Private Sub HistoryProduksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        repo.showData("SELECT history_produksi.work_order_id, work_order.work_code, history_produksi.date_now FROM produksi, work_order INNER JOIN history_produksi ON work_order.id = history_produksi.work_order_id;", DataGridView1)

    End Sub
End Class