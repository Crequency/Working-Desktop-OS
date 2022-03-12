using System;
using System.ComponentModel;

namespace wdos.wpf.contract
{
    /// <summary>
    /// WPF 应用接口
    /// </summary>
    [Description("WPF-Plugin-Interface")]
    public interface IContract
    {
        public string GetName();
    }
}
