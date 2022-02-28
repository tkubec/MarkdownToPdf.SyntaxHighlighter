
using Orionsoft.MarkdownToPdfLib.SyntaxHighlighter;
using Orionsoft.MarkdownToPdfLib;
using Orionsoft.PrismSharp.Themes;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var pdf = new MarkdownToPdf();
            pdf.PluginManager.Add(new HighlighterPlugin { ThemeName = ThemeNames.SolarizedDarkAtom });
            pdf.Add("# Highlighting\r\n\r\n```csharp\r\nfor (var i = 0; i < 10; i++) { ; } // comment\r\n```");
            pdf.Save("out.pdf");
        }
    }
}
