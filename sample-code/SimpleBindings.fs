module SampleCode.SimpleBindings


(* Literals *)

let a_sbyte      = 100y
let a_byte       = 35uy
let b_byte       = 0b000101uy
let c_byte       = 'F'B

let a_int16      = 44s
let a_uint16     = 44us
let a_int        = 100
let a_int32      = 100l
let a_uint       = 100u
let a_uin32      = 100ul
let a_unativeint = 0x00002D3Fun
let a_int64      = 86L
let a_uint64     = 86UL

let a_float32    = 10.0F
let b_float32    = 55.66f
let c_float32    = 0x00000000lf
let d_float32    = 180.e5f
let e_float32    = 180.3E+32f
let f_float32    = 180.4e+10f
let g_float32    = 180.e5F
let h_float32    = 180.3E+32F
let i_float32    = 180.4e+10F

let a_float64    = 30.0
let b_float64    = 40.0e5
let c_float64    = 2.3E+32
let d_float64    = 2.3e+32
let e_float64    = 0x0000000000000000LF

let a_bigint     = 304554I

let π = 3.1415


let binding = "empty"
let aString : string = "typed"
let accentué = "accentué"

let [<Literal>] literal_test = 11

[<Literal>]
let literal_test2 = 11

printf  "\d"
printfn "\s"
sprintf ""
printf "some tup %A dasda" ((2),2)
printf "%O" (1,2,3)
printf "%s" ""
printf "%E" 2.0
printf "%1e" 1.0
printf "sss  %-1e" 2.
printf "%-10s" "2"
printf "%020.1f" 0.2f
printfn "\x00 \x1a \xff \x1g" // 1g is invalid
// all valid
printfn "\a\b\f\n\r\t\v\\\"\' \000\255\111 \x00\xFF\xE7\xe7 \u0000\uffff\uFFFF \U00000000\U0010FFFF\U0001F47D\U0001f47d"
// all invalid
printfn "\c\h \345\256 \xxx\xFX \u123x \U12345678\U0011FFFF\U00FFFFFF\U0010FXFF"
// all invalid with normal chars and space between
printfn "a\ca\ha a\345a\256a\12a \12 a\xxxa\xFXa\xxa \xs a\u123x\u14a a\U12345678a\U0011FFFFa\U00FFFFFFa\U0010FXFFa \U0014e a"

sprintf "75.9%% ss"
sprintf """
dfdfdf %s
"""

let numbers = [1 .. 10]
let numbers = [1..10]
let numbers = [1 .. 10 .. 100]
let numbers = [1..10..100]
let numbers = [1.0 .. 10.0]
let numbers = [1.0..10.0]
let numbers = [1.0 .. 10.0 .. 100.0]
let numbers = [1.0..10.0..100.0]
let numbers = numbers[1 ..]
let numbers = numbers[1..]
let numbers = numbers[1 .. 10]
let numbers = numbers[1..10]
let numbers = numbers[.. 10]
let numbers = numbers[..10]
let square x = x * x
let squares = List.map square numbers
printfn "N^2 = %A" squares

let tupA1, tupA2 = 1, 2
let (tupB1,tupB2) : decimal * decimal = 40m, 50M
let (tupB1, tupB2) : decimal * decimal = 40m, 50M
let [| a; b |] = [| 1; 2 |]
let [ c; d ] = [1; 2]
let ``tick`` = ""
let ``tick with mutiple words`` = ""
let quote' = ""
let multiple'quote = ""

type T = C of int
let m = C 3
let (C n) = C 3

let x = fun a -> 17

let internal add a b = a + b
let private add2 a b = a + b
let public add3 a b = a + b
let add4 a b = a + b
let update _msg model =
  model


module public test =
    let x = 1

module internal test2 =
    let x = 1

module private test3 =
    let x = 1

module test4 =
    let x = 1

let uses = None
match uses with
| Some uses -> ()
| Some ands -> ()
| uses -> ()
| ands -> ()
// ENHANCEMENT: Keywords should not change following tokens and highlighting
//   -> string should still be recognized and highlighted as string
// | and -> ()
// | use -> ()
"some string"

// Make sure the equal signs are all the same color, particularly when
// using different colors for keywords than for symbols
module EqualSignTest =

    module Opt = Option

    type Foo() =

        let mutable waldo = 0

        member this.A = waldo
        member this.B with set (value) = waldo <- value
        member this.C with get () = waldo and set (value) = waldo <- value
        member this.D with get () = waldo

    and Bar() =

        interface System.IDisposable with member this.Dispose() = ()

        member val A = 11
        member val B = 22 with get, set

    let quux =
        let foo = new Foo()
        use bar = new Bar()
        task {
            let! fred = task { return new Foo() }
            use! barb = task { return new Bar() }
            return (fred, barb)
        }

    type Boo = { A : int; B : int }
    let boom = { A = 123; B = 456 }
    let buzz = { boom with B = 789 }

    type Goo =
        val a : int
        val b : int
        new(a0, b0) = { a = a0; b = b0; }

    let rec bee x =
        bop (x - 1)
    and bop y =
        if (y = 0) then 0 else bee y

// Make sure the arrow symbols `<-` and `->` are all the same color. If the
// user sets a custom color for `keyword.symbol.arrow`, then all the arrows
// should be that color. If the user does not set an explicit configuration
// for the arrow color, then all the arrows should be the same color as all
// the other operator symbols (i.e. the `keyword.symbol` color).
module ArrowTest =

    let mutable foo1 = 0

    foo1 <- 1

    let foo2 = (fun () -> 123)
    let foo3 = (fun x -> 456)
    let foo4 : (unit -> unit) = id
    let foo5 =
        match foo1 with
        | 0 -> ()
        | _ -> ()

    [<AbstractClass>]
    type FooWithArrows(item : unit -> unit) =
        abstract member Bar : unit -> unit
        abstract member Baz : unit -> array<int>
        member this.Boo : unit -> unit = id
        member this.Goo : unit -> array<int> = failwith "foo"

// The word `unit` should be styled the same as built-in primitive types such
// as `char`, `byte`, `int`, `float`, `bool`, etc.
module UnitAsTypeTest =

    let unit = "foo"
    let char = "bar"
    let byte = "baz"

    let bing = unit
    let bang = char
    let boom = byte

    let mike : unit = ()
    let john : char = 'A'
    let gary : byte = 0uy

#nowarn "3535"

type IFace =
    static abstract M : unit
    static abstract member N : unit

let inline foo x = x
let inline bar x = x
