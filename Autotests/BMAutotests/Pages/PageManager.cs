using BMAutotests.AppLogic;
using BMAutotests.Menues;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;


namespace BMAutotests.Pages
{
    public class PageManager
    {
        internal IWebDriver driver;
        internal string baseUrl;
        internal string browsername = "Default";
        internal string versionname = "defaultversion";
        internal int DimensionX = 1152;
        internal int DimensionY = 864;
        //время в секундах используемое для ожиданий на страницах
        public const int WAITTIMEFORFINDELEMENT = 20;//ожидание элемента
        //public const int WAITTIMEFORCLOSEPOPUP = 3;//таймаут для ожидания закрытия попапа, пока не работает
        public const int WAITPAGELOADTIME = 60; //таймаут для рефреша


        public PageManager(ICapabilities capabilities, string baseUrl, string hubUrl)
        {
            driver = WebDriverFactory.GetDriver(hubUrl, capabilities);
            browsername = capabilities.BrowserName;
            versionname = capabilities.Version;
            // driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(PageManager.WAITPAGELOADTIME));
            driver.Manage().Window.Size = new System.Drawing.Size(DimensionX, DimensionY);
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Manage().Window.Maximize();

            if (!driver.Url.StartsWith(baseUrl))
            {
                driver.Navigate().GoToUrl(baseUrl);
            }
            this.baseUrl = baseUrl;

            mainMenu = InitElements(new MainMenu(this));
            meetingsPage = InitElements(new MeetingsPage(this));
            meetingsPage = InitElements(new MeetingsPage(this));
            loginPage = InitElements(new LoginPage(this));
            contextMenu = InitElements(new ContextMenu(this));
            headerMenu = InitElements(new HeaderMenu(this));
            adminMenu = InitElements(new AdminMenu(this));
            middleMenu = InitElements(new MiddleMenu(this));
            iconsMenu = InitElements(new IconsMenu(this));
            popupPage = InitElements(new PopupPage(this));
            profilePage = InitElements(new ProfilePage(this));
            headerPage = InitElements(new HeaderPage(this));
            remindPasswordPage = InitElements(new RemindPasswordPage(this));
        }

        private T InitElements<T>(T page) where T : Page
        {
            PageFactory.InitElements(driver, page);
            return page;
        }
        public void goToURL(string URL)
        {
            driver.Navigate().GoToUrl(baseUrl + URL);
        }

        public HeaderPage headerPage { get; set; }
        public MainMenu mainMenu { get; set; }
        public MeetingsPage meetingsPage { get; set; }
        public MeetingPopup meetingPopup { get; set; }
        public AdminMenu adminMenu { get; set; }
        public MiddleMenu middleMenu { get; set; }
        public LoginPage loginPage { get; set; }
        public ContextMenu contextMenu { get; set; }
        public HeaderMenu headerMenu { get; set; }
        public IconsMenu iconsMenu { get; set; }
        public PopupPage popupPage { get; set; }
        public ProfilePage profilePage { get; set; }
        public RemindPasswordPage remindPasswordPage { get; set; }
    }
}
