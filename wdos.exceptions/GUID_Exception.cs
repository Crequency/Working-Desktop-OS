using System;

namespace wdos.exceptions
{
    public class GUID_Exception : Exception, IWDOS_Exception
    {
        public GUID_Exception()
        {

        }

        public GUID_Exception(string message) : base(message)
        {

        }

        public GUID_Exception(string message, string err) : base(message)
        {
            ErrorDescribe = err;
        }

        public string? ErrorDescribe { get; set; }

        public IWDOS_Exception.ErrorType ErrorT { get; set; }

        public IWDOS_Exception.ErrorLevel ErrorLV { get; set; }

        public ushort ErrorID { get; set; }
    }
}
