CREATE DATABASE RusadaApp;
GO

USE [RusadaApp]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SightDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Make] [nvarchar](200) NOT NULL,
	[Model] [nvarchar](200) NOT NULL,
	[Registration] [nvarchar](10) NOT NULL,
	[Location] [nvarchar](255) NOT NULL,
	[SightDate] [datetime] NULL,
	[PhotoFileName] [nvarchar](500) NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_SightDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[SightDetails]([Make], [Model], [Registration], [Location], [SightDate], [PhotoFileName])
VALUES('Airbus','A333-300','AY-ERS','Heathrow Airport','2021-08-11 12:40:00.000','A333-300.jpg')
GO
INSERT INTO [dbo].[SightDetails]([Make], [Model], [Registration], [Location], [SightDate], [PhotoFileName])
VALUES('Airbus','A340-300','RF-HYTRT','katunayake airport','2021-08-11 12:40:00.000','A340-300.jpg')
GO
INSERT INTO [dbo].[SightDetails]([Make], [Model], [Registration], [Location], [SightDate], [PhotoFileName])
VALUES('Boeing','777-200','ER-OOIIT','Sydney Airport','2021-08-11 12:40:00.000','777-200.jpg')
GO
INSERT INTO [dbo].[SightDetails]([Make], [Model], [Registration], [Location], [SightDate], [PhotoFileName])
VALUES('Boeing','777-300','EW-OL','Changi Airport','2021-08-11 12:40:00.000','777-300.jpg')
GO