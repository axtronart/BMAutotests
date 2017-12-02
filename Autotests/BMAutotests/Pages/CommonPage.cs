using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace BMAutotests.Pages
{
    public class CommonPage : TablePage
    {
        
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'title')]")]
        private IWebElement header;

        public CommonPage(PageManager pageManager)
            : base(pageManager)
        {
            
        }

        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.ClassName("b-sidebar-header")));
        }
        public virtual void headerClick()
        {
            header.Click();
        }
    }
}
