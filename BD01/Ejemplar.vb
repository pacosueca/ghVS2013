Public Class Ejemplar

    Dim miFormato As Integer

    Public ReadOnly Property Formato
        Get
            Formato = miFormato
        End Get
    End Property

    Public Sub Crear(formato As Integer)
        miFormato = formato
    End Sub

    

End Class
