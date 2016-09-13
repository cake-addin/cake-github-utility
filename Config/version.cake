using System.Diagnostics;

Func<string> getVersion = () => {
    return FileVersionInfo.GetVersionInfo(debugDll).FileVersion;
    //return "0.4.0.0";
};