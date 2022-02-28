using Orionsoft.MarkdownToPdfLib.Converters;
using Orionsoft.MarkdownToPdfLib.Plugins;
using Orionsoft.PrismSharp.Themes;
using Orionsoft.PrismSharp.Tokenizing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This file is a part of MarkdownToPdf Syntax Highlighting Plugin by Tomas Kubec
// Distributed under MIT license - see license.txt
//

namespace Orionsoft.MarkdownToPdfLib.SyntaxHighlighter
{
    public class HighlighterPlugin : IHighlightingPlugin
    {
        private Tokenizer tokenizer;
        private Highlighter highlighter;
        private ThemeNames themeName;

        public ThemeNames ThemeName { get => themeName ; set => SetTheme(value); }


        public HighlighterPlugin()
        {
            tokenizer = new Tokenizer();
            highlighter = new Highlighter(tokenizer, Theme.Load(themeName));
            
        }
        public HighlightingPluginResult Convert(List<string> lines, IElementConverter converter)
        {
            var lang = converter.Attributes.Info?.ToLower();
            
            if (converter is IBlockConverter && !tokenizer.LanguageList.Contains(lang)) return new HighlightingPluginResult();
            if (converter is IInlineConverter && !tokenizer.LanguageList.Contains(lang)) return new HighlightingPluginResult();
            var res = highlighter.Highlight(string.Join("\r\n", lines.ToArray()), lang);
            return res;
        }
        private void SetTheme(ThemeNames value)
        {
            themeName = value;
            highlighter = new Highlighter(tokenizer, Theme.Load(themeName));
        }
    }
}
