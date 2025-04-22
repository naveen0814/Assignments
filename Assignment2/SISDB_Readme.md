# Task 1. Database Design:  
1. Create the database named "SISDB" 
```sql
CREATE DATABASE SISDB
GO
```
2. Define the schema for the Students, Courses, Enrollments, Teacher, and Payments tables based 
on the provided schema. Write SQL scripts to create the mentioned tables with appropriate data 
types, constraints, and relationships.  
a. Students  
b. Courses 
c. Enrollments  
d. Teacher  
e. Payments 
```sql

CREATE TABLE Students (
    student_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    date_of_birth DATE,
    email VARCHAR(100),
    phone_number VARCHAR(20)
)
CREATE TABLE Teacher (
    teacher_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100)
)
CREATE TABLE Courses (
    course_id INT PRIMARY KEY IDENTITY(1,1),
    course_name VARCHAR(100),
    credits INT,
    teacher_id INT,
    FOREIGN KEY (teacher_id) REFERENCES Teacher(teacher_id)
)
CREATE TABLE Enrollments (
    enrollment_id INT PRIMARY KEY IDENTITY(1,1),
    student_id INT,
    course_id INT,
    enrollment_date DATE,
    FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE
)
CREATE TABLE Payments (
    payment_id INT PRIMARY KEY IDENTITY(1,1),
    student_id INT,
    amount DECIMAL(10,2),
    payment_date DATE,
    FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE
)


```

3. Create an ERD (Entity Relationship Diagram) for the database. 

![{92BF6162-FB04-4051-AA2C-8B3C7B93855D}](https://github.com/user-attachments/assets/71e521a4-5167-4f89-8523-570df2fc283f)


4. Create appropriate Primary Key and Foreign Key constraints for referential integrity. 
```sql

CREATE TABLE Students (
    student_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    date_of_birth DATE,
    email VARCHAR(100),
    phone_number VARCHAR(20)
)
CREATE TABLE Teacher (
    teacher_id INT PRIMARY KEY IDENTITY(1,1),
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100)
)
CREATE TABLE Courses (
    course_id INT PRIMARY KEY IDENTITY(1,1),
    course_name VARCHAR(100),
    credits INT,
    teacher_id INT,
    FOREIGN KEY (teacher_id) REFERENCES Teacher(teacher_id)
)
CREATE TABLE Enrollments (
    enrollment_id INT PRIMARY KEY IDENTITY(1,1),
    student_id INT,
    course_id INT,
    enrollment_date DATE,
    FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE
)
CREATE TABLE Payments (
    payment_id INT PRIMARY KEY IDENTITY(1,1),
    student_id INT,
    amount DECIMAL(10,2),
    payment_date DATE,
    FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE
)


```

5. Insert at least 10 sample records into each of the following tables. 
i. 
ii. 
iii. 
Students  
Courses 
Enrollments  
iv. Teacher  
v. Payments
```sql

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
('Priya', 'Iyer', '1998-05-14', 'priya.iyer@example.com', '9876590123')

INSERT INTO Teacher (first_name, last_name, email)
VALUES 
('Ramesh', 'Krishnan', 'ramesh.krishnan@example.com'),
('Meena', 'Das', 'meena.das@example.com'),
('Vikram', 'Singh', 'vikram.singh@example.com')

INSERT INTO Courses (course_name, credits, teacher_id)
VALUES 
('C Programming Basics', 4, 1),
('Mathematics 101', 3, 2),
('Java Fundamentals', 4, 3),
('Advanced Database Management', 4, 1),
('Operating Systems Concepts', 3, 2)

INSERT INTO Enrollments (student_id, course_id, enrollment_date)
VALUES 
(1, 1, '2024-01-10'),
(1, 2, '2024-01-12'),
(2, 3, '2024-01-15'),
(3, 1, '2024-01-18'),
(4, 4, '2024-01-20'),
(5, 5, '2024-01-22'),
(6, 2, '2024-01-25'),
(7, 3, '2024-01-28'),
(8, 1, '2024-01-30'),
(9, 4, '2024-02-01')

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

```
# Tasks 2: Select, Where, Between, AND, LIKE:   

1. Write an SQL query to insert a new student into the "Students" table with the following details: 
a. First Name: John
b. Last Name: Doe 
c. Date of Birth: 1995-08-15 
d. Email: john.doe@example.com 
e. Phone Number: 1234567890 

```sql

INSERT INTO Students (first_name, last_name, date_of_birth, email, phone_number)
VALUES ('John', 'Doe', '1995-08-15', 'john.doe@example.com', '1234567890')

```
![{D3EC4FD5-B87B-4856-86B2-05011E954A6F}](https://github.com/user-attachments/assets/99b64dfa-312d-49cf-9796-f41048d23b56)

2. Write an SQL query to enroll a student in a course. Choose an existing student and course and 
insert a record into the "Enrollments" table with the enrollment date. 
```sql
INSERT INTO Enrollments (student_id, course_id, enrollment_date)
VALUES (11, 1, GETDATE())

```
![{5E2389AA-D0C3-43F3-A7B0-DEA2C531D8D4}](https://github.com/user-attachments/assets/611f81ed-4dbe-4801-b06f-f8baae289b1a)


3. Update the email address of a specific teacher in the "Teacher" table. Choose any teacher and 
modify their email address. 

```sql
update teacher
set email='ramesh@example.com'
where teacher_id=1


```
![{5B8E3276-7324-4E9E-AAA6-31291BE63BC5}](https://github.com/user-attachments/assets/5596ef2d-37d6-4dfe-80f1-65c318448247)

4. Write an SQL query to delete a specific enrollment record from the "Enrollments" table. Select 
an enrollment record based on the student and course. 


```sql
DELETE FROM Enrollments
WHERE student_id = 2 AND course_id = 3

```
![{A87071B1-E8FE-4F68-A9FD-D90CD3B88063}](https://github.com/user-attachments/assets/596b3be0-5e0a-4488-9496-a7556b686e65)

5. Update the "Courses" table to assign a specific teacher to a course. Choose any course and 
teacher from the respective tables. 


```sql
UPDATE Courses
SET teacher_id = 4
WHERE course_id = 4

```
![{3F05D270-69F6-43E2-B708-6CF9DDC59DEA}](https://github.com/user-attachments/assets/47a5b96f-0609-4b7e-b82b-85262831fe52)

6. Delete a specific student from the "Students" table and remove all their enrollment records 
from the "Enrollments" table. Be sure to maintain referential integrity. 


```sql
DELETE FROM Students
WHERE student_id = 5

```
![{C2D43656-BCE9-46CF-BE8E-2EDCDBFA2B79}](https://github.com/user-attachments/assets/e1c05d0d-5051-4a9d-ba7c-0b6a8a774fec)

7. Update the payment amount for a specific payment record in the "Payments" table. Choose any 
payment record and modify the payment amount. 
```sql
update Payments
set amount=600
where payment_id=1

```
![{20DDF630-9A84-4F38-9B44-12DF3790293F}](https://github.com/user-attachments/assets/84e74677-9131-4e67-9256-2cf2713fb87f)

# Task 3. Aggregate functions, Having, Order By, GroupBy and Joins:  


1. Write an SQL query to calculate the total payments made by a specific student. You will need to 
join the "Payments" table with the "Students" table based on the student's ID. 


```sql
SELECT 
    S.first_name, 
    S.last_name, 
    SUM(P.amount) AS total_payment
FROM 
    Students S
JOIN 
    Payments P ON S.student_id = P.student_id
WHERE 
    S.student_id = 1
GROUP BY 
    S.first_name, S.last_name

```
![{AB6AB538-264F-45C4-A3F2-F324DF56FE1F}](https://github.com/user-attachments/assets/7e25ce41-bc36-42ce-8641-8ace7d5805d1)

2. Write an SQL query to retrieve a list of courses along with the count of students enrolled in each 
course. Use a JOIN operation between the "Courses" table and the "Enrollments" table. 

```sql
SELECT 
    C.course_name, 
    COUNT(E.student_id) AS enrolled_students
FROM 
    Courses C
LEFT JOIN 
    Enrollments E ON C.course_id = E.course_id
GROUP BY 
    C.course_name

```
![{765523C5-4258-4FD1-A068-3BADF4027333}](https://github.com/user-attachments/assets/84f76986-11d1-442b-8c95-64ee8f834965)

3. Write an SQL query to find the names of students who have not enrolled in any course. Use a 
LEFT JOIN between the "Students" table and the "Enrollments" table to identify students 
without enrollments. 

```sql

SELECT 
    S.first_name, 
    S.last_name
FROM 
    Students S
LEFT JOIN 
    Enrollments E ON S.student_id = E.student_id
WHERE 
    E.enrollment_id IS NULL

```
![{85CB41F6-03F4-44AB-8AE6-5A849CCF8752}](https://github.com/user-attachments/assets/59a2d465-63ff-4f4c-96f2-036b90ff5b9c)

4. Write an SQL query to retrieve the first name, last name of students, and the names of the 
courses they are enrolled in. Use JOIN operations between the "Students" table and the 
"Enrollments" and "Courses" tables. 

```sql
SELECT 
    S.first_name, 
    S.last_name, 
    C.course_name
FROM 
    Students S
JOIN 
    Enrollments E ON S.student_id = E.student_id
JOIN 
    Courses C ON E.course_id = C.course_id

```
![{0F5A89FB-4F55-4440-A748-E0D0CA9D846E}](https://github.com/user-attachments/assets/6eb4db3d-8f6a-43ab-a31c-b683ff5d095e)

5. Create a query to list the names of teachers and the courses they are assigned to. Join the 
"Teacher" table with the "Courses" table. 

```sql
SELECT 
    T.first_name, 
    T.last_name, 
    C.course_name
FROM 
    Teacher T
JOIN 
    Courses C ON T.teacher_id = C.teacher_id

```
![{B714FEB5-8F11-4F92-B200-86BD2C32A7B1}](https://github.com/user-attachments/assets/9127b6d9-2196-4420-80f3-835360be76ec)

6. Retrieve a list of students and their enrollment dates for a specific course. You'll need to join the 
"Students" table with the "Enrollments" and "Courses" tables. 

```sql

SELECT 
    S.first_name, 
    S.last_name, 
    E.enrollment_date
FROM 
    Students S
JOIN 
    Enrollments E ON S.student_id = E.student_id
WHERE 
    E.course_id = 1

```
![{AA5AEC19-96FA-4501-954B-B669B6B139AC}](https://github.com/user-attachments/assets/86a121e6-6914-4984-b1c3-5af2f9651ed4)

7. Find the names of students who have not made any payments. Use a LEFT JOIN between the 
"Students" table and the "Payments" table and filter for students with NULL payment records. 

```sql
SELECT 
    S.first_name, 
    S.last_name
FROM 
    Students S
LEFT JOIN 
    Payments P ON S.student_id = P.student_id
WHERE 
    P.payment_id IS NULL

```
![{1B671143-A09C-45FF-A537-82B8B5B2DD34}](https://github.com/user-attachments/assets/5ad94089-b466-4ef9-8f92-83bbe0fb4c37)

8. Write a query to identify courses that have no enrollments. You'll need to use a LEFT JOIN 
between the "Courses" table and the "Enrollments" table and filter for courses with NULL 
enrollment records.
```sql
SELECT 
    C.course_name
FROM 
    Courses C
LEFT JOIN 
    Enrollments E ON C.course_id = E.course_id
WHERE 
    E.enrollment_id IS NULL
```
![{E4AD1CE0-CE5F-4D11-ACD6-C4E4591CAFA8}](https://github.com/user-attachments/assets/05714ef4-14ed-4ec3-9109-30379a4f36b2)

9. Identify students who are enrolled in more than one course. Use a self-join on the "Enrollments" 
table to find students with multiple enrollment records. 
```sql

SELECT 
    S.first_name, 
    S.last_name, 
    COUNT(E.course_id) AS course_count
FROM 
    Students S
JOIN 
    Enrollments E ON S.student_id = E.student_id
GROUP BY 
    S.first_name, S.last_name
HAVING 
    COUNT(E.course_id) > 1
```
![{C164016F-0341-425B-9D6D-23561190BC14}](https://github.com/user-attachments/assets/d60db52c-ec5c-4b96-a0ca-4fc519d273a0)



10. Find teachers who are not assigned to any courses. Use a LEFT JOIN between the "Teacher" 
table and the "Courses" table and filter for teachers with NULL course assignments. 
```sql
SELECT 
    T.first_name, 
    T.last_name
FROM 
    Teacher T
LEFT JOIN 
    Courses C ON T.teacher_id = C.teacher_id
WHERE 
    C.course_id IS NULL
```
![{EF3E0424-820E-4D8B-A829-20021152F0D6}](https://github.com/user-attachments/assets/6aa9553c-3c7f-400e-985a-6a75bcac683d)

# Task 4. Subquery and its type:  
1. Write an SQL query to calculate the average number of students enrolled in each course. Use 
aggregate functions and subqueries to achieve this.

```sql
SELECT 
    AVG(student_count) AS avg_students_per_course
FROM 
    (SELECT 
        course_id, 
        COUNT(student_id) AS student_count
     FROM 
        Enrollments
     GROUP BY 
        course_id) AS CourseCounts

```
![{EA3A6CF7-A40A-4B8D-AAAB-D7117FFDCFCF}](https://github.com/user-attachments/assets/1af8981a-3057-42f6-9974-a7bc2b10e933)


2. Identify the student(s) who made the highest payment. Use a subquery to find the maximum 
payment amount and then retrieve the student(s) associated with that amount. 

```sql
	SELECT 
		S.first_name, 
		S.last_name, 
		P.amount
	FROM 
		Payments P
	JOIN 
		Students S ON P.student_id = S.student_id
	WHERE 
		P.amount = (SELECT MAX(amount) FROM Payments)

```
![{BF61D914-2195-46C2-84C6-AE9042F81805}](https://github.com/user-attachments/assets/eff9696e-240c-4436-b548-89bd412ea748)


3. Retrieve a list of courses with the highest number of enrollments. Use subqueries to find the 
course(s) with the maximum enrollment count. 

```sql

SELECT 
    C.course_name, 
    COUNT(E.student_id) AS total_enrollments
FROM 
    Courses C
JOIN 
    Enrollments E ON C.course_id = E.course_id
GROUP BY 
    C.course_name
HAVING 
    COUNT(E.student_id) = 
    (SELECT MAX(course_enrollments) 
     FROM 
        (SELECT COUNT(student_id) AS course_enrollments 
         FROM Enrollments 
         GROUP BY course_id) AS EnrollmentCounts)

```
![{DB7B3388-09AC-43BD-AF2F-67CD985312D4}](https://github.com/user-attachments/assets/2a257b89-a4d8-4f89-bfc6-26f7ade52796)


4. Calculate the total payments made to courses taught by each teacher. Use subqueries to sum 
payments for each teacher's courses. 

```sql
SELECT 
    T.first_name, 
    T.last_name, 
    SUM(P.amount) AS total_payments
FROM 
    Teacher T
JOIN 
    Courses C ON T.teacher_id = C.teacher_id
JOIN 
    Enrollments E ON C.course_id = E.course_id
JOIN 
    Payments P ON E.student_id = P.student_id
GROUP BY 
    T.first_name, T.last_name

```
![{920F10A3-FB0E-473F-AED4-9041682EA5B4}](https://github.com/user-attachments/assets/aadd5db8-75e4-4278-aabc-d93008ed38ca)


5. Identify students who are enrolled in all available courses. Use subqueries to compare a 
student's enrollments with the total number of courses. 

```sql

SELECT 
    S.first_name, 
    S.last_name
FROM 
    Students S
WHERE 
    (SELECT COUNT(DISTINCT course_id) FROM Enrollments WHERE student_id = S.student_id) 
    = 
    (SELECT COUNT(course_id) FROM Courses)

```
![{14A18960-F16A-4B0E-9699-E8EF34DF8ABC}](https://github.com/user-attachments/assets/f7560d51-c29b-4df0-ada8-e373d6d0a24a)


6. Retrieve the names of teachers who have not been assigned to any courses. Use subqueries to 
find teachers with no course assignments. 

```sql

SELECT 
    first_name, 
    last_name
FROM 
    Teacher
WHERE 
    teacher_id NOT IN (SELECT DISTINCT teacher_id FROM Courses WHERE teacher_id IS NOT NULL)

```
![{B6AB5EE3-8AA1-42FE-80DC-A7956639D653}](https://github.com/user-attachments/assets/8ec49c7a-5368-4f7a-8224-8912f270d1a1)



7. Calculate the average age of all students. Use subqueries to calculate the age of each student 
based on their date of birth. 

```sql
SELECT 
    AVG(DATEDIFF(YEAR, date_of_birth, GETDATE())) AS average_age
FROM 
    Students

```

![{B64047B0-86F7-4BBB-9332-349AEB32C3A6}](https://github.com/user-attachments/assets/0e3ee95a-90e2-48a9-8e96-c0b90486a7c7)

8. Identify courses with no enrollments. Use subqueries to find courses without enrollment 
records. 

```sql

SELECT 
    course_name
FROM 
    Courses
WHERE 
    course_id NOT IN (SELECT DISTINCT course_id FROM Enrollments)

```
![{14D69B15-F8F5-4B51-9270-8A7E1845B5E8}](https://github.com/user-attachments/assets/e0c5c682-de37-45c2-b972-ee6bd06619e5)


9. Calculate the total payments made by each student for each course they are enrolled in. Use 
subqueries and aggregate functions to sum payments. 

```sql

SELECT 
    S.first_name, 
    S.last_name, 
    C.course_name, 
    (SELECT SUM(P.amount) 
     FROM Payments P 
     WHERE P.student_id = S.student_id) AS total_payment
FROM 
    Students S
JOIN 
    Enrollments E ON S.student_id = E.student_id
JOIN 
    Courses C ON E.course_id = C.course_id

```
![{6F433F8E-DEE0-4396-8A6F-88328BB7B0A2}](https://github.com/user-attachments/assets/c5c61b4c-6e31-41ad-9fd4-754881015c27)


10. Identify students who have made more than one payment. Use subqueries and aggregate 
functions to count payments per student and filter for those with counts greater than one. 

```sql
SELECT 
    S.first_name, 
    S.last_name, 
    COUNT(P.payment_id) AS payment_count
FROM 
    Students S
JOIN 
    Payments P ON S.student_id = P.student_id
GROUP BY 
    S.first_name, S.last_name
HAVING 
    COUNT(P.payment_id) > 1

```
![{FFC65068-EB47-4E78-BFDC-698297E09968}](https://github.com/user-attachments/assets/08ba90b2-72f8-4c4b-9a66-29cf6f387d28)


11. Write an SQL query to calculate the total payments made by each student. Join the "Students" 
table with the "Payments" table and use GROUP BY to calculate the sum of payments for each 
student. 

```sql

SELECT 
    S.first_name, 
    S.last_name, 
    SUM(P.amount) AS total_payment
FROM 
    Students S
LEFT JOIN 
    Payments P ON S.student_id = P.student_id
GROUP BY 
    S.first_name, S.last_name

```
![{A3B0662A-0EAA-415C-A735-9F6214201810}](https://github.com/user-attachments/assets/d69d60c8-681e-43b8-8547-bd53b66e4add)


12. Retrieve a list of course names along with the count of students enrolled in each course. Use 
JOIN operations between the "Courses" table and the "Enrollments" table and GROUP BY to 
count enrollments. 

```sql

SELECT 
    C.course_name, 
    COUNT(E.student_id) AS enrolled_students
FROM 
    Courses C
LEFT JOIN 
    Enrollments E ON C.course_id = E.course_id
GROUP BY 
    C.course_name

```
![{D710E05C-333F-4FCE-A780-1CEE1DE24510}](https://github.com/user-attachments/assets/000f0cf4-826d-4e2c-b565-a6b9ed54ec53)


13. Calculate the average payment amount made by students. Use JOIN operations between the 
"Students" table and the "Payments" table and GROUP BY to calculate the average.

```sql


SELECT 
    C.course_name, 
    COUNT(E.student_id) AS enrolled_students
FROM 
    Courses C
LEFT JOIN 
    Enrollments E ON C.course_id = E.course_id
GROUP BY 
    C.course_name

SELECT 
    AVG(P.amount) AS avg_payment
FROM 
    Payments P

```
![{1C55CA85-C19E-4C97-B65F-B32D51858D0D}](https://github.com/user-attachments/assets/e80f64b1-b2a1-44e0-8dc2-d9b4ddc255d3)

