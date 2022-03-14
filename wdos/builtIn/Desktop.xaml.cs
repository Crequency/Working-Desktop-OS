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

namespace wdos.builtIn
{
    /// <summary>
    /// Desktop.xaml 的交互逻辑
    /// </summary>
    public partial class Desktop : UserControl
    {
        public Desktop()
        {
            InitializeComponent();

            KeyDown += (_, _) =>
            {
                if(Keyboard.IsKeyDown(Key.LeftCtrl) &&
                    Keyboard.IsKeyDown(Key.LeftShift) &&
                    Keyboard.IsKeyDown(Key.L))
                {
                    BeginAnimation(OpacityProperty, new DoubleAnimation()
                    {
                        From = 1, To = 0, Duration = new TimeSpan(0, 0, 0, 0, 300),
                        EasingFunction = new CubicEase()
                        {
                            EasingMode = EasingMode.EaseOut
                        }
                    });
                    new Thread(() =>
                    {
                        Thread.Sleep(300);
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            App.mainWin.Inject(new LogIn(300), "PasswdBox");
                        }));
                    }).Start();
                }
            };
        }
    }
}
