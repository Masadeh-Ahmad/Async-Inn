# Async-Inn

## Ahmad Masadeh

## 4/16/2022

# Introduction
This web App about Hotal management system we can add Hotals by there ID, name, city, state, Address and phone Number 

you can add rooms by there ID and name, and add amenities by there ID and name

and you can retrieve data of hotels ,rooms and amenities and updata on it

## 4/20/2022

#  Dependency Injection & Repository Design Pattern

We add  Dependency Injection & Repository Design Pattern to our project so now we have a spareted services Classes now the controllers have a less functionality to do.

Now you do this:
- GET(api/Hotels) To get all data for hotels
- GET(api/Hotels/"id") To get the data for a specific hotel 
- POST(api/Hotels) to add a hotel to the database
- PUT(api/Hotels/"id") to modify the data for a specific hotel
- DELETE((api/Hotels/"id")) to delete  all data for a specific hotel



# ERD 
![ERD](./ERD.png)

Hotel: the hotel has an ID, name, city, state, Address and phone Number 

HotelRoom: it has tow FK one for hotel ID and one for Room ID, along with other properties such as Rate and RoomNum. 

Room: so this room has a unique ID and other properites such as name and layout.

Amenities: it has an ID and a name. 

RoomAmenities: It has FK; because this table is responsible of connecting both of Room and Amenities



