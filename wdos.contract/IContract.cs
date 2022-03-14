using System.ComponentModel;
using System.Text.RegularExpressions;
using wdos.exceptions;
using wdos.global.Strings;

namespace wdos.contract
{
    [Description("Basic-Plugin-Interface")]
    public interface IContract
    {
        /// <summary>
        /// 应用名称
        /// </summary>
        /// <returns>名称</returns>
        string AppName();

        /// <summary>
        /// 应用发布者结构体
        /// </summary>
        /// <returns>发布者结构体</returns>
        AppPublisherStruct AppPublisher();

        /// <summary>
        /// 应用GUID结构体
        /// </summary>
        /// <returns>GUID</returns>
        App_GUID_Struct AppGUID();
    }

    /// <summary>
    /// GUID 帮助类
    /// </summary>
    public static class GUID_Helper
    {
        public static GUID_Status TypeOf_GUID_Staus(App_GUID_Struct guid)
        {
            GUID_Status status = new();

            return status;
        }

        /// <summary>
        /// 每段赋值
        /// </summary>
        /// <param name="agsp">GUID结构体Part引用</param>
        /// <param name="yet">part</param>
        private static void SetPart_GUID_Part(ref App_GUID_Struct_Part agsp, string yet)
        {
            agsp.part = yet; agsp.A = yet[0];
            agsp.B = yet[1]; agsp.C = yet[2];
            agsp.D = yet[3]; agsp.E = yet[4];
        }

        /// <summary>
        /// 将字符串转换为GUID结构体
        /// </summary>
        /// <param name="guid">字符串形式GUID</param>
        /// <returns>GUID结构体</returns>
        /// <exception cref="GUID_Exception">非法GUID异常</exception>
        public static App_GUID_Struct Get_GUID_FromString(string guid, GUID_Status? status)
        {
            App_GUID_Struct app_GUID_Struct = new();
            app_GUID_Struct.level = status ?? GUID_Status.Test;
            guid = guid.ToUpper(); // 转换为大写字母
            if (new Regex(RegexPatterns.GUID_Pattern).IsMatch(guid))
            {
                string[] parts = guid.Split('-');
                int passed = 0;
                foreach (string part in parts)
                {
                    #region 分段部分赋值
                    switch (passed)
                    {
                        case 0: SetPart_GUID_Part(ref app_GUID_Struct.A, part); break;
                        case 1: SetPart_GUID_Part(ref app_GUID_Struct.B, part); break;
                        case 2: SetPart_GUID_Part(ref app_GUID_Struct.C, part); break;
                        case 3: SetPart_GUID_Part(ref app_GUID_Struct.D, part); break;
                        case 4: SetPart_GUID_Part(ref app_GUID_Struct.E, part); break;
                    }
                    #endregion
                    ++passed;
                }
                return app_GUID_Struct;
            }
            else
            {
                throw new GUID_Exception("Invalid GUID format.", $"WDOS:FE10200 >> {guid}");
            }
        }
    }

    /// <summary>
    /// 应用GUID结构体
    /// </summary>
    public struct App_GUID_Struct
    {
        public App_GUID_Struct_Part A, B, C, D, E;
        public GUID_Status level;
    }

    /// <summary>
    /// 应用GUID结构体部分
    /// </summary>
    public struct App_GUID_Struct_Part
    {
        public char A, B, C, D, E;
        public string part;
    }

    /// <summary>
    /// 应用发布者结构体
    /// publisherType -> 指示发布者的类型
    /// publisherName -> 指示发布者的名称
    /// </summary>
    public struct AppPublisherStruct
    {
        public PublisherType publisherType;
        public string publisherName;
    }

    /// <summary>
    /// GUID 类型
    /// </summary>
    public enum GUID_Status
    {
        Debug = 0, Test = 0, Alpha = 1, Beta = 2, Release = 3, Publish = 3
    }

    /// <summary>
    /// 发布者类型
    /// </summary>
    public enum PublisherType
    {
        Personal = 0, Studio = 1, Business = 2
    }
}
