namespace MSTest

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open Code

[<TestClass>]
type TestClass () =

    [<TestMethod>]
        member x.``gcd of 18 and 42 is 6 (MSTest)`` () =
            let result = gcd 18 42
            Assert.AreEqual(result, 6)