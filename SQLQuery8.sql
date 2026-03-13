IF NOT EXISTS (
    SELECT * FROM sys.tables WHERE name = 'FlaggedRecords'
)
BEGIN
    CREATE TABLE dbo.FlaggedRecords
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        ComicTitle NVARCHAR(255) NOT NULL,
        FlagReason NVARCHAR(500) NULL,
        FlaggedByUserId INT NOT NULL,
        FlaggedDate DATETIME NOT NULL,
        FOREIGN KEY (FlaggedByUserId) REFERENCES dbo.Users(Id)
    );
END