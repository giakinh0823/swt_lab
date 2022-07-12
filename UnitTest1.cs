using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace unit_selenium
{
    public class Tests
    {
        private const string driverUrl = "D:\\FPT UNIVERSITY\\STUDY\\KY_5\\PRN211\\GUI\\unit_selenium\\unit_selenium";
        private const string email = "";
        private static string password = "";
        private static string host = "https://fap.fpt.edu.vn/";
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(driverUrl);
            driver.Manage().Window.Maximize();
            LoginGmail(driver, email, password);
            LoginFapFromHoaLac();
        }

        public void LoginGmail(IWebDriver driver, string email, string password)
        {
            driver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier");
            Thread.Sleep(2000);
            var loginBox = driver.FindElement(By.Id("identifierId"));
            loginBox.SendKeys(email);
            loginBox.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            var pwBox = driver.FindElement(By.Name("password"));
            pwBox.SendKeys(password);
            pwBox.SendKeys(Keys.Enter);
            Thread.Sleep(4000);
        }

        public void LoginFapFromHoaLac()
        {
            driver.Navigate().GoToUrl(host);
            Thread.Sleep(4000);
            var selectCampus = driver.FindElement(By.Name("ctl00$mainContent$ddlCampus"));
            var selectElement = new SelectElement(selectCampus);
            selectElement.SelectByValue("3");
            Thread.Sleep(2000);
            var buttonLogin = driver.FindElement(By.ClassName("abcRioButtonContentWrapper"));
            buttonLogin.Click();
            Thread.Sleep(5000);
        }


        [Test]
        public void GoToHome()
        {
            driver.Navigate().GoToUrl(host);
            Thread.Sleep(2000);
        }

        [Test]
        public void GoToUniversityTimeTable()
        {
            driver.Navigate().GoToUrl(host);
            Thread.Sleep(2000);
            var link = driver.FindElement(By.CssSelector("a[href='Course/Courses.aspx']"));
            link.Click();
            Thread.Sleep(2000);
        }


        [Test]
        public void GoToSubjectFees()
        {
            driver.Navigate().GoToUrl(host);
            Thread.Sleep(2000);
            var link = driver.FindElement(By.CssSelector("a[href='FrontOffice/SubjectFees.aspx']"));
            link.Click();
            Thread.Sleep(2000);
        }


        [Test]
        public void GoToScheduleOfWeek()
        {
            driver.Navigate().GoToUrl(host);
            Thread.Sleep(2000);
            var link = driver.FindElement(By.CssSelector("a[href='Report/ScheduleOfWeek.aspx']"));
            link.Click();
            var selectWeek = driver.FindElement(By.Name("ctl00$mainContent$drpSelectWeek"));
            var selectElement = new SelectElement(selectWeek);
            selectElement.SelectByValue("29");
            Thread.Sleep(2000);
            var linkCourse = driver.FindElement(By.CssSelector("a[href*='../Schedule/ActivityDetail.aspx']"));
            linkCourse.Click();
            Thread.Sleep(2000);
            var linkInstructor = driver.FindElement(By.CssSelector("a[href*='../User/UserDetail.aspx']"));
            linkInstructor.Click();
            Thread.Sleep(2000);
        }

        [Test]
        public void GoToScheduleExams()
        {
            driver.Navigate().GoToUrl(host);
            Thread.Sleep(2000);
            var link = driver.FindElement(By.CssSelector("a[href='Exam/ScheduleExams.aspx']"));
            link.Click();
            Thread.Sleep(2000);
        }

        [Test]
        public void GoToAttendstudent()
        {
            driver.Navigate().GoToUrl(host);
            Thread.Sleep(2000);
            var link = driver.FindElement(By.CssSelector("a[href='Report/ViewAttendstudent.aspx']"));
            link.Click();
            Thread.Sleep(2000);
            var linkTerm = driver.FindElement(By.CssSelector("a[href*='&term=']"));
            linkTerm.Click();
            Thread.Sleep(2000);
        }



        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}