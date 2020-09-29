import os
import csv

#Part I: Analysis

#Input file location
csv_path = "Resources/budget_data.csv"

#output file location
output_path = "analysis/output.txt"

#open csv file
with open(csv_path, "r") as csvfile:

    #reading the csvfile
    csv_reader = csv.reader(csvfile, delimiter = ",")
    
    #removing the header row
    csv_header = next(csv_reader)

    #reading the rest file
    count = 0
    total_profit = 0
    total_months = 0
    profit_loss = []
    date = []

    for row in csv_reader:

        #number of rows in the table withou the header
        count = count+1

        #Sum a csv column "Profit/Losses"
        total_profit += int(row[1])

        #Created the list of Date column
        date.append(row[0])

        #created the list of Profit column
        profit_loss.append(row[1])

    #Total number of months
    total_months = count

    #Changes Profit(time+1) - Profit(time)
    change_profit = []
    for i in range(count-1):
        change = int(profit_loss[i+1]) - int(profit_loss[i])
        change_profit.append(change)
        #print(change)
    #print(change_profit)

    #Average Change:
    avg_change = sum(change_profit) / len(change_profit)
    
    #Greates Increas in Profit and Greates Decrease in Profit
    max_change = max(change_profit)
    min_change = min(change_profit)

    #index of max and min value. I will use it to find related Date
    max_index = (change_profit.index(max_change))
    min_index = (change_profit.index(min_change))
    #print(date[max_index+1])
    #print(date[min_index+1])

    #print(f"Count = {count}") #number of rows in the table withou the header

    print("-----------------------------")
    print("     Financial Analysis      ")
    print("-----------------------------")
    
    #Total number of months
    print(f"Total Months: {total_months}")

    #Total Profit/Loses
    print(f"Total Profit/Losses: {total_profit}")

    #Average Change (two decimol after period):
    print(f"Avereage Change: ${format(avg_change,'.2f')}")

    #Greates Changes in Profit 
    print(f"Greates Increase in Profit: {date[max_index+1]} (${max_change})")
    print(f"Greates Decrease in Profit: {date[min_index+1]} (${min_change})")

csvfile.close()

#------------------------------------------------
#Part II: Writing obtained results to a .txt file
#------------------------------------------------

#output file is open to write
with open(output_path,"w+") as output_file:
    output_file.write("-----------------------------\n")
    output_file.write("     Financial Analysis      \n")
    output_file.write("-----------------------------\n")
    output_file.write(f"Total Months: {total_months} \n")
    output_file.write(f"Total Profit/Losses: {total_profit} \n")
    output_file.write(f"Avereage Change: ${format(avg_change,'.2f')} \n")
    output_file.write(f"Greates Increase in Profit: {date[max_index+1]} (${max_change}) \n")
    output_file.write(f"Greates Decrease in Profit: {date[min_index+1]} (${min_change}) \n")

output_file.close()





        


