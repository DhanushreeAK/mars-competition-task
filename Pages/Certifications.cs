using Mars_CompetitionTask_US2.Utils;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_CompetitionTask_US2.Pages
{
    public class Certification : GlobalDefinitions
    {
        //add certification locators
        public static IWebElement certificationTab => driver.FindElement(By.LinkText("Certifications"));
        public static IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
        public static IWebElement certificationTextbox => driver.FindElement(By.Name("certificationName"));
        public static IWebElement certificationFromTextbox => driver.FindElement(By.Name("certificationFrom"));
        public static IWebElement selectYearDropDown => driver.FindElement(By.Name("certificationYear"));
        public static IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));

        //update locators

        public static IWebElement updateIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]"));

        public static IWebElement updateCertification => driver.FindElement(By.Name("certificationName"));

        public static IWebElement updateCertificationFrom => driver.FindElement(By.Name("certificationFrom"));
        public static IWebElement updateSelectYear => driver.FindElement(By.Name("certificationYear"));

        public static IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]"));


        //delete locators
        public static IWebElement deleteIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i"));

        public static IWebElement certificate => driver.FindElement(By.XPath("//div[@data-tab='fourth']//table/tbody[last()]/tr/td[1]"));
        public static IWebElement certificationFrom => driver.FindElement(By.XPath("//div[@data-tab='fourth']//table/tbody[last()]/tr/td[2]"));
        public static IWebElement certificationYear => driver.FindElement(By.XPath("//div[@data-tab='fourth']//table/tbody[last()]/tr/td[3]"));


        public static IWebElement certificateNotDuplicated => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        public static IWebElement popup_Message => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        public void CertificationTab()
        {
            Thread.Sleep(2000);
            certificationTab.Click();
        }



        public void AddCertificate(string certificate, string certifiedFrom, string year)
        {

            Thread.Sleep(5000);
            addNewButton.Click();

            certificationTextbox.SendKeys(certificate);

            certificationFromTextbox.SendKeys(certifiedFrom);

            var addYear = new SelectElement(selectYearDropDown);
            addYear.SelectByValue(year);
            addButton.Click();
        }
        public string GetCertificate()
        {
            try
            {
                return certificate.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }

        public string GetCertifiedFrom()
        {
            try
            {
                return certificationFrom.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }

        public string GetCertificationYear()
        {
            try
            {

                return certificationYear.Text;
            }
            catch (Exception)
            {
                return "Certificate element not found";
            }
        }

        public Boolean VerifyAddedCertification()
        {
            Boolean isSuccess = false;
            Thread.Sleep(5000);
            string certificateData = GetCertificate();
            if (popup_Message.Text.Contains(certificateData + " has been added to your certification"))
            {
                isSuccess = true;
            }
            return isSuccess;
        }
        public void EditCertificate(string certificate, string certifiedFrom, string year)
        {

            Thread.Sleep(3000);
            updateIcon.Click();
            updateCertification.Clear();
            updateCertification.SendKeys(certificate);

            updateCertificationFrom.Clear();
            updateCertificationFrom.SendKeys(certifiedFrom);

            var editedYear = new SelectElement(updateSelectYear);
            editedYear.SelectByValue(year);

            updateButton.Click();


        }
    

        public Boolean VerifyUpdatedCertification()
        {
            Boolean isSuccess = false;
            Thread.Sleep(5000);
            if (popup_Message.Text.Contains("has been updated to your certification"))
            {
                isSuccess = true;
            }
            return isSuccess;
        }
        public void DeleteCertificate(string certificate)
        {
            try
            {
                Thread.Sleep(3000);
                string deletedCertificate = GetCertificate();
                if (deletedCertificate == certificate)
                {
                    deleteIcon.Click();
                }
                else
                {
                    Assert.Fail("No matching certificate found.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No certificate is found.");
            }
        }

        public Boolean AddDuplicateCertificate()

        {
            Boolean VerifyCertificateNotDuplicated = false;
            Thread.Sleep(2000);
            if (certificateNotDuplicated.Text.Contains("This information already exists.", StringComparison.OrdinalIgnoreCase))
            {
                VerifyCertificateNotDuplicated = true;
            }

            return VerifyCertificateNotDuplicated;


        }


    }










}

