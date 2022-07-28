/// This file contains all the F# keywords

namespace global

open System
open System.Collections

type IType =
    abstract member Getter : unit -> int

type SType =
    struct
        val x: int
        new (x: int) = { x = x }
    end

type AType () as self =
    class
        override this.ToString () = "AType"
        abstract member Rotate: float -> unit
        default this.Rotate(delta : float) = ()
    end

and MyType<'T when 'T : null and 'T : not struct and 'T : (new: unit -> 'T)> =
    inherit AType
    interface IType with
        member this.Getter () = 42
    static member Getter () = 42

    override self.ToString () =
        base.ToString ()

type Fn = delegate of int -> unit
type Color = | Red = 0 | Green = 1 | Blue = 2

exception ErrorException of string

module rec Keywords =
    extern void test ()

    let anotherProperty = "not a keyword"
    let property = "not a keyword"
    let union = "not a keyword"

    type UserDto = { id: System.Guid }

    let useAtStartOfWord () =
        let user: UserDto = { id = Guid.Empty }
        sprintf "%A" user.id

    let public sampleKeywords (error: exn) =
        begin
            printfn "%A" Keywords.union
            printfn "%A" Keywords.property
            printfn "%A" Keywords.anotherProperty

            let a = true or false
            let b = lazy function | Some x -> x | None -> 0
            let mutable value = [ yield! [ yield 42 ] ]
            let b = enum<Color>(3)
            let s = [| 42 |]
            use ptr = fixed &s.[0]
            try
                new AType ()
            finally
                while true do
                    ()
        end

    let rec private myFunc (arg : int) =
        for x = 1 to 10 do
            for y = 10 downto 1 do
                for z in Seq.empty do
                    ()
                done

        match arg with | 42 -> () | _ -> assert true

    let inline internal myInternalFunc () =
        async {
            let b : IEnumerable = upcast Seq.empty
            let c : int seq = downcast b

            let x = if Seq.isEmpty c then 1 elif Seq.contains 2 c then 2 else 3
            use! a = async {
                let a: IDisposable = null
                return a }
            return! async { return () }
        }
