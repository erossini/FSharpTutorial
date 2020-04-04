module Tests

open System
open Xunit
open Code

[<Fact>]
let ``gcd of 18 and 42 is 6 (xUnit)`` () =
    let result = gcd 18 42
    Assert.Equal(result, 6)
