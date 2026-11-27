module Highlighting

#nowarn "40"

open System
open System.Collections.Generic

// Function names: a `let` name followed by parameters, members, operators, active patterns
let value = 42
let add x y = x + y
let rec loop (n: int) acc = if n = 0 then acc else loop (n - 1) (acc + n)
let inline private twice f x = f (f x)
let ``name with spaces: (a) -> b`` () = ()
let (|Even|Odd|) n = if n % 2 = 0 then Even else Odd
let (|Int|_|) (s: string) =
    match Int32.TryParse s with
    | true, i -> Some i
    | _ -> None
let (>>=) m f = Option.bind f m

// Union cases in declarations and patterns
type Shape =
    | Circle of radius: float
    | Rectangle of width: float * height: float
    | Empty

type Color =
    | Red = 0
    | Green = 1

let area shape =
    match shape with
    | Circle r -> Math.PI * r * r
    | Rectangle(w, h) -> w * h
    | Empty -> 0.0

let describe = function
    | Some (Ok x) -> string x
    | Some (Error e) -> failwith e
    | None -> raise (ArgumentException "none")

// Members, auto-properties, accessors
type Counter(start: int) =
    let mutable count = start
    member val Name = "counter" with get, set
    member _.Count = count
    member this.Add(n: int) = count <- count + n; this
    member x.Value
        with get () = count
        and set v = count <- v
    static member (+) (a: Counter, b: Counter) = Counter(a.Count + b.Count)
    override _.ToString() = sprintf "%s=%d" "count" count

[<AbstractClass>]
type Animal() =
    abstract Sound: string
    abstract Legs: int with get, set

// Types in expressions
let o = Counter(1) :> obj
let isCounter = match o with :? Counter as c -> c.Count > 0 | _ -> false
let list = ResizeArray<string>()
let dict = Dictionary<string, int list>()
let tType = typeof<Map<string, int>>
let zero = Unchecked.defaultof<int>
let sb = new Text.StringBuilder(16)
let suffixes = (0y, 1uy, 2s, 3us, 4L, 5UL, 6n, 7un)
let money = 10.5M
let nonNull (x: string | null) = match x with null -> "" | s -> s
let names = [ "a"; "b" ] |> List.map _.ToUpper()

// Computation expressions and query
let work = async { return 1 }
let pipeline = task {
    let! x = Threading.Tasks.Task.FromResult 1
    and! y = Threading.Tasks.Task.FromResult 2
    while! Threading.Tasks.Task.FromResult false do
        ()
    return x + y
}

let adults (people: (string * int) list) =
    query {
        for (name, age) in people do
        where (age >= 18)
        sortBy name
        select name
    }

let grouped (people: (string * int) list) =
    query {
        for (name, age) in people do
        groupBy age into g
        select (g.Key, Seq.length g)
    }

#if DEBUG && !RELEASE
let mode = "debug"
#else
let mode = "release"
#endif
