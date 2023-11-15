/* check to see if the database exists, if so, dorp it */
IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases
			WHERE name = 'Library')
BEGIN
	DROP DATABASE Library
	print '' print '*** dropping database Library ***'
END
GO

print '' print '*** creating database Library ***'	
GO
CREATE DATABASE Library
GO
USE Library
GO

/************************************************/
/* Employee Table */
print '' print '*** creating employee table ***'
GO
CREATE TABLE [dbo].[Employees] (
    [EmployeeID]       [int]  IDENTITY(100000, 1)  NOT NULL,
	[GivenName]        [nvarchar] (50)               NOT NULL,
	[FamilyName]       [nvarchar] (50)               NOT NULL,
	[Phone]            [nvarchar] (11)               NOT NULL,
	[Email]            [nvarchar] (100)              NOT NULL,
	[PasswordHash]     [nvarchar] (100)              NOT null DEFAULT
		'9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e',
	[Active]           [bit]                         NOT NULL DEFAULT 1,
	CONSTRAINT   [pk_EmployeeID] PRIMARY KEY ([EmployeeID]),
	CONSTRAINT   [ak_Email] UNIQUE ([Email])
)
GO

/* Employee test record */

print '' print '*** inserting employee test record ***'
GO 
INSERT INTO [dbo].[Employees]
([GivenName], [FamilyName],[Phone], [Email])
VALUES 
      ('Husam','Abdelzez', '2495551111', 'HusamAzez@company.com'),
	  ('Ismael', 'Branko', '2495552222', 'branko99@company.com'),
	  ('Yassin', 'Bono', '2495553333', 'yassinyoo@company.com'),
	  ('Mohamed', 'Khalid', '2495554444', 'mokhalid@company.com'),
	  ('Ahmed', 'Abualjaz', '2495555555', 'ahmedjaz@company.com')
GO 

/* Role Table*/
print '' print '*** creating role table ***'
GO 

CREATE TABLE [dbo]. [Role] (
	[RoleID]        [nvarchar] (50)                  NOT NULL,
	CONSTRAINT      [pk_Role] PRIMARY KEY ([RoleID])
    ) 
    GO

/*Role Test records */
print '' print '*** creating empoyeeRole table ***'
GO 
INSERT INTO [dbo].[Role]
             ([RoleID])
			 VALUES 
			          ('Admin'),
					  ('Manager'),
					  ('Process')
					 
GO

/* EmployeeRole Table */
print '' print '*** creating empoyeeRole table ***'
GO 
CREATE TABLE [dbo]. [EmployeeRole] (
	[EmployeeID]        [int]                   NOT NULL,
	[RoleID]            [nvarchar] (50)         NOT NULL,

    CONSTRAINT [fk_EmployeeRole_EmployeeID]  FOREIGN KEY ([EmployeeID])
         REFERENCES [dbo]. [Employees]([EmployeeID]),

CONSTRAINT [fk_EmployeeRole_RoleID] FOREIGN KEY ([RoleID])
         REFERENCES [dbo].[Role] ([RoleID]),
 CONSTRAINT [pk_EmployeeRole] PRIMARY KEY ([EmployeeID], [RoleID])

)    

GO

print ' ' print '*** insrting  EmployeeRole test records ***'
Go
 INSERT INTO [dbo].[EmployeeRole]
            ([EmployeeID], [RoleID])
 VALUES
       (100000, 'Admin'),
       (100001, 'Manager'),
       (100002, 'Process')
       
GO
/* publisher Table */
print '' print '*** creating publishers table ***'
GO
CREATE TABLE [dbo].[publishers] (
    	[publisherID]          [int]  IDENTITY(100000, 1)  NOT NULL,
	[publisherName]         [nvarchar] (50)               NOT NULL,
	[email]         [nvarchar]  (50)              NOT NULL,
	[phone]		  [nvarchar]  (50)  NOT NULL,
	[Active]           [bit]                         NOT NULL DEFAULT 1,
	CONSTRAINT   [pk_publisherID] PRIMARY KEY ([publisherID])
)
       
GO
print ' ' print '*** inserting  publishers test records ***'
Go
 INSERT INTO [dbo].[publishers]
            ([publisherName], [email],[phone])
 VALUES
       ('person', 'admin@person.com','3195691234'),
       ('adiad', 'adiad@sudan.com','123456789'),
       ('kooz', 'kooz@kizan.com','222222222')
       
