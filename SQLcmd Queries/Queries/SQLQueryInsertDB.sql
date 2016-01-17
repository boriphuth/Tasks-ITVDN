USE master;
GO

USE Store;
GO

EXEC AddClient 'Alex', 'Kiyv';
GO
EXEC AddClient 'Fred', 'Dnepr';
GO
EXEC AddClient 'Tom', 'Kiyv';
GO
EXEC AddClient 'Tom', 'Kiyv';
GO


EXEC AddGood 'Orange', 25.20;
GO
EXEC AddGood 'Lemon', 27.20;
GO
EXEC AddGood 'Apple', 24.20;
GO
EXEC AddGood 'Milk', 5.25;
GO
EXEC AddGood 'Water', 0.20;
GO
EXEC AddGood 'Water', 0.20;
GO



INSERT INTO Orders
VALUES
(1, 1, GETDATE()),
(1, 2, GETDATE()),
(2, 3, GETDATE()),
(2, 1, GETDATE()),
(1, 4, GETDATE()),
(3, 2, GETDATE()),
(3, 3, GETDATE()),
(3, 1, GETDATE()),
(1, 5, GETDATE());
GO


SELECT *
FROM Clients;

SELECT *
FROM Goods;

SELECT *
FROM Orders;