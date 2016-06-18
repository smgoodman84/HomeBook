CREATE TABLE [dbo].[Transaction]
(
[TransactionId] [int] NOT NULL IDENTITY(1, 1),
[TransactionDate] [datetime] NOT NULL,
[Type] [nvarchar] (10) NOT NULL,
[Description] [nvarchar] (100) NOT NULL,
[Value] [decimal] (18, 0) NULL,
[Balance] [decimal] (18, 0) NOT NULL,
[AccountName] [nvarchar] (100) NOT NULL,
[AccountNumber] [nvarchar] (100) NOT NULL
)
GO
