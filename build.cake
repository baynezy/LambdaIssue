var target = Argument("target", "Package-Lambda-CI");
var configuration = Argument("configuration", "Release");
var versionNumber = Argument("versionNumber", "0.1.0");
var projectName = "ProfileAPI";
var solutionFolder = "./";
var publishSourceLocation = "./src/" + projectName + "/bin/Release/net6.0/publish";
var outputFolder = "./lambda-publish";
var appProjectFolder = "./src/" + projectName;
var appProject = appProjectFolder + "/" + projectName + ".csproj";

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(publishSourceLocation);
        CleanDirectory(outputFolder);
    });

Task("Package-Lambda-Only")
    .Does(() =>
    {
        CreateDirectory(outputFolder);
        Zip(publishSourceLocation, outputFolder + "/lambda.zip");
    });

Task("Package-Lambda-CI")
    .IsDependentOn("Net6-Fix")
    .IsDependentOn("Package-Lambda-Only");

//https://learn.microsoft.com/en-us/dotnet/core/compatibility/sdk/6.0/publish-readytorun-requires-restore-change
Task("Net6-Fix")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetPublish(appProject, new DotNetPublishSettings
        {
            NoRestore = false,
            NoBuild = false,
            Configuration = configuration,
            OutputDirectory = publishSourceLocation
        });
    });

RunTarget(target);