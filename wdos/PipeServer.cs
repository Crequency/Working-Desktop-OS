using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wdos.global;

namespace wdos
{
    internal class PipeServer
    {
        internal Dictionary<string, Thread> ServerThreads = new();
        internal NamedPipeServerStream RegisterServer =
            new("RegisterServer", PipeDirection.InOut,
                Global.PipeServer_MaxThreads);
        internal int ThreadID = Environment.CurrentManagedThreadId;

        internal PipeServer()
        {
            new Thread(StartListen).Start();
        }

        /// <summary>
        /// 停止监听
        /// </summary>
        internal void StopListen()
        {
            RegisterServer.Close();
        }

        /// <summary>
        /// 开始监听
        /// </summary>
        internal void StartListen()
        {
            RegisterServer.WaitForConnection();
            try
            {

            }
            catch (IOException e)
            {

            }
        }
    }
}
