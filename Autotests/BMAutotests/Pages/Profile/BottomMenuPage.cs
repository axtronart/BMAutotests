using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace BMAutotests.Pages
{
    public class HeaderPage : CommonPage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='modules_base_app_header-user']")]
        private IWebElement userMenu;

        public HeaderPage(PageManager pageManager)
            : base(pageManager)
        {
            pagename = "headerPage";
        }

        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.XPath("//div[@class='modules_base_app_header-companies']")));
        }
        public void userMenuClick()
        {
            userMenu.Click();
        }
    }
}
