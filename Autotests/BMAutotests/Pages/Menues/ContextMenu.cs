using BMAutotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace BMAutotests.Menues
{
    public class ContextMenu : MainMenu
    {
        [FindsBy(How = How.ClassName, Using = "b-common_context_menu-content")]
        private IWebElement Menu;
        [FindsBy(How = How.XPath, Using = "//*[@class = 'b-common_context_menu-content']//input")]
        private IWebElement inputField;

        [FindsBy(How = How.XPath, Using = "//ul[contains(@class, 'b-radio_list')]")]
        private IWebElement radioList;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'b-edit_popup-footer')]/div[2]")]
        private IWebElement cancelButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'b-edit_popup-footer')]/div[1]")]
        private IWebElement saveButton;
      
        public ContextMenu(PageManager pageManager)
            : base(pageManager)
        {
            pagename = "contextmenu";
        }

        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.ClassName("b-common_context_menu-content")));
            waitForFixPosition(pageManager.driver.FindElement(By.ClassName("b-common_context_menu-content")));
        }
        public void ensureListLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.ClassName("b-context_menu-scroll")));
            waitForFixPosition(pageManager.driver.FindElement(By.ClassName("b-context_menu-scroll")));
        }

        public override void ClickByText(string text)
        {
            Menu.FindElement(By.XPath(".//*[contains(@id,'item_')]/span[text() ='" + text + "']")).Click();
        }

        public override void ClickByIndex(int index)
        {
            Menu.FindElements(By.XPath(".//div[contains(@id,'item_')]"))[index].Click();
        }

        public void ClickArchiveByIndex(int index)
        {
            Menu.FindElements(By.XPath(".//span/label/span[last()]"))[index].Click();
        }

        internal void setText(string name)
        {
            setTextField(inputField, name);
        }

        internal void saveClick()
        {
            saveButton.Click();
        }
        public void setRadioButton(string value)
        {
            radioList.FindElement(By.XPath(".//span[ text() = '" + value + "']")).Click();
        }
        public void setSelectableMenu(string text)
        {
            if (text != null)
            {
                ensureListLoaded();
                Menu.FindElement(By.XPath(".//label[text() = '" + text + "']/../input")).Click();
            }
        }
    }
}
