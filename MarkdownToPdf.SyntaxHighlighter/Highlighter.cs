using Orionsoft.MarkdownToPdfLib.Plugins;
using Orionsoft.PrismSharp.Highlighters;
using Orionsoft.PrismSharp.Highlighters.Abstract;
using Orionsoft.PrismSharp.Themes;
using Orionsoft.PrismSharp.Tokenizing;
using System.Collections.Generic;
using System.Drawing;

// This file is a part of MarkdownToPdf Syntax Highlighting Plugin by Tomas Kubec
// Distributed under MIT license - see license.txt
//

namespace Orionsoft.MarkdownToPdfLib.SyntaxHighlighter
{
    internal class Highlighter : AbstractHighlighter<HighlightingPluginResult>
    {
        public Highlighter(Tokenizer tokenizer, Theme theme)
        {
            Construct(tokenizer, theme);
        }
       
        protected override ThemeStyle BeginDocument(string language, ThemeStyle docStyle)
        {
            Result = new HighlightingPluginResult();
            Result.Spans = new List<HighlightedSpan>();
            return docStyle;
        }

        protected override void EndDocument()
        {
            Result.Success = true;
            var st = Theme.GetDocumentStyle(Language);
            Result.Background = Color.FromArgb( st.Background.R, st.Background.G, st.Background.B);
        }

        protected override ThemeStyle BeginContainer(Token token, ThemeStyle style, ThemeStyle parentStyle)
        {
            return style?.MergeWith(parentStyle) ?? parentStyle.Clone();
        }

        protected override void AddSpan(string text, Token token, ThemeStyle style, ThemeStyle parentStyle)
        {
            var st = style?.MergeWith(parentStyle) ?? parentStyle.Clone();
            Result.Spans.Add(new HighlightedSpan
            {
                Bold = st.Bold ?? false,
                Italic = st.Italic ?? false,
                Underline = st.Underline ?? false,
                Color = Color.FromArgb((int)(st.Color.A * 255), st.Color.R, st.Color.G, st.Color.B),
                Text = text
            }); 
        }
    }
}