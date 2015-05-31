Public Class Tipo


    'Dim cadena As String = "Server=usuario\sqlexpress;Database=videoclub;Trusted_Connection=True;"

    Public Sub New()

    End Sub

    Public Sub Crear(nombre As String, precio As String)
        Dim sql As String
        Dim conexion As New SqlClient.SqlConnection
        conexion.ConnectionString = MiConexion.Cadena
        conexion.Open()
        Dim cmd As New SqlClient.SqlCommand
        cmd.Connection = conexion
        sql = "insert into tipo values('" & nombre & "'," & Replace(precio, ",", ".") & ")"
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
    End Sub

    Public Sub Modificar(idTipo As Integer, nombre As String)

    End Sub

    Public ReadOnly Property Nombre As String
        Get
            Nombre = ""
        End Get
    End Property
End Class
