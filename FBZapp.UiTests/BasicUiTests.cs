using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FBZapp.UiTests
{
    [TestFixture]
    public class BasicUiTests
    {
        private IWebDriver? driver;
        private WebDriverWait? wait;
        private string baseUrl = string.Empty;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            baseUrl = "https://localhost:44395";
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
            driver = null;
            wait = null;
        }

        [Test]
        public void LoginPage_Should_Load()
        {
            driver!.Navigate().GoToUrl(baseUrl + "/Account/Login");
            wait!.Until(d => d.PageSource.Contains("Login"));

            Assert.That(driver.PageSource, Does.Contain("Login"));
        }

        [Test]
        public void ComicsPage_Should_Load()
        {
            driver!.Navigate().GoToUrl(baseUrl + "/Comics");
            wait!.Until(d => d.PageSource.Contains("Comic Search"));

            Assert.That(driver.PageSource, Does.Contain("Comic Search"));
        }

        [Test]
        public void AboutPage_Should_Load()
        {
            driver!.Navigate().GoToUrl(baseUrl + "/Home/About");
            wait!.Until(d => d.PageSource.Length > 0);

            Assert.That(driver.PageSource.Length, Is.GreaterThan(0));
        }
    }
}