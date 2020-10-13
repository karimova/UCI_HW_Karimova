# **Matplotlib - The Power of Plots**

Pymaceuticals Inc.is a pharmaceutical company based out of San Diego. Pymaceuticals specializes in anti-cancer pharmaceuticals. In its most recent efforts, it began screening for potential treatments for squamous cell carcinoma (SCC), a commonly occurring form of skin cancer. In this study, 249 mice identified with SCC tumor growth were treated through a variety of drug regimens. Over the course of 45 days, tumor development was observed and measured. The purpose of this study was to compare the performance of Pymaceuticals' drug of interest, Capomulin, versus the other treatment regimens. 

Matplotlib Analysis have been performed to generate all of the tables and figures needed for the technical report of the study. 
The executive team also has asked for a top-level summary of the study results.

## **Input Data**
`data/Mouse_metadata.csv` - information about mice in the experiment (id, gender, weight etc)

`data/Study_results.csv` - study results (tumor volume, time points etc)

## **Analysis Steps**

In the beginning of the analysis, the data for any mouse ID was checked with duplicate time points. All duplicates were removed any data associated with that mouse ID.
The cleaned data were used for the remaining steps.

* A summary statistics table consisting of the mean, median, variance, standard deviation, and SEM of the tumor volume for each drug regimen was generated.


* A bar plot using both Pandas's DataFrame.plot() and Matplotlib's pyplot that shows  the number of total mice for each treatment regimen throughout the course of the study was generated.


* A pie plot using both Pandas's DataFrame.plot() and Matplotlib's pyplot that shows the distribution of female or male mice in the study was generated.

* The final tumor volume of each mouse across four of the most promising treatment regimens: Capomulin, Ramicane, Infubinol, and Ceftamin was calculated. 
  Calculate the quartiles and IQR and quantitatively determine if there are any potential outliers across all four treatment regimens.

* Using Matplotlib, a box and whisker plot of the final tumor volume for all four treatment regimens and highlight any potential outliers in the plot by changing their color and style was generated.

* A mouse that was treated with Capomulin was selected and generate a line plot of tumor volume vs. time point for that mouse.

* A scatter plot of mouse weight versus average tumor volume for the Capomulin treatment regimen was generated.

* The correlation coefficient and linear regression model between mouse weight and average tumor volume for the Capomulin treatment were calculated. 

* The linear regression model on top of the previous scatter plot was ploted.

## **Output file**

`Pymaceuticals/pymaceuticals_starter.ipynb` - jupyter notebook file

## **Conclusions**

* In the experiment, the amount of male and female mice is close to 50/50%.
* Calculation of the number of data mesaruments(points) for each treatment regimen showed that for Capomulin and Ramicane more data were collected with respect to other drug regimens.
* The box plot of the final tumor volume of each mouse across four regimens (Capomulin, Ramicane, Infubinol, and Ceftamin), showed that results for Capomulin and Ramicane are very close to each other: both demonstrate the smallest tumor volume.


