CREATE TABLE [dbo].[tbl_company]
(
	[companyID] INT NOT NULL , 
    [company_name] NVARCHAR(100) NOT NULL, 
    [company_kana] NVARCHAR(100) NULL, 
    [delete_flag] BIT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([companyID])
)
