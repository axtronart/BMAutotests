using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace BMAutotests.Pages
{

    public class Page
    {
        protected string pagename = "DefaultPage";

        protected PageManager pageManager;
        public Page(PageManager pageManager)
        {
            this.pageManager = pageManager;
        }

        public virtual void ensurePageLoaded()
        {

        }

        public virtual void ensureNewTabAppear(int count = 2)
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.WindowHandles.Count == count);
        }

        public Boolean waitPageLoaded()
        {
            try
            {
                ensurePageLoaded();
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }
        public int refreshPage(int num)
        {
            try
            {
                if (num < 5) //количество попыток обновления 
                {
                    pageManager.driver.Navigate().Refresh();

                }
                return 0;
            }
            catch (TimeoutException)
            {
                Console.Out.WriteLine("Ошибка при обновлении страницы пока тоже 0");
                return 0;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Ошибка при обновлении страницы второй кетч");
                Console.Out.WriteLine(e.Data);
                Console.Out.WriteLine("Количество попыток {0}", num);

                num++;
                return refreshPage(num);
            }
        }
        //метод для получения строки из текстового поля.
        protected string getTextField(IWebElement field)
        {
            try
            {
                if (field.GetAttribute("value") == "")
                {
                    return null;
                }
                else if (field.GetAttribute("value") == "дд.мм.гггг")//костыль для сафари
                {
                    return null;
                }
                else
                    return field.GetAttribute("value");
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }
        protected string getTextField(IWebElement field, string placeholder)
        {
            try
            {
                return getTextField(field).Remove(0, placeholder.Length);
            }
            catch
            {
                return null;
            }
        }
        protected string getTextField(IWebElement field, string placeholder, string placeholderend)
        {
            try
            {
                string temp = getTextField(field).Remove(0, placeholder.Length);
                return temp.Remove(temp.Length - placeholderend.Length);
            }
            catch
            {
                return null;
            }
        }

        protected void setTextField(IWebElement field, string text)
        {
            if (text != null)
                field.SendKeys(text);
        }
        protected void setDateFieldWithoutDatePicker(IWebElement dateField, string date)
        {
            if (date != null)
            {
                dateField.Click();
                dateField.SendKeys(Keys.Home);
                dateField.SendKeys(date);
            }
        }
        protected void setTimeField(IWebElement timeField, string time)
        {
            if (time != null)
            {
                ClearManual(timeField);

                timeField.Click();
                timeField.SendKeys(Keys.Home);
                timeField.SendKeys(time);
            }
        }
        protected void setTimeFieldWithDelay(IWebElement timeField, string time)
        {
            if (time != null)
            {
                ClearManual(timeField);

                timeField.Click();
                timeField.SendKeys(Keys.Home);
                for (int i = 0; i < time.Length; i++)
                {
                    timeField.SendKeys(time[i].ToString());
                    waitSecond(500);
                }
            }
        }

        protected void setDateFieldWithDatePicker(IWebElement dateField, string date)
        {
            if (date != null)
            {
                dateField.Click();
                dateField.SendKeys(Keys.Home);
                dateField.SendKeys(date);
                Thread.Sleep(1000);
                dateField.FindElement(By.XPath("..//..//*[contains(@class,'b-date_picker--day-hover')]")).Click();
            }
        }

        protected void setDropdownByText(IWebElement dropdown, string text)
        {
            if (text != null)
            {
                // клик для открытия списка в нижний левый угол
                Actions clickDown = new Actions(pageManager.driver);
                clickDown.MoveToElement(dropdown, 0, dropdown.Size.Height - 1).Click().Perform();

                waitSecond();
                dropdown.FindElement(By.XPath("//label/span[ text() = '" + text + "']")).Click();
            }
        }
        private string getUneditableText(IWebElement element)
        {
            try
            {
                if (element.Text == "")
                {
                    return null;
                }
                else
                    return element.Text;
            }
            catch
            {
                return null;
            }
        }
        private string getUneditableText(IWebElement element, string placeholder, string placeholderend)
        {
            try
            {
                string temp = getUneditableText(element).Remove(0, placeholder.Length);
                return temp.Remove(temp.Length - placeholderend.Length);
            }
            catch
            {
                return null;
            }
        }
        protected string getUneditableText(IWebElement element, string placeholder)
        {
            try
            {
                return getUneditableText(element).Remove(0, placeholder.Length);
            }
            catch
            {
                return null;
            }
        }

        protected string getDropDownText(IWebElement dropdown)
        {
            // если не отображается лейбл, значит, отображается тект плейсхолдера по умолчанию
            // текст по умолчанию принимаем за null (значение из дропдауна не выбрано)

            if (!dropdown.FindElement(By.XPath("//div[contains(@class, 'b-dropdown-float_label')]")).Displayed)
            {
                return null;
            }
            else return getUneditableText(dropdown);
        }

        private string getUneditableTextWithPlaceholder(IWebElement element, string placeholder)
        {
            //если в тексте плейсхолдер, то ничего null
            if (element.GetAttribute("class").Contains("b-dropdown_selectable-placeholder"))
                return null;
            else
                return getUneditableText(element, placeholder);
        }
        protected string getDropDownText(IWebElement dropdown, string placeholder, string placeholderend)
        {
            return getUneditableText(dropdown, placeholder);
        }
        protected string getDropDownWtihPlaceholder(IWebElement dropdown, string placeholder)
        {
            return getUneditableTextWithPlaceholder(dropdown, placeholder);
        }

        protected string getCellText(IWebElement cell)
        {
            return getUneditableText(cell);
        }
        protected string getDirectory(IWebElement cell)
        {
            return getUneditableText(cell.FindElement(By.XPath(".//span//span")));
        }

        protected string getCellText(IWebElement cell, string placeholder, string placeholderend)
        {
            return getUneditableText(cell, placeholder, placeholderend);
        }
        protected string getCellText(IWebElement cell, string placeholder)
        {
            return getUneditableText(cell, placeholder);
        }

        public void waitSecond()
        {
            waitSecond(3000);
        }
        public void waitSecond(string text)
        {
            waitSecond();
            Console.WriteLine(text);
        }
        public void waitSecond(IWebElement element, string property)
        {
            waitSecond();
            Console.WriteLine("{0} : {1}", property, element.GetAttribute(property));
        }
        public void waitSecond(int millisecond)
        {
            Thread.Sleep(millisecond);
        }

        protected void ClearManual(IWebElement webElement)
        {
            //очистка вручную
            webElement.Click(); // для хрома нужно
            webElement.SendKeys(Keys.Home);
            webElement.SendKeys(Keys.Shift + Keys.End);
            webElement.SendKeys(Keys.Delete);
        }

        public void waitForFixPosition(IWebElement element)
        {
            try
            {
                Point prevLocation = new Point(0, 0);
                do
                {
                    prevLocation = element.Location;
                    Thread.Sleep(500);
                    Console.Out.WriteLine("prevLocation" + prevLocation);
                    Console.Out.WriteLine("element location" + element.Location);
                }
                while (!element.Location.Equals(prevLocation));

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught. Проблемы с fix position", e);
            }
        }
     
        public string getValidationMessage()
        {
            waitSecond(1000);//окно присутствует всегда, поэтому вставил костыль, нужно сделать проверку на отображение
            //Ожидание появления какого-нибудь валидатора/
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.XPath("//*[@class='row validation-summary js-validation-summary']")));
            //Валидатор  
            IWebElement Temp = pageManager.driver.FindElement(By.XPath("//*[@class='row validation-summary js-validation-summary']"));
            return getUneditableText(Temp);
        }

        public void waitSuggestOpen()
        {
            //ожидание саджеста, пока просто ожидание, так как логика саджеста будет описана позднее
            waitSecond(1000);
        }
        protected void setSuggestField(IWebElement suggest, string text)
        {
            try
            {
                if (text != null)
                {
                    //блок для стабильности в хроме
                    suggest.Click();
                    waitSuggestOpen();
                    // end
                    suggest.SendKeys(text);
                    waitSuggestOpen();
                    suggest.FindElement(By.XPath("//li/div/a/div[1]/strong")).Click();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        // До востребованности
        //public void clickNHold(IWebElement element)
        //{
        //    Actions action = new Actions(pageManager.driver);
        //    action.ClickAndHold(element).Build().Perform();
        //    waitSecond(1000);
        //    action.Release(element).Build().Perform();
        //}

        protected void setReportSuggestField(IWebElement suggest, string text)
        {
            try
            {
                if (text != null)
                {
                    suggest.SendKeys(text);
                    waitSuggestOpen();

                    for (int i = 0; i < pageManager.driver.FindElements(By.XPath(".//div[contains(@class,'b-textfield_with_dropdown-item')]")).Count(); i++)
                    {
                        suggest.SendKeys(Keys.ArrowDown); // Решение выбрано для решения проблемы, когда ФФ кликает мимо и теряет фокус
                    }

                    suggest.SendKeys(Keys.Enter); // Решение выбрано для решения проблемы, когда ФФ кликает мимо и теряет фокус
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        internal bool getCheckBox(IWebElement element)
        {
            return element.Selected;
        }

        internal void setCheckBox(IWebElement element, bool state)
        {
            if (state != getCheckBox(element))
                element.Click();
        }

        internal bool getStarField(IWebElement webElement)
        {
            return !(webElement.GetAttribute("class") == "b-events-list-item-content-favorite");
        }

        internal void setStarField(IWebElement webElement, bool state)
        {
            if (state != getStarField(webElement))
                webElement.Click();
        }
        public List<string> getListFromUneditable(IEnumerable<IWebElement> list)
        {
            //создаем список для получения текста из вебэлементов
            List<string> x = new List<string>();
            //наполняем список текстом
            foreach (IWebElement Element in list)
                x.Add(getUneditableText(Element));
            return x;
        }
        public List<string> getListFromEditable(IEnumerable<IWebElement> list)
        {
            //создаем список для получения текста из вебэлементов
            List<string> x = new List<string>();
            //наполняем список текстом
            foreach (IWebElement Element in list)
                x.Add(getTextField(Element));
            return x;
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                pageManager.driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected bool isPagination(string XPath, int pagesize)
        {
            int temp = pageManager.driver.FindElements(By.XPath(XPath)).Count;
            scrollToWebElement(pageManager.driver.FindElements(By.XPath(XPath))[temp - 1]);
            waitSecond();//ждем пока количество увеличится
            int current = pageManager.driver.FindElements(By.XPath(XPath)).Count;
            Console.WriteLine("Было {0}, Стало {1}", temp, current);
            int count = current - temp;
            return ((count) % pagesize < pagesize) && (count > 0);
        }

        public void scrollToCenter(IWebElement webElement)
        {
            int CenterX = pageManager.DimensionX / 2;
            int CenterY = pageManager.DimensionY / 2;
            scrollWithOffset(webElement.Location.X - CenterX, webElement.Location.Y - CenterY);
        }
        public void scrollToWebElement(IWebElement webElement)
        {
            string code = "arguments[0].scrollIntoView();";
            IJavaScriptExecutor js = pageManager.driver as IJavaScriptExecutor;
            js.ExecuteScript(code, webElement);
        }

        public void scrollWithOffset(IWebElement webElement, int CenterX = 0, int CenterY = 0)
        {
            string code = "window.scroll(" + (CenterX - webElement.Location.X) + "," + (CenterY - webElement.Location.Y) + ");";
            IJavaScriptExecutor js = pageManager.driver as IJavaScriptExecutor;
            js.ExecuteScript(code, webElement);
        }
        private void scrollWithOffset(int x, int y)
        {

            string code = "window.scrollBy(" + x + "," + y + ");";
            IJavaScriptExecutor js = pageManager.driver as IJavaScriptExecutor;
            js.ExecuteScript(code);
        }

        public void isLoadingDone()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(ExpectedConditions.StalenessOf(pageManager.driver.FindElement(By.XPath("//div[contains(@class,'progress-overlay')]"))));
        }
        public void ensureTabLoaded(string tabname)
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.XPath("//div[@class='case-card-tab-content']//a/div[.='" + tabname + "']")));
        }
        public IWebElement getTabByName(string tabname)
        {
            return pageManager.driver.FindElement(By.XPath("//div[@class='case-card-tab-content']//a/div[.='" + tabname + "']"));
        }

        internal void switchTab(string tabname)
        {
            getTabByName(tabname).Click();
        }
    }
}