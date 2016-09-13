## Cake.GithubUtility

![](Assets/logo.png)

## Install

```
#addin "nuget:?package=Cake.GithubUtility"
```

## Create raw path

```csharp
Task("Create-Raw-Path").Does(() => {
    var raw = CreateRawPath("cake-addin", "cake-github-utility", "Assets/logo.png");
    var rs = raw == "https://raw.githubusercontent.com/cake-addin/cake-github-utility/master/Assets/logo.png";
});
```

