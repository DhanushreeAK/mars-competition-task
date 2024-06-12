using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Mars_CompetitionTask_US2.Pages;
using Mars_CompetitionTask_US2.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mars_CompetitionTask_US2.Utils.CommonMethods;

namespace Mars_CompetitionTask_US2.Tests
{
    [TestFixture]
    [Parallelizable]
    public class CertificationTests : CommonMethods
    {
        [SetUp]
        public void Setup()
        {
            
            Login loginObj = new Login();
            loginObj.LoginInToApplication();

        }

        [Test, Order(1)]
        public void TC1_UserAddsCertification()
        {
            Certification certificationObj = new Certification();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            certificationObj.CertificationTab();
            // Parsing the Certification Json test data
            JObject obj = GetTestDataJsonObjectFromFile("Certification");

            //Fetching the particular array in Certification json file for reading the test data 
            List<CertificationDetails> certifications = obj["Certification0"].ToObject<List<CertificationDetails>>();

            for (int i = 0; i < certifications.Count; i++)
            {
                certificationObj.AddCertificate(certifications[i].certificate.ToString(), certifications[i].certifiedFrom.ToString(), certifications[i].year.ToString());
                test.Log(Status.Pass, "Success");

            }

            if (certificationObj.VerifyAddedCertification())
            {
                Assert.Pass("Certification has been added");
            }
            else
            {
                Assert.Fail("Failed to add certification");
            }


        }



        [Test, Order(2)]
        public void TC2_UserEditsCertification()
        {
            Certification certificationObj = new Certification();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            certificationObj.CertificationTab();
            // Parsing the Certification Json test data
            JObject obj = GetTestDataJsonObjectFromFile("Certification");

            //Fetching the particular array in Certification json file for reading the test data 
            List<CertificationDetails> certifications = obj["Certification5"].ToObject<List<CertificationDetails>>();
            for (int i = 0; i < certifications.Count; i++)
            {
                certificationObj.AddCertificate(certifications[i].certificate.ToString(), certifications[i].certifiedFrom.ToString(), certifications[i].year.ToString());
                test.Log(Status.Pass, "Success");

            }

            List<CertificationDetails> certifications1 = obj["Certification1"].ToObject<List<CertificationDetails>>();
            for (int i = 0; i < certifications1.Count; i++)
            {
                certificationObj.EditCertificate(certifications1[i].certificate.ToString(), certifications1[i].certifiedFrom.ToString(), certifications1[i].year.ToString());


            }
            if (certificationObj.VerifyUpdatedCertification() == true)
            {
                Assert.Pass("Successfully updated");
            }
            else
            {
                Assert.Fail("Failed to update");
            }

        }

        [Test, Order(4)]
        public void TC2_UserDeletesCertification()
        {
                Certification certificationObj = new Certification();
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
                certificationObj.CertificationTab();
                // Parsing the Certification Json test data
                JObject obj = GetTestDataJsonObjectFromFile("Certification");

                //Fetching the particular array in Certification json file for reading the test data 
                 List<CertificationDetails> certifications = obj["Certification2"].ToObject<List<CertificationDetails>>();
                for (int i = 0; i < certifications.Count; i++)
                    {
                        certificationObj.AddCertificate(certifications[i].certificate.ToString(), certifications[i].certifiedFrom.ToString(), certifications[i].year.ToString());
                        test.Log(Status.Pass, "Success");
                        certificationObj.DeleteCertificate(certifications[i].certificate.ToString());
                    }


        }

        [Test, Order(5)]
        public void TC5_UserAddsInvalidCertification()
        {
            Certification certificationObj = new Certification();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            certificationObj.CertificationTab();
            // Parsing the Certification Json test data
            JObject obj = GetTestDataJsonObjectFromFile("Certification");

            //Fetching the particular array in Certification json file for reading the test data 
            List<CertificationDetails> certifications = obj["Certification3"].ToObject<List<CertificationDetails>>();
            for (int i = 0; i < certifications.Count; i++)
            {
                certificationObj.AddCertificate(certifications[i].certificate.ToString(), certifications[i].certifiedFrom.ToString(), certifications[i].year.ToString());
                test.Log(Status.Pass, "Success");

            }

            if (certificationObj.VerifyAddedCertification())
            {
                Assert.Fail("Certification has been added");
            }
            else
            {
                Assert.Pass("Failed to add certification");
            }


        }
        [Test, Order(6)]
        public void TC5_UserDuplicatesCertificationAdded()
        {
            Certification certificationObj = new Certification();
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            certificationObj.CertificationTab();
            // Parsing the Certification Json test data
            JObject obj = GetTestDataJsonObjectFromFile("Certification");

            //Fetching the particular array in Certification json file for reading the test data 
            List<CertificationDetails> certifications = obj["Certification4"].ToObject<List<CertificationDetails>>();
            for (int i = 0; i < certifications.Count; i++)
            {
                certificationObj.AddCertificate(certifications[i].certificate.ToString(), certifications[i].certifiedFrom.ToString(), certifications[i].year.ToString());
                test.Log(Status.Pass, "Success");

            }
            for (int j = 0; j < certifications.Count; j++)
            {
                certificationObj.AddCertificate(certifications[j].certificate.ToString(), certifications[j].certifiedFrom.ToString(), certifications[j].year.ToString());
                test.Log(Status.Pass, "Success");

            }
            if (certificationObj.AddDuplicateCertificate())
            {
                Assert.Fail("Certification has been added");
            }
            else
            {
                Assert.Pass("Failed to add certification");
            }


        }

        [OneTimeTearDown]
        public static void ExtentClose()
        {
            extent.Flush();

        }
    }
}

