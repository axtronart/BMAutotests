using BMAutotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace BMAutotests.Menues
{
    public class BaseMenu : Page
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='modules_base_app-left']//ul")]
        private IWebElement Menu;
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'b-logo-container')]/div[@title='Основное меню']")]
        private IWebElement MainMenuState;
      
        public BaseMenu(PageManager pageManager)
            : base(pageManager)
        {
               
        }
        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.ClassName("modules_base_app-left")));
        }
        public virtual void ClickByText(string text)
        {
            Menu.FindElement(By.LinkText(text)).Click();
        }

        public virtual void ClickByIndex(int index)
        {
            Menu.FindElements(By.ClassName("modules_base_app_left_navMenu_item-main"))[index].Click();
        }
    }
}


