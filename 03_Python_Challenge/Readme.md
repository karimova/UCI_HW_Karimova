# **Python Challenge**

Two directories were created: `PyBank` and  `PyPoll`.

* Each folder inside has the following:

  * **main.py** - it is the main script to run for data analysis.
  * **analysis** - it is a folder that contains the text file that has the results from your analysis.

## PyBank

budget_data.csv - a set of financial data. 

* The sctipt **main.py** analyzes the records to calculate each of the following:

  * The total number of months included in the dataset

  * The net total amount of `Profit/Losses` over the entire period

  * The average of the changes in `Profit/Losses` over the entire period

  * The greatest increase in profits (date and amount) over the entire period

  * The greatest decrease in losses (date and amount) over the entire period

Obtained results can be found below (printscreen of terminal):

<p align="left">
  <img width="200%" src="Images/pybank_terminal.png">
</p>




* In addition, the final script print the analysis to the terminal and export a text file with the results.

![Pybank_txt](Images/pybank_txt.png)

## PyPoll

![Vote Counting](Images/Vote_counting.png)

* In this challenge, you are tasked with helping a small, rural town modernize its vote counting process.

* You will be give a set of poll data called [election_data.csv](PyPoll/Resources/election_data.csv). The dataset is composed of three columns: `Voter ID`, `County`, and `Candidate`. Your task is to create a Python script that analyzes the votes and calculates each of the following:

  * The total number of votes cast

  * A complete list of candidates who received votes

  * The percentage of votes each candidate won

  * The total number of votes each candidate won

  * The winner of the election based on popular vote.

* As an example, your analysis should look similar to the one below:

  ```text
  Election Results
  -------------------------
  Total Votes: 3521001
  -------------------------
  Khan: 63.000% (2218231)
  Correy: 20.000% (704200)
  Li: 14.000% (492940)
  O'Tooley: 3.000% (105630)
  -------------------------
  Winner: Khan
  -------------------------
  ```

* In addition, your final script should both print the analysis to the terminal and export a text file with the results.

## Hints and Considerations

* Consider what we've learned so far. To date, we've learned how to import modules like `csv`; to read and write files in various formats; to store contents in variables, lists, and dictionaries; to iterate through basic data structures; and to debug along the way. Using what we've learned, try to break down your tasks into discrete mini-objectives. This will be a _much_ better course of action than spending all your time looking for a solution on Stack Overflow.

* As you will discover, for some of these challenges, the datasets are quite large. This was done purposefully, as it showcases one of the limits of Excel-based analysis. While our first instinct, as data analysts, is often to head straight into Excel, creating scripts in Python can provide us with more robust options for handling "big data".

* Write one script for each dataset provided. Run your script separately to make sure that the code works for its respective dataset.

* Feel encouraged to work in groups, but don't shortchange yourself by copying someone else's work. You get what you put in, and the art of programming is extremely unforgiving to moochers. Dig your heels in, burn the night oil, and learn this while you can! These are skills that will pay dividends in your future career.

* Start early, and reach out for help often! Challenge yourself to identify _specific_ questions for your instructors and TAs. Don't resign yourself to simply saying, "I'm totally lost." If you need help, reach out because we're happy to help. But, come prepared and show us what you have done and your thought process.

* Always commit your work and back it up with GitHub pushes. You don't want to lose hours of your work because you didn't push it to GitHub every half hour or so.

  * Ensure your repository has regular commits (i.e. 20+ commits) and a thorough README.md file

  

## Copyright

Trilogy Education Services © 2019. All Rights Reserved.