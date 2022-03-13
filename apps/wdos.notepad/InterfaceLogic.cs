using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.Composition;
using BaseContract = wdos.contract;
using Contract = wdos.wpf.contract;
using IContract = wdos.wpf.contract.IContract;

namespace wdos.notepad
{
    [Export(typeof(IContract))]
    public class InterfaceLogic : IContract
    {
        public BaseContract.App_GUID_Struct AppGUID()
        {
            return BaseContract.GUID_Helper.Get_GUID_FromString("",
                BaseContract.GUID_Status.Test);
        }

        public string AppName() => "NotePad";

        public BaseContract.AppPublisherStruct AppPublisher()
        {
            return new BaseContract.AppPublisherStruct()
            {
                publisherName = "WDOS",
                publisherType = BaseContract.PublisherType.Personal
            };
        }

        public Contract.EnvironmentStatus CheckEnvironment()
        {
            return new Contract.EnvironmentStatus()
            {
                dependencies = new List<Contract.DependencyStatus>
                {
                    new Contract.DependencyStatus()
                    {
                        name = "dotnet",
                        versions = new Dictionary<string, bool>()
                        {
                            { "6.0", true }
                        },
                        message = "If this not pass, you won't see me!"
                    }
                },
                readyToRun = true
            };
        }

        public bool Start()
        {

            return true;
        }
    }
}
