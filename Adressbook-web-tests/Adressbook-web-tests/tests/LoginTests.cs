using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests: AuthTestBase
    {
        [Test]
        public void LoginValid()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
        [Test]
        public void LoginInValid()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "123");
            app.Auth.Login(account);

            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }

    }
}
