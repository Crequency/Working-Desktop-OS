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
            string space = string.Empty;
            for (int i = 0; i < num; i++)
                space += c;
            return space;
        }

        /// <summary>
        /// 将字符串转换为GUID结构体
        /// </summary>
        /// <param name="guid">字符串形式GUID</param>
        /// <returns>GUID结构体</returns>
        /// <exception cref="GUID_Exception">非法GUID异常</exception>
        public static App_GUID_Struct Get_GUID_FromString(string guid)
        {
            App_GUID_Struct app_GUID_Struct = new();
            guid = guid.ToUpper(); // 转换为大写字母
            if (new Regex(RegexPatterns.GUID_Pattern).IsMatch(guid))
            {
                string[] parts = guid.Split('-');
                int passed = 0, setted = 0;
                App_GUID_Struct_Part agsp = app_GUID_Struct.A;
                foreach (string part in parts)
                {
                    #region 判断每一部分是否合法, 不合法抛出异常
                    if (part.Length != 5)
                    {
                        int spaceNum = passed * 5 + passed == 0 ? 0 : passed;
                        throw new GUID_Exception("Invalid GUID format.",
                            $"WDOS:FE1021 >> {guid}\n" +
                            $"{GenerateChar(spaceNum + 15, ' ')}" +
                            $"{part}");
                    }
                    #endregion
                    #region 将每一部分赋值与结构体的部分
                    foreach (char item in part)
                    {
                        switch (setted)
                        {
                            case 0: agsp.A = item; break;
                            case 1: agsp.B = item; break;
                            case 2: agsp.C = item; break;
                            case 3: agsp.D = item; break;
                            case 4: agsp.E = item; break;
                        }
                        ++setted;
                    }
                    #endregion
                    #region 调整引用, 指向下一部分
                    switch (passed)
                    {
                        case 0: agsp = app_GUID_Struct.B; break;
                        case 1: agsp = app_GUID_Struct.C; break;
                        case 2: agsp = app_GUID_Struct.D; break;
                        case 3: agsp = app_GUID_Struct.E; break;
                    } 
                    #endregion
                    ++passed; setted = 0;
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
    }

    /// <summary>
    /// 应用GUID结构体部分
    /// </summary>
    public struct App_GUID_Struct_Part
    {
        public char A, B, C, D, E;
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
    /// 发布者类型
    /// </summary>
    public enum PublisherType
    {
        Personal = 0, Studio = 1, Business = 2
    }
}
