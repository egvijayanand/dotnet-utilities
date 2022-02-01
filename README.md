## .NET Utilities

Useful .NET Utilities, published as NuGet package(s), that helps in reducing repetitive tasks.

For now, FontAwesome (free version) and Google Material Design icon font glyphs as a NuGet package to refer in any .NET application.

And frequently used constants, extensions and methods now put together as one NuGet package so that no more code duplication and better reuse.

|Package Name|Version|
|:---:|:---:|
|[VijayAnand.FontAwesome](https://www.nuget.org/packages/VijayAnand.FontAwesome/)|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.FontAwesome/)](https://www.nuget.org/packages/VijayAnand.FontAwesome/)|
|[VijayAnand.GoogleMaterial](https://www.nuget.org/packages/VijayAnand.GoogleMaterial/)|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.GoogleMaterial/)](https://www.nuget.org/packages/VijayAnand.GoogleMaterial/)|
|[VijayAnand.Toolkit](https://www.nuget.org/packages/VijayAnand.Toolkit/)|[![NuGet Package](https://badgen.net/nuget/v/VijayAnand.Toolkit/)](https://www.nuget.org/packages/VijayAnand.Toolkit/)|

### Package Details:

#### VijayAnand.FontAwesome Package:

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
