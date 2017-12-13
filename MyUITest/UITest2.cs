using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace MyUITest
{
	/// <summary>
	/// Test Australia's distributor exist
	/// </summary>
	[TestClass]
	public class UITest2
	{
		private IWebDriver driver;

		[TestInitialize()]
		public void Initialize()
		{
		}

		[TestMethod]
		[TestCategory("Selenium")]
		public void TestMethod1()
		{
			string url = "http://www.gigabyte.tw/Buy#105134000,,1,1,1-0";

			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
			driver.Navigate().GoToUrl(url);

			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

			Thread.Sleep(1000);

			var select = wait.Until(d => d.FindElement(By.Id("country-select")));
			var selectElement = new SelectElement(select);
			selectElement.SelectByValue("106008000");

			Thread.Sleep(1000);

			select = wait.Until(d => d.FindElement(By.Id("productLine")));
			selectElement = new SelectElement(select);
			selectElement.SelectByValue("3");

			Thread.Sleep(1000);

			select = wait.Until(d => d.FindElement(By.XPath("//select[@class = 'Special-saleType']")));
			selectElement = new SelectElement(select);
			selectElement.SelectByValue("1");

			Thread.Sleep(1000);

			var imgs = wait.Until(d => d.FindElements(By.XPath("//img[@class = 'wtb-logo']")));
			if (imgs.Count == 0)
			{
				Assert.Fail("Australia's distributor is not exist");
			}

			Thread.Sleep(3000);
		}

		[TestCleanup()]
		public void MyTestCleanup()
		{
			driver.Quit();
			driver.Dispose();
		}
	}
}
