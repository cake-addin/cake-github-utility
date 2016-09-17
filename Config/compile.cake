Task("Build-Release").Does(() => {
    DotNetBuild(solution, settings =>
        settings.SetConfiguration("Release")
        .WithTarget("Build")
        .WithProperty("TreatWarningsAsErrors","true"));
});

Task("Build-Debug").Does(() => {
    DotNetBuild(solution, settings =>
        settings.SetConfiguration("Debug")
        .WithTarget("Build")
        .WithProperty("TreatWarningsAsErrors","true"));
});
