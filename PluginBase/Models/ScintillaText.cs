using System;

namespace WpfPluginBase.Models
{
    public class ScintillaText
    {
        private string _textToEdit;
        public string Text
        {
            get => _textToEdit;
            set => _textToEdit = value;
        }
        
        public readonly Guid Id = Guid.NewGuid();

        public ScintillaText(string textToEdit)
        {
            _textToEdit = textToEdit;
        }
    }
}