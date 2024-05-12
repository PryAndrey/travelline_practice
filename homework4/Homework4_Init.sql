IF NOT EXISTS (SELECT*FROM sysobjects WHERE name='rooms')
CREATE TABLE dbo.rooms (
	room_id INT IDENTITY(1,1) NOT NULL,
	room_number INT NOT NULL,
	room_type NVARCHAR(50) NOT NULL,
	price_per_night MONEY NOT NULL,
	availability BIT NOT NULL,
	CONSTRAINT PK_rooms_id_room PRIMARY KEY(room_id)
	)

IF NOT EXISTS ( SELECT * FROM sysobjects WHERE name ='customers')
CREATE TABLE dbo.customers(
	 customer_id INT IDENTITY(1,1) NOT NULL,
	 first_name NVARCHAR(50) NOT NULL,
	 last_name NVARCHAR(50) NOT NULL,
	 email NVARCHAR(100) NOT NULL,
     	 phone_number NVARCHAR(30) NOT NULL,
	 CONSTRAINT PK_customers_id_customer PRIMARY KEY(customer_id)
	)

IF NOT EXISTS ( SELECT * FROM sysobjects WHERE name ='bookings')
CREATE TABLE dbo.bookings(
	 booking_id INT IDENTITY(1,1) NOT NULL,
	 customer_id INT NOT NULL,
	 room_id INT NOT NULL,
	 check_in_date DATE NOT NULL,
     	 check_out_date DATE NOT NULL,
	 CONSTRAINT PK_bookings_id_booking PRIMARY KEY(booking_id),
	 CONSTRAINT FK_bookings_id_customer FOREIGN KEY (customer_id) REFERENCES dbo.customers (customer_id),
	 CONSTRAINT FK_bookings_id_room	FOREIGN KEY (room_id) REFERENCES dbo.rooms (room_id)
	)

IF NOT EXISTS ( SELECT * FROM sysobjects WHERE name ='facilities')
CREATE TABLE dbo.facilities(
	 facility_id INT IDENTITY(1,1) NOT NULL,
	 facility_name NVARCHAR(50) NOT NULL,
	 CONSTRAINT PK_facilities_id_facility PRIMARY KEY(facility_id)
	)

IF NOT EXISTS ( SELECT * FROM sysobjects WHERE name ='room_to_facilities')
CREATE TABLE dbo.room_to_facilities(
	 room_id INT NOT NULL,
	 facility_id INT NOT NULL,
	 CONSTRAINT PK_room_to_facilities_id_room_id_facilities PRIMARY KEY(room_id, facility_id),
	 CONSTRAINT FK_room_to_facilities_id_room
		FOREIGN KEY (room_id) REFERENCES dbo.rooms(room_id),
	 CONSTRAINT FK_room_to_facilities_id_facilities
		FOREIGN KEY (facility_id) REFERENCES dbo.facilities(facility_id)
	)


INSERT INTO dbo.rooms (room_number, room_type, price_per_night, availability)
VALUES
	(62, N'one-room', 2000.00, 1),
	(63, N'two-room', 3000.00, 0),
	(64, N'three-room', 4000.00, 0),
	(65, N'one-room', 2000.00, 0),
    	(66, N'two-room', 3000.00, 0),
    	(67, N'three-room', 4000.00, 1),
    	(68, N'one-room', 2000.00, 1),
    	(69, N'two-room', 1000.00, 1),
    	(70, N'three-room', 4000.00, 1),
    	(71, N'one-room', 4000.00, 1),
    	(72, N'two-room', 3000.00, 0),
    	(73, N'three-room', 4000.00, 0),
    	(74, N'one-room', 6000.00, 0),
    	(75, N'two-room', 7000.00, 1),
    	(76, N'three-room', 8000.00, 1),
	(77, N'one-room', 3000.00, 0),
	(78, N'two-room', 4000.00, 0),	
	(79, N'three-room', 5000.00, 1)

INSERT INTO dbo.customers (first_name, last_name, email, phone_number)
VALUES
    (N'John', N'Doe', N'johndoe@gmail.com', N'+7 (495) 123-45-67'),
	(N'Katherine', N'Smith', N'katherinesmith@mail.ru', N'+7 (812) 987-65-43'),
	(N'Alexander', N'Johnson', N'alexanderjohnson@yahoo.com', N'+7 (3832) 345-67-89'),
	(N'Maria', N'Williams', N'mariawilliams@hotmail.com', N'+7 (495) 678-90-12'),
	(N'Dmitry', N'Sokolov', N'dmitrysokolov@outlook.com', N'+7 (8432) 456-78-90'),
	(N'Anna', N'Kuznetsova', N'annakuznetsova@mail.ru', N'+7 (495) 111-22-33'),
	(N'Maxim', N'Fedorov', N'maximfedorov@yahoo.com', N'+7 (812) 444-55-66'),
	(N'Elena', N'Solovieva', N'elenasolovieva@gmail.com', N'+7 (3832) 777-88-99'),
	(N'Sergey', N'Pavlov', N'sergeypavlov@hotmail.com', N'+7 (495) 999-00-11');

INSERT INTO dbo.bookings (customer_id, room_id, check_in_date, check_out_date)
VALUES
    	(1, 1, '2024-04-15', '2024-05-08'),
    	(2, 3, '2024-04-26', '2024-05-12'),
    	(3, 4, '2024-04-12', '2024-05-11'),
    	(4, 5, '2024-04-28', '2024-05-15'),
    	(5, 7, '2024-04-16', '2024-05-17'),
    	(6, 8, '2024-04-19', '2024-05-28'),
    	(7, 10,'2024-04-25', '2024-05-20'),
    	(8, 12,'2024-04-21', '2024-05-14'),
    	(9, 13,'2024-04-29', '2024-05-15')

INSERT INTO dbo.facilities (facility_name)
VALUES
	(N'Wifi'),
	(N'Minibar'),
	(N'Conditioner'),
	(N'Amaizing view'),
	(N'Jacuzzi'),
	(N'Hairdryer'),
	(N'Wake-up service'),
	(N'Dry cleaning service'),
	(N'Pets allowed');

INSERT INTO dbo.room_to_facilities (room_id, facility_id)
VALUES
	(1,1), 
	(1,3), 
	(1,7),
	(2,2), 
	(2,3), 
	(2,4),
	(3,1), 
	(3,4), 
	(3,6),
	(3,8),
	(4,1), 
	(4,9), 
	(5,3), 
	(5,6), 
	(5,8),
	(6,1), 
	(6,8),
	(7,1), 
	(7,5),
	(8,4),
	(9,1), 
	(9,4), 
	(9,7),
	(10,2), 
	(10,3), 
	(10,5), 
	(10,6),
	(11,1),
	(12,1),
	(13,2), 
	(13,5),
	(14,1), 
	(14,9),
	(15,2), 
	(15,3), 
	(15,7),
	(16,1), 
	(16,2), 
	(16,3), 
	(16,4), 
	(16,5), 
	(16,6), 
	(16,7), 
	(16,8), 
	(16,9),
	(17,3), 
	(17,4), 
	(17,5), 
	(17,6), 
	(17,7), 
	(17,8), 
	(17,9),
	(18,1), 
	(18,2), 
	(18,3), 
	(18,4),
	(18,5),
	(18,6),
	(18,7), 
	(18,8), 
	(18,9);
