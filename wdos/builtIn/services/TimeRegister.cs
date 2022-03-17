using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

#pragma warning disable CS8602 // 解引用可能出现空引用。

namespace wdos.builtIn.services
{
    /// <summary>
    /// 日期时间托管注册类
    /// </summary>
    internal class TimeRegister
    {
        /// <summary>
        /// 定时器
        /// </summary>
        private readonly DispatcherTimer timer = new();

        /// <summary>
        /// 日期时间更新目标
        /// </summary>
        private readonly Dictionary<uint, ValueStruct> targets = new();

        /// <summary>
        /// 可用ID队列
        /// </summary>
        private readonly Queue<uint> AvailableID = new();

        /// <summary>
        /// 最大ID分配
        /// </summary>
        private uint NowMaxID = 0;

        /// <summary>
        /// 目标结构
        /// </summary>
        private struct ValueStruct
        {
            public FrameworkElement target;
            public ElementType elementType;
            public string format;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public TimeRegister()
        {
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Tick += (_, _) =>
            {
                if (targets.Count != 0)
                    foreach (uint item in targets.Keys)
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

        /// <summary>
        /// 注册一个日期时间更新对象
        /// </summary>
        /// <param name="fe">对象控件</param>
        /// <param name="et">对象类型</param>
        /// <param name="format">日期时间格式化字符串</param>
        /// <returns>分配的 ID , 请妥善保管</returns>
        public uint RegisterControl(FrameworkElement fe, ElementType et, string format)
        {
            uint targetID;
            if (AvailableID.Count == 0)
            {
                targetID = NowMaxID + 1;
                ++NowMaxID;
            }
            else targetID = AvailableID.Dequeue();
            targets.Add(targetID, new ValueStruct()
            {
                target = fe,
                elementType = et,
                format = format
            });
            return targetID;
        }

        /// <summary>
        /// 取消注册已经注册过的日期时间更新对象
        /// </summary>
        /// <param name="id">对象被分配的 ID</param>
        public void UnRegisterControl(uint id)
        {
            targets.Remove(id);
            AvailableID.Enqueue(id);
        }

        /// <summary>
        /// 结束计时器
        /// </summary>
        internal void Shutdown()
        {
            timer.Stop();
        }

        /// <summary>
        /// 对象类型
        /// </summary>
        public enum ElementType
        {
            TextBlock = 0, TextBox = 1, Label = 2
        }
    }
}

#pragma warning restore CS8602 // 解引用可能出现空引用。