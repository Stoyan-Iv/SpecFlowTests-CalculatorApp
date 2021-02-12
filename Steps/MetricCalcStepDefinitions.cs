using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowTests_CalculatorApp.Steps
{
    [Binding, Scope(Feature = "Metric Calculator")]
    public class MetricCalcSteps
    {
        static RemoteWebDriver driver;
        static IWebElement valueBoxNum; 
        static SelectElement dropDownFromMetric;
        static SelectElement dropDownToMetric;
        static IWebElement buttonCalc;
        static IWebElement buttonReset;
        static IWebElement divResult;
        static IWebElement startMetricCalcButton;

        [BeforeFeature]
        public static void OpenCalculatorApp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://js-calculator.nakov.repl.co");
            startMetricCalcButton = driver.FindElementByXPath("(//a[@href='#'])[3]");
            startMetricCalcButton.Click();
            valueBoxNum = driver.FindElementByCssSelector("#fromValue");
            dropDownFromMetric = new SelectElement(driver.FindElementByCssSelector("#sourceMetric"));
            dropDownToMetric = new SelectElement(driver.FindElementByXPath("//*[@id=\"destMetric\"]"));
            buttonCalc = driver.FindElementByCssSelector(
                "#screenMetricCalc > form > div.buttons-bar > input[type=button]:nth-child(1)");
            buttonReset = driver.FindElementByCssSelector(
                "#screenMetricCalc > form > div.buttons-bar > input[type=reset]:nth-child(2)");
            divResult = driver.FindElementByCssSelector("#screenMetricCalc > div");
        }

        [AfterFeature]
        public static void CloseCalculatorApp()
        {
            driver.Quit();
        }

        [BeforeScenario]
        public static void ResetCalculatorApp()
        {
            buttonReset.Click();
        }

        [Given("the  number is (.*)")]
        public void GivenNumberIs(string num)
        {
            valueBoxNum.SendKeys(num);  
        }

        [Given("the first metric is (.*)")]
        public void GivenFirstMetric(string firstMetric)
        {
           if (firstMetric == "kilometers")
                dropDownFromMetric.SelectByValue("km");
           else if (firstMetric == "meters")
                    dropDownFromMetric.SelectByValue("m");
           else if (firstMetric == "centimeters")
                dropDownFromMetric.SelectByValue("cm");
           else if (firstMetric == "milimeters")
                dropDownFromMetric.SelectByValue("mm");
           else
                throw new InvalidOperationException(
                    $"The given metric {firstMetric} not supported by the Metric Calculator app!");
        }

        [Given("the second metric is (.*)")]
        public void WhenTheSecondMetric(string secondMEtric)
        {

           if (secondMEtric == "kilometers")
               dropDownToMetric.SelectByValue("km");
           else if (secondMEtric == "meters")
                dropDownToMetric.SelectByValue("m");
           else if (secondMEtric == "centimeters")
                dropDownToMetric.SelectByValue("cm");
           else if (secondMEtric == "milimeters")
                dropDownToMetric.SelectByValue("mm");
           else
               throw new InvalidOperationException(
                   $"The given metric {secondMEtric} not supported by the Metric Calculator app!");
         
        }
        [When("the metrics are converted")]
        public void clickButton()
        {
           
            buttonCalc.Click();
        }


        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string expectedResult)
        {
            var result = divResult.Text;
            result = result.Substring("Result: ".Length);
            result.Should().Be(expectedResult);
            //Assert.AreEqual(expectedResult, result);
        }
    }
}