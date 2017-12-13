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
	/// UITest1 的摘要描述
	/// </summary>
	[TestClass]
	public class UITest1
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
			string url = "http://www.gigabyte.tw/Motherboard/AORUS-Gaming";

			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
			driver.Navigate().GoToUrl(url);

			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			var imgs = wait.Until(d => d.FindElements(By.XPath(".//img[contains(@src,'//static.gigabyte.com/Product/2/')]")));
			string imgTitle = imgs[0].GetAttribute("title");

			if (imgTitle != "Z370 AORUS Gaming 7(1.0)")
			{
				Assert.Fail("The first image is not Z370 AORUS Gaming 7(1.0)");
			}
		}

		[TestCleanup()]
		public void MyTestCleanup()
		{
			driver.Quit();
			driver.Dispose();
		}
	}
}
