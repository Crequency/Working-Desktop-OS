using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace wdos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static MainWindow mainWin = new();
        internal static PipeServer pipeServer = new();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            mainWin.Show();
        }
    }
}
