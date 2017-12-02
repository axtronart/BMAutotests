using BMAutotests.AppLogic;
using BMAutotests.Model;
using NUnit.Framework;

namespace BMTests
{
    [TestFixture()]
    public class LoginNegativePageTests : TestBase
    {

        [Test, TestCaseSource(typeof(FileHelper), "loginincorrect")]
        [Category("Login")]
        public void LoginNegative(User user)
        {
            app.userHelper.loginAs(user);
            Assert.AreEqual(user.role, app.userHelper.isNotLogged());
        }

        [TearDown]
        public void ClearLogin()
        {
            app.userHelper.loginClear();
        }
    }
}
