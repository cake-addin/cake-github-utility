#r "../src/Cake.GithubUtility/obj/Release/netstandard2.0/Cake.GitHubUtility.dll"
#r "../publish/Octokit.dll"

open Cake.GithubUtility.Github

let raw = createRawPath "wk-j" "cake-github-utility" "Assets/logo.png"
printfn "%A" raw

downloadLatestAssets ("bcircle", "capture-service", (System.Environment.GetEnvironmentVariable("GITHUB_TOKEN")))
|> printfn "%A"
