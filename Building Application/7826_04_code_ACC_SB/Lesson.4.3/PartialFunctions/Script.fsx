module PartialFunctions

    let add x y =
        x + y

    let add2 = add 2
    add2 4

    let add' (x,y) =
        x + y
    
    let add2' = add' 2

    let doOperation f x y =
        f x y

    let doAdd = doOperation add

    doAdd 2 4

    let doMultiply = doOperation (*)
    times3 16

    open System
    open System.Globalization

    let stringCompare s1 s2 =
        String.Compare(s1, s2, true, CultureInfo.InvariantCulture)

    let stringCompare' 
        (ignoreCase:bool) 
        (cultureInfo:CultureInfo) 
        s1 s2 =
            String.Compare(s1, s2, ignoreCase, cultureInfo)
    
    let stringCompare'' =
        stringCompare' true CultureInfo.InvariantCulture