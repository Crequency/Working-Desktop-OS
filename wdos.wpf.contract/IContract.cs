using System.Collections.Generic;
using System.ComponentModel;
using BaseContract = wdos.contract.IContract;

namespace wdos.wpf.contract
{
    /// <summary>
    /// WPF Ӧ�ýӿ�
    /// </summary>
    [Description("WPF-Plugin-Interface")]
    public interface IContract : BaseContract
    {
        /// <summary>
        /// Ҫ��Ӧ�ü�����л���
        /// </summary>
        /// <returns>�ܷ������Լ����</returns>
        EnvironmentStatus CheckEnvironment();

        /// <summary>
        /// ����Ӧ��
        /// </summary>
        /// <returns>�Ƿ������ɹ�</returns>
        bool Start();        
    }

    /// <summary>
    /// ��������ṹ��
    /// </summary>
    public struct EnvironmentStatus
    {
        public List<DependencyStatus> dependencies;
        public bool readyToRun;
    }

    /// <summary>
    /// ������״���ṹ��
    /// </summary>
    public struct DependencyStatus
    {
        public string name, message;
        public Dictionary<string, bool> versions;
    }

    /// <summary>
    /// ״������
    /// </summary>
    public enum StatusLevel
    {
        Info = 0, Warning = 1, Error = 2, Fatal = 3
    }
}
