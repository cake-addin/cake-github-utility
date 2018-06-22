#addin "FSharp.Core&Version=4.3.4"
#addin "Octokit&0.30.0"
#addin "nuget:http://192.168.0.109:7777/nuget?package=Cake.GitHubUtility"

var pass = EnvironmentVariable("GITHUB_TOKEN");

Task("Raw").Does(() => {
    var raw = CreateRawPath("wk-j", "cake-github-utility", "Assets/logo.png");
    Console.WriteLine(raw);
});

Task("Download").Does(() => {
    var assets = DownloadLatestAssets("bcircle", "easy-capture", pass);
    assets.ToList().ForEach(Console.WriteLine);
});

var target = Argument("target", "default");
RunTarget(target);