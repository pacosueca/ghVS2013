Imports System
Imports System.Data.SqlClient

Public Class frmMostrarGeneros

    Dim miUsuario As Integer

    Private Sub frmMostrarGeneros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim misGeneros As New Genero
        'Dim miDr As SqlDataReader
        'miDr = misGeneros.Obtener
        'While miDr.Read
        '    lstGeneros.Items.Add(UCase(miDr.Item("nombre")))
        'End While

        Dim miDT As New Data.DataTable

        Dim misgeneros As New Genero
        miDT = misgeneros.ObtenerDT()
        lstGeneros.DataSource = miDT
        lstGeneros.ValueMember = miDT.Columns("idgenero").ColumnName.ToString
        lstGeneros.DisplayMember = UCase(miDT.Columns("nombre").ColumnName.ToString)

    End Sub

    Private Sub lstGeneros_DoubleClick(sender As Object, e As EventArgs) Handles lstGeneros.DoubleClick
        Dim f As New frmGenero(miUsuario, True)
        f.MdiParent = Me.MdiParent
        f.txtGenero.Text = lstGeneros.Text
        f.txtIdGenero.Text = Me.lstGeneros.SelectedValue
        f.Show()
    End Sub

    Private Sub lstGeneros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstGeneros.SelectedIndexChanged

    End Sub

    Public Sub New(idusuario As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        miUsuario = idusuario
    End Sub
End Class