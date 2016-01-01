CREATE TABLE [dbo].[tbl_company]
(
	[companyID] INT NOT NULL , 
    [company_name] NVARCHAR(100) NOT NULL, 
    [company_kana] NVARCHAR(100) NULL, 
    [memo] NVARCHAR(MAX) NOT NULL, 
    [delete_flag] BIT NULL, 
    CONSTRAINT [PK_tbl_company] PRIMARY KEY ([companyID])
)
go

CREATE TABLE [dbo].[tbl_customer]
(
	[customerID] INT NOT NULL , 
    [customer_name] NVARCHAR(20) NOT NULL, 
    [customer_kana] NVARCHAR(20) NOT NULL, 
	[companyID] INT NULL , 
    [section] NVARCHAR(50) NULL,
	[post] NVARCHAR(30) NULL, 
    [zipcode] NVARCHAR(8) NULL,
    [address1] NVARCHAR(100) NULL,
    [address2] NVARCHAR(100) NULL,
	[tel] NVARCHAR(20) NULL, 
    [staffID] INT NULL, 
    [first_action_date] DATETIME NULL, 
	[memo] NVARCHAR(MAX) NULL, 
    [input_date] DATETIME NULL, 
	[input_staff_name] NVARCHAR(20) NULL,
    [update_date] DATETIME NULL,
	[update_staff_name] NVARCHAR(20) NOT NULL, 
    [delete_flag] BIT NULL, 
    CONSTRAINT [PK_tbl_customer] PRIMARY KEY ([customerID])
)
go

CREATE TABLE [dbo].[tbl_action]
(
	[ID] INT NOT NULL , 
	[customerID] INT NOT NULL , 
    [action_date] DATETIME NOT NULL,
	[action_content] NVARCHAR(400) NULL, 
    [action_staffID] INT NULL,
    CONSTRAINT [PK_tbl_action] PRIMARY KEY ([ID])
)
go

CREATE TABLE [dbo].[tbl_staff]
(
	[staffID] INT NOT NULL , 
	[staff_name] NVARCHAR(20) NOT NULL , 
	[userID] NVARCHAR(10) NULL , 
	[password] NVARCHAR(10) NULL , 
    [admin_flag] BIT NULL, 
    [delete_flag] BIT NULL, 
    CONSTRAINT [PK_tbl_staff] PRIMARY KEY ([staffID])
)
go

--drop table tbl_company
--drop table tbl_customer
--drop table tbl_action
--drop table tbl_staff