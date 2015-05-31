Public Class frmTipo

    Dim miUsuario As Integer

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click

        Dim miTipo As New Tipo
        miTipo.Crear(txtTipo.Text, txtPrecio.Text)
        Dim miLog As New LogAccion
        miLog.Inserta(miUsuario, "ALTA TIPO " & txtTipo.Text & "-" & txtPrecio.Text)
    End Sub

    Private Sub frmTipo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If txtTipo.Text <> "" Or txtPrecio.Text <> "" Then
            Dim resp As DialogResult = MessageBox.Show("¿Realmente quieres salir?", "Nuevo Tipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If resp = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmTipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(id As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        miUsuario = id
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub
End Class