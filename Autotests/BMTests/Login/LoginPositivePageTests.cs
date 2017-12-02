using BMAutotests.AppLogic;
using BMAutotests.Model;
using NUnit.Framework;

namespace BMTests
{
    [TestFixture()]
    public class LoginPositivePageTests : InternalPageTests
    {

        [Test, TestCaseSource(typeof(FileHelper), "user")]
        [Category("Login")]
        public void LoginPositive(User user)
        {
            app.userHelper.loginAs(user);
            //проверка выполняется методом логаут
            Assert.IsTrue(app.userHelper.isLoggedIn());
        }
    }
}
