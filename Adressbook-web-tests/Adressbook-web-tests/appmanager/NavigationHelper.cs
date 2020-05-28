using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        

        public NavigationHelper(IWebDriver driver) : base(driver)
          {

          }

        public void GoToHomePage()
        {
            //open homepage
            driver.Navigate().GoToUrl("http://localhost/addressbook");
        }


        public void GoToGroup()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

    }
}
