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