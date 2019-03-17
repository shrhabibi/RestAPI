USE [RestAPI]
GO

/****** Object:  Table [dbo].[Versicherungsvertrag]    Script Date: 17.03.2019 14:56:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Versicherungsvertrag](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Benutzer] [int] NULL,
	[Versicherungspolice] [int] NULL,
 CONSTRAINT [PK_Versicherungsvertrag] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Versicherungsvertrag]  WITH CHECK ADD  CONSTRAINT [FK_Versicherungsvertrag_Benutzer ] FOREIGN KEY([Benutzer])
REFERENCES [dbo].[Benutzer ] ([ID])
GO

ALTER TABLE [dbo].[Versicherungsvertrag] CHECK CONSTRAINT [FK_Versicherungsvertrag_Benutzer ]
GO

ALTER TABLE [dbo].[Versicherungsvertrag]  WITH CHECK ADD  CONSTRAINT [FK_Versicherungsvertrag_Versicherungspolice] FOREIGN KEY([Versicherungspolice])
REFERENCES [dbo].[Versicherungspolice] ([ID])
GO

ALTER TABLE [dbo].[Versicherungsvertrag] CHECK CONSTRAINT [FK_Versicherungsvertrag_Versicherungspolice]
GO


