IF NOT EXISTS (
    SELECT * FROM sys.tables WHERE name = 'DatasetImportLogs'
)
BEGIN
    CREATE TABLE dbo.DatasetImportLogs
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        FileName NVARCHAR(255) NOT NULL,
        ImportDate DATETIME NOT NULL,
        Status NVARCHAR(50) NOT NULL,
        Notes NVARCHAR(1000) NULL
    );
END