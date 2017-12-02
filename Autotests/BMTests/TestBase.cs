using BMAutotests.AppLogic;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;

namespace BMTests
{
    [TestFixture()]
    public class TestBase
    {
        protected AppManager app;
        
        [SetUp]
        public void Init()
        {

            string browserType = System.Environment.GetEnvironmentVariable("BROWSER");
            string baseUrl = System.Environment.GetEnvironmentVariable("BASE_URL");
            string hubUrl = System.Environment.GetEnvironmentVariable("HUB_URL");
            if (baseUrl == null)
            {
                baseUrl = "https://test01.boardmaps.com:10001";
                //baseUrl = "http://192.168.0.12:8099/";
            }
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName,
                browserType != null ? browserType : "chrome");
            app = new AppManager(capabilities, baseUrl, hubUrl);
            Console.WriteLine("Браузер: {0}, адрес: {1}, время: {2}", browserType, baseUrl, DateTime.Now);
        }
    }
}
