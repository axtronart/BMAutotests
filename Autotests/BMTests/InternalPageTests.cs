using NUnit.Framework;
namespace BMTests
{
    [TestFixture()]
    public class InternalPageTests: TestBase
    {
       
        [TearDown]
        public void logout()
        {
            app.userHelper.logout();
        }
    }
}
