using EventBus;

namespace PluginBase
{
    public interface IBasePlugin
    {
        string GetPluginName();
        string Initialize(SimpleEventBus eventBus);
        void Dispose();
    }
}