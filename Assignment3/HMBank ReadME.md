# Tasks 1: Database Design:   

1. Create the database named "HMBank"  
```sql
CREATE DATABASE HMBank
USE HMBank
```
2. Define the schema for the Customers, Accounts, and Transactions tables based on the 
provided schema.  
```sql

CREATE TABLE Customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    DOB DATE NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    phone_number VARCHAR(15) UNIQUE NOT NULL,
    address VARCHAR(255) NOT NULL
)

CREATE TABLE Accounts (
    account_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT NOT NULL,
    account_type VARCHAR(20) CHECK (account_type IN ('savings', 'current', 'zero_balance')) NOT NULL,
    balance DECIMAL(15, 2) CHECK (balance >= 0) NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id) ON DELETE CASCADE
)

CREATE TABLE Transactions (
    transaction_id INT PRIMARY KEY IDENTITY(1,1),
    account_id INT NOT NULL,
    transaction_type VARCHAR(20) CHECK (transaction_type IN ('deposit', 'withdrawal', 'transfer')) NOT NULL,
    amount DECIMAL(15, 2) CHECK (amount > 0) NOT NULL,
    transaction_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (account_id) REFERENCES Accounts(account_id) ON DELETE CASCADE
)


```
4. Create an ERD (Entity Relationship Diagram) for the database.  

