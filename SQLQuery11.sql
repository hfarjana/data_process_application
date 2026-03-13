IF EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = 'IX_SearchResultLogs_ComicTitle'
      AND object_id = OBJECT_ID('dbo.SearchResultLogs')
)
BEGIN
    DROP INDEX IX_SearchResultLogs_ComicTitle
    ON dbo.SearchResultLogs;
END

ALTER TABLE dbo.SearchResultLogs
ALTER COLUMN ComicTitle NVARCHAR(450) NOT NULL;

CREATE INDEX IX_SearchResultLogs_ComicTitle
ON dbo.SearchResultLogs (ComicTitle);

