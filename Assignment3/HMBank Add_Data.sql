
INSERT INTO Customers (first_name, last_name, DOB, email, phone_number, address)
VALUES 
('John', 'Doe', '1990-01-15', 'john.doe@example.com', '1234567890', 'New York'),
('Jane', 'Smith', '1985-06-20', 'jane.smith@example.com', '2345678901', 'Los Angeles'),
('Alice', 'Brown', '1992-09-10', 'alice.brown@example.com', '3456789012', 'Chicago'),
('Bob', 'Taylor', '1978-03-25', 'bob.taylor@example.com', '4567890123', 'Houston'),
('Carol', 'Johnson', '1995-11-11', 'carol.johnson@example.com', '5678901234', 'Phoenix'),
('David', 'Lee', '1988-12-30', 'david.lee@example.com', '6789012345', 'San Antonio'),
('Eva', 'White', '1991-07-05', 'eva.white@example.com', '7890123456', 'San Diego'),
('Frank', 'Green', '1983-04-19', 'frank.green@example.com', '8901234567', 'Dallas'),
('Grace', 'Hall', '1975-08-29', 'grace.hall@example.com', '9012345678', 'San Jose'),
('Henry', 'King', '1993-10-23', 'henry.king@example.com', '0123456789', 'Austin')

INSERT INTO Accounts (customer_id, account_type, balance)
VALUES
(1, 'savings', 2500),
(2, 'current', 5000),
(3, 'savings', 1000),
(4, 'zero_balance', 0),
(5, 'current', 3000),
(6, 'savings', 1500),
(7, 'current', 1200),
(8, 'zero_balance', 0),
(9, 'savings', 4000),
(10, 'current', 2500)

INSERT INTO Transactions (account_id, transaction_type, amount, transaction_date)
VALUES
(1, 'deposit', 500, '2024-03-01'),
(1, 'withdrawal', 200, '2024-03-05'),
(2, 'deposit', 1000, '2024-03-02'),
(3, 'withdrawal', 100, '2024-03-06'),
(4, 'deposit', 300, '2024-03-04'),
(5, 'withdrawal', 500, '2024-03-07'),
(6, 'deposit', 700, '2024-03-03'),
(7, 'withdrawal', 400, '2024-03-08'),
(8, 'deposit', 600, '2024-03-09'),
(9, 'withdrawal', 150, '2024-03-10')
