module Cake.GithubUtility.Github

open Octokit
open System.Linq
open System.IO
open System.Collections.Generic
open System

let createRawPath owner repo path =
      let br = "master"
      sprintf "https://raw.githubusercontent.com/%s/%s/%s/%s" owner repo br path


let downloadLatestAssets(owner: string, repo: string, pass: string) =
    let createToken(pass) = 
        new Credentials(pass)

    let product = ProductHeaderValue("my-cool-app")
    let client = GitHubClient(product)
    client.Credentials <- createToken pass

    let download (asset: ReleaseAsset) =
        let temp = Path.Combine(Path.GetTempPath().TrimEnd('\\'), asset.Name);
        let dict = Dictionary<string,string>()
        let mimeType = "application/octet-stream"
        let response = client.Connection.Get<byte array>(Uri(asset.Url), dict, mimeType).Result
        do
            use file = new FileStream(temp, FileMode.Create)
            file.Write(response.Body, 0, response.Body.Length)
        (temp)


    let release = client.Repository.Release.GetAll(owner, repo).Result
    let last =  release.FirstOrDefault()

    let result = 
        match obj.ReferenceEquals(last, null) with
        | true ->
            []
        | false ->
            last.Assets |> Seq.map download |> Seq.toList

    (result)

