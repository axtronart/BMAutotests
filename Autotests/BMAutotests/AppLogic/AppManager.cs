using BMAutotests.Pages;
using OpenQA.Selenium;

namespace BMAutotests.AppLogic
{
    public class AppManager
    {
        public AppManager(ICapabilities capabilities, string baseUrl, string hubUrl)
        {
            Pages = new PageManager(capabilities, baseUrl, hubUrl);

            userHelper = new UserHelper(this);
            meetingHelper = new MeetingHelper(this);
            
        }

        public PageManager Pages { get; set; }
        public UserHelper userHelper { get; set; }
        public static FileHelper fileHelper { get; set; }
        public MeetingHelper meetingHelper { get; set; }
    }
}
