﻿// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    MyLib.getHello() |> printfn "%s"
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
