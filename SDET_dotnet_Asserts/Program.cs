using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSquare_Maintenance
{
    class Program
    {
        IWebDriver driver;
        public IWebDriver SetUpDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendText(IWebElement element, string value)
        {
            element.SendKeys(value + Keys.Enter);
        }

        #region Google Locators
        By GoogleSearchBar = By.XPath("//textarea[@class='gLFyf']");
        By GoogleSearIcon = By.XPath("//div[@class='FPdoLc lJ9FBc']/center/input[@class='gNO89b']");
        By UnoSquareGoogleResult = By.XPath("//h3[@class='LC20lb MBeuO DKV0Md'][contains(.,'Unosquare: Home Page')]");
        #endregion

        #region UnoSquare Locators
        By UnoSquareServicesMenu = By.Id("menu-item-8439");
        By PracticeAreas = By.Id("menu-item-8497");
        By ContactUs = By.XPath("(//a[contains(@class,'elementor-button elementor-button-link elementor-size-sm')])[8]");
        By ElementTitle = By.XPath("//h2[contains(.,'Ready to Transform Your Tech?')]");
        #endregion 
        static void Main(string[] args)
        {

            IWebDriver Browser;
            IWebElement element;
            Program program = new Program();
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";

            //Wirite the locator for the Google Search Bar
            element = Browser.FindElement(program.GoogleSearchBar);

            // Write Assert True that element is present 
            Assert.IsTrue(element.Displayed);

            //Send the text "Unosquare" to the Text Bar, and enter
            program.SendText(element, "Unosquare");

            // Locate the first result corresponding to Unosquare and click on the Link
            element = Browser.FindElement(program.UnoSquareGoogleResult);

            // Write Assert Equal [Unosquare: Home Page - Smart Engineering For Your Digital ...] vs [Element.text]
            string expectedText = "Unosquare: Home Page - Smart Engineering For Your Digital ...";
            Assert.AreEqual(expectedText, element.Text);

            program.Click(element);

            //Locate the Service Menu and Click the element
            element = Browser.FindElement(program.UnoSquareServicesMenu);

            // Write Assert True that element is present [Services] menu object
            Assert.IsTrue(element.Displayed, "Services menu is not present on the page.");

            program.Click(element);

            //Locate the Practice Areas Menu and Click the Element
            element = Browser.FindElement(program.PracticeAreas);

            // Write Assert True that element is present [Industries] menu object
            Assert.IsTrue(element.Displayed, "Industries menu is not present on the page.");

            program.Click(element);

            //Locate the Contact Us Menu and Click the Element
            element = Browser.FindElement(program.ContactUs);

            program.Click(element);

            // Write Assert Equal [Ready to Transform Your Tech?] vs [Element.text] h2 ojbect
            string h2ExprectedText = "Ready to Transform Your Tech?";
            element = Browser.FindElement(program.ElementTitle);
            Assert.AreEqual(element.Text, h2ExprectedText);

            program.driver.Quit();

        }
    }
}
