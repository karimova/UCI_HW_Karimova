# **Excel Analysis of projects on Kickstarter**

Over $2 billion has been raised using the massively successful crowdfunding service, Kickstarter, but not every project has found success. Of the more than 300,000 projects launched on Kickstarter, only a third have made it through the funding process with a positive outcome.
In this project, the Kickstarter database (4,000 past projects) was analyzed.  Obtained results, allowed to uncover some hidden market trends, and help to determine the main features required to run the successful projects.

## **Input Data**

Calculations and analysis were performed using Microsoft Excel (Office 365) program (Microsoft Excel, https://office.microsoft.com/excel).

All data can be found in the Excel file: **01-Excel_Challenge.xlsx**  
This workbook has 6 sheets:  
* Table  
* PivotTable_1  
* PivotTable_2  
* PivotTable_3  
* Bonus  
* Bonus_Stat

The Kickstarter database can be found in the Table sheet. It contains following data:  
* `name` – the name of the project  
* `blurb` – brief description of the project  
* `goal` – required amount of money  
* `pledged` – obtained amount of money  
* `state` – the associated campaign was successful, failed, canceled, or live  
* `country` – country (US, GB, AU etc.)  
* `currency` – the world currencies by countries  
* `deadline` – date when project was ended (in Unix timestamps)  
* `launched_at` – date when project was started (in Unix timestamps)  
* `backers_count` – the total amount of backers donated for the project  
* `Category and Sub-Category` – type of industry project belong (for example, food, music, games etc.)


## **Calculations and Formulas:**
 
Essential calculations and formatting were performed in the Table spreadsheet.

(1) Conditional formatting was used to fill each cell in the state column with a different color, depending on whether the associated campaign: successful (green), failed (red), canceled (yellow), or live (blue).

(2) A new `Percent Funded` (column O) was created. These data are used to uncover how much money a campaign made to reach its initial goal. Formula is:

`Percent Funded` = (`pledged` ∙ 100) / goal                                                                       **(1)**

(3) Then, conditional formatting was used to fill each cell in the `Percent Funded` column using a three-color scale. The scale starts at 0 and became a dark shade of red, transitioning to green at 100, and blue at 200.

(4) A new column called `Average Donation` (column P) was created. These data are used to show how much each backer for the project paid on average. Formula is:

`Average Donation` =  `pledged` / `backers_count`                                                                  (2)

(5) The `Category and Sub-Category` (column N) was split into two parts: (i) `Category` (column Q), and (ii) `Sub-Category` (column R).   
Excel’s functions LEFT and RIGTH were used to do it. Example of used formulas for row #2 is presented below:

`Category` = LEFT(N2,FIND("\"/"\",N2)-1)                                                                           (3)

`Sub-Category` = RIGHT(N2,LEN(N2)-FIND("\"/"\",N2))                                                                (4)

(6) To determine the dates when project was started and ended, the `deadline` and `launched_at columns` (with dates in Unix timestamps format) were converted it into an into Excel's date format using formulas:

`Date Created Conversion` = (((`launched_at`/60)/60)/24)+DATE(1970,1,1)                                            (5)

`Date Ended Conversion` = (((`deadline`/60)/60)/24)+DATE(1970,1,1)                                                 (6)

Two new columns `Date Created Conversio` (column S) and `Date Ended Conversion` (column T) were created.


## **Data analysis**

### **PivotTable_1**

A new sheet with a pivot table (**PivotTable_1**) was created to analyze initial worksheet and count how many campaigns were successful, failed, canceled, or live per Category (**Fig.1, PivotTable_1**). Additionally, a stacked column pivot chart that can be filtered by `country` have been produced (**Fig.2, PivotTable_1**).

<p align="center">
  <img width="50%" src="Images/Fig_1.png">
</p>
<p align="center">
 <em><b>Figure 1.</b> Pivot table: Filter = country; Rows = Category; Columns = state; Values = Count of pledged.</em>
</p>
  
<p align="center">
  <img width="80%" src="Images/Fig_2.png">
</p>
<p align="center">
 <em><b>Figure 2.</b> A stacked column pivot chart that can be filtered by country based on the table in PivotTable_1.</em>
</p>  

### **PivotTable_2**

A new sheet with a pivot table (**PivotTable_2**) that will analyze the initial sheet to count how many campaigns were successful, failed, canceled, or live per Sub-Category (**Fig.3**). Additionally, a stacked column pivot chart that can be filtered by country based on the table have been produced (**Fig. 4, PivotTable_2**).
 
 <p align="center">
  <img width="50%" src="Images/Fig_3.png">
</p>
<p align="center">
 <em><b>Figure 3.</b> Pivot table: Filter = country and Category; Rows = Sub-Category; Columns = state; Values = Count of pledged.</em>
</p>
  
<p align="center">
  <img width="100%" src="Images/Fig_4.png">
</p>
<p align="center">
 <em><b>Figure 4.</b> A stacked column pivot chart that can be filtered by country and Category based on the table in PivotTable_2.</em>
</p>  

### **PivotTable_3**

A new sheet with a pivot table (**PivotTable_3**) was created with a column of state, rows of Date Created Conversion, values based on the count of state, and filters based on Category and Years (**Fig.5**). Also, a pivot chart line graph that visualizes this new table is presented on **Fig.6** (**PivotTable_3**). 

 <p align="center">
  <img width="50%" src="Images/Fig_5.png">
</p>
<p align="center">
 <em><b>Figure 5.</b> Pivot table: Filter = Category and Years; Rows = Date Created Conversion; Columns = state; Values = Count of state.</em>
</p>
  
<p align="center">
  <img width="50%" src="Images/Fig_6.png">
</p>
<p align="center">
 <em><b>Figure 6.</b> Visualization of PivotTable_3.</em>
</p>  

## **Conclutions**

## **Bonus**

A new sheet (**Bonus**) was created. In this part I have calculated: (i) the amount of successful, failed, canceled, or live projects with respect to the goal within the ranges (**Fig.7, Bonus**); (ii) calculated the total number of projects per goal category; and (iii) determined the percentage of successful, failed, canceled, or live projects with respect to the goal (**Fig.7**).

To count how many successful, failed, and canceled projects were created with goals within the ranges the following function Using the `COUNTIFS()` were applied (example of formulas for successful projects):

`Number Successful` = COUNTIFS(Table!$D:$D,"<1000",Table!$F:$F,"successful")                                         (7)

`Total Projects` = (`Number Successful` + `Number Failed` + `Number Canceled`)                                       (8)

`Percentage Successful` =  (`Number Successful`)/(`Total Projects`) %                                                (9)


<p align="center">
  <img width="50%" src="Images/Fig_7.png">
</p>
<p align="center">
 <em><b>Figure 7.</b> Number and percentage of successful, failed, canceled, or live projects with respect to the type of goal.</em>
</p>
  
<p align="center">
  <img width="50%" src="Images/Fig_8.png">
</p>
<p align="center">
 <em><b>Figure 8.</b> The relationship between a goal's amount and its chances at success, failure, or cancellation.</em>
</p> 






