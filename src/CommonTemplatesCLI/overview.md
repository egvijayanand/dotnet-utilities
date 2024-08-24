### Common CLI Templates

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

#### Project Options:

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
