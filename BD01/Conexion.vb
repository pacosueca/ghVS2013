Public Class Conexion

    'Dim miCadena As String = "Server=usuario\sqlexpress;Database=videoclub;Trusted_Connection=True;"
    Dim miCadena As String = "Server=pacogarciafbcb\sqlexpress;Database=videoclub;Trusted_Connection=True;"

    Public ReadOnly Property Cadena As String
        Get
            Cadena = miCadena
        End Get
    End Property

End Class
