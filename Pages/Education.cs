using Mars_CompetitionTask_US2.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_CompetitionTask_US2.Pages
{
    public class Education : GlobalDefinitions
    {
        //add education locators
        public static IWebElement educationTab => driver.FindElement(By.LinkText("Education"));
        public static IWebElement addNewButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
        public static IWebElement addCollegeNameTextBox => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input"));

        public static IWebElement selectCountryDropDown => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"));

        public static IWebElement selectTitleDropDown => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));
        public static IWebElement addDegreeTextBox => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
        public static IWebElement selectYearDropDown => driver.FindElement(By.Name("yearOfGraduation"));
        public static IWebElement addButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));
        public static IWebElement cancelButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[2]"));
        public static IWebElement lastAddedEducation => driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]"));
        public static IWebElement country => driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[1]"));
        public static IWebElement college => driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[2]"));
        public static IWebElement title => driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[3]"));
        public static IWebElement degree => driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[4]"));
        public static IWebElement graduationYear => driver.FindElement(By.XPath("//div[@data-tab='third']//table/tbody[last()]/tr/td[5]"));

        //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]

        //edit education locators
        public static IWebElement editIcon => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]"));
        public static IWebElement editCollegeTextBox => driver.FindElement(By.Name("instituteName"));

        public static IWebElement editTitleDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[2]/div[1]/select"));
        public static IWebElement editDegree => driver.FindElement(By.Name("degree"));
        public static IWebElement editCountryDropDown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[1]/div[2]/select"));

        public static IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]"));

        //delete locators
        public static IWebElement deleteLastLanguage => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i"));
        
        public static IWebElement deleteButton => driver.FindElement(By.TagName("i"));
        public static IWebElement educationNotDuplicated => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        public static IWebElement popup_Message => driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        public void EducationTab()
        {
            Thread.Sleep(3000);
            educationTab.Click();
        }


        public void AddEducation(string country, string college, string title, string degree, string graduationYear)
        {
            Thread.Sleep(3000);
           
            addNewButton.Click();

            addCollegeNameTextBox.SendKeys(college);
            var selectCountry = new SelectElement(selectCountryDropDown);
            selectCountry.SelectByValue(country);
            var selectTitle = new SelectElement(selectTitleDropDown);
            selectTitle.SelectByValue(title);
            addDegreeTextBox.SendKeys(degree);
            var selectYear = new SelectElement(selectYearDropDown);
            selectYear.SelectByValue(graduationYear);
            addButton.Click();
        }

        public string GetCountry()
        {
            try
            {
         
                return country.Text;
            }
            catch (Exception)
            {
                return "Country element not found";
            }
        }
        public string GetCollege()
        {
            try
            {
                
                return college.Text;
            }
            catch (Exception)
            {
                return "College element not found";
            }
        }
        public string GetTitle()
        {
            try
            {
                
                return title.Text;
            }
            catch (Exception)
            {
                return "Title element not found";
            }
        }
        public string GetDegree()
        {
            try
            {
                
                return degree.Text;
            }
            catch (Exception)
            {
                return "Degree element not found";
            }
        }

        public string GetGraduationYear()
        {
            try
            {
                
                return graduationYear.Text;
            }
            catch (Exception)
            {
                return "Graduation Year element not found";
            }
        }


        public Boolean VerifyAddedEducation()
        {
            Boolean isSuccess = false;
            Thread.Sleep(5000);
            if (popup_Message.Text.Contains("Education has been added"))
            {
                isSuccess = true;
            }
            return isSuccess;
        }
        public void EditEducation(string country, string college, string title, string degree, string graduationYear)
        {
            try
            {
                Thread.Sleep(3000);
                editIcon.Click();
                editCollegeTextBox.Clear();
                editCollegeTextBox.SendKeys(college);

                var selectCountry = new SelectElement(editCountryDropDown);
                selectCountry.SelectByValue(country);

               

                editDegree.Clear();
                editDegree.SendKeys(degree);

                var selectGraduationYear = new SelectElement(selectYearDropDown);
                selectGraduationYear.SelectByValue(graduationYear);

                //var selectTitle = new SelectElement(editTitleDropDown);
                //selectTitle.SelectByValue(title);

                updateButton.Click();
                Console.WriteLine("update after!!! ");
            }
            catch (Exception)
            {
                Assert.Fail("No education record is found.");
            }
        }


        public Boolean VerifyUpdatedEducation()
        {
            Boolean isSuccess = false;
            Thread.Sleep(5000);
            if (popup_Message.Text.Contains("Education as been updated"))
            {
                isSuccess = true;
            }
            return isSuccess;
        }

        public void DeleteEducation()
        {
            try
            {
                    Thread.Sleep(3000);
                    deleteLastLanguage.Click();

            }
            catch (Exception)
            {
                Assert.Fail("No record found");
            }
        }

        public Boolean AddDuplicateEducation()

        {
            Boolean VerifyEducationNotDuplicated = false;
            Thread.Sleep(2000);
            if (educationNotDuplicated.Text.Contains("This information already exists.", StringComparison.OrdinalIgnoreCase))
            {
                VerifyEducationNotDuplicated = true;
            }

            return VerifyEducationNotDuplicated;


        }

        public void ClearEducationAdded()
        {

            Thread.Sleep(3000);

            var recordTables = driver.FindElements(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table"));
          

            for (int i = 0; i < recordTables.Count; i++)
            {
                var tbody = recordTables[i].FindElement(By.TagName("tbody"));
                if (tbody != null)
                {

                    var rows = tbody.FindElements(By.TagName("tr"));

                    for (int j = 0; j < rows.Count; j++)
                    {
                        var removeIcon = driver.FindElement(By.CssSelector("div.ui:nth-child(2) div.ui.fluid.container div.ui.grid div.row div.eight.wide.column form.ui.form:nth-child(2) div.ui.bottom.attached.tab.segment.tooltip-target.active:nth-child(4) div.row div.twelve.wide.column.scrollTable div.form-wrapper table.ui.fixed.table tbody:nth-child(2) tr:nth-child(1) td.right.aligned:nth-child(6) span.button:nth-child(2) > i.remove.icon"));
                        removeIcon.Click();
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    Console.WriteLine("No education found to clear");
                }



            }
        }


    }
}

