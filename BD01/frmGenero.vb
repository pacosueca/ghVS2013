Public Class frmGenero

    Dim miUsuario As Integer
    Dim Modificando As Boolean

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        If txtGenero.Text <> "" Then
            If Not Modificando Then
                Dim MiGenero As New Genero()
                MiGenero.Crear(txtGenero.Text)
                Dim miLog As New LogAccion
                miLog.Inserta(miUsuario, "ALTA GENERO " & txtGenero.Text)
            Else
                Dim MiGenero As New Genero()
                MiGenero.Modificar(txtIdGenero.Text, txtGenero.Text)
                Dim miLog As New LogAccion
                miLog.Inserta(miUsuario, "MODIFICACION GENERO " & txtIdGenero.Text)
            End If
            txtGenero.Text = ""
            Me.Close()
        Else
            MessageBox.Show("Introduce un nombre para el género", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmGenero_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If txtGenero.Text <> "" Then
            Dim resp As DialogResult = MessageBox.Show("¿Realmente quieres salir?", "Nuevo Género", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If resp = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmGenero_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Public Sub New(id As Integer, modificacion As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        miUsuario = id
        Modificando = modificacion
    End Sub
End Class