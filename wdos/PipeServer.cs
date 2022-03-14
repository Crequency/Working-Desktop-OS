using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wdos.global;

[assembly: InternalsVisibleTo("wdos.unit.test")]
namespace wdos
{
    internal class PipeServer
    {
        internal Dictionary<string, Thread> ServerThreads = new();
        internal NamedPipeServerStream? RegisterServer;
        internal int ThreadID = Environment.CurrentManagedThreadId;

        internal PipeServer()
        {
            try
            {
                RegisterServer = new("WDOS_RegisterServer", PipeDirection.InOut,
                    Global.PipeServer_MaxThreads);
            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// 停止监听
        /// </summary>
        internal void StopListen()
        {
            RegisterServer?.Close();
        }

        /// <summary>
        /// 开始监听
        /// </summary>
        internal void StartListen()
        {
            new Thread(() =>
            {
                RegisterServer?.WaitForConnection();
                try
                {
                    StreamString ss = new(RegisterServer);
                    ss.WriteString("WDOS_Welcome");
                    string ans = ss.ReadString();
                    ss.WriteString("Your new server: sdfgd");
                }
                catch (IOException e)
                {

                }
            }).Start();
        }
    }
}
