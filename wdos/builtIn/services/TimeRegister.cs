using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

#pragma warning disable CS8602 // 解引用可能出现空引用。

namespace wdos.builtIn.services
{
    internal class TimeRegister
    {
        private readonly DispatcherTimer timer = new();

        private readonly Dictionary<int, ValueStruct> targets = new();

        private struct ValueStruct
        {
            public FrameworkElement target;
            public ElementType elementType;
            public string format;
        }

        public TimeRegister()
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 250);
            timer.Tick += (_, _) =>
            {
                if (targets.Count != 0)
                    foreach (int item in targets.Keys)
                    {
                        string datetime = DateTime.Now.ToString(targets[item].format);
                        switch (targets[item].elementType)
                        {
                            case ElementType.TextBlock:
                                (targets[item].target as TextBlock).Text = datetime;
                                break;
                            case ElementType.TextBox:
                                (targets[item].target as TextBox).Text = datetime;
                                break;
                            case ElementType.Label:
                                (targets[item].target as Label).Content = datetime;
                                break;
                        }
                    }
            };
            timer.Start();
        }

        public int RegisterControl(FrameworkElement fe, ElementType et, string format)
        {
            targets.Add(targets.Count, new ValueStruct()
            {
                target = fe,
                elementType = et,
                format = format
            });
            return targets.Count - 1;
        }

        public void UnRegisterControl(int id)
        {
            targets.Remove(id);
        }

        internal void Shutdown()
        {
            timer.Stop();
        }

        public enum ElementType
        {
            TextBlock = 0, TextBox = 1, Label = 2
        }
    }
}

#pragma warning restore CS8602 // 解引用可能出现空引用。