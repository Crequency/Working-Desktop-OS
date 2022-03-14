using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static wdos.exceptions.IWDOS_Exception;

namespace wdos.exceptions
{
    public interface IWDOS_Exception
    {
        /// <summary>
        /// 错误描述
        /// </summary>
        public string? ErrorDescribe { get; set; }

        public ErrorType ErrorT { get; set; }

        public ErrorLevel ErrorLV { get; set; }

        public ushort ErrorID { get; set; }

        /// <summary>
        /// 错误类型 -> 所有可能的错误类型
        /// </summary>
        /// <value> FE -> File Error        ->  文件错误</value>
        /// <value> SE -> Surrounding Error ->  环境错误</value>
        /// <value> CE -> Compile Error     ->  编译错误</value>
        /// <value> DE -> Data Error        ->  数据错误</value>
        public enum ErrorType
        {
            FE = 0, SE = 1, CE = 2, DE = 3
        }

        /// <summary>
        /// 错误级别 -> 所有可能的错误级别
        /// </summary>
        /// <value> Info    ->  ℹ 建议</value>
        /// <value> Warning ->  ⚠ 警告</value>
        /// <value> Error   ->  ❌ 错误</value>
        /// <value> Fatal   ->  😩 崩溃</value>
        public enum ErrorLevel
        {
            Info = 0, Warning = 1, Error = 2, Fatal = 3
        }
    }

    public static class ExceptionHelper
    {
        private static string? EnumToStr(ErrorType et)
        {
            return et switch
            {
                ErrorType.FE => "FE",
                ErrorType.SE => "SE",
                ErrorType.CE => "CE",
                ErrorType.DE => "DE",
                _ => null,
            };
        }

        public static string GenerateErrorDescr(ErrorType et, ushort ID, string message)
        {
            return $"WDOS:{EnumToStr(et)}{ID} >> {message}";
        }
    }
}
