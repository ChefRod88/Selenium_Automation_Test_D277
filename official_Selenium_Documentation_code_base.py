import time

from pyexpat.errors import messages
from selenium import webdriver
from selenium.webdriver.common.by import By

#1
driver = webdriver.Chrome() #starts the session
driver.maximize_window()
#2
driver.get("https://www.selenium.dev/selenium/web/web-form.html") #Take action on the browser. In this example we are navigating to a web page.

#3
title = driver.title #Request browser information

#4
driver.implicitly_wait(0.5) #Synchronizing the code with the current state of the browser is one of the biggest challenges with Selenium, and doing it well is an advanced topic.

#Essentially you want to make sure that the element is on the page before you attempt to locate it and the element is in an interactable state before you attempt to interact with it.

#An implicit wait is rarely the best solution, but it’s the easiest to demonstrate here, so we’ll use it as a placeholder.

#5
text_box = driver.find_element(by=By.NAME, value="my-text") # The majority of commands in most Selenium sessions are element related, and you can’t interact with one without first finding an element
submit_button = driver.find_element(by=By.CSS_SELECTOR, value="button")

#6
#Take action on element. There are only a handful of actions to take on an element, but you will use them frequently.
text_box.clear()
password = "Selenium"
text_box.send_keys(password)
submit_button.click()

message = driver.find_element(by=By.ID, value="message")
text = message.text

driver.quit()

time.sleep(10)