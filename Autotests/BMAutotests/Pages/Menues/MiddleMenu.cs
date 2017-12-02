using BMAutotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BMAutotests.Menues
{
    public class MiddleMenu : BaseMenu
    {
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'b-middle_menu')]/ul")]
        private IWebElement Menu;
        private const int pagesize = 20; //размер страницы
        private const string menulocator = ".//li[@ui-sref-active ='active']"; // локатор каждого элемента меню
        private const int timeforwaiting = 1000; // время загрузки следующего элемента меню

        public MiddleMenu(PageManager pageManager)
            : base(pageManager)
        {

        }
        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.XPath("//div[contains(@class,'b-middle_menu')]/ul")));
        }

        public virtual void ClickByText(string text)
        {
            Menu.FindElement(By.LinkText(text)).Click();
        }
        internal void deleteLastElement()
        {
            Actions act = new Actions(pageManager.driver);
            act.MoveToElement(Menu.FindElements(By.XPath(".//li"))[1]).Perform();
            Menu.FindElement(By.XPath("//*[contains(@class,'remove-icon')]")).Click();
        }
        internal void deleteElement(string name)
        {
            Actions act = new Actions(pageManager.driver);
            act.MoveToElement(Menu.FindElement(By.XPath(".//li/div[1]/div/div[.= '" + name + "']"))).Perform();
            Menu.FindElement(By.XPath("//*[contains(@class,'remove-icon')]")).Click();
        }
        public List<string> getList()
        {
            return getListFromUneditable(Menu.FindElements(By.XPath(".//li[@ui-sref-active ='active']")));
        }

        internal void scrollToBottom()
        {
            scrollToBottom(menulocator, timeforwaiting, pagesize);
        }

        private void scrollToBottom(string XPath, int timeforwaiting, int pagesize)
        {
            Actions act = new Actions(pageManager.driver);
            int temp = pagesize;
            for (int i = pagesize - 1; i < temp; i = i + pagesize) //начинаем прокручивать от конца страницы и до последнего элемента
            {
                act.MoveToElement(Menu.FindElements(By.XPath(XPath))[i]).Perform();
                waitSecond(timeforwaiting);//ждем пока подгрузятся еще справочники
                temp = Menu.FindElements(By.XPath(XPath)).Count;
            }
        }
        public bool isPagination()
        {
            return base.isPagination(menulocator, pagesize);
        }
    }
}
