-- Create Database
CREATE DATABASE TicketBookingSystem;

-- Create Tables
CREATE TABLE Venue (
    venue_id INT PRIMARY KEY,
    venue_name VARCHAR(100) NOT NULL,
    address NVARCHAR(255) NOT NULL
);

CREATE TABLE Event (
    event_id INT PRIMARY KEY,
    event_name VARCHAR(100) NOT NULL,
    event_date DATE NOT NULL,
    event_time TIME NOT NULL,
    venue_id INT NOT NULL,
    total_seats INT NOT NULL,
    available_seats INT NOT NULL,
    ticket_price DECIMAL(10, 2) NOT NULL,
    event_type NVARCHAR(50) CHECK (event_type IN ('Movie', 'Sports', 'Concert')),
    FOREIGN KEY (venue_id) REFERENCES Venue(venue_id)
);

CREATE TABLE Customer (
    customer_id INT PRIMARY KEY,
    customer_name NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    phone_number NVARCHAR(20) NOT NULL
);

CREATE TABLE Booking (
    booking_id INT PRIMARY KEY,
    customer_id INT NOT NULL,
    event_id INT NOT NULL,
    num_tickets INT NOT NULL,
    total_cost DECIMAL(10, 2) NOT NULL,
    booking_date DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (customer_id) REFERENCES Customer(customer_id),
    FOREIGN KEY (event_id) REFERENCES Event(event_id)
);

-- Insert Data
INSERT INTO Venue (venue_id, venue_name, address) VALUES
(1, 'Galaxy Cinemas', '10 Garp Avenue'),
(2, 'Champion Stadium', '21 Nami Lane'),
(3, 'Echo Auditorium', '77 Usopp Crescent');

INSERT INTO Event (event_id, event_name, event_date, event_time, venue_id, total_seats, available_seats, ticket_price, event_type) VALUES
(101, 'Avengers: Endgame', '2025-05-20', '19:00:00', 1, 250, 250, 1800, 'Movie'),
(102, 'India vs Australia', '2025-06-25', '18:30:00', 2, 60000, 60000, 2700, 'Sports'),
(103, 'Imagine Dragons Live', '2025-07-15', '20:00:00', 3, 1200, 1200, 2200, 'Concert');

INSERT INTO Customer (customer_id, customer_name, email, phone_number) VALUES
(201, 'Ankit', 'ankit@email.com', '9123456000'),
(202, 'Harsha', 'harsha@email.com', '9123456001'),
(203, 'Deepak', 'deepak@email.com', '9123456002'),
(204, 'Aisha', 'aisha@email.com', '9123456003'),
(205, 'Reema', 'reema@email.com', '9123456004'),
(206, 'Karan', 'karan@email.com', '9123456005'),
(207, 'Divya', 'divya@email.com', '9123456006'),
(208, 'Raghav', 'raghav@email.com', '9123456007'),
(209, 'Simran', 'simran@email.com', '9123456008'),
(210, 'Tarun', 'tarun@email.com', '9123456009');

INSERT INTO Booking (booking_id, customer_id, event_id, num_tickets, total_cost) VALUES
(301, 201, 101, 3, 5400),
(302, 202, 102, 4, 10800),
(303, 203, 103, 5, 11000),
(304, 204, 103, 2, 4400),
(305, 205, 101, 2, 3600),
(306, 206, 102, 7, 18900),
(307, 207, 103, 1, 2200),
(308, 208, 103, 3, 6600),
(309, 209, 101, 1, 1800),
(310, 210, 103, 2, 4400);


-- TASK 2

-- 1
SELECT * FROM Event;

-- 2
SELECT * FROM Event WHERE available_seats > 0;

-- 3
SELECT * FROM Event WHERE event_name LIKE '%vs%';

-- 4
SELECT * FROM Event WHERE ticket_price BETWEEN 1000 AND 2500;

-- 5
SELECT * FROM Event WHERE event_date BETWEEN '2025-05-01' AND '2025-08-01';

-- 6
SELECT * FROM Event WHERE available_seats > 0 AND event_type = 'Concert';

-- 7
SELECT * FROM Customer ORDER BY customer_id OFFSET 5 ROWS FETCH NEXT 5 ROWS ONLY;

-- 8
SELECT * FROM Booking WHERE num_tickets > 4;

-- 9
SELECT * FROM Customer WHERE phone_number LIKE '%000';

-- 10
SELECT * FROM Event WHERE total_seats > 15000 ORDER BY total_seats;

-- 11
SELECT * FROM Event WHERE event_name NOT LIKE 'x%' AND event_name NOT LIKE 'y%' AND event_name NOT LIKE 'z%';


-- TASK 3

-- 1
SELECT event_name, AVG(ticket_price) AS average_price FROM Event GROUP BY event_name;

-- 2
SELECT e.event_name, SUM(b.total_cost) AS total_revenue
FROM Booking b JOIN Event e ON b.event_id = e.event_id
GROUP BY e.event_name;

-- 3
SELECT TOP 1 e.event_name, SUM(b.num_tickets) AS total_tickets
FROM Booking b JOIN Event e ON b.event_id = e.event_id
GROUP BY e.event_name ORDER BY total_tickets DESC;

-- 4
SELECT e.event_name, SUM(b.num_tickets) AS total_tickets_sold
FROM Booking b JOIN Event e ON b.event_id = e.event_id
GROUP BY e.event_name;

-- 5
SELECT event_name FROM Event
WHERE event_id NOT IN (SELECT DISTINCT event_id FROM Booking);

-- 6
SELECT TOP 1 c.customer_name, SUM(b.num_tickets) AS total_tickets
FROM Booking b JOIN Customer c ON b.customer_id = c.customer_id
GROUP BY c.customer_name ORDER BY total_tickets DESC;

-- 7
SELECT FORMAT(booking_date, 'yyyy-MM') AS month, SUM(num_tickets) AS tickets_sold
FROM Booking GROUP BY FORMAT(booking_date, 'yyyy-MM');

-- 8
SELECT v.venue_name, AVG(e.ticket_price) AS average_price
FROM Event e JOIN Venue v ON e.venue_id = v.venue_id
GROUP BY v.venue_name;

-- 9
SELECT event_type, SUM(b.num_tickets) AS total_tickets
FROM Booking b JOIN Event e ON b.event_id = e.event_id
GROUP BY event_type;

-- 10
SELECT YEAR(booking_date) AS year, SUM(total_cost) AS total_revenue
FROM Booking GROUP BY YEAR(booking_date) ORDER BY year;

-- 11
SELECT c.customer_name, COUNT(DISTINCT b.event_id) AS events_booked
FROM Booking b JOIN Customer c ON b.customer_id = c.customer_id
GROUP BY c.customer_name HAVING COUNT(DISTINCT b.event_id) > 1;

-- 12
SELECT c.customer_name, SUM(b.total_cost) AS total_revenue
FROM Booking b JOIN Customer c ON b.customer_id = c.customer_id
GROUP BY c.customer_name;

-- 13
SELECT e.event_type, v.venue_name, AVG(e.ticket_price) AS average_price
FROM Event e JOIN Venue v ON e.venue_id = v.venue_id
GROUP BY e.event_type, v.venue_name;

-- 14
SELECT c.customer_name, SUM(b.num_tickets) AS total_tickets
FROM Booking b JOIN Customer c ON b.customer_id = c.customer_id
WHERE booking_date >= DATEADD(DAY, -30, GETDATE())
GROUP BY c.customer_name;


-- TASK 4

-- 1
SELECT v.venue_name, 
    (SELECT AVG(ticket_price) FROM Event WHERE venue_id = v.venue_id) AS average_ticket_price
FROM Venue v;

-- 2
SELECT event_name FROM Event WHERE (total_seats - available_seats) > (total_seats / 2);

-- 3
SELECT event_name,
    (SELECT SUM(num_tickets) FROM Booking WHERE event_id = e.event_id) AS total_tickets_sold
FROM Event e;

-- 4
SELECT customer_name FROM Customer c
WHERE NOT EXISTS (
    SELECT 1 FROM Booking b WHERE b.customer_id = c.customer_id
);

-- 5
SELECT event_name FROM Event
WHERE event_id NOT IN (
    SELECT DISTINCT event_id FROM Booking
);

-- 6
SELECT event_type, SUM(tickets_sold) AS total_tickets
FROM (
    SELECT e.event_type, b.num_tickets AS tickets_sold
    FROM Booking b JOIN Event e ON b.event_id = e.event_id
) AS sub
GROUP BY event_type;

-- 7
SELECT event_name, ticket_price FROM Event
WHERE ticket_price > (SELECT AVG(ticket_price) FROM Event);

-- 8
SELECT customer_name,
    (SELECT SUM(total_cost) FROM Booking WHERE customer_id = c.customer_id) AS total_revenue
FROM Customer c;

-- 9
SELECT customer_name FROM Customer c
WHERE EXISTS (
    SELECT 1 FROM Booking b 
    JOIN Event e ON b.event_id = e.event_id
    WHERE b.customer_id = c.customer_id AND e.venue_id = 1
);

-- 10
SELECT event_type,
    (SELECT SUM(b.num_tickets) FROM Booking b 
     JOIN Event e2 ON b.event_id = e2.event_id 
     WHERE e2.event_type = e.event_type) AS total_ticket
FROM Event e
GROUP BY event_type;

-- 11
SELECT DISTINCT c.customer_name, FORMAT(b.booking_date, 'yyyy-MM') AS booking_month
FROM Booking b JOIN Customer c ON b.customer_id = c.customer_id;

-- 12
SELECT venue_name, 
    (SELECT AVG(ticket_price) FROM Event WHERE venue_id = v.venue_id) AS average_price
FROM Venue v;
