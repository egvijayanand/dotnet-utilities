## .NET Utilities

Useful .NET Utilities, published as NuGet package(s), that helps in reducing repetitive tasks.

For now, Font Awesome (free version) and Google Material Design icon font glyphs as a NuGet package to refer in any .NET application.

And frequently used constants, extensions and methods now put together as one NuGet package so that no more code duplication and better reuse.

|Package Name|Version|
|:---:|:---:|
|[VijayAnand.CommonTemplates](https://www.nuget.org/packages/VijayAnand.CommonTemplates/)|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.CommonTemplates/?icon=nuget)](https://www.nuget.org/packages/VijayAnand.CommonTemplates/)|
|[VijayAnand.FontAwesome](https://www.nuget.org/packages/VijayAnand.FontAwesome/)|[![Font Awesome 5 LTS](https://badgen.net/badge/nuget/v1.0.7/blue?icon=nuget)](https://www.nuget.org/packages/VijayAnand.FontAwesome/1.0.7) [![Font Awesome 6 Latest](https://badgen.net/nuget/v/VijayAnand.FontAwesome/?icon=nuget)](https://www.nuget.org/packages/VijayAnand.FontAwesome/)|
|[VijayAnand.GoogleMaterial](https://www.nuget.org/packages/VijayAnand.GoogleMaterial/)|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.GoogleMaterial/?icon=nuget)](https://www.nuget.org/packages/VijayAnand.GoogleMaterial/)|
|[VijayAnand.Toolkit](https://www.nuget.org/packages/VijayAnand.Toolkit/)|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.Toolkit/?icon=nuget)](https://www.nuget.org/packages/VijayAnand.Toolkit/)|

### Package Details:

#### VijayAnand.CommonTemplates:

For now, a project template for defining a source generator to automate the source code generation and is named as `sourcegen`.

To support the incremental source generator, it takes the below optional parameter:

* `-inc` | `--incremental` - Default value is `false`.

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

Use the below .NET CLI command to create the project out these template:

```shell
dotnet new sourcegen -n XamlAutomation
```
Incremental Source Generator:
```shell
dotnet new sourcegen -n XamlAutomation -inc
```

#### VijayAnand.FontAwesome Package:

* v1 series compatible with Font Awesome 5 LTS fonts
* v2 series compatible with Font Awesome 6 fonts

Note for Font Awesome v6 glyph usage:

* Number fonts have been named as Number_0, Number_1, ...
* Letter fonts have been named as Letter_A, Letter_B, ...

Brands - `FontAwesome.Brands`

Regular - `FontAwesome.Regular`

Solid - `FontAwesome.Solid`

#### VijayAnand.GoogleMaterial Package:

Material - `Google.Material`

In both the above packages, class under each of the namespace mentioned is titled as `IconFont`

#### VijayAnand.Toolkit Package:

And the class is named as `Constants`, a static class with another nested static class named as `Ascii`

Within which all are `char` constants to refer the ASCII character set with meaningful names, covered with frequently used alias names too

Can be referenced with single static using statement as:

```CS
using static VijayAnand.Toolkit.Constants.Ascii;
```
