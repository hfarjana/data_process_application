IF NOT EXISTS (
    SELECT * FROM sys.tables WHERE name = 'SavedComics'
)
BEGIN
    CREATE TABLE dbo.SavedComics
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        UserId INT NOT NULL,
        ComicTitle NVARCHAR(255) NOT NULL,
        SavedDate DATETIME NOT NULL,
        FOREIGN KEY (UserId) REFERENCES dbo.Users(Id)
    );
END