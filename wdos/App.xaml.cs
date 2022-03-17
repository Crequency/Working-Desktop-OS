using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using wdos.builtIn;
using wdos.builtIn.services;

namespace wdos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static MainWindow mainWin = new();
        internal static PipeServer pipeServer = new();
        internal static TimeRegister timeRegister = new();

        private void OS_StartUp()
        {
            mainWin.Show();

            mainWin.Inject(new StartupUI(), null);
        }

        internal static void Terminate()
        {
            timeRegister.Shutdown();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (helper.VersionHelper.IsNewest())
            {
                OS_StartUp();
            }
            else
            {
                helper.VersionHelper.UpdateVersion();
            }
        }
    }
}
