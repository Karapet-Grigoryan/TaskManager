namespace TaskManager.DAL
{
    /*
     --CREATE TABLE [User] (
--    Id INT IDENTITY(1,1) PRIMARY KEY,
--    UserName NVARCHAR(100) NOT NULL UNIQUE,
--    Email NVARCHAR(150) NOT NULL UNIQUE,
--    PasswordHash NVARCHAR(255) NOT NULL,
--    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
--);

--INSERT INTO [User] (UserName, Email, PasswordHash)
--VALUES 
--('user_1', 'user1@example.com', 'hashed_password_1'),
--('user_2', 'user2@example.com', 'hashed_password_2'),
--('user_3', 'user3@example.com', 'hashed_password_3'),
--('user_4', 'user4@example.com', 'hashed_password_4'),
--('user_5', 'user5@example.com', 'hashed_password_5');

----------------------------------------------------------------------------------

--CREATE TABLE TaskStatus (
--    Id INT PRIMARY KEY,
--    Name NVARCHAR(50) NOT NULL UNIQUE
--);

--INSERT INTO TaskStatus (Id, Name) VALUES
--(1, 'Pending'),
--(2, 'In Progress'),
--(3, 'Completed');

----------------------------------------------------------------------------------

--CREATE TABLE PriorityLevel (
--    Id INT PRIMARY KEY,
--    Name NVARCHAR(50) NOT NULL UNIQUE,
--    ColorHexCode NVARCHAR(7) NULL -- Օրինակ՝ '#FF0000' Hex կոդերի համար
--);

--INSERT INTO PriorityLevel (Id, Name, ColorHexCode) VALUES
--(1, 'High', '#FF0000'),    -- Կարմիր
--(2, 'Medium', '#FFFF00'),  -- Դեղին
--(3, 'Low', '#008000');     -- Կանաչ

----------------------------------------------------------------------------------

--CREATE TABLE TodoTask (
--    Id INT IDENTITY(1,1) PRIMARY KEY,
--    Title NVARCHAR(200) NOT NULL,
--    Description NVARCHAR(MAX) NULL,
--    PriorityId INT NOT NULL DEFAULT 2, -- 1=High, 2=Medium, 3=Low
--    StatusId INT NOT NULL DEFAULT 1, -- Pending
--	CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
--    DueDate DATETIME NULL,
--    UserId INT NOT NULL,

--   -- Foreign Key
--    CONSTRAINT FK_TodoTask_PriorityLevel FOREIGN KEY (PriorityId) 
--        REFERENCES PriorityLevel(Id),

--    CONSTRAINT FK_TodoTask_TaskStatus FOREIGN KEY (StatusId) 
--        REFERENCES TaskStatus(Id),

--    CONSTRAINT FK_TodoTask_User FOREIGN KEY (UserId) 
--        REFERENCES [User](Id) ON DELETE CASCADE
--);

--INSERT INTO TodoTask (Title, Description, PriorityId, StatusId, DueDate, UserId) 
--VALUES
--('Task_Title_1', 'Description_1', 1, 3, '10-05-2026', 1),
--('Task_Title_2', 'Description_2', 2, 2, '15-05-2026', 2),
--('Task_Title_3', 'Description_3', 1, 1, '22-06-2026', 3),
--('Task_Title_4', 'Description_4', 3, 1,  NULL, 4),
--('Task_Title_5', 'Description_5', 1, 3, '1-07-2026', 5),
--('Task_Title_6', 'Description_6', 3, 3, '17-05-2026', 3),
--('Task_Title_7', 'Description_7', 1, 1, '3-06-2026', 1),
--('Task_Title_8', 'Description_8', 2, 1,  NULL, 4),
--('Task_Title_9', 'Description_9', 1, 3, '24-05-2026', 2),
--('Task_Title_10', 'Description_10', 2, 2, '12-05-2026', 5),
--('Task_Title_11', 'Description_11', 1, 2, '7-06-2026', 1),
--('Task_Title_12', 'Description_12', 3, 1,  NULL, 4);
     */
}
