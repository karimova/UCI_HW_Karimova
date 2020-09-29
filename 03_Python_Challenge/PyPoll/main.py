import os
import csv

#Input file location
csvpath = "Resources/election_data.csv"

#output file location
output_path = "analysis/output.txt"

#reading data from the file
with open(csvpath, encoding="ISO-8859-1") as csvfile:
    #print(csvfile)
    #reading the csvfile
    csv_reader = csv.reader(csvfile, delimiter = ",")

    #removing the Header from the considered Table
    csv_header = next(csv_reader)

    count = 0
    candidate = [] #column "Candiadtes"
    for row in csv_reader:
        count = count + 1
        candidate.append(str(row[2]))

csvfile.close()

#A complete list of candidates who received votes
list_candidates = [] #list of candidates who recieved votes

for i in candidate:
    if i in list_candidates:
        pass
    else:
        list_candidates.append(i)
           
#print(list_candidates)

#The total number of votes each candidate won &
#The percentage of votes each candidate won

num_votes = []
percentage_votes = []

for j in list_candidates:
    count_2 = 0 #number of votes per candudate.
    for k in candidate:
        if k == j:
            count_2 = count_2 + 1 #number of votes per candudate.
 
    num_votes.append(count_2) #number of votes per candudate. Append to the list

    #The percentage of votes each candidate won
    percent = round((count_2 / count) * 100,0)
    percentage_votes.append(format(percent,".3f")) #The percentage of votes each candidate won

#print(num_votes)
#print(percentage_votes)

#The winner of the election based on popular vote.
max_votes = max(num_votes) #Max number of votes in the list "num_votes"
win_index = num_votes.index(max_votes) #to find the
winner = list_candidates[win_index] #Winner

#-----------------------------------    
#OUPTUT    
#-----------------------------------    
print(" ")
print("Election Rusults")
print("-----------------------------")
print(f"Total Votes: {count}")
print("-----------------------------")
for x in range(len(list_candidates)):
    print(f"{list_candidates[x]}: {percentage_votes[x]}% ({num_votes[x]}) ")
print("-----------------------------")
print(f"Winner: {winner}")
print("-----------------------------")

#------------------------------------------------
#Part II: Writing obtained results to a .txt file
#------------------------------------------------

#output file is open to write
with open(output_path,"w+") as output_file:
    output_file.write("Election Results\n")
    output_file.write("-----------------------------\n")
    output_file.write(f"Total Votes: {count}\n")
    output_file.write("-----------------------------\n")
    for x in range(len(list_candidates)):
        output_file.write(f"{list_candidates[x]}: {percentage_votes[x]}% ({num_votes[x]}) \n")
    output_file.write("-----------------------------\n")
    output_file.write(f"Winner: {winner} \n")
    output_file.write("-----------------------------\n")
output_file.close()



    