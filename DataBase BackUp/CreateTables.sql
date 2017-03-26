
SET QUOTED_IDENTIFIER OFF;
GO
USE [PhoneDirectory];
GO


-- Creating table 'Admins'
CREATE TABLE [dbo].[Admins] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [username] nvarchar(70)  NOT NULL,
    [password] nvarchar(70)  NOT NULL,
    [employeeID] int  NULL
);
GO

-- Creating table 'Department'
CREATE TABLE [dbo].[Department] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(70)  NOT NULL,
    [location] nvarchar(50)  NULL
);
GO

-- Creating table 'Employee'
CREATE TABLE [dbo].[Employee] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [surname] nvarchar(50)  NOT NULL,
    [phoneNumber] nvarchar(11)  NOT NULL,
    [departmentID] int  NULL,
    [managerID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [PK_Admins]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Department'
ALTER TABLE [dbo].[Department]
ADD CONSTRAINT [PK_Department]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [PK_Employee]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [employeeID] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [FK_Admins_Employee]
    FOREIGN KEY ([employeeID])
    REFERENCES [dbo].[Employee]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Admins_Employee'
CREATE INDEX [IX_FK_Admins_Employee]
ON [dbo].[Admins]
    ([employeeID]);
GO

-- Creating foreign key on [departmentID] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [FK_Employee_Department]
    FOREIGN KEY ([departmentID])
    REFERENCES [dbo].[Department]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Department'
CREATE INDEX [IX_FK_Employee_Department]
ON [dbo].[Employee]
    ([departmentID]);
GO

-- Creating foreign key on [managerID] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [FK_Employee_Employee]
    FOREIGN KEY ([managerID])
    REFERENCES [dbo].[Employee]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Employee'
CREATE INDEX [IX_FK_Employee_Employee]
ON [dbo].[Employee]
    ([managerID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------