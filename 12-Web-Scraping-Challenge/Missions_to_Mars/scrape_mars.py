from splinter import Browser
from bs4 import BeautifulSoup
from webdriver_manager.chrome import ChromeDriverManager

#Site Navigation
def init_browser():
    executable_path = {'executable_path': ChromeDriverManager().install()}
    return Browser("chrome", **executable_path, headless=False)


# Defining scrape & dictionary
def scrape():
    final_data = {}
    mars_news = marsNews()
    final_data["mars_news"] = mars_news[0]
    final_data["mars_paragraph"] = mars_news[1]
    final_data["mars_image"] = marsImage()
    final_data["mars_facts"] = marsFacts()
    final_data["mars_hemisphere"] = marsHem()

    return final_data

# Mars News: Title and Paragraph

def marsNews():
    browser = init_browser()
    news_url = "https://mars.nasa.gov/news/"
    browser.visit(news_url)
    html = browser.html
    soup = BeautifulSoup(html, "html.parser")
    results = soup.find("div", class_='list_text')
    title = results.find("div", class_="content_title").text
    paragraph = results.find("div", class_ ="article_teaser_body").text
    mars_news = [title, paragraph]
    return mars_news

# JPL Mars Space Images - Featured Image
def marsImage():
    browser = init_browser()
    image_url = "https://www.jpl.nasa.gov/spaceimages/?search=&category=Mars"
    browser.visit(image_url)
    html = browser.html
    soup = BeautifulSoup(html, "html.parser")
    image = soup.find("img", class_="thumb")["src"]
    featured_image_url = "https://www.jpl.nasa.gov" + image
    return featured_image_url

# Mars Facts
def marsFacts():
    import pandas as pd
    browser = init_browser()
    facts_url = "https://space-facts.com/mars/"
    browser.visit(facts_url)
    mars_info = pd.read_html(facts_url)
    mars_info = pd.DataFrame(mars_info[0])
    mars_info.columns = ["Parameter", "Value"]
    mars_info = mars_info.set_index("Parameter")
    mars_facts = mars_info.to_html(index = True, header =True)
    return mars_facts


# Mars Hemispheres
def marsHem():
    import time
    browser = init_browser() 
    hemispheres_url = "https://astrogeology.usgs.gov/search/results?q=hemisphere+enhanced&k1=target&v1=Mars"
    browser.visit(hemispheres_url)
    html = browser.html
    soup = BeautifulSoup(html, "html.parser")
    mars_hemisphere = []

    results = soup.find_all("div", class_="item")

    for result in results:
        title = result.find('h3').text
        img_link = result.find('a', class_='itemLink product-item')['href']
        full_img_link = "https://astrogeology.usgs.gov" + img_link
        browser.visit(full_img_link)
        html = browser.html
        soup=BeautifulSoup(html, "html.parser")
        dl = soup.find("div", class_="downloads")
        img_url = dl.find("a")["href"]
        mars_hemisphere.append({"title": title, "img_url": img_url})
    return mars_hemisphere
