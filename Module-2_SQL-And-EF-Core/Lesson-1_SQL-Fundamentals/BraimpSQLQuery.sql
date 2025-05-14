use master
GO
IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'FakeBraimp')
BEGIN
ALTER DATABASE FakeBraimp SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE FakeBraimp;
CREATE DATABASE FakeBraimp;
END

Use FakeBraimp
GO

CREATE TABLE [Tags] (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE [CourseCategories] (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL
);

CREATE TABLE Courses (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[OwnerId] UNIQUEIDENTIFIER NOT NULL,
	[Title] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(1000) NULL,
	[Status] NVARCHAR(50) NOT NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[UpdatedAt] DATETIMEOFFSET NULL,
	[GradingSystem] NVARCHAR(50) NOT NULL,
	[CoverImageUrl] NVARCHAR(2048) NULL,
	[BackgroundColor] NVARCHAR(50) NULL,
	[LogoUrl] NVARCHAR(2048) NULL,
	[CourseCategoryId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Courses_CourseCategories_CourseCategoryId FOREIGN KEY (CourseCategoryId) REFERENCES CourseCategories(Id)
);

CREATE TABLE [CourseTags] (
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [CourseId] UNIQUEIDENTIFIER NOT NULL,
    [TagId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_CourseTags_Courses_CourseID FOREIGN KEY (CourseId) REFERENCES Courses(Id),
    CONSTRAINT FK_CourseTags_Tags_TagId FOREIGN KEY (TagId) REFERENCES Tags(Id)
);

CREATE TABLE [EnrollmentRequests](
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Status] NVARCHAR(50)  NOT NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[UpdatedAt] DATETIMEOFFSET NULL,
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	[CourseId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_EnrollmentRequests_Courses_CourseId FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

CREATE TABLE [CourseParticipants](
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	[CourseId] UNIQUEIDENTIFIER NOT NULL,
	[Role] NVARCHAR(50),
	CONSTRAINT FK_CourseParticipants_Courses_CourseId FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

CREATE TABLE [CourseNews](
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(100) NOT NULL,
	[Content] NVARCHAR(1000) NOT NULL,
	[ImageUrl] NVARCHAR(2048) NOT NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[UpdatedAt] DATETIMEOFFSET NULL,
	[AuthorId] UNIQUEIDENTIFIER NOT NULL,
	[CourseId] UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT FK_CourseNews_Courses_CourseId FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);


CREATE TABLE [Modules] (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(1000) NULL,
	[IsPublished] BIT NOT NULL DEFAULT 0,
	[SortIndex] INT NOT NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[UpdatedAt] DATETIMEOFFSET NULL,
	[CourseId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Modules_Courses_CourseId FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

CREATE TABLE [Lessons] (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(1000) NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[UpdatedAt] DATETIMEOFFSET NULL,
	[IsPublished] BIT NOT NULL DEFAULT 0,
	[SortIndex] INT NOT NULL,
	[ModuleId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Lessons_Modules_ModuleId FOREIGN KEY (ModuleId) REFERENCES Modules(Id)
);

CREATE TABLE [Materials] (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[ResourceType] NVARCHAR(50) NOT NULL,
	[ResourceUrl] NVARCHAR(2048) NOT NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[UpdatedAt] DATETIMEOFFSET NULL,
	[LessonId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Materials_Lessons_LessonId FOREIGN KEY (LessonId) REFERENCES Lessons(Id)
);

CREATE TABLE [Assignments] (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[AttachmentUrl] NVARCHAR(2048) NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[UpdatedAt] DATETIMEOFFSET NULL,
	[Deadline] DATETIMEOFFSET NULL,
	[CourseId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Assignments_Courses_CourseId FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

CREATE TABLE Submissions (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Status] NVARCHAR(50) NOT NULL,
	[StudentId] UNIQUEIDENTIFIER NOT NULL,
	[ReviewerId] UNIQUEIDENTIFIER NULL,
	[Text] NVARCHAR(300) NULL,
	[Grade] DECIMAL(5,2) NULL,
	[ReviewComment] NVARCHAR(300) NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[UpdatedAt] DATETIMEOFFSET NULL,
	[ReviewedAt] DATETIMEOFFSET NULL,
	[AssignmentId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Submissions_Assignments_AssignmentId FOREIGN KEY (AssignmentId) REFERENCES Assignments(Id)
);

ALTER TABLE Submissions
ADD CONSTRAINT CK_Submissions_Grade CHECK (Grade > 0);

ALTER TABLE Submissions
ADD CONSTRAINT CK_Submissions_StudentID UNIQUE (StudentID);

CREATE TABLE SubmissionAttachments (
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	FileUrl NVARCHAR(2048) NOT NULL,
	SubmissionId UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_SubmissionAttachments_Submissions_SubmissionId FOREIGN KEY (SubmissionId) REFERENCES Submissions(Id)
);

CREATE TABLE [Quizzes] (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Title] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[TimeLimitMinutes] INT NULL,
	[IsPublished] BIT NOT NULL DEFAULT 0,
	[MaxAttempts] INT NOT NULL,
	[IsRandomized] BIT NOT NULL DEFAULT 0,
	[StartTime] DATETIMEOFFSET NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[UpdatedAt] DATETIMEOFFSET NULL,
	[CourseId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Quizzes_Courses_CourseId FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

CREATE TABLE [QuizQuestions] (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Text] NVARCHAR(300) NOT NULL,
	[QuestionType] NVARCHAR(50) NOT NULL,
	[MediaUrl] NVARCHAR(2048) NULL,
	[Weight] INT NOT NULL DEFAULT 1,
	[QuizId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_QuizQuestions_Quizzes_QuizId FOREIGN KEY (QuizId) REFERENCES Quizzes(Id)
);

CREATE TABLE [QuizOptions] (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Text] NVARCHAR(100) NOT NULL,
	[MediaUrl] NVARCHAR(2048) NULL,
	[IsCorrect] BIT NOT NULL,
	[QuizQuestionId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_QuizOptions_QuizQuestions_QuizQuestionId FOREIGN KEY (QuizQuestionId) REFERENCES QuizQuestions(Id)
)

CREATE TABLE [QuizResult] (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[StudentId] UNIQUEIDENTIFIER NOT NULL,
	[Score] DECIMAL(5,2) NOT NULL,
	[Grade] DECIMAL(5,2) NULL,
	[CorrectAnswerCount] INT NOT NULL,
	[IncorrectAnswerCount] INT NOT NULL,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[UpdatedAt] DATETIMEOFFSET NULL,
	[IsPublished] BIT NOT NULL DEFAULT 0,
	[AttemptNumber] INT NOT NULL,
	[QuizId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_QuizResults_Quizzes_QuizId FOREIGN KEY (QuizId) REFERENCES Quizzes(Id)
);

CREATE TABLE [Notifications] (
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	[Title] NVARCHAR(100) NOT NULL,
	[Message] NVARCHAR(300) NOT NULL,
	[IsRead] BIT NOT NULL DEFAULT 0,
	[CreatedAt] DATETIMEOFFSET NOT NULL,
	[UpdatedAt] DATETIMEOFFSET NULL,
	[Type] NVARCHAR(50) NOT NULL,
	[CourseId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT FK_Notifications_Courses_CourseId FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

INSERT INTO [CourseCategories] ([Id], [Name])
VALUES ('46B527EF-AD59-4EE4-AD6C-DB03DF2B8258', 'Programming'),
       ('D85D2A58-9091-4295-8EB1-DC34CD10C65E', 'Design'),
       ('F6318B96-E3CD-4BD0-A6DE-617B1FB6CAAF', 'Marketing');


SELECT *
FROM CourseCategories

INSERT INTO [Courses] 
    ([Id], [OwnerId], [Title], [Description], [Status], [CreatedAt], [GradingSystem], [CoverImageUrl], [BackgroundColor], [LogoUrl],  [CourseCategoryId])
VALUES 
    ('525B8E34-77DC-4859-8864-A0ED56126FE7', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'C# Fundamentals', 'An introductory course on C# programming language for beginners.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/csharp.jpg', '#FFFFFF', 'https://example.com/logo/csharp.png', '46B527EF-AD59-4EE4-AD6C-DB03DF2B8258'),
    ('7F67CE5B-6D48-4EE0-BA81-026FEA71FD1D', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'User Interface Design', 'A course on designing user interfaces and enhancing user experience.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/ui.jpg', '#EFEFEF', 'https://example.com/logo/ui.png', 'D85D2A58-9091-4295-8EB1-DC34CD10C65E'),
    ('B68B7937-1DEE-4D22-8ED3-B730A5E5DEE5', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'Digital Marketing Strategies', 'Learn strategies and tools for effective digital marketing.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/marketing.jpg', '#DDDDDD', 'https://example.com/logo/marketing.png', 'F6318B96-E3CD-4BD0-A6DE-617B1FB6CAAF'),
	    -- Programming
    ('A1E7D2F5-9C44-4E27-AB29-65DBA3A2A1B0', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'ASP.NET Core Web API', 'Build robust RESTful APIs with ASP.NET Core.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/aspnet.jpg', '#F3F3F3', 'https://example.com/logo/aspnet.png', '46B527EF-AD59-4EE4-AD6C-DB03DF2B8258'),
    ('B2E4F6A1-4C4A-4B51-90D4-874E839C1BD7', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'JavaScript for Beginners', 'Learn the fundamentals of JavaScript programming.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/js.jpg', '#FFF8DC', 'https://example.com/logo/js.png', '46B527EF-AD59-4EE4-AD6C-DB03DF2B8258'),
    ('C6E84359-A4E4-4567-B1A5-187F234A7B92', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'Data Structures in C#', 'Understand core data structures and how to implement them in C#.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/datastructures.jpg', '#DFF6F0', 'https://example.com/logo/ds.png', '46B527EF-AD59-4EE4-AD6C-DB03DF2B8258'),
    ('DEAF7645-992D-41A6-8413-BA98EB1B3DF3', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'Algorithms with .NET', 'Solve complex problems with optimized algorithms in .NET.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/algorithms.jpg', '#CCE5FF', 'https://example.com/logo/algorithms.png', '46B527EF-AD59-4EE4-AD6C-DB03DF2B8258'),
    ('9B9C4EDB-CF5E-457D-987D-E245F58D671B', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'Blazor WebAssembly', 'Create rich interactive UIs using Blazor WebAssembly.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/blazor.jpg', '#F0FFFF', 'https://example.com/logo/blazor.png', '46B527EF-AD59-4EE4-AD6C-DB03DF2B8258'),

    -- Design
    ('8F3C8E97-1F41-43B7-837D-204C9E3B87BD', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'UX Research Fundamentals', 'Learn the basics of user experience research and testing.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/uxresearch.jpg', '#FAF0E6', 'https://example.com/logo/ux.png', 'D85D2A58-9091-4295-8EB1-DC34CD10C65E'),
    ('12E24699-F05D-4C2E-8884-71E6740AB7BC', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'Photoshop Essentials', 'Master the core tools and workflows of Adobe Photoshop.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/photoshop.jpg', '#F5F5DC', 'https://example.com/logo/ps.png', 'D85D2A58-9091-4295-8EB1-DC34CD10C65E'),
    ('239FD7FA-1A0A-4FC5-8449-60AA43E76950', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'Typography in Web Design', 'Understand how to effectively use typography in digital interfaces.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/typography.jpg', '#FFF0F5', 'https://example.com/logo/typography.png', 'D85D2A58-9091-4295-8EB1-DC34CD10C65E'),
    ('F1A2ACBC-E08D-466D-9E7F-A9D0AC7E1889', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'Design Systems & Figma', 'Learn how to build and manage design systems with Figma.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/figma.jpg', '#F9F9F9', 'https://example.com/logo/figma.png', 'D85D2A58-9091-4295-8EB1-DC34CD10C65E'),
    ('A7AC2E92-BF6B-48F6-AD09-7ED78911B8B3', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'Mobile App Design', 'Design visually stunning and user-friendly mobile applications.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/mobiledesign.jpg', '#F8F8FF', 'https://example.com/logo/mobile.png', 'D85D2A58-9091-4295-8EB1-DC34CD10C65E'),

    -- Marketing
    ('77C8D918-2251-4E6D-9F98-1A2B8D582002', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'SEO Basics', 'Improve your website ranking with effective SEO techniques.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/seo.jpg', '#FFFFF0', 'https://example.com/logo/seo.png', 'F6318B96-E3CD-4BD0-A6DE-617B1FB6CAAF'),
    ('E9B2D3B5-BDB3-4A93-A963-E01A9A67855D', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'Social Media Marketing', 'Reach your audience with compelling social media strategies.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/socialmedia.jpg', '#F0FFF0', 'https://example.com/logo/social.png', 'F6318B96-E3CD-4BD0-A6DE-617B1FB6CAAF'),
    ('1F4289F7-A6C4-41D6-B9BD-85F729129121', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'Content Marketing Tactics', 'Create and distribute valuable content to attract customers.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/content.jpg', '#F5FFFA', 'https://example.com/logo/content.png', 'F6318B96-E3CD-4BD0-A6DE-617B1FB6CAAF'),
    ('2B7A9F74-E73C-4570-B8A0-2F7A236720DC', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'Email Campaign Optimization', 'Boost conversions with smart email marketing strategies.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/email.jpg', '#FFF5EE', 'https://example.com/logo/email.png', 'F6318B96-E3CD-4BD0-A6DE-617B1FB6CAAF'),
    ('6D5F7383-8A2D-45F5-A843-90D81F09821A', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'Google Ads Mastery', 'Drive traffic with optimized Google Ads campaigns.', 'Approved', GETUTCDATE(), 'PointsOutOf10', 'https://example.com/img/googleads.jpg', '#FFFAFA', 'https://example.com/logo/googleads.png', 'F6318B96-E3CD-4BD0-A6DE-617B1FB6CAAF');

SELECT *
FROM Courses

INSERT INTO CourseParticipants (Id, UserId, CourseId, Role) VALUES 
('c23a5b57-9f00-4b9c-8d07-ec4f12a8016e', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', '525B8E34-77DC-4859-8864-A0ED56126FE7', 'Owner'),
('1d7f65d7-9e8a-4f03-82e5-68c17a0b3e23', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', '7F67CE5B-6D48-4EE0-BA81-026FEA71FD1D', 'Owner'),
('f80ffd39-b33c-4185-90f5-217ab30f40d8', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'B68B7937-1DEE-4D22-8ED3-B730A5E5DEE5', 'Owner'),
('d6266614-0428-48f5-b2e5-5bb125dd48cd', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'A1E7D2F5-9C44-4E27-AB29-65DBA3A2A1B0', 'Owner'),
('06f0e2a4-1594-4b40-9bee-4e827d620c11', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'B2E4F6A1-4C4A-4B51-90D4-874E839C1BD7', 'Owner'),
('5cc89f39-81b9-4f09-8a10-a7101b2be4d1', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'C6E84359-A4E4-4567-B1A5-187F234A7B92', 'Owner'),
('92b0e8b5-1808-4dba-aca7-5d72c72d1d4a', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'DEAF7645-992D-41A6-8413-BA98EB1B3DF3', 'Owner'),
('e6f5776c-5faf-4ec1-b888-07b1f1963db2', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', '9B9C4EDB-CF5E-457D-987D-E245F58D671B', 'Owner'),
('a3728e0a-b839-401b-9458-6a45b9375f8c', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', '8F3C8E97-1F41-43B7-837D-204C9E3B87BD', 'Owner'),
('3bb45e2e-1c6e-4179-bd58-5c4d5c24a2b9', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', '12E24699-F05D-4C2E-8884-71E6740AB7BC', 'Owner'),
('c47e028e-5618-4241-b31b-a413cf6630f2', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', '239FD7FA-1A0A-4FC5-8449-60AA43E76950', 'Owner'),
('5dea6b74-994c-4fc1-8e6a-c8b3dd0fd4e7', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'F1A2ACBC-E08D-466D-9E7F-A9D0AC7E1889', 'Owner'),
('0d047c2e-37c8-4244-9b43-7b0f8c35ec47', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'A7AC2E92-BF6B-48F6-AD09-7ED78911B8B3', 'Owner'),
('4dc2b185-934c-4b82-9c46-2e9a7ffc2d60', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', '77C8D918-2251-4E6D-9F98-1A2B8D582002', 'Owner'),
('b4bb6c2c-8f20-44b6-9a68-4d9977af7c34', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', 'E9B2D3B5-BDB3-4A93-A963-E01A9A67855D', 'Owner'),
('a1dbb8c1-1f42-4c9c-bd6f-ebd5eb24e034', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', '1F4289F7-A6C4-41D6-B9BD-85F729129121', 'Owner'),
('c339df36-3c8b-4ecc-b1b2-c70b0e0607a5', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', '2B7A9F74-E73C-4570-B8A0-2F7A236720DC', 'Owner'),
('ce0e09b2-43ea-4f38-ba4d-191420c5faf6', 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308', '6D5F7383-8A2D-45F5-A843-90D81F09821A', 'Owner');

SELECT *
FROM CourseParticipants

--UPDATE [Courses]
--SET OwnerId = 'dc22e2bc-bb8c-4b2a-949a-a3cae8acc308'