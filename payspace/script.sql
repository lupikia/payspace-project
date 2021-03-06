USE [payscape]
GO
/****** Object:  Table [dbo].[Tax_type]    Script Date: 2/10/2021 11:59:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tax_type](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[postal_code] [text] NULL,
	[calculation_type] [text] NULL,
 CONSTRAINT [PK_Tax_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
