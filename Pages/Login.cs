using Mars_CompetitionTask_US2.Utils;
using OpenQA.Selenium;
using static Mars_CompetitionTask_US2.Utils.ConstantHelpers;
using static Mars_CompetitionTask_US2.Utils.GlobalDefinitions;


namespace Mars_CompetitionTask_US2.Pages
{
    public class Login
    {
        public void LoginInToApplication()
        {
            driver.Navigate().GoToUrl(Url);
            try
            {
                Thread.Sleep(3000);
                IWebElement signIn = driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/a"));
                signIn.Click();

                IWebElement emailId = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
                emailId.SendKeys("dhanushreeak@gmail.com");

                IWebElement passwordTextBox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
                passwordTextBox.SendKeys("March@2024");
                Thread.Sleep(3000);
                IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
                Thread.Sleep(3000);
                loginButton.Click();

            }
            catch (Exception)
            {

            }

        }
    }

}
