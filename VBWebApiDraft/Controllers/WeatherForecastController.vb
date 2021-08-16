﻿Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.Extensions.Logging

Namespace Controllers

    ' KAD: The C# template leaves the route in as "[controller", although it knows the controller. How come?
    <ApiController>
    <Route("WeatherForecast")>
    Public Class WeatherForecastController
        Inherits ControllerBase

        Private Shared ReadOnly Summaries As String() = {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"}
        Private ReadOnly _logger As ILogger(Of WeatherForecastController)

        Public Sub New(logger As ILogger(Of WeatherForecastController))
            _logger = logger
        End Sub

        <HttpGet>
        Public Function [Get]() As IEnumerable(Of WeatherForecast)
            Dim rng = New Random()
            Return Enumerable.Range(1, 5).[Select](Function(index) New WeatherForecast With {
                .Date = DateTime.Now.AddDays(index),
                .TemperatureC = rng.[Next](-20, 55),
                .Summary = Summaries(rng.[Next](Summaries.Length))
            }).ToArray()
        End Function
    End Class
End Namespace
