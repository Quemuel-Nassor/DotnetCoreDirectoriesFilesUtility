<h1 align="center">Files Folders Utility</h1>
<p align="center">
<a href="#about">About</a>&nbsp;|
<a href="#technology">Technology</a>&nbsp;|
<a href="#technology">Installation</a>&nbsp;|
<a href="#technology">Configuration</a>
</p>

<div align="center">

[![NuGet](https://img.shields.io/nuget/v/dotnet-directory-files-utility?style=plastic)][nuget-pkg] 
[![GitHub](https://img.shields.io/github/license/quemuel-nassor/DotnetCoreDirectoriesFilesUtility?style=plastic)](/LICENSE.txt) 
[![Nuget](https://img.shields.io/nuget/dt/dotnet-directory-files-utility?color=informational&style=plastic)][nuget-pkg]
</div>

## <span id="about"> About</span>
<p>This is a utility to aid in directory management for .NET Web or .NET API applications and includes tools to conveniently look up physical and server paths based on mapped directories</p>

## <span id="technology">Technology</span>

[.NET Standard 2.0](https://learn.microsoft.com/pt-br/dotnet/standard/net-standard?tabs=net-standard-2-0)

## <span id="installation">Installation</span>
<p>To install and use this tool, you will need to install the [nuget package][nuget-pkg] and register the service in your application settings.</p>

## <span id="configuration">Configuration</span>
<p>A good practice recommendation is to store the names of the directories you want to map in constants, so it will be easier to manage the directories later, for example.</p>

```c#
public static class Consts
{
    public const string FilesFolder = "Files";
    public const string TempFolder = "Temp";
    public const string ImagesFolder = "Images";
}
```

<p>After downloading and installing the package, you need to register the service to use it in your application, it is mandatory to add at least one directory in the mapping settings, in case of mapping subdirectories the name of the parent directory must always precede the name of the child directory as example to follow:</p>

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

## <span id="samples">Samples</span>
<p>After registering the service, you can use it like any other dependency injection in the context of your application, as shown in the following example.</p>

```c#
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDirectoriesFilesUtility _utility;

    public HomeController(ILogger<HomeController> logger, IDirectoriesFilesUtility utility)
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

[nuget-pkg]:https://www.nuget.org/packages/dotnet-directory-files-utility