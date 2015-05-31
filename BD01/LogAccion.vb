Public Class LogAccion

    'Dim cadena As String = "Server=usuario\sqlexpress;Database=videoclub;Trusted_Connection=True;"
    'Dim cadena As String = "Server=usuario\sqlexpress;Database=videoclub;Trusted_Connection=True;"

    Public Sub Inserta(idusuario As Integer, accion As String)
        Dim sql As String
        Dim conexion As New SqlClient.SqlConnection
        conexion.ConnectionString = MiConexion.Cadena
        conexion.Open()
        Dim cmd As New SqlClient.SqlCommand
        cmd.Connection = conexion
        sql = "insert into logaccion values('" & accion & "'," & idusuario & ",'" & DateTime.UtcNow & "')"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

End Class
