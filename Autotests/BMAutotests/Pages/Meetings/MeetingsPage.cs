using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace BMAutotests.Pages
{
    public class MeetingsPage : CommonPage
    {
        [FindsBy(How = How.CssSelector, Using = "body > div.wrapper > div > div.clearfix.shrow > a")]
        private IWebElement createButton; 

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'b-project-content')]")]
        private IWebElement caseContent;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'b-project-content')]/div[1]")]
        private IWebElement caseCardInfo; // Данные по делу (Проект, Название, Тип, Ответственный, Заказчик и т.д)

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'save')]")]
        private IWebElement saveButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='case-card-tab-content']")]
        private IWebElement caseTabPanel;

        [FindsBy(How = How.XPath, Using = ".//div[contains(@class,'b-actions-dropdown')]")]
        private IWebElement caseMenu;

        private IWebElement secondBlock;

        public MeetingsPage(PageManager pageManager)
            : base(pageManager)
        {
            pagename = "meetingspage";
        }

        public override void ensurePageLoaded()
        {
            waitSecond();
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.XPath("/html/body/div[1]/div/div[1]")));
        }

        public void openCaseMenu()
        {
            caseMenu.Click();
        }

        internal void createButtonClick()
        {
            createButton.Click();
        }
    }
}
