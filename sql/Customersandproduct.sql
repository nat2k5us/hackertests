 USE Quick_Application1;

 Drop Table If exists Customers;
 Drop Table If exists ProductMaster;
 Drop Table If Exists Orders;

 IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='CUSTOMERS' and xtype='U')
CREATE TABLE  CUSTOMERS(
   ID   INT              NOT NULL,
   NAME VARCHAR (20)     NOT NULL,
   ADDRESS1  VARCHAR (255) ,
   ADDRESS2  VARCHAR (255) ,
   City varchar(100),
   State varchar (100),
   Country varchar(100),
   PostalCode varchar(12),   
   PRIMARY KEY (ID)
)

Go

insert into CUSTOMERS (ID,NAME, PostalCode) Values (1,'Todd', '75660');
insert into CUSTOMERS (ID,NAME, PostalCode) Values (2,'cherry', '75612');
insert into CUSTOMERS (ID,NAME, PostalCode) Values (3,'Mike', '75110');
insert into CUSTOMERS (ID,NAME, PostalCode) Values (4,'Joe', '75440');

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ProductMaster' and xtype='U')
CREATE TABLE  ProductMaster(
   ID   INT              NOT NULL,
   NAME VARCHAR (20)     NOT NULL,
  Price DECIMAL (10,2),
  Description  VARCHAR (255),
  Weight Decimal(10,2),
   PRIMARY KEY (ID)
)

Go
Insert into ProductMaster (ID, NAME) Values (1, 'X');
Insert into ProductMaster (ID, NAME) Values (2, 'Q');
Insert into ProductMaster (ID, NAME) Values (3, 'B');
Insert into ProductMaster (ID, NAME) Values (4, 'A');


 IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Orders' and xtype='U')
CREATE TABLE  Orders(
   ID   INT            IDENTITY(1,1) PRIMARY KEY,
   CustomerId INT     NOT NULL,
   ProductId INT      NOT NULL,
   OrderDate Date,
   Quantity INT,
)

Go
-- Use the table provided to populate the orders table
-- Product X Orders
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 1,1,1);
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 2,1,1);
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 3,1,1);
--Product Q Orders
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 1,2,1);
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 2,2,1);
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 3,2,1);
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 1,2,1);
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 2,2,1);
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 3,2,1);
--Product B ordrs
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 1,3,0);
-- Product A Orders
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 1,4,1);
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 2,4,1);
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 3,4,1);
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 1,4,1);
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 2,4,1);
Insert into Orders ( CustomerId, ProductId, Quantity) Values ( 3,4,1);

select * from ProductMaster;
select * from Orders;
--Question 2:
select pm.Name,sum(ords.Quantity) as Qty From ProductMaster pm
Left Outer join Orders ords On ords.ProductId=pm.ID
group by pm.Name;

-- Question 3
select pm.Name,sum(ords.Quantity) as Qty From ProductMaster pm
Left Outer join Orders ords On ords.ProductId=pm.ID
 group by pm.Name
 HAVING sum(ords.Quantity) > 5;

