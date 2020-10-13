# **Matplotlib - The Power of Plots**

In this study, 249 mice identified with SCC tumor growth were treated through a variety of drug regimens. 
Over the course of 45 days, tumor development was observed and measured. 
The purpose of this study was to compare the performance of Pymaceuticals' drug of interest, Capomulin, versus the other treatment regimens. 
You have been tasked by the executive team to generate all of the tables and figures needed for the technical report of the study. 
The executive team also has asked for a top-level summary of the study results.

In the beginning of the analysis, the data for any mouse ID was checked with duplicate time points. All duplicates were removed any data associated with that mouse ID.


## **Analisys Steps:**

The cleaned data were used for the remaining steps.

* A summary statistics table consisting of the mean, median, variance, standard deviation, and SEM of the tumor volume for each drug regimen was generated.


* A bar plot using both Pandas's DataFrame.plot() and Matplotlib's pyplot that shows  the number of total mice for each treatment regimen throughout the course of the study was generated.


* A pie plot using both Pandas's DataFrame.plot() and Matplotlib's pyplot that shows the distribution of female or male mice in the study was generated.

* The final tumor volume of each mouse across four of the most promising treatment regimens: Capomulin, Ramicane, Infubinol, and Ceftamin was calculated. 
  Calculate the quartiles and IQR and quantitatively determine if there are any potential outliers across all four treatment regimens.


Using Matplotlib, generate a box and whisker plot of the final tumor volume for all four treatment regimens and highlight any potential outliers in the plot by changing their color and style.
Hint: All four box plots should be within the same figure. Use this Matplotlib documentation page for help with changing the style of the outliers.


Select a mouse that was treated with Capomulin and generate a line plot of tumor volume vs. time point for that mouse.


Generate a scatter plot of mouse weight versus average tumor volume for the Capomulin treatment regimen.


Calculate the correlation coefficient and linear regression model between mouse weight and average tumor volume for the Capomulin treatment. Plot the linear regression model on top of the previous scatter plot.
