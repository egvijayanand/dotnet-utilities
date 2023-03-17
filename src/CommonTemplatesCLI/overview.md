### Common CLI Templates

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
