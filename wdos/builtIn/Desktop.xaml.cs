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
    /// Desktop.xaml 的交互逻辑
    /// </summary>
    public partial class Desktop : UserControl
    {
        private readonly uint[] time_control_id = new uint[2];

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
                    ReleaseResources();
                    new Thread(() =>
                    {
                        Thread.Sleep(300);
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            App.mainWin.Inject(new LogIn(300), "PasswdBox");
                        }));
                    }).Start();
                }
                #region 测试代码
                if (global.Global.IsDebug)
                {
                    if (Keyboard.IsKeyDown(Key.RightCtrl) && Keyboard.IsKeyDown(Key.M))
                    {
                        (Resources["ModernTaskBar"] as Storyboard)?.Begin();
                        TaskBar_Back.CornerRadius = new CornerRadius(10);
                    }
                    if (Keyboard.IsKeyDown(Key.RightCtrl) && Keyboard.IsKeyDown(Key.D))
                    {
                        (Resources["DockTaskBar"] as Storyboard)?.Begin();
                        TaskBar_Back.CornerRadius = new CornerRadius(0);
                    }
                }
                #endregion
            };

            Loaded += (_, _) =>
            {
                time_control_id[0] = App.timeRegister.RegisterControl(TimeBlock,
                    TimeRegister.ElementType.TextBlock, "HH:mm:ss");
                time_control_id[1] = App.timeRegister.RegisterControl(DateBlock,
                    TimeRegister.ElementType.TextBlock, "yyyy-MM-dd");
            };
        }

        private void ReleaseResources()
        {
            App.timeRegister.UnRegisterControl(time_control_id[0]);
            App.timeRegister.UnRegisterControl(time_control_id[1]);
        }
    }
}
