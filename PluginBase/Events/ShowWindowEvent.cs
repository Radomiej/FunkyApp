using System.Windows;

namespace PluginBase.Events
{
    public class ShowWindowEvent
    {
        public Window windowToShow;

        public ShowWindowEvent(Window windowToShow)
        {
            this.windowToShow = windowToShow;
        }
    }
}