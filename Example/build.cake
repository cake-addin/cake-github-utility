// #r "../Cake.GithubUtility/bin/Debug/FSharp.Core.dll"
#r "../Cake.GithubUtility/bin/Debug/Cake.GithubUtility.dll"

using Cake.GithubUtility.GithubAlias;

Task("Raw").Does(() => {
    var raw = CreateRawPath("cake-addin", "cake-github-utility", "Assets/logo.png");
    Console.WriteLine(raw);
});

var target = Argument("target", "default");
RunTarget(target);