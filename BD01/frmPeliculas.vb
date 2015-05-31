Imports System.Data.SqlClient

Public Class frmPeliculas

    Dim miUsuario As Integer
    Dim Modificando As Boolean

    Dim miEjemplar As New Ejemplar

    Private Sub frmPeliculas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub


    Private Sub CargaGeneros()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim conexion As New SqlConnection(MiConexion.Cadena)
        conexion.Open()
        cmd.CommandText = "select * from genero"
        cmd.Connection = conexion
        da.SelectCommand = cmd
        da.Fill(dt)
        da.Dispose()
        cmd.Dispose()
        cmbGenero.DataSource = dt

        cmbGenero.DisplayMember = dt.Columns(1).ColumnName.ToString
        cmbGenero.ValueMember = dt.Columns(0).ColumnName.ToString

    End Sub

    Private Sub CargaTipos()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim conexion As New SqlConnection(MiConexion.Cadena)
        conexion.Open()
        cmd.CommandText = "select idtipo,nombre from tipo"
        cmd.Connection = conexion
        da.SelectCommand = cmd
        da.Fill(dt)

        cmbTipo.DataSource = dt

        cmbTipo.DisplayMember = dt.Columns(1).ColumnName.ToString
        cmbTipo.ValueMember = dt.Columns(0).ColumnName.ToString

    End Sub

    Public Sub New(id As Integer, modificar As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        miUsuario = id
        Modificando = modificar
        CargaGeneros()
        CargaTipos()
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        'Si no tenemos ejemplar creamos solo la pelicula
        'sino hay que crear pelicula con ejemplar (transaccion)
        'Nuevo comentario prueba git
        If Not Modificando Then
            Dim miPelicula As New Pelicula
            If miEjemplar.Formato = 0 Then 'si no se ha seleccionado crear un ejemplar creamos solo la pelicula
                miPelicula.Crear(txtTitulo.Text, cmbGenero.SelectedValue, cmbTipo.SelectedValue, txtActores.Text, txtResumen.Text)
                Me.Close()
            Else
                Dim Insertada As Boolean
                miPelicula.CrearConEjemplar(txtTitulo.Text, cmbGenero.SelectedValue, cmbTipo.SelectedValue, txtActores.Text, txtResumen.Text, miEjemplar.Formato, Insertada)
                If Not Insertada Then
                    MessageBox.Show("Ha ocurrido un error al crear la película." & vbCrLf & "No se ha creado la película", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Close()
            End If
        Else
            MessageBox.Show("Modificando pelicula...")
        End If
        
    End Sub

    Private Sub cmdAddEjemplar_Click(sender As Object, e As EventArgs) Handles cmdAddEjemplar.Click
        If Me.txtTitulo.Text <> "" Then
            If miEjemplar.Formato = 0 Then
                Dim f As New frmEjemplar
                f.txtTitulo.Text = Me.txtTitulo.Text
                If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                    miEjemplar = f.NuevoEjemplar
                End If
            Else
                MessageBox.Show("Ya se ha creado un ejemplar de esta pelicula. Imposible crear otro ahora mismo", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Indica el título de la película para generar un ejemplar", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub
End Class