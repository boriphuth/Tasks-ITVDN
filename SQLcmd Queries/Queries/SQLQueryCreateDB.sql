USE master;
GO

DROP DATABASE Store;
GO

CREATE DATABASE Store;
GO

USE Store;
GO

DROP TABLE Clients;
GO

DROP TABLE Orders;
GO

DROP TABLE Goods;
GO

CREATE TABLE Clients
(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	Name nchar(30) NOT NULL,
	Adress nchar(30) NULL
);
GO


CREATE TABLE Orders
(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	ClientId int NOT NULL,
	GoodId int NOT NULL,
	OrderDate datetime NOT NULL
);
GO

ALTER TABLE Orders
ADD FOREIGN KEY (ClientId) REFERENCES Clients(Id);
GO

ALTER TABLE Orders
ADD FOREIGN KEY (GoodId) REFERENCES Goods(Id);
GO

CREATE TABLE Goods
(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	Name nchar(30) NOT NULL,
	Price money NULL
);
GO

DROP PROC AddGood;
GO

CREATE PROC AddGood
@Name nchar(30), 
@Price money
AS
BEGIN
	IF EXISTS
		(SELECT Name, Price
		FROM Goods
		WHERE Goods.Name = @Name AND Goods.Price = @Price)
		PRINT 'Good exist'
		ELSE
		BEGIN
			INSERT INTO Goods(Name, Price)
			VALUES(@Name, @Price)
		END;
END;
GO

DROP PROC AddClient;
GO

CREATE PROC AddClient
@Name nchar(30), 
@Adress nchar(30)
AS
BEGIN
	IF EXISTS
		(SELECT Name, Adress
		FROM Clients
		WHERE Clients.Name = @Name AND Clients.Adress = @Adress)
		PRINT 'Client exist'
		ELSE
		BEGIN
			INSERT INTO Clients(Name,  Adress)
			VALUES(@Name,  @Adress)
		END;
END;
GO