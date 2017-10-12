﻿module SampleCode.SimpleBindings


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

sprintf "75.9%% ss"
sprintf """
dfdfdf %s
"""

let numbers = [ 1 .. 10 ]
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


module public test =
    let x = 1

module internal test2 =
    let x = 1

module private test3 =
    let x = 1

module test4 =
    let x = 1