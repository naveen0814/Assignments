CREATE DATABASE HMBank
USE HMBank

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



  
select * from customers
select * from Accounts
select * from Transactions

SELECT first_name, last_name, account_type, email
FROM Customers
JOIN Accounts ON Customers.customer_id = Accounts.customer_id


SELECT t.transaction_id, t.transaction_type, t.amount, c.first_name, c.last_name
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id
JOIN Customers c ON a.customer_id = c.customer_id



UPDATE Accounts
SET balance = balance + 500
WHERE account_id = 2
select * from Accounts


SELECT CONCAT(first_name, ' ', last_name) AS full_name FROM Customers


DELETE FROM Accounts
WHERE balance = 0 AND account_type = 'savings'


SELECT * FROM Customers
WHERE address = 'Dallas'


SELECT balance FROM Accounts
WHERE account_id = 3



SELECT * FROM Accounts
WHERE account_type = 'current' AND balance > 1000


SELECT * FROM Transactions
WHERE account_id = 1



SELECT account_id, balance, balance * 0.05 AS interest
FROM Accounts
WHERE account_type = 'savings'


SELECT * FROM Accounts
WHERE balance < 500


SELECT * FROM Customers
WHERE address != 'Dallas'


SELECT AVG(balance) AS avg_balance FROM Accounts


SELECT TOP 10 * FROM Accounts
ORDER BY balance DESC


SELECT SUM(amount) AS total_deposit
FROM Transactions
WHERE transaction_type = 'deposit' AND transaction_date = '2024-03-02'


SELECT TOP 1 * FROM Customers
ORDER BY DOB ASC

SELECT TOP 1 * FROM Customers
ORDER BY DOB DESC


SELECT t.*, a.account_type
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id


SELECT c.*, a.account_id, a.account_type, a.balance
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id


SELECT t.*, c.first_name, c.last_name
FROM Transactions t
JOIN Accounts a ON t.account_id = a.account_id
JOIN Customers c ON a.customer_id = c.customer_id
WHERE a.account_id = 1


SELECT customer_id, COUNT(account_id) AS account_count
FROM Accounts
GROUP BY customer_id
HAVING COUNT(account_id) > 1


SELECT 
    SUM(CASE WHEN transaction_type = 'deposit' THEN amount ELSE 0 END) -
    SUM(CASE WHEN transaction_type = 'withdrawal' THEN amount ELSE 0 END) AS difference
FROM Transactions



SELECT account_id, AVG(balance) AS avg_daily_balance
FROM Accounts
GROUP BY account_id


SELECT account_type, SUM(balance) AS total_balance
FROM Accounts
GROUP BY account_type


SELECT a.account_id, COUNT(t.transaction_id) AS txn_count
FROM Accounts a
JOIN Transactions t ON a.account_id = t.account_id
GROUP BY a.account_id
ORDER BY txn_count DESC


SELECT c.first_name, c.last_name, a.account_type, SUM(a.balance) AS total_balance
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id
GROUP BY c.first_name, c.last_name, a.account_type
HAVING SUM(a.balance) > 3000



SELECT account_id, amount, transaction_date, COUNT(*) AS dup_count
FROM Transactions
GROUP BY account_id, amount, transaction_date
HAVING COUNT(*) > 1


SELECT c.first_name, c.last_name, a.balance
FROM Customers c
JOIN Accounts a ON c.customer_id = a.customer_id
WHERE a.balance = (SELECT MAX(balance) FROM Accounts)

SELECT AVG(balance) AS avg_balance
FROM Accounts
WHERE customer_id IN (
    SELECT customer_id
    FROM Accounts
    GROUP BY customer_id
    HAVING COUNT(account_id) > 1
)


SELECT DISTINCT a.account_id, a.account_type
FROM Accounts a
JOIN Transactions t ON a.account_id = t.account_id
WHERE t.amount > (SELECT AVG(amount) FROM Transactions)

SELECT c.customer_id, c.first_name, c.last_name
FROM Customers c
WHERE c.customer_id NOT IN (
    SELECT a.customer_id
    FROM Accounts a
    JOIN Transactions t ON a.account_id = t.account_id
)



SELECT SUM(balance) AS total_balance
FROM Accounts
WHERE account_id NOT IN (
    SELECT account_id FROM Transactions
)


SELECT t.*
FROM Transactions t
WHERE t.account_id IN (
    SELECT account_id
    FROM Accounts
    WHERE balance = (SELECT MIN(balance) FROM Accounts)
)


SELECT customer_id
FROM Accounts
GROUP BY customer_id
HAVING COUNT(DISTINCT account_type) > 1


SELECT account_type, 
       COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Accounts) AS percentage
FROM Accounts
GROUP BY account_type


SELECT t.*
FROM Transactions t
WHERE t.account_id IN (
    SELECT account_id
    FROM Accounts
    WHERE customer_id = 2
)


SELECT DISTINCT account_type, 
       (SELECT SUM(balance) FROM Accounts a2 WHERE a2.account_type = a1.account_type) AS total_balance
FROM Accounts a1
