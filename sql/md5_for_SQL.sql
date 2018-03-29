SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('MD5', CONVERT(VARBINARY(100), @data))), 3, 32)

mysql.exe -u[user] -p [db_name] < file.sql
