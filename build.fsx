//--------------------------------------------------------//
// Ionide-FsGrammar - FSharp.SyntaxTest FAKE Build Script //
//--------------------------------------------------------//

// This build script is run inside VSCode when `F5` is used to Launch the Extension

#r @"packages/FAKE/tools/FakeLib.dll"

open System
open Fake
open Fake.ProcessHelper

System.IO.Directory.SetCurrentDirectory __SOURCE_DIRECTORY__

/// Stores F#, Paket, FsLex & FsYacc Syntax Definition Files  
let syntaxDir           = "grammar"
/// Location of the FSharp-SyntaxTest VSCode Extension    
let extensionDir        = "fsharp.syntaxtest"
/// FSharp-SyntaxTest will load the Syntax Definition files in this dir    
let extensionSyntaxDir  = extensionDir</>"syntaxes"


let CopyGrammar & cg = "CopyGrammar" 
Target cg  (fun _ ->
    trace "Copying F# Syntax Definition Files\n"
    ensureDirectory extensionSyntaxDir
    CleanDir extensionSyntaxDir
    CopyFiles extensionSyntaxDir [
        syntaxDir </> "fsharp.fsi.json"
        syntaxDir </> "fsharp.fsl.json"
        syntaxDir </> "fsharp.fsx.json"
        syntaxDir </> "fsharp.json"
    ]
)

let platformTool tool path =
    isUnix |> function | true -> tool | _ -> path

/// Node Package Manager
let npmTool =    
    platformTool "npm" ("packages"</>"Npm.js"</>"tools"</>"npm.cmd" |> FullName)


let run cmd args workingDir =
    if  execProcess (fun info ->
        if not (String.IsNullOrWhiteSpace workingDir) then 
            info.WorkingDirectory <- workingDir
        info.FileName <- cmd    
        info.Arguments <- args
        ) System.TimeSpan.MaxValue = false then
        traceError <| sprintf "Error while running '%s' with args: %s" cmd args


let BuildExtension & bext = "BuildExtension" 
Target bext  (fun () ->
    trace "Building VSCode Extension - FSharp-SyntaxTest"
    // install any necessary dependencies for the FSharp-SyntaxTest Extension
    run npmTool "install --verbose" extensionDir   
)


let Notify & nt = "Notify" 
Target nt  (fun () ->
    traceLine ()
    traceError <|
        sprintf"\n\
        This Build Script is not intended to be run from the commandline\n\n\
        Launch VSCode with \n\
        -   code %s\n\n\
        and start the extension host with `F5` to run FSharp.SyntaxTest\n\n" __SOURCE_DIRECTORY__
    traceLine ()
)


/// Visual Studio Code
let codeTool =
    platformTool "code" (ProgramFilesX86</>"Microsoft VS Code"</>"bin/code.cmd")


CopyGrammar ==> BuildExtension

RunTargetOrDefault Notify
