### .NET tool to modify solution (slnx) file

Installation:

```shell
dotnet tool install --global VijayAnand.Slnx
```

Supported Commands:

|Command|Description|
|:---:|:---|
|new|Create an empty solution containing no projects.|
|add|Adda a project to a solution file.|
|list|List all projects in a solution file.|
|remove|Removes a project from a solution file.|

Code Samples:

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
