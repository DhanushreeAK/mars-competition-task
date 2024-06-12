using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Docker.DotNet.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static Mars_CompetitionTask_US2.Utils.GlobalDefinitions;

namespace Mars_CompetitionTask_US2.Utils
{
    public class CommonMethods
    {
        #region Constant configuration
        public static string eductionTestDataJsonPath = @"C:\Users\nitin\OneDrive\Documents\industryconnect_git_manual-tc-repo\compettiontask-us2\qa-mars-repo\Mars_CompetitionTask_US2\TestData\EducationTestData.json";
        public static string certificationTestDataJsonPath = @"C:\Users\nitin\OneDrive\Documents\industryconnect_git_manual-tc-repo\compettiontask-us2\qa-mars-repo\Mars_CompetitionTask_US2\TestData\CertificationTestData.json";
        public static string ScreenshotPath = @"C:\Users\nitin\OneDrive\Documents\industryconnect_git_manual-tc-repo\compettiontask-us2\qa-mars-repo\Mars_CompetitionTask_US2\TestReports\Screenshots\";
        public static string ReportsPath = @"C:\Users\nitin\OneDrive\Documents\industryconnect_git_manual-tc-repo\compettiontask-us2\qa-mars-repo\Mars_CompetitionTask_US2\TestReports\Reports\";
        #endregion

        #region reports
        public static AventStack.ExtentReports.ExtentReports extent;
        public static AventStack.ExtentReports.ExtentTest test;

        

        [OneTimeSetUp]
        protected void ExtentStart()
        {
            //Initialize report
            string reportName = System.IO.Directory.GetParent(@"../../../").FullName
           + Path.DirectorySeparatorChar + "TestReports"
           + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("dd-MM-yyyy HHmmss") + Path.DirectorySeparatorChar;

            //start reporters
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportName);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
            
        }
        
        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        //Method to locate the root directory where the Test data json file is placed
        public static string GetProjectRootDirectory()
        {

            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split("bin")[0];

        }

        // Param: JsonFileName
        // Method to read the Json file by passing the required FileName and returning the Json object
        public static JObject GetTestDataJsonObjectFromFile(string jsonFileName)
        {
            string fileName = jsonFileName + "TestData.json";
            string path = Path.Combine(GetProjectRootDirectory(), "TestData", fileName);
            JObject jObject = JObject.Parse(File.ReadAllText(path));
            return jObject;

        }
       
        //Mapping the Json data to the EducationDetails Class
        public class EducationDetails
        {
            public string title { get; set; }
            public string country { get; set; }
            public string degree { get; set; }
            public string college { get; set;}

            public string graduationYear { get; set; }

        }

        //Mapping the Json data to the CertificationDetails Class
        public class CertificationDetails
        {
            public string certificate { get; set; }
            public string certifiedFrom { get; set; }
            public string year { get; set; }
            

        }


        [TearDown]
        public void TearDown()
        {
            String img = GlobalDefinitions.Screenshot.SaveScreenshotMVP(GlobalDefinitions.driver, "Screenshot");

            var exec_status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            string TC_Name = TestContext.CurrentContext.Test.Name;
            string base64 = GlobalDefinitions.Screenshot.GetScreenshot();

            Status logStatus = Status.Pass;

            switch (exec_status)
            {
                case TestStatus.Failed:

                    logStatus = Status.Fail;
                    test.Log(Status.Fail, exec_status + errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                    break;

                case TestStatus.Skipped:

                    logStatus = Status.Skip;
                    test.Log(Status.Skip, errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64).Build());
                    break;

                case TestStatus.Inconclusive:

                    logStatus = Status.Warning;
                    test.Log(Status.Warning, "Test ");
                    break;

                case TestStatus.Passed:

                    logStatus = Status.Pass;
                    test.Log(Status.Pass, "Test Passed");
                    break;

                default:
                    break;
            }
            driver.Close();
            driver.Quit();
        }
       
        #endregion



    }
}
    

