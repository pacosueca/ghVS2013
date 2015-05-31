Module ModuloGeneral

    Public MiConexion As New Conexion

    Public Sub Main()
        Dim f As New frmLogin
        f.ShowDialog()
        If f.DialogResult = DialogResult.OK Then
            Dim miLog As New LogAccion
            miLog.Inserta(CInt(f.txtUsuario.Text), "LOGIN")
            Dim formulario As New frmPrincipal(CInt(f.txtUsuario.Text))
            f.Close()
            formulario.ShowDialog()
        End If
    End Sub

    Public Sub RellenaDataTable(ByRef dt As DataTable, sql As String)
        Try
            dt.Clear()
            Dim conexion As New SqlClient.SqlConnection
            conexion.ConnectionString = MiConexion.Cadena
            conexion.Close()
            Dim cmd As New SqlClient.SqlCommand
            cmd.Connection = conexion
            cmd.CommandText = sql
            Dim da As New SqlClient.SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(dt)
            cmd = Nothing
            da = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub CargaCombo(ByRef cmb As ComboBox, dt As DataTable)
        cmb.DataSource = dt
        cmb.DisplayMember = dt.Columns(1).ColumnName.ToString
        cmb.ValueMember = dt.Columns(0).ColumnName.ToString
    End Sub

    Public Sub CargaList(ByRef lst As ListBox, dt As DataTable)
        lst.DataSource = dt
        lst.DisplayMember = dt.Columns(1).ColumnName.ToString
        lst.ValueMember = dt.Columns(0).ColumnName.ToString
    End Sub

End Module
