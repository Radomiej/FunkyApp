using System;
using EventBus;
using PluginBase.Events;

namespace PluginBase
{
    public class WpfConsole
    {
        public static void WriteLine(string message)
        {
            SimpleEventBus.GetDefaultEventBus().Post(new ConsoleOutputEvent(message), TimeSpan.Zero);
        }
    }
}