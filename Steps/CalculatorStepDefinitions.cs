using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTests_CalculatorApp.Steps
{
    [Binding, Scope(Feature = "Number Calculator")]
    public class NumberCalculatorSteps
    {
        static RemoteWebDriver driver;
        static IWebElement textBoxNum1;
        static IWebElement textBoxNum2;
        static SelectElement dropDownOperation;
        static IWebElement buttonCalc;
        static IWebElement buttonReset;
        static IWebElement divResult;

        [BeforeFeature]
        public static void OpenCalculatorApp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://js-calculator.nakov.repl.co");
            var linkNumberCalc =
                driver.FindElementByXPath("//a[@href='#'][contains(.,'Number Calculator')]");
            linkNumberCalc.Click();
            textBoxNum1 = driver.FindElementByCssSelector("input#number1");
            dropDownOperation = new SelectElement(
                driver.FindElementByCssSelector("select#operation"));
            textBoxNum2 = driver.FindElementByCssSelector("input#number2");
            buttonCalc = driver.FindElementByCssSelector(
                "#screenNumberCalc input[value='Calculate']");
            buttonReset = driver.FindElementByCssSelector(
                "#screenNumberCalc input[value='Reset']");
            divResult = driver.FindElementByCssSelector("#screenNumberCalc div.result");
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

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(string firstNum)
        {
            textBoxNum1.SendKeys(firstNum);
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(string secondNum)
        {
            textBoxNum2.SendKeys(secondNum);
        }

        [When("the two numbers are (.*)")]
        public void WhenTheTwoNumbersAreAdded(string operation)
        {
            if (operation == "added")
                dropDownOperation.SelectByValue("+");
            else if (operation == "subtracted")
                dropDownOperation.SelectByValue("-");
            else if (operation == "multiplied")
                dropDownOperation.SelectByValue("*");
            else if (operation == "divided")
                dropDownOperation.SelectByValue("/");
            else
                throw new InvalidOperationException(
                    $"Operation {operation} not supported by the Number Calculator app!");
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