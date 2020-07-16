using WpfPluginBase.Models;

namespace PluginBase.Events
{
    public class ScintillaTextSaveEvent
    {
        public readonly ScintillaText ScintillaText;

        public ScintillaTextSaveEvent(ScintillaText scintillaText)
        {
            ScintillaText = scintillaText;
        }
    }
}