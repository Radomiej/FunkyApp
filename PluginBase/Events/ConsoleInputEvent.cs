using EventBus;
using PluginBase.Helpers;

namespace PluginBase.Events
{
    public class ConsoleInputEvent
    {
        public readonly string ConsoleInputText;
        public ConsoleOptionsAdapter ConsoleOptionsAdapter { get; private set; }

        public ConsoleInputEvent(string consoleInputText)
        {
            ConsoleInputText = consoleInputText;
            ConsoleOptionsAdapter = new ConsoleOptionsAdapter(consoleInputText);
        }

        private ConsoleOptionsAdapter _adapter;
        public ConsoleOptionsAdapter getConsoleOptionsAdapter()
        {
            if(_adapter == null) _adapter = new ConsoleOptionsAdapter(ConsoleInputText);
            return _adapter;
        }
      
    }
}