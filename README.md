<h1 align="center">Files Folders Utility</h1>
<p align="center">
<a href="#about">About</a>&nbsp;|
<a href="#technology">Technology</a>&nbsp;|
<a href="#technology">Installation</a>&nbsp;|
<a href="#technology">Configuration</a>
</p>

<p align="center">
<img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/quemuel-nassor/DotnetCoreDirectoriesFilesUtility?color=orange&style=plastic">
<img alt="Nuget" src="https://img.shields.io/nuget/v/dotnet-directory-files-utility?style=plastic">
<img alt="GitHub" src="https://img.shields.io/github/license/quemuel-nassor/DotnetCoreDirectoriesFilesUtility?style=plastic">
<img alt="GitHub top language" src="https://img.shields.io/github/languages/top/quemuel-nassor/DotnetCoreDirectoriesFilesUtility?color=yellow&style=plastic">
</p>

<h2>
<a id="about" class="anchor" aria-hidden="true" href="#about">
<svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true">
<path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path>
</svg>
</a>
About</h2>
This is a utility to aid in directory management for .NET Web or .NET API applications and includes tools to conveniently look up physical and server paths based on mapped directories

<h2>
<a id="technology" class="anchor" aria-hidden="true" href="#technology">
<svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true">
<path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path>
</svg>
</a>
Technology</h2>

[.NET Standard 2.0](https://learn.microsoft.com/pt-br/dotnet/standard/net-standard?tabs=net-standard-2-0)

<h2>
<a id="installation" class="anchor" aria-hidden="true" href="#installation">
<svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true">
<path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path>
</svg>
</a>
Installation</h2>

To install and use this tool, you will need to install the [nuget package][nuget-pkg] and register the service in your application settings.

<h2>
<a id="configuration" class="anchor" aria-hidden="true" href="#configuration">
<svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true">
<path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path>
</svg>
</a>
Configuration</h2>
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

<h2>
<a id="samples" class="anchor" aria-hidden="true" href="#samples">
<svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true">
<path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path>
</svg>
</a>
Samples</h2>
After registering the service, you can use it like any other dependency injection in the context of your application, as shown in the following example.

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
        .GetStreamAsync("https://cdn.pixabay.com/photo/2016/09/21/04/46/barley-field-1684052_960_720.jpg")
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