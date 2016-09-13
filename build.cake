#tool "nuget:?package=Fixie"
#tool "nuget:?package=Mono.TextTransform"
#addin "nuget:?package=Cake.Watch"
#addin "nuget:?package=Cake.SquareLogo"

//Func<string, string> replace = (x) => x.Replace("{id}", "Cake.GithubUtility");

var id = "Cake.GithubUtility";

var solution = $"{id}.sln";
var testDll = $"{id}.Tests/bin/Debug/{id}.Tests.dll";
var debugDll = $"{id}/bin/Debug/{id}.dll";
var releaseDll = $"{id}/bin/Release/{id}.dll";
var npi = EnvironmentVariable("npi");

var title = $"{id}";
var description = "Github utility for Cake";
var projectUrl = "https://github.com/cake-addin/cake-github-utility";
var releaseNotes = new[] { "New version" };
var tags = new [] { "Cake", "Github" };

var files = new [] {
    releaseDll,
    releaseDll.Replace("Cake.GithubUtility.dll", "FSharp.Core.dll")
};

Task("Create-Logo").Does(() => {
    var settings = new LogoSettings { Background = "Black" };
    CreateLogo("G", "Assets/logo.png", settings);
});

#load "Config/version.cake"
#load "Config/compile.cake"
#load "Config/nuget.cake"

var target = Argument("target", "default");
RunTarget(target);