module GithubSpec
    
open Xunit
open Cake.GithubUtility.Github


[<Fact>]
let shouldDownloadAssets() =
    
    let pass = System.Environment.GetEnvironmentVariable("ghp");
    let rs = downloadLatestAssets("bcircle", "easy-capture", pass)
    
    ()

    
