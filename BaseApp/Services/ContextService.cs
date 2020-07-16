using BaseApp.Properties;
using EventBus;
using Newtonsoft.Json;
using PluginBase;
using PluginBase.Events;
using PluginBase.Context;
using WpfPluginBase.Models;

namespace BaseApp.Services
{
    public class ContextService
    {
        private readonly string AppContextKey = "Context";

        public ContextService()
        {
            LoadContext();
        }
        
        [EventSubscriber]
        public void HandleOutputEvent(ConsoleInputEvent inputEvent)
        {
            string input = inputEvent.ConsoleInputText;
            if (!inputEvent.ConsoleInputText.StartsWith("context")) return;

            string[] parts= input.Split(' ');
            if (parts[1].Equals("load")) LoadContext();
            else if (parts[1].Equals("save")) SaveContext();
            else if (parts[1].Equals("view")) PrintContext();
           
        }

        private void PrintContext()
        {
            AppContext appContext = ContextEngine.Instance.GetContextCopy();
            string contextJson = JsonConvert.SerializeObject(appContext);
            WpfConsole.WriteLine(contextJson);
        }

        private void SaveContext()
        {
            AppContext appContext = ContextEngine.Instance.GetContextCopy();
            string contextJson = JsonConvert.SerializeObject(appContext);
            AppSettings.Default.Context = contextJson;
            AppSettings.Default.Save();
            WpfConsole.WriteLine("Context saved");
        }

        private void LoadContext()
        {
            AppSettings.Default.Reload();
            string contextJson = AppSettings.Default.Context;
            AppContext appContext = JsonConvert.DeserializeObject<AppContext>(contextJson);
            ContextEngine.Instance.RestoreContext(appContext);
            WpfConsole.WriteLine("Context restored");
        }
    }
}