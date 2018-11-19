Create Database BAIS3110Security


Create Table Users(
Email varchar(30),
Password varchar(255),
Salt varchar(20)
)
drop table Users

GO
Create Proc AddUser(@Email varchar(30) = NULL, @Password varchar(255)=NULL, @Salt varchar(20)=NULL)
as
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @Email IS NULL
		RAISERROR ('AddUser - Required parameter: @Email',16,1)
	ELSE
	If @Password IS NULL
		RAISERROR ('AddPassword - Required parameter: @Password',16,1)
	ELSE
		BEGIN
			INSERT INTO Users
			(Email,Password, Salt)
			VALUES
			(@Email, @Password, @Salt)

			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('AddUser - INSERT error: Users table.',16,1)
		END
RETURN @ReturnCode
drop proc AddUser

GO
Create Proc GetUser(@Email varchar(30) = NULL)
as
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @Email IS NULL
		RAISERROR ('GetUser - Required parameter: @Email',16,1)
	ELSE
		BEGIN
			Select Email, Password, Salt
			From Users
			where @Email = Email

			IF @@ERROR = 0
				SET @ReturnCode = 0
			ELSE
				RAISERROR('GetUser - GET error: Users table.',16,1)
		END
RETURN @ReturnCode

Drop Proc GetUser
select * from Users