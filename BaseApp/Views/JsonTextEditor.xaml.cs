using System.Windows;
using System.Windows.Controls;
using ScintillaNET;

namespace BaseApp.Views
{
    public partial class JsonTextEditor : UserControl
    {
        public JsonTextEditor()
        {
            InitializeComponent();
            LoadScintilla();
        }

        private void LoadScintilla()
        {
            scintilla.Lexer = Lexer.Json;
            scintilla.Margins[0].Width = 16;

            EnableFolding();
        }

        private void EnableFolding()
        {
            // Instruct the lexer to calculate folding
            scintilla.SetProperty("fold", "1");
            scintilla.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            scintilla.Margins[2].Type = MarginType.Symbol;
            scintilla.Margins[2].Mask = Marker.MaskFolders;
            scintilla.Margins[2].Sensitive = true;
            scintilla.Margins[2].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                scintilla.Markers[i].SetForeColor(System.Drawing.SystemColors.ControlLightLight);
                scintilla.Markers[i].SetBackColor(System.Drawing.SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

//        private int maxLineNumberCharLength;
//        private void scintilla_TextChanged(object sender, EventArgs e)
//        {
//            // Did the number of characters in the line number display change?
//            // i.e. nnn VS nn, or nnnn VS nn, etc...
//            var maxLineNumberCharLength = scintilla.Lines.Count.ToString().Length;
//            if (maxLineNumberCharLength == this.maxLineNumberCharLength)
//                return;
//
//            // Calculate the width required to display the last line number
//            // and include some padding for good measure.
//            const int padding = 2;
//            scintilla.Margins[0].Width = scintilla.TextWidth(ScintillaNET.Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
//            this.maxLineNumberCharLength = maxLineNumberCharLength;
//        }
    }
}