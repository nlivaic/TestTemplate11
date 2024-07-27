USE master
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TestTemplate11Db')
BEGIN
  CREATE DATABASE TestTemplate11Db;
END;
GO

USE TestTemplate11Db;
GO

IF NOT EXISTS (SELECT 1
                 FROM sys.server_principals
                WHERE [name] = N'TestTemplate11Db_Login' 
                  AND [type] IN ('C','E', 'G', 'K', 'S', 'U'))
BEGIN
    CREATE LOGIN TestTemplate11Db_Login
        WITH PASSWORD = '<DB_PASSWORD>';
END;
GO  

IF NOT EXISTS (select * from sys.database_principals where name = 'TestTemplate11Db_User')
BEGIN
    CREATE USER TestTemplate11Db_User FOR LOGIN TestTemplate11Db_Login;
END;
GO  


EXEC sp_addrolemember N'db_datareader', N'TestTemplate11Db_User';
GO

EXEC sp_addrolemember N'db_datawriter', N'TestTemplate11Db_User';
GO

EXEC sp_addrolemember N'db_ddladmin', N'TestTemplate11Db_User';
GO
