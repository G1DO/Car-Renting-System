CREATE TABLE User_table (
    userID NUMBER PRIMARY KEY,
    username VARCHAR2(50),
    password VARCHAR2(50),
    license_number NUMBER
);
 
CREATE TABLE Car_table (
    CarID NUMBER PRIMARY KEY,
    Cost NUMBER,
    Model VARCHAR2(50),
    IS_Rented NUMBER(1) -- 0 = not rented, 1 = rented
);
 
CREATE TABLE Rental_table (
    RentalID NUMBER PRIMARY KEY,
    CarID NUMBER,
    userID NUMBER,
    Rental_Startdate DATE,
    Rental_Enddate DATE,
    FOREIGN KEY (CarID) REFERENCES Car_table(CarID),
    FOREIGN KEY (userID) REFERENCES User_table(userID)
);
CREATE TABLE Payment_table (
    PaymentID NUMBER PRIMARY KEY,
    RentalID NUMBER,
    Payment_Date DATE,
    Payment_Method VARCHAR2(30),
    FOREIGN KEY (RentalID) REFERENCES Rental_table(RentalID)
);

CREATE TABLE Rating_table (
    RatingID NUMBER PRIMARY KEY,
    RentalID NUMBER,
    Rating NUMBER CHECK (Rating BETWEEN 1 AND 5),
    FOREIGN KEY (RentalID) REFERENCES Rental_table(RentalID)
);

CREATE TABLE admin_table (
    adminID NUMBER PRIMARY KEY,
    adminname VARCHAR2(50),
    password VARCHAR2(50)
);




