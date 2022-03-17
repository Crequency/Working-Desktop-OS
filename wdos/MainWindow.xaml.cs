using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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

#pragma warning disable CS8604 // 引用类型参数可能为 null。

namespace wdos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            KeyDown += (_, e) =>
            {
                if (Keyboard.IsKeyDown(Key.RightAlt) && Keyboard.IsKeyDown(Key.Enter))
                {
                    switch (wsstate)
                    {
                        case WindowScreenState.FullScreen:
                            wsstate = WindowScreenState.Windowful;
                            WindowStyle = WindowStyle.SingleBorderWindow;
                            break;
                        case WindowScreenState.Windowful:
                            wsstate = WindowScreenState.FullScreen;
                            WindowStyle = WindowStyle.None;
                            WindowState = WindowState.Normal;
                            WindowState = WindowState.Maximized;
                            break;
                    }
                }
            };
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            App.Terminate();
            base.OnClosing(e);
        }

        internal void Inject(FrameworkElement element, string? focuson)
        {
            Screen.Child = element;
            if (focuson != null)
            {
                element.Loaded += (_, _) =>
                {
                    (element.FindName(focuson) as FrameworkElement)?.Focus();
                };
            }
        }

        private WindowScreenState wsstate = WindowScreenState.Windowful;

        private enum WindowScreenState
        {
            FullScreen, Windowful
        }
    }
}

#pragma warning restore CS8604 // 引用类型参数可能为 null。
