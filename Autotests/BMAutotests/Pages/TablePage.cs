using BMAutotests.AppLogic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BMAutotests.Pages
{
    public class TablePage : Page
    {
        //общих элементов для поиска внутри таблицы пока нет
        [FindsBy(How = How.XPath, Using = "//div")]
        private IWebElement Content;

        private string columns = ".//thead//td/div/div[1]";

        public TablePage(PageManager pageManager)
            : base(pageManager)
        {
            pagename = "table";
        }

        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.ClassName("ui-table")));
        }

        public void ensureReportUpdated()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(ExpectedConditions.StalenessOf(pageManager.driver.FindElement(By.XPath("//div[contains(@class,'preloader-wrapper')]"))));
        }

        public void clickByHeading(int indexOfTable = 0)
        {
            ensureTableLoaded();
            //клик по первой таблице
            getTableHeading(indexOfTable).FindElement(By.XPath(".//div[@class = 'ui-table-heading-title']/span")).Click();
        }
        
        public IWebElement getTableHeading(int indexOfTable = 0)
        {
            return getTable(indexOfTable).FindElement(By.ClassName("ui-table-heading"));
        }
        internal IWebElement getTableBody(IWebElement Table)
        {
            return Table.FindElement(By.ClassName("ui-table-body"));
        }
        //получение таблицы по индексу
        internal virtual IWebElement getTable(int index = 0)
        {
            // в итоге класс ссылается на ui-table ng-scope, проверено на отчетах, надо проверить в других местах
            return Content.FindElements(By.XPath(".//div[contains(@class,'ui-table')]/div[contains(@class,'ui-table-head')]/div[contains(@class,'ui-table-row')]/../.."))[index];
        }
        //получение таблицы по заголовку
        internal IWebElement getTable(string tableName)
        {
            // в итоге класс ссылается на ui-table ng-scope
            return Content.FindElement(By.XPath("//*[text()='" + tableName + "']/ancestor::div[contains(@class,'ui-table-heading')]/.."));
        }

        public IWebElement getRow(string nameOfTable, string name)
        {
            return getRow(getTable(nameOfTable), name);
        }
        public IWebElement getRow(IWebElement tableBody, string name)
        {
            return tableBody.FindElement(By.XPath(".//*[ text() = '" + name + "']/ancestor::div[contains(@class, 'ui-table-row ui-table-row--with_actions')]"));
        }

        public IWebElement getRow(int index)
        {
            return getRow(getTable(), index);
        }

        public int countRow(IWebElement tableBody)
        {
            if (tableBody == null)
            {
                return 0;
            }
            else
            {
                int num = getRows(tableBody).Count;
                Console.WriteLine("NUM = " + num);
                return num;
            }

        }
        public int countRow()
        {
            return countRow(getTable());
        }
        //надо переделать---
        public IWebElement getCellInRow(IWebElement row, int col, int col2 = 1)
        {
            return row.FindElement(By.XPath(".//div[contains( @class, 'ui-table-col')][" + col + "]/*[" + col2 + "]"));
        }
        //---
        public virtual IWebElement getSubCell(IWebElement Cell, int col)
        {
            return Cell.FindElements(By.XPath("./div"))[col];
        }
        //Функция возвращает ячейку в таблице
        public virtual IWebElement getCell(IWebElement tableBody, int row, int col)
        {
            return getRow(tableBody, row).FindElements(By.XPath("./div[contains(@class,'ui-table-row-content')]/div"))[col];
        }
        public IWebElement getCell(string tablename, string tablerow, int col)
        {
            return getRow(tablename, tablerow).FindElements(By.XPath("./div[contains(@class,'ui-table-row-content')]/div"))[col];
        }
        public IWebElement getRow(IWebElement tableBody, int row)
        {
            return getRows(tableBody)[row];
        }
        public ReadOnlyCollection<IWebElement> getRows(IWebElement tableBody)
        {
            ensureTableLoaded();
            return tableBody.FindElements(By.XPath(".//div[contains(@class,'ui-table-row')]//div[contains(@class,'ui-table-row-content')]/.."));
        }

        internal IWebElement getCell(IWebElement tableBody, string text)
        {
            return tableBody.FindElement(By.XPath(".//*[contains( text(), '" + text + "')]"));
        }

        internal IWebElement getCell(int row, int col)
        {
            return getCell(getTableBody(getTable()), row, col);
        }

        public IWebElement getCell(string text)
        {
            return getCell(Content, text);
        }

        public ReadOnlyCollection<IWebElement> getCellWithInput(IWebElement el)
        {
            return el.FindElements(By.XPath(".//div[contains(@class,'b-textfield_with_dropdown')]//input"));
        }

        public void ensureTableLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.ClassName("ui-table-body")));
        }
        public void ensureTableLoaded(string tableheading)
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.XPath("//div[@class = 'ui-table-heading-title' and .= '" + tableheading + "']")));
        }

        internal int getColumnSortingIndex()
        {
            ensureTableLoaded();
            return getTable().FindElements(By.XPath(".//td[contains(@class,'is_active_order')]/preceding::td")).Count; //считает количество братьев-нодов (столбцов) перед элементом

        }

        internal string getColumnSortingOrder()
        {
            ensureTableLoaded();
            return getTable().FindElement(By.XPath(".//td[contains(@class,'is_active_order')]//div[contains(@class,'sort')]")).GetAttribute("class").Contains("desc") ? "DESC" : "ASC";
        }

        internal int getColumnIndex(IWebElement column)
        {
            ensureTableLoaded();
            return getTable().FindElements(By.XPath(".//thead//td/div/div[1]")).IndexOf(column);
        }
        internal void setSorting(int index, string sortorder)
        {
            ensureTableLoaded();
            if (!(getColumnSortingOrder() == sortorder))
            {
                getColumns()[index].Click();
            }
        }

        internal int getColumnsCount()
        {
            ensureTableLoaded();
            return getTable().FindElements(By.XPath(columns)).Count;
        }

        internal ReadOnlyCollection<IWebElement> getColumns()
        {
            ensureTableLoaded();
            return getTable().FindElements(By.XPath(columns));
        }

        public void openActionsMenuAtRow(IWebElement row)
        {
            getActionsMenuAtRow(row).Click();
        }
        public IWebElement getActionsMenuAtRow(IWebElement row)
        {
            return row.FindElement(By.XPath(".//div[contains(@class,'b-actions-dropdown')]"));
        }
        internal bool isSorting(int index, string sortorder)
        {
            return false;
         //   return UserHelper.isSortList(getRowColumnFromParticipantsValues(index), sortorder);
        }
    }
}
