﻿using System;
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
        

        public NavigationHelper(ApplicationManager manager) : base(manager)
          {

          }

        public void GoToHomePage()
        {
            //open homepage
            if (driver.Url == "http://localhost/addressbook")
            {
                return;
            }

            driver.Navigate().GoToUrl("http://localhost/addressbook");
        }

         
        public void GoToGroup()
        {
            if (driver.Url == "http://localhost/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }

            driver.FindElement(By.LinkText("groups")).Click();
        }

    }
}
