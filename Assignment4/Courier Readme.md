# Task 1:
```sql
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Name VARCHAR(255),
    Email VARCHAR(255) UNIQUE,
    Password VARCHAR(255),
    ContactNumber VARCHAR(20),
    Address TEXT
)

CREATE TABLE Couriers (
    CourierID INT PRIMARY KEY,
    SenderName VARCHAR(255),
    SenderAddress TEXT,
    ReceiverName VARCHAR(255),
    ReceiverAddress TEXT,
    Weight DECIMAL(5, 2),
    Status VARCHAR(50),
    TrackingNumber VARCHAR(20) UNIQUE,
    DeliveryDate DATE
)

CREATE TABLE CourierServices (
    ServiceID INT PRIMARY KEY,
    ServiceName VARCHAR(100),
    Cost DECIMAL(8, 2)
)

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    Name VARCHAR(255),
    Email VARCHAR(255) UNIQUE,
    ContactNumber VARCHAR(20),
    Role VARCHAR(50),
    Salary DECIMAL(10, 2)
)

CREATE TABLE Locations (
    LocationID INT PRIMARY KEY,
    LocationName VARCHAR(100),
    Address TEXT
)

CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY,
    CourierID INT,
    LocationID INT,
    Amount DECIMAL(10, 2),
    PaymentDate DATE,
    FOREIGN KEY (CourierID) REFERENCES Couriers(CourierID),
    FOREIGN KEY (LocationID) REFERENCES Locations(LocationID)
)

INSERT INTO Users VALUES 
(1, 'Naveen Kumar', 'naveen.kumar@example.com', 'naveen123', '9876543210', '12 MG Road, Bengaluru'),
(2, 'Sanjay Sharma', 'sanjay.sharma@example.com', 'sanjay123', '8765432109', '34 Park Street, Delhi'),
(3, 'Kartick Das', 'kartick.das@example.com', 'kartick123', '7654321098', '56 Prince Anwar Shah Rd, Kolkata'),
(4, 'Priya Singh', 'priya.singh@example.com', 'priya123', '6543210987', '78 Anna Nagar, Chennai'),
(5, 'Rahul Verma', 'rahul.verma@example.com', 'rahul123', '9123456780', '90 Baner Road, Pune'),
(6, 'Anjali Mehta', 'anjali.mehta@example.com', 'anjali123', '9988776655', '45 Jubilee Hills, Hyderabad'),
(7, 'Amit Patel', 'amit.patel@example.com', 'amit123', '8877665544', '67 Satellite Road, Ahmedabad'),
(8, 'Sneha Reddy', 'sneha.reddy@example.com', 'sneha123', '7766554433', '89 Banjara Hills, Hyderabad'),
(9, 'Vikram Iyer', 'vikram.iyer@example.com', 'vikram123', '6655443322', '21 T Nagar, Chennai'),
(10, 'Neha Kapoor', 'neha.kapoor@example.com', 'neha123', '5544332211', '33 Andheri East, Mumbai')


INSERT INTO Couriers VALUES 
(101, 'Naveen Kumar', '12 MG Road, Bengaluru', 'Amit Patel', '67 Satellite Road, Ahmedabad', 5.50, 'In Transit', 'TRK1001', '2025-03-25'),
(102, 'Sanjay Sharma', '34 Park Street, Delhi', 'Sneha Reddy', '89 Banjara Hills, Hyderabad', 2.75, 'Delivered', 'TRK1002', '2025-03-24'),
(103, 'Kartick Das', '56 Prince Anwar Shah Rd, Kolkata', 'Priya Singh', '78 Anna Nagar, Chennai', 4.00, 'In Transit', 'TRK1003', '2025-03-26'),
(104, 'Priya Singh', '78 Anna Nagar, Chennai', 'Rahul Verma', '90 Baner Road, Pune', 3.25, 'Pending', 'TRK1004', '2025-03-27'),
(105, 'Rahul Verma', '90 Baner Road, Pune', 'Vikram Iyer', '21 T Nagar, Chennai', 6.00, 'Delivered', 'TRK1005', '2025-03-24'),
(106, 'Anjali Mehta', '45 Jubilee Hills, Hyderabad', 'Neha Kapoor', '33 Andheri East, Mumbai', 7.25, 'In Transit', 'TRK1006', '2025-03-28'),
(107, 'Amit Patel', '67 Satellite Road, Ahmedabad', 'Anjali Mehta', '45 Jubilee Hills, Hyderabad', 5.75, 'Pending', 'TRK1007', '2025-03-29'),
(108, 'Sneha Reddy', '89 Banjara Hills, Hyderabad', 'Sanjay Sharma', '34 Park Street, Delhi', 2.50, 'Delivered', 'TRK1008', '2025-03-24'),
(109, 'Vikram Iyer', '21 T Nagar, Chennai', 'Kartick Das', '56 Prince Anwar Shah Rd, Kolkata', 3.90, 'In Transit', 'TRK1009', '2025-03-25'),
(110, 'Neha Kapoor', '33 Andheri East, Mumbai', 'Naveen Kumar', '12 MG Road, Bengaluru', 4.50, 'Pending', 'TRK1010', '2025-03-26')


INSERT INTO CourierServices VALUES 
(1, 'Express Delivery', 120.00),
(2, 'Standard Delivery', 60.00),
(3, 'Overnight Delivery', 150.00),
(4, 'Same Day Delivery', 200.00),
(5, 'Next Day Delivery', 100.00),
(6, 'International Shipping', 500.00),
(7, 'Heavy Parcel', 250.00),
(8, 'Light Parcel', 40.00),
(9, 'Fragile Goods', 180.00),
(10, 'Eco Delivery', 70.00)


INSERT INTO Employees VALUES 
(201, 'Ravi Kumar', 'ravi.kumar@example.com', '9988776655', 'Manager', 55000),
(202, 'Suman Das', 'suman.das@example.com', '8877665544', 'Delivery Executive', 25000),
(203, 'Deepak Joshi', 'deepak.joshi@example.com', '7766554433', 'Delivery Executive', 27000),
(204, 'Anita Sharma', 'anita.sharma@example.com', '6655443322', 'Receptionist', 22000),
(205, 'Rajeev Nair', 'rajeev.nair@example.com', '5544332211', 'Manager', 60000),
(206, 'Sunita Menon', 'sunita.menon@example.com', '4433221100', 'HR', 30000),
(207, 'Arjun Mehra', 'arjun.mehra@example.com', '3322110099', 'Delivery Executive', 26000),
(208, 'Pooja Reddy', 'pooja.reddy@example.com', '2211009988', 'Receptionist', 21000),
(209, 'Vinod Chauhan', 'vinod.chauhan@example.com', '1100998877', 'Delivery Executive', 28000),
(210, 'Meena Pillai', 'meena.pillai@example.com', '9998887776', 'Manager', 58000)


INSERT INTO Locations VALUES 
(301, 'Warehouse Bengaluru', '12 MG Road, Bengaluru'),
(302, 'Warehouse Delhi', '34 Park Street, Delhi'),
(303, 'Warehouse Kolkata', '56 Prince Anwar Shah Rd, Kolkata'),
(304, 'Warehouse Chennai', '78 Anna Nagar, Chennai'),
(305, 'Warehouse Pune', '90 Baner Road, Pune'),
(306, 'Warehouse Hyderabad', '45 Jubilee Hills, Hyderabad'),
(307, 'Warehouse Ahmedabad', '67 Satellite Road, Ahmedabad'),
(308, 'Warehouse Mumbai', '33 Andheri East, Mumbai'),
(309, 'Warehouse Jaipur', '23 MI Road, Jaipur'),
(310, 'Warehouse Lucknow', '65 Gomti Nagar, Lucknow')

INSERT INTO Payments VALUES 
(401, 101, 301, 120.00, '2025-03-22'),
(402, 102, 302, 60.00, '2025-03-23'),
(403, 103, 303, 150.00, '2025-03-24'),
(404, 104, 304, 200.00, '2025-03-25'),
(405, 105, 305, 100.00, '2025-03-24'),
(406, 106, 306, 500.00, '2025-03-25'),
(407, 107, 307, 250.00, '2025-03-26'),
(408, 108, 308, 40.00, '2025-03-23'),
(409, 109, 309, 180.00, '2025-03-24'),
(410, 110, 310, 70.00, '2025-03-26')
```
# Task 2: Select,Where 
Solve the following queries in the Schema that you have created above  
1. List all customers:  
```sql
SELECT * FROM Users

```
![{76CA0A10-BFDD-4F1B-AFD9-D51A2F7552A7}](https://github.com/user-attachments/assets/45906022-3072-4a5b-9171-0bd0a8af0293)


2. List all orders for a specific customer:  
```sql
SELECT * 
FROM Couriers 
WHERE SenderName = 'Naveen Kumar'
```
![{9E505837-C897-4E60-881A-8FC9BA3D5177}](https://github.com/user-attachments/assets/e1c0618b-44e9-44c3-85d1-99fb25be4d3f)


3. List all couriers:  
```sql

SELECT * FROM Couriers

```
![{B2EEB475-2FAD-46E6-99F1-BF476E588CEF}](https://github.com/user-attachments/assets/5fc622fa-4aa2-4f39-96ee-031f0e9713b5)

4. List all packages for a specific order:  
```sql
SELECT * 
FROM Couriers 
WHERE CourierID = 101

```
![{E352D3C9-61FA-442D-83F6-6BADE6F8CA33}](https://github.com/user-attachments/assets/e3b97a0d-8d70-4f6c-b766-1a39bff4b210)

5. List all deliveries for a specific courier:  
```sql

SELECT * 
FROM Couriers 
WHERE TrackingNumber = 'TRK1001'

```
![{95335879-F1EF-45C1-B7E0-A64A0871C259}](https://github.com/user-attachments/assets/e2c8ae36-6955-442f-9f11-6fd696e5defc)

6. List all undelivered packages:  
```sql

SELECT * 
FROM Couriers 
WHERE Status != 'Delivered'
```
![{85E02D08-B019-420F-95CC-B36A0922DCF7}](https://github.com/user-attachments/assets/f5198aa7-cb66-4eb5-a7d6-f9a13a526ee9)

7. List all packages that are scheduled for delivery today:  
```sql
SELECT * FROM Couriers 
WHERE DeliveryDate = '2025-03-24'

```
![{2200814F-9DF5-4B23-8857-8AA7216EBF0A}](https://github.com/user-attachments/assets/a4374280-162a-47af-8108-9157488356de)

8. List all packages with a specific status:  
```sql
SELECT * 
FROM Couriers 
WHERE Status = 'In Transit'

```
![{D52F1556-9293-430F-9273-C3E7EE137651}](https://github.com/user-attachments/assets/c73c3990-a947-4df2-a4f9-5bb8d9a56b8e)

9. Calculate the total number of packages for each courier.  
```sql
SELECT SenderName, COUNT(*) AS TotalPackages
FROM Couriers
GROUP BY SenderName

```
![{D4AA6C25-AF04-44AA-911D-FC441C353216}](https://github.com/user-attachments/assets/597ba8b9-0ec9-4071-af29-403d5a43e03d)

10. Find the average delivery time for each courier  
```sql
SELECT SenderName, AVG(Weight) AS AverageWeight
FROM Couriers
GROUP BY SenderName

```
![{A1BEB497-DECB-41DA-BAFA-A8D3AD6E55AF}](https://github.com/user-attachments/assets/d6d47dd3-54d4-4c98-b1ea-f80675fe6fde)

11. List all packages with a specific weight range:  
```sql
SELECT * 
FROM Couriers 
WHERE Weight BETWEEN 3 AND 6

```
![{44650B7F-0C08-4B79-AB59-1985817DC385}](https://github.com/user-attachments/assets/47ac165d-9d26-4374-8021-203d60aba75d)

12. Retrieve employees whose names contain 'John'  
```sql

SELECT * 
FROM Employees 
WHERE Name LIKE '%Kumar%'

```
![{9763FB79-702B-44C5-970A-618CA66E428E}](https://github.com/user-attachments/assets/4afeb624-3698-4d5a-99bf-011d277be3b0)

13. Retrieve all courier records with payments greater than $50.
```sql
SELECT Couriers.*
FROM Couriers
INNER JOIN Payments ON Couriers.CourierID = Payments.CourierID
WHERE Payments.Amount > 50

```
![{D9AFD8DC-5AD7-48F1-9575-B4783582DD62}](https://github.com/user-attachments/assets/739b9c61-2303-49ff-90a6-0860a5a3a882)

# Task 3: GroupBy, Aggregate Functions, Having, Order By, where  
14. Find the total number of couriers handled by each employee.  
```sql


```



15. Calculate the total revenue generated by each location  
```sql
SELECT l.LocationID, l.LocationName, SUM(p.Amount) AS TotalRevenue
FROM Locations l
LEFT JOIN Payments p ON l.LocationID = p.LocationID
GROUP BY l.LocationID, l.LocationName
ORDER BY TotalRevenue DESC

```
![{4FA64B18-7C35-40E7-9C1E-DAF16035AC13}](https://github.com/user-attachments/assets/6e915f2d-78da-463f-befc-2002b25d9ade)

16. Find the total number of couriers delivered to each location.  
```sql


```

17. Find the courier with the highest average delivery time:  
```sql


```

18. Find Locations with Total Payments Less Than a Certain Amount  
```sql


```

19. Calculate Total Payments per Location  
```sql
SELECT l.LocationID, l.LocationName, SUM(p.Amount) AS TotalPayments
FROM Locations l
LEFT JOIN Payments p ON l.LocationID = p.LocationID
GROUP BY l.LocationID, l.LocationName
ORDER BY TotalPayments DESC

```
![{9B1DEE94-2518-4C7D-B33E-24128635151F}](https://github.com/user-attachments/assets/38d6ed5b-3ac6-4dca-95e8-2dedbe146d95)

20. Retrieve couriers who have received payments totaling more than $1000 in a specific location 
(LocationID = X):  
```sql


```

21. Retrieve couriers who have received payments totaling more than $1000 after a certain date 
(PaymentDate > 'YYYY-MM-DD'):  
```sql


```

22. Retrieve locations where the total amount received is more than $5000 before a certain date 
(PaymentDate > 'YYYY-MM-DD')
```sql


```

# Task 4: Inner Join,Full Outer Join, Cross Join, Left Outer Join,Right Outer Join  
23. Retrieve Payments with Courier Information  
```sql
SELECT p.PaymentID, p.Amount, p.PaymentDate, c.CourierID, c.TrackingNumber, c.Status
FROM Payments p
INNER JOIN Couriers c ON p.CourierID = c.CourierID


```

![image](https://github.com/user-attachments/assets/83524e38-f173-4ce8-ac31-04118f381130)

24. Retrieve Payments with Location Information  
```sql
SELECT p.PaymentID, p.Amount, p.PaymentDate, l.LocationID, l.LocationName, l.Address
FROM Payments p
INNER JOIN Locations l ON p.LocationID = l.LocationID


```

![{4735526A-0868-4E9C-9BDA-5FBC9FCEE123}](https://github.com/user-attachments/assets/194d97ef-0a0e-491a-9fe2-1ad3f30e47dc)

25. Retrieve Payments with Courier and Location Information  
```sql

SELECT p.PaymentID, p.Amount, p.PaymentDate, c.CourierID, c.TrackingNumber, l.LocationID, l.LocationName
FROM Payments p
INNER JOIN Couriers c ON p.CourierID = c.CourierID
INNER JOIN Locations l ON p.LocationID = l.LocationID


```

![{DE16ADA2-17A7-44CA-BD7C-7705B1D3CC2C}](https://github.com/user-attachments/assets/dd5b869d-fbe2-47a9-a758-1600785e5836)

26. List all payments with courier details  
```sql

SELECT p.PaymentID, p.Amount, p.PaymentDate, c.CourierID, c.TrackingNumber, c.Status
FROM Payments p
LEFT JOIN Couriers c ON p.CourierID = c.CourierID    


```

![{F0A7A153-E8A9-4219-9A8A-BDEA41D18C01}](https://github.com/user-attachments/assets/6ebd5099-cbfc-42b4-b6bf-7a5beeff2731)


27. Total payments received for each courier  
```sql

SELECT c.CourierID, c.TrackingNumber, SUM(p.Amount) AS TotalPayments
FROM Couriers c
LEFT JOIN Payments p ON c.CourierID = p.CourierID
GROUP BY c.CourierID, c.TrackingNumber
ORDER BY TotalPayments DESC


```

![{EF21703D-BD45-41EC-8E76-0F7E539B1FF3}](https://github.com/user-attachments/assets/85b2d6f8-197d-4b66-9f03-0282b4afee6e)


28. List payments made on a specific date 
```sql


SELECT * FROM Payments
WHERE PaymentDate = '2025-03-24'

```

![{23ADE41E-B32F-44B2-A635-408355B05549}](https://github.com/user-attachments/assets/a759a358-f46c-4b26-b89b-013df1ab92e8)

29. Get Courier Information for Each Payment  
```sql
SELECT p.PaymentID, p.Amount, p.PaymentDate, c.CourierID, c.TrackingNumber, c.Status
FROM Payments p
LEFT JOIN Couriers c ON p.CourierID = c.CourierID


```

![{0A08B9FC-24BA-4877-8B5F-105F2EFDFF6E}](https://github.com/user-attachments/assets/4c8d4464-5a9d-4fca-9d5c-8b374b7778b6)

30. Get Payment Details with Location  
```sql

SELECT p.PaymentID, p.Amount, p.PaymentDate, l.LocationID, l.LocationName, l.Address
FROM Payments p
LEFT JOIN Locations l ON p.LocationID = l.LocationID

```

![{95A6024F-0BB1-48AA-803D-82BF3CE64C45}](https://github.com/user-attachments/assets/d0152b3c-ef13-49b1-bf09-b040bbcd8d9b)

31. Calculating Total Payments for Each Courier  
```sql



```

32. List Payments Within a Date Range  
```sql

SELECT * FROM Payments
WHERE PaymentDate BETWEEN '2025-03-01' AND '2025-03-24'


```
![{2BE22BD6-22F7-4A83-BDD9-4D37B78E5092}](https://github.com/user-attachments/assets/387df54e-e619-4107-8acc-c719cd3ef6fd)


33. Retrieve a list of all users and their corresponding courier records, including cases where there are 
no matches on either side  
```sql



```

34. Retrieve a list of all couriers and their corresponding services, including cases where there are no 
matches on either side  
```sql



```

35. Retrieve a list of all employees and their corresponding payments, including cases where there are 
no matches on either side  
```sql



```

36. List all users and all courier services, showing all possible combinations.  
```sql

SELECT u.UserID, u.Name AS UserName, cs.ServiceID, cs.ServiceName
FROM Users u
CROSS JOIN CourierServices cs


```

![{FDD5C7C8-7FC3-4B15-82F2-F547ECE6DB9C}](https://github.com/user-attachments/assets/024975b8-a0c1-42ef-a449-c2c290b29512)

37. List all employees and all locations, showing all possible combinations:  
```sql


SELECT e.EmployeeID, e.Name AS EmployeeName, l.LocationID, l.LocationName
FROM Employees e
CROSS JOIN Locations l

```

![{6E0548EC-58D6-4AD4-9624-E6EAD0FEBE5C}](https://github.com/user-attachments/assets/2c6d4b32-75dd-4609-a84d-eb0e69e0797b)

38. Retrieve a list of couriers and their corresponding sender information (if available)  
```sql

SELECT c.CourierID, c.TrackingNumber, u.UserID, u.Name AS SenderName
FROM Couriers c
LEFT JOIN Users u ON c.SenderName = u.Name


```

![{6B236426-2AA9-4162-9DC0-37985FEAFF57}](https://github.com/user-attachments/assets/f93e0ed1-606c-4f8a-a3da-4d4aa3a14fa9)


39. Retrieve a list of couriers and their corresponding receiver information (if available):  
```sql
SELECT c.CourierID, c.TrackingNumber, c.ReceiverName
FROM Couriers c


```

![{75EE91D8-DEAF-4197-ACF0-EB0414530E33}](https://github.com/user-attachments/assets/07546781-a443-47cc-bf86-6fb1990be90a)

40. Retrieve a list of couriers along with the courier service details (if available):  
```sql



```

41. Retrieve a list of employees and the number of couriers assigned to each employee:  
```sql



```

42. Retrieve a list of locations and the total payment amount received at each location:  
```sql
SELECT l.LocationID, l.LocationName, SUM(p.Amount) AS TotalPayments
FROM Locations l
LEFT JOIN Payments p ON l.LocationID = p.LocationID
GROUP BY l.LocationID, l.LocationName



```

![{BE2DF0F9-B3D2-4481-9D54-08EAFE12374D}](https://github.com/user-attachments/assets/2119f622-771a-458d-aba5-31856ec7d848)


43. Retrieve all couriers sent by the same sender (based on SenderName).  
```sql
SELECT SenderName, COUNT(CourierID) AS TotalCouriers
FROM Couriers
GROUP BY SenderName
HAVING COUNT(CourierID) > 1


```

![{63C2535C-7EA5-4841-B590-1B6EF90DF197}](https://github.com/user-attachments/assets/dc5ac88e-8d8d-47bf-9fea-b5e8004e0394)

44. List all employees who share the same role.  
```sql



```

45. Retrieve all payments made for couriers sent from the same location.  
```sql



```

46. Retrieve all couriers sent from the same location (based on SenderAddress).  
```sql



```

47. List employees and the number of couriers they have delivered:  
```sql



```

48. Find couriers that were paid an amount greater than the cost of their respective courier services 
```sql



```
# Scope: Inner Queries, Non Equi Joins, Equi joins,Exist,Any,All  
49. Find couriers that have a weight greater than the average weight of all couriers  
```sql

SELECT CourierID, SenderName, ReceiverName, Weight
FROM Couriers
WHERE Weight > (SELECT AVG(Weight) FROM Couriers)


```
![{AFAF232B-FCE2-4A72-8C3E-C3B47A55F79B}](https://github.com/user-attachments/assets/f796b2ae-621a-4ea8-ba97-d4015085326c)

50. Find the names of all employees who have a salary greater than the average salary:  
```sql
SELECT Name, Salary
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees)


```
![{D659744B-43BF-4AB0-89FA-4BF1BAE466B9}](https://github.com/user-attachments/assets/a7702a74-3d95-4cc5-9bfe-5b37deb7ac24)

51. Find the total cost of all courier services where the cost is less than the maximum cost  
```sql
SELECT SUM(Cost) AS TotalCost
FROM CourierServices
WHERE Cost < (SELECT MAX(Cost) FROM CourierServices)


```
![{6DB6FADC-AC61-4FBF-9BE2-F8A16730DC78}](https://github.com/user-attachments/assets/d3358733-4588-48c3-8c71-b4abb4939ab2)

52. Find all couriers that have been paid for  
```sql

SELECT c.CourierID, c.TrackingNumber
FROM Couriers c
WHERE EXISTS (SELECT 1 FROM Payments p WHERE p.CourierID = c.CourierID)


```
![{254563E6-76B0-46D0-9452-55DDA129088D}](https://github.com/user-attachments/assets/c7ec4985-3abc-400c-a2bf-33515b767839)

53. Find the locations where the maximum payment amount was made  
```sql

SELECT l.LocationID, l.LocationName
FROM Locations l
INNER JOIN Payments p ON l.LocationID = p.LocationID
WHERE p.Amount = (SELECT MAX(Amount) FROM Payments)


```
![{6636D74D-E822-4268-B250-6EF822EE4DA5}](https://github.com/user-attachments/assets/36bc8e09-800c-4ed6-bfb5-f697a5e7fd21)

54. Find all couriers whose weight is greater than the weight of all couriers sent by a specific sender 
(e.g., 'SenderName'): 
```sql
SELECT CourierID, SenderName, Weight
FROM Couriers
WHERE Weight > ALL (SELECT Weight FROM Couriers WHERE SenderName = 'Naveen Kumar')


```
![{90E5891C-84BE-49AD-A041-1CCDE7BC97DF}](https://github.com/user-attachments/assets/3487fddd-9231-43b6-a114-7da2f051f6fe)

