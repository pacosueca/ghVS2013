Imports System
Imports System.Data.SqlClient

Public Class frmClientes

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim validacion As String = ""
        For Each c As Control In Me.GroupBox2.Controls
            If TypeOf (c) Is TextBox Then
                If c.Tag <> "" Then
                    If c.Text = "" Then
                        validacion = validacion & c.Tag & vbCrLf
                    End If
                End If
            End If
        Next
        If validacion <> "" Then
            MessageBox.Show("Los valores de :" & vbCrLf & vbCrLf & validacion & vbCrLf & "no pueden estar vacíos", "Alta clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim miCliente As New Cliente
            miCliente.Crear(txtNombre.Text, txtApellido1.Text, txtApellido2.Text, txtDNI.Text, txtDireccion.Text, txtPoblacion.Text, txtCP.Text, txtProvincia.Text, txtEmail.Text, txtTelefono.Text, dtpFecNac.Value, dtpFechaAlta.Value)
            For Each c As Control In Me.GroupBox2.Controls
                If TypeOf (c) Is TextBox Then
                    c.Text = ""
                End If
            Next
            Me.Close()
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmClientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim resp As DialogResult = MsgBox("¿Realmente quieres salir?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir")

        If resp = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        End If
    End Sub


    Private Sub frmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
