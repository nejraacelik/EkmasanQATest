using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QATest.Setup;
using System.Threading;
using System.IO;
using OpenQA.Selenium;


namespace EkmasanQATest
{
    public class Login
    {

        public static bool EkmasanLogin(IWebDriver webDriver, string url)
        {
            var loginFilePath = @"C:\Ekmasan Test Configuration\Login.txt";
            Url.GoTo(url);
            string[] lines = File.ReadLines(loginFilePath).ToArray();
            try
            {
                var username = webDriver.FindElement(By.Id("Username"));
                Assert.IsNotNull(username);
                username.SendKeys(lines[0]);
                var password = webDriver.FindElement(By.Id("Password"));
                Assert.IsNotNull(password);
                password.SendKeys(lines[1]);
                var signinbutton = webDriver.FindElement(By.CssSelector("button[class='btn btn-primary btn-block']"));
                Assert.IsNotNull(signinbutton);
                signinbutton.Click();

                Thread.Sleep(500);
                Functions.TakeScreenShot();

                return true;

            }

            catch (Exception e)
            {
                return false;

            }

        }
    }
}
