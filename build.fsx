#r "paket: groupref netcorebuild //"
#load ".fake/build.fsx/intellisense.fsx"
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators
open BlackFox.Fake
open Fake.JavaScript

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
    Npm.install (fun o -> { o with WorkingDirectory = extensionDir })
}

Target.create "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    |> Shell.cleanDirs
)

Target.create "Build" (fun _ ->
    !! "src/**/*.*proj"
    |> Seq.iter (DotNet.build id)
)

BuildTask.runOrList()
