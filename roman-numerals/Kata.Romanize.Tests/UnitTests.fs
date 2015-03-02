namespace Kata.Romanize.Tests

open Microsoft.VisualStudio.TestTools.UnitTesting
open FsUnit.MsTest
open NHamcrest.Core
open Kata.Romanize.Romanizer
open FSharp.Data

[<TestClass>] 
type ``Given a game designer wants to translate arabic numbers to roman numerals`` ()=
   let TestCases = CsvProvider<"romanizer-tests.csv">.GetSample()
   
   [<TestMethod>] member test.
    ``When an arabic number is passed, the correct Roman numeral is returned.`` ()=
        TestCases.Rows
        |> Seq.iter(fun x -> Romanize x.Value |> should equal x.Result)