GO
/* Author Table */
print '' print '*** creating Authors table ***'
GO
CREATE TABLE [dbo].[Authors] (
    	[AuthorID]          [int]  IDENTITY(100000, 1)  NOT NULL,
	[firstName]         [nvarchar] (50)               NOT NULL,
	[lastName]         [nvarchar]  (50)              NOT NULL,
	[phone]		  [nvarchar]  (50)  NOT NULL,
	[email]		  [nvarchar]  (50)  NOT NULL,
	[Active]           [bit]                         NOT NULL DEFAULT 1,
	CONSTRAINT   [pk_AuthorID] PRIMARY KEY ([AuthorID])
)
GO
print ' ' print '*** inserting  Authors test records ***'
Go
 INSERT INTO [dbo].[Authors]
            ([firstName], [lastName],[phone],[email])
 VALUES
       ('yaseen', 'yoo','yaseen@compnay.com','3195691234'),
       ('shafalla', 'abuKhalid','shafa@company.com','123456789'),
       ('ahmed', 'Handasa','ahmed@company.com','222222222')
       
GO

/* BookType Table */
print '' print '*** creating BooksTypes table ***'
GO
CREATE TABLE [dbo].[BooksTypes] (
    	[BookTypeID]    [nvarchar] (50)  NOT NULL,
	[description]	[nvarchar](50)   NOT NULL
	CONSTRAINT   [pk_BookTypeID] PRIMARY KEY ([BookTypeID])
)
GO
print ' ' print '*** inserting  BooksTypes test records ***'
Go
 INSERT INTO [dbo].[BooksTypes]
            ([BookTypeID], [description])
 VALUES
       ('fiction', 'fiction'),
       ('history', 'history'),
       ('sciense', 'sciense')
       
GO
/* Books Table */
print '' print '*** creating books table ***'
GO
CREATE TABLE [dbo].[books] (
    	[BookID]          [int]  IDENTITY(100000, 1)  NOT NULL,
	[BookName]         [nvarchar] (50)               NOT NULL,
	[AuthorID]         [int]                NOT NULL,
	[BookType]         [nvarchar] (50)               NOT NULL,
	[publisher]        [int]              NOT NULL,
	[Active]           [bit]                         NOT NULL DEFAULT 1,
	CONSTRAINT   [pk_BookID] PRIMARY KEY ([BookID]),
	CONSTRAINT [fk_AuthorID] FOREIGN KEY ([AuthorID])
         REFERENCES [dbo].[Authors] ([AuthorID]),
	CONSTRAINT [fk_publisher] FOREIGN KEY ([publisher])
         REFERENCES [dbo].[publishers] ([publisherID]),
	CONSTRAINT [fk_BookType] FOREIGN KEY ([BookType])
         REFERENCES [dbo].[BooksTypes] ([BookTypeID]),
)
GO
print ' ' print '*** inserting  books test records ***'
Go
 INSERT INTO [dbo].[books]
            ([BookName], [AuthorID],[BookType],[publisher])
 VALUES
       ('Season of Imgrant', 100000,'fiction',100000),
       ('history of Sudan', 100001,'history',100001),
       ('sciense of Rain', 100002,'sciense',100002)
       
GO
print '' print '*** creating sp_verify_user'
GO
CREATE PROCEDURE [dbo].[sp_verify_user]
(
	@Email		[nvarchar](250),
	@PasswordHash	[nvarchar](100)
)
AS
	BEGIN
		SELECT [EmployeeID]
		FROM [dbo].[Employees]
		WHERE Email = @Email
		AND PasswordHash = @PasswordHash
	END
GO
print '' print '*** creating sp_select_role_by_employeeId'
GO
CREATE PROCEDURE [dbo].[sp_select_role_by_employeeId]
(
	@EmployeeID INT
)
AS
	BEGIN
		SELECT [RoleID]
		FROM [dbo].[EmployeeRole]
		WHERE EmployeeID = @EmployeeID
	END
GO

print '' print '*** creating sp_selectAllEmployees'
GO
CREATE PROCEDURE [dbo].[sp_selectAllEmployees]
AS
	BEGIN
		SELECT [dbo].[Employees].[EmployeeID], [dbo].[Employees].[GivenName],[dbo].[Employees].[FamilyName] ,[dbo].[Employees].[Phone], 
			[dbo].[Employees].[Email],[dbo].[Employees].[PasswordHash] ,[dbo].[Employees].[Active],[dbo].[EmployeeRole].[RoleID]
		FROM [dbo].[Employees], [dbo].[EmployeeRole]
		WHERE [dbo].[Employees].[EmployeeID] = [dbo].[EmployeeRole].[EmployeeID]
	END
GO
print '' print '*** creating sp_insert_employee'
GO
CREATE PROCEDURE [dbo].[sp_insert_employee](
@GivenName [nvarchar] (50) ,@FamilyName [nvarchar] (50) ,@Phone [nvarchar] (11) ,@Email [nvarchar] (100) ,@PasswordHash [nvarchar] (100) , @Active bit, @Role [nvarchar] (50) 
)
AS
	BEGIN
		DECLARE @TestVariable AS INT
