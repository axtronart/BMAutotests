using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace BMAutotests.Pages
{
    public class ProfilePage : CommonPage
    {
        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']//input[@name = 'firstName']")]
        private IWebElement nameField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']//input[@name = 'middleName']")]
        private IWebElement patronimicField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']//input[@name = 'lastName']")]
        private IWebElement lastNameField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']//input[@name = 'initials']")]
        private IWebElement initialsField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']//input[@name = 'сompanyName']")]
        private IWebElement companyField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']//input[@name = 'post']")]
        private IWebElement positionField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']//input[@name = 'сompanyUrl']")]
        private IWebElement siteField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']//input[@name = 'email']")]
        private IWebElement emailField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']//input[@name = 'phone']")]
        private IWebElement phoneField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']/div[1]/div[2]/div/div[4]/div[1]/div/button")]
        private IWebElement departmentField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']/div[1]/div[2]/div/div[4]/div[2]/div/button")]
        private IWebElement timezoneField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']//input[@name='OldPassword']")]
        private IWebElement currentPasswordField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']//input[@name='NewPassword']")]
        private IWebElement newPasswordField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']//input[@name='ConfirmPassword']")]
        private IWebElement passwordAgainField;

        [FindsBy(How = How.XPath, Using = "//form[@name = 'profileForm']/div[3]/div/div/button")]
        private IWebElement saveButton;

        [FindsBy(How = How.XPath, Using = "//label[@class='b-profile-portrait-cap']")]
        private IWebElement portrait;

        [FindsBy(How = How.XPath, Using = "//*[@common-actions-dropdown-classes='b-actions-dropdown--white']")]
        private IWebElement portraitMenu;
        
       

        public ProfilePage(PageManager pageManager)
            : base(pageManager)
        {
            pagename = "profile";
        }

        public override void ensurePageLoaded()
        {
            var wait = new WebDriverWait(pageManager.driver, TimeSpan.FromSeconds(PageManager.WAITTIMEFORFINDELEMENT));
            wait.Until(d => d.FindElement(By.XPath("//form[@name='profileForm']")));
        }
       
        internal void clearName()
        {
            ClearManual(nameField);
        }

        internal void clearPatronimic()
        {
            ClearManual(patronimicField);
        }

        internal void clearLastname()
        {
            ClearManual(lastNameField);
        }

        internal void clearInitials()
        {
            ClearManual(initialsField);
        }

        internal void clearCompany()
        {
            ClearManual(companyField);
        }

        internal void clearPosition()
        {
            ClearManual(positionField);
        }

        internal void clearSite()
        {
            ClearManual(siteField);
        }

        internal void clearEmail()
        {
            ClearManual(emailField);
        }

        internal void clearPhone()
        {
            ClearManual(phoneField);
        }

        internal void clearDepartment()
        {
            setDepartment("Не выбрано");
        }

        internal void clearTimezone()
        {
            ClearManual(timezoneField);
        }

        internal void clearCurrentPassword()
        {
            ClearManual(currentPasswordField);
        }

        internal void clearNewPassword()
        {
            ClearManual(newPasswordField);
        }

        internal void clearPasswordAgain()
        {
            ClearManual(passwordAgainField);
        }

        internal void setName(string name)
        {
            setTextField(nameField, name);
        }

        internal void setPatronimic(string patronimic)
        {
            setTextField(patronimicField, patronimic);
        }

        internal void setLastname(string lastName)
        {
            setTextField(lastNameField, lastName);
        }

        internal void setInitials(string initials)
        {
            setTextField(initialsField, initials);
        }

        internal void setCompany(string company)
        {
            setTextField(companyField, company);
        }

        internal void setPosition(string position)
        {
            setTextField(positionField, position);
        }

        internal void setSite(string site)
        {
            setTextField(siteField, site);
        }

        internal void setEmail(string email)
        {
            setTextField(emailField, email);
        }

        internal void setPhone(string phone)
        {
            setTextField(phoneField, phone);
        }

        internal void setDepartment(string department)
        {
            setDropdownByText(departmentField, department);
        }

        internal void setCurrentPassword(string password)
        {
            setTextField(currentPasswordField, password);
        }

        internal void setNewPassword(string password)
        {
            setTextField(newPasswordField, password);
        }

        internal void setPasswordAgain(string password)
        {
            setTextField(passwordAgainField, password);
        }

        internal void saveClick()
        {
            saveButton.Click();
        }

        internal string getName()
        {
            return getTextField(nameField);
        }

        internal string getPatronimic()
        {
            return getTextField(patronimicField);
        }

        internal string getLastName()
        {
            return getTextField(lastNameField);
        }

        internal string getInitials()
        {
            return getTextField(initialsField);
        }

        internal string getCompany()
        {
            return getTextField(companyField);
        }

        internal string getSite()
        {
            return getTextField(siteField);
        }

        internal string getEmail()
        {
            return getTextField(emailField);
        }

        internal string getPhone()
        {
            return getTextField(phoneField);
        }

        internal string getDepartment()
        {
            return getDropDownText(departmentField);
        }

        internal string getCurrentPassword()
        {
            return getTextField(currentPasswordField);
        }

        internal string getNewPassword()
        {
            return getTextField(newPasswordField);
        }

        internal string getPasswordAgain()
        {
            return getTextField(passwordAgainField);
        }

        internal string getPosition()
        {
            return getTextField(positionField);
        }

        internal void setTimezone(string timezone)
        {
            setDropdownByText(timezoneField, timezone);
        }

        internal string getTimeZone()
        {
            return getDropDownText(timezoneField);
        }

        internal void addPhotoClick()
        {
            portrait.Click();
        }

        internal void menuClick()
        {
            portraitMenu.Click();
        }
    }
}
