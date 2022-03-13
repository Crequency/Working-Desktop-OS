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
        /// <summary>
        /// 生成指定数量的字符
        /// </summary>
        /// <param name="num">数量</param>
        /// <param name="c">字符</param>
        /// <returns>拼合成字符串</returns>
        private static string GenerateChar(int num, char c)
        {
            string space = "";
            for (int i = 0; i < num; i++) space += c;
            return space;
        }

        public static GUID_Status TypeOf_GUID_Staus(App_GUID_Struct guid)
        {
            GUID_Status status = new();

            return status;
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
                    App_GUID_Struct_Part agsp;
                    #region 调整引用, 指向下一部分
                    switch (passed)
                    {
                        case 0: agsp = app_GUID_Struct.A; break;
                        case 1: agsp = app_GUID_Struct.B; break;
                        case 2: agsp = app_GUID_Struct.C; break;
                        case 3: agsp = app_GUID_Struct.D; break;
                        case 4: agsp = app_GUID_Struct.E; break;
                    }
                    #endregion
                    #region 判断每一部分是否合法, 不合法抛出异常
                    if (part.Length != 5)
                    {
                        int spaceNum = passed * 5 + passed;
                        throw new GUID_Exception("Invalid GUID format.",
                            $"WDOS:FE1021 >> {guid}\n" +
                            $"{GenerateChar(spaceNum + 15, ' ')}" +
                            $"{part}");
                    }
                    #endregion
                    #region 将每一部分赋值与结构体的部分
                    agsp.part = part;
                    for(int i = 0; i < part.Length; ++i)
                    {
                        switch (i)
                        {
                            case 0: agsp.A = part[i]; break;
                            case 1: agsp.B = part[i]; break;
                            case 2: agsp.C = part[i]; break;
                            case 3: agsp.D = part[i]; break;
                            case 4: agsp.E = part[i]; break;
                        }
                    }
                    #endregion
                    ++passed;
                }
                return app_GUID_Struct;
            }
            else
            {
                throw new GUID_Exception("Invalid GUID format.", $"WDOS:FE1020 >> {guid}");
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
