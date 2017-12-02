using BMAutotests.AppLogic;
using BMAutotests.Model;
using NUnit.Framework;

namespace BMTests
{
    [TestFixture()]
    public class CreateMeetingsTests : TestBase
    {
        [SetUp]
        public void Login()
        {
            app.userHelper.loginAs(app.userHelper.getSecretary());
            app.userHelper.waitsecond();
            app.userHelper.clickMenu(2);
        }


        [Test, TestCaseSource(typeof(FileHelper), "meetings")]
        [Category("Meeting")]
        public void CreateMeeting(Meeting meeting)
        {
            //добавление нового заседания
            app.meetingHelper.createMeeting(meeting);
            app.userHelper.waitClosedPopup();

            Meeting testMeeting = app.meetingHelper.getMeeting();
            Assert.IsTrue(app.meetingHelper.compareMeeting(meeting, testMeeting));
        }


        [TearDown]
        public void deleteMeeting()
        {
            //app.meetingHelper.deleteMeeting();
        }
    }
}
