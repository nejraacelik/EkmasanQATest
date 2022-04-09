using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using QATest.Setup;

namespace EkmasanQATest
{
    [TestClass] 
    public class EkmasanDelivererTest:EkmasanBaseTest
    {
      [TestMethod]

        public void EkmasanDelivererFind()
        {

            bool isLoged = Login.EkmasanLogin(Driver.Instance, Parameters.Url);
            Assert.IsTrue(isLoged);

            var deliverer =Driver.Instance.FindElement(By.CssSelector("body > div.sidebar.sidebar-hide-to-small.sidebar-shrink.sidebar-gestures > div > div.nano-content > ul > li:nth-child(2) > a"));
            deliverer.Click();
            var searchField = Driver.Instance.FindElement(By.CssSelector("form > div > input.form-control"));
            searchField.SendKeys("Test");
            var searchClick = Driver.Instance.FindElement(By.CssSelector("form > div > input.ml-4.btn.btn-primary"));
            searchClick.Click();
            var tableField = Driver.Instance.FindElement(By.CssSelector("table[class='table table-striped']"));
            var tableBody = Driver.Instance.FindElement(By.TagName("tbody"));
            var tableRows = tableBody.FindElements(By.TagName("tr"));
            Assert.AreEqual(1, tableRows.Count);    


        }
    }
}
