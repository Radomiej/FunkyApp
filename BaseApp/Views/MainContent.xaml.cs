using System.Windows;
using System.Windows.Controls;
using EventBus;
using PluginBase.Events;

namespace BaseApp.Views
{
    public partial class MainContent : UserControl
    {
        public MainContent()
        {
            InitializeComponent();
            SimpleEventBus.GetDefaultEventBus().Register(this);
        }
        
        [EventSubscriber]
        public void HandleOutputEvent(AddTabItemEvent addTabItemEvent)
        {
            Application.Current.Dispatcher.Invoke(
                () => { AddTabItem(addTabItemEvent);});
        }

        private void AddTabItem(AddTabItemEvent addTabItemEvent)
        {
            TabControl tabControl = MainDockTabs;
            if (addTabItemEvent.PanelKind == AddTabItemEvent.TabPanelKind.LEFT) tabControl = LeftDockTabs;
            else if(addTabItemEvent.PanelKind == AddTabItemEvent.TabPanelKind.RIGHT) tabControl = RightDockTabs;

            tabControl.Items.Add(addTabItemEvent.TabItem);
        }
    }
}
