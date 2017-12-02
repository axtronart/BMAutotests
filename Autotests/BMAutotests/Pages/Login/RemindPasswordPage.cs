using BMAutotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;


namespace BMAutotests
{
    public class RemindPasswordPage : Page
    {
        [FindsBy(How = How.XPath, Using = "//input")]
        private IWebElement usernameField;

        [FindsBy(How = How.XPath, Using = "//form/div/div[3]/div[2]/div[2]/button")]
        private IWebElement submitButton;

        public RemindPasswordPage(PageManager pageManager)
            : base(pageManager)
        {
            pagename = "remindpassword";
        }

        public void setUserNameField(string username)
        {
            usernameField.Click();
            setTextField(usernameField, username);
        }

        public void clearLogin()
        {
            usernameField.Clear();
        }

        public void submitClick()
        {
            submitButton.Click();
        }

        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.XPath("//span[text()= 'Вспомнили пароль?']")));
        }
    }
}
