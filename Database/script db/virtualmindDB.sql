CREATE DATABASE [VirtualmindDB]

go

USE [VirtualmindDB]

GO

CREATE TABLE [dbo].[tblCompra](
	[id] [int] identity primary key NOT NULL,
	[idUsuario] [int] NOT NULL,
	[monto] [decimal](18, 3) NOT NULL,
	[moneda] [nvarchar](10) NOT NULL,
	[cambio] [decimal](18, 3) NOT NULL,
	[fecha] [datetime] NOT NULL
)

GO
ALTER TABLE [dbo].[tblCompra] ADD  CONSTRAINT [DF_tblCompra_fecha]  DEFAULT (getdate()) FOR [fecha]
GO

