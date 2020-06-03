﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
       
        
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.Remove(1);
            List<GroupData> newgroups = app.Groups.GetGroupList();
            
            oldgroups.RemoveAt(0);
            Assert.AreEqual(oldgroups, newgroups);

        }

    }
}
