using BMAutotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BMAutotests.Menues
{
    public class ExternalMenu : BaseMenu
    {
        [FindsBy(How = How.XPath, Using = "//menu")]
        private IWebElement Menu;
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'b-logo-container')]/div[@title='Основное меню']")]
        private IWebElement MainMenuState;
        
         public ExternalMenu(PageManager pageManager)
            : base(pageManager)
        {
               
        }

        public virtual void ClickByText(string text)
        {
            Menu.FindElement(By.LinkText(text)).Click();
        }
      
        public virtual void ClickByIndex(int index)
        {
            Menu.FindElements(By.ClassName("b-sidebar-menu-list-item"))[index].Click();
        }

        public void clickByMainMenu()
        {
            MainMenuState.Click();
        }
    }
}
