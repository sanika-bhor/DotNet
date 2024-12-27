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