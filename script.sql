USE [DuLieu]
GO
/****** Object:  Table [dbo].[XPath_DanhSachBaiViet]    Script Date: 26/05/2021 5:21:00 PM ******/
DROP TABLE [dbo].[XPath_DanhSachBaiViet]
GO
/****** Object:  Table [dbo].[XPath_ChiTietBaiViet]    Script Date: 26/05/2021 5:21:00 PM ******/
DROP TABLE [dbo].[XPath_ChiTietBaiViet]
GO
/****** Object:  Table [dbo].[TrangWeb]    Script Date: 26/05/2021 5:21:00 PM ******/
DROP TABLE [dbo].[TrangWeb]
GO
/****** Object:  Table [dbo].[BaiViet]    Script Date: 26/05/2021 5:21:00 PM ******/
DROP TABLE [dbo].[BaiViet]
GO
/****** Object:  Table [dbo].[BaiViet]    Script Date: 26/05/2021 5:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiViet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](200) NULL,
	[TieuDePhu] [nvarchar](300) NULL,
	[TomTat] [nvarchar](500) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[ThoiGian] [datetime] NULL,
	[TacGia] [nvarchar](200) NULL,
	[TrangWeb_id] [int] NULL,
	[BaiViet_Url] [nvarchar](200) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrangWeb]    Script Date: 26/05/2021 5:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangWeb](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [nvarchar](300) NULL,
	[ChuyenMuc_Url] [nvarchar](300) NULL,
	[ChuyenMucCon_Url] [nvarchar](300) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[XPath_ChiTietBaiViet]    Script Date: 26/05/2021 5:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XPath_ChiTietBaiViet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](200) NULL,
	[TieuDePhu] [nvarchar](200) NULL,
	[TomTat] [nvarchar](200) NULL,
	[NoiDung] [nvarchar](200) NULL,
	[ThoiGian] [nvarchar](200) NULL,
	[TacGia] [nvarchar](200) NULL,
	[TrangWeb_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[XPath_DanhSachBaiViet]    Script Date: 26/05/2021 5:21:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XPath_DanhSachBaiViet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DanhSach] [nvarchar](200) NULL,
	[TieuDe] [nvarchar](200) NULL,
	[TieuDePhu] [nvarchar](200) NULL,
	[TomTat] [nvarchar](200) NULL,
	[BaiViet_Url] [nvarchar](200) NULL,
	[TrangWeb_id] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[TrangWeb] ON 

INSERT [dbo].[TrangWeb] ([id], [Url], [ChuyenMuc_Url], [ChuyenMucCon_Url]) VALUES (1, N'https://baothuathienhue.vn/', N'van-hoa-nghe-thuat/', N'thong-tin-van-hoa/')
SET IDENTITY_INSERT [dbo].[TrangWeb] OFF
SET IDENTITY_INSERT [dbo].[XPath_ChiTietBaiViet] ON 

INSERT [dbo].[XPath_ChiTietBaiViet] ([id], [TieuDe], [TieuDePhu], [TomTat], [NoiDung], [ThoiGian], [TacGia], [TrangWeb_id]) VALUES (1, N'//*[@id="colcate1"]/h1', N'//*[@id="colcate1"]/p', NULL, N'//*[@id="newscontents"]', N'//*[@id="clear"]/span', N'//*[@id="newscontents"]/p[30]/strong', 1)
SET IDENTITY_INSERT [dbo].[XPath_ChiTietBaiViet] OFF
SET IDENTITY_INSERT [dbo].[XPath_DanhSachBaiViet] ON 

INSERT [dbo].[XPath_DanhSachBaiViet] ([id], [DanhSach], [TieuDe], [TieuDePhu], [TomTat], [BaiViet_Url], [TrangWeb_id]) VALUES (1, N'//*[@id="topcate"]/div[5]/ul/li', N'//a[1]/h3', NULL, N'//p', N'//a[1]', 1)
SET IDENTITY_INSERT [dbo].[XPath_DanhSachBaiViet] OFF
