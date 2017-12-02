using BMAutotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace BMAutotests.Menues
{
    public class AdminMenu : BaseMenu
    {
        [FindsBy(How = How.XPath, Using = "//menu")]
        private IWebElement Menu;
         public AdminMenu(PageManager pageManager)
            : base(pageManager)
        {
               
        }
         public override void ensurePageLoaded()
         {
             var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
             wait.Until(d => d.FindElement(By.ClassName("b-sidebar-menu-text")));
         }

        public virtual void ClickByText(string text)
        {

            Menu.FindElement(By.XPath("//span[.='" + text + "']")).Click();
        }
    }
}
