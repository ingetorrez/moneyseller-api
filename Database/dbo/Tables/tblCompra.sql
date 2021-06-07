CREATE TABLE [dbo].[tblCompra] (
    [id]        INT             IDENTITY (1, 1) NOT NULL,
    [idUsuario] INT             NOT NULL,
    [monto]     DECIMAL (18, 3) NOT NULL,
    [moneda]    NVARCHAR (10)   NOT NULL,
    [cambio]     DECIMAL (18, 3) NOT NULL,
    [fecha]     DATETIME        CONSTRAINT [DF_tblCompra_fecha] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_tblCompra] PRIMARY KEY CLUSTERED ([id] ASC)
);





