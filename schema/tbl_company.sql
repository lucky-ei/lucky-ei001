USE [testdb]
GO

INSERT INTO [dbo].[tbl_company]
           ([companyID]
           ,[company_name]
           ,[company_kana]
           ,[memo]
           ,[delete_flag])
     VALUES
('1','株式会社百面相△□','ヒャクメンソウ△□','NULL','0'),
('2','ググッド◎◇株式会社','ググッド◎◇','NULL','0'),
('3','株式会社パル×○','パル','NULL','0'),
('4','クレソン●×株式会社','クレソン●×','NULL','0')

GO