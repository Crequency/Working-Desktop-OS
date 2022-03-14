using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO.Pipes;
using System.Security.Principal;

namespace wdos.unit.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_Pipe()
        {
            PipeServer ps = new();
            ps.StartListen();

            NamedPipeClientStream c1 = new("localhost", "WDOS_RegisterServer",
                PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);
            c1.Connect();
            var ss = new StreamString(c1);
            // Validate the server's signature string.
            if (ss.ReadString() == "WDOS_Welcome")
            {
                // The client security token is sent with the first write.
                // Send the name of the file whose contents are returned
                // by the server.
                ss.WriteString("UnitTest!!!");
                Console.WriteLine(ss.ReadString());
            }
            else
            {
                Console.WriteLine("Server could not be verified.");
            }
            c1.Close();
        }
    }
}