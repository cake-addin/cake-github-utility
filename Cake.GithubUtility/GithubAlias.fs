module Cake.GithubUtility.GithubAlias

open Cake.Core
open Cake.Core.Annotations
open System.Runtime.CompilerServices
open Cake.GithubUtility.Github

[<Extension>]
[<AbstractClass>]
[<Sealed>]
type GithubExtension =

      [<CakeMethodAlias>]
      [<Extension>]
      static member CreateRawPath(context: ICakeContext, owner, repo, path) =
            createRawPath owner repo path