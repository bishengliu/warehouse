-- create the product stock
WITH ps AS
(
		SELECT 
			pd.ProductId
		,	Min(a.Stock / pd.ArticleAmount) as Stock
		,	Sum(pd.Price) as Price

		FROM ProductDefinition as pd
		JOIN Article as a

		ON pd.ArticleId = a.Id

		GROUP BY pd.ProductId

)


SELECT 
	p.Id
	, p.Name
	, ps.Stock
	, ps.Price

FROM ps

JOIN Product as p

ON ps.ProductId = p.Id;



