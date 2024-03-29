USE [zbasmt]
GO


/****** Object:  Table [dbo].[employee]    Script Date: 16-Mar-24 9:41:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  StoredProcedure [dbo].[Asmt_CreateEmployee]    Script Date: 16-Mar-24 9:41:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rojan Thomas Samuel
-- Create date: 
-- Description:	Create new employee
-- =============================================
Create PROCEDURE [dbo].[Asmt_CreateEmployee] @FirstName varchar(50),@MiddleName varchar(50),@LastName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @count as int

	select @count=count(*)  from employee where FirstName=@FirstName and @MiddleName=@MiddleName and LastName=@LastName
	IF (@count >0)
	BEGIN
		RAISERROR (15600, -1, -1, 'Employee Already Exist');
	END
	ELSE
	BEGIN
		-- Insert statements for procedure here
		insert into employee (FirstName,MiddleName,LastName) values (@FirstName ,@MiddleName ,@LastName)
		SELECT id,FirstName,MiddleName,LastName from employee where FirstName=@FirstName and @MiddleName=@MiddleName and LastName=@LastName
	END
END

GO
/****** Object:  StoredProcedure [dbo].[Asmt_DeleteEmployee]    Script Date: 16-Mar-24 9:41:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rojan Thomas Samuel
-- Create date: 
-- Description:	|Delete employee by id
-- =============================================
CREATE PROCEDURE [dbo].[Asmt_DeleteEmployee] @id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @count as int
	
	select @count=count(*)  from employee where id=@id
	IF (@count <= 0 )
	BEGIN
		RAISERROR (15600, -1, -1, 'Employee Not found by ID');
	END
	ELSE
	BEGIN
		
		-- Delete statements for procedure here
		delete from employee where id=@id
		SELECT id,FirstName,MiddleName,LastName from employee where id=@id
		
	END

END

GO
/****** Object:  StoredProcedure [dbo].[Asmt_GetEmployee]    Script Date: 16-Mar-24 9:41:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rojan Thomas Samuel
-- Create date: 
-- Description:	Get Employee by id
-- =============================================
CREATE PROCEDURE [dbo].[Asmt_GetEmployee] @id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @count as int
	select @count=count(*)  from employee
	IF (@id <= 0 or @id >@count)
	BEGIN
		RAISERROR (15600, -1, -1, 'id out of range');
	END
	ELSE
	BEGIN
		-- Insert statements for procedure here
		SELECT id,FirstName,MiddleName,LastName from employee where id=@id
	END
END

GO
/****** Object:  StoredProcedure [dbo].[Asmt_GetEmployees]    Script Date: 16-Mar-24 9:41:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rojan Sameul
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Asmt_GetEmployees]
	
AS
BEGIN
	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id,FirstName,MiddleName,LastName from employee order by id
END

GO
/****** Object:  StoredProcedure [dbo].[Asmt_UpdateEmployee]    Script Date: 16-Mar-24 9:41:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rojan Thomas Samuel
-- Create date: 
-- Description:	Update employee by id
-- =============================================
Create PROCEDURE [dbo].[Asmt_UpdateEmployee] @id int,@FirstName varchar(50),@MiddleName varchar(50),@LastName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @count as int
	
	select @count=count(*)  from employee where id=@id
	IF (@id <= 0 )
	BEGIN
		RAISERROR (15600, -1, -1, 'Employee Not found by ID');
	END
	ELSE
	BEGIN
		select @count=count(*)  from employee where id<> @id and  FirstName=@FirstName and @MiddleName=@MiddleName and LastName=@LastName
		IF (@count >0)
		BEGIN
			RAISERROR (15600, -1, -1, 'Duplicate Record with different id');
		END
		ELSE
		BEGIN
			-- Update statements for procedure here
			update employee set FirstName=@FirstName,MiddleName=@MiddleName ,LastName=@LastName where id=@id
			SELECT id,FirstName,MiddleName,LastName from employee where FirstName=@FirstName and @MiddleName=@MiddleName and LastName=@LastName
		END
	END

END

GO
