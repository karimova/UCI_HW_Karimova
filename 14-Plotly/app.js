// 1. Use the D3 library to read in samples.json.

function myPlots(sample) {

  d3.json("samples.json").then((importedData) => {
    console.log(importedData)
    var samples = importedData.samples;
    var resultArray = samples.filter(sampleObj => sampleObj.id == sample);
    var result = resultArray[0];  
    
    // 2. Bar CHart
    
    var otu_id = result.otu_ids.slice(0,10).reverse();
    var labels = result.otu_labels.slice(0,10);
    var x_data = result.sample_values.slice(0,10).reverse();
    var y_data = result.otu_ids.map(d => "OTU " + d);
    
    
    //var x_data = data.samples[0].sample_values.slice(0,10).reverse();
    //var otu_id = data.samples[0].otu_ids.slice(0,10).reverse();
    //var labels = data.samples[0].otu_labels.slice(0,10);
    //var y_data = otu_id.map(d => "OTU " + d);

    console.log(x_data);
    console.log(y_data);
    console.log(labels);


    //Trace 1
    var trace1 = {
        x: x_data,
        y: y_data,
        text: labels,
        type: "bar",
        orientation: "h"
    };

    //data
    var charData = [trace1];

    var layout = {
        title: "Top 10 OTU",
        margin: {
            l: 100,
            r: 100,
            t: 100,
            b: 100
        }
    };


    //Render the plot

    Plotly.newPlot("bar", charData, layout)

    
    
    // 3. Bubble Chart
    // Reading full data
    var y_data = result.sample_values;
    var otu_id = result.otu_ids;
    var labels = result.otu_labels;

    //var y_data = data.samples[0].sample_values;
   // var otu_id = data.samples[0].otu_ids;
   // var labels = data.samples[0].otu_labels;
    //var x_data = otu_id.map(d => "OTU " + d);

    var trace2 = {
        x: otu_id,
        y: y_data,
        text: labels,
        mode: 'markers',
        marker: {
          size: y_data,
          color: otu_id
        }
      };
      
      var data2 = [trace2];
      
      var layout2 = {
        title: 'Bubble Chart',
        showlegend: false,
      };
      
      Plotly.newPlot('bubble', data2, layout2);
  });  
};



// Demografic Information
function demoInfo(sample) {
  // read the json file to get data
  d3.json("samples.json").then((data)=> {
  // get the metadata info for the demographic panel
    var metadata = data.metadata;
      console.log(metadata)
  // filter meta data info by id
    var resultArray = metadata.filter(sampleObj => sampleObj.id == sample);
    var result = resultArray[0];
  // select demographic panel to put data
    var table = d3.select("#sample-metadata");
          
  // empty the demographic info panel each time before getting new id info
    table.html("");
  
  // grab the necessary demographic data data for the id and append the info to the panel
    Object.entries(result).forEach((key) => {   
    table.append("h5").text(key[0].toUpperCase() + ": " + key[1] + "\n");    
    });
  });
}


    // 4. Sample Selection
    ////-------------------------------
function init() {
   var sample_selection = d3.select("#selDataset");

  d3.json("samples.json").then((importedData) => {
    //console.log(importedData)
    //var data = importedData.names;

    importedData.names.forEach((sample) => {
      sample_selection.append("option").text(sample).property("value", sample);
    });
    
    // Use the First Sample from the List to Build Initial Plots
    //var firstSample = importedData.names[0];
    myPlots(importedData.names[0]);
    demoInfo(importedData.names[0]);
  });
};
      
      
   
// 4.1. Dropdown SElection Button && get the id data to the dropdwown menu
function optionChanged(newID) {
  myPlots(newID);
  demoInfo(newID);
};

// Initialize the Dashboard
init();

myPlots(940)
demoInfo(940)