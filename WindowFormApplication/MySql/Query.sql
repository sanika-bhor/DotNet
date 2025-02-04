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

desc product;

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

select * from Customer;




create table ShoppingCart
(
ProductId int not null,
CustomerId int,
Title varchar(50),
UnitPrice int,
Quantity int
);

insert into  shoppingcart values (101,1,"Rose",5 ,2);
insert into  shoppingcart values (103,1,"Gerbera",7 ,15);
 update shoppingcart set CustomerId=2 where ProductId=103;
select * from shoppingcart;


create table Payments
(
Id int,
OrderId int,
Amount decimal,
PaymentDate datetime,
PaymentMode varchar(20)
);

drop table Payments;
insert into  Payments values (1,25,45,"2020-1-10 10.30.23","online");
insert into  Payments values (3,78,96,"2020-1-10 5.15.20","online");
insert into  Payments values (4,6,12,"2020-1-10 8.32.31","offline");
insert into  Payments values (2,96,26,"2020-1-10 12.08.56","online");
