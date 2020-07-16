using System;
using System.Collections;
using System.Collections.Generic;
using EventBus;
using PluginBase.Events;
using AppContext = WpfPluginBase.Models.AppContext;

namespace PluginBase.Context
{
    public class ContextEngine
    {
        private static ContextEngine _instance;
        public static ContextEngine Instance => _instance ?? (_instance = new ContextEngine());

        private readonly Dictionary<string, object> _contextData = new Dictionary<string, object>(100);

        private ContextEngine()
        {
            // Initialize.
        }

        public bool AppendToContextObject(string key, object value)
        {
            object oldValue = GetContextObject(key);
            if (oldValue == null)
            {
                oldValue = new List<object>();
                SetContextObject(key, oldValue);
            }
            if (oldValue is IList)
            {
                var list = oldValue as IList;
                list.Add(value);
                return true;
            }

            return false;
        }

        public void SetContextObject(string key, object value)
        {
            object oldValue = GetContextObject(key);
            ContextPropertiesChangedEvent contextPropertiesChangedEvent =
                new ContextPropertiesChangedEvent(key, oldValue, value);
            
            if (_contextData.ContainsKey(key)) _contextData[key] = value;
            else _contextData.Add(key, value);
            
            SimpleEventBus.GetDefaultEventBus().Post(contextPropertiesChangedEvent, TimeSpan.Zero);
        }

        public string GetStringContextObject(string key)
        {
            if (!_contextData.ContainsKey(key)) return "";
            return _contextData[key].ToString();
        }

        public object GetContextObject(string key)
        {
            return _contextData.ContainsKey(key) ? _contextData[key] : null;
        }

        public AppContext GetContextCopy()
        {
            return new AppContext(_contextData);
        }

        public void RestoreContext(AppContext appContext)
        {
            if(appContext == null) return;
            
            _contextData.Clear();
            foreach (string key in appContext.ContextData.Keys)
            {
                _contextData.Add(key, appContext.ContextData[key]);
            }
        }
    }
}