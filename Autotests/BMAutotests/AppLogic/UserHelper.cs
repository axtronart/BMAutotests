using AutoItX3Lib;
using BMAutotests.Model;
using BMAutotests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BMAutotests.AppLogic
{
    public class UserHelper
    {
        private AppManager app;
        private PageManager pages;
        public const string ENTITY_EVENT_TAG = "Событие";
        public const string ENTITY_PROJECT_TAG = "ПРОЕКТ";
        public const string ENTITY_DOCUMENT_TAG = "Документ";
        public const string ENTITY_TASK_TAG = "ЗАДАЧА";
        public const string ENTITY_DUPLICATE_CASE_TAG = "Выделено отдельное производство";

        public const string DUPLICATE_CASE_TEXT1 = "Дело создано на основании выделения требований из дела";
        public const string DUPLICATE_CASE_TEXT2 = "Из дела были выделены требования в отдельное производство";

        public const int WAIT_DOCUMENT_DOWNLOADED = 3000;

        public UserHelper(AppManager app)
        {
            this.app = app;
            this.pages = app.Pages;
        }

        public User getUserByRole(string role)
        {
            List<User> users = FileHelper.user().ToList();
            return users.Find(x => x.role == role);
        }

        public User getAdminUser()
        {
            return getUserByRole("Администратор");
        }
        public User getSecretary()
        {
            return getUserByRole("Секретарь");
        }
        public User getReportDataUser()
        {
            return getUserByRole("Данные в отчетах");
        }
        public User getProfileUser()
        {
            return getUserByRole("Профиль");
        }
        public User getBillingUser()
        {
            return getUserByRole("Биллинг");
        }

        public User getTimeLogUser()
        {
            return getUserByRole("Тайминг");
        }
        public void logout()
        {
            //завершение работы всех запущенных браузеров
            WebDriverFactory.DismissAll();
        }
        /*
        public void clickMenu(string text)
        {
            pages.extMenu.ensurePageLoaded();
            pages.extMenu.ClickByText(text);
        }*/
        public void clickMenu(int number)
        {
            waitsecond();
            pages.mainMenu.ensurePageLoaded();
            pages.mainMenu.ClickByIndex(number);
        }
        public void clickAdminMenu(string text)
        {
            pages.adminMenu.ensurePageLoaded();
            pages.adminMenu.ClickByText(text);
        }
        /*
        public void returnToMainMenu()
        {
            pages.extMenu.ensurePageLoaded();
            pages.extMenu.clickByMainMenu();
        }*/
        public string getURL()
        {
            return pages.driver.Url;
        }
        public string getBaseURL()
        {
            return pages.baseUrl;
        }

        public string isNotLogged()
        {
            return pages.loginPage.getValidationMessage();
        }

        public void loginClear()
        {
            pages.loginPage.clearLogin();
            pages.loginPage.clearPassword();
        }
        public bool isLoggedIn()
        {
            pages.headerPage.ensurePageLoaded();
            return true;
        }

        public void closePopup()
        {
            pages.popupPage.closePopup();
        }

        public void RefreshPage()
        {
            pages.popupPage.refreshPage(0);
        }

        public void waitsecond()
        {
            pages.adminMenu.waitSecond();
        }
        public void waitsecond(int milliseconds)
        {
            pages.adminMenu.waitSecond(milliseconds);
        }
        public void closeContextMenu()
        {
            pages.popupPage.ensurePageLoaded();
            pages.popupPage.menuPopupClick();
        }

        public void loginAs(User user)
        {
            pages.loginPage.ensurePageLoaded();
            //VersionToConsole();
            pages.loginPage.setUserNameField(user.login);
            pages.loginPage.setPasswordField(user.password);
            pages.loginPage.submitClick();
        }
        
        public void ClickEnter()
        {
            Actions act = new Actions(pages.driver);
            act.SendKeys(Keys.Enter).Perform();
        }

        public void deleteAlertOk()
        {
            pages.driver.SwitchTo().Alert().Accept();
        }

        public void switchToAnotherTab()
        {
          /*  pages.automationPage.ensureNewTabAppear();
            pages.driver.SwitchTo().Window(pages.driver.WindowHandles[1]);*/
        }
        public void switchToNewTab(int numtab = 1)
        {
            /*pages.automationPage.ensureNewTabAppear(numtab + 1);
            pages.driver.SwitchTo().Window(pages.driver.WindowHandles.Last());*/
        }

        public void switchToAnotherTab(int index)
        {
            //pages.automationPage.ensureNewTabAppear(index+1);
            pages.driver.SwitchTo().Window(pages.driver.WindowHandles[index]);
        }
        public void switchToFirstTab()
        {
            //pages.automationPage.ensureNewTabAppear(pages.driver.WindowHandles.Count());
            Console.WriteLine("хендлов" + pages.driver.WindowHandles.Count);
            pages.driver.SwitchTo().Window(pages.driver.WindowHandles.First());
        }

        public void loadFile(string filepath)
        {
            //дефолт расчитанный на firefox
            string titlewindow = "Выгрузка файла";
            string labelcontrol = "Имя файла:";

            if (pages.browsername == "chrome")
            {
                titlewindow = "Открытие";
                labelcontrol = "Имя файла:";
            }
            if (pages.browsername == "firefox")
            {
                titlewindow = "Выгрузка файла";
                labelcontrol = "Имя файла:";
            }
            List<int> logs = new List<int>();
            AutoItX3 autoIt = new AutoItX3();
            logs.Add(autoIt.WinWait(titlewindow, "", 10));
            logs.Add(autoIt.ControlSetText(titlewindow, labelcontrol, "", filepath));
            Console.WriteLine("новый лог:" + autoIt.WinGetTitle(titlewindow));
            autoIt.WinActivate(titlewindow);
            logs.Add(autoIt.ControlSend(titlewindow, "", "", "{ENTER}"));
            Console.WriteLine("==============вывод ошибок========");
            foreach (int temp in logs)
            {
                Console.WriteLine(temp);
            }
            Console.WriteLine("==============конец вывода========");
        }

        public void closePopupFromCancel()
        {
            pages.popupPage.closePopupFromCancel();
            pages.popupPage.waitClosedPopup();
        }
        //Процедура вывода полей одного объекта (пока не использовал)
        public static void WriteToConsole(object obj)
        {
            // Get the type of MyClass.
            Type myType = obj.GetType();
            try
            {
                // Get the FieldInfo of MyClass. 
                FieldInfo[] myFields = myType.GetFields(BindingFlags.Public
                    | BindingFlags.Instance);
                // Display the values of the fields.
                Console.WriteLine("\n============== Класс {0} =====================\n", myType);
                for (int i = 0; i < myFields.Length; i++)
                {
                    Console.WriteLine(" {0}: is: ({1})",
                        myFields[i].Name, myFields[i].GetValue(obj));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : {0}", e.Message);
            }
        }

        //Процедура вывода полей двух объектов
        internal static void WriteToConsole(object obj, object obj1)
        {
            // Получение текущего класса
            Type myType = obj.GetType();
            try
            {
                // Получение набора публичных полей в классе
                FieldInfo[] myFields = myType.GetFields(BindingFlags.Public
                    | BindingFlags.Instance);
                //Отображение типа
                Console.WriteLine("\n============== Класс {0} =====================\n", myType);
                for (int i = 0; i < myFields.Length; i++)
                {
                    if (myFields[i].FieldType.IsGenericType)
                    {
                        Console.WriteLine("{0}:              ", myFields[i].Name);

                        for (int j = 0; j < (myFields[i].GetValue(obj1) as IList).Count; j++)
                        {
                            Console.Write("  значение {1}:              ({0}) ", (myFields[i].GetValue(obj) as IList)[j], j);
                            Console.Write("  значение {1}:              ({0}) ", (myFields[i].GetValue(obj1) as IList)[j], j);
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0}:              ({1})",
                        myFields[i].Name, myFields[i].GetValue(obj));
                        Console.WriteLine("{0}:              ({1})",
                            myFields[i].Name, myFields[i].GetValue(obj1));
                    }

                }
                Console.WriteLine("=========Конец сравнения========");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : {0}", e.Message);
            }
        }
        
        public void clickNewAutomationScenario()
        {
            clickMiddleMenuByText("Новый сценарий");
        }
        public void clickMiddleMenuByText(string text)
        {
            pages.middleMenu.ensurePageLoaded();
            pages.middleMenu.ClickByText(text);
        }

        // Для проверки данных в отчете
        public static bool listComprassion(List<string> list1, List<string> list2)
        {
            if ((list1 == null) && (list2 == null))
                return true;
            if (((list1 == null) && (list2 != null)) || ((list1 != null) && (list2 == null)))
                return false;
            Console.WriteLine("L1.Count = {0}  L2.Count = {1}", list1.Count, list2.Count);
            if (list1.Count != list2.Count)
            {
                Console.WriteLine(String.Format("L1:{0}, L2:{1}", list1.Count, list2.Count));
                foreach (string str in list1)
                    Console.Write("L1: ({0}) ", str);
                Console.WriteLine();
                foreach (string str in list2)
                    Console.Write("L2: ({0}) ", str);
                Console.WriteLine();
                return false;
            }
            else
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i] != list2[i])
                    {
                        Console.WriteLine("L1: {0}   != L2: {1}", list1[i], list2[i]);
                        return false;
                    }
                }
                return true;
            }
        }
        // Для проверки ссылок в письмах (проверяется содержание первого значения во втором)
        public static bool listComparisionLinks(List<string> list1, List<string> list2)
        {
            if ((list1 == null) && (list2 == null))
                return true;
            if (((list1 == null) && (list2 != null)) || ((list1 != null) && (list2 == null)))
                return false;
            if (list1.Count != list2.Count)
            {
                Console.WriteLine(String.Format("L1:{0}, L2:{1}", list1.Count, list2.Count));
                foreach (string str in list1)
                    Console.Write("L1: ({0}) ", str);
                Console.WriteLine();
                foreach (string str in list2)
                    Console.Write("L2: ({0}) ", str);
                Console.WriteLine();
                Console.WriteLine("Not equals");
                return false;
            }
            else
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    if (!list1[i].Contains(list2[i]))
                    {
                        Console.WriteLine("L1: {0}   != L2: {1}", list1[i], list2[i]);
                        return false;
                    }
                }
                return true;
            }
        }


        public static bool listContains(List<string> list, List<string> value)
        {
            foreach (string item in value)
            {
                if (!list.Contains(item))
                {
                    Console.WriteLine("В списке отсутствует: {0} ", item);
                    return false;
                }
            }
            return true;
        }
        public static bool isSortList(List<string> list, string order)
        {
            if (list.Count > 0)//проверяем что список не пустой
            {
                List<string> TempList = new List<string>(list);
                TempList.Sort();
                if (order == "DESC")
                {
                    TempList.Reverse();
                }
                return listComprassion(TempList, list);
            }
            else
            {
                Console.WriteLine("Список для сортировки пустой");
                return false;
            }
        }

        public List<string> getMiddleMenuList()
        {
            pages.middleMenu.ensurePageLoaded();
            pages.middleMenu.scrollToBottom();
            return pages.middleMenu.getList();
        }

        public bool isMiddleMenuPagination()
        {
            pages.middleMenu.ensurePageLoaded();
            return pages.middleMenu.isPagination();
        }

        public bool isParticipantsPagination()
        {
            return true;
         /*   pages.allParticipantsPage.ensureTableLoaded();
            pages.allParticipantsPage.waitSecond();
            return pages.allParticipantsPage.isPagination();*/
        }

        public bool checkDownloadedFile(string fileName, string extension)
        {
            return (getFile(fileName, extension).Any());
        }

        internal string getFile(string fileName, string extension)
        {
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");
            return Directory.GetFiles(pathDownload, String.Format("{0}.{1}", fileName, extension))[0];
        }

        public void deleteFileByName(string fileName, string extension)
        {
            File.Delete(getFile(fileName, extension));
        }
        public void waitClosedPopup()
        {
            pages.popupPage.waitClosedPopup();
        }

        public bool isReportPaginaion()
        {
            return false;
           /* pages.allReportsPage.ensurePageLoaded();
            return pages.allReportsPage.isPagination();*/
        }

        public void returnToFirstElement()
        {
            /*pages.allReportsPage.returnToFirstElement();*/
        }

        public void goToProfile()
        {
            pages.headerPage.ensurePageLoaded();
            pages.headerPage.userMenuClick();
            pages.contextMenu.ensurePageLoaded();
            pages.contextMenu.ClickByText("Профиль");
        }

        public void personalMenuClick(string text)
        {
            pages.profilePage.ensurePageLoaded();
            pages.profilePage.menuClick();
            pages.contextMenu.ensurePageLoaded();
            pages.contextMenu.ClickByText(text);
        }

        public void addPhotoClick()
        {
            pages.profilePage.ensurePageLoaded();
            pages.profilePage.addPhotoClick();
        }

        public void clickNewUser()
        {
            pages.middleMenu.ensurePageLoaded();
            pages.middleMenu.ClickByText("Новый пользователь");
        }

        public User getEmailUser()
        {
            return getUserByRole("Email");
        }

        public User getFindprojectUser()
        {
            return getUserByRole("Поиск по проектам");
        }

        public User getCaseAndProjectCreator()
        {
            return getUserByRole("Создание дел и проектов");
        }

        public User getTasksUser()
        {
            return getUserByRole("Создание задач");
        }

       
        public void sendPassword(string username)
        {
            pages.remindPasswordPage.ensurePageLoaded();
            pages.remindPasswordPage.setUserNameField(username);
            pages.remindPasswordPage.submitClick();
            pages.loginPage.ensurePageLoaded();
        }

        public void goToParticipantInCase()
        {
            pages.goToURL("#/case/0e804113-861b-e711-80bb-0cc47a7d3f5d/participants/");
        }
        public void goToExpensesInCase()
        {
            pages.goToURL("#/case/0ca35ee0-ebe6-e611-80b9-0cc47a7d3f5d/expenses");
        }
        
        public User getEmailNotSendUser()
        {
            return getUserByRole("EmailNotSend");
        }
        public void goToChangeRightInCase()//для проверки что письма не отправляются при изменении прав
        {
            pages.goToURL("#/case/f450a20d-bf04-e711-80ba-0cc47a7d3f5d/users");

        }
        public void goToInvoice()
        {
            pages.goToURL("#/billing/d5c0d0d4-e20a-e711-80ba-0cc47a7d3f5d/view");
        }
        public void goToInvoicesInCase()
        {
            pages.goToURL("#/case/0ca35ee0-ebe6-e611-80b9-0cc47a7d3f5d/bills");
        }

        internal int getNumDriverTab()
        {
            return pages.driver.WindowHandles.Count;
        }

        public void IncrementString()
        {
            Console.WriteLine(Increment("000002".ToCharArray()));
        }
        public char[] Increment(char[] referenceNumber)
        {
            int i = referenceNumber.Length - 1;
            while (Char.IsDigit(referenceNumber[i]) || i > 0)
            {
                i--;
            }
            char[] temp = null;
            referenceNumber.CopyTo(temp, i);
            
            return referenceNumber;
        }

       
    }
}
