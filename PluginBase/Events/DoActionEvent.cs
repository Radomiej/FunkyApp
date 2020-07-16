
using PluginBase.Actions;

namespace PluginBase.Events
{
    public class DoActionEvent
    {
        public IBaseAction ActionToDo { get; }

        public DoActionEvent(IBaseAction actionToDo)
        {
            ActionToDo = actionToDo;
        }
    }
}