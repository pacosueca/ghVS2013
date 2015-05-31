Public Class Usuario

    Public Sub New()

    End Sub

    Public Function Nombre(id As String) As String
        Dim dr As SqlClient.SqlDataReader
        Dim conexion As New SqlClient.SqlConnection
        conexion.ConnectionString = MiConexion.Cadena
        conexion.Open()
        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = "select nombre from usuarios where idusuario=" & (id)
        cmd.Connection = conexion
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                Nombre = dr.Item("nombre")
            End While
        Else
            Nombre = ""
        End If
        conexion.Close()
    End Function

    Public Function ValidarUsuario(idusuario As String, pass As String) As Boolean
        Dim dr As SqlClient.SqlDataReader
        Dim conexion As New SqlClient.SqlConnection
        conexion.ConnectionString = MiConexion.Cadena
        conexion.Open()
        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = "select nombre from usuarios where idusuario=" & idusuario & " and password='" & pass & "'"
        cmd.Connection = conexion
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            ValidarUsuario = True
        Else
            ValidarUsuario = False
        End If
        conexion.Close()
    End Function

End Class
