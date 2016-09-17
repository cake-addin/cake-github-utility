#tool "nuget:?package=Fixie"
#tool "nuget:?package=Mono.TextTransform"
#addin "nuget:?package=Cake.Watch"
#addin "nuget:?package=Cake.SquareLogo"

#r "./Cake.GithubUtility/bin/Debug/Cake.GithubUtility.dll"
using Cake.GithubUtility.GithubAlias;

var id = "Cake.GithubUtility";
var solution = $"{id}.sln";
var testDll = $"{id}.Tests/bin/Debug/{id}.Tests.dll";
var debugDll = $"{id}/bin/Debug/{id}.dll";
var releaseDll = $"{id}/bin/Release/{id}.dll";
var npi = EnvironmentVariable("npi");

var title = $"{id}";
var description = "Github utility for Cake";
var projectUrl = "https://github.com/cake-addin/cake-github-utility";
var iconUrl = CreateRawPath("cake-addin", "cake-github-utility", "Assets/logo.png");
var releaseNotes = new[] { "New version" };
var tags = new [] { "Cake", "Github" };

var files = new [] {
    releaseDll,
    releaseDll.Replace("Cake.GithubUtility.dll", "FSharp.Core.dll")
};

#load "Config/version.cake"
#load "Config/compile.cake"
#load "Config/nuget.cake"

Task("Create-Logo").Does(() => {
    var settings = new LogoSettings { Background = "Black" };
    CreateLogo("G", "Assets/logo.png", settings);
});

Task("Example")
    .IsDependentOn("Build-Debug")
    .Does(() => {
        var win = IsRunningOnWindows();
        var ps = win ? "tools/cake/cake.exe" : "mono";
        var args = win ? "" : "tools/cake/cake.exe";
        var example = Argument("example", "");
        var settings = new ProcessSettings {
            Arguments = args + " ./Example/build.cake -target=" + example
        };
        StartProcess(ps, settings);
    });


var target = Argument("target", "default");
RunTarget(target);