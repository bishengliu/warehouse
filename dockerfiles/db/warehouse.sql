if db_id('warehouse') is null
	CREATE DATABASE [warehouse]
GO


USE [warehouse]
GO

CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Stock] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[UpdateAt] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Article] ADD  DEFAULT ((0)) FOR [Stock]
GO

ALTER TABLE [dbo].[Article] ADD  DEFAULT ('2021-04-30T23:23:29.9941030Z') FOR [UpdateAt]
GO

ALTER TABLE [dbo].[Article] ADD  DEFAULT ((0.0)) FOR [Price]
GO


CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[UpdateAt] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product] ADD  DEFAULT ('2021-04-30T23:23:29.9952399Z') FOR [UpdateAt]
GO

CREATE TABLE [dbo].[ProductDefinition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ArticleId] [int] NOT NULL,
	[ArticleAmount] [int] NOT NULL,
	[UpdateAt] [datetime2](7) NOT NULL,
	[UpdateBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProductDefinition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProductDefinition] ADD  DEFAULT ((0.0)) FOR [Price]
GO

ALTER TABLE [dbo].[ProductDefinition] ADD  DEFAULT ((1)) FOR [ArticleAmount]
GO

ALTER TABLE [dbo].[ProductDefinition] ADD  DEFAULT ('2021-04-30T23:23:30.0030315Z') FOR [UpdateAt]
GO

ALTER TABLE [dbo].[ProductDefinition]  WITH CHECK ADD  CONSTRAINT [FK_Article_ProductCompositions] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([Id])
GO

ALTER TABLE [dbo].[ProductDefinition] CHECK CONSTRAINT [FK_Article_ProductCompositions]
GO

ALTER TABLE [dbo].[ProductDefinition]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCompositions] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO

ALTER TABLE [dbo].[ProductDefinition] CHECK CONSTRAINT [FK_Product_ProductCompositions]
GO



-- create view
CREATE VIEW [dbo].[ProductStock] AS 
        SELECT 
	        p.Id
	        , p.Name
	        , ps.Stock
	        , ps.Price

        FROM 
        (
		                SELECT 
			                pd.ProductId
		                ,	Min(a.Stock / pd.ArticleAmount) as Stock
		                ,	Sum(pd.Price) as Price

		                FROM ProductDefinition as pd
		                JOIN Article as a

		                ON pd.ArticleId = a.Id

		                GROUP BY pd.ProductId

        ) as ps

        JOIN Product as p

        ON ps.ProductId = p.Id;
GO
