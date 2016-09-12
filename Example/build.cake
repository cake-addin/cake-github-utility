// #r "../Cake.GithubUtility/bin/Debug/FSharp.Core.dll"
#r "../Cake.GithubUtility/bin/Debug/Cake.GithubUtility.dll"

using Cake.GithubUtility.GithubAlias;

Task("Raw").Does(() => {
    var raw = CreateRawPath("wk-j", "cake-github-utility", "Assets/logo.png");
    Console.WriteLien(raw);
});

var target = Argument("target", "default");
RunTarget(target);