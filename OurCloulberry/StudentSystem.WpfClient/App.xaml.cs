﻿using System.Linq;
using System.Windows;
using StudentSystem.Library;
using Telerik.Windows.Controls;

namespace StudentSystem.WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            StyleManager.ApplicationTheme = new Expression_DarkTheme();

            Resources.Add("AppConfiguration", AppCache.Config);
            AppCache.Config.IsBusyPool.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(IsBusyDict_CollectionChanged);
        }

        void IsBusyDict_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (AppCache.Config.IsBusyPool.Count == 0)
                AppCache.Config.IsBusy = false;
            else
            {
                AppCache.Config.IsBusyMessage = AppCache.Config.IsBusyPool.First();
                AppCache.Config.IsBusy = true;
            }
        }
    }
}
