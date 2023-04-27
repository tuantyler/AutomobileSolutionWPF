/*
 Navicat Premium Data Transfer

 Source Server         : SQLServer_Password
 Source Server Type    : SQL Server
 Source Server Version : 15002000
 Source Catalog        : MyStock
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002000
 File Encoding         : 65001

 Date: 25/11/2022 14:20:41
*/


-- ----------------------------
-- Table structure for Cars
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Cars]') AND type IN ('U'))
	DROP TABLE [dbo].[Cars]
GO

CREATE TABLE [dbo].[Cars] (
  [CarID] int  NOT NULL,
  [CarName] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Manufacturer] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Price] money  NOT NULL,
  [ReleasedYear] int  NOT NULL
)
GO

ALTER TABLE [dbo].[Cars] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Cars
-- ----------------------------
INSERT INTO [dbo].[Cars] ([CarID], [CarName], [Manufacturer], [Price], [ReleasedYear]) VALUES (N'2', N'TEst', N'gfhfgh', N'567567.0000', N'5675')
GO

INSERT INTO [dbo].[Cars] ([CarID], [CarName], [Manufacturer], [Price], [ReleasedYear]) VALUES (N'6', N'Vios', N'Toyota', N'200000000.0000', N'2022')
GO

INSERT INTO [dbo].[Cars] ([CarID], [CarName], [Manufacturer], [Price], [ReleasedYear]) VALUES (N'56', N'ghj', N'fgh', N'456456.0000', N'4564')
GO

INSERT INTO [dbo].[Cars] ([CarID], [CarName], [Manufacturer], [Price], [ReleasedYear]) VALUES (N'57', N'gh', N'aaaaaaa', N'556456.0000', N'2222')
GO


-- ----------------------------
-- Primary Key structure for table Cars
-- ----------------------------
ALTER TABLE [dbo].[Cars] ADD CONSTRAINT [PK__Cars__68A0340E3FDE0259] PRIMARY KEY CLUSTERED ([CarID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

