using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using QATest.Setup;
using System;
using System.Threading;

namespace EkmasanQATest
{
    [TestClass]
    public class EkmasanLoginTest
    {
        private object openUrl;
        private TestArguments parameters;
        private object subject;
        private object body;
        private string filePath = @"C:\Ekmasan Test Configuration\LogFile.txt";

        [TestInitialize]

        public void Init()
        {
            var downloadDirectory = @"C:\Files";
            var driverDirectory = @"C:\Drivers\";
            var configFilePath = @"C:\Ekmasan Test Configuration\config.xml";

            Functions.WriteInto(filePath, "Start of init");
            parameters = new TestArguments(configFilePath);
            Driver.Initiliaze(driverDirectory, downloadDirectory, parameters.Browser);
            Functions.WriteInto(filePath, "End of init");
        }

        [TestMethod]
        public void EkmasanEmptyLogin()
        {
            string URL = parameters.Url;
            string subject = "";
            Url.GoTo(URL);
            
            try
            {
                var username = Driver.Instance.FindElement(By.Id("Username"));
                Assert.IsNotNull(username);
                var password = Driver.Instance.FindElement(By.Id("Password"));
                Assert.IsNotNull(password);
                var signinbutton = Driver.Instance.FindElement(By.CssSelector("div > div > div >div > form> div.text-center > button"));
                Assert.IsNotNull(signinbutton);
                signinbutton.Click();

                Thread.Sleep(500);

                var usernameerror = Driver.Instance.FindElement(By.Id("Username-error"));
                Assert.IsNotNull(usernameerror);
                var passworderror = Driver.Instance.FindElement(By.Id("Password-error"));
                Assert.IsNotNull(passworderror);

                Functions.TakeScreenShot();



            }
            catch (Exception e)
            {
                Functions.WriteInto(filePath, "Error" + e.Message);
                Assert.Fail();  

            }


        }


        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }


    }
}