using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void GroupCreationTest()
        {

            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";

            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.Create(group);

            List<GroupData> newgroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);


        }
        [Test]
        public void EGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newgroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);
        }

        [Test]
        public void BadNameCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldgroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newgroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldgroups.Count + 1, newgroups.Count);
        }
    }
}