INSERT INTO [dbo].[Employees]
		([GivenName],[FamilyName],[Phone],[Email],[PasswordHash], [Active])
			VALUES(@GivenName,@FamilyName,@Phone,@Email,@PasswordHash,@Active);
SET @TestVariable = 
(SELECT [dbo].[Employees].[EmployeeID]
FROM [dbo].[Employees]
WHERE [GivenName] = @GivenName
AND [FamilyName] = @FamilyName
AND [Phone] = @Phone
AND [Email] = @Email
AND [PasswordHash] = @PasswordHash
AND [Active] = @Active);
INSERT INTO [dbo].[EmployeeRole]
		([EmployeeID],[RoleID])
VALUES (@TestVariable,@Role);
return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_update_employee'
GO
CREATE PROCEDURE [dbo].[sp_update_employee](
@EmployeeID INT,@GivenName [nvarchar] (50) ,@FamilyName [nvarchar] (50) ,@Phone [nvarchar] (11) ,@Email [nvarchar] (100) ,@PasswordHash [nvarchar] (100) , @Active bit, @Role [nvarchar] (50) 
)
AS
BEGIN
	UPDATE [dbo].[Employees]
	SET
		GivenName = @GivenName,
		FamilyName = @FamilyName,
		Phone = @Phone,
		Email = @Email,
		PasswordHash = @PasswordHash,
		Active = @Active
	WHERE
		EmployeeID = @EmployeeID
	UPDATE [dbo].[EmployeeRole]
	SET
		RoleID = @Role
	WHERE
		EmployeeID = @EmployeeID
	return @@ROWCOUNT
END
GO
print '' print '*** creating sp_select_all_books'
GO
CREATE PROCEDURE [dbo].[sp_select_all_books]
AS
	BEGIN
		SELECT [dbo].[books].[BookID],[dbo].[books].[BookName],[dbo].[books].[BookType],
			[dbo].[Authors].[lastName],[dbo].[publishers].[publisherName],[dbo].[books].[Active]
		FROM [dbo].[books]
		JOIN [dbo].[Authors] ON [dbo].[Authors].[AuthorID] = [dbo].[books].[AuthorID]
		JOIN [dbo].[publishers] ON [dbo].[publishers].[publisherID] = [dbo].[books].[publisher];
	END
GO
print '' print '*** creating sp_select_all_authors_lastName'
GO
CREATE PROCEDURE [dbo].[sp_select_all_authors_lastName]
AS
	BEGIN
		SELECT [dbo].[Authors].[lastName]
		FROM [dbo].[Authors]
	END
GO
print '' print '*** creating sp_select_all_publishers_name'
GO
CREATE PROCEDURE [dbo].[sp_select_all_publishers_name]
AS
	BEGIN
		SELECT [dbo].[publishers].[publisherName]
		FROM [dbo].[publishers]
	END
GO
print '' print '*** creating sp_select_all_books_Types_Id'
GO
CREATE PROCEDURE [dbo].[sp_select_all_books_Types_Id]
AS
	BEGIN
		SELECT [dbo].[BooksTypes].[BookTypeID]
		FROM [dbo].[BooksTypes]
	END
GO
print '' print '*** creating sp_insert_book'
GO
CREATE PROCEDURE [dbo].[sp_sp_insert_book]
(@BookName [nvarchar] (50), @AuthorName [nvarchar]  (50), @BookType [nvarchar] (50), @publisherName [nvarchar] (50))
AS
	BEGIN
		DECLARE @AuthorID AS INT
		SET @AuthorID = (
			SELECT AuthorID
			FROM Authors
			WHERE lastName = @AuthorName
		);
		DECLARE @PublisherID AS INT
		SET @PublisherID = (
			SELECT publisherID
			FROM publishers
			WHERE publisherName = @publisherName
		);
		INSERT INTO [books]
			([BookName],[BookType],[AuthorID],[publisher])
			VALUES (@BookName,@BookType,@AuthorID,@PublisherID);
	END
GO
print '' print '*** creating sp_update_book'
GO
CREATE PROCEDURE [dbo].[sp_update_book]
(@BookID int, @BookName [nvarchar] (50), @AuthorName [nvarchar]  (50), @BookType [nvarchar] (50), @publisherName [nvarchar] (50), @Active bit)
AS
	BEGIN
		DECLARE @AuthorID AS INT
		SET @AuthorID = (
			SELECT AuthorID
			FROM Authors
			WHERE lastName = @AuthorName
		);
		DECLARE @PublisherID AS INT
		SET @PublisherID = (
			SELECT publisherID
			FROM publishers
			WHERE publisherName = @publisherName
		);
		UPDATE [dbo].[books]
		SET
			[BookName] = @BookName,
			[BookType] = @BookType,
			[AuthorID] = @AuthorID,
			[publisher]= @PublisherID,
			[Active]   = @Active
		WHERE	[BookID]   = @BookID
	END
GO