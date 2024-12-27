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


insert into  product values (101,"rose","valentineFlower" ,20,452);
insert into  product values (102,"lotus","unique flower" ,50,62);
insert into  product values (103,"gerbera","wedding Flower" ,15,4563);
insert into  product values (104,"aster","festival Flower" ,6,5000);
insert into  product values (105,"hibiscus","beautiful Flower" ,10,0);
insert into  product values (107,"lily","cute and small" ,6,57240);

set SQL_SAFE_UPDATES=0;

delete from product where ProductId=107;
select * from product;