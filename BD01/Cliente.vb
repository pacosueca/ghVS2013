Imports System.Data.SqlClient

Public Class Cliente
    Public Sub New()

    End Sub

    Public Sub Crear(nombre As String, ape1 As String, ape2 As String, dni As String, dir As String, pob As String, cp As String, prov As String, email As String, tel As String, fecnac As Date, fecalta As Date)
        Dim sql As String
        sql = "insert into clientes(dni,nombre,apellido1,apellido2,fecnac,cp,poblacion,provincia,direccion,email,telf,fecalta) "
        sql = sql & "values(@dni,@nombre,@apellido1,@apellido2,@fecnac,@cp,@poblacion,@provincia,@direccion,@email,@telf,@fecalta)"
        Dim cmd As New SqlCommand
        Dim conexion As New SqlConnection
        conexion.ConnectionString = MICONEXION.Cadena
        conexion.Open()
        cmd.Connection = conexion
        cmd.CommandText = sql

        Dim DniSQL As New SqlParameter()
        With DniSQL
            .ParameterName = "@dni"
            .SqlDbType = SqlDbType.VarChar
            .Size = 10
            .Value = dni
        End With

        Dim NombreSQL As New SqlParameter()
        NombreSQL.ParameterName = "@nombre"
        NombreSQL.SqlDbType = SqlDbType.VarChar
        NombreSQL.Size = 50
        NombreSQL.Value = nombre

        cmd.Parameters.Add(DniSQL)
        cmd.Parameters.Add(NombreSQL)
        cmd.Parameters.Add("@apellido1", SqlDbType.VarChar, 50).Value = ape1
        cmd.Parameters.Add("@apellido2", SqlDbType.VarChar, 50).Value = ape2
        cmd.Parameters.Add("@cp", SqlDbType.VarChar, 6).Value = cp
        cmd.Parameters.Add("@poblacion", SqlDbType.VarChar, 50).Value = pob
        cmd.Parameters.Add("@provincia", SqlDbType.VarChar, 50).Value = prov
        cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = dir
        cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email
        cmd.Parameters.Add("@telf", SqlDbType.VarChar, 10).Value = tel
        cmd.Parameters.Add("@fecnac", SqlDbType.SmallDateTime).Value = fecnac
        cmd.Parameters.Add("@fecalta", SqlDbType.SmallDateTime).Value = fecalta

        cmd.ExecuteNonQuery()
    End Sub

End Class
