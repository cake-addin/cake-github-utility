Task("Publish-Nuget")
    .IsDependentOn("Create-Nuget-Package")
    .Does(() => {
        var nupkg = new DirectoryInfo("./nuget").GetFiles("*.nupkg").LastOrDefault();
        var package = nupkg.FullName;
        NuGetPush(package, new NuGetPushSettings {
            Source = "https://www.nuget.org/api/v2/package",
            ApiKey = npi
        });
    });

Task("Create-Nuget-Package")
    .IsDependentOn("Build-Release")
    .Does(() => {
        var nugetFiles = files.Select(file => {
                var full = new System.IO.FileInfo(file).FullName;
                Console.WriteLine(full);
                return new NuSpecContent { Source = full, Target = "bin/net45" };
        }).ToArray();

        CleanDirectory("./nuget");
        var version = getVersion();
        var settings   = new NuGetPackSettings {
                                        //ToolPath                = "./tools/nuget.exe",
                                        Id                      = id,
                                        Version                 = version,
                                        Title                   = title,
                                        Authors                 = new[] {"wk"},
                                        Owners                  = new[] {"wk"},
                                        Description             = description,
                                        //NoDefaultExcludes       = true,
                                        Summary                 = description,
                                        ProjectUrl              = new Uri(projectUrl),
                                        IconUrl                 = new Uri(projectUrl),
                                        LicenseUrl              = new Uri(projectUrl),
                                        Copyright               = "MIT",
                                        ReleaseNotes            = releaseNotes,
                                        Tags                    = tags,
                                        RequireLicenseAcceptance= false,
                                        Symbols                 = false,
                                        NoPackageAnalysis       = true,
                                        Files                   = nugetFiles,
                                        BasePath                = "./",
                                        OutputDirectory         = "./nuget"
                                    };
        NuGetPack(settings);
    });