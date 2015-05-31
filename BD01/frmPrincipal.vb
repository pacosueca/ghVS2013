Public Class frmPrincipal

    Dim miUsuario As Integer

    Dim ContClientes As Integer = 0
    Dim ContPeliculas As Integer = 0
    Dim ContFormato As Integer = 0
    Dim ContGenero As Integer = 0
    Dim ContTipo As Integer = 0

    Public Sub New(id As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        miUsuario = id

    End Sub



    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoClienteToolStripMenuItem.Click
        Dim f As New frmClientes
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub VerLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerLogToolStripMenuItem.Click
        Dim f As New frmClientes
        f.Show()
    End Sub

    Private Sub NuevoToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        Dim f As New frmClientes
        f.MdiParent = Me
        ContClientes = ContClientes + 1
        f.Text = "Nuevo Cliente " & ContClientes
        f.Show()
    End Sub


    Private Sub MosaicoHorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MosaicoHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub MosaicoVerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MosaicoVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub CascadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CascadaToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub frmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim resp As DialogResult = MessageBox.Show("¿Realmente quieres salir?", "VideoClub", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If resp = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        Else
            Dim miLog As New LogAccion
            miLog.Inserta(miUsuario, "LOGOUT")
        End If
    End Sub

    Private Sub NuevoToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem2.Click
        Dim f As New frmFormato(miUsuario, False)
        f.MdiParent = Me
        f.Text = "Formato " & ContFormato
        f.Show()
    End Sub

    Private Sub NuevoToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem3.Click
        Dim f As New frmGenero(miUsuario, False)
        f.MdiParent = Me
        f.Text = "Genero " & ContGenero
        f.Show()
    End Sub

    Private Sub NuevoToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem4.Click
        Dim f As New frmTipo(miUsuario)
        f.MdiParent = Me
        f.Text = "Tipo " & ContTipo
        f.Show()
    End Sub

    Private Sub MostrarToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles MostrarToolStripMenuItem4.Click
        Dim f As New frmMostrarGeneros(miUsuario)
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub NuevoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem1.Click
        Dim f As New frmPeliculas(miUsuario, False)
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub MostrarToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles MostrarToolStripMenuItem3.Click
        Dim f As New frmMostrarFormatos(miUsuario)
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub MostrarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles MostrarToolStripMenuItem2.Click
        Dim f As New frmMostrarPeliculas(miUsuario)
        f.MdiParent = Me
        f.Show()
    End Sub
End Class
