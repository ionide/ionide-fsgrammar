open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators
open BlackFox.Fake
open Fake.JavaScript

[<EntryPoint>]
let main argv =

    argv
    |> Array.toList
    |> Context.FakeExecutionContext.Create false "build.fsx"
    |> Context.RuntimeContext.Fake
    |> Context.setExecutionContext

    /// Stores F#, Paket, FsLex & FsYacc Syntax Definition Files
    let syntaxDir           = "grammars"
    /// Location of the FSharp-SyntaxTest VSCode Extension
    let extensionDir        = "fsharp.syntaxtest"
    /// FSharp-SyntaxTest will load the Syntax Definition files in this dir
    let extensionSyntaxDir  = extensionDir</>"syntaxes"

    Target.initEnvironment ()

    let copyGrammar = BuildTask.create "CopyGrammar" [ ] {
        Trace.trace "Copying F# Syntax Definition Files\n"
        Directory.ensure extensionSyntaxDir
        Shell.cleanDir extensionSyntaxDir
        Shell.copyFiles extensionSyntaxDir [
            syntaxDir </> "fsharp.fsi.json"
            syntaxDir </> "fsharp.fsl.json"
            syntaxDir </> "fsharp.fsx.json"
            syntaxDir </> "fsharp.json"
            syntaxDir </> "paket.dependencies.json"
            syntaxDir </> "paket.lock.json"
        ]
    }

    let buildExtension = BuildTask.create "BuildExtension" [ copyGrammar ] {
        Trace.trace "Building VSCode Extension - FSharp-SyntaxTest"
    }

    BuildTask.runOrList ()

    0
