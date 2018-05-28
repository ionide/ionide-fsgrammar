(**
# First-level heading
Some more documentation using `Markdown`.
*)
module SampleCode.SimpleTypes

module Test =

    (** **Check** that this line isn't capture for the markdown grammar *)
    let a = ""

    (**
    This is an edge case, because in early implementation this is commented the whilte file

    Line with indentation isn't colorized because markdown can't set up his context.
    *)
    let b = ""

    (**
This block is colorized becasue markdown can set up his context.

# First-level heading
This should be parsed as `markdown`.
This is an edge case, because in early implementation this is parser the whole
file as markdown
    *)
    let c = ""

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

/// **Checking that markdown is really working on single line**
let markdownDemo2 (arg1 : string) (arg2 : string) =
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

// Check builder detection (based on a whitelist)
let a = promise { }
let b = pipeline { }
let c = noColor { }

type FancyClass(thing:int, var2 : string, ``ddzdz``: string, extra) as xxx =

    let pf() = xxx.Test()

    member xxx.Test() = "F#"

    member __.Test2(thing:int, var2 : string, ``ddzdz``: string, extra) = ""

type FancyClass1(?thing:int) =
    class end

type private FancyClass2 (?thing:int) =
    class end

type FancyClass3 private (?thing:int) =
    class end

let paramsColorWorksHereToo (client : obj, extraParam) = ""

let (name : string, age) = "", 0

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

let res (client : Client, extraParam) = client.Request { Params = "" }

[<Measure>]
type kg


let forLoop =
    [ for index = 0 to 1 do
        yield "" ]
