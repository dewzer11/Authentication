Create Database BAIS3110Security

drop table Users

Create Table Users(
Email varchar(30),
Password varchar(255),
Salt varchar(20),
Role VARCHAR(80)
)


GO
Create Proc AddUser(@Email varchar(30) = NULL, @Password varchar(255)=NULL, @Salt varchar(20)=NULL, @Role VARCHAR(80)=NULL)
as
	DECLARE @ReturnCode INT
	SET @ReturnCode = 1

	IF @Email IS NULL
		RAISERROR ('AddUser - Required parameter: @Email',16,1)
	ELSE
	If @Password IS NULL
		RAISERROR ('AddPassword - Required parameter: @Password',16,1)
	ELSE
	IF @Role IS NULL
		set @Role = 'user'
		BEGIN
			INSERT INTO Users
			(Email,Password, Salt, Role)
			VALUES
			(@Email, @Password, @Salt, @Role)

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
			Select Email, Password, Salt, Role
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

GO
Update Users
Set Role = 'Admin'
where Email = 'obarnett@nait.ca'
