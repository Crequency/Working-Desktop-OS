using System.Collections.Generic;
using System.ComponentModel;
using BaseContract = wdos.contract.IContract;

namespace wdos.wpf.contract
{
    /// <summary>
    /// WPF 应用接口
    /// </summary>
    [Description("WPF-Plugin-Interface")]
    public interface IContract : BaseContract
    {
        /// <summary>
        /// 要求应用检查运行环境
        /// </summary>
        /// <returns>能否运行以及情况</returns>
        EnvironmentStatus CheckEnvironment();

        /// <summary>
        /// 启动应用
        /// </summary>
        /// <returns>是否启动成功</returns>
        bool Start();        
    }

    /// <summary>
    /// 环境情况结构体
    /// </summary>
    public struct EnvironmentStatus
    {
        public List<DependencyStatus> dependencies;
        public bool readyToRun;
    }

    /// <summary>
    /// 依赖项状况结构体
    /// </summary>
    public struct DependencyStatus
    {
        public string name, message;
        public Dictionary<string, bool> versions;
    }

    /// <summary>
    /// 状况级别
    /// </summary>
    public enum StatusLevel
    {
        Info = 0, Warning = 1, Error = 2, Fatal = 3
    }
}
