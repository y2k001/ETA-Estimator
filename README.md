# ETA-Estimator
Delivery ETA Estimator
The application has been developed using following data as reference and assumptions and works just to show delivery of orders.Data to be entered is case sensitive currently.<br>
Delivery is estimated based on region and stock available

The application comprises of two solutions front end ui in Angular and backend api built using Web API C#.
Initial UI, on running angular application
![alt text](image.png)


Add data to the fields in UI as per data stored in backend.<br>
The backend has data stored as:<br>
For products – <br>
ProductId = "P1001", Name = "Washing Machine", InStock = true <br>
ProductId = "P1002", Name = "Fridge", InStock = false <br>
ProductId = "P1003", Name = "Dishwasher", InStock = true <br>
ProductId = "P1004", Name = "Oven", InStock = false <br>
For products to be delivered in days as per region mentioned, data is as:<br>
North-> 2, here for North region, number of days to deliver is 2 <br>
 South-> 5,<br>
East -> 3,<br>
West-> 7<br>


On adding data in the text fields and submitting, we get as follows<br>
![alt text](image-3.png)
On refreshing the page we get page as 
![alt text](image-4.png)
Similarly, we can add data based on data above. 