# Import Flask
from flask import Flask, jsonify

# Dependencies and Setup
import numpy as np
import datetime as dt

# Python SQL Toolkit and Object Relational Mapper
import sqlalchemy
from sqlalchemy.ext.automap import automap_base
from sqlalchemy.orm import Session
from sqlalchemy import create_engine, func
from sqlalchemy.pool import StaticPool



engine = create_engine("sqlite:///Resources/hawaii.sqlite", connect_args={"check_same_thread": False}, poolclass=StaticPool, echo=True)

# Reflect Existing Database Into a New Model
Base = automap_base()

# Reflect the Tables
Base.prepare(engine, reflect=True)

# Save References to Each Table
Measurement = Base.classes.measurement
Station = Base.classes.station

# Create Session (Link) From Python to the DB
session = Session(engine)


# Flask 
app = Flask(__name__)

# Welcome Page
@app.route("/")
def welcome():
    print("Server recieved request for 'Home' page")
    return (
        f"Welcome to Climate App!:<br>"
        f"Available Routes:<br>"
        f"/api/v1.0/precipitation<br>"
        f"/api/v1.0/stations<br>"
        f"/api/v1.0/tobs<br/>"
        f"/api/v1.0/YYYY-MM-DD<br>"
        f"/api/v1.0/start=YYYY-MM-DD/end=YYYY-MM-DD<br>"
    )

#Precipitation
@app.route("/api/v1.0/precipitation")
def precipitation():
        # Convert the Query Results to a Dictionary 
        # Calculate the Date 1 Year Ago 
        year_ago_date = dt.date(2017,8,23) - dt.timedelta(days=365)
        # Design a Query to Retrieve the Last 12 Months of Precipitation Data 
        precipitation_last_year = (session.query(Measurement.date, Measurement.prcp).
            filter(Measurement.date >= year_ago_date).
            order_by(Measurement.date)).all()
        # Return JSON Representation of Dictionary
        return jsonify(precipitation_last_year)

# Stations 
@app.route("/api/v1.0/stations")
def stations():
        stations_list = session.query(Station.station, Station.name).all()
        # Return JSON List of Stations from the Dataset
        return jsonify(stations_list)

# Tobs 
@app.route("/api/v1.0/tobs")
def tobs():
        # Query for the Dates and Temperature Observations from a Year from the Last Data Point
        year_ago_date = dt.date(2017,8,23) - dt.timedelta(days=365)
        # Design a Query to Retrieve the Last 12 Months of Precipitation Data 
        tobs_data = session.query(Measurement.date, Measurement.tobs).\
                filter(Measurement.date >= year_ago_date).\
                order_by(Measurement.date).all()
        # Return JSON List of Temperature Observations (tobs) for the Previous Year
        return jsonify(tobs_data)

# Start Day Route
@app.route("/api/v1.0/<start>")
def start_day(start):
        start_day = session.query(Measurement.date, func.min(Measurement.tobs), func.avg(Measurement.tobs), func.max(Measurement.tobs)).\
                filter(Measurement.date >= start).\
                group_by(Measurement.date).all()
        # Return JSON List of Min Temp, Avg Temp and Max Temp for a Given Start Range
        return jsonify(start_day)

# Start-End Day Route
@app.route("/api/v1.0/<start>/<end>")
def start_end_day(start, end):
        start_end_day = session.query(Measurement.date, func.min(Measurement.tobs), func.avg(Measurement.tobs), func.max(Measurement.tobs)).\
                filter(Measurement.date >= start).\
                filter(Measurement.date <= end).\
                group_by(Measurement.date).all()
        # Return JSON List of Min Temp, Avg Temp and Max Temp for a Given Start-End Range
        return jsonify(start_end_day)


if __name__ == "__main__":
    app.run(debug = True)