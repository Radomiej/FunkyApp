namespace PluginBase.Actions
{
    public interface IBaseAction
    {
        void DoAction();
        void UndoAction();
        void RedoAction();
    }
}