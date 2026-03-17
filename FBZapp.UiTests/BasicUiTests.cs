using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace FBZapp.UiTests
{
    [TestFixture]
    public class BasicUiTests
    {
        private ChromeDriver driver;
        private string baseUrl;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);

            baseUrl = "https://localhost:44395";
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }

        [Test]
        public void LoginPage_Should_Load()
        {
            driver.Navigate().GoToUrl(baseUrl + "/Account/Login");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.FindElement(By.TagName("body")));

            Assert.That(driver.Url, Does.Contain("/Account/Login"));
            Assert.That(driver.PageSource, Does.Contain("Login"));
        }

        [Test]
        public void RegisterPage_Should_Load()
        {
            driver.Navigate().GoToUrl(baseUrl + "/Account/Register");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.FindElement(By.TagName("body")));

            Assert.That(driver.Url, Does.Contain("/Account/Register"));
            Assert.That(driver.PageSource, Does.Contain("Register"));
        }

        [Test]
        public void ComicsPage_Should_Load()
        {
            driver.Navigate().GoToUrl(baseUrl + "/Comics");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.FindElement(By.TagName("body")));

            Assert.That(driver.Url, Does.Contain("/Comics"));
            Assert.That(driver.FindElement(By.TagName("body")).Text.Length, Is.GreaterThan(0));
        }
    }
}
