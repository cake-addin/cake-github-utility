#tool "nuget:?package=Fixie"
#addin "nuget:?package=Cake.Watch"
#addin "nuget:?package=Cake.SquareLogo"

Task("Create-Logo").Does(() => {
    var settings = new LogoSettings { Background = "Black" };
    CreateLogo("G", "Assets/logo.png", settings);
});

var target = Argument("target", "default");
RunTarget(target);