﻿module FunctionComposition

    let subtract x y = x - y
    subtract 9 3

    3 
    |> subtract 9
    |> subtract 88
   
    subtract 88 <| (subtract 9 <| 3)
    
    let square x = x * x
    let triple x = x * 3
    let negate x = -x

    let squareAndTripleAndNegate = square >> triple >> negate

    squareAndTripleAndNegate 5

    let toFloat x = (float)x
    let toInt (x:float) = (int)x

    let squareAndTripleAndNegate = 
        square >> toFloat >> triple >> toInt >> negate

    let add x y = x + y

    let splitPair f (x:int,y:int) = f x y

    let addAndSquare = splitPair add >> square

    addAndSquare (7,13)

    