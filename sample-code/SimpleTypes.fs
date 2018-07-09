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

type FancyClass(thing:int, var2 : string -> string, ``ddzdz``: string list, extra) as xxx =

    let pf() = xxx.Test()

    member xxx.Test() = "F#"

    member __.Test2(thing:int, var2 : string, ``name with space``: string option, extra) = ""

// Arrow should be colored as a keyword and int as type definition
let exec (buildOptions: int -> int -> int -> int) args = ""

// This line is to check that member_declaration isn't propagate output of declaration scopes
let p value = System.Int32.Parse(value)

type TestGeneric<'arg, 'model, 'msg, 'view> private (*comments test*) (a: 'arg, model: 'model, msg: 'msg, view: 'view, notify : string -> unit ) as xxx =
    class end

type Program<'arg, 'model, 'msg, 'view> =
    { Arg : 'arg
      Model : 'model
      Msg : 'msg
      View : 'view }

let run (program : Program<'arg, 'model, 'msg, 'view>) = ""
let run2 (program : unit -> Program<'arg, 'model, 'msg, 'view>) = ""

type T =
    abstract member Name: string option with get, set
    abstract member NameTestComment: string (*I am a comments*) option with get, set
    abstract member NameTestComment2: string //option with get, set
    abstract member Keys: unit -> Program<'arg, 'model, 'msg, array<'view>>
    abstract Run : program : Program<'arg, 'model, 'msg, 'view> -> unit
    abstract ``open``: cacheName: string -> obj
    abstract DrawElementsInstancedANGLE: mode: float * count: float * ``type``: float * offset: float * primcount: float

type FancyClass with
    member __.Run (program : Program<'arg, 'model, 'msg, array<'view>>) = ()

type FancyClass1(?thing:int) =
    class end

type private FancyClass2 (?thing:int) =
    class end

type FancyClass3 private (?thing:int) =
    class end

let paramsColorWorksHereToo (client : obj, extraParam) (name : unit -> obj) = ""

let endOfThisLineShouldBeCommented// (client : obj, extraParam) = ""
    = ""

// Fixed width comments also works and coloration is still correct after it
let endOfThisLineShouldBeCommented2 (*(client : obj, extraParam) = ""*) (name: int) = ""

// Fixed width comments also works even in tuples parameters
// and coloration is still correct after it
let private _emitLetBinding (il:int, (*methods:MethodSymbolTable, locals:LocalsSymbolTable,*) binding:obj) =
    ""

type EndOfThisLineShouldBe//Commented (a:int, b:int) =
    (a: int, b: int) =
        class end

let (name : string, age) = "", 0

let variable = "value"

// Check that style is apply even when declaration is on multiple lines
let func arg1 arg2 = ""

let func
    arg1 arg2 = ""

let func
    arg1
    arg2 = ""

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
    | CaseF of client: Client (*comment tests*) * (*comment tests*) string * port : int
    | CaseG of (obj -> unit)
    | CaseH of string * (obj -> unit)
    // Check multiple declaration on one line
    | CaseI of int | CaseJ of int
    | CaseF2 of client: Client // * string * port : int
    | FetchDomainsSuccess of Result<int list * int * int, string>

type GenType<'a> = 'a

type ``type with space`` = obj

let t : ``type with space`` = null
let t2 : obj = null

type TestRecordColoration<'a> =
    { Firstname : string
      Lastname : string
      /// Test docs comments works with `markdown`
      Age : (*comment tests*) int
      Notify : string -> unit
      Notify2 : string ->unit
      Notify3 : string-> unit
      Notify4 : string   ->    unit
      Callback : (string * int) -> GenType<'a> -> Client // Comments tests
      TypeWithSpace : ``type with space``
      Nested : ((string * int) -> (*comment tests*) RequestData) -> Client
      mutable Mutable : obj }

let testRecordColoration =
    { Firstname = "string" // Comments should work here
      Lastname = "string"
      Age = 10
      Notify = fun _ -> ()
      Notify2 = fun s -> ()
      Notify3 = fun _ -> ()
      Notify4 = fun _ -> ()
      Callback = fun (a, (*b) comments should works here too*) b) -> unbox null
      TypeWithSpace = null
      Nested = fun func -> unbox null
      Mutable = null }

type CheckSingleLineRecord =
    { Param1 : string; (*comment tests*) Param2 : obj }

// Check that compression expression aren't mess up by the record coloration
let a =
    async {
        let! a = async {
            (*comment tests*)
            return 0
        }
        return a
    }

// Edge cases provided by @selketjah
// In this code some of the `type` word where colored in purple
type Example =
   { Type : int
     SType : int
     Stype : int
     STypeT : int
     StypeT : int // comments tests
     TypeS : int (*comment tests*)
     typeTest : int
     stype : int
     stypes : int
     s_type : int }

// Edge cases provided by @selketjah
// `type` was colored as keyword
// `with` as a Type declaration
let temp (s : Example) =
   match s.stype with
   | 0 -> "whatever"
   | 1 -> "you lazy bastard"

// Edge case when there is something after } the next type is not colored
type One =
    { Id : string } // test

type Two =
    { Id : int }
