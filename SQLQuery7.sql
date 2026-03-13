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

IF NOT EXISTS (
    SELECT * FROM sys.tables WHERE name = 'SavedSearches'
)
BEGIN
    CREATE TABLE dbo.SavedSearches
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        UserId INT NOT NULL,
        QueryText NVARCHAR(255) NULL,
        Genre NVARCHAR(100) NULL,
        SortOption NVARCHAR(50) NULL,
        SavedDate DATETIME NOT NULL,
        FOREIGN KEY (UserId) REFERENCES dbo.Users(Id)
    );
END