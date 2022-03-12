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
            string space = string.Empty;
            for (int i = 0; i < num; i++)
                space += c;
            return space;
        }

        /// <summary>
        /// ���ַ���ת��ΪGUID�ṹ��
        /// </summary>
        /// <param name="guid">�ַ�����ʽGUID</param>
        /// <returns>GUID�ṹ��</returns>
        /// <exception cref="GUID_Exception">�Ƿ�GUID�쳣</exception>
        public static App_GUID_Struct Get_GUID_FromString(string guid)
        {
            App_GUID_Struct app_GUID_Struct = new();
            guid = guid.ToUpper(); // ת��Ϊ��д��ĸ
            if (new Regex(RegexPatterns.GUID_Pattern).IsMatch(guid))
            {
                string[] parts = guid.Split('-');
                int passed = 0, setted = 0;
                App_GUID_Struct_Part agsp = app_GUID_Struct.A;
                foreach (string part in parts)
                {
                    #region �ж�ÿһ�����Ƿ�Ϸ�, ���Ϸ��׳��쳣
                    if (part.Length != 5)
                    {
                        int spaceNum = passed * 5 + passed == 0 ? 0 : passed;
                        throw new GUID_Exception("Invalid GUID format.",
                            $"WDOS:FE1021 >> {guid}\n" +
                            $"{GenerateChar(spaceNum + 15, ' ')}" +
                            $"{part}");
                    }
                    #endregion
                    #region ��ÿһ���ָ�ֵ��ṹ��Ĳ���
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
                    #region ��������, ָ����һ����
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
    /// Ӧ��GUID�ṹ��
    /// </summary>
    public struct App_GUID_Struct
    {
        public App_GUID_Struct_Part A, B, C, D, E;
    }

    /// <summary>
    /// Ӧ��GUID�ṹ�岿��
    /// </summary>
    public struct App_GUID_Struct_Part
    {
        public char A, B, C, D, E;
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
    /// ����������
    /// </summary>
    public enum PublisherType
    {
        Personal = 0, Studio = 1, Business = 2
    }
}
