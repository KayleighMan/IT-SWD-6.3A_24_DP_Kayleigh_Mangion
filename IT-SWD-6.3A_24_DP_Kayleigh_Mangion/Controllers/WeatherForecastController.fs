﻿namespace IT_SWD_6._3A_24_DP_Kayleigh_Mangion.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open IT_SWD_6._3A_24_DP_Kayleigh_Mangion

[<ApiController>]
[<Route("[controller]")>]
type WeatherForecastController (logger : ILogger<WeatherForecastController>) =
    inherit ControllerBase()

    let summaries =
        [|
            "Freezing"
            "Bracing"
            "Chilly"
            "Cool"
            "Mild"
            "Warm"
            "Balmy"
            "Hot"
            "Sweltering"
            "Scorching"
        |]

    [<HttpGet>]
    member _.Get() =
        let rng = System.Random()
        [|
            for index in 0..4 ->
                { Date = DateTime.Now.AddDays(float index)
                  TemperatureC = rng.Next(-20,55)
                  Summary = summaries.[rng.Next(summaries.Length)] }
        |]
