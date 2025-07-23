(**
---
layout: standard
title: Manual
---
**)

// The next comment was making the rest of the file render
// as a comment until another comment was breaking the flow
(*** hide ***)

module SampleCode.SimpleTypes

(**
This comment was making the rest of the file render as a comment
**)

// Compiler directives

#if true
#elif false
#elseif false
#endif
#light "on"
#nowarn
#nowarn "9" "40"

open System.Text// check that comments are handled correctly
open System.Text // check that comments are handled correctly
open System.Text.RegularExpressions(* check that comments are handled correctly *)
open System.Text.RegularExpressions (* check that comments are handled correctly *)
open type System.Math

module Test =

    (** **Check** that this line isn't capture for the markdown grammar *)
    let a = ""

    (**
    This is an edge case, because in early implementation this is commented the whilte file

    Line with indentation isn't colorized because markdown can't set up his context.
    *)
    let b = ""

    let double = (*) 2 // *) was being captured as a comment
    
    // Both of these operators should have the same syntax highlighting,
    // specifically the infix multiplication operator.
    let foldSum xs = Seq.fold (+) 0 xs
    let foldProduct xs = Seq.fold (*) 1 xs
    
    // Parenthesizing the above expression should not associate the `)`
    // part of the multiplication operator with the opening paren before
    // the expression.
    let foldProduct2 xs = (Seq.fold (*) 1 xs)

    (**
This block is colorized because markdown can set up his context.

# First-level heading
This should be parsed as `markdown`.
This is an edge case, because in early implementation this is parser the whole
file as markdown
    *)
    let c = ""

    (* Comments with nested (* (* *) *) works

    This line should be shown commented.
    class should not be colored
    *)
    let d = ""


    (* Unbalanced comment, which turn everything after itself into comment **)
    let e = (* comment// *) "not a comment"
    
    // The infix multiplication operator (*) should not be parsed as the end of a 
    // block comment.
    (* (*) "This text is a comment" (*) *)

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

// See https://github.com/ionide/ionide-fsgrammar/issues/177
// Check that custom operators definition that use any number of `/` are not captured as a comment
let (!//!) x y = x + y
let (%//%) x y = x + y
let (&//&) x y = x + y
let (+//+) x y = x + y
let (-//-) x y = x + y
let (.//.) x y = x + y
// This definition generates errors below, but I don't think it is common enough to spend time on it
// The bug is probably due to the open `<` at the end
// let (<//<) x y = x + y
let (=//=) x y = x + y
let (>//>) x y = x + y
let (?//?) x y = x + y
let (@//@) x y = x + y
let (^//^) x y = x + y
let (|//|) x y = x + y
let (<//>) x y = x + y

let (!///!) x y = x + y
let (%///%) x y = x + y
let (&///&) x y = x + y
let (+///+) x y = x + y
let (-///-) x y = x + y
let (.///.) x y = x + y
// This definition generates errors below, but I don't think it is common enough to spend time on it
// The bug is probably due to the open `<` at the end
// let (<///<) x y = x + y
let (=///=) x y = x + y
let (>///>) x y = x + y
let (?///?) x y = x + y
let (@///@) x y = x + y
let (^///^) x y = x + y
let (|///|) x y = x + y
let (<///>) x y = x + y
// Works for any number of `/`
let (</////////>) x y = x + y

// // Check that custom operators usage that use `//` is not captured as a comment
let add1 x y = x (!//!) y
let add2 x y = x (%//%) y
let add3 x y = x (&//&) y
let add4 x y = x (+//+) y
let add5 x y = x (-//-) y
let add6 x y = x (.//.) y
let add7 x y = x (<//<) y
let add8 x y = x (=//=) y
let add9 x y = x (>//>) y
let add10 x y = x (?//?) y
let add11 x y = x (@//@) y
let add12 x y = x (^//^) y
let add13 x y = x (|//|) y
let add14 x y = x (<//>) y

let add15 x y = x (!///!) y
let add16 x y = x (%///%) y
let add17 x y = x (&///&) y
let add18 x y = x (+///+) y
let add19 x y = x (-///-) y
let add20 x y = x (.///.) y
let add21 x y = x (<///<) y
let add22 x y = x (=///=) y
let add23 x y = x (>///>) y
let add24 x y = x (?///?) y
let add25 x y = x (@///@) y
let add26 x y = x (^///^) y
let add27 x y = x (|///|) y
let add28 x y = x (<///>) y
// Works for any number of `/`
let add29 x y = x (</////////>) y

// operator chars after comments don't break comment rendering
let r = 23 + 42 //|> id

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

let private getArgResults, private removeArgResults, private setArgResults = "", "", ""

// Check builder detection (based on a whitelist)
let a = promise { }
let b = pipeline { }
let c = noColor { }

let origin = struct (0,0)

let private (struct (x0,y0)) = origin

// Check that known builder names aren't captured as builders when a
// value name begins with one of them (e.g. `asyncResult`)
// Also see ionide/ionide-vscode-fsharp#836
let d =
    let asyncF = async { }
    asyncF

// Whitespace between builder and opening brace is optional
let e = async{ return 0 }

type Foo = int

// Make sure the opening and closing bracket colors match when the color
// used for keywords is different than the color used for brackets
let f = seq { yield! seq { yield 1 } }

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

    member __.ReadAndWriteWithSignature
        with get (count : int) : string = string count
        and set (value : int) : unit = failwith ""

    member __.MyReadWriteProperty with get () = myInternalValue
    member __.MyReadWriteProperty with set (value) = myInternalValue <- value

    abstract Update : int * string * string option * obj -> FancyClass
    default this.Update (thing:int, var2 : string, ``name withh spaces``: string option, extra) = this

    member val Property1 = thing
    member val Property2 = "" with get, set

    static member val StaticProperty1 = thing

    /// The typo in withh is intentional, because with is one of the `end` possibility
    /// We consider it ok, because there is a low chance that a person will use `with` in a quoted variable
    member __.Test2(thing:int, var2 : string, ``name withh spaces``: string option, extra) = ""

    static member (>) (v1 : int, v2 : int) = v1 > v2
    static member (<) (v1 : int, v2 : int) = v2 < v2
    static member (< ) (v1 : int, v2 : int) = v2 < v2
    static member (<|>) (v1 : int, v2 : int) = v2 < v2

    member inline _.Q () = 3
    member inline internal _.P () = 3

    member this.Value
        with inline get() = ()
        and inline set v = ()

let inline internal (<) (x : int) ys = x + ys
let (< ) (x : int) ys = x + ys
let (<<.) a = 1
let inline internal (<==) (x : int) ys = x + ys
let inline internal (<==) x ys = x + ys

// Check that this `get` and `set` methods are not messing the colourisation
let get = ignore
get ("maxime")
let set = ignore
set("maxime")

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
let tuple2 (decoder1: Decoder<'T1>) (decoder2: Decoder<'T2>) : Decoder<'T1 * 'T2> = failwith ""

let run (program : Program<'arg, 'model, 'msg, 'view>) = ""
let run2 (program : unit -> Program<'arg, 'model, 'msg, 'view>) = ""

type T =
    abstract Item: selector: string -> string with get, set
    abstract icon: width : int * height : int with get, set
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
    abstract Decode<'Json> : spaces : int -> string // Should trigger generic coloration and have int colored as type
    abstract member Decode2<'Json, 'Output> : spaces : int -> string// This was breaking coloration of lines below

type FancyClass with
    member __.Run<'JsonValue> (program : Program<'arg, 'model, 'msg, array<'view>>) = ()

type FancyClass1(?thing:int) =
    class end

type private FancyClass2 (?thing:int) =
    class end

type FancyClass3 private (?thing:int) =
    class end

let foo =
    { new System.IDisposable with
        member __.Dispose() =
            failwith "do nothing" }
let bar =
    use foo = new System.Threading.CancellationTokenSource()
    ()

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
let tupleWithAListOfGenerics (p1 : int * Map<int, int> list) (p2 : int * Map<int, int> list) : int * Map<int, int> list = 1, []
let tupleWithAListOfGenerics : int * Map<int, int> list = 1, []
let tupleWithAListOrArrayOfGenerics2 : int * Map<int, int> list * Map<int, int> array = 1, [], [||]

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
let inline method<'a> prefix chunck dzd zd = promise {
        let! dzdz = ""
    }


let v ``var with spaces``= ""

let printFullName { Firstname = firstname; Surname = surname } : string = firstname + " " + surname
let printFirstName { Firstname = firstname } : string = firstname
let printFirstName ({ Firstname = ``var with spaces`` } : NameRecord) ( _ : obj) : string = ``var with spaces``


let ``test multiple backticks`` = row.``maxime``.Trim(), row.``Last Update`` // Test multiple backticks on the same line

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

// Test case for: https://github.com/ionide/ionide-fsgrammar/issues/147
let testVariableWithModuleKeyword test_module =
    if test_module then // This is the line where the problem is
        ()

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
   | 1 -> ""

// Edge case when there is something after } the next type is not colored
type One =
    { Id : string } // test

type Two =
    { Id : int }

// Support for anonymous records

type Employee =
    | Engineer of {| Prop1 : int; Prop2 : {| Prop1 : int; Prop2 : {| Prop1 : GenType<GenType<obj>>; Prop2 : {| Prop1 : int; Prop2 : List<string> |} |} |} |}
    | Manager of {| Prop1 : int; Prop2 : {| Prop1 : int; Prop2 : List<string> |} |}

let private standardIntInput (props : {| Dispatch : GenType<GenType<obj>>
                                         Disabled : {| Prop1 : int; Prop2 : {| Prop1 : int; Prop2 : List<string> |} |}
                                         Errors : GenType<'Msg> list |}) = ""

let test = fun (props : {| Dispatch : GenType<GenType<obj>>
                           Disabled : {| Prop1 : int; Prop2 : {| Prop1 : int; Prop2 : List<string> |} |}
                           Errors : GenType<'Msg> list |}) -> ""

type AR_Class () =
    member this.Method1 (props : {| Dispatch : GenType<GenType<obj>>
                                    Disabled : {| Prop1 : int; Prop2 : {| Prop1 : int; Prop2 : List<string> |} |}
                                    Errors : GenType<'Msg> list |}) = ""

// Check anonymous function type signature
let tx = fun (t : ``type with spaces``) (``var with spaces`` : Result<obj list, int>) -> ()

// Make sure the opening and closing parenthesis colors match when using
// a distinct color for the arrow symbol
let lambda0 = fun x -> x
let lambda1 = fun (x) -> x
let lambda2 = fun (x) (y) -> x
let lambda3 = fun (x, y) -> x
let lambda4 = fun ((x, y), z) -> x
let lambda5 = (fun x -> x)
let lambda6 = (fun (x) -> x)
let lambda7 = (fun (x) (y) -> x)
let lambda8 = (fun (x, y) -> x)
let lambda9 = (fun ((x, y), z) -> x)

let private mixedArray msg (decoders: string []) (path: string) (values: obj[]): Result<obj list, int> =
    Ok []

type Auto() =
    static let (color, message) = failwith ""

    static let (color : Result<'T, string>) = failwith ""

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

// // Make sure coloration support SRTP synthax
// // The next code has been copied from
// // https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/generics/statically-resolved-type-parameters

let inline konst x _ = x

type CFunctor() =
    static member inline fmap (f: ^a -> ^b, a: ^a list) = List.map f a
    static member inline fmap (f: ^a -> ^b, a: ^a option) =
        match a with
        | None -> None
        | Some x -> Some (f x)

    // default implementation of replace
    static member inline replace< ^a, ^b, ^c, ^d, ^e when ^a :> CFunctor and (^a or ^d): (static member fmap: (^b -> ^c) * ^d -> ^e) > (a, f) =
        ((^a or ^d) : (static member fmap : (^b -> ^c) * ^d -> ^e) (konst a, f))

    // call overridden replace if present
    static member inline replace< ^a, ^b, ^c when ^b: (static member replace: ^a * ^b -> ^c)>(a: ^a, f: ^b) =
        (^b : (static member replace: ^a * ^b -> ^c) (a, f))

let inline replace_instance< ^a, ^b, ^c, ^d when (^a or ^c): (static member replace: ^b * ^c -> ^d)> (a: ^b, f: ^c) =
        ((^a or ^c): (static member replace: ^b * ^c -> ^d) (a, f))

// Note the concrete type 'CFunctor' specified in the signature
let inline replace (a: ^a) (f: ^b): ^a0 when (CFunctor or ^b): (static member replace: ^a *  ^b ->  ^a0) =
    replace_instance<CFunctor, _, _, _> (a, f)

// End of SRTP synthax

// Make sure constraints are correctly colored
// https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/generics/constraints

// Base Type Constraint
type Class1<'T when 'T :> System.Exception> =
    class end

// Interface Type Constraint
type Class2<'T when 'T :> System.IComparable> =
    class end

// Null constraint
type Class3<'T when 'T : null> =
    class end

// Member constraint with static member
type Class4<'T when 'T : (static member staticMethod1 : unit -> 'T) > =
    class end

// Member constraint with instance member
type Class5<'T when 'T : (member Method1 : 'T -> int)> =
    class end

// Member constraint with property
type Class6<'T when 'T : (member Property1 : int)> =
    class end

// Constructor constraint
type Class7<'T when 'T : (new : unit -> 'T)>(thing:int, var2 : string -> string, ``ddzdz``: string list, extra) as xxx =
    member val Field = new 'T()

// Reference type constraint
type Class8<'T when 'T : not struct> =
    class end

// Enumeration constraint with underlying value specified
type Class9<'T when 'T : enum<uint32>> =
    class end

// 'T must implement IComparable, or be an array type with comparable
// elements, or be System.IntPtr or System.UIntPtr. Also, 'T must not have
// the NoComparison attribute.
type Class10<'T when 'T : comparison> =
    class end

// 'T must support equality. This is true for any type that does not
// have the NoEquality attribute.
type Class11<'T when 'T : equality> =
    class end

type Class12<'T when 'T : delegate<obj * System.EventArgs, unit>> =
    class end

type Class13<'T when 'T : unmanaged> =
    class end

// Member constraints with two type parameters
// Most often used with static type parameters in inline functions

// Test that we are correctly detecting the end of the STRP syntahx when there is only one argument
let inline doNothing(_value1 : ^T when ^T : (static member (+) : ^T * ^T -> ^T)) =
    ""

let inline doNothing(_value1 : ^Word when ^Word : (static member toJson : ^Word * ^Word -> ^Word)) =
    ""

let inline add2(value1 : ^T, value2: ^T when ^T : (static member (+) : ^T * ^T -> ^T)) =
    value1 + value2

let inline add(value1 : ^T when ^T : (static member (+) : ^T * ^T -> ^T), value2: ^T) =
    value1 + value2

// ^T and ^U must support operator +
let inline heterogenousAdd(value1 : ^T when (^T or ^U) : (static member (+) : ^T * ^U -> ^T), value2 : ^U) =
    value1 + value2

let inline heterogenousAdd(value1 : ^Word when (^Word or ^U) : (static member (+) : ^Word * ^U -> ^Word), value2 : ^U) =
    value1 + value2

// If there are multiple constraints, use the and keyword to separate them.
type Class14<'T,'U when 'T : equality and 'U : equality> =
    class end

type Class15<'``generic type with space`` when '``generic type with space`` :> System.Exception> =
    class end

// Type constrainst coloration also works in the constructor
type Class16(value1 : ^T when (^T or ^U) : (static member (+) : ^T * ^U -> ^T), value2 : ^U) =
    class end

// Make sure that `:>` isn't closing the current generic tag
let inline create<'a, 'b when 'a :> obj and 'a: (new: unit -> 'a)> () : 'b =  failwith ""

// Explicit Fields
// Adapted from: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/members/explicit-fields-the-val-keyword
// And : https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/members/let-bindings-in-classes

type MyType<'``Generic type with spaces``, 'T>() =
    let mutable myInt1 = 10
    static let mutable myInt3 = 3
    [<DefaultValue>] static val mutable private myInt2 : int
    [<DefaultValue>] val mutable myString : '``Generic type with spaces``
    [<DefaultValue>] val mutable myString2 : 'T

type MyClass =
    val a : int
    val b : int
    // The following version of the constructor is an error
    // because b is not initialized.
    // new (a0, b0) = { a = a0; }
    // The following version is acceptable because all fields are initialized.
    new(a0, b0) = { a = a0; b = b0; }

// Check that SRTP do not break standard syntax between `(` & `)`
let incorrect =
    (fun loadedModel ->
        let temp = async {
            return 0
        }
        let loadedModel = { loadedModel with FormState = Form.setWaiting false loadedModel.FormState }
        ())

// This code is used to check that we capture correctly all the variable in the binding

let x = 1

let rec y = 2
and z = 3

use d = new Disposable()

let f =
    foo {
        let! a = bar
        and! b = qux

        use! c = fooBar

        ()
    }

// The opening and closing parentheses following the `new` keyword in the
// constructors should always use the symbol color, regardless of whether
// or not there is a space after the `new` keyword. And the `new` keyword
// should always be the keyword color and not the symbol color.

type FooWithNoSpaceAfterNew =
    val a : int
    new() = { a = 0 }
    new(b) = { a = b }

type FooWithSpaceAfterNew =
    val a : int
    new () = { a = 0 }
    new (b) = { a = b }

// Opening and closing parentheses associated with tuples, unit literals,
// and parameters should be colored consistently.

let parensFoo1 = ()
let parensFoo2 = ( )
let parensFoo3 = (1)
let parensFoo4 = (2, 3)
let parensFoo5 = (), ()
let parensFoo6 = ((), ())
let parensFoo7 = DateTime()
let parensFoo8 = DateTime(456)

let parensBar1 () = "foo"
let parensBar2 ( ) = "bar"
let parensBar3 (x) = "baz"

type ParensBaz1() = class end
type ParensBaz2( ) = class end
type ParensBaz3(x) = class end

// The opening and closing angle brackets `<` and `>` for generics should
// always use the symbol color and not the keyword color. Also, the colon
// symbol `:` and casting operator `:>` should use the symbol color.

type GenericType1<'a> =
    class end

type GenericType2<'a when 'a :> obj> =
    class end

type GenericType3<'a when 'a : enum<int>> =
    class end

let genericFunc1<'a> (x : 'a) = x

let genericFunc2<'a when 'a :> obj> (x : 'a) = x

let genericFunc3<'a when 'a : enum<int>> (x : 'a) = x

type AbstractType =
    abstract member Foo : unit -> unit


type DecoderError<'JsonValue> = string * ErrorReason<'JsonValue>

// Nullness related

let myNullValue : objnull = null

type NullnessConstraint<'T when 'T : null> =
    class end

// Check that we don't break the non nullness case
let toUpperString (txt : string) = ()

let toUpper (txt : string | null) = ()

let toUpperLambda = 
    fun (txt: string | null) -> ()

type StringHelper =
    member this.ToUpper (txt : string | null) = ()