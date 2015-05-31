Imports System.Data.SqlClient

Public Class frmMostrarPeliculas

    Dim miUsuario As Integer

    Dim misPeliculas As New Pelicula

    Private Sub frmMostrarPeliculas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'grdPeliculas.DataSource = misPeliculas.ListarTodas
        'grdPeliculas.Refresh()

        bsTitulo.DataSource = misPeliculas.ListarTodas

        grdPeliculas.DataSource = bsTitulo.DataSource
        FormateaGrid()
    End Sub

    Private Sub FormateaGrid()
        With grdPeliculas
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .Columns("idpelicula").Visible = False
            .Columns("idformato").Visible = False
            .Columns("idgenero").Visible = False
            .Columns("idtipo").Visible = False
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim f As New frmPeliculas(miUsuario, False)
        f.MdiParent = Me.MdiParent
        f.Show()
    End Sub

    Public Sub New(idusuario As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        miUsuario = idusuario
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click

    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        bsTitulo.Filter = "titulo like '%" & txtFiltro.Text & "%'"
        grdPeliculas.DataSource = bsTitulo.DataSource
    End Sub

    Private Sub ToolStripTextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        
    End Sub

    Private Sub grdPeliculas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPeliculas.CellDoubleClick
        Dim f As New frmPeliculas(miUsuario, True)
        f.txtTitulo.Text = grdPeliculas.Rows(e.RowIndex).Cells("titulo").Value
        f.cmbGenero.SelectedValue = grdPeliculas.Rows(e.RowIndex).Cells("idgenero").Value
        f.cmbTipo.SelectedValue = grdPeliculas.Rows(e.RowIndex).Cells("idtipo").Value
        f.MdiParent = Me.MdiParent
        f.Show()

    End Sub

    Private Sub grdPeliculas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPeliculas.CellContentClick

    End Sub
End Class