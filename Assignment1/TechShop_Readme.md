# HEXA
# Task:1. Database Design:
1. Create the database named "TechShop"
```sql
   CREATE DATABASE TechShop

USE TechShop
```
2. Define the schema for the Customers, Products, Orders, OrderDetails and Inventory tables based on the provided schema.
```sql
CREATE DATABASE TechShop

USE TechShop
CREATE TABLE Customers
(
CustomerID int PRIMARY KEY,
FirstName varchar(50),
LastName varchar(50),
Email varchar(200),
Phone bigint,
Address varchar(500)
)
CREATE TABLE Products
(
ProductID int PRIMARY KEY,
ProductName varchar(100),
Description varchar(200),
Price decimal
)
CREATE TABLE Orders
(
OrderID int PRIMARY KEY,
CustomerID int,
OrderDate DATE,
TotalAmount MONEY
Constraint fh_ky FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)
CREATE TABLE OrderDetails
(
OrderDetailID int PRIMARY KEY,
OrderID int,
ProductID int,
Quantity int
constraint fh_ky1 FOREIGN KEY (OrderID) references Orders(OrderID),
constraint fh_ky2 FOREIGN KEY (ProductID) references Products(ProductID)
)
CREATE TABLE Inventory
(
InventoryID int PRIMARY KEY,
ProductID int ,
QuantityInStock int,
LastStockUpdate datetime
constraint fh_ky3 FOREIGN KEY (ProductID) references Products(ProductID)
)
```
3. Create an ERD (Entity Relationship Diagram) for the database.

