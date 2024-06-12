using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Docker.DotNet.Models;


namespace Mars_CompetitionTask_US2.Utils
{
    public class Driver
    {
        public static IWebDriver driver;
        public void Initialize()
        {
            driver = new ChromeDriver();
            Wait(driver, 10);
            driver.Manage().Window.Maximize();
        }



        public void Wait(IWebDriver driver, int timeInSeconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInSeconds);
        }



        public static void NavigateToApplicationUrl(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(ConstantHelpers.Url);
        }

        public void Close()
        {
            driver.Quit();
        }
    }
}
