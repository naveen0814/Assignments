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
select * from Inventory
INSERT INTO Customers (CustomerID, FirstName, LastName, Email, Phone, Address)
VALUES 
(1, 'Naveen', 'Reddy', 'naveen.reddy@example.com', 9876543210, 'Flat No. 201, Krishna Residency, Banjara Hills, Hyderabad, Telangana'),
(2, 'Kumar', 'Patel', 'kumar.patel@example.com', 9876543211, '12, Shree Apartments, CG Road, Navrangpura, Ahmedabad, Gujarat'),
(3, 'Gabriel', 'Fernandes', 'gabriel.fernandes@example.com', 9876543212, '403, Sea View Residency, Miramar Beach Road, Panaji, Goa'),
(4, 'Sumanth', 'Verma', 'sumanth.verma@example.com', 9876543213, '17, Brigade Road, Ashok Nagar, Bangalore, Karnataka'),
(5, 'Vignesh', 'Iyer', 'vignesh.iyer@example.com', 9876543214, '56, MG Road, T. Nagar, Chennai, Tamil Nadu'),
(6, 'Dharma', 'Sharma', 'dharma.sharma@example.com', 9876543215, '221B, MI Road, C-Scheme, Jaipur, Rajasthan'),
(7, 'Barna', 'Das', 'barna.das@example.com', 9876543216, '88, Park Street, Ballygunge, Kolkata, West Bengal'),
(8, 'Gopal', 'Singh', 'gopal.singh@example.com', 9876543217, '90, Hazratganj Road, Aliganj, Lucknow, Uttar Pradesh'),
(9, 'Surya', 'Mishra', 'surya.mishra@example.com', 9876543218, '34, Boring Road, Sri Krishna Puri, Patna, Bihar'),
(10, 'Hamdhan', 'Ali', 'hamdhan.ali@example.com', 9876543219, 'House No. 76, MG Road, Ernakulam, Kochi, Kerala')


INSERT INTO Products (ProductID, ProductName, Description, Price)
VALUES 
(1, 'iPhone 14', 'Apple Smartphone 128GB', 79999.00),
(2, 'Samsung Galaxy S22', 'Samsung Smartphone 256GB', 69999.00),
(3, 'Dell XPS 13', 'Dell Laptop 13-inch 512GB SSD', 119999.00),
(4, 'Sony WH-1000XM4', 'Sony Noise Cancelling Headphones', 24999.00),
(5, 'Apple Watch Series 8', 'Apple Smartwatch 45mm', 45999.00),
(6, 'Lenovo IdeaPad', 'Lenovo Laptop 8GB RAM 1TB HDD', 49999.00),
(7, 'Canon EOS 1500D', 'DSLR Camera with 18-55mm Lens', 40999.00),
(8, 'Realme Narzo 50', 'Realme Smartphone 64GB', 15999.00),
(9, 'Samsung 43 Inch Smart TV', 'Samsung Full HD Smart LED TV', 35999.00),
(10, 'JBL Flip 5', 'Portable Bluetooth Speaker', 8499.00)

INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount)
VALUES 
(1, 1, '2024-12-01', 154997.00),
(2, 2, '2024-12-03', 8499.00),
(3, 3, '2024-12-04', 69999.00),
(4, 4, '2024-12-05', 119999.00),
(5, 5, '2024-12-07', 40999.00),
(6, 6, '2024-12-10', 35999.00),
(7, 7, '2024-12-12', 79999.00),
(8, 8, '2024-12-14', 24999.00),
(9, 9, '2024-12-15', 45999.00),
(10, 10, '2024-12-18', 15999.00)

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity)
VALUES 
(1, 1, 1, 1),  
(2, 1, 4, 1),  
(3, 2, 10, 1), 
(4, 3, 2, 1),  
(5, 4, 3, 1), 
(6, 5, 7, 1), 
(7, 6, 9, 1),  
(8, 7, 1, 1),  
(9, 8, 4, 1),  
(10, 9, 5, 1)

INSERT INTO Inventory (InventoryID, ProductID, QuantityInStock, LastStockUpdate)
VALUES 
(1, 1, 50, '2025-01-01'),
(2, 2, 40, '2025-01-01'),
(3, 3, 20, '2025-01-01'),
(4, 4, 30, '2025-01-01'),
(5, 5, 25, '2025-01-01'),
(6, 6, 35, '2025-01-01'),
(7, 7, 15, '2025-01-01'),
(8, 8, 60, '2025-01-01'),
(9, 9, 18, '2025-01-01'),
(10, 10, 45, '2025-01-01')


select FirstName,LastName,Email from Customers
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
INSERT into Customers (CustomerID, FirstName, LastName, Email, Phone, Address) 
VALUES
(11,'Karthik','Raj','Karthikraj0808@example.com',8798767987,'No.234 Velan Nagar Valasarvakkam Chennai')

UPDATE Products
SET Price = Price*1.10
select * from Products

DECLARE @OrderID INT = 3
DELETE FROM OrderDetails WHERE OrderID = @OrderID
DELETE FROM Orders WHERE OrderID = @OrderID

INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount)
VALUES (11, 2, '2025-03-17', 15999.00)

UPDATE Customers SET Email='naveen2004@example.com', Address = 'Velan Nagar Valasaravakkam' WHERE CustomerID = 1

ALTER table Orders add Status Varchar(50)
update Orders SET Status = 'Shipped' Where OrderID=1


ALTER TABLE Customers ADD OrderCount INT;
UPDATE Customers
SET OrderCount = (
    SELECT COUNT(*) FROM Orders WHERE Orders.CustomerID = Customers.CustomerID
)





UPDATE Orders
SET TotalAmount = (
    SELECT SUM(p.Price * od.Quantity)
    FROM OrderDetails od
    INNER JOIN Products p ON od.ProductID = p.ProductID
    WHERE od.OrderID = Orders.OrderID
)

DECLARE @CustID INT = 2;
DELETE FROM OrderDetails
WHERE OrderID IN (SELECT OrderID FROM Orders WHERE CustomerID = @CustID);
DELETE FROM Orders
WHERE CustomerID = @CustID;



select * from Orders

SELECT Orders.OrderID, Orders.OrderDate, Customers.FirstName, Customers.LastName
FROM Orders
INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID;

SELECT Products.ProductName, SUM(OrderDetails.Quantity * Products.Price) AS TotalRevenue
FROM OrderDetails
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
GROUP BY Products.ProductName

SELECT DISTINCT Customers.CustomerID, Customers.FirstName, Customers.LastName, Customers.Email, Customers.Phone
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID;

SELECT TOP 1 Products.ProductName, SUM(OrderDetails.Quantity) AS TotalQuantity
FROM OrderDetails
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
GROUP BY Products.ProductName
ORDER BY TotalQuantity DESC

SELECT ProductName, Description
FROM Products

SELECT Customers.CustomerID, Customers.FirstName, Customers.LastName, AVG(Orders.TotalAmount) AS AverageOrderValue
FROM Orders
INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID
GROUP BY Customers.CustomerID, Customers.FirstName, Customers.LastName

SELECT TOP 1 Orders.OrderID, Customers.FirstName, Customers.LastName, Orders.TotalAmount
FROM Orders
INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID
ORDER BY Orders.TotalAmount DESC


SELECT Products.ProductName, COUNT(OrderDetails.OrderDetailID) AS TimesOrdered
FROM OrderDetails
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
GROUP BY Products.ProductName


DECLARE @ProductName VARCHAR(100) = 'iPhone 14'

SELECT DISTINCT Customers.CustomerID, Customers.FirstName, Customers.LastName
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
INNER JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderID
INNER JOIN Products ON OrderDetails.ProductID = Products.ProductID
WHERE Products.ProductName = @ProductName


DECLARE @StartDate DATE = '2024-12-01';
DECLARE @EndDate DATE = '2024-12-31';

SELECT SUM(TotalAmount) AS TotalRevenue
FROM Orders
WHERE OrderDate BETWEEN @StartDate AND @EndDate

SELECT c.CustomerID, c.FirstName, c.LastName, COUNT(o.OrderID) AS OrderCount
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.FirstName, c.LastName
HAVING COUNT(o.OrderID) = 0

SELECT COUNT(*) AS TotalProducts FROM Products


SELECT SUM(TotalAmount) AS TotalRevenue FROM Orders

SELECT OrderID, AVG(OrderDetails.Quantity) AS AvgQuantityOrdered FROM OrderDetails
join Products on OrderDetails.OrderID = Products.ProductID group by OrderDetails.OrderID




DECLARE @CustomerID INT = 6;

SELECT c.FirstName, c.LastName, COALESCE(SUM(o.TotalAmount), 0) AS TotalRevenue
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.CustomerID = @CustomerID
GROUP BY c.FirstName, c.LastName;


SELECT c.FirstName, c.LastName, COUNT(o.OrderID) AS OrderCount
FROM Orders o
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY c.CustomerID, c.FirstName, c.LastName
ORDER BY OrderCount DESC;

SELECT TOP 1 p.Description AS Category, SUM(od.Quantity) AS TotalQuantityOrdered
FROM OrderDetails od
INNER JOIN Products p ON od.ProductID = p.ProductID
GROUP BY p.Description
ORDER BY TotalQuantityOrdered DESC;

SELECT TOP 1 c.FirstName, c.LastName, SUM(o.TotalAmount) AS TotalSpending
FROM Orders o
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
INNER JOIN Products p ON od.ProductID = p.ProductID
WHERE p.Description LIKE '%Electronics%' OR p.Description LIKE '%Smartphone%' 
   OR p.Description LIKE '%Laptop%' OR p.Description LIKE '%Gadget%'
GROUP BY c.FirstName, c.LastName
ORDER BY TotalSpending DESC


SELECT AVG(TotalAmount) AS AvgOrderValue
FROM Orders

SELECT Customers.CustomerID, CONCAT(FirstName, ' ', LastName) AS CustomerName, COUNT(OrderID) AS OrderCount
FROM Customers
LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
GROUP BY Customers.CustomerID, FirstName, LastName















select * from Customers,Products,Orders,OrderDetails,Inventory
select * from Orders
insert into Orders values (1,1,'2025-03-17',899)
insert into Customers values (2,'Gabe','barna','gabe2001@gmail.com',87378098478,'Velan Nagar 2nd street')

delete from Customers where CustomerID = 2







select * from Orders
insert into Products values (1,'Bottle','High Quality Water Bottle',899.00)