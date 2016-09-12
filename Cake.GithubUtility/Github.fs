module Cake.GithubUtility.Github

let createRawPath owner repo path =
      let br = "master"
      sprintf "https://raw.githubusercontent.com/%s/%s/%s/%s" owner repo br path



