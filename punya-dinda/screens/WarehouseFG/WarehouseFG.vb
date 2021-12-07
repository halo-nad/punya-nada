Public Class WH_FG
    Dim repository As Repository = Repository.getInstance()
    Dim logistic = LogisticControllers.getInstance()
    Dim marketingCont = MarketingController.getInstance()
    Dim pendingInvoices As New List(Of MarketingInvoiceHead)
    Dim products As New List(Of PpicProductPresentation)
    Dim selectedInvoice As MarketingInvoiceHead
    Dim selectedCust As CustomerModel
    Dim prodCont = ProductionController.getInstance()
    Private Sub WH_FG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        canWeAccessThis(New List(Of String)({"admin", "fg"}), Me)
        Dim productStock = logistic.getProductStock()
        For Each product In productStock
            ListView1.Items.Add(New ListViewItem(New String() {product.id, product.name, product.quantity}))
        Next
        pendingInvoices = marketingCont.getCompletedInvoices()
        ComboBox1.Items.Clear()
        For Each workOrder In pendingInvoices
            ComboBox1.Items.Add(workOrder.invoice_code)
        Next
    End Sub

    Private Sub MetroComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        selectedInvoice = repository.getSingleData(Of MarketingInvoiceHead)($"SELECT * FROM {TABLE_MARKETING_HEAD} WHERE invoice_code='{ComboBox1.SelectedItem.ToString()}'")
        selectedCust = repository.getSingleData(Of CustomerModel)($"SELECT * FROM {TABLE_CUSTOMER} WHERE id={selectedInvoice.customer_id}")
        TextBox8.Text = selectedCust.name
        products = prodCont.getProductsInvoice(selectedInvoice.invoice_code)
        ListView2.Items.Clear()
        For Each product In products
            ListView2.Items.Add(New ListViewItem(New String() {product.id, product.productName, product.quantity}))
        Next
    End Sub
    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim head As New LogisticHead(TextBox11.Text, TextBox10.Text, selectedCust.id, selectedInvoice.id)
        head.saveData()
        For Each product In products
            Dim entry As New LogisticItemModel(head.id, product.id)
            entry.saveData()
            Dim logisticStock As New LogisticStockModel("", product.quantity, DIRECTION_OUT, False)
            logisticStock.saveData(product.id)
        Next
        selectedInvoice.updateCompleted(TextBox11.Text)
    End Sub
End Class