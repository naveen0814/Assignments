
INSERT INTO Teacher (first_name, last_name, email)
VALUES 
('Ramesh', 'Krishnan', 'ramesh.krishnan@example.com'),
('Meena', 'Das', 'meena.das@example.com'),
('Vikram', 'Singh', 'vikram.singh@example.com'),
('Deepa', 'Shah', 'deepa.shah@example.com'),
('Arjun', 'Mishra', 'arjun.mishra@example.com'),
('Lakshmi', 'Nair', 'lakshmi.nair@example.com'),
('Amit', 'Verma', 'amit.verma@example.com'),
('Kiran', 'Chowdhury', 'kiran.chowdhury@example.com'),
('Pooja', 'Saxena', 'pooja.saxena@example.com'),
('Sanjay', 'Gupta', 'sanjay.gupta@example.com');

INSERT INTO Courses (course_name, credits, teacher_id)
VALUES 
('C Programming Basics', 4, 1),
('Mathematics 101', 3, 2),
('Java Fundamentals', 4, 3),
('Advanced Database Management', 4, 4),
('Operating Systems Concepts', 3, 5),
('Data Structures', 4, 6),
('Cloud Computing', 3, 7),
('Web Development', 4, 8),
('Machine Learning', 3, 9),
('Cyber Security', 4, 10);

INSERT INTO Students (first_name, last_name, date_of_birth, email, phone_number)
VALUES 
('Naveen', 'Kumar', '1995-08-15', 'naveen.kumar@example.com', '9876543210'),
('Venkat', 'Rao', '1996-02-10', 'venkat.rao@example.com', '9876512345'),
('Suresh', 'Patel', '1997-03-22', 'suresh.patel@example.com', '9876523456'),
('Vasanth', 'Menon', '1998-04-18', 'vasanth.menon@example.com', '9876534567'),
('Surya', 'Nair', '1994-12-05', 'surya.nair@example.com', '9876545678'),
('Nitesh', 'Yadav', '1993-09-13', 'nitesh.yadav@example.com', '9876556789'),
('Ajith', 'Khan', '1995-07-29', 'ajith.khan@example.com', '9876567890'),
('Vijay', 'Reddy', '1996-11-21', 'vijay.reddy@example.com', '9876578901'),
('Anjali', 'Sharma', '1997-01-30', 'anjali.sharma@example.com', '9876589012'),
('Priya', 'Iyer', '1998-05-14', 'priya.iyer@example.com', '9876590123');

INSERT INTO Enrollments (student_id, course_id, enrollment_date)
VALUES 
(1, 1, '2024-01-10'),
(1, 2, '2024-01-12'),
(2, 3, '2024-01-15'),
(3, 4, '2024-01-18'),
(4, 5, '2024-01-20'),
(5, 6, '2024-01-22'),
(6, 7, '2024-01-25'),
(7, 8, '2024-01-28'),
(8, 9, '2024-01-30'),
(9, 10, '2024-02-01');

INSERT INTO Payments (student_id, amount, payment_date)
VALUES 
(1, 500.00, '2024-02-10'),
(2, 300.00, '2024-02-11'),
(3, 450.00, '2024-02-12'),
(4, 400.00, '2024-02-13'),
(5, 350.00, '2024-02-14'),
(6, 600.00, '2024-02-15'),
(7, 550.00, '2024-02-16'),
(8, 500.00, '2024-02-17'),
(9, 300.00, '2024-02-18'),
(10, 700.00, '2024-02-19')
