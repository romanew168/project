using System;
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

            Assert.AreEqual(oldgroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newgroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldgroups[0];
            oldgroups.RemoveAt(0);
            Assert.AreEqual(oldgroups, newgroups);

            foreach (GroupData group in newgroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);

            }
        }

    }
}
