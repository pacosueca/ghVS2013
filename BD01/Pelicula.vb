Imports System.Data.SqlClient

Public Class Pelicula
    Public Sub Crear(titulo As String, genero As Integer, tipo As Integer, actores As String, resumen As String)
        Dim sql As String

        Dim conexion As New SqlConnection
        conexion.ConnectionString = MiConexion.Cadena
        conexion.Open()

        sql = "insert into peliculas(titulo,idgenero,idtipo,actores,resumen) "
        sql = sql & "values(@titulo,@genero,@tipo,@actores,@resumen)"
        Dim cmd As New SqlCommand

        cmd.Connection = conexion
        cmd.CommandText = sql

        cmd.Parameters.Add("@titulo", SqlDbType.VarChar, 125).Value = titulo
        cmd.Parameters.Add("@genero", SqlDbType.Int).Value = genero
        cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo
        cmd.Parameters.Add("@actores", SqlDbType.VarChar, 500).Value = actores
        cmd.Parameters.Add("@resumen", SqlDbType.VarChar, 1000).Value = resumen

        cmd.ExecuteNonQuery()
    End Sub

    Public Sub CrearConEjemplar(titulo As String, genero As Integer, tipo As Integer, actores As String, resumen As String, formatoEjemplar As Integer, ByRef Resultado As Boolean)
        Dim transaccion As SqlTransaction
        Try
            Dim sql As String

            Dim conexion As New SqlConnection
            conexion.ConnectionString = MiConexion.Cadena
            conexion.Open()

            transaccion = conexion.BeginTransaction

            sql = "insert into peliculas(titulo,idgenero,idtipo,actores,resumen) "
            sql = sql & "values(@titulo,@genero,@tipo,@actores,@resumen)"
            Dim cmd As New SqlCommand

            cmd.Connection = conexion
            cmd.CommandText = sql

            cmd.Transaction = transaccion

            cmd.Parameters.Add("@titulo", SqlDbType.VarChar, 125).Value = titulo
            cmd.Parameters.Add("@genero", SqlDbType.Int).Value = genero
            cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo
            cmd.Parameters.Add("@actores", SqlDbType.VarChar, 500).Value = actores
            cmd.Parameters.Add("@resumen", SqlDbType.VarChar, 1000).Value = resumen

            cmd.ExecuteNonQuery()

            Dim cmd2 As New SqlCommand
            Dim conexion2 As New SqlConnection
            conexion2.ConnectionString = MiConexion.Cadena
            conexion2.Open()

            sql = "select top 1 idpelicula from peliculas with (nolock) where titulo='" & titulo & "' order by idpelicula desc"
            cmd2.Connection = conexion2
            cmd2.CommandText = sql

            Dim miIdPelicula As Long = cmd2.ExecuteScalar

            Dim cmd3 As New SqlCommand

            sql = "insert into ejemplar(idpelicula,idformato,activo) "
            sql = sql & "values(@idpelicula,@idformato,1)"

            cmd3.Connection = conexion
            cmd3.CommandText = sql

            cmd3.Transaction = transaccion

            cmd3.Parameters.Add("@idpelicula", SqlDbType.Int).Value = miIdPelicula
            cmd3.Parameters.Add("@idformato", SqlDbType.Int).Value = formatoEjemplar
            cmd3.ExecuteNonQuery()

            transaccion.Commit()
            Resultado = True
        Catch ex As Exception
            transaccion.Rollback()
            Resultado = False
        Finally
        End Try

    End Sub

    Public Function ListarTodas() As DataTable
        Dim sql As String
        Dim midt As New DataTable
        sql = "select ejemplar.idEjemplar as [Cód. ejemplar],Peliculas.Titulo,genero.Nombre as [Género],Tipo.Nombre as Tipo,tipo.Precio,Formato.Nombre as Formato, "
        sql = sql & "peliculas.idpelicula,formato.idformato,genero.idgenero,tipo.idtipo "
        sql = sql & "from Peliculas inner join Genero on Peliculas.idGenero= genero.idGenero "
        sql = sql & "inner join Ejemplar on Ejemplar.idPelicula=Peliculas.idPelicula "
        sql = sql & "inner join Formato on Formato.idFormato = Ejemplar.idFormato "
        sql = sql & "inner join tipo on tipo.idTipo = Peliculas.idTipo "
        RellenaDataTable(midt, sql)
        ListarTodas = midt
    End Function

    Public Sub Modificar()

    End Sub

End Class
