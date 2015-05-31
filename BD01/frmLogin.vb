Public Class frmLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim miUsuario As New Usuario
        If IsNumeric(txtUsuario.Text) Then
            If miUsuario.ValidarUsuario(txtUsuario.Text, txtPass.Text) = True Then
                Me.DialogResult = DialogResult.OK
            Else
                MessageBox.Show("Usario no válido", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtUsuario.Text = ""
                lblUsuario.Text = ""
                txtPass.Text = ""
                txtUsuario.Focus()
                'Me.Close()
            End If
        Else
            MessageBox.Show("El usuario ha de ser numérico", "VideoClub", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        
        Me.Close()
    End Sub

    Private Sub txtUsuario_LostFocus(sender As Object, e As EventArgs) Handles txtUsuario.LostFocus
        If txtUsuario.Text <> "" Then
            Dim usuario As New Usuario
            lblUsuario.Text = usuario.Nombre(txtUsuario.Text)
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
