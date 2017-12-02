
using BMAutotests.AppLogic;
using BMAutotests.Model;
using NUnit.Framework;
using System;
namespace BMTests
{
    [TestFixture()]
    public class EmailTests
    {
        protected EmailHelper emailHelper = new EmailHelper();
        
        [Test, TestCaseSource(typeof(FileHelper), "welcomeemails")]
        [Category("Email")]
        public void Email_Welcome(EmailMessage EM)
        {
            //подключение к почтовому ящику и получение писем
            emailHelper.connect("testcasepro1@yandex.ru", "testmail");
            EM.date = DateTime.Now.Date.ToShortDateString();
            EmailMessage testEM = emailHelper.getEmail(EM.folder);
            //чтобы не определять тип вручную берем из джейсона
            testEM.type = EM.type;
            testEM = emailHelper.parseTextMessage(testEM);
            Assert.IsTrue(emailHelper.CompareEmail(testEM, EM));
        }
        [Test, TestCaseSource(typeof(FileHelper), "emails")]
        [Category("Email")]
        public void Email_Content(EmailMessage EM)
        {
            //подключение к почтовому ящику и получение писем
            emailHelper.connect("testcasepro@yandex.ru", "testmail");
            EM.date = DateTime.Now.Date.ToShortDateString();
            EmailMessage testEM = emailHelper.getEmail(EM.folder);
            //чтобы не определять тип вручную берем из джейсона
            testEM.type = EM.type;
            testEM = emailHelper.parseTextMessage(testEM);
            Assert.IsTrue(emailHelper.CompareEmail(testEM, EM));
        }

        [Test()]
        [Category("Email")]
        //тест проверяющий, что письма не приходят
        public void Email_Nullable()
        {
            string folder = "INBOX|AllMails";
            //подключение к почтовому ящику
            emailHelper.connect("testcasepro2@yandex.ru", "testmail");
            EmailMessage testEM = emailHelper.getEmail(folder);
            UserHelper.WriteToConsole(testEM);
            Assert.IsNull(testEM.subject);
        }
        [TearDown]
        public void DeleteCurrentEmail()
        {
            emailHelper.disconnect();
        }
    }
}
