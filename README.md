# Files Folders Utility

[About](#about)&nbsp;|
[Technology](#technology)&nbsp;|
[Installation](#technology)&nbsp;|
[Configuration](#technology)

[![NuGet](https://img.shields.io/nuget/v/dotnet-directory-files-utility?style=flat)](https://www.nuget.org/packages/dotnet-directory-files-utility)
[![GitHub](https://img.shields.io/github/license/quemuel-nassor/DotnetCoreDirectoriesFilesUtility?style=flat)](/LICENSE.txt)
[![Nuget](https://img.shields.io/nuget/dt/dotnet-directory-files-utility?color=informational&style=flat)](https://www.nuget.org/packages/dotnet-directory-files-utility)

##  About
This is a utility to aid in directory management for .NET Web or .NET API applications and includes tools to conveniently look up physical and server paths based on mapped directories

## Technology

[.NET Standard 2.0](https://learn.microsoft.com/pt-br/dotnet/standard/net-standard?tabs=net-standard-2-0)

## Installation
To install and use this tool, you will need to install the [nuget package](https://www.nuget.org/packages/dotnet-directory-files-utility) and register the service in your application settings.

## Configuration
A good practice recommendation is to store the names of the directories you want to map in constants, so it will be easier to manage the directories later, for example.

```c#
public static class Consts
{
    public const string FilesFolder = "Files";
    public const string TempFolder = "Temp";
    public const string ImagesFolder = "Images";
}
```

After downloading and installing the package, you need to register the service to use it in your application, it is mandatory to add at least one directory in the mapping settings, in case of mapping subdirectories the name of the parent directory must always precede the name of the child directory as example to follow:

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.RegisterDirectoriesFilesUtility(o =>
    {
        o.AddFolder(parent: Consts.FilesFolder, name: Consts.ImagesFolder);
        o.AddFolder(name: Consts.TempFolder);
        o.AddFolder(name: Consts.FilesFolder);
    });
}
```

## Samples
After registering the service, you can use it like any other dependency injection in the context of your application, as shown in the following example.

```c#
public class HomeController : Controller
{
    private readonly ILoggerHomeController> _logger;
    private readonly IDirectoriesFilesUtility _utility;

    public HomeController(ILoggerHomeController> logger, IDirectoriesFilesUtility utility)
    {
        _utility = utility;
        _logger = logger;
    }

    public IActionResult Index()
    {
        HttpClient cli = new HttpClient();

        Stream sampleStream = cli
        .GetStreamAsync("https://images.pexels.com/photos/15476378/pexels-photo-15476378.jpeg")
        .Result;

        //you can omit the parameter if you want to get the directory only
        string destination = _utility.GetPath(Consts.FilesFolder, "sample.jpg");
        string source = _utility.GetPath(Consts.ImagesFolder, "sample.jpg");
        string sourceUrl = _utility.GetUrl(Consts.ImagesFolder, "sample.jpg");

        string streamName = _utility.WriteFile(sampleStream, source).Result;
        string copyName = _utility.CopyFile(source, destination);
        string moveName = _utility.MoveFile(source, destination);

        return View();
    }
}
```