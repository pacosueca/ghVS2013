Public Class frmEjemplar

    Public NuevoEjemplar As New Ejemplar

    Dim miFormato As New Formato
    Dim dt As New DataTable

    Private Sub frmEjemplar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt = miFormato.ObtenerFormato
        CargaCombo(cmbFormato, dt)
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        NuevoEjemplar.Crear(cmbFormato.SelectedValue)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class