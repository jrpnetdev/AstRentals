CREATE PROCEDURE [dbo].[SearchCars]
(
	@term varchar(255) = '%'
)
AS

	SET NOCOUNT ON;

	SELECT 
		*
	FROM 
	  Cars
	WHERE
	   Make + ' ' + Model + ' ' + CAST([Year] as nvarchar(5)) LIKE '%' + @term + '%'
	   OR
	   Model + ' ' + Make + ' ' + CAST([Year] as nvarchar(5)) LIKE '%' + @term + '%'
	   OR
	   CAST([Year] as nvarchar(5)) + ' ' + Model + ' ' + Make LIKE '%' + @term + '%'
	   OR
	   CAST([Year] as nvarchar(5)) + ' ' + Make + ' ' + Model LIKE '%' + @term + '%'
	   OR
	   Make + ' ' + CAST([Year] as nvarchar(5)) + ' ' + Model LIKE '%' + @term + '%'
	   OR
	   Model + ' ' + CAST([Year] as nvarchar(5)) + ' ' + Make LIKE '%' + @term + '%'
GO