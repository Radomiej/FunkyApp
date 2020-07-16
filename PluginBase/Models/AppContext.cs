using System.Collections.Generic;

namespace WpfPluginBase.Models
{
    public class AppContext
    {
        public Dictionary<string, object> ContextData { get; } = new Dictionary<string, object>(100);

        public AppContext()
        {
            
        }

        public AppContext(Dictionary<string, object> contextData)
        {
            ContextData = contextData;
        }
    }
}