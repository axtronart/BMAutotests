using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace BMAutotests.Pages
{
    public class MeetingPopup : PopupPage
    {
        [FindsBy(How = How.Id, Using = "number")]
        private IWebElement numberField;

        [FindsBy(How = How.XPath, Using = "//div[@name='projectFolder']/input")]
        private IWebElement nameFolderField;

        [FindsBy(How = How.XPath, Using = "//form[@name='projectForm']//select[@name='projectType']/../div[1]")]
        private IWebElement caseTypeDropdown;

        [FindsBy(How = How.XPath, Using = "//div[@name='projectName']//input")]
        private IWebElement caseNameField;

        [FindsBy(How = How.XPath, Using = "//form[@name='projectForm']")]
        private IWebElement newCasePopup;

        public MeetingPopup(PageManager pageManager)
            : base(pageManager)
        {
            pagename = "meetingpopup";
        }

                public void setCaseName(string caseName)
        {
            setTextField(caseNameField, caseName);
        }

        internal void setMeetingType(string Type)
        {

        }

        internal void setMeetingNumber(string Number)
        {
            setTextField(numberField, Number);
        }
    }
}
