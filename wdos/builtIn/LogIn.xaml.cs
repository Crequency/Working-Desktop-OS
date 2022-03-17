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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using wdos.builtIn.services;

namespace wdos.builtIn
{
    /// <summary>
    /// LogIn.xaml 的交互逻辑
    /// </summary>
    public partial class LogIn : UserControl
    {
        private readonly uint[] time_control_id = new uint[2];

        public LogIn(int delay)
        {
            InitializeComponent();
            MouseDown += (_, e) =>
            {
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    if(uistate == UIState.InLogin)
                    {
                        uistate = UIState.NotLogin;
                        (Resources["LeaveLogin_Login"] as Storyboard)?.Begin();
                    }
                }
                else
                {
                    if (uistate == UIState.NotLogin)
                    {
                        uistate = UIState.InLogin;
                        (Resources["EnterLogin_Login"] as Storyboard)?.Begin();
                    }
                }
            };
            Loaded += (_, _) =>
            {
                new Thread(() =>
                {
                    Thread.Sleep(delay);
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        (Resources["FadeIn_Login"] as Storyboard)?.Begin();
                    }));
                }).Start();
                time_control_id[0] = App.timeRegister.RegisterControl(TimeBlock,
                    TimeRegister.ElementType.TextBlock, "HH:mm");
                time_control_id[1] = App.timeRegister.RegisterControl(DateBlock,
                    TimeRegister.ElementType.TextBlock, "M");
            };
        }

        private UIState uistate = UIState.NotLogin;

        private enum UIState
        {
            NotLogin = 0, InLogin = 1
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            (Resources["FadeOut_Login"] as Storyboard)?.Begin();
            ReleaseResources();
            new Thread(() =>
            {
                Thread.Sleep(300);
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    App.mainWin.Inject(new Desktop(), "StartMenuBtn");
                }));
            }).Start();
        }

        private void ShutDown_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Restore_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Message_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void More_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReleaseResources()
        {
            App.timeRegister.UnRegisterControl(time_control_id[0]);
            App.timeRegister.UnRegisterControl(time_control_id[1]);
        }
    }
}
