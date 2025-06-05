Create or replace PROCEDURE CHECKADMINNAME (
 name1 varchar2 , 
password1 varchar2 , 
id2 out number
)
AS 
BEGIN 
Select adminID into id2 
from admin_table 
where adminname = name1 and password = password1; 
EXCEPTION 
WHEN NO_DATA_FOUND THEN 
Id2:=-1; 
END CHECKADMINNAME;









Create or replace PROCEDURE CHECKUSERNAME ( 
name1 varchar2 , 
password1 varchar2 , 
id2 out number
) 
AS 
BEGIN 
select userID into id2 
from user_table 
where username = name1 and password = password1; 
EXCEPTION 
WHEN NO_DATA_FOUND THEN 
id2:=-1; 
END CHECKUSERNAME;

Create or replace PROCEDURE CREATE_ID (
new_id out number
) 
AS 
BEGIN 
Select max(rentalid) Into new_id From rental_table; 
EXCEPTION 
WHEN NO_DATA_FOUND THEN 
New_id:=-1; 
END CREATE_ID;


Create or replace PROCEDURE CREATE_RATE_ID (
new_id out number
) 
AS 
BEGIN 
Select max(ratingid) Into new_id From rating_table; 
EXCEPTION 
WHEN NO_DATA_FOUND THEN
 New_id:=-1; 
END CREATE_RATE_ID;

create or replace PROCEDURE GETAVAILABLECARS (
CID out sys_refcursor 
) 
AS 
BEGIN
open CID for 
select carID,cost,model 
from car_table 
where is_rented = 0; 
END GETAVAILABLECARS;




create or replace PROCEDURE GETUSER (
userid2 in number , 
username2 out varchar2 , 
LICENSE_NUMBER2 out number 
) 
AS 
BEGIN 
select username , LICENSE_NUMBER 
into username2, LICENSE_NUMBER2 
from user_table 
where userid = userid2; 
END GETUSER;
