using System.Collections.Generic;
using EventBus;
using PluginBase.Events;

namespace PluginBase.Actions
{
    public class ActionEngine
    {
        private static ActionEngine _instance;
        public static ActionEngine Instance => _instance ?? (_instance = new ActionEngine());

        private List<IBaseAction> _actions = new List<IBaseAction>(100);
        
        private ActionEngine()
        {
            // Initialize.
        }
        
        
        [EventSubscriber]
        public void HandleDoActionEvent(DoActionEvent doActionEvent)
        {
            IBaseAction action = doActionEvent.ActionToDo;
            _actions.Add(action);
            action.DoAction();
        }
        
        [EventSubscriber]
        public void HandleUndoActionEvent(UndoActionEvent undoActionEvent)
        {
            if(_actions.Count == 0) return;
            
            IBaseAction action = _actions[_actions.Count - 1];
            action.UndoAction();
            _actions.Remove(action);
        }
        
    }
}