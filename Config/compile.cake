Task("Build-Release").Does(() => {
    DotNetBuild(solution, settings =>
        settings.SetConfiguration("Release")
        .WithTarget("Build")
        .WithProperty("TreatWarningsAsErrors","true"));
});
