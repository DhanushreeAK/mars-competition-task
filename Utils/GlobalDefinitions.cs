using Mars_CompetitionTask_US2.Utils;
using Microsoft.VisualStudio.Services.Profile;
using OpenQA.Selenium;
using System.Text;

namespace Mars_CompetitionTask_US2.Utils
{
    public class GlobalDefinitions
    {
        
        public static IWebDriver driver { get ; set ; }

        #region screenshots
        public class Screenshot
        {

            public static string SaveScreenshotMVP(IWebDriver driver, string ScreenShotFileName)
            {
                if (!System.IO.Directory.Exists(CommonMethods.ScreenshotPath))
                {
                    System.IO.Directory.CreateDirectory(CommonMethods.ScreenshotPath);
                }

                var screenShot = ((ITakesScreenshot)GlobalDefinitions.driver).GetScreenshot();
                var fileName = new StringBuilder(CommonMethods.ScreenshotPath + ScreenShotFileName + DateTime.Now.ToString("_dd-MM-yyyy_HHmm") + ".jpeg");
                screenShot.SaveAsFile(fileName.ToString());
                return fileName.ToString();
            }
            public static string GetScreenshot()
            {
                return ((ITakesScreenshot)GlobalDefinitions.driver).GetScreenshot().AsBase64EncodedString;
            }

        }
        #endregion


    }
}