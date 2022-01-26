## .NET Utilities

Useful .NET Utilities, published as NuGet package(s), that helps in reducing repetitive tasks.

For now, FontAwesome (free version) and Google Material Design icon font glyphs as a NuGet package to refer in any .NET application.

And frequently used constants, extensions and methods now put together as one NuGet package so that no more code duplication and better reuse.

|Version|Icon Font|
|:---:|:---:|
|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.FontAwesome/)](https://www.nuget.org/packages/VijayAnand.FontAwesome/)|[FontAwesome](https://www.nuget.org/packages/VijayAnand.FontAwesome/)|
|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.GoogleMaterial/)](https://www.nuget.org/packages/VijayAnand.GoogleMaterial/)|[Google Material](https://www.nuget.org/packages/VijayAnand.GoogleMaterial/)|
|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.Helpers/)](https://www.nuget.org/packages/VijayAnand.Helpers/)|[VijayAnand Helpers](https://www.nuget.org/packages/VijayAnand.Helpers/)|

#### Namespace referenced:

Brands - `FontAwesome.Brands`

Regular - `FontAwesome.Regular`

Solid - `FontAwesome.Solid`

`Google.Material`

In both the packages, class under each of the above namespace is named as `IconFont`

`VijayAnand.Helpers` Package

And the class is named as `Constants`, a static class with another nested static class as `Ascii`

Within which all are `char` constants to refer the (visible) ASCII characters with proper names, covered with frequently used alias names too

Can be referenced with single static using statement as:

```CSharp
using static VijayAnand.Helpers.Constants.Ascii;
```
