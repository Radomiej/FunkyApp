using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PluginBase.Helpers
{
    public class ConsoleOptionsAdapter
    {
        private static readonly Dictionary<string, string> _serviceShortcuts = new Dictionary<string, string>();

        public static void RegisterServiceShortcut(string fullServiceName, string shortcutName)
        {
            if (fullServiceName == null )
            {
               if(_serviceShortcuts.ContainsKey(shortcutName)) _serviceShortcuts.Remove(shortcutName);
            }
            else
            {
                if (_serviceShortcuts.ContainsKey(shortcutName)) _serviceShortcuts[shortcutName] = fullServiceName;
                else _serviceShortcuts.Add(shortcutName, fullServiceName);
            }
        }
        
        public readonly string RawInput;
        public readonly string[] Args;
        public readonly string serviceName;
        public readonly Dictionary<string, string> namedArguments = new Dictionary<string, string>();
        public readonly List<string> basicArguments = new List<string>();
        
        //TODO improve or remove
        public ConsoleOptionsAdapter(string consoleInput)
        {
            RawInput = consoleInput;
            Args = RawInput.Split(' ');
            serviceName = Args[0];
            if (_serviceShortcuts.ContainsKey(serviceName))
            {
                serviceName = _serviceShortcuts[serviceName];//Update to full name of service
            }
            
            for (int i = 1; i < Args.Length; i++)
            {
                string part = Args[i];
                if (part.StartsWith("-"))
                {
                    i++;
                    string value = Args[i];
                    if (namedArguments.ContainsKey(part)) namedArguments[part] = value;
                    else namedArguments.Add(part, value);
                }
                else
                {
                    basicArguments.Add(part);
                }
            }
        }
    }
}