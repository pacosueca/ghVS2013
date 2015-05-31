Public Class Formato

    'Dim cadena As String = "Server=usuario\sqlexpress;Database=videoclub;Trusted_Connection=True;"

    Public Sub New()

    End Sub

    Public Sub Crear(nombre As String)
        Dim sql As String
        Dim conexion As New SqlClient.SqlConnection
        conexion.ConnectionString = MiConexion.Cadena
        conexion.Open()
        Dim cmd As New SqlClient.SqlCommand
        cmd.Connection = conexion
        sql = "insert into tipo formato('" & nombre & "')"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Public Function ObtenerFormato() As Data.DataTable
        'Dim sql As String
        Dim conexion As New SqlClient.SqlConnection
        conexion.ConnectionString = MiConexion.Cadena
        conexion.Open()
        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = "select * from formato"
        cmd.Connection = conexion

        Dim dt As New Data.DataTable
        Dim da As New SqlClient.SqlDataAdapter
        da.SelectCommand = cmd
        da.Fill(dt)
        ObtenerFormato = dt
    End Function

    Public Sub Modificar(idFormato As Integer, nombre As String)
        Dim sql As String
        Dim conexion As New SqlClient.SqlConnection
        conexion.ConnectionString = MiConexion.Cadena
        conexion.Open()
        Dim cmd As New SqlClient.SqlCommand
        cmd.Connection = conexion
        sql = "update formato set nombre='" & nombre & "' where idformato=" & idformato
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Public ReadOnly Property Nombre As String
        Get
            Nombre = ""
        End Get
    End Property
End Class
