# CrudOperation
1) Need to update sql server connection in appsetting.json

2) Run Below sql Script on your sql server.

--Create database WebAppTestDB
CREATE DATABASE WebAppTestDB;
GO
 
--Start using the WebAppTestDB database
USE WebAppTestDB;
GO
 
--Create Employee Master table
CREATE TABLE [dbo].[tbl_EmployeeMaster](
    [EmployeeId] [int] IDENTITY(1,1) NOT NULL,
    [FirstName] [nvarchar](256) NOT NULL,
    [LastName] [nvarchar](256) NOT NULL,
    [Email] [varchar](50) NOT NULL,
    [PhoneNumber] [varchar](15) NULL,
    [Status] [varchar](10) NOT NULL
);
GO
 
--Add some sample records
INSERT INTO [dbo].[tbl_EmployeeMaster]
([FirstName], [LastName], [Email], [PhoneNumber], [Status])
VALUES
( 'Smith', 'David', 'ccc@gmail.com', '895444444', 'Active'),
( 'Sachin', 'Mathew', '9876543210', 'HR Head', 'InActive')
GO

3) Hit Local Host URL:https://localhost:44372/EmployeeMasters/
4) Perform Operation (Add-EDIT and Delete)
