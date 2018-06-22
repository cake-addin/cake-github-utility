
var project = "src/Cake.GitHubUtility";

Task("Build").Does(() => {
    DotNetCoreBuild(project,  new DotNetCoreBuildSettings {
        Configuration = "Release"
    });
});

Task("Publish").Does(() => {
    CleanDirectory("publish");
    DotNetCorePublish(project, new DotNetCorePublishSettings {
        OutputDirectory = "publish"
    });
});

Task("Pack").Does(() => {
    CleanDirectory("publish");
    DotNetCorePack(project, new DotNetCorePackSettings {
        OutputDirectory = "publish"
    });
});

Task("Publish-Nuget")
    .IsDependentOn("Pack")
    .Does(() => {
        var npi = EnvironmentVariable("npi");
        var nupkg = new DirectoryInfo("publish").GetFiles("*.nupkg").LastOrDefault();
        var package = nupkg.FullName;
        NuGetPush(package, new NuGetPushSettings {
            Source = "https://api.nuget.org/v3/index.json",
            ApiKey = npi
        });
});

var target = Argument("target", "default");
RunTarget(target);