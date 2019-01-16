using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using WordsGenerator;
using WordsSeach;

namespace WordSearch
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IGenerator, Generator>();
            container.RegisterType<ISearch, Search>();

            var viewModel = container.Resolve<MainViewModel>();
            var view = new MainWindow { DataContext = viewModel };
            view.Show();
        }
    }
}
