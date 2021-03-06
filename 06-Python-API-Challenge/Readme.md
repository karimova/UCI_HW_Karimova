# **Python API Homework - What's the Weather Like?**

## **Input Data**

`WeatherPy/WeatherPy_solved.ipynb` - script to run the weather analysis (Jupyter Notebook)

`VacationPy/VacationPy_solved.ipynb` - script to run the vacation analysis (Jupyter Notebook)

To run these scripts you will need:

* Install `citypy` in your python environment (https://pypi.python.org/pypi/citipy)

* Create two API Keys and store them in the 'api_keys.py':

    `weather_api_key` - OpenWeatherMap API Key (https://openweathermap.org/)
    
    `g_key` - Google API Key (https://console.developers.google.com/getting-started) 
    
## **Part I - WeatherPy**

In this part, a Python script to visualize the weather of 500+ cities across the world of varying distance from the equator was created. 

In the first step, a series of scatter plots to showcase the following relationships were created:

![max_temp](WeatherPy/Images/City_Latitude_vs_Max_Temperature.png)


![humidity](WeatherPy/Images/City_Latitude_vs_Humidity.png)


![cloudiness](WeatherPy/Images/City_Latitude_vs_Cloudiness.png)


![wind](WeatherPy/Images/City_Latitude_vs_Wind_Speed.png)



The second step is to run linear regression on each relationship. This time, cities were separating into Northern Hemisphere (greater than or equal to 0 degrees latitude) and Southern Hemisphere (less than 0 degrees latitude):

#### 1. Northern Hemisphere - Temperature (F) vs. Latitude

The value of (R<sup>2</sup>) is 0.6928352119310256

![max_temp](WeatherPy/Images/Northern_Hemisphere_City_Latitude_vs_Max_Temperature.png)


#### 2. Southern Hemisphere - Temperature (F) vs. Latitude

The value of (R<sup>2</sup>) is 0.29777248084213165

![max_temp](WeatherPy/Images/Southern_Hemisphere_City_Latitude_vs_Max_Temperature.png)


#### 3. Northern Hemisphere - Humidity (%) vs. Latitude

The value of (R<sup>2</sup>) is 0.036520078332717434

![hum](WeatherPy/Images/Northern_Hemisphere_City_Latitude_vs_Humidity.png)


#### 4. Southern Hemisphere - Humidity (%) vs. Latitude

The value of (R<sup>2</sup>) is 0.06510856728144215

![hum](WeatherPy/Images/Southern_Hemisphere_City_Latitude_vs_Humidity.png)


#### 5. Northern Hemisphere - Cloudiness (%) vs. Latitude

The value of (R<sup>2</sup>) is 0.02222779724000044

![cloud](WeatherPy/Images/Northern_Hemisphere_City_Latitude_vs_Cloudiness.png)


#### 6. Southern Hemisphere - Cloudiness (%) vs. Latitude

The value of (R<sup>2</sup>) is 0.015428689903624284

![cloud](WeatherPy/Images/Southern_Hemisphere_City_Latitude_vs_Cloudiness.png)


#### 7. Northern Hemisphere - Wind Speed (mph) vs. Latitude

The value of (R<sup>2</sup>) is 0.00022051436367263692

![wind](WeatherPy/Images/Northern_Hemisphere_City_Latitude_vs_Wind_Speed.png)


#### 8. Southern Hemisphere - Wind Speed (mph) vs. Latitude

The value of (R<sup>2</sup>) is 0.09267616215139951

![wind](WeatherPy/Images/Southern_Hemisphere_City_Latitude_vs_Wind_Speed.png)


### Conclutions.

* Highest temperature is found for cities with latitudes between 20 and -20 degrees. Temperature significantly drops with increasing the latitude.

* The strong correclation was found bewteen (Max Temperature and Latitude). However, there are no obvious correlation between (humidity and Latitude) and (cloudiness and Latitude).

* Wind Speed (mph) data for all latitutes are mainly concentrate below 15 mph, and do not go above 35 mph.  


## **Part II - VacationPy**

Now obtained weather data can be used to plan future vacations. Jupyter-gmaps and the Google Places API were used for this part of the project.

`WeatherPy/output_data/cities.csv` - data location

* Heat map that displays the humidity for every city from the part I of the project was generated.

  ![heatmap](VacationPy/Images/Humidity_Heatmap.png)

* Set your ideal weather condition. For example:

  - A max temperature in the range of 75 - 85 F degrees.
  - Zero cloudiness.
  - Wind speed less than 5 mph.
  - Any rows that don't contain all three conditions were droped.

![heatmap](VacationPy/Images/Hotel_Map.png)
