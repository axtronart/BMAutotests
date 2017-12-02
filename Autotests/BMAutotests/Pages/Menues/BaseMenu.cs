using BMAutotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BMAutotests.Menues
{
    public class BaseMenu : Page
    {
        public BaseMenu(PageManager pageManager)
            : base(pageManager)
        {
               
        }
        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.ClassName("b-sidebar-menu")));
        }
    }
}


