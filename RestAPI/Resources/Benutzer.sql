USE [RestAPI]
GO

/****** Object:  Table [dbo].[Benutzer ]    Script Date: 17.03.2019 14:55:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Benutzer ](
	[ID] [int] NOT NULL,
	[Benutzername] [nvarchar](32) NULL,
	[Kennwort] [nvarchar](64) NULL,
	[Vorname] [nvarchar](32) NULL,
	[Nachname] [nvarchar](64) NULL,
	[Telefonnummer] [nvarchar](16) NULL,
	[Adresse] [nvarchar](255) NULL,
 CONSTRAINT [PK_Benutzer ] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


