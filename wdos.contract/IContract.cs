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
        /// Ӧ������
        /// </summary>
        /// <returns>����</returns>
        string AppName();

        /// <summary>
        /// Ӧ�÷����߽ṹ��
        /// </summary>
        /// <returns>�����߽ṹ��</returns>
        AppPublisherStruct AppPublisher();

        /// <summary>
        /// Ӧ��GUID�ṹ��
        /// </summary>
        /// <returns>GUID</returns>
        App_GUID_Struct AppGUID();
    }

    /// <summary>
    /// GUID ������
    /// </summary>
    public static class GUID_Helper
    {
        /// <summary>
        /// ����ָ���������ַ�
        /// </summary>
        /// <param name="num">����</param>
        /// <param name="c">�ַ�</param>
        /// <returns>ƴ�ϳ��ַ���</returns>
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
        /// ���ַ���ת��ΪGUID�ṹ��
        /// </summary>
        /// <param name="guid">�ַ�����ʽGUID</param>
        /// <returns>GUID�ṹ��</returns>
        /// <exception cref="GUID_Exception">�Ƿ�GUID�쳣</exception>
        public static App_GUID_Struct Get_GUID_FromString(string guid, GUID_Status? status)
        {
            App_GUID_Struct app_GUID_Struct = new();
            app_GUID_Struct.level = status ?? GUID_Status.Test;
            guid = guid.ToUpper(); // ת��Ϊ��д��ĸ
            if (new Regex(RegexPatterns.GUID_Pattern).IsMatch(guid))
            {
                string[] parts = guid.Split('-');
                int passed = 0;
                foreach (string part in parts)
                {
                    App_GUID_Struct_Part agsp;
                    #region ��������, ָ����һ����
                    switch (passed)
                    {
                        case 0: agsp = app_GUID_Struct.A; break;
                        case 1: agsp = app_GUID_Struct.B; break;
                        case 2: agsp = app_GUID_Struct.C; break;
                        case 3: agsp = app_GUID_Struct.D; break;
                        case 4: agsp = app_GUID_Struct.E; break;
                    }
                    #endregion
                    #region �ж�ÿһ�����Ƿ�Ϸ�, ���Ϸ��׳��쳣
                    if (part.Length != 5)
                    {
                        int spaceNum = passed * 5 + passed;
                        throw new GUID_Exception("Invalid GUID format.",
                            $"WDOS:FE1021 >> {guid}\n" +
                            $"{GenerateChar(spaceNum + 15, ' ')}" +
                            $"{part}");
                    }
                    #endregion
                    #region ��ÿһ���ָ�ֵ��ṹ��Ĳ���
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
    /// Ӧ��GUID�ṹ��
    /// </summary>
    public struct App_GUID_Struct
    {
        public App_GUID_Struct_Part A, B, C, D, E;
        public GUID_Status level;
    }

    /// <summary>
    /// Ӧ��GUID�ṹ�岿��
    /// </summary>
    public struct App_GUID_Struct_Part
    {
        public char A, B, C, D, E;
        public string part;
    }

    /// <summary>
    /// Ӧ�÷����߽ṹ��
    /// publisherType -> ָʾ�����ߵ�����
    /// publisherName -> ָʾ�����ߵ�����
    /// </summary>
    public struct AppPublisherStruct
    {
        public PublisherType publisherType;
        public string publisherName;
    }

    /// <summary>
    /// GUID ����
    /// </summary>
    public enum GUID_Status
    {
        Debug = 0, Test = 0, Alpha = 1, Beta = 2, Release = 3, Publish = 3
    }

    /// <summary>
    /// ����������
    /// </summary>
    public enum PublisherType
    {
        Personal = 0, Studio = 1, Business = 2
    }
}
