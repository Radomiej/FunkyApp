using System.Resources;
using System.Windows.Controls;
using System.Windows.Media;

namespace PluginBase.Events
{
    public class AddTabItemEvent
    {
        public enum TabPanelKind {LEFT, RIGHT, MAIN}
        
        public string Category { get; }
        public TabItem TabItem { get; }
        public ResourceManager ResourceManager { get; }
        public TabPanelKind PanelKind { get; }

        public AddTabItemEvent(string category, TabItem menuItem, TabPanelKind panelKind, ResourceManager resourceManager)
        {
            Category = category;
            TabItem = menuItem;
            PanelKind = panelKind;
            ResourceManager = resourceManager;
        }
    }
}