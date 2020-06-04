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
    public class GroupHelper : HelperBase
    {
    
       public GroupHelper(ApplicationManager manager) : base(manager)
        {
            }

        

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroup();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnGroupPage(); 
            return this;
        }

        private List<GroupData> groupCache = null;

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroup();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }

            }
            
            return new List<GroupData> (groupCache);

        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroup();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnGroupPage();
            return this;
            
        }
              

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroup();
            SelectGroup(p);
            RemoveGroup();
            ReturnGroupPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
         
            return this;
        }

        

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper ReturnGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }
    }
}

