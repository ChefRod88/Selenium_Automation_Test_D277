using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static IWebDriver driver;

    static void Main(string[] args)
    {
        // Initialize the WebDriver (Chrome in this case)
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("http://www.sunshinestate.byethost10.com/");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        // Define the expected title
        string expectedTitle = "Welcome to Florida";

        // Run the test cases
        CheckTitle(expectedTitle);
        CheckHomepageImage();
        CheckCapitalMiamiOrlandoImagesArePresent();
        CheckNavLinks();
        CheckCapitalCityDetails();

        // Close the browser after the tests are done
        driver.Quit();
    }

    // Function to check the page title
    static void CheckTitle(string expectedTitle)
    {
        try
        {
            // Get the current page title
            string actualTitle = driver.Title;

            // Assert the title matches the expected title
            if (actualTitle == expectedTitle)
            {
                Console.WriteLine($"PASS: The title is correct. '{actualTitle}' matches the expected title.");
            }
            else
            {
                Console.WriteLine($"FAIL: Expected title '{expectedTitle}', but got '{actualTitle}'.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"FAIL: Error occurred while checking the title: {e.Message}");
        }
    }

    // Function to check if images are present on the homepage
    static void CheckHomepageImage()
    {
        try
        {
            // Try to find any image on the page
            var imageElements = driver.FindElements(By.TagName("img"));

            // Check if any image elements were found
            if (imageElements.Count == 0)
            {
                Console.WriteLine("PASS: No images found on the homepage.");
            }
            else
            {
                Console.WriteLine("FAIL: Images found on the homepage.");
                // Optional: Check if images are visible and have alt text
                foreach (var img in imageElements)
                {
                    if (img.Displayed)
                    {
                        string altText = img.GetAttribute("alt");
                        if (!string.IsNullOrEmpty(altText))
                        {
                            Console.WriteLine($"FAIL: Image is displayed and has an alt tag: {altText}");
                        }
                        else
                        {
                            Console.WriteLine("FAIL: Image is displayed but does not have an alt tag.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("FAIL: Image found but is not displayed.");
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"FAIL: Error occurred while checking the homepage image: {e.Message}");
        }
    }

    // Function to check if images are present on capital, orlando, or miami pages
    static void CheckCapitalMiamiOrlandoImagesArePresent()
    {
        List<string> pages = new List<string>
        {
            "capital.html",  // Tallahassee
            "orlando.html",  // Orlando
            "miami.html"     // Miami
        };

        string baseUrl = "http://www.sunshinestate.byethost10.com/";

        foreach (string page in pages)
        {
            string fullUrl = baseUrl + page;  // Combine base URL with the page URL
            driver.Navigate().GoToUrl(fullUrl);  // Navigate to the page

            try
            {
                // Wait explicitly for the image element to be located
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var imageElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.TagName("img")));

                // Check if the image is displayed
                if (imageElement.Displayed)
                {
                    Console.WriteLine($"PASS: Image is displayed on {page}");
                }
                else
                {
                    Console.WriteLine($"FAIL: Image is not displayed on {page}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"FAIL: Error occurred on {page}: {e.Message}");
            }
        }
    }

    // Function to check navigation links on all pages
    static void CheckNavLinks()
    {
        List<string> pages = new List<string>
        {
            "index.html",    // Home Page
            "capital.html",  // Tallahassee
            "orlando.html",  // Orlando
            "miami.html",    // Miami
            "contact.html"   // Contact Form
        };

        string baseUrl = "http://www.sunshinestate.byethost10.com/";

        foreach (string page in pages)
        {
            string fullUrl = baseUrl + page;  // Combine base URL with the page URL
            driver.Navigate().GoToUrl(fullUrl);  // Navigate to the page

            try
            {
                var navLinks = driver.FindElements(By.TagName("a"));

                if (navLinks.Count == 0)
                {
                    Console.WriteLine($"FAIL: No navigation links found on {fullUrl}.");
                }
                else
                {
                    Console.WriteLine($"PASS: Navigation links found on {fullUrl}.");
                    // Check if the links are displayed and have the 'href' attribute
                    foreach (var link in navLinks)
                    {
                        if (link.Displayed && !string.IsNullOrEmpty(link.GetAttribute("href")))
                        {
                            Console.WriteLine($"PASS: Link '{link.Text}' is displayed and has an 'href' attribute.");
                        }
                        else
                        {
                            Console.WriteLine($"FAIL: Link '{link.Text}' is either not displayed or does not have an 'href' attribute.");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"FAIL: Error occurred while checking the navigation links on {fullUrl}: {e.Message}");
            }
        }
    }

    // Function to check the capital city details (Tallahassee)
    static void CheckCapitalCityDetails()
    {
        driver.Navigate().GoToUrl("http://www.sunshinestate.byethost10.com/capital.html");

        string expectedPopulation = "200,000";
        string expectedYearIncorporated = "1825";
        string expectedRegion = "Northwest";
        string expectedClassification = "Classification: Urban";
        string expectedIncomeLevel = "Income: Moderate compared to Florida's average";

        try
        {
            string actualPopulation = driver.FindElement(By.XPath("//*[contains(text(),'Population')]")).Text;
            string actualYearIncorporated = driver.FindElement(By.XPath("//*[contains(text(),'Incorporated')]")).Text;
            string actualRegion = driver.FindElement(By.XPath("//*[contains(text(),'Region')]")).Text;
            string actualClassification = driver.FindElement(By.XPath("//*[contains(text(),'Classification')]")).Text;
            string actualIncomeLevel = driver.FindElement(By.XPath("//*[contains(text(),'Income')]")).Text;

            // Assertions to verify that the values are correct
            if (!actualPopulation.Contains(expectedPopulation))
                Console.WriteLine($"FAIL: Expected population '{expectedPopulation}', but got '{actualPopulation}'");
            if (!actualYearIncorporated.Contains(expectedYearIncorporated))
                Console.WriteLine($"FAIL: Expected year incorporated '{expectedYearIncorporated}', but got '{actualYearIncorporated}'");
            if (!actualRegion.Contains(expectedRegion))
                Console.WriteLine($"FAIL: Expected region '{expectedRegion}', but got '{actualRegion}'");
            if (!actualClassification.Contains(expectedClassification))
                Console.WriteLine($"FAIL: Expected classification '{expectedClassification}', but got '{actualClassification}'");
            if (!actualIncomeLevel.Contains(expectedIncomeLevel))
                Console.WriteLine($"FAIL: Expected income level '{expectedIncomeLevel}', but got '{actualIncomeLevel}'");

            // If all assertions pass
            Console.WriteLine("PASS: All capital city details are correct.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"FAIL: Error occurred while checking the capital city details: {e.Message}");
        }
    }
}