![Screenshot_20250321_102352](https://github.com/user-attachments/assets/4e8bdd0f-7739-41eb-90a1-93ae38f20a65)

5. Create appropriate Primary Key and Foreign Key constraints for referential integrity.  
```sql

CREATE TABLE Customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    DOB DATE NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    phone_number VARCHAR(15) UNIQUE NOT NULL,
    address VARCHAR(255) NOT NULL
)

CREATE TABLE Accounts (
    account_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT NOT NULL,
    account_type VARCHAR(20) CHECK (account_type IN ('savings', 'current', 'zero_balance')) NOT NULL,
    balance DECIMAL(15, 2) CHECK (balance >= 0) NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id) ON DELETE CASCADE
)

CREATE TABLE Transactions (
    transaction_id INT PRIMARY KEY IDENTITY(1,1),
    account_id INT NOT NULL,
    transaction_type VARCHAR(20) CHECK (transaction_type IN ('deposit', 'withdrawal', 'transfer')) NOT NULL,
    amount DECIMAL(15, 2) CHECK (amount > 0) NOT NULL,
    transaction_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (account_id) REFERENCES Accounts(account_id) ON DELETE CASCADE
)

```

6. Write SQL scripts to create the mentioned tables with appropriate data types, constraints, 
and relationships.   
• Customers  
• Accounts 
• Transactions

```sql

CREATE TABLE Customers (
    customer_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    DOB DATE NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    phone_number VARCHAR(15) UNIQUE NOT NULL,
    address VARCHAR(255) NOT NULL
)

CREATE TABLE Accounts (
    account_id INT PRIMARY KEY IDENTITY(1,1),
    customer_id INT NOT NULL,
    account_type VARCHAR(20) CHECK (account_type IN ('savings', 'current', 'zero_balance')) NOT NULL,
    balance DECIMAL(15, 2) CHECK (balance >= 0) NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id) ON DELETE CASCADE
)

CREATE TABLE Transactions (
    transaction_id INT PRIMARY KEY IDENTITY(1,1),
    account_id INT NOT NULL,
    transaction_type VARCHAR(20) CHECK (transaction_type IN ('deposit', 'withdrawal', 'transfer')) NOT NULL,
    amount DECIMAL(15, 2) CHECK (amount > 0) NOT NULL,
    transaction_date DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (account_id) REFERENCES Accounts(account_id) ON DELETE CASCADE
)
```
# Tasks 2: Select, Where, Between, AND, LIKE: 

1. Insert at least 10 sample records into each of the following tables.   
• Customers  
• Accounts 
• Transactions 

![{EB316326-5F68-44DE-843E-ECC7C642649E}](https://github.com/user-attachments/assets/9fefd404-6a7f-4a04-8dab-bc5882a16e4b)


2. Write SQL queries for the following tasks: 
1. Write a SQL query to retrieve the name, account type and email of all customers.   
```sql
SELECT first_name, last_name, account_type, email
FROM Customers
JOIN Accounts ON Customers.customer_id = Accounts.customer_id

```
![{AADBCA61-A64C-42C5-9E31-59E0FBCA4BD4}](https://github.com/user-attachments/assets/a3b6a311-c428-4360-b3c9-c9298c0bc857)


2. Write a SQL query to list all transaction corresponding customer. 
```sql
SELECT t.transaction_id, t.transaction_type, t.amount, c.first_name, c.last_name
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id
JOIN Customers c ON a.customer_id = c.customer_id
```
![{D5A8A4AB-E573-4B92-8259-337411AECEDA}](https://github.com/user-attachments/assets/6f358950-bd43-459c-a6ae-ab882d85528a)

3. Write a SQL query to increase the balance of a specific account by a certain amount. 
```sql
UPDATE Accounts
SET balance = balance + 500
WHERE account_id = 2
```
![{20E3F21A-4034-4700-A0B1-C8FE3D959E86}](https://github.com/user-attachments/assets/bf026460-4c1f-4179-886b-cc39d2557574)

4. Write a SQL query to Combine first and last names of customers as a full_name. 
```sql
SELECT CONCAT(first_name, ' ', last_name) AS full_name FROM Customers

```
![{BD6C7155-1833-4805-8271-2A588CE57746}](https://github.com/user-attachments/assets/59702249-76dd-48c1-a251-e5191cf6c625)

5. Write a SQL query to remove accounts with a balance of zero where the account 
type is savings. 
```sql
DELETE FROM Accounts
WHERE balance = 0 AND account_type = 'savings'
```
![{C37C821D-3938-45B1-9F3A-69A4563CAFAD}](https://github.com/user-attachments/assets/2d2a4f6c-9030-44b5-b427-992007677504)

6. Write a SQL query to Find customers living in a specific city. 
```sql
SELECT * FROM Customers
WHERE address = 'Dallas'

```
![{32FF3409-FE1E-4335-92D3-D8C82894A288}](https://github.com/user-attachments/assets/82dec54d-cba5-48e3-b82b-9c99dbe7403f)

7. Write a SQL query to Get the account balance for a specific account. 
```sql
SELECT balance FROM Accounts
WHERE account_id = 3

```
![{61B0B8DE-C192-459D-9372-63478AFE29BD}](https://github.com/user-attachments/assets/772715c9-502f-41b7-9531-09615aedc464)

8. Write a SQL query to List all current accounts with a balance greater than $1,000. 
```sql

SELECT * FROM Accounts
WHERE account_type = 'current' AND balance > 1000

```
![{4A4B8A6C-272E-4409-B7B9-6508AB7353CD}](https://github.com/user-attachments/assets/498605fb-126f-4da9-81b6-38d70d3d688e)


9. Write a SQL query to Retrieve all transactions for a specific account. 
```sql
SELECT * FROM Transactions
WHERE account_id = 1

```
![{FCB89985-6613-4571-8F8C-A64E8C98644A}](https://github.com/user-attachments/assets/80e14896-fcdd-47d1-b176-1c88e2cdaef5)

10. Write a SQL query to Calculate the interest accrued on savings accounts based on a 
given interest rate. 
```sql
SELECT account_id, balance, balance * 0.05 AS interest
FROM Accounts
WHERE account_type = 'savings'
```
![{9E948EE8-EB83-4EC3-87B0-E3048E2CAC5B}](https://github.com/user-attachments/assets/ed6a5d10-c5d7-4a82-8c5b-c213e282e64f)

11. Write a SQL query to Identify accounts where the balance is less than a specified 
overdraft limit. 
```sql
SELECT * FROM Accounts
WHERE balance < 500
```
![{C0855AC3-0371-4ED8-BAFB-EED819C3D9A6}](https://github.com/user-attachments/assets/441b3757-4202-4b4c-b2f7-ee08e5039d74)

12. Write a SQL query to Find customers not living in a specific city. 
```sql

SELECT * FROM Customers
WHERE address != 'Dallas'

```
![{FADA5488-2C96-46F2-BB7C-19B5334338FF}](https://github.com/user-attachments/assets/baa0beca-9660-4249-812a-e421861faa29)


# Tasks 3: Aggregate functions, Having, Order By, GroupBy and Joins: 
1. Write a SQL query to Find the average account balance for all customers.   
```sql
SELECT AVG(balance) AS avg_balance FROM Accounts

```
![{213678B0-5BB2-4152-8901-1FC7AEB61910}](https://github.com/user-attachments/assets/238dc159-f12b-4c21-9a26-a95e89758bab)

2. Write a SQL query to Retrieve the top 10 highest account balances.  
```sql

SELECT TOP 10 * FROM Accounts
ORDER BY balance DESC

```
![{A9E313CD-80E8-48DE-80AF-61806B9E3BB8}](https://github.com/user-attachments/assets/4e9563dc-bcd7-48fb-af67-c4f9fec4b5bc)

3. Write a SQL query to Calculate Total Deposits for All Customers in specific date. 
```sql
SELECT SUM(amount) AS total_deposit
FROM Transactions
WHERE transaction_type = 'deposit' AND transaction_date = '2024-03-02'

```
![{4F6AC731-9744-42D7-9069-FC8116B9598E}](https://github.com/user-attachments/assets/0b933e76-6e77-433c-a99f-03c9d2991fcf)

4. Write a SQL query to Find the Oldest and Newest Customers. 
```sql
SELECT TOP 1 * FROM Customers
ORDER BY DOB ASC

SELECT TOP 1 * FROM Customers
ORDER BY DOB DESC
```
![{37C22F36-C828-4731-93F1-89A8BF578E22}](https://github.com/user-attachments/assets/4adc0ca8-4076-43d5-a4cb-a26034b785ac)

5. Write a SQL query to Retrieve transaction details along with the account type. 
```sql
SELECT t.*, a.account_type
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id

```
![{5DF6C373-7B55-4283-8BE0-B97879B54F99}](https://github.com/user-attachments/assets/78a1bc26-5e04-4dbb-9412-4d50c60c4eea)

6. Write a SQL query to Get a list of customers along with their account details. 
```sql

SELECT c.*, a.account_id, a.account_type, a.balance
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id

```
![{629C0D11-316C-4504-90B7-97AFAF0CB2E0}](https://github.com/user-attachments/assets/cb622a16-2600-49b5-a852-1be22a255f53)

7. Write a SQL query to Retrieve transaction details along with customer information for a 
specific account. 
```sql
SELECT t.*, c.first_name, c.last_name
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id
JOIN Customers c ON a.customer_id = c.customer_id
WHERE a.account_id = 1
```
![{08C1EA14-4AA2-48DD-AF68-B986961AEDAA}](https://github.com/user-attachments/assets/007df1a3-7f7b-48ea-89b8-cbc6133d855f)

8. Write a SQL query to Identify customers who have more than one account. 
```sql
SELECT customer_id, COUNT(account_id) AS account_count
FROM Accounts
GROUP BY customer_id
HAVING COUNT(account_id) > 1

```
![{792DD542-0428-4336-8804-EA26C34CDCDC}](https://github.com/user-attachments/assets/b71c597d-a9a5-45ba-9a15-1b8c7fae75cb)

9. Write a SQL query to Calculate the difference in transaction amounts between deposits and 
withdrawals. 
```sql
SELECT 
    SUM(CASE WHEN transaction_type = 'deposit' THEN amount ELSE 0 END) -
    SUM(CASE WHEN transaction_type = 'withdrawal' THEN amount ELSE 0 END) AS difference
FROM Transactions
```
![{2373BE0A-DDD8-4D61-B128-0AC1E6582A7B}](https://github.com/user-attachments/assets/9df0b359-ef9d-42e6-ab10-749ef2225c74)

10. Write a SQL query to Calculate the average daily balance for each account over a specified 
period. 
```sql

SELECT account_id, AVG(balance) AS avg_daily_balance
FROM Accounts
GROUP BY account_id

```
![{5EEDDE56-32D3-41BB-BD12-7B36A5281045}](https://github.com/user-attachments/assets/534600de-74a5-45ea-a9f3-f8eee3cd606f)

11. Calculate the total balance for each account type. 
```sql
SELECT account_type, SUM(balance) AS total_balance
FROM Accounts
GROUP BY account_type
```
![{0F80FF9D-2683-4CD7-B4D7-B3AD036B2038}](https://github.com/user-attachments/assets/3adee0e9-3feb-4a65-988c-ea5d203266d3)

12. Identify accounts with the highest number of transactions order by descending order. 
```sql
SELECT a.account_id, COUNT(t.transaction_id) AS txn_count
FROM Accounts a
JOIN Transactions t ON a.account_id = t.account_id
GROUP BY a.account_id
ORDER BY txn_count DESC
```
![{C3D56633-78F1-4752-8375-9749294CB876}](https://github.com/user-attachments/assets/62f982bf-6ee4-4a48-9e87-7affe5a17cf6)

13. List customers with high aggregate account balances, along with their account types. 
```sql
SELECT c.first_name, c.last_name, a.account_type, SUM(a.balance) AS total_balance
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id
GROUP BY c.first_name, c.last_name, a.account_type
HAVING SUM(a.balance) > 3000
```
![{12FFDDFF-2B0D-4EE0-9DEB-CE98BD4934B0}](https://github.com/user-attachments/assets/2ebbe774-b7ec-4630-a905-4f924a80a7c8)

14. Identify and list duplicate transactions based on transaction amount, date, and account.
```sql
SELECT account_id, amount, transaction_date, COUNT(*) AS dup_count
FROM Transactions
GROUP BY account_id, amount, transaction_date
HAVING COUNT(*) > 1
```
![{0FFC5988-CE61-4865-9163-C59B9F68CAA5}](https://github.com/user-attachments/assets/43e07ab3-98c8-4e67-8502-f77244a58ce2)

# Tasks 4: Subquery and its type: 
1. Retrieve the customer(s) with the highest account balance. 
```sql
SELECT c.first_name, c.last_name, a.balance
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id
WHERE a.balance = (SELECT MAX(balance) FROM Accounts)
```
![{D4D92DD5-A47C-4477-87DB-658704B3C328}](https://github.com/user-attachments/assets/000a382b-b788-4254-a344-ad261eaa47bf)


2. Calculate the average account balance for customers who have more than one account. 
```sql
SELECT AVG(balance) AS avg_balance
FROM Accounts
WHERE customer_id IN (
    SELECT customer_id
    FROM Accounts
    GROUP BY customer_id
    HAVING COUNT(account_id) > 1
)
```
![{7153327A-A337-4D5D-A40F-1C0C036067D8}](https://github.com/user-attachments/assets/1dd62807-ce27-4b97-bca3-bf63d76d90b5)

3. Retrieve accounts with transactions whose amounts exceed the average transaction amount. 
```sql
SELECT DISTINCT a.account_id, a.account_type
FROM Accounts a
JOIN Transactions t ON a.account_id = t.account_id
WHERE t.amount > (SELECT AVG(amount) FROM Transactions)
```
![{DE4F85C8-CF97-46F6-9D0E-C4C77955AF72}](https://github.com/user-attachments/assets/c194febe-4e21-4551-806c-53117c788fc1)

4. Identify customers who have no recorded transactions. 
```sql
SELECT c.customer_id, c.first_name, c.last_name
FROM Customers c
WHERE c.customer_id NOT IN (
    SELECT a.customer_id
    FROM Accounts a
    JOIN Transactions t ON a.account_id = t.account_id
)
```
![{9854FD8B-CC24-4C03-959C-C09E40ED56C5}](https://github.com/user-attachments/assets/8dfda8d8-da51-4489-af9a-4d2ab5a3ddb1)

5. Calculate the total balance of accounts with no recorded transactions. 
```sql
SELECT SUM(balance) AS total_balance
FROM Accounts
WHERE account_id NOT IN (
    SELECT account_id FROM Transactions
)
```
![{85642002-F34B-4719-B9B2-5D404AF55539}](https://github.com/user-attachments/assets/f801c680-bee7-40be-839c-5284f831f499)

6. Retrieve transactions for accounts with the lowest balance. 
```sql


SELECT t.*
FROM Transactions t
WHERE t.account_id IN (
    SELECT account_id
    FROM Accounts
    WHERE balance = (SELECT MIN(balance) FROM Accounts)
)

```
![{CBDA601A-CCE5-4CD6-AED2-7A14EEA6F4EB}](https://github.com/user-attachments/assets/210bd22d-e576-4737-b343-140d4d968389)

7. Identify customers who have accounts of multiple types. 
```sql
SELECT customer_id
FROM Accounts
GROUP BY customer_id
HAVING COUNT(DISTINCT account_type) > 1
```
![{EA40AF64-FD43-45E3-8B91-C60384180FC5}](https://github.com/user-attachments/assets/da22bb71-8d67-4378-b6db-8052032e9278)

8. Calculate the percentage of each account type out of the total number of accounts. 
```sql
SELECT account_type, 
       COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Accounts) AS percentage
FROM Accounts
GROUP BY account_type
```
![{D50CBECD-858E-4712-A9BC-8401D9AAD74B}](https://github.com/user-attachments/assets/c39b91a8-a0a9-43e0-ba57-a8ec1214ea29)

9. Retrieve all transactions for a customer with a given customer_id. 
```sql
SELECT t.*
FROM Transactions t
WHERE t.account_id IN (
    SELECT account_id
    FROM Accounts
    WHERE customer_id = 2
)

```
![{C33E19AD-76AF-40CC-BB42-81C9916EF7C5}](https://github.com/user-attachments/assets/de1bbc69-ab77-4605-a8ac-9f40b6d4c3b9)

10. Calculate the total balance for each account type, including a subquery within the SELECT 
clause.
```sql
SELECT DISTINCT account_type, 
       (SELECT SUM(balance) FROM Accounts a2 WHERE a2.account_type = a1.account_type) AS total_balance
FROM Accounts a1
```
![{029C392E-008F-4C6F-8DB8-CEBEA09BE72D}](https://github.com/user-attachments/assets/96f43959-7a56-4801-803f-f3169bff543e)
