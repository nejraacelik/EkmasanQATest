using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using QATest.Setup;
using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace EkmasanQATest
{
    [TestClass]
    public class EkmasanLoginTest :EkmasanBaseTest
    {
      

        [TestMethod]
        public void EkmasanEmptyLogin()
        {
            string URL = Parameters.Url;
            Url.GoTo(URL);
            
            try
            {
                var username = Driver.Instance.FindElement(By.Id("Username"));
                Assert.IsNotNull(username);
                var password = Driver.Instance.FindElement(By.Id("Password"));
                Assert.IsNotNull(password);
                var signinbutton = Driver.Instance.FindElement(By.CssSelector("button[class='btn btn-primary btn-block']"));
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
                Functions.WriteInto(FilePath, "Error" + e.Message);
                Assert.Fail();  

            }


        }

        [TestMethod]
        public void EkmasanWrongLogin()
        {
            string URL = Parameters.Url;
            Url.GoTo(URL);
            string user22 = "user22";
            string password1 = "password1";
            try
            {
                var username = Driver.Instance.FindElement(By.Id("Username"));
                Assert.IsNotNull(username);
                username.SendKeys(user22);
                var password = Driver.Instance.FindElement(By.Id("Password"));
                Assert.IsNotNull(password);
                password.SendKeys(password1);
                var signinbutton = Driver.Instance.FindElement(By.CssSelector("button[class='btn btn-primary btn-block']"));
                Assert.IsNotNull(signinbutton);
                signinbutton.Click();

                Thread.Sleep(500);

                var messageerror = Driver.Instance.FindElement(By.CssSelector("body > div.authincation.h-100vh > div > div > div.col-md-6 > div > div > div > div > div"));
                Assert.IsNotNull(messageerror);

                Functions.TakeScreenShot();



            }
            catch (Exception e)
            {
                Functions.WriteInto(FilePath, "Error" + e.Message);
                Assert.Fail();

            }
        }
        [TestMethod]

        public void EkmasanCorrectLogin()
        {
            bool isLoged = Login.EkmasanLogin(Driver.Instance, Parameters.Url);
            Assert.IsTrue(isLoged);
            //string URL = parameters.Url;
            //    string subject = "";
            //    var loginFilePath = @"C:\Ekmasan Test Configuration\Login.txt";
            //    Url.GoTo(URL);
            //   List<string> lines=File.ReadLines(loginFilePath).ToList();
            //    try
            //    {
            //        var username = Driver.Instance.FindElement(By.Id("Username"));
            //        Assert.IsNotNull(username);
            //        username.SendKeys(lines[0]);
            //        var password = Driver.Instance.FindElement(By.Id("Password"));
            //        Assert.IsNotNull(password);
            //        password.SendKeys(lines[1]);
            //        var signinbutton = Driver.Instance.FindElement(By.CssSelector("button[class='btn btn-primary btn-block']"));
            //        Assert.IsNotNull(signinbutton);
            //        signinbutton.Click();

            //        Thread.Sleep(500);
            //        Functions.TakeScreenShot();

            //    var adminLink = Driver.Instance.FindElement(By.CssSelector("body > div.header > div > div > div > div.float-right > ul > li > span"));
            //    Assert.IsNotNull(adminLink);

            //    }
            //    catch (Exception e)
            //    {
            //        Functions.WriteInto(filePath, "Error" + e.Message);
            //        Assert.Fail();

            //    }

        }


       

    }
}