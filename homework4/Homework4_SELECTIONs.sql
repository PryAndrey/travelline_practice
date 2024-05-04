SELECT rooms.* FROM rooms
	JOIN bookings ON bookings.room_id = rooms.room_id
WHERE (GETDATE() NOT BETWEEN bookings.check_in_date AND bookings.check_out_date ) AND availability = 1

SELECT * FROM customers
WHERE last_name LIKE 'S%';

SELECT bookings.* FROM bookings
	JOIN customers ON bookings.customer_id = customers.customer_id
WHERE customers.first_name = N'John' OR customers.email = N'johndoe@gmail.com';

SELECT bookings.* FROM bookings
	JOIN rooms ON bookings.customer_id = rooms.room_id
WHERE rooms.room_number = 64;

SELECT rooms.* FROM rooms
WHERE room_id IN 
	(SELECT room_id FROM bookings
	 WHERE rooms.[availability] = 1 
		AND '2024-05-15' NOT BETWEEN bookings.check_in_date AND bookings.check_out_date);

SELECT * FROM rooms
WHERE 
(rooms.room_id NOT IN (SELECT room_id FROM bookings))
	OR (rooms.room_id IN 
	(SELECT room_id FROM bookings
		WHERE rooms.[availability] = 1
		AND '2024-05-15' NOT BETWEEN bookings.check_in_date AND bookings.check_out_date));