![erid](https://github.com/user-attachments/assets/05742b90-4ee8-46df-be58-510b4a66d734)

![Screenshot_20250317_195807](https://github.com/user-attachments/assets/561287ee-9b99-4308-ac40-f558ffe31461)

4. Create appropriate Primary Key and Foreign Key constraints for referential integrity.
```sql
   CREATE DATABASE TechShop

USE TechShop
CREATE TABLE Customers
(
CustomerID int PRIMARY KEY,
FirstName varchar(50),
LastName varchar(50),
Email varchar(200),
Phone bigint,
Address varchar(500)
)
CREATE TABLE Products
(
ProductID int PRIMARY KEY,
ProductName varchar(100),
Description varchar(200),
Price decimal
)
CREATE TABLE Orders
(
OrderID int PRIMARY KEY,
CustomerID int,
OrderDate DATE,
TotalAmount MONEY
Constraint fh_ky FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)
CREATE TABLE OrderDetails
(
OrderDetailID int PRIMARY KEY,
OrderID int,
ProductID int,
Quantity int
constraint fh_ky1 FOREIGN KEY (OrderID) references Orders(OrderID),
constraint fh_ky2 FOREIGN KEY (ProductID) references Products(ProductID)
)
CREATE TABLE Inventory
(
InventoryID int PRIMARY KEY,
ProductID int ,
QuantityInStock int,
LastStockUpdate datetime
constraint fh_ky3 FOREIGN KEY (ProductID) references Products(ProductID)
)
```
5. Insert at least 10 sample records into each of the following tables.
a. Customers
b. Products
c. Orders
d. OrderDetails
e. Inventory

![{64AA4EDD-4BB2-4AAD-ACC1-29EF2900EA94}](https://github.com/user-attachments/assets/514ccb72-9100-471b-a283-9951bc33b14a)
![{221C37F6-17AB-43FF-A8E0-CBEFC1EA32D3}](https://github.com/user-attachments/assets/f4e62aa1-f655-4fff-94b2-a67cdf5ead09)
![{F8AC3B9D-ABCA-416F-859B-BB776ACF03EC}](https://github.com/user-attachments/assets/8038b3e0-e402-478b-8530-df728a19c43a)
![{0D1E4AFF-75EF-4DA4-A8C5-883C163DD819}](https://github.com/user-attachments/assets/11c420a8-73c0-4926-9674-f2033e21e15f)
![{C3C2C495-4A59-4549-85C1-1035B16447AF}](https://github.com/user-attachments/assets/5e8c3c0e-87a6-4be3-a7c9-20be6bce3218)

# Tasks 2: Select, Where, Between, AND, LIKE:
1. Write an SQL query to retrieve the names and emails of all customers.
   ```sql
   select FirstName,LastName,Email from Customers
   ```
![Screenshot_20250317_205945](https://github.com/user-attachments/assets/036dbf4c-ab5b-4ee6-bc46-ff24305b2a6d)

2. Write an SQL query to list all orders with their order dates and corresponding customer names.
   
```sql
SELECT 
    Orders.OrderID,
    Orders.OrderDate,
    Customers.FirstName,
    Customers.LastName
FROM 
    Orders
INNER JOIN 
    Customers
ON 
    Orders.CustomerID = Customers.CustomerID
```
![{93BB38FB-BB4B-45E0-A6AB-D5F14287B983}](https://github.com/user-attachments/assets/e2499950-ef22-410d-a990-6498d5f96120)
3. Write an SQL query to insert a new customer record into the "Customers" table. Include customer information such as name, email, and address.
```sql
INSERT into Customers (CustomerID, FirstName, LastName, Email, Phone, Address) 
VALUES
(11,'Karthik','Raj','Karthikraj0808@example.com',8798767987,'No.234 Velan Nagar Valasarvakkam Chennai')
```
![{25A8AEA2-0128-4D30-A081-9DD5A2B402DC}](https://github.com/user-attachments/assets/d35194d3-b918-47aa-9625-32f1f32982e9)


4. Write an SQL query to update the prices of all electronic gadgets in the "Products" table by increasing them by 10%.
 
```sql
UPDATE Products
SET Price = Price*1.10
select * from Products
```
![{91FD4E73-5A3B-4C19-84FE-C56719604E41}](https://github.com/user-attachments/assets/babc5892-def2-4a90-b337-c99de5c135b4)

5. Write an SQL query to retrieve a list of electronic gadgets along with their corresponding 
categories.

```sql
DECLARE @OrderID INT = 3;
DELETE FROM OrderDetails WHERE OrderID = @OrderID
DELETE FROM Orders WHERE OrderID = @OrderID

```
![Screenshot_20250317_214219](https://github.com/user-attachments/assets/1ab04e46-e00d-421f-a5c3-b920629b7232)

6. Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, 
order date, and any other necessary information.
```sql
INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount)
VALUES (11, 2, '2025-03-17', 15999.00)
```
![{BC8AF78E-143A-4A5D-9872-82D38F10F1B4}](https://github.com/user-attachments/assets/e77ba029-9b0f-486e-a4e5-369daa1001ab)
7. Write an SQL query to update the contact information (e.g., email and address) of a specific 
customer in the "Customers" table. Allow users to input the customer ID and new contact 
information.
```sql
UPDATE Customers SET Email='naveen2004@example.com', Address = 'Velan Nagar Valasaravakkam' WHERE CustomerID = 1
```
![{DD9DC58D-697C-4CA8-92DE-3043966B4276}](https://github.com/user-attachments/assets/7e16185c-d97e-47f0-84f5-deff4251b47b)

8. Write an SQL query to recalculate and update the total cost of each order in the "Orders" 
table based on the prices and quantities in the "OrderDetails" table. 


```sql

UPDATE Orders
SET TotalAmount = (
    SELECT SUM(p.Price * od.Quantity)
    FROM OrderDetails od
    INNER JOIN Products p ON od.ProductID = p.ProductID
    WHERE od.OrderID = Orders.OrderID
)

```
![{63FB8872-C081-44B6-88F9-0E6E1C1B0A19}](https://github.com/user-attachments/assets/71d754f1-a5cc-49eb-9fce-400776773a24)


9. Write an SQL query to delete all orders and their associated order details for a specific 
customer from the "Orders" and "OrderDetails" tables. Allow users to input the customer ID 
as a parameter.

```sql
DECLARE @CustID INT = 2;
DELETE FROM OrderDetails
WHERE OrderID IN (SELECT OrderID FROM Orders WHERE CustomerID = @CustID);
DELETE FROM Orders
WHERE CustomerID = @CustID;
```
![{3A7B3C41-7725-492D-8D76-CF5205C62DCD}](https://github.com/user-attachments/assets/d638817c-9454-4a15-a707-45cd64df4359)

10. Write an SQL query to insert a new electronic gadget product into the "Products" table, 
including product name, category, price, and any other relevant details. 

```sql
INSERT INTO Products (ProductID, ProductName, Description, Price)
VALUES (11, 'OnePlus Nord 3', 'OnePlus Smartphone 128GB', 29999.00)
```

![{DEF691A4-464C-4999-84A6-8ED2B2BC1CF7}](https://github.com/user-attachments/assets/6140925f-a08c-4810-98cb-ed925a2b7227)

11.Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from 
"Pending" to "Shipped"). Allow users to input the order ID and the new status.
```sql
ALTER table Orders add Status Varchar(50)
update Orders SET Status = 'Shipped' Where OrderID=1
```

![{E14D3CCA-733A-4606-BEE1-C15F53B2072C}](https://github.com/user-attachments/assets/068b00a4-8856-4fc3-be6d-92570b65e273)

12. Write an SQL query to calculate and update the number of orders placed by each customer 
in the "Customers" table based on the data in the "Orders" table.
```sql
ALTER TABLE Customers ADD OrderCount INT;
UPDATE Customers
SET OrderCount = (
    SELECT COUNT(*) FROM Orders WHERE Orders.CustomerID = Customers.CustomerID
)
```
![{B30C4765-70ED-4851-8F7D-FC489EE733A4}](https://github.com/user-attachments/assets/a14d3b01-d19f-4330-a8ef-7aeddf43054a)


# Task 3. Aggregate functions, Having, Order By, GroupBy and Joins:  

1. Write an SQL query to retrieve a list of all orders along with customer information (e.g., 
customer name) for each order.

```sql

SELECT Orders.OrderID, Orders.OrderDate, Customers.FirstName, Customers.LastName
FROM Orders
INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID;

```

![{B1D05698-6FF2-4EA5-9C88-FEEC7E698B21}](https://github.com/user-attachments/assets/9bead468-b832-40dd-804a-a00043ba32a7)

2. Write an SQL query to find the total revenue generated by each electronic gadget product. 
Include the product name and the total revenue.

```sql
SELECT Products.ProductName, SUM(OrderDetails.Quantity * Products.Price) AS TotalRevenue
FROM OrderDetails
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
GROUP BY Products.ProductName
```

![{8360D8C8-4158-4A7F-BED9-ADD4F90841FF}](https://github.com/user-attachments/assets/15a0283c-257b-4a61-9857-0efba9f73ae5)

3. Write an SQL query to list all customers who have made at least one purchase. Include their 
names and contact information.
```sql
SELECT DISTINCT Customers.CustomerID, Customers.FirstName, Customers.LastName, Customers.Email, Customers.Phone
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID;
```

![{3268EE77-A79D-48A4-9146-2CDC6B1861BD}](https://github.com/user-attachments/assets/d934ccdd-3f2f-48ba-8056-8b8f4fec166f)

4. Write an SQL query to find the most popular electronic gadget, which is the one with the highest 
total quantity ordered. Include the product name and the total quantity ordered.

```sql
SELECT TOP 1 Products.ProductName, SUM(OrderDetails.Quantity) AS TotalQuantity
FROM OrderDetails
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
GROUP BY Products.ProductName
ORDER BY TotalQuantity DESC
```


![{A980301F-A3EC-4948-B086-77BC74086D9E}](https://github.com/user-attachments/assets/e491cdc6-5376-4029-b6fa-cab79c8ea875)

5. Write an SQL query to retrieve a list of electronic gadgets along with their corresponding 
categories.

```sql
SELECT ProductName, Description
FROM Products
```


![{4A5DE529-6645-4107-808B-86CEC29FAA82}](https://github.com/user-attachments/assets/8fd43a2e-4c28-4b8b-b0eb-e67e891d7399)

6. Write an SQL query to calculate the average order value for each customer. Include the 
customer's name and their average order value

```sql
SELECT Customers.CustomerID, Customers.FirstName, Customers.LastName, AVG(Orders.TotalAmount) AS AverageOrderValue
FROM Orders
INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID
GROUP BY Customers.CustomerID, Customers.FirstName, Customers.LastName
```


![{30DA6DCA-18B2-4534-B871-53F988DAD34B}](https://github.com/user-attachments/assets/a450ac13-10bc-44a6-8698-5289de5712e2)

7. Write an SQL query to find the order with the highest total revenue. Include the order ID, 
customer information, and the total revenue.

```sql
SELECT TOP 1 Orders.OrderID, Customers.FirstName, Customers.LastName, Orders.TotalAmount
FROM Orders
INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID
ORDER BY Orders.TotalAmount DESC
```



![{93000681-F432-4703-BCF0-FF75B0BBD3BE}](https://github.com/user-attachments/assets/9388284b-5464-4044-b02a-8accfb635670)

8. Write an SQL query to list electronic gadgets and the number of times each product has been 
ordered.

```sql

SELECT Products.ProductName, COUNT(OrderDetails.OrderDetailID) AS TimesOrdered
FROM OrderDetails
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
GROUP BY Products.ProductName
```

![{60DCFADF-374C-4E7C-BFB1-127926A27C76}](https://github.com/user-attachments/assets/ae78a198-0342-4ea5-8d51-a1c007b66d1b)

9. Write an SQL query to find customers who have purchased a specific electronic gadget product. 
Allow users to input the product name as a parameter.

```sql
DECLARE @ProductName VARCHAR(100) = 'iPhone 14'

SELECT DISTINCT Customers.CustomerID, Customers.FirstName, Customers.LastName
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
WHERE Products.ProductName = @ProductName
```


![{1AFFBB38-8D16-45DA-81A5-127F73D957C3}](https://github.com/user-attachments/assets/f02e0f1a-5b2b-42b0-a982-518d913d41d5)

10. Write an SQL query to calculate the total revenue generated by all orders placed within a 
specific time period. Allow users to input the start and end dates as parameters.

```sql
DECLARE @StartDate DATE = '2024-12-01';
DECLARE @EndDate DATE = '2024-12-31';

SELECT SUM(TotalAmount) AS TotalRevenue
FROM Orders
WHERE OrderDate BETWEEN @StartDate AND @EndDate
```



![{797A66FF-8051-463B-8804-2A21AA902198}](https://github.com/user-attachments/assets/2f7b513c-3dfa-4c87-92e9-ad7a6c55baaf)

# Task 4. Subquery and its type:  

1. Write an SQL query to find out which customers have not placed any orders.

```sql
SELECT c.CustomerID, c.FirstName, c.LastName, COUNT(o.OrderID) AS OrderCount
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.FirstName, c.LastName
HAVING COUNT(o.OrderID) = 0
```

![{ABDF3751-416D-4719-95A5-935DBAADD37D}](https://github.com/user-attachments/assets/1f0bc32c-52fd-41e8-b360-61de3031ceb5)
 
2. Write an SQL query to find the total number of products available for sale.  
```sql
SELECT COUNT(*) AS TotalProducts FROM Products
```
![{008CD8C6-5735-47CD-AC9D-2862BDBB3E4C}](https://github.com/user-attachments/assets/fe03730b-63ea-4015-b726-013e060fa3f2)


3. Write an SQL query to calculate the total revenue generated by TechShop.  
```sql
SELECT SUM(TotalAmount) AS TotalRevenue FROM Orders
```

![{6D177E27-A1B3-4020-BEBA-5F85C2DECA4C}](https://github.com/user-attachments/assets/ca4de16e-237e-40a7-bbbf-914d0e2af5ad)

4. Write an SQL query to calculate the average quantity ordered for products in a specific category. 
Allow users to input the category name as a parameter. 

```sql
SELECT OrderID, AVG(OrderDetails.Quantity) AS AvgQuantityOrdered FROM OrderDetails
join Products on OrderDetails.OrderID = Products.ProductID group by OrderDetails.OrderID
```


![{B87AE3C7-235B-422E-B51D-497396577D8E}](https://github.com/user-attachments/assets/932df38c-582e-4836-ba20-3dc02051b8f5)

5. Write an SQL query to calculate the total revenue generated by a specific customer. Allow users 
to input the customer ID as a parameter. 
```sql

DECLARE @CustomerID INT = 6;

SELECT c.FirstName, c.LastName, COALESCE(SUM(o.TotalAmount), 0) AS TotalRevenue
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.CustomerID = @CustomerID
GROUP BY c.FirstName, c.LastName;

```
![{34F936D0-8DAB-4587-A0C2-F3F7B75DA904}](https://github.com/user-attachments/assets/615fbe9a-2b93-4697-9731-6dd99911ce5f)

6. Write an SQL query to find the customers who have placed the most orders. List their names 
and the number of orders they've placed. 
```sql

SELECT c.FirstName, c.LastName, COUNT(o.OrderID) AS OrderCount
FROM Orders o
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY c.CustomerID, c.FirstName, c.LastName
ORDER BY OrderCount DESC
```
![{43F25DAB-4330-4BAF-8D84-06C11AA9199B}](https://github.com/user-attachments/assets/82a9c82d-c5ac-4308-a952-26e9d3ae4b44)

7. Write an SQL query to find the most popular product category, which is the one with the highest 
total quantity ordered across all orders. 
```sql
SELECT TOP 1 p.Description AS Category, SUM(od.Quantity) AS TotalQuantityOrdered
FROM OrderDetails od
INNER JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.Description
ORDER BY TotalQuantityOrdered DESC

```

![{73716700-4F73-4909-9599-1FF2CCA0832E}](https://github.com/user-attachments/assets/4402b2d0-8619-4808-9f6f-5027898e9c59)

8. Write an SQL query to find the customer who has spent the most money (highest total revenue) 
on electronic gadgets. List their name and total spending. 
```sql
SELECT TOP 1 c.FirstName, c.LastName, SUM(o.TotalAmount) AS TotalSpending
FROM Orders o
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID
WHERE p.Description LIKE '%Electronics%' OR p.Description LIKE '%Smartphone%' 
   OR p.Description LIKE '%Laptop%' OR p.Description LIKE '%Gadget%'
GROUP BY c.FirstName, c.LastName
ORDER BY TotalSpending DESC
```
![{94799A24-75AE-4C9F-88A5-CCD2F694BF81}](https://github.com/user-attachments/assets/4207ffa5-38ac-4b22-aeb6-2f21edec8977)

9. Write an SQL query to calculate the average order value (total revenue divided by the number of 
orders) for all customers. 
```sql

SELECT AVG(TotalAmount) AS AvgOrderValue
FROM Orders

```
![{04844AA2-E4DF-4F4E-85EA-9B3768893D78}](https://github.com/user-attachments/assets/7b543021-3761-4665-a790-249ceaf8795d)

10. Write an SQL query to find the total number of orders placed by each customer and list their 
names along with the order count.

```sql
SELECT Customers.CustomerID, CONCAT(FirstName, ' ', LastName) AS CustomerName, COUNT(OrderID) AS OrderCount
FROM Customers
LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CustomerID, FirstName, LastName



```


![{DDD393C6-2BDB-4E30-8C7E-A149D6C096F1}](https://github.com/user-attachments/assets/47f2ac81-7a9b-4db7-ba3c-a8287cf65ba1)

