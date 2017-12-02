using BMAutotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace BMAutotests.Menues
{
    public class HeaderMenu : BaseMenu
    {
        [FindsBy(How = How.ClassName, Using = "b-header-menu")]
        private IWebElement Menu;
      
        public HeaderMenu(PageManager pageManager)
            : base(pageManager)
        {
            pagename = "headermenu";
        }

        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.ClassName("b-header-menu")));
            waitForFixPosition(pageManager.driver.FindElement(By.ClassName("b-header-menu")));
        }

        public override void ClickByText(string text)
        {
            Menu.FindElement(By.XPath("//*[@class = 'b-header-menu-item']/span[text() ='" + text + "']")).Click();
        }

        public override void ClickByIndex(int index)
        {
            Menu.FindElements(By.XPath("//*[@class = 'b-header-menu-item']"))[index].Click();
        }
    }
}
