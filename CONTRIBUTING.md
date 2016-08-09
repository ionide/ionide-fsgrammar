[Visual Studio Code is required to use FSharp.SyntaxTest](https://code.visualstudio.com/download)

FSharp.SyntaxTest is a lightweight extension that allows for fast testing of modifications to the
syntax definiton files located in `/grammar/` 

Open VSCode at the repository root and use either `F5` or `> Start Debugging` to start the extension host
which will open at `/sample-code/`


![](http://i.imgur.com/QKTVUzR.gif)


## Important Notes
  
- Only modifications made to the syntax files in `/grammar/` will be tracked by Git
- If you're going to add more src files to `/sample-code/` remember to add the files to `SampleCode.fsproj`
- You may need to close and restart the extension host before changes to the syntax definitions are accurately displayed
- [Reference the F# Language Spec for detail on the syntax grammar](http://fsharp.org/specs/language-spec/4.0/FSharpSpec-4.0-latest.pdf#page=320)
  


## Roadmap

- Upgrade FSharp.SyntaxTest with functionality from [vscode-textmate npm package](https://www.npmjs.com/package/vscode-textmate)
for more in-depth information about which tokens are being created
- Add Syntax Grammar for [FsYacc](https://github.com/fsprojects/FsLexYacc)
- Support XML syntax highlighting in documentation `///` comments?
- Support Markdown syntax highlighting in documentation and block `(* *)` comments?
 
