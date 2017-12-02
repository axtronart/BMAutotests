using BMAutotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;


namespace BMAutotests
{
    public class LoginPage : Page
    {
        [FindsBy(How = How.Id, Using = "loginText")]
        private IWebElement usernameField;

        [FindsBy(How = How.Id, Using = "passwordText")]
        private IWebElement passwordField;

        [FindsBy(How = How.Id, Using = "loginButton")]
        private IWebElement submitButton;

        public LoginPage(PageManager pageManager)
            : base(pageManager)
        {
            pagename = "loginpage";
        }


        public void setUserNameField(string username)
        {
            setTextField(usernameField, username);
        }

        public void setPasswordField(string password)
        {
            setTextField(passwordField,password);
        }

        public void clearPassword()
        {
            ClearManual(passwordField);
        }

        public void clearLogin()
        {
            ClearManual(usernameField);
        } 

        public void submitClick()
        {
            submitButton.Click();
        }

        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.Id("loginButton")));
        }
    }
}
