Kendte fejl

1.:
C:\Program Files\dotnet\sdk\8.0.201\Sdks\Microsoft.NET.Sdk\targets\Microsoft.PackageDependencyResolution.targets(266,5): error NETSDK1064: Package Antlr4.Runtime.Standard, version 4.13.1 
was not found. It might have been deleted since NuGet restore. Otherwise, NuGet restore might have only partially completed, which might have been due to maximum path length restrictions.
 [C:\Users\ajapo\Documents\GitHub\CalculatorLanguage\AntlrCSharp\AntlrCSharp.csproj]

1. Solution:
Først:  dotnet nuget locals all --clear
efter:  dotnet build
kør det du gerne vil køre efter
virkede for mig
