(**
# First-level heading
Some more documentation using `Markdown`.
*)
module SampleCode.SimpleTypes

// Compiler directives

#if true
#elif false
#elseif false
#endif
#light "on"
#nowarn
#nowarn "9" "40"


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
    let mutable myInternalValue = null

    member xxx.Test() = "F#"

    // A read-only property.
    member __.MyReadOnlyProperty = myInternalValue
    // A write-only property.
    member __.MyWriteOnlyProperty with set (value) = myInternalValue <- value
    // A read-write property.
    member __.MyReadWriteProperty
        with get () = myInternalValue
        and set (value) = myInternalValue <- value

    member __.MyReadWriteProperty with get () = myInternalValue
    member __.MyReadWriteProperty with set (value) = myInternalValue <- value

    member val Property1 = thing
    member val Property2 = "" with get, set

    /// The typo in withh is intentional, because with is one of the `end` possibility
    /// We consider it ok, because there is a low chance that a person will use `with` in a quoted variable
    member __.Test2(thing:int, var2 : string, ``name withh spaces``: string option, extra) = ""

    static member (>) (v1 : int, v2 : int) = v1 > v2
    static member (<) (v1 : int, v2 : int) = v2 < v2
    static member (< ) (v1 : int, v2 : int) = v2 < v2

// Arrow should be colored as a keyword and int as type definition
let exec (buildOptions: int -> int -> int -> int) args = ""

// This line is to check that member_declaration isn't propagate output of declaration scopes
let p value = System.Int32.Parse(value)

type TestGeneric<'arg, 'model, 'msg, 'view> private (*comments test*) (a: 'arg, model: 'model, msg: 'msg, view: 'view, notify : string -> unit ) as xxx =
    class end

type ``Program with spaces``<'arg, 'model, 'msg, 'view> =
    class end

