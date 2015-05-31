Imports System
Imports System.Data.SqlClient

Public Class frmMostrarFormatos

    Dim miUsuario As Integer

    Public Sub New(idusuario As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        miUsuario = idusuario
    End Sub



    Private Sub frmMostrarFormatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim miDT As New Data.DataTable

        Dim miFormato As New Formato
        miDT = miFormato.ObtenerFormato

        CargaList(lstFormatos, miDT)

        lstFormatos.DataSource = miDT
        lstFormatos.ValueMember = miDT.Columns("idformato").ColumnName.ToString
        lstFormatos.DisplayMember = UCase(miDT.Columns("nombre").ColumnName.ToString)
    End Sub

    Private Sub lstFormatos_DoubleClick(sender As Object, e As EventArgs) Handles lstFormatos.DoubleClick
        Dim f As New frmFormato(miUsuario, True)
        f.MdiParent = Me.MdiParent
        f.txtIdFormato.Text = lstFormatos.Text
        f.txtFormato.Text = lstFormatos.SelectedValue
        f.Show()
    End Sub

    Private Sub lstFormatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFormatos.SelectedIndexChanged

    End Sub
End Class