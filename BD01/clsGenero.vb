Imports System
Imports System.Data.SqlClient

Public Class clsGenero

    'Dim cadena As String = "Server=usuario\sqlexpress;Database=videoclub;Trusted_Connection=True;"

    Public Sub New()

    End Sub


    Public Sub Crear(nombre As String)
        Dim conexion As New SqlClient.SqlConnection
        conexion.ConnectionString = MiConexion.Cadena
        conexion.Open()
        Dim cmd As New SqlClient.SqlCommand
        cmd.Connection = conexion
        cmd.CommandText = "insert into genero values('" & nombre & "')"
        cmd.ExecuteNonQuery()
    End Sub


    Public Sub Modificar(idgenero As Integer, nombre As String)
        Dim conexion As New SqlClient.SqlConnection
        conexion.ConnectionString = MiConexion.Cadena
        conexion.Open()
        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = "update genero set nombre ='" & nombre & "' where idgenero=" & idgenero
        cmd.Connection = conexion
        cmd.ExecuteNonQuery()
    End Sub

    Public Function Obtener() As SqlDataReader
        Dim conexion As New SqlClient.SqlConnection
        conexion.ConnectionString = MiConexion.Cadena
        conexion.Open()
        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = "select * from genero"
        cmd.Connection = conexion
        Obtener = cmd.ExecuteReader
    End Function

    Public ReadOnly Property Nombre As String
        Get
            Nombre = ObtenerMiNombre()
        End Get
    End Property

    Private Function ObtenerMiNombre() As String
        ObtenerMiNombre = ""
    End Function

End Class
