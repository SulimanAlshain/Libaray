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
					  ('Proccess')
					 
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
       (100002, 'proccess')
       
       GO
       
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
