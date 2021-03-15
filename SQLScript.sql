USE [master]
GO
/****** Object:  Database [Automat]    Script Date: 3/15/2021 2:58:26 PM ******/
CREATE DATABASE [Automat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Automat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.ABAKUSADAM\MSSQL\DATA\Automat.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Automat_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.ABAKUSADAM\MSSQL\DATA\Automat_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Automat] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Automat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Automat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Automat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Automat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Automat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Automat] SET ARITHABORT OFF 
GO
ALTER DATABASE [Automat] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Automat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Automat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Automat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Automat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Automat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Automat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Automat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Automat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Automat] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Automat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Automat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Automat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Automat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Automat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Automat] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Automat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Automat] SET RECOVERY FULL 
GO
ALTER DATABASE [Automat] SET  MULTI_USER 
GO
ALTER DATABASE [Automat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Automat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Automat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Automat] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Automat] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Automat] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Automat', N'ON'
GO
ALTER DATABASE [Automat] SET QUERY_STORE = OFF
GO
USE [Automat]
GO
/****** Object:  Table [dbo].[Campaings]    Script Date: 3/15/2021 2:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campaings](
	[Id] [int] NOT NULL,
	[Slot] [int] NOT NULL,
	[CampaignDesc] [varchar](100) NOT NULL,
	[DiscountRatio] [real] NOT NULL,
 CONSTRAINT [PK_Campaings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Slot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethods]    Script Date: 3/15/2021 2:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethods](
	[Id] [int] NOT NULL,
	[PaymentMethodDesc] [varchar](100) NOT NULL,
 CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/15/2021 2:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Slot] [int] NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[NumberOfProducts] [int] NOT NULL,
	[PriceOfProduct] [money] NOT NULL,
	[IsRequiredSugarSelection] [bit] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
 CONSTRAINT [PK_Products_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Slot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 3/15/2021 2:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [int] NOT NULL,
	[ProdyctTypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 3/15/2021 2:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Slot] [int] NOT NULL,
	[SelectedPieces] [int] NOT NULL,
	[TransactionAmount] [money] NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PaymentMethods] ([Id], [PaymentMethodDesc]) VALUES (1, N'Nakit')
INSERT [dbo].[PaymentMethods] ([Id], [PaymentMethodDesc]) VALUES (2, N'Kredi Kartı')
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (1, 1, 1, N'Gofret', 3, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (2, 2, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (3, 3, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (4, 4, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (5, 5, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (6, 6, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (7, 7, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (8, 8, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (9, 9, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (10, 10, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (11, 11, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (12, 12, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (13, 13, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (14, 14, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (15, 15, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (16, 16, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (17, 17, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (18, 18, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (19, 19, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (20, 20, 1, N'Gofret', 5, 5.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (24, 21, 2, N'Cola', 5, 10.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (25, 22, 2, N'Cola', 5, 10.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (26, 23, 2, N'Cola', 5, 10.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (27, 24, 2, N'Cola', 5, 10.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (28, 25, 2, N'Cola', 5, 10.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (29, 26, 2, N'Fanta', 5, 10.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (30, 27, 2, N'Fanta', 5, 10.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (31, 28, 2, N'Fanta', 5, 10.0000, 0, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (32, 29, 2, N'Çay', 100, 2.0000, 1, 1)
INSERT [dbo].[Products] ([Id], [Slot], [ProductTypeId], [ProductName], [NumberOfProducts], [PriceOfProduct], [IsRequiredSugarSelection], [IsAvailable]) VALUES (33, 30, 2, N'Kahve', 100, 4.0000, 1, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[ProductTypes] ([Id], [ProdyctTypeName]) VALUES (1, N'Yiyecek')
INSERT [dbo].[ProductTypes] ([Id], [ProdyctTypeName]) VALUES (2, N'İçecek')
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([Id], [Slot], [SelectedPieces], [TransactionAmount], [IsPaid], [CreateDate]) VALUES (1, 1, 1, 5.0000, 1, CAST(N'2021-03-14T19:02:57.093' AS DateTime))
INSERT [dbo].[Transactions] ([Id], [Slot], [SelectedPieces], [TransactionAmount], [IsPaid], [CreateDate]) VALUES (2, 1, 1, 5.0000, 1, CAST(N'2021-03-14T19:05:07.750' AS DateTime))
INSERT [dbo].[Transactions] ([Id], [Slot], [SelectedPieces], [TransactionAmount], [IsPaid], [CreateDate]) VALUES (3, 2, 1, 5.0000, 0, CAST(N'2021-03-15T14:02:32.200' AS DateTime))
INSERT [dbo].[Transactions] ([Id], [Slot], [SelectedPieces], [TransactionAmount], [IsPaid], [CreateDate]) VALUES (4, 2, 1, 5.0000, 0, CAST(N'2021-03-15T14:03:07.077' AS DateTime))
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
ALTER TABLE [dbo].[Campaings] ADD  CONSTRAINT [DF_Campaings_CampaignDesc]  DEFAULT ('') FOR [CampaignDesc]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_IsHotDrinkProduck]  DEFAULT ((0)) FOR [IsRequiredSugarSelection]
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_IsPaid]  DEFAULT ((0)) FOR [IsPaid]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTypes] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductTypes] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductTypes]
GO
USE [master]
GO
ALTER DATABASE [Automat] SET  READ_WRITE 
GO
