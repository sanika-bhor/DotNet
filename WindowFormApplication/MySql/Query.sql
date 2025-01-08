create database ECommerce;

use ECommerce;
create table product
(
ProductId int not null,
Title varchar(50),
Description varchar(1000),
UnitPrice int,
Quantity int
);

update product set Description="valentine flower" where ProductId=101;
insert into  product values (101,"rose","valentine Flower" ,20,452);
insert into  product values (102,"lotus","unique flower" ,50,62);
insert into  product values (103,"gerbera","wedding Flower" ,15,4563);
insert into  product values (104,"aster","festival Flower" ,6,5000);
insert into  product values (105,"hibiscus","beautiful Flower" ,10,0);
insert into  product values (106,"lily","cute and small" ,6,57240,"/images/flowers/lily.png");
insert into  product values (107,"hibiscus","perfect flower" ,20,853,"/images/flowers/Hibiscus.png");


set SQL_SAFE_UPDATES=0;

delete from product where ProductId=10;
select * from product;


create table Customer
(
CustomerId int not null,
LoginId varchar(50),
Password varchar(10),
CustomerName varchar(30),
Email varchar(20),
ContactNo varchar(10),
Location varchar(50)
);

insert into  Customer values (1,"sanika12","SB27" ,"sanika bhor", "sb@gmail.com","7896400000","pune");
insert into  Customer values (2,"sumitBhor","sumit13" ,"sumit bhor", "sumit@gmail.com","1456327889","pune");
insert into  Customer values (3,"Transflower","tflPortal" ,"Ravi Sir", "Tfl@gmail.com","7853697124","Swarget");
