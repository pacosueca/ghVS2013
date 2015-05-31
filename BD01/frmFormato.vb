Public Class frmFormato

    Dim miUsuario As Integer
    Dim Modificando As Boolean

    Private Sub frmFormato_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If txtFormato.Text <> "" Then
            Dim resp As DialogResult = MessageBox.Show("¿Realmente quieres salir?", "Nuevo Formato", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If resp = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmFormato_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(id As Integer, Modificar As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        miUsuario = id
        Modificar = Modificando
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        If txtFormato.Text <> "" Then
            Dim miFormato As New Formato
            If Not Me.Modificando Then
                miFormato.Modificar(txtIdFormato.Text, txtFormato.Text)
                Dim miLog As New LogAccion
                miLog.Inserta(miUsuario, "MODIFICACION FORMATO " & txtFormato.Text)
                txtFormato.Text = ""
            Else
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub
End Class