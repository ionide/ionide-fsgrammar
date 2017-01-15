module SampleCode.SimpleTypes

type Alias = int

type Alpha = class end

type LightDU =
    | CaseA
    | CaseB

type Underscore_Name = | Underscore_Name of string


type Class1() =
    member this.X = "F#"


type FancyClass(thing:int) as xxx =

    let pf() = xxx.Test()

    member xxx.Test() = "F#"

module test =
    let t = 1

open test