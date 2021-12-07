Public Class Form1
    Dim repository As Repository = Repository.getInstance()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Marketing.Show()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = repository.name
        Label2.Text = repository.role
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Customer.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        products01.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ProduksiMainForm.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Purchasing.Show()
    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs)
        ProduksiFG.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        QCForm.Show()
    End Sub



    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        WH_FG.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        WarehouseRM.Show()
    End Sub
End Class
