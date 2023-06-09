create database [AleppoFreeUniversity]
go
USE [master]
GO
/****** Object:  Login [admin]    Script Date: 16/09/2020 09:08:57 ص ******/
CREATE LOGIN [admin] WITH PASSWORD='0000', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
ALTER LOGIN [admin] DISABLE
GO
/****** Object:  Login [ادارة الامتحانات]    Script Date: 16/09/2020 09:08:57 ص ******/
CREATE LOGIN [ادارة الامتحانات] WITH PASSWORD='0000', DEFAULT_DATABASE=[AleppoFreeUniversity], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
ALTER LOGIN [ادارة الامتحانات] DISABLE
GO
/****** Object:  Login [ادارة الطلاب]    Script Date: 16/09/2020 09:08:57 ص ******/
CREATE LOGIN [ادارة الطلاب] WITH PASSWORD='0000', DEFAULT_DATABASE=[AleppoFreeUniversity], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO
ALTER LOGIN [ادارة الطلاب] DISABLE
GO

USE [master]
GO
/****** Object:  StoredProcedure [dbo].[restore_db]    Script Date: 16/09/2020 09:17:49 ص ******/
create proc [dbo].[restore_db]
@path nvarchar(75)
as

alter database [AleppoFreeUniversity] set offline with rollback immediate
RESTORE DATABASE [AleppoFreeUniversity] FROM  DISK =@path 
alter database [AleppoFreeUniversity]  set online
-------------------------------------------------------------------------



