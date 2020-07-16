using System.Windows;
using BaseApp.Services;
using EventBus;
using PluginBase;
using PluginBase.Actions;
using PluginBase.Context;
using PluginBase.Events;

namespace BaseApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
      
        private I18NEngine _i18NEngine;
        
        public MainWindow()
        {
            InitializeComponent();
            SimpleEventBus.GetDefaultEventBus().Register(this);
            SimpleEventBus.GetDefaultEventBus().Register(ActionEngine.Instance);
//            LoadPlugins();
            LoadServices();
            InitPluginEngine();
            
        }

        private void LoadServices()
        {
            SimpleEventBus.GetDefaultEventBus().Register(new ContextService());
        }

        private void InitPluginEngine()
        {
            PluginEngine pluginEngine = new PluginEngine();
            //Restore from context
            pluginEngine.RestorePlugins();
            SimpleEventBus.GetDefaultEventBus().Register(pluginEngine);
            
           
        }


        private void LoadPlugins()
        {
            string pluginPath = @"H:\Dokumenty\Kod\C#\UploadApp\BaseApp\PluginMusicPlayer\bin\Debug\";
            WpfConsole.WriteLine("Load Plugins from: " + pluginPath);
            PluginEngine pluginEngine = new PluginEngine();
            pluginEngine.FindPlugins(pluginPath);
            pluginEngine.InitializePlugins();
        }


        [EventSubscriber]
        public void HandleOutputEvent(ShowWindowEvent showWindowEvent)
        {
            Application.Current.Dispatcher.Invoke(
                () => { showWindowEvent.windowToShow.Show(); });
        }



        

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _i18NEngine = new I18NEngine(this, Properties.Resources.ResourceManager);
            _i18NEngine.UpdateLanguage();
        }

    }
}