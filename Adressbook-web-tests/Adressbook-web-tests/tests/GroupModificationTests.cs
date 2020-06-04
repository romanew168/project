using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupModificationTests: AuthTestBase
    {
        [Test]
        public void GroupModificationTest() {

            GroupData newData = new GroupData("sss");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldgroups = app.Groups.GetGroupList();

            GroupData oldData = oldgroups[0];

            app.Groups.Modify(1, newData);
            Assert.AreEqual(oldgroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newgroups = app.Groups.GetGroupList();

            oldgroups[0].Name = newData.Name;
            oldgroups.Sort();
            newgroups.Sort();
            Assert.AreEqual(oldgroups, newgroups);

            foreach (GroupData group in newgroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
                

            }



        }



    }

}