type Program<'arg, 'model, 'msg, 'view> =
    { Arg : 'arg
      Model : 'model
      Msg : 'msg
      View : 'view }


type Decoder<'a> =
    class end

let keyValuePairs (decoder : Decoder<'value>) : Decoder<(string * 'value) list> = failwith ""
let keyValuePairs (decoder : Decoder<'value>) : Decoder<(string * 'value) list -> obj> = failwith ""


let run (program : Program<'arg, 'model, 'msg, 'view>) = ""
let run2 (program : unit -> Program<'arg, 'model, 'msg, 'view>) = ""

type T =
    abstract Item: selector: string -> string with get, set
    abstract member Name: string option with get, set
    abstract member NameTestComment: string (*I am a comments*) option with get, set
    abstract member NameTestComment2: string //option with get, set
    abstract member Keys: unit -> Program<'arg, 'model, 'msg, array<array<array<'view>>>>
    abstract Run : program : Program<'arg, 'model, 'msg, array<array<array<'view>>>> -> unit
    abstract ``open``: cacheName: string -> obj
    abstract DrawElementsInstancedANGLE: mode: float * count: float * ``type with spaces``: float * offset: float * primcount: float
    abstract Test : Result<string list, int array>
    abstract Test2 : mode: float * test : (Result<Result<Result<Result<string, string>, string>, string> list, int array> * int)
    abstract TupleOfTuples : (int * (int * (Result<Result<Result<Result<string, string>, string>, string> list, int array> * int)))

type FancyClass with
    member __.Run (program : Program<'arg, 'model, 'msg, array<'view>>) = ()

type FancyClass1(?thing:int) =
    class end

type private FancyClass2 (?thing:int) =
    class end

type FancyClass3 private (?thing:int) =
    class end

let paramsColorWorksHereToo (client : obj, extraParam) (name : unit -> obj) : string = ""

let endOfThisLineShouldBeCommented// (client : obj, extraParam) = ""
    : string = ""

// Fixed width comments also works and coloration is still correct after it
let endOfThisLineShouldBeCommented2 (*(client : obj, extraParam) = ""*) (name: int) = ""

// Fixed width comments also works even in tuples parameters
// and coloration is still correct after it
let private _emitLetBinding (il:int, (*methods:MethodSymbolTable, locals:LocalsSymbolTable,*) binding:obj) =
    ""

type EndOfThisLineShouldBe //Commented (a:int, b:int)
    (a: int, b: int) =
        class end

let (name : string, age) = "", 0

type NameRecord =
    { Firstname : string
      Surname : string }

type NestedRecord =
    { Nested : NestedRecord
      PropB : string }


// Test signature coloration
let primitive : int = 0

let tupleOfPrimitives : int * string list = 0, []
let tupleOfPrimitives : (int * string) = 0, ""
let tupleOfTuples : (int * (int * (int * int))) = failwith ""
let tupleOfTuples : int * (int * (Result<Result<Result<Result<string, string>, string>, string> list, int array> * int)) = failwith ""
let tupleOfTuples : (int * (int * (Result<Result<Result<Result<string, string>, string>, string> list, int array> * int))) = failwith ""
let listOfTuples
    (files : (string * string) list)
    (files2 : (string * string) list)
    : (int * (int * (Result<Result<string, string> list, int array> * int))) list = []
let generics : Result<string list, int array> = Ok []

let tupleWithGenerics : Result<string list, int array> * int = Ok [], 0

// Really complexe nested generic type
let tupleWithGenerics2 : (Result<Result<Result<Result<string, string>, string>, string> list, int array> * int) = Ok [], 0

let lambda : int -> unit = ignore
let lambda : (int -> unit) = ignore
let lambda : (int -> unit) -> unit = ignore
let lambda : (Result<string list, int array> -> (string * int)) -> unit = ignore
let lambda : (Result<Result<Result<Result<string, string>, string>, string> list, int array> -> Result<Result<string, string> list, int array> * int) -> unit = ignore
let lambda ( x : (Result<Result<Result<Result<string, string>, string>, string> list, int array>
                -> Result<Result<Result<Result<string, string>, string>, string> list, int array> * int)
                -> unit) : ('T -> unit ) = ignore

let inline isLoadingTime<'a> = ""
let inline isLoadingTime<'a, 'b, 'c> = ""

let v ``var with spaces``= ""

let printFullName { Firstname = firstname; Surname = surname } : string = firstname + " " + surname
let printFirstName { Firstname = firstname } : string = firstname
let printFirstName ({ Firstname = ``var with spaces`` } : NameRecord) ( _ : obj) : string = ``var with spaces``

let nestedRecords ({ Nested = { Nested = { Nested = { Nested = value }; PropB = _ } }; PropB = propB } : NestedRecord) : string = value.PropB + " " + propB

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

type GenType<'a> = 'a

type ``type with spaces`` = obj

let t : ``type with spaces`` = null
let t2 : obj = null

type TestDUTypeColoration =
    | CaseA
    | CaseB of int
    | CaseC of (int * (string * string) list)
    | CaseD of name :string * age:int
    | CaseE of client: Client
    | CaseF of client: Client (*comment tests*) * (*comment tests*) string * port : int
    | CaseG of (obj -> unit)
    | CaseH of string * (obj -> unit)
    // Check multiple declaration on one line
    | CaseI of int | CaseJ of int
    | CaseF2 of client: Client // * string * port : int
    | FetchDomainsSuccess of Result<int list * ``type with spaces`` * int, ``type with spaces``>
    | CaseK of ``var with spaces``: string
    | CaseL of ``var with spaces``: ``type with spaces``
    | CaseM of v1 : ``type with spaces``
    | CaseN of ``type with spaces``

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
      TypeWithSpace : ``type with spaces``
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

// Check anonymous function type signature
let tx = fun (t : ``type with spaces``) (``var with spaces`` : Result<obj list, int>) -> ()

let private mixedArray msg (decoders: string []) (path: string) (values: obj[]): Result<obj list, int> =
    Ok []

type Auto =
    // Here `<`& `>` not in purple
    static member GenerateDecoder<'T> (?isCamelCase : bool): GenType<'T> = failwith ""

    // Here generics not colored
    static member FromString<'T>(json: string, ?isCamelCase : bool): 'T = failwith ""

type Example1 = { Test : int list }
let test = { Test = [ 1;2;3 ] }
// test.test shouldn't be colored
let temp = { test with Test = 3 :: test.Test }

type EitherBuilder() =
   member __.Bind(x) = x
   member __.Return(x) = x

let either = EitherBuilder()

let test x =
    // Ensure coloration is working correctly in custom computation expressions
   either {
       let x = x
       let! c = ""

       return 0
   }


open System

type QueueTrigger(msg : string, b : bool) =
    inherit Attribute()

type [<AllowNullLiteral>] AppState2() =
    class end

type [<AllowNullLiteral>] AppState<'a, 'b>() =
    class end

let run ([<QueueTrigger("something", false); QueueTrigger("something", false)>] content:string) = failwith ""

type [<QueueTrigger("something", false)>] TestInlineAttributeGenerics<'a, 'b>(content:string) =
    class end

type [<QueueTrigger("something", false)>] TestInlineAttribute(content:string) =
    class end

[<QueueTrigger("something", false); QueueTrigger("something", false)>]
type TestAttribue2(content:string) =
    class end
