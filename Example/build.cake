#r "../Cake.GithubUtility/bin/Debug/FSharp.Core.dll"
#r "../Cake.GithubUtility/bin/Debug/Cake.GithubUtility.dll"

var pass = EnvironmentVariable("ghp");

using Cake.GithubUtility.GithubAlias;

Task("Raw").Does(() => {
    var raw = CreateRawPath("cake-addin", "cake-github-utility", "Assets/logo.png");
    Console.WriteLine(raw);
});

Task("Download").Does(() => {
    var assets = DownloadLatestAssets("bcircle", "easy-capture", pass);
    assets.ToList().ForEach(Console.WriteLine);
});

var target = Argument("target", "default");
RunTarget(target);