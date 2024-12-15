from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC

# Initialize the WebDriver (Chrome in this case)
driver = webdriver.Chrome()
driver.maximize_window()
driver.get("http://www.sunshinestate.byethost10.com/")
driver.implicitly_wait(5)  # This helps, but we will use explicit waits as well

# Define the expected title
expected_title = "Welcome to Florida"

# Function to check the page title
def check_title(expected_title):
    try:
        # Get the current page title
        actual_title = driver.title

        # Assert the title matches the expected title
        assert actual_title == expected_title, f"FAIL: Expected title '{expected_title}', but got '{actual_title}'"

        print(f"PASS: The title is correct. '{actual_title}' matches the expected title.")
    except AssertionError as e:
        print(str(e))
    except Exception as e:
        print(f"FAIL: Error occurred while checking the title: {str(e)}")

# Function to check if images are present on the homepage
def check_homepage_image():
    try:
        # Try to find any image on the page
        image_elements = driver.find_elements(By.TAG_NAME, "img")

        # Check if any image elements were found
        if len(image_elements) == 0:
            print("PASS: No images found on the homepage.")
        else:
            print("FAIL: Images found on the homepage.")
            # Optional: You can also check if images are visible and have alt text
            for img in image_elements:
                if img.is_displayed():
                    alt_text = img.get_attribute("alt")
                    if alt_text:
                        print(f"FAIL: Image is displayed and has an alt tag: {alt_text}")
                    else:
                        print(f"FAIL: Image is displayed but does not have an alt tag.")
                else:
                    print(f"FAIL: Image found but is not displayed.")
    except Exception as e:
        print(f"FAIL: Error occurred while checking the homepage image: {str(e)}")

# Function to check if images are present on capital, orlando, or miami pages
def check_capital_miami_orlando_images_are_present():
    pages = [
        "capital.html",  # Tallahassee
        "orlando.html",  # Orlando
        "miami.html"  # Miami
    ]

    base_url = "http://www.sunshinestate.byethost10.com/"  # Base URL for relative paths

    for page in pages:
        full_url = base_url + page  # Combine base URL with the page URL
        driver.get(full_url)  # Navigate to the page

        try:
            # Wait explicitly for the image element to be located
            image_element = WebDriverWait(driver, 10).until(
                EC.presence_of_element_located((By.TAG_NAME, "img"))
            )

            # Check if the image is displayed
            if image_element.is_displayed():
                print(f"PASS: Image is displayed on {page}")
            else:
                print(f"FAIL: Image is not displayed on {page}")
        except Exception as e:
            print(f"FAIL: Error occurred on {page}: {str(e)}")

def check_nav_links():
    pages = [
        "index.html",    # Home Page
        "capital.html",  # Tallahassee
        "orlando.html",  # Orlando
        "miami.html",    # Miami
        "contact.html"   #Contact Form
    ]

    base_url = "http://www.sunshinestate.byethost10.com/"  # Base URL for relative paths

    for page in pages:
        full_url = base_url + page  # Combined base URL with the page URL
        driver.get(full_url)  # Navigate to the page

        try:
            nav_links = driver.find_elements(By.TAG_NAME, "a")

            if len(nav_links) == 0:
                print(f"FAIL: No navigation links found on {full_url}.")
            else:
                print(f"PASS: Navigation links found on {full_url}.")
                 # Optional: Check if the links are displayed and have the 'href' attribute
                for link in nav_links:
                    if link.is_displayed() and link.get_attribute("href"):
                        print(f"PASS: Link '{link.text}' is displayed and has an 'href' attribute.")
                    else:
                        print(f"FAIL: Link '{link.text}' is either not displayed or does not have an 'href' attribute.")
        except:
            print(f"FAIL: Error occurred while checking the navigation links on {full_url}")


def check_capital_city_details():
    # Navigate to the capital city page (Tallahassee)
    driver.get("http://www.sunshinestate.byethost10.com/capital.html")

    driver.implicitly_wait(5)

    expected_population = "200,000"
    expected_year_incorporated = "1825"
    expected_region = "Northwest"
    expected_classification = "Classification: Urban"
    expected_income_level = "Income: Moderate compared to Florida's average"

    try:
        actual_population = driver.find_element(By.XPATH, "//*[contains(text(),'Population')]").text
        actual_year_incorporated = driver.find_element(By.XPATH, "//*[contains(text(),'Incorporated')]").text
        actual_region = driver.find_element(By.XPATH, "//*[contains(text(),'Region')]").text
        actual_classification = driver.find_element(By.XPATH, "//*[contains(text(),'Classification')]").text
        actual_income_level = driver.find_element(By.XPATH, "//*[contains(text(),'Income')]").text

        # Assertions to verify that the values are correct (you may need to adjust text depending on format)
        assert expected_population in actual_population, f"FAIL: Expected population '{expected_population}', but got '{actual_population}'"
        assert expected_year_incorporated in actual_year_incorporated, f"FAIL: Expected year incorporated '{expected_year_incorporated}', but got '{actual_year_incorporated}'"
        assert expected_region in actual_region, f"FAIL: Expected region '{expected_region}', but got '{actual_region}'"
        assert expected_classification in actual_classification, f"FAIL: Expected classification '{expected_classification}', but got '{actual_classification}'"
        assert expected_income_level in actual_income_level, f"FAIL: Expected income level '{expected_income_level}', but got '{actual_income_level}'"

        # If all assertions pass
        print("PASS: All capital city details are correct.")

    except Exception as e:
        print(f"FAIL: Error occurred while checking the capital city details: {str(e)}")





# Check the title of the homepage
check_title(expected_title)

# Check the homepage image
check_homepage_image()

# Check for images on all the pages (capital, orlando, miami)
check_capital_miami_orlando_images_are_present()

# Check for nav links on all pages (index, capital, orlando, miami and contact)
check_nav_links()



# Close the browser after the tests are done
driver.quit()