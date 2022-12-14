USE [master]
GO
/****** Object:  Database [BDUNACEM]    Script Date: 13/11/2022 16:55:30 ******/
CREATE DATABASE [BDUNACEM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDUNACEM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDUNACEM.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDUNACEM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BDUNACEM_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDUNACEM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDUNACEM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDUNACEM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDUNACEM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDUNACEM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDUNACEM] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDUNACEM] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BDUNACEM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDUNACEM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDUNACEM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDUNACEM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDUNACEM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDUNACEM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDUNACEM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDUNACEM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDUNACEM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDUNACEM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDUNACEM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDUNACEM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDUNACEM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDUNACEM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDUNACEM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDUNACEM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDUNACEM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDUNACEM] SET  MULTI_USER 
GO
ALTER DATABASE [BDUNACEM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDUNACEM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDUNACEM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDUNACEM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDUNACEM', N'ON'
GO
USE [BDUNACEM]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BrickFormats]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrickFormats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Group] [varchar](50) NULL,
	[BrickA] [varchar](50) NULL,
	[BrickB] [varchar](50) NULL,
	[QuantityA] [int] NOT NULL,
	[QuantityB] [int] NOT NULL,
	[Diameter] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_BrickFormats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudgetCiCurrency]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetCiCurrency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudgetCIId] [int] NOT NULL,
	[Name] [varchar](500) NULL,
	[Symbol] [varchar](500) NULL,
	[Equivalence] [float] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_BudgetCiCurrency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudgetCiRows]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetCiRows](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudgetCiId] [int] NOT NULL,
	[Zone] [varchar](500) NULL,
	[Area] [decimal](5, 2) NOT NULL,
	[ThicknessC] [float] NOT NULL,
	[ThicknessI] [float] NOT NULL,
	[CostC] [float] NOT NULL,
	[CostI] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
	[ProviderInsulatingId] [int] NULL,
	[ProviderConcreteId] [int] NULL,
	[materialRequirementC] [float] NULL,
	[materialRequirementI] [float] NULL,
 CONSTRAINT [PK_BudgetCiRows] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudgetCurrency]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetCurrency](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudgetId] [int] NOT NULL,
	[Name] [nvarchar](4000) NOT NULL,
	[Symbol] [nvarchar](4000) NOT NULL,
	[Equivalence] [float] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_BudgetCurrency] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Budgets]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Budgets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TotalAmount] [float] NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
	[OvenLarge] [int] NULL,
	[OvenDiameter] [int] NULL,
	[Description] [varchar](400) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Budgets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudgetsCi]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetsCi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Line] [nvarchar](255) NULL,
	[Date] [datetime] NULL,
	[Total] [float] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
	[Description] [nvarchar](450) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_BudgetsCi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudgetStretch]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetStretch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudgetId] [int] NOT NULL,
	[BrickFormatId] [int] NULL,
	[BrickACost] [float] NOT NULL,
	[BrickBCost] [float] NOT NULL,
	[WedgeAQuantity] [float] NOT NULL,
	[WedgeBQuantity] [float] NOT NULL,
	[WedgeACost] [float] NOT NULL,
	[WedgeBCost] [float] NOT NULL,
	[TotalAmount] [float] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
	[ProviderBrickId] [int] NULL,
	[PositionIni] [int] NULL,
	[PositionEnd] [int] NULL,
	[BrickLNormal] [int] NULL,
 CONSTRAINT [PK_BudgetStretch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hex] [int] NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gallery]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gallery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VersionId] [int] NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[Image] [varbinary](max) NULL,
	[Title] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Gallery] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Headquarters]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Headquarters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Headquarters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ovens]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ovens](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Diameter] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Headquarter] [varchar](255) NULL,
	[Large] [int] NULL,
 CONSTRAINT [PK_Ovens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProviderBricks]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProviderBricks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProviderImportationId] [int] NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[RecommendedZone] [nvarchar](4000) NULL,
	[Composition] [nvarchar](4000) NULL,
	[Density] [nvarchar](4000) NULL,
	[Porosity] [nvarchar](4000) NULL,
	[Ccs] [nvarchar](4000) NULL,
	[ThermalConductivity300] [nvarchar](100) NULL,
	[ThermalConductivity700] [nvarchar](100) NULL,
	[ThermalConductivity100] [nvarchar](100) NULL,
	[DeletedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_ProviderBricks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProviderConcretes]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProviderConcretes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProviderImportationId] [int] NOT NULL,
	[Name] [nvarchar](400) NOT NULL,
	[RecommendedZone] [varchar](4000) NULL,
	[Composition] [varchar](4000) NULL,
	[MaterialNeeded] [varchar](4000) NULL,
	[WaterMix] [varchar](4000) NULL,
	[Temperature] [varchar](4000) NULL,
	[ThermalConductivity300] [varchar](4000) NULL,
	[ThermalConductivity700] [varchar](4000) NULL,
	[ThermalConductivity100] [varchar](4000) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_ProviderConcretes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProviderImportations]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProviderImportations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProviderId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_ProviderImportations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProviderInsulatings]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProviderInsulatings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProviderImportationId] [int] NOT NULL,
	[Name] [varchar](400) NOT NULL,
	[RecommendedZone] [varchar](4000) NULL,
	[Composition] [varchar](4000) NULL,
	[MaterialNeeded] [varchar](4000) NULL,
	[WaterMix] [varchar](4000) NULL,
	[Temperature] [varchar](4000) NULL,
	[ThermalConductivity300] [varchar](4000) NULL,
	[ThermalConductivity700] [varchar](4000) NULL,
	[ThermalConductivity100] [varchar](4000) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime] NULL,
 CONSTRAINT [PK_ProviderInsulatings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Providers]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Providers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Providers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stretchs]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stretchs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VersionId] [int] NOT NULL,
	[BrickFormatId] [int] NOT NULL,
	[ProviderBrickId] [int] NOT NULL,
	[PositionEnd] [float] NOT NULL,
	[ColorId] [int] NOT NULL,
	[PositionIni] [float] NOT NULL,
	[TextureId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Stretchs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickness]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickness](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Height] [int] NOT NULL,
	[width] [int] NOT NULL,
	[Name] [nvarchar](200) NULL,
	[UserId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Tickness] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicknessVersionRegisters]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicknessVersionRegisters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TicknessVersionId] [int] NOT NULL,
	[position] [int] NULL,
	[value] [int] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_TicknessVersionRegisters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicknessVersions]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicknessVersions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TicknessId] [int] NOT NULL,
	[Name] [nvarchar](200) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_TicknessVersions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tyres]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tyres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ColorId] [int] NOT NULL,
	[OvenId] [int] NOT NULL,
	[TextureId] [int] NOT NULL,
	[Position] [float] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Tyres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Token] [nvarchar](max) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[ExpireIn] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Versions]    Script Date: 13/11/2022 16:55:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Versions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OvenId] [int] NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DateIni] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Versions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_BudgetCiCurrency_BudgetCiId]    Script Date: 13/11/2022 16:55:30 ******/
CREATE NONCLUSTERED INDEX [IX_BudgetCiCurrency_BudgetCiId] ON [dbo].[BudgetCiCurrency]
(
	[BudgetCIId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BudgetCiRows_BudgetCiId]    Script Date: 13/11/2022 16:55:30 ******/
CREATE NONCLUSTERED INDEX [IX_BudgetCiRows_BudgetCiId] ON [dbo].[BudgetCiRows]
(
	[BudgetCiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BudgetCiRows_ProviderConcretesId]    Script Date: 13/11/2022 16:55:30 ******/
CREATE NONCLUSTERED INDEX [IX_BudgetCiRows_ProviderConcretesId] ON [dbo].[BudgetCiRows]
(
	[ProviderConcreteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BudgetCiRows_ProviderInsulatingId]    Script Date: 13/11/2022 16:55:30 ******/
CREATE NONCLUSTERED INDEX [IX_BudgetCiRows_ProviderInsulatingId] ON [dbo].[BudgetCiRows]
(
	[ProviderInsulatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProviderConcretes_ProviderImportationId]    Script Date: 13/11/2022 16:55:30 ******/
CREATE NONCLUSTERED INDEX [IX_ProviderConcretes_ProviderImportationId] ON [dbo].[ProviderConcretes]
(
	[ProviderImportationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProviderInsulatings_ProviderImportationId]    Script Date: 13/11/2022 16:55:30 ******/
CREATE NONCLUSTERED INDEX [IX_ProviderInsulatings_ProviderImportationId] ON [dbo].[ProviderInsulatings]
(
	[ProviderImportationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BrickFormats] ADD  DEFAULT ((0)) FOR [QuantityA]
GO
ALTER TABLE [dbo].[BrickFormats] ADD  DEFAULT ((0)) FOR [QuantityB]
GO
ALTER TABLE [dbo].[BrickFormats] ADD  DEFAULT ((0)) FOR [Diameter]
GO
ALTER TABLE [dbo].[BrickFormats] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[BudgetCurrency] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[BudgetStretch] ADD  CONSTRAINT [DF__BudgetStr__Budge__15DA3E5D]  DEFAULT ((0)) FOR [BudgetId]
GO
ALTER TABLE [dbo].[Gallery] ADD  DEFAULT (N'') FOR [Title]
GO
ALTER TABLE [dbo].[Headquarters] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Ovens] ADD  CONSTRAINT [DF__Ovens__UserId__6FE99F9F]  DEFAULT ((0)) FOR [UserId]
GO
ALTER TABLE [dbo].[Ovens] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[Ovens] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ProviderImportations] ADD  CONSTRAINT [DF__ProviderI__Creat__5535A963]  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Providers] ADD  DEFAULT (N'') FOR [Name]
GO
ALTER TABLE [dbo].[Providers] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Stretchs] ADD  CONSTRAINT [DF__Stretchs__BrickF__719CDDE7]  DEFAULT ((0)) FOR [BrickFormatId]
GO
ALTER TABLE [dbo].[Stretchs] ADD  CONSTRAINT [DF__Stretchs__Provid__756D6ECB]  DEFAULT ((0)) FOR [ProviderBrickId]
GO
ALTER TABLE [dbo].[Stretchs] ADD  CONSTRAINT [DF__Stretchs__Positi__73852659]  DEFAULT ((0.0000000000000000e+000)) FOR [PositionEnd]
GO
ALTER TABLE [dbo].[Stretchs] ADD  CONSTRAINT [DF__Stretchs__Color___72910220]  DEFAULT ((0)) FOR [ColorId]
GO
ALTER TABLE [dbo].[Stretchs] ADD  CONSTRAINT [DF__Stretchs__Positi__74794A92]  DEFAULT ((0.0000000000000000e+000)) FOR [PositionIni]
GO
ALTER TABLE [dbo].[Stretchs] ADD  CONSTRAINT [DF__Stretchs__Textur__76619304]  DEFAULT ((0)) FOR [TextureId]
GO
ALTER TABLE [dbo].[Stretchs] ADD  CONSTRAINT [DF__Stretchs__Creati__6FB49575]  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[TicknessVersionRegisters] ADD  CONSTRAINT [DF__TicknessVersionRegisters__TicknessVersionId__6FE99F9F]  DEFAULT ((0)) FOR [TicknessVersionId]
GO
ALTER TABLE [dbo].[TicknessVersions] ADD  CONSTRAINT [DF__TicknessVersions__TicknessId__6FE99F9F]  DEFAULT ((0)) FOR [TicknessId]
GO
ALTER TABLE [dbo].[Tyres] ADD  CONSTRAINT [DF__Tyres__ColorId__68487DD7]  DEFAULT ((0)) FOR [ColorId]
GO
ALTER TABLE [dbo].[Tyres] ADD  CONSTRAINT [DF__Tyres__OvenId__6E01572D]  DEFAULT ((0)) FOR [OvenId]
GO
ALTER TABLE [dbo].[Tyres] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Versions] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedAt]
GO
ALTER TABLE [dbo].[BudgetCiCurrency]  WITH CHECK ADD  CONSTRAINT [FK_BudgetCiCurrency_BudgetsCi_BudgetCiId] FOREIGN KEY([BudgetCIId])
REFERENCES [dbo].[BudgetsCi] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BudgetCiCurrency] CHECK CONSTRAINT [FK_BudgetCiCurrency_BudgetsCi_BudgetCiId]
GO
ALTER TABLE [dbo].[BudgetCiRows]  WITH CHECK ADD  CONSTRAINT [FK_BudgetCiRows_BudgetsCi_BudgetCiId] FOREIGN KEY([BudgetCiId])
REFERENCES [dbo].[BudgetsCi] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BudgetCiRows] CHECK CONSTRAINT [FK_BudgetCiRows_BudgetsCi_BudgetCiId]
GO
ALTER TABLE [dbo].[BudgetCiRows]  WITH CHECK ADD  CONSTRAINT [FK_BudgetCiRows_ProviderConcretes_ProviderConcretesId] FOREIGN KEY([ProviderConcreteId])
REFERENCES [dbo].[ProviderConcretes] ([Id])
GO
ALTER TABLE [dbo].[BudgetCiRows] CHECK CONSTRAINT [FK_BudgetCiRows_ProviderConcretes_ProviderConcretesId]
GO
ALTER TABLE [dbo].[BudgetCiRows]  WITH CHECK ADD  CONSTRAINT [FK_BudgetCiRows_ProviderInsulatings_ProviderInsulatingId] FOREIGN KEY([ProviderInsulatingId])
REFERENCES [dbo].[ProviderInsulatings] ([Id])
GO
ALTER TABLE [dbo].[BudgetCiRows] CHECK CONSTRAINT [FK_BudgetCiRows_ProviderInsulatings_ProviderInsulatingId]
GO
ALTER TABLE [dbo].[BudgetCurrency]  WITH CHECK ADD  CONSTRAINT [FK_BudgetCurrency_Budgets_BudgetId] FOREIGN KEY([BudgetId])
REFERENCES [dbo].[Budgets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BudgetCurrency] CHECK CONSTRAINT [FK_BudgetCurrency_Budgets_BudgetId]
GO
ALTER TABLE [dbo].[BudgetStretch]  WITH CHECK ADD  CONSTRAINT [FK_BudgetStretch_BrickFormats_BrickFormatId] FOREIGN KEY([BrickFormatId])
REFERENCES [dbo].[BrickFormats] ([Id])
GO
ALTER TABLE [dbo].[BudgetStretch] CHECK CONSTRAINT [FK_BudgetStretch_BrickFormats_BrickFormatId]
GO
ALTER TABLE [dbo].[BudgetStretch]  WITH CHECK ADD  CONSTRAINT [FK_BudgetStretch_Budgets_BudgetId] FOREIGN KEY([BudgetId])
REFERENCES [dbo].[Budgets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BudgetStretch] CHECK CONSTRAINT [FK_BudgetStretch_Budgets_BudgetId]
GO
ALTER TABLE [dbo].[Gallery]  WITH CHECK ADD  CONSTRAINT [FK_Gallery_Versions_VersionId] FOREIGN KEY([VersionId])
REFERENCES [dbo].[Versions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Gallery] CHECK CONSTRAINT [FK_Gallery_Versions_VersionId]
GO
ALTER TABLE [dbo].[Ovens]  WITH CHECK ADD  CONSTRAINT [FK_Ovens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ovens] CHECK CONSTRAINT [FK_Ovens_Users_UserId]
GO
ALTER TABLE [dbo].[ProviderBricks]  WITH NOCHECK ADD  CONSTRAINT [FK_ProviderBricks_ProviderImportations_ProviderImportationId] FOREIGN KEY([ProviderImportationId])
REFERENCES [dbo].[ProviderImportations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProviderBricks] CHECK CONSTRAINT [FK_ProviderBricks_ProviderImportations_ProviderImportationId]
GO
ALTER TABLE [dbo].[ProviderConcretes]  WITH NOCHECK ADD  CONSTRAINT [FK_ProviderConcretes_ProviderImportations_ProviderImportationId] FOREIGN KEY([ProviderImportationId])
REFERENCES [dbo].[ProviderImportations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProviderConcretes] CHECK CONSTRAINT [FK_ProviderConcretes_ProviderImportations_ProviderImportationId]
GO
ALTER TABLE [dbo].[ProviderImportations]  WITH CHECK ADD  CONSTRAINT [FK_ProviderImportations_Providers_ProviderId] FOREIGN KEY([ProviderId])
REFERENCES [dbo].[Providers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProviderImportations] CHECK CONSTRAINT [FK_ProviderImportations_Providers_ProviderId]
GO
ALTER TABLE [dbo].[ProviderInsulatings]  WITH NOCHECK ADD  CONSTRAINT [FK_ProviderInsulatings_ProviderImportations_ProviderImportationId] FOREIGN KEY([ProviderImportationId])
REFERENCES [dbo].[ProviderImportations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProviderInsulatings] CHECK CONSTRAINT [FK_ProviderInsulatings_ProviderImportations_ProviderImportationId]
GO
ALTER TABLE [dbo].[Stretchs]  WITH CHECK ADD  CONSTRAINT [FK_Stretchs_BrickFormats_BrickFormatId] FOREIGN KEY([BrickFormatId])
REFERENCES [dbo].[BrickFormats] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stretchs] CHECK CONSTRAINT [FK_Stretchs_BrickFormats_BrickFormatId]
GO
ALTER TABLE [dbo].[Stretchs]  WITH CHECK ADD  CONSTRAINT [FK_Stretchs_ProviderBricks_ProviderBrickId] FOREIGN KEY([ProviderBrickId])
REFERENCES [dbo].[ProviderBricks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stretchs] CHECK CONSTRAINT [FK_Stretchs_ProviderBricks_ProviderBrickId]
GO
ALTER TABLE [dbo].[Stretchs]  WITH CHECK ADD  CONSTRAINT [FK_Stretchs_Versions_VersionId] FOREIGN KEY([VersionId])
REFERENCES [dbo].[Versions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stretchs] CHECK CONSTRAINT [FK_Stretchs_Versions_VersionId]
GO
ALTER TABLE [dbo].[TicknessVersionRegisters]  WITH CHECK ADD  CONSTRAINT [FK_TicknessVersionRegisters_TicknessVersions_TicknessVersionId] FOREIGN KEY([TicknessVersionId])
REFERENCES [dbo].[TicknessVersions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TicknessVersionRegisters] CHECK CONSTRAINT [FK_TicknessVersionRegisters_TicknessVersions_TicknessVersionId]
GO
ALTER TABLE [dbo].[TicknessVersions]  WITH CHECK ADD  CONSTRAINT [FK_TicknessVersions_Tickness_TicknessId] FOREIGN KEY([TicknessId])
REFERENCES [dbo].[Tickness] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TicknessVersions] CHECK CONSTRAINT [FK_TicknessVersions_Tickness_TicknessId]
GO
ALTER TABLE [dbo].[Tyres]  WITH CHECK ADD  CONSTRAINT [FK_Tyres_Ovens_OvenId] FOREIGN KEY([OvenId])
REFERENCES [dbo].[Ovens] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tyres] CHECK CONSTRAINT [FK_Tyres_Ovens_OvenId]
GO
ALTER TABLE [dbo].[Versions]  WITH CHECK ADD  CONSTRAINT [FK_Versions_Ovens_OvenId] FOREIGN KEY([OvenId])
REFERENCES [dbo].[Ovens] ([Id])
GO
ALTER TABLE [dbo].[Versions] CHECK CONSTRAINT [FK_Versions_Ovens_OvenId]
GO
USE [master]
GO
ALTER DATABASE [BDUNACEM] SET  READ_WRITE 
GO

INSERT INTO [Users]([Email], [Name], [CreatedAt]) Values('ext_prueba_mulesoft@unacem.pe', 'Usuario Prueba', '2022-11-4');