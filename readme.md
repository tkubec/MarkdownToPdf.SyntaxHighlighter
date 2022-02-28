# Syntax Highlighter for MarkdownToPdf Library

Syntax highlighter plugin for  [MarkdownToPdf Library](https://github.com/tkubec/MarkdownToPdf) using [PrismSharp](https://github.com/tkubec/PrismSharp).

# Usage

```csharp
var pdf = new MarkdownToPdf();
pdf.PluginManager.Add(new HighlighterPlugin { ThemeName = ThemeNames.SolarizedDarkAtom });
pdf.Add("# Highlighting\r\n\r\n```csharp\r\nfor (var i = 0; i < 10; i++) { ; } // comment\r\n```");
pdf.Save("out.pdf");

```


# Installation

The library is available as a NuGet package: [![](https://img.shields.io/badge/nuget-v1.0-blue)](https://www.nuget.org/packages/MarkdownToPdf.SyntaxHighlighter)

# License
This software is released under the MIT license.
