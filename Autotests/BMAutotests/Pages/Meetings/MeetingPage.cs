using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace BMAutotests.Pages
{
    public class MeetingPage : CommonPage
    {
        [FindsBy(How = How.CssSelector, Using = "body > div.wrapper > div > div.clearfix.shrow > a")]
        private IWebElement createButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'l-track i-type ellipsis')]")]
        private IWebElement typeField;

        [FindsBy(How = How.XPath, Using = "//span[@class = 'ellipsis']")]
        private IWebElement numberField;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'save')]")]
        private IWebElement saveButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='case-card-tab-content']")]
        private IWebElement caseTabPanel;

        [FindsBy(How = How.XPath, Using = ".//div[contains(@class,'b-actions-dropdown')]")]
        private IWebElement caseMenu;

        private IWebElement secondBlock;

        public MeetingPage(PageManager pageManager)
            : base(pageManager)
        {
            pagename = "meetingpage";
        }

        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.Id("meeting-entity")));
        }

        internal string getType()
        {
            return getCellText(typeField);
        }

        internal string getNumber()
        {
            return getCellText(numberField, "Заседание №");
        }
    }
}
