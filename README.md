## .NET Utilities

Useful .NET Utilities, published as NuGet package(s), that helps in reducing repetitive tasks.

For now, Font Awesome (free version) and Google Material Design icon font glyphs as a NuGet package to refer in any .NET application.

And frequently used constants, extensions and methods now put together as one NuGet package so that no more code duplication and better reuse.

|Package Name|Version|
|:---:|:---:|
|[VijayAnand.CommonTemplates](https://www.nuget.org/packages/VijayAnand.CommonTemplates/)|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.CommonTemplates/?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.CommonTemplates/)|
|[VijayAnand.Slnx](https://www.nuget.org/packages/VijayAnand.Slnx/)|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.Slnx/?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.Slnx/)|
|[VijayAnand.FontAwesome](https://www.nuget.org/packages/VijayAnand.FontAwesome/)|[![Font Awesome 5 LTS](https://badgen.net/badge/nuget/v1.0.7/blue?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.FontAwesome/1.0.7)  [![Font Awesome 6 Latest](https://badgen.net/nuget/v/VijayAnand.FontAwesome/?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.FontAwesome/)|
|[VijayAnand.GoogleMaterial](https://www.nuget.org/packages/VijayAnand.GoogleMaterial/)|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.GoogleMaterial/?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.GoogleMaterial/)|
|[VijayAnand.Toolkit](https://www.nuget.org/packages/VijayAnand.Toolkit/)|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.Toolkit/?icon=nuget&foo=bar)](https://www.nuget.org/packages/VijayAnand.Toolkit/)|

### VijayAnand.CommonTemplates

For now, a project template for defining a source generator to automate the source code generation and is named as `sourcegen`.

#### Install Package

To install the template NuGet package, use the below .NET CLI command:

```shell
dotnet new install VijayAnand.CommonTemplates
```

If you've already installed this package, then it can be updated to the latest version with the below command:

```shell
dotnet new update --check-only
```

```shell
dotnet new update
```

#### Project Options

*Note: These options may also be combined.*

To support the incremental source generator, it takes the below optional parameter:

* `-inc` | `--incremental` - Default value is `false`.

To support the XML-based solution file (`slnx`) format.

*This would be an explicit option since the SLNX feature is currently in the preview stage and is only supported on VS2022.*

* `-slnx` | `--use-slnx` - Default value is `false`.

Option to include a reference to the [PolySharp](https://www.nuget.org/packages/PolySharp/) NuGet package.

* `-ips` | `--include-polysharp` - Default value is `false`.

#### Command Usage

Use the below .NET CLI command to create the project out these template:

```shell
dotnet new sourcegen -n XamlAutomation
```

Incremental Source Generator:

```shell
dotnet new sourcegen -n XamlAutomation -inc
```

Use SLNX solution file format:

```shell
dotnet new sourcegen -n XamlAutomation -slnx
```

Include PolySharp NuGet package:

```shell
dotnet new sourcegen -n XamlAutomation -ips
```

### VijayAnand.Slnx CLI Tool Package

A .NET CLI tool to modify XML-based solution (`slnx`) files.

#### Install Tool

```shell
dotnet tool install -g VijayAnand.Slnx
```

#### Supported Commands

|Command|Description|
|:---:|:---|
|new|Create an empty solution containing no projects.|
|add|Add a project to a solution file.|
|list|List all projects in a solution file.|
|remove|Remove a project from a solution file.|

#### Command Usage

Works with an implicit solution file.

```shell
slnx new
```

```shell
slnx add Test.csproj
```

```shell
slnx list
```

```shell
slnx remove Test.csproj
```

Works with an explicit solution file too.

```shell
slnx new Test
```

```shell
slnx Test.slnx add Test.csproj
```

```shell
slnx Test.slnx list
```

```shell
slnx Test.slnx remove Test.csproj
```

### VijayAnand.FontAwesome Package

* v1 series compatible with Font Awesome 5 LTS font package
* v2 series compatible with Font Awesome 6 font package

Note for Font Awesome v6 glyph usage:

* Number fonts have been named as Number_0, Number_1, ...
* Letter fonts have been named as Letter_A, Letter_B, ...

Brands - `FontAwesome.Brands`

Regular - `FontAwesome.Regular`

Solid - `FontAwesome.Solid`

### VijayAnand.GoogleMaterial Package

Material - `Google.Material`

In both the above packages, class under each of the namespace mentioned is titled as `IconFont`

### VijayAnand.Toolkit Package

And the class is named as `Constants`, a static class with another nested static class named as `Ascii`

Within which all are `char` constants to refer the ASCII character set with meaningful names, covered with frequently used alias names too

Can be referenced with single static using statement as:

```CS
using static VijayAnand.Toolkit.Constants.Ascii;
```
