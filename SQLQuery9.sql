IF NOT EXISTS (
    SELECT * FROM sys.tables WHERE name = 'SearchLogs'
)
BEGIN
    CREATE TABLE dbo.SearchLogs
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        UserId INT NULL,
        QueryText NVARCHAR(255) NULL,
        SearchDate DATETIME NOT NULL
    );
END

IF NOT EXISTS (
    SELECT * FROM sys.tables WHERE name = 'SearchResultLogs'
)
BEGIN
    CREATE TABLE dbo.SearchResultLogs
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        QueryText NVARCHAR(255) NULL,
        ComicTitle NVARCHAR(255) NOT NULL,
        SearchDate DATETIME NOT NULL
    );
END