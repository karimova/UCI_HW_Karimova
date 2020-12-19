// from data.js
var tableData = data;

// YOUR CODE HERE!

// Section-1
// Get a reference to the table body
var tbody = d3.select("tbody");

// Console.log the ufo data from data.js
//console.log(tableData);

 // Use d3 to update each cell's text with
// // ufo report values 
function showTable(tableData){
    tbody.text("")
    tableData.forEach(function(ufoReport) {
        //console.log(ufoReport);
        var row = tbody.append("tr");
        Object.entries(ufoReport).forEach(function([key, value]) {
        var cell = row.append("td");
        cell.text(value);
        })
    })
}

showTable(tableData)

// Section-2 
// filtering data with respect to the date that the we input

// A reference to the button on the page 
var myDate = d3.select("#datetime")
var button = d3.select("#filter-btn");

function buttomClick(){
    //don't refresh the page!
    d3.event.preventDefault();
    //print input value
    console.log(myDate.property("value"));
    //create a new table with filterd information only
    var new_table = tableData.filter(ufoReport => ufoReport.datetime===myDate.property("value"))
    //display the new table
    showTable(new_table);
}

// changes and click
myDate.on("change", buttomClick)


