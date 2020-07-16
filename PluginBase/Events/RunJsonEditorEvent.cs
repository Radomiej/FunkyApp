using WpfPluginBase.Models;

namespace PluginBase.Events
{
    public class RunJsonEditorEvent
    {
        public readonly ScintillaText ScintillaText;

        public RunJsonEditorEvent(ScintillaText scintillaText)
        {
            ScintillaText = scintillaText;
        }
    }
}