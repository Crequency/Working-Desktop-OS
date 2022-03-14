using System.IO;

namespace wdos.exceptions
{
    public class Pipe_Exception : IOException, IWDOS_Exception
    {
        public Pipe_Exception()
        {
            
        }

        public Pipe_Exception(string message) : base(message)
        {

        }

        public Pipe_Exception(string message, string errdescr) : base(message)
        {
            ErrorDescribe = errdescr;
        }

        public string? ErrorDescribe { get; set; }

        public IWDOS_Exception.ErrorType ErrorT { get; set; }

        public IWDOS_Exception.ErrorLevel ErrorLV { get; set; }

        public ushort ErrorID { get; set; }
    }
}
