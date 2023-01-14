#addin nuget:?package=Cake.FileHelpers&version=6.0.0

var target = Argument<string>("target", "Default");
var project = Argument<string>("project", "ChickAndPaddy");
var @namespace = Argument<string>("namspace", "ChickAndPaddy");
var feature = Argument<string>("feature", "FeatureX");
var model = Argument<string>("model", string.Empty);
var forced = Argument<bool>("forced", false);

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

const string FEATURE_FODLER_PATH_TEMPLATE="./src/{0}/Features/{1}";

Task("popup")
    .Does(() =>
{
    var page = Argument<string>("popup", string.Empty);
    if (string.IsNullOrWhiteSpace(page)) {
        page = Argument<string>("name");
    }

    var featureFolderPath = string.Format(FEATURE_FODLER_PATH_TEMPLATE, project, feature);
    Information("Feature folder path: " + featureFolderPath);
    
    if (!DirectoryExists(featureFolderPath)) {
        CreateDirectory(featureFolderPath);
    }

    var pagesFolderPath = $"{featureFolderPath}/Popups";

    if (!DirectoryExists(pagesFolderPath)) {
        CreateDirectory(pagesFolderPath);
    }

    var pageXamlFilePath = $"{pagesFolderPath}/{page}Popup.xaml";

    if (!forced && FileExists(pageXamlFilePath)) {
        Warning($"Popup {page}Popup exists!!!!!");
        return;
    }

    Information($"\n>> Generate >> {page}Popup.xaml");
    FileWriteText($"{pagesFolderPath}/{page}Popup.xaml", $@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<app:BasePage 
    xmlns=""http://schemas.microsoft.com/dotnet/2021/maui""
    xmlns:x=""http://schemas.microsoft.com/winfx/2009/xaml""
    xmlns:app=""clr-namespace:{@namespace}""
    x:Class=""{@namespace}.{page}Popup""
    x:DataType=""app:{page}PopupViewModel""
    Title=""{page}"">
    <VerticalStackLayout>
        <Label 
            Text=""This is {page}!""
            VerticalOptions=""Center"" 
            HorizontalOptions=""Center"" />
    </VerticalStackLayout>
</app:BasePage>");

    Information($"\n>> Generate >> {page}Popup.xaml.cs");
    FileWriteText($"{pagesFolderPath}/{page}Popup.xaml.cs", $@"namespace {@namespace};
public partial class {page}Popup
{{
    public {page}Popup({page}PopupViewModel vm)
    {{
        InitializeComponent();

        BindingContext = vm;
    }}
}}");

    Information($"\n>> Generate >> {page}PopupViewModel.cs");
    FileWriteText($"{pagesFolderPath}/{page}PopupViewModel.cs", $@"namespace {@namespace};
public partial class {page}PopupViewModel : NavigationAwareBaseViewModel
{{
    public {page}PopupViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {{
    }}
}}");
});

Task("page")
    .Does(() =>
{
    var page = Argument<string>("page", string.Empty);
    if (string.IsNullOrWhiteSpace(page)) {
        page = Argument<string>("name");
    }

    var featureFolderPath = string.Format(FEATURE_FODLER_PATH_TEMPLATE, project, feature);
    Information("Feature folder path: " + featureFolderPath);
    
    if (!DirectoryExists(featureFolderPath)) {
        CreateDirectory(featureFolderPath);
    }

    var pagesFolderPath = $"{featureFolderPath}/Pages";

    if (!DirectoryExists(pagesFolderPath)) {
        CreateDirectory(pagesFolderPath);
    }

    var pageXamlFilePath = $"{pagesFolderPath}/{page}Page.xaml";

    if (!forced && FileExists(pageXamlFilePath)) {
        Warning($"Page {page}Page exists!!!!!");
        return;
    }

    Information($"\n>> Generate >> {page}Page.xaml");
    FileWriteText($"{pagesFolderPath}/{page}Page.xaml", $@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<app:BasePage 
    xmlns=""http://schemas.microsoft.com/dotnet/2021/maui""
    xmlns:x=""http://schemas.microsoft.com/winfx/2009/xaml""
    xmlns:app=""clr-namespace:{@namespace}""
    x:Class=""{@namespace}.{page}Page""
    x:DataType=""app:{page}PageViewModel""
    Title=""{page}"">
    <VerticalStackLayout>
        <Label 
            Text=""This is {page}!""
            VerticalOptions=""Center"" 
            HorizontalOptions=""Center"" />
    </VerticalStackLayout>
</app:BasePage>");

    Information($"\n>> Generate >> {page}Page.xaml.cs");
    FileWriteText($"{pagesFolderPath}/{page}Page.xaml.cs", $@"namespace {@namespace};
public partial class {page}Page
{{
    public {page}Page({page}PageViewModel vm)
    {{
        InitializeComponent();

        BindingContext = vm;
    }}
}}");

    Information($"\n>> Generate >> {page}PageViewModel.cs");
    FileWriteText($"{pagesFolderPath}/{page}PageViewModel.cs", $@"namespace {@namespace};
public partial class {page}PageViewModel : NavigationAwareBaseViewModel
{{
    public {page}PageViewModel(
        IAppNavigator appNavigator
    ) : base(appNavigator)
    {{
    }}
}}");
});

Task("model")
    .Does(() =>
{
    var name = Argument<string>("model", string.Empty);
    if (string.IsNullOrWhiteSpace(name)) {
        name = Argument<string>("name");
    }
    var form = Argument<bool>("form", false);

    var featureFolderPath = string.Format(FEATURE_FODLER_PATH_TEMPLATE, project, feature);
    Information("Feature folder path: " + featureFolderPath);
    
    if (!DirectoryExists(featureFolderPath)) {
        CreateDirectory(featureFolderPath);
    }

    var modelsFolderPath = $"{featureFolderPath}/Models";

    if (!DirectoryExists(modelsFolderPath)) {
        CreateDirectory(modelsFolderPath);
    }

    var modelSuffix = form ? "FormModel" : "Model";
    var modelFilePath = $"{modelsFolderPath}/{name}{modelSuffix}.cs";

    if (!forced && FileExists(modelFilePath)) {
        Warning($"Model {name}{modelSuffix} exists!!!!!");
        return;
    }

    Information($"\n>> Generate >> {name}{modelSuffix}.cs");
    FileWriteText($"{modelsFolderPath}/{name}{modelSuffix}.cs", $@"namespace {@namespace};
public partial class {name}{modelSuffix} : Base{modelSuffix}
{{
}}");
});


Task("Default")
    .IsDependentOn("page");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);

