using BMAutotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace BMAutotests.Menues
{
    public class IconsMenu : ExternalMenu
    {
        [FindsBy(How = How.ClassName, Using = "b-floating_button-icon_list")]
        private IWebElement Menu;
        [FindsBy(How = How.ClassName, Using = "b-floating_button-el")]
        private IWebElement ContextMenuButton;

        public IconsMenu(PageManager pageManager)
            : base(pageManager)
        {
            pagename = "iconsmenu";
        }

        public void waitForOpen()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.XPath("//div[contains(@class, 'b-floating_button-icon_list-item--')]")));
            waitForFixPosition(pageManager.driver.FindElement(By.XPath("//div[contains(@class, 'b-floating_button-icon_list-item--')]")));
        }                                                                 
        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.ClassName("b-floating_button-el")));
        }
        internal void clickPlus()
        {
            ContextMenuButton.Click();
        }
        public override void ClickByIndex(int index)
        {
            Menu.FindElements(By.ClassName("b-floating_button-icon_list-item"))[index].Click();
        }

    }
}
