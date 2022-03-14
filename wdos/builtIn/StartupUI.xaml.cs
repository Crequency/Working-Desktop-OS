using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wdos.builtIn
{
    /// <summary>
    /// Startup.xaml 的交互逻辑
    /// </summary>
    public partial class StartupUI : UserControl
    {
        public StartupUI()
        {
            InitializeComponent();

            new Thread(() =>
            {
                Thread.Sleep(5000);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    App.mainWin.Inject(new LogIn());
                }));
            }).Start();
        }
    }
}
