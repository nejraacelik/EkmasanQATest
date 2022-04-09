using Microsoft.VisualStudio.TestTools.UnitTesting;
using QATest.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkmasanQATest
{
    [TestClass]

    public class EkmasanBaseTest
    {
        public TestArguments Parameters { get; private set; }
        public string FilePath => @"C:\Ekmasan Test Configuration\LogFile.txt";

        [TestInitialize]

        public void Init()
        {
            var downloadDirectory = @"C:\Files";
            var driverDirectory = @"C:\Drivers\";
            var configFilePath = @"C:\Ekmasan Test Configuration\config.xml";

            Functions.WriteInto(FilePath, "Start of init");
            Parameters = new TestArguments(configFilePath);
            Driver.Initiliaze(driverDirectory, downloadDirectory, Parameters.Browser);
            Functions.WriteInto(FilePath, "End of init");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }

}
