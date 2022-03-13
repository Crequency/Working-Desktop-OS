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
        /// ÿ�θ�ֵ
        /// </summary>
        /// <param name="agsp">GUID�ṹ��Part����</param>
        /// <param name="yet">part</param>
        private static void SetPart_GUID_Part(ref App_GUID_Struct_Part agsp, string yet)
        {
            agsp.part = yet; agsp.A = yet[0];
            agsp.B = yet[1]; agsp.C = yet[2];
            agsp.D = yet[3]; agsp.E = yet[4];
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
                    #region �ֶβ��ָ�ֵ
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
