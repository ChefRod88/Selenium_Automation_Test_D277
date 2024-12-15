# Selenium_Automation_Test_D277

README
Project Overview
This repository contains an automated Selenium-based testing suite to verify the key details of a website representing various cities in Florida. The goal of this project is to ensure that the pages are functioning correctly, with tests validating the presence of necessary elements, such as page titles, images, navigation links, and specific content on the pages.

The main objective is to achieve 100% test coverage for the website, covering:

Homepage title verification
Image presence checks on key pages (capital city, Orlando, Miami)
Verification of essential page elements (navigation links)
Content validation for specific city pages (capital city, Orlando, Miami)
This README provides a detailed explanation of the testing suite, setup instructions, test case descriptions, and how you can run the tests.

Project Goals
Automation with Selenium: Using Selenium WebDriver, we test the functionality of a website representing cities in Florida.
100% Test Coverage: Each page element (title, images, navigation links, and specific content) is checked, ensuring full coverage and high-quality testing.
Error Handling and Logging: Proper error handling ensures the test results are clear and concise. Failures are captured with meaningful messages to help diagnose issues quickly.
Test Cases Overview
1. Homepage Title Verification
The test checks if the homepage title is correct by comparing the actual title with the expected title "Welcome to Florida."

2. Homepage Image Verification
This test checks if there are any images present on the homepage. If no images are found, the test reports it as a failure. Additional checks for image visibility and alt text are also performed.

3. Image Presence on Specific Pages (Capital, Orlando, Miami)
We verify that each of the specific pages (capital.html, orlando.html, miami.html) contains at least one visible image. If an image is not displayed, the test will fail.

4. Navigation Links Validation
This test ensures that all pages have working navigation links. For each page (index.html, capital.html, orlando.html, miami.html, contact.html), the test checks the presence and visibility of navigation links and ensures that the links contain valid href attributes.

5. Capital City Details Verification
This test checks specific details about Tallahassee (the capital city). It ensures that the following elements are correctly displayed:

Population
Year Incorporated
Region
Classification
Income Level
The values are compared with the expected results, and any discrepancies will cause a test failure.

Project Setup
Prerequisites
Python 3.x: The project uses Python 3 for running the Selenium WebDriver tests.
Selenium: A Python library to automate web browser interactions.
Chrome WebDriver: The Selenium WebDriver requires a Chrome browser installed on your machine for running tests.
Installation
Clone the repository:

bash
Copy code
git clone https://github.com/yourusername/selenium-florida-city-tests.git
cd selenium-florida-city-tests
Install dependencies:

You can install the required Python libraries by running:

bash
Copy code
pip install -r requirements.txt
Download Chrome WebDriver:

Download Chrome WebDriver from here.
Make sure the version of the WebDriver matches your installed version of Chrome.
Add WebDriver to your system's PATH.
Running the Tests
To run the test suite, execute the Python script:

bash
Copy code
python test_script.py
This will run all the test cases and output the results (PASS or FAIL) for each of the checks.

Expected Output
For each test case, you should see either a "PASS" or "FAIL" message. For example:

vbnet
Copy code
PASS: The title is correct. 'Welcome to Florida' matches the expected title.
FAIL: Images found on the homepage.
PASS: Image is displayed on capital.html
PASS: Navigation links found on index.html.
FAIL: Error occurred while checking the capital city details: 'Population' not found.
The output helps you identify which specific checks failed, allowing for easier debugging.

Closing the Browser
Once all tests have been executed, the script ensures that the browser window is closed:

python
Copy code
driver.quit()
Test Coverage
The test suite is designed to cover 100% of the following:

Title checks: Each page has a correct title (verified using driver.title).
Image presence: Each page (homepage, capital city, Orlando, and Miami) has at least one visible image.
Navigation links: All pages have functional navigation links, which are checked for proper visibility and valid href attributes.
Page content validation: Each city page (e.g., Tallahassee, Orlando, Miami) has the required details like population, year of incorporation, region, classification, and income level.
Code Explanation
The code performs the following steps:

Driver Setup:

A Selenium WebDriver instance (driver) is created to launch Chrome in the test environment. The browser is maximized, and the test URL is loaded (http://www.sunshinestate.byethost10.com/).
An implicit wait of 5 seconds is used, with explicit waits also applied in key places to ensure elements are loaded before interacting with them.
Test Functions:

check_title: Compares the actual title of the homepage with the expected title.
check_homepage_image: Ensures that images on the homepage are displayed and have alt text.
check_capital_miami_orlando_images_are_present: Checks for visible images on specific pages (capital, Orlando, Miami).
check_nav_links: Verifies that navigation links on each page have valid href attributes and are visible.
check_capital_city_details: Checks that the capital city page (Tallahassee) displays correct population, year incorporated, region, classification, and income level.
Assertions:

Assertions are used to verify that the values extracted from the web pages match the expected values. If any assertion fails, an error message is printed.
If all checks pass, a confirmation message is displayed.
