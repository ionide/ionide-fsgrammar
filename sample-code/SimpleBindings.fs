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

let tupA1, tupA2 = 1, 2
let (tupB1, tupB2) : decimal * decimal = 40m, 50M

