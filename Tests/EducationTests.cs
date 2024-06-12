using AventStack.ExtentReports;
using Mars_CompetitionTask_US2.Pages;
using Mars_CompetitionTask_US2.Utils;
using Microsoft.VisualStudio.Services.Profile;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using static Microsoft.VisualStudio.Services.Graph.GraphResourceIds;

using System.Reflection.Emit;
using Docker.DotNet.Models;
using Newtonsoft.Json.Linq;


namespace Mars_CompetitionTask_US2.Tests
{
    [TestFixture]
    [Parallelizable]
    public class EducationTests : CommonMethods
    {
        

        [SetUp]
        public void Setup()
        {
           Login loginObj = new Login();
           loginObj.LoginInToApplication();
           
        }

        [Test, Order(2)]
        public void TC1_UserAddsEducation()
        {
            Education educationObj = new Education();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            educationObj.EducationTab();
           // educationObj.ClearEducationAdded();
           
            // Parsing the Education Json test data
            JObject obj = GetTestDataJsonObjectFromFile("Education");

            //Fetching the particular array in Education json file for reading the test data 
            List<EducationDetails> educations = obj["Education0"].ToObject<List<EducationDetails>>();

            for (int i = 0; i < educations.Count; i++)
            {
                educationObj.AddEducation(educations[i].country.ToString(), educations[i].college.ToString(), educations[i].title.ToString(), educations[i].degree.ToString(), educations[i].graduationYear.ToString());
                test.Log(Status.Pass, "Success");

            }
            
            if (educationObj.VerifyAddedEducation())
            {
                Assert.Pass("Education has been added");
            }
            else
            {
                Assert.Fail("Failed to add education");
            }
            test.Log(Status.Info, "Adding User Education Passed");

        }


        [Test, Order(3)]
        public void TC1_UserEditsEducation()
        {
            Education educationObj = new Education();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            educationObj.EducationTab();
            educationObj.ClearEducationAdded();

            JObject obj = GetTestDataJsonObjectFromFile("Education");

            List<EducationDetails> educations = obj["Education1"].ToObject<List<EducationDetails>>();
            for (int i = 0; i < educations.Count; i++)
            {
                educationObj.AddEducation(educations[i].country.ToString(), educations[i].college.ToString(), educations[i].title.ToString(), educations[i].degree.ToString(), educations[i].graduationYear.ToString());
               
            }
            List<EducationDetails> educations2 = obj["Education2"].ToObject<List<EducationDetails>>();
            for (int i = 0; i < educations2.Count; i++)
            {
                educationObj.EditEducation(educations2[i].country.ToString(), educations2[i].college.ToString(), educations2[i].title.ToString(), educations2[i].degree.ToString(), educations2[i].graduationYear.ToString());
                test.Log(Status.Pass, "Success");
            }
            
            if (educationObj.VerifyUpdatedEducation())
            {
                Assert.Pass("Success");
            } else
            {
                Assert.Fail("Failed");
            }
              
        }
       
        [Test, Order(4)]
        public void TC2_UserDeletesEducation()
        {
            Education educationObj = new Education();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            educationObj.EducationTab();
            educationObj.ClearEducationAdded();
            JObject obj = GetTestDataJsonObjectFromFile("Education");

            List<EducationDetails> educations = obj["Education3"].ToObject<List<EducationDetails>>();
            for (int i = 0; i < educations.Count; i++)
            {
                educationObj.AddEducation(educations[i].country.ToString(), educations[i].college.ToString(), educations[i].title.ToString(), educations[i].degree.ToString(), educations[i].graduationYear.ToString());
                Thread.Sleep(3000);
                educationObj.DeleteEducation();

            }
               
        }

        [Test, Order(5)]
        public void TC1_UserAddsDuplicateEducation()
        {
            Education educationObj = new Education();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            educationObj.EducationTab();
           // educationObj.ClearEducationAdded();
            JObject obj = GetTestDataJsonObjectFromFile("Education");

            List<EducationDetails> educations = obj["Education1"].ToObject<List<EducationDetails>>();
            for (int i = 0; i < educations.Count; i++)
            {
                educationObj.AddEducation(educations[i].country.ToString(), educations[i].college.ToString(), educations[i].title.ToString(), educations[i].degree.ToString(), educations[i].graduationYear.ToString());

            }
            for (int j = 0; j < educations.Count; j++)
            {
                educationObj.AddEducation(educations[j].country.ToString(), educations[j].college.ToString(), educations[j].title.ToString(), educations[j].degree.ToString(), educations[j].graduationYear.ToString());
                test.Log(Status.Pass, "Success");
            }

            if (educationObj.AddDuplicateEducation())
            {
                Assert.Fail("Education has been added");
            }
            else
            {
                Assert.Pass("Failed to add education");
            }

        }
        [Test, Order(5)]
        public void TC1_UserAddsInvalidEducation()
        {
            Education educationObj = new Education();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            educationObj.EducationTab();
            //educationObj.ClearEducationAdded();
            JObject obj = GetTestDataJsonObjectFromFile("Education");

            List<EducationDetails> educations = obj["Education5"].ToObject<List<EducationDetails>>();

            for (int i = 0; i < educations.Count; i++)
            {
                educationObj.AddEducation(educations[i].country.ToString(), educations[i].college.ToString(), educations[i].title.ToString(), educations[i].degree.ToString(), educations[i].graduationYear.ToString());
                test.Log(Status.Pass, "Success");

            }

            if (educationObj.VerifyAddedEducation())
            {
                Assert.Fail("Education has been added");
            }
            else
            {
                Assert.Pass("Failed to add education");
            }
            test.Log(Status.Info, "Adding User Education Passed");

        }

    

        [OneTimeTearDown]
        public void ExtentClose()
        {
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
        }
        

    }

}

   

