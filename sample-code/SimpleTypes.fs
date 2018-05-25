(**
# First-level heading
Some more documentation using `Markdown`.
*)
module SampleCode.SimpleTypes

/// **Description**
///
/// **Parameters**
///   * `arg1` - parameter of type `string`
///   * `arg2` - parameter of type `string`
///
/// **Output Type**
///   * `string`
///
/// **Exceptions**
///
let markdownDemo (arg1 : string) (arg2 : string) =
    ""

// **This comment isn't formatted**

(* Neither this one *)

type Alias = int

type Alpha = class end

type LightDU =
    | CaseA
    | CaseB

type EgalNewLine
    = CaseA
    | CaseB

type Underscore_Name = | Underscore_Name of string

type Accentué = int

type Class1() =
    member this.X = "F#"

// Check accessibility modifier coloring
type R = private { X  : int }
type U = private | X of int

type FancyClass(thing:int, var2 : string) as xxx =

    let pf() = xxx.Test()

    member xxx.Test() = "F#"

type FancyClass1(?thing:int) =
    class end

type private FancyClass2 (?thing:int) =
    class end

type FancyClass3 private (?thing:int) =
    class end

module test =
    let t = 1

module accentué =
    let t = 1

open test

type MutableMembersTest = {
    mutable test: string
}

// Test that variable named like: keyword' isn't colored in a match statement
let test match' =
    match match' with
    | CaseA -> ""
    | CaseB -> ""

let test2 return' =
    match return' with
    | CaseA -> ""
    | CaseB -> ""

type RequestData =
    { Params : string }

type Client () =
    member this.Request (req : RequestData) = ""

let res (client : Client) = client.Request { Params = "" }

[<Measure>]
type kg

