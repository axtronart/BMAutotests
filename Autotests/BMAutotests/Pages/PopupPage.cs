using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;


namespace BMAutotests.Pages
{
    public class PopupPage : TablePage
    {
        [FindsBy(How = How.ClassName, Using = "b-icon-close")]
        private IWebElement closeButton;
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'b-popup-header-more-icon')]")]
        private IWebElement menuPopup;
        [FindsBy(How = How.XPath, Using = "//form//div[@class='l-right']/div")]
        private IWebElement cancelButton;

        private IWebElement PopupOverlay;

        [FindsBy(How = How.XPath, Using = "//form//div[@class='l-right']/button")]
        private IWebElement saveButton;

        //общих элементов для поиска внутри таблицы пока нет
        [FindsBy(How = How.XPath, Using = "//section//div[@class = 'b-popup-add-tabs']")]
        private IWebElement Content;
        [FindsBy(How = How.XPath, Using = "//header/div[2]")]
        private IWebElement menuButton;
        [FindsBy(How = How.XPath, Using = "//header/div[contains(@class, 'b-popup-header-title')]")]
        private IWebElement popupHeader;

        public PopupPage(PageManager pageManager)
            : base(pageManager)
        {

        }

        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.XPath("//*[contains(@class,'b-popup-header')]")));
            PopupOverlay = pageManager.driver.FindElement(By.XPath("//div[contains(@class,'b-popup-overlay')]"));
            //Ожидание пока попап остановится
            waitForFixPosition(PopupOverlay);
            waitSecond(1000);
        }

        internal void clickTabByName(string p)
        {
            pageManager.driver.FindElement(By.XPath("//div[text() ='" + p + "']")).Click();
        }

        public void closePopup()
        {
            closeButton.Click();
            waitClosedPopup();
        }

        public void cancelClick()
        {
            cancelButton.Click();
        }

        public void closePopupFromCancel()
        {
            cancelClick();
            waitClosedPopup();
        }
        public void menuPopupClick()
        {
            menuPopup.Click();
        }
        public void menuButtonClick()
        {
            menuButton.Click();
        }

        public void waitClosedPopup()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(ExpectedConditions.StalenessOf(PopupOverlay));
        }
        internal override IWebElement getTable(int index = 0)
        {
            //отдельный метод для попапа
            string locator = ".//div[@class='ui-table-body']";
            if (Content.FindElements(By.XPath(locator)).Count > 0)
                return Content.FindElements(By.XPath(locator))[index];
            else
                return null;
        }
        internal void saveClick()
        {
            saveButton.Click();
        }
    }
}
