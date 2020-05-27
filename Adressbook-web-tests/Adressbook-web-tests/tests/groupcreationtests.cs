﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {

            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroup();
            app.Groups.InitGroupCreation();
            app.Groups.FillGroupForm(new GroupData("aaa", "ddd", "fff"));
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnGroupPage(); 
        }

        
    }
}
