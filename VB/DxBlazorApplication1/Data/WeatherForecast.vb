Imports System
Imports System.Collections.Generic

Namespace DxBlazorApplication1.Data

    Public Class WeatherForecast

        Public Property [Date] As DateTime

        Public Property TemperatureC As Integer

        Public ReadOnly Property TemperatureF As Integer
            Get
                Return 32 + CInt(TemperatureC / 0.5556)
            End Get
        End Property

        Public Property Summary As List(Of String)?

        Public ReadOnly Property SummaryString As String
            Get
                Return String.Join(",", Summary)
            End Get
        End Property
    End Class
End Namespace
