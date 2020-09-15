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
* `state` – the associated campaign was successful, failed, canceled, or is live  
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

`Percent Funded` = (`pledged` ∙ 100) / goal

(3) Then, conditional formatting was used to fill each cell in the `Percent Funded` column using a three-color scale. The scale starts at 0 and became a dark shade of red, transitioning to green at 100, and blue at 200.

(4) A new column called `Average Donation` (column P) was created. These data are used to show how much each backer for the project paid on average. Formula is:

`Average Donation` =  `pledged` / `backers_count`

The Category and Sub-Category column N was split into two parts: (i) Category (column Q), and (ii) Sub-Category (column R). Excel’s functions LEFT and RIGTH were used to do it. Example of used formulas for row #2 is presented below:
Category=LEFT(N2,FIND("\"/\"",N2)-1)
Sub-Category=RIGHT(N2,LEN(N2)-FIND("\"/\",N2))" 
	To determine the dates when project was started and ended, the deadline and launched_at columns (with dates in Unix timestamps format) were converted it into an into Excel's date format using formulas:
Date Created Conversion=(((launched_at/60)/60)/24)+DATE(1970,1,1)
Date Ended Conversion=(((deadline/60)/60)/24)+DATE(1970,1,1)
Two new columns Date Created Conversion (column S) and Date Ended Conversion (column T) were created.

## **References:**
(1) [Microsoft Excel] (https://office.microsoft.com/excel)

