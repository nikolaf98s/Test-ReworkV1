CREATE VIEW [dbo].[v_Report]
AS 
	SELECT CAST(AVG([S].[Rating]) AS DECIMAL(7,4)) AS [AverageRating], [P].[Name]
	FROM [Survey] [S]
	INNER JOIN [Product] [P]
	ON [S].[ProductId] = [P].[Id]
	GROUP BY [P].[Id], [P].[Name]
