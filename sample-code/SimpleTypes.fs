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

exception UndefinedValueException of string

type Alias = int

type Alpha = class end

type LightDU =
    | CaseA
    | CaseB

type EgalNewLine
    = CaseA
    | CaseB

type Underscore_Name = | Underscore_Name of string

let i32 = typeof<int>
let list = typedefof<_ list>

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

// Check that known builder names aren't captured as builders when a
// value name begins with one of them (e.g. `asyncResult`)
// Also see ionide/ionide-vscode-fsharp#836
let d =
    let asyncF = async { }
    asyncF

// Whitespace between builder and opening brace is optional
let e = async{ return 0 }

type FancyClass(thing:int, var2 : string -> int, ``ddzdz``: string list, extra) as xxx =

    let pf() = xxx.Test()

    member xxx.Test() = "F#"

    member __.Test2(thing:int, var2 : string, ``name with space``: string option, extra) = ""

// Arrow should be colored as a keyword and int as type definition
let exec (buildOptions: int -> int -> int -> int) args = ""

type FancyClass1(?thing:int) =
    class end

type private FancyClass2 (?thing:int) =
    class end

type FancyClass3 private (?thing:int) =
    class end

let paramsColorWorksHereToo (client : obj, extraParam) = ""

let (name : string, age) = "", 0

// Check that option is also colored as part of the type definition
let debounce (debounce : int option) = ""

// Check output type coloration
let mutable timeoutID : float = 0.
let test2 test (timeoutID : float option) : int option = None

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
        yield index ]

type TestDUTypeColoration =
    | CaseA
    | CaseB of int
    | CaseC of int * string
    | CaseD of name :string * age:int
    | CaseE of client: Client
    | CaseF of client: Client * string * port : int
    | CaseG of (obj -> unit)
    | CaseH of string * (obj -> unit)
    // Check multiple declaration on one line
    | CaseI of int | CaseJ of int

type GenType<'a> = 'a

type ``type with space`` = obj

let t : ``type with space`` = null
let t2 : obj = null

type TestRecordColoration<'a> =
    { Firstname : string
      Lastname : string
      Age : int
      Notify : string -> unit
      Notify2 : string ->unit
      Notify3 : string-> unit
      Notify4 : string   ->    unit
      Callback : (string * int) -> GenType<'a> -> Client
      TypeWithSpace : ``type with space``
      Nested : ((string * int) -> RequestData) -> Client
      mutable Mutable : obj }

type CheckSingleLineRecord =
    { Param1 : string; Param2 : obj }

// Check that compression expression aren't mess up by the record coloration
let a =
    async {
        let! a = async {
            return 0
        }
        return a
    }
