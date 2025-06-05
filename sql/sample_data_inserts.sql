--Insert admin 
INSERT INTO admin_table VALUES (1, 'Admin', '123'); 
INSERT INTO admin_table VALUES (2, 'Admin2', '456');
-- Insert Users 
INSERT INTO User_table VALUES (1, 'john_doe', 'pass123', 1234567); 
INSERT INTO User_table VALUES (2, 'jane_smith', 'secret456', 7654321);
-- Insert Cars 
INSERT INTO Car_table VALUES (100, 30000, 'Toyota Corolla', 0); 
INSERT INTO Car_table VALUES (101, 45000, 'Honda Civic', 0); 
INSERT INTO Car_table VALUES (102, 55000, 'Tesla Model 3', 1);
-- Insert Rental 
INSERT INTO Rental_table VALUES (
1, 102, 1, 
TO_DATE ('2025-04-01', 'YYYY-MM-DD'), 
TO_DATE('2025-04-10', 'YYYY-MM-DD')
);

