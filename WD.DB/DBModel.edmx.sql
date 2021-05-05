
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/05/2021 20:46:28
-- Generated from EDMX file: C:\Users\Jakub Jachowicz\source\repos\WD\WD.DB\DBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ThesisFiles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Files] DROP CONSTRAINT [FK_ThesisFiles];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentThesis]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Theses] DROP CONSTRAINT [FK_StudentThesis];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Files] DROP CONSTRAINT [FK_ProjectFile];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentClass_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentClass] DROP CONSTRAINT [FK_StudentClass_Student];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentClass_Class]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudentClass] DROP CONSTRAINT [FK_StudentClass_Class];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_ClassProject];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassTeacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Classes] DROP CONSTRAINT [FK_ClassTeacher];
GO
IF OBJECT_ID(N'[dbo].[FK_Promoter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Theses] DROP CONSTRAINT [FK_Promoter];
GO
IF OBJECT_ID(N'[dbo].[FK_Reviewer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Theses] DROP CONSTRAINT [FK_Reviewer];
GO
IF OBJECT_ID(N'[dbo].[FK_FinalNoteStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FinalNotes] DROP CONSTRAINT [FK_FinalNoteStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_FinalNoteClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FinalNotes] DROP CONSTRAINT [FK_FinalNoteClass];
GO
IF OBJECT_ID(N'[dbo].[FK_Student_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Student] DROP CONSTRAINT [FK_Student_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Teacher_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users_Teacher] DROP CONSTRAINT [FK_Teacher_inherits_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Classes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Classes];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Theses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Theses];
GO
IF OBJECT_ID(N'[dbo].[Files]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Files];
GO
IF OBJECT_ID(N'[dbo].[FinalNotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FinalNotes];
GO
IF OBJECT_ID(N'[dbo].[Users_Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Student];
GO
IF OBJECT_ID(N'[dbo].[Users_Teacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Teacher];
GO
IF OBJECT_ID(N'[dbo].[StudentClass]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentClass];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Classes'
CREATE TABLE [dbo].[Classes] (
    [ClassId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Teacher_UserId] int  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [ProjectId] int IDENTITY(1,1) NOT NULL,
    [Note] float  NULL,
    [Review] nvarchar(max)  NULL,
    [Scope] nvarchar(max)  NULL,
    [Goal] nvarchar(max)  NULL,
    [IsSubmitted] bit  NOT NULL,
    [SubmissionDate] datetime  NULL,
    [IsReviewed] bit  NOT NULL,
    [ReviewDate] datetime  NULL,
    [CreationDate] datetime  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [ClassId] int  NOT NULL
);
GO

-- Creating table 'Theses'
CREATE TABLE [dbo].[Theses] (
    [ThesisId] int IDENTITY(1,1) NOT NULL,
    [PromoterNote] float  NULL,
    [ReviewerNote] float  NULL,
    [PromoterOpinion] nvarchar(max)  NULL,
    [Review] nvarchar(max)  NULL,
    [Title] nvarchar(max)  NOT NULL,
    [IsTaken] bit  NOT NULL,
    [TakeDate] datetime  NULL,
    [IsSubmitted] bit  NOT NULL,
    [SubmissionDate] datetime  NULL,
    [IsAccepted] bit  NOT NULL,
    [AcceptationDate] datetime  NULL,
    [IsReviewed] bit  NOT NULL,
    [ReviewDate] datetime  NULL,
    [CreationDate] datetime  NOT NULL,
    [Scope] nvarchar(max)  NOT NULL,
    [Goal] nvarchar(max)  NOT NULL,
    [StudentQualifications] nvarchar(max)  NULL,
    [PromoterId] int  NOT NULL,
    [ReviewerId] int  NOT NULL,
    [Student_UserId] int  NOT NULL
);
GO

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [FileId] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(max)  NOT NULL,
    [UploadDate] datetime  NOT NULL,
    [ThesisId] int  NULL,
    [ProjectId] int  NULL
);
GO

-- Creating table 'FinalNotes'
CREATE TABLE [dbo].[FinalNotes] (
    [NoteId] int IDENTITY(1,1) NOT NULL,
    [Note] smallint  NOT NULL,
    [StudentId] int  NOT NULL,
    [ClassId] int  NOT NULL
);
GO

-- Creating table 'Users_Student'
CREATE TABLE [dbo].[Users_Student] (
    [HasThesis] bit  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Users_Teacher'
CREATE TABLE [dbo].[Users_Teacher] (
    [Title] nvarchar(max)  NOT NULL,
    [CanBePromoter] bit  NOT NULL,
    [CanBeReviewer] bit  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'StudentClass'
CREATE TABLE [dbo].[StudentClass] (
    [Students_UserId] int  NOT NULL,
    [Classes_ClassId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [ClassId] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [PK_Classes]
    PRIMARY KEY CLUSTERED ([ClassId] ASC);
GO

-- Creating primary key on [ProjectId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([ProjectId] ASC);
GO

-- Creating primary key on [ThesisId] in table 'Theses'
ALTER TABLE [dbo].[Theses]
ADD CONSTRAINT [PK_Theses]
    PRIMARY KEY CLUSTERED ([ThesisId] ASC);
GO

-- Creating primary key on [FileId] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([FileId] ASC);
GO

-- Creating primary key on [NoteId] in table 'FinalNotes'
ALTER TABLE [dbo].[FinalNotes]
ADD CONSTRAINT [PK_FinalNotes]
    PRIMARY KEY CLUSTERED ([NoteId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users_Student'
ALTER TABLE [dbo].[Users_Student]
ADD CONSTRAINT [PK_Users_Student]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users_Teacher'
ALTER TABLE [dbo].[Users_Teacher]
ADD CONSTRAINT [PK_Users_Teacher]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Students_UserId], [Classes_ClassId] in table 'StudentClass'
ALTER TABLE [dbo].[StudentClass]
ADD CONSTRAINT [PK_StudentClass]
    PRIMARY KEY CLUSTERED ([Students_UserId], [Classes_ClassId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ThesisId] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [FK_ThesisFiles]
    FOREIGN KEY ([ThesisId])
    REFERENCES [dbo].[Theses]
        ([ThesisId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ThesisFiles'
CREATE INDEX [IX_FK_ThesisFiles]
ON [dbo].[Files]
    ([ThesisId]);
GO

-- Creating foreign key on [Student_UserId] in table 'Theses'
ALTER TABLE [dbo].[Theses]
ADD CONSTRAINT [FK_StudentThesis]
    FOREIGN KEY ([Student_UserId])
    REFERENCES [dbo].[Users_Student]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentThesis'
CREATE INDEX [IX_FK_StudentThesis]
ON [dbo].[Theses]
    ([Student_UserId]);
GO

-- Creating foreign key on [ProjectId] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [FK_ProjectFile]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([ProjectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectFile'
CREATE INDEX [IX_FK_ProjectFile]
ON [dbo].[Files]
    ([ProjectId]);
GO

-- Creating foreign key on [Students_UserId] in table 'StudentClass'
ALTER TABLE [dbo].[StudentClass]
ADD CONSTRAINT [FK_StudentClass_Student]
    FOREIGN KEY ([Students_UserId])
    REFERENCES [dbo].[Users_Student]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Classes_ClassId] in table 'StudentClass'
ALTER TABLE [dbo].[StudentClass]
ADD CONSTRAINT [FK_StudentClass_Class]
    FOREIGN KEY ([Classes_ClassId])
    REFERENCES [dbo].[Classes]
        ([ClassId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentClass_Class'
CREATE INDEX [IX_FK_StudentClass_Class]
ON [dbo].[StudentClass]
    ([Classes_ClassId]);
GO

-- Creating foreign key on [ClassId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_ClassProject]
    FOREIGN KEY ([ClassId])
    REFERENCES [dbo].[Classes]
        ([ClassId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassProject'
CREATE INDEX [IX_FK_ClassProject]
ON [dbo].[Projects]
    ([ClassId]);
GO

-- Creating foreign key on [Teacher_UserId] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [FK_ClassTeacher]
    FOREIGN KEY ([Teacher_UserId])
    REFERENCES [dbo].[Users_Teacher]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassTeacher'
CREATE INDEX [IX_FK_ClassTeacher]
ON [dbo].[Classes]
    ([Teacher_UserId]);
GO

-- Creating foreign key on [PromoterId] in table 'Theses'
ALTER TABLE [dbo].[Theses]
ADD CONSTRAINT [FK_Promoter]
    FOREIGN KEY ([PromoterId])
    REFERENCES [dbo].[Users_Teacher]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Promoter'
CREATE INDEX [IX_FK_Promoter]
ON [dbo].[Theses]
    ([PromoterId]);
GO

-- Creating foreign key on [ReviewerId] in table 'Theses'
ALTER TABLE [dbo].[Theses]
ADD CONSTRAINT [FK_Reviewer]
    FOREIGN KEY ([ReviewerId])
    REFERENCES [dbo].[Users_Teacher]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Reviewer'
CREATE INDEX [IX_FK_Reviewer]
ON [dbo].[Theses]
    ([ReviewerId]);
GO

-- Creating foreign key on [StudentId] in table 'FinalNotes'
ALTER TABLE [dbo].[FinalNotes]
ADD CONSTRAINT [FK_FinalNoteStudent]
    FOREIGN KEY ([StudentId])
    REFERENCES [dbo].[Users_Student]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FinalNoteStudent'
CREATE INDEX [IX_FK_FinalNoteStudent]
ON [dbo].[FinalNotes]
    ([StudentId]);
GO

-- Creating foreign key on [ClassId] in table 'FinalNotes'
ALTER TABLE [dbo].[FinalNotes]
ADD CONSTRAINT [FK_FinalNoteClass]
    FOREIGN KEY ([ClassId])
    REFERENCES [dbo].[Classes]
        ([ClassId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FinalNoteClass'
CREATE INDEX [IX_FK_FinalNoteClass]
ON [dbo].[FinalNotes]
    ([ClassId]);
GO

-- Creating foreign key on [UserId] in table 'Users_Student'
ALTER TABLE [dbo].[Users_Student]
ADD CONSTRAINT [FK_Student_inherits_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'Users_Teacher'
ALTER TABLE [dbo].[Users_Teacher]
ADD CONSTRAINT [FK_Teacher_inherits_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------