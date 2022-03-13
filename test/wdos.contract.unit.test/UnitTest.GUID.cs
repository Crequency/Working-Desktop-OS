using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace wdos.contract.unit.test
{
    [TestClass]
    public class UnitTest_GUID
    {
        private string Test_App_GUID_Struct(App_GUID_Struct ags)
        {
            string rst = $"{ags.A.part}-" +
                $"{ags.B.part}-{ags.C.part}-" +
                $"{ags.D.part}-{ags.E.part}";
            return rst;
        }

        [TestMethod]
        public void TestMethod_GUID()
        {
            App_GUID_Struct ags1 = GUID_Helper.Get_GUID_FromString("" +
                "TD244-P4NB7-YQ6XK-Y8MMM-YWV2J",
                null);
            App_GUID_Struct ags2 = GUID_Helper.Get_GUID_FromString("" +
                "VHF9H-NXBBB-638P6-6JHCY-88JWH",
                null);
            try
            {
                App_GUID_Struct ags3 = GUID_Helper.Get_GUID_FromString("" +
                    "VHF9H-NXBBB-63P6-6JHCY-88JWH",
                    null);
            }
            catch (exceptions.GUID_Exception ex)
            {
                Console.WriteLine(ex.Message);
                System.Windows.MessageBox.Show(ex.ErrorDescribe);
                Console.WriteLine(ex.ErrorDescribe);
            }
            try
            {
                App_GUID_Struct ags4 = GUID_Helper.Get_GUID_FromString("" +
                    "VHF9H-NXBBB-sdavsda(*E&(*&FDWH",
                    null);
            }
            catch (exceptions.GUID_Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ErrorDescribe);
            }
            Console.WriteLine(Test_App_GUID_Struct(ags1));
            Console.WriteLine(Test_App_GUID_Struct(ags2));
            Assert.AreEqual(Test_App_GUID_Struct(ags1),
                "TD244-P4NB7-YQ6XK-Y8MMM-YWV2J");
            Assert.AreEqual(Test_App_GUID_Struct(ags2),
                "VHF9H-NXBBB-638P6-6JHCY-88JWH");
        }
    }
}