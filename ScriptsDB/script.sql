USE [master]
GO
/****** Object:  Database [EmpleadosDB]    Script Date: 19/8/2024 18:02:58 ******/
CREATE DATABASE [EmpleadosDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmpleadosDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EmpleadosDB.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmpleadosDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\EmpleadosDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EmpleadosDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmpleadosDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmpleadosDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmpleadosDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmpleadosDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmpleadosDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmpleadosDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmpleadosDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmpleadosDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmpleadosDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmpleadosDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmpleadosDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmpleadosDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmpleadosDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmpleadosDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmpleadosDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmpleadosDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EmpleadosDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmpleadosDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmpleadosDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmpleadosDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmpleadosDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmpleadosDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmpleadosDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmpleadosDB] SET RECOVERY FULL 
GO
ALTER DATABASE [EmpleadosDB] SET  MULTI_USER 
GO
ALTER DATABASE [EmpleadosDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmpleadosDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmpleadosDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmpleadosDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmpleadosDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmpleadosDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EmpleadosDB', N'ON'
GO
ALTER DATABASE [EmpleadosDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [EmpleadosDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EmpleadosDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19/8/2024 18:02:58 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[EmpleadoID] [nvarchar](450) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bonificacion]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bonificacion](
	[BonificacionID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Bonificacion] PRIMARY KEY CLUSTERED 
(
	[BonificacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deduccion]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deduccion](
	[DeduccionID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Porcentaje] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Deduccion] PRIMARY KEY CLUSTERED 
(
	[DeduccionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[EmpleadoID] [nvarchar](450) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Telefono] [nvarchar](max) NOT NULL,
	[FechaContratacion] [datetime2](7) NOT NULL,
	[RoleId] [nvarchar](450) NULL,
	[PuestoID] [int] NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[EmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpleadosBonificaciones]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadosBonificaciones](
	[EmpleadoID] [nvarchar](450) NOT NULL,
	[BonificacionID] [int] NOT NULL,
 CONSTRAINT [PK_EmpleadosBonificaciones] PRIMARY KEY CLUSTERED 
(
	[EmpleadoID] ASC,
	[BonificacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpleadosDeducciones]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadosDeducciones](
	[EmpleadoID] [nvarchar](450) NOT NULL,
	[DeduccionID] [int] NOT NULL,
 CONSTRAINT [PK_EmpleadosDeducciones] PRIMARY KEY CLUSTERED 
(
	[EmpleadoID] ASC,
	[DeduccionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EvaluacionesRendimiento]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluacionesRendimiento](
	[EvaluacionID] [int] IDENTITY(1,1) NOT NULL,
	[EmpleadoID] [nvarchar](450) NOT NULL,
	[Objetivos] [nvarchar](max) NOT NULL,
	[Seguimiento] [nvarchar](max) NOT NULL,
	[Retroalimentacion] [nvarchar](max) NOT NULL,
	[FechaReunion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_EvaluacionesRendimiento] PRIMARY KEY CLUSTERED 
(
	[EvaluacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagos]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagos](
	[PagoID] [int] IDENTITY(1,1) NOT NULL,
	[EmpleadoID] [nvarchar](450) NOT NULL,
	[SalarioBase] [decimal](18, 2) NOT NULL,
	[TotalDeducciones] [decimal](18, 2) NOT NULL,
	[TotalBonificaciones] [decimal](18, 2) NOT NULL,
	[SalarioNeto] [decimal](18, 2) NOT NULL,
	[FechaPago] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Pagos] PRIMARY KEY CLUSTERED 
(
	[PagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puesto]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puesto](
	[PuestoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Salario] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Puesto] PRIMARY KEY CLUSTERED 
(
	[PuestoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TurnoEmpleados]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TurnoEmpleados](
	[TurnoEmpleadoID] [int] IDENTITY(1,1) NOT NULL,
	[EmpleadoID] [nvarchar](450) NOT NULL,
	[TurnoID] [int] NOT NULL,
 CONSTRAINT [PK_TurnoEmpleados] PRIMARY KEY CLUSTERED 
(
	[TurnoEmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 19/8/2024 18:02:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[TurnoID] [int] IDENTITY(1,1) NOT NULL,
	[TipoTurno] [nvarchar](max) NOT NULL,
	[CantHoras] [int] NOT NULL,
	[DiasSeleccionados] [nvarchar](max) NOT NULL,
	[HoraEntrada] [time](7) NOT NULL,
	[HoraSalida] [time](7) NOT NULL,
 CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[TurnoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240809033013_InitialIdentityMigration', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240812050312_AgregarTurnos', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240812053618_ActualizarModeloEmpleado', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240812054725_EliminarCamposPasswordEmpleado', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240812135929_ActualizarTurnoEstructura', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240812160329_AgregarTablasNomina', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240813223103_MigrationAfterManualChanges', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240814040120_SincronizarEstado', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240814051421_RenombreTablasIntermediasEmpleadoBonifDeduc', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240819184607_AddEvaluacionRendimiento', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240819222955_AddPagosTable', N'8.0.7')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'66281de0-8473-42f0-bc6d-4628e169b4ef', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6889c928-bf96-4f9d-8c4d-a8f4a2a2f2c0', N'Empleado', N'EMPLEADO', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'57255cff-0727-45cc-96a0-8d056cfd9da4', N'66281de0-8473-42f0-bc6d-4628e169b4ef')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bd23ccd9-5163-4acc-834e-7ac0bdb2cba6', N'66281de0-8473-42f0-bc6d-4628e169b4ef')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f7261ca7-af80-4e66-8303-00f66f62914e', N'66281de0-8473-42f0-bc6d-4628e169b4ef')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'15c66d36-624a-41f3-8b7f-9f86997d0c40', N'6889c928-bf96-4f9d-8c4d-a8f4a2a2f2c0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5a77271b-4d00-4b77-8fc1-394498d961e8', N'6889c928-bf96-4f9d-8c4d-a8f4a2a2f2c0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f2f4ebc2-622f-46f4-89fc-c7bc35118fe1', N'6889c928-bf96-4f9d-8c4d-a8f4a2a2f2c0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [EmpleadoID]) VALUES (N'15c66d36-624a-41f3-8b7f-9f86997d0c40', N'seis@emp.com', N'SEIS@EMP.COM', N'seis@emp.com', N'SEIS@EMP.COM', 1, N'AQAAAAIAAYagAAAAEEWoaSaAJFHNUGS+8VZkPocoaZDvXyHE70KiRkHaaWewkxVhz2/hgbrD6UoWpGObzg==', N'TIK72BH257GNWBPHI66W6ZMIZV5JHOCS', N'951ef0f5-566d-46d7-8fde-3a2c4a623cd9', NULL, 0, 0, NULL, 1, 0, N'6-6666-6666')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [EmpleadoID]) VALUES (N'57255cff-0727-45cc-96a0-8d056cfd9da4', N'admin@empmanagepro.com', N'ADMIN@EMPMANAGEPRO.COM', N'admin@empmanagepro.com', N'ADMIN@EMPMANAGEPRO.COM', 1, N'AQAAAAIAAYagAAAAEMT1uesOCJLK1wWuVOCBbfBcdF7UlhYFhswfjEAnRaSM9s3SBF4WJkujl7M+GYfbrA==', N'U24GYERV2PK3JBOYMZKRGYGWG6NOKY76', N'8157dd42-282a-492c-b9a1-17e575a40310', NULL, 0, 0, NULL, 0, 0, N'123456789')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [EmpleadoID]) VALUES (N'5a77271b-4d00-4b77-8fc1-394498d961e8', N'empleado@empmanagepro.com', N'EMPLEADO@EMPMANAGEPRO.COM', N'empleado@empmanagepro.com', N'EMPLEADO@EMPMANAGEPRO.COM', 1, N'AQAAAAIAAYagAAAAECrIzNzkSAzQYS0bXcuoNd+6OsPFznbT0Uk0s87sfFLan9XF2MUPN35zCC+Xz7iJiQ==', N'YSGKECLNJ6AT5LX3HE7Q2AX5XXFJFYPK', N'234f145c-d805-4424-a427-acb2a6ab6b10', NULL, 0, 0, NULL, 0, 0, N'987654321')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [EmpleadoID]) VALUES (N'bd23ccd9-5163-4acc-834e-7ac0bdb2cba6', N'jose@emp.com', N'JOSE@EMP.COM', N'jose@emp.com', N'JOSE@EMP.COM', 1, N'AQAAAAIAAYagAAAAELv6Nb+tLO58k71a6wbelsKfbl8ZKxZsUUo9+Yy5RajkXNuGRRNktaxx8Z98SsOoiw==', N'BMQSDYG5RV72RAQP7HIZPAKKESD7HSTT', N'8bfc7aa8-c02e-450e-b44e-58f1b9f838cd', NULL, 0, 0, NULL, 1, 0, N'1-1336-0794')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [EmpleadoID]) VALUES (N'f2f4ebc2-622f-46f4-89fc-c7bc35118fe1', N'elena@emp.com', N'ELENA@EMP.COM', N'elena@emp.com', N'ELENA@EMP.COM', 1, N'AQAAAAIAAYagAAAAEDYqQ1KYRjLDkn+m+50Xnvab2K+lZHZVf2DsozDTwJ0HLzOC4VNSOqfY8pOA0j7aqA==', N'LWQHPPB6IPIUL66QUUNMNJ2DBHDZB4WY', N'5ec8da5a-9fb0-4ee2-821b-62a20fa469e1', NULL, 0, 0, NULL, 1, 0, N'9-9999-9999')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [EmpleadoID]) VALUES (N'f7261ca7-af80-4e66-8303-00f66f62914e', N'puris@emp.com', N'PURIS@EMP.COM', N'puris@emp.com', N'PURIS@EMP.COM', 1, N'AQAAAAIAAYagAAAAEE15BKCKPTxvlRLbplVkGh//DvkkT0M9hrbYDols2BDhQqyZ8mGCFYow5EXKD735xw==', N'DXMK324LU3HANNVB4JDQQLQ6LQV74GL3', N'62382ac0-dd76-4aeb-aa6e-7f5a27121b1d', NULL, 0, 0, NULL, 1, 0, N'8-8888-8888')
GO
SET IDENTITY_INSERT [dbo].[Bonificacion] ON 

INSERT [dbo].[Bonificacion] ([BonificacionID], [Nombre], [Monto]) VALUES (1, N'Dedicación Exclusiva', CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[Bonificacion] ([BonificacionID], [Nombre], [Monto]) VALUES (3, N'Anualidad', CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[Bonificacion] ([BonificacionID], [Nombre], [Monto]) VALUES (4, N'Cumplimiento de Objetivos', CAST(50000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Bonificacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Deduccion] ON 

INSERT [dbo].[Deduccion] ([DeduccionID], [Nombre], [Porcentaje]) VALUES (2, N'Impuesto del Seguro Social', CAST(9.00 AS Decimal(18, 2)))
INSERT [dbo].[Deduccion] ([DeduccionID], [Nombre], [Porcentaje]) VALUES (3, N'Impuesto Sobre la Renta', CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[Deduccion] ([DeduccionID], [Nombre], [Porcentaje]) VALUES (5, N'Prestamo-10', CAST(10.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Deduccion] OFF
GO
INSERT [dbo].[Empleados] ([EmpleadoID], [Nombre], [Direccion], [Email], [Telefono], [FechaContratacion], [RoleId], [PuestoID]) VALUES (N'1-1336-0794', N'Jose Cristian Bermúdez Fallas', N'Puriscal, San José, Costa Rica', N'jose@emp.com', N'8400-0000', CAST(N'2024-08-14T00:00:00.0000000' AS DateTime2), N'66281de0-8473-42f0-bc6d-4628e169b4ef', 2)
INSERT [dbo].[Empleados] ([EmpleadoID], [Nombre], [Direccion], [Email], [Telefono], [FechaContratacion], [RoleId], [PuestoID]) VALUES (N'123456789', N'Usuario Administrador EmpManagePro', N'Costa Rica', N'admin@empmanagepro.com', N'12345678', CAST(N'2024-08-08T00:00:00.0000000' AS DateTime2), N'66281de0-8473-42f0-bc6d-4628e169b4ef', 4)
INSERT [dbo].[Empleados] ([EmpleadoID], [Nombre], [Direccion], [Email], [Telefono], [FechaContratacion], [RoleId], [PuestoID]) VALUES (N'6-6666-6666', N'Prueba Seis Prueba Seis', N'Seis Seis Seis', N'seis@emp.com', N'6666-6666', CAST(N'2024-08-19T00:00:00.0000000' AS DateTime2), N'6889c928-bf96-4f9d-8c4d-a8f4a2a2f2c0', 3)
INSERT [dbo].[Empleados] ([EmpleadoID], [Nombre], [Direccion], [Email], [Telefono], [FechaContratacion], [RoleId], [PuestoID]) VALUES (N'8-8888-8888', N'Puris San José Costa Rica', N'Puriscal, Costa Rica', N'puris@emp.com', N'8888-8888', CAST(N'2024-08-19T00:00:00.0000000' AS DateTime2), N'66281de0-8473-42f0-bc6d-4628e169b4ef', 5)
INSERT [dbo].[Empleados] ([EmpleadoID], [Nombre], [Direccion], [Email], [Telefono], [FechaContratacion], [RoleId], [PuestoID]) VALUES (N'987654321', N'Usuario Empleado EmpManagePro', N'Costa Rica', N'empleado@empmanagepro.com', N'8765-4321', CAST(N'2024-08-08T00:00:00.0000000' AS DateTime2), N'6889c928-bf96-4f9d-8c4d-a8f4a2a2f2c0', 4)
INSERT [dbo].[Empleados] ([EmpleadoID], [Nombre], [Direccion], [Email], [Telefono], [FechaContratacion], [RoleId], [PuestoID]) VALUES (N'9-9999-9999', N'Elena Guzmán', N'Mercedes Norte, Puriscal, Costa Rica', N'elena@emp.com', N'9999-9999', CAST(N'2024-08-19T00:00:00.0000000' AS DateTime2), N'6889c928-bf96-4f9d-8c4d-a8f4a2a2f2c0', 5)
GO
INSERT [dbo].[EmpleadosBonificaciones] ([EmpleadoID], [BonificacionID]) VALUES (N'987654321', 1)
INSERT [dbo].[EmpleadosBonificaciones] ([EmpleadoID], [BonificacionID]) VALUES (N'9-9999-9999', 1)
GO
INSERT [dbo].[EmpleadosDeducciones] ([EmpleadoID], [DeduccionID]) VALUES (N'1-1336-0794', 2)
INSERT [dbo].[EmpleadosDeducciones] ([EmpleadoID], [DeduccionID]) VALUES (N'6-6666-6666', 2)
INSERT [dbo].[EmpleadosDeducciones] ([EmpleadoID], [DeduccionID]) VALUES (N'8-8888-8888', 2)
INSERT [dbo].[EmpleadosDeducciones] ([EmpleadoID], [DeduccionID]) VALUES (N'987654321', 2)
INSERT [dbo].[EmpleadosDeducciones] ([EmpleadoID], [DeduccionID]) VALUES (N'9-9999-9999', 2)
INSERT [dbo].[EmpleadosDeducciones] ([EmpleadoID], [DeduccionID]) VALUES (N'1-1336-0794', 3)
INSERT [dbo].[EmpleadosDeducciones] ([EmpleadoID], [DeduccionID]) VALUES (N'6-6666-6666', 3)
INSERT [dbo].[EmpleadosDeducciones] ([EmpleadoID], [DeduccionID]) VALUES (N'8-8888-8888', 3)
INSERT [dbo].[EmpleadosDeducciones] ([EmpleadoID], [DeduccionID]) VALUES (N'9-9999-9999', 3)
INSERT [dbo].[EmpleadosDeducciones] ([EmpleadoID], [DeduccionID]) VALUES (N'8-8888-8888', 5)
INSERT [dbo].[EmpleadosDeducciones] ([EmpleadoID], [DeduccionID]) VALUES (N'9-9999-9999', 5)
GO
SET IDENTITY_INSERT [dbo].[EvaluacionesRendimiento] ON 

INSERT [dbo].[EvaluacionesRendimiento] ([EvaluacionID], [EmpleadoID], [Objetivos], [Seguimiento], [Retroalimentacion], [FechaReunion]) VALUES (1, N'9-9999-9999', N'Responder en menos de 5 horas hábiles cada correo (de trabajo) que le entre en la bandeja de entrada.', N'Se dará seguimiento el día de la reunión', N'Debe presentar un informe el día de la reunión', CAST(N'2024-08-23T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[EvaluacionesRendimiento] OFF
GO
SET IDENTITY_INSERT [dbo].[Pagos] ON 

INSERT [dbo].[Pagos] ([PagoID], [EmpleadoID], [SalarioBase], [TotalDeducciones], [TotalBonificaciones], [SalarioNeto], [FechaPago]) VALUES (1, N'1-1336-0794', CAST(1450000.00 AS Decimal(18, 2)), CAST(145000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1305000.00 AS Decimal(18, 2)), CAST(N'2024-08-19T16:38:10.3462629' AS DateTime2))
INSERT [dbo].[Pagos] ([PagoID], [EmpleadoID], [SalarioBase], [TotalDeducciones], [TotalBonificaciones], [SalarioNeto], [FechaPago]) VALUES (2, N'6-6666-6666', CAST(1250000.00 AS Decimal(18, 2)), CAST(125000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(1125000.00 AS Decimal(18, 2)), CAST(N'2024-08-19T16:40:33.6803906' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Pagos] OFF
GO
SET IDENTITY_INSERT [dbo].[Puesto] ON 

INSERT [dbo].[Puesto] ([PuestoID], [Nombre], [Salario]) VALUES (2, N'Senior', CAST(1450000.00 AS Decimal(18, 2)))
INSERT [dbo].[Puesto] ([PuestoID], [Nombre], [Salario]) VALUES (3, N'Junior', CAST(1250000.00 AS Decimal(18, 2)))
INSERT [dbo].[Puesto] ([PuestoID], [Nombre], [Salario]) VALUES (4, N'Comodin', CAST(1000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Puesto] ([PuestoID], [Nombre], [Salario]) VALUES (5, N'Especializado', CAST(1650000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Puesto] OFF
GO
SET IDENTITY_INSERT [dbo].[TurnoEmpleados] ON 

INSERT [dbo].[TurnoEmpleados] ([TurnoEmpleadoID], [EmpleadoID], [TurnoID]) VALUES (11, N'1-1336-0794', 6)
INSERT [dbo].[TurnoEmpleados] ([TurnoEmpleadoID], [EmpleadoID], [TurnoID]) VALUES (13, N'9-9999-9999', 8)
INSERT [dbo].[TurnoEmpleados] ([TurnoEmpleadoID], [EmpleadoID], [TurnoID]) VALUES (14, N'9-9999-9999', 6)
SET IDENTITY_INSERT [dbo].[TurnoEmpleados] OFF
GO
SET IDENTITY_INSERT [dbo].[Turnos] ON 

INSERT [dbo].[Turnos] ([TurnoID], [TipoTurno], [CantHoras], [DiasSeleccionados], [HoraEntrada], [HoraSalida]) VALUES (6, N'Diurno', 40, N'Lunes,Martes,Miércoles,Jueves,Viernes', CAST(N'07:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[Turnos] ([TurnoID], [TipoTurno], [CantHoras], [DiasSeleccionados], [HoraEntrada], [HoraSalida]) VALUES (8, N'Rotativo 1', 40, N'Lunes,Martes,Miércoles,Jueves,Viernes', CAST(N'07:00:00' AS Time), CAST(N'15:00:00' AS Time))
INSERT [dbo].[Turnos] ([TurnoID], [TipoTurno], [CantHoras], [DiasSeleccionados], [HoraEntrada], [HoraSalida]) VALUES (9, N'Nocturno', 40, N'Lunes,Martes,Miércoles,Jueves,Viernes', CAST(N'22:00:00' AS Time), CAST(N'06:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[Turnos] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 19/8/2024 18:02:58 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUsers_EmpleadoID]    Script Date: 19/8/2024 18:02:58 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AspNetUsers_EmpleadoID] ON [dbo].[AspNetUsers]
(
	[EmpleadoID] ASC
)
WHERE ([EmpleadoID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 19/8/2024 18:02:58 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Empleados_PuestoID]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [IX_Empleados_PuestoID] ON [dbo].[Empleados]
(
	[PuestoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Empleados_RoleId]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [IX_Empleados_RoleId] ON [dbo].[Empleados]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpleadosBonificaciones_BonificacionID]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [IX_EmpleadosBonificaciones_BonificacionID] ON [dbo].[EmpleadosBonificaciones]
(
	[BonificacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmpleadosDeducciones_DeduccionID]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [IX_EmpleadosDeducciones_DeduccionID] ON [dbo].[EmpleadosDeducciones]
(
	[DeduccionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_EvaluacionesRendimiento_EmpleadoID]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [IX_EvaluacionesRendimiento_EmpleadoID] ON [dbo].[EvaluacionesRendimiento]
(
	[EmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Pagos_EmpleadoID]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [IX_Pagos_EmpleadoID] ON [dbo].[Pagos]
(
	[EmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TurnoEmpleados_EmpleadoID]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [IX_TurnoEmpleados_EmpleadoID] ON [dbo].[TurnoEmpleados]
(
	[EmpleadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TurnoEmpleados_TurnoID]    Script Date: 19/8/2024 18:02:58 ******/
CREATE NONCLUSTERED INDEX [IX_TurnoEmpleados_TurnoID] ON [dbo].[TurnoEmpleados]
(
	[TurnoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Turnos] ADD  DEFAULT ((0)) FOR [CantHoras]
GO
ALTER TABLE [dbo].[Turnos] ADD  DEFAULT (N'') FOR [DiasSeleccionados]
GO
ALTER TABLE [dbo].[Turnos] ADD  DEFAULT ('00:00:00') FOR [HoraEntrada]
GO
ALTER TABLE [dbo].[Turnos] ADD  DEFAULT ('00:00:00') FOR [HoraSalida]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Empleados] FOREIGN KEY([EmpleadoID])
REFERENCES [dbo].[Empleados] ([EmpleadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Empleados]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Empleados_EmpleadoID] FOREIGN KEY([EmpleadoID])
REFERENCES [dbo].[Empleados] ([EmpleadoID])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Empleados_EmpleadoID]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_AspNetRoles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_AspNetRoles]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Puesto_PuestoID] FOREIGN KEY([PuestoID])
REFERENCES [dbo].[Puesto] ([PuestoID])
GO
ALTER TABLE [dbo].[Empleados] CHECK CONSTRAINT [FK_Empleados_Puesto_PuestoID]
GO
ALTER TABLE [dbo].[EmpleadosBonificaciones]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosBonificaciones_Bonificacion_BonificacionID] FOREIGN KEY([BonificacionID])
REFERENCES [dbo].[Bonificacion] ([BonificacionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpleadosBonificaciones] CHECK CONSTRAINT [FK_EmpleadosBonificaciones_Bonificacion_BonificacionID]
GO
ALTER TABLE [dbo].[EmpleadosBonificaciones]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosBonificaciones_Empleados_EmpleadoID] FOREIGN KEY([EmpleadoID])
REFERENCES [dbo].[Empleados] ([EmpleadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpleadosBonificaciones] CHECK CONSTRAINT [FK_EmpleadosBonificaciones_Empleados_EmpleadoID]
GO
ALTER TABLE [dbo].[EmpleadosDeducciones]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosDeducciones_Deduccion_DeduccionID] FOREIGN KEY([DeduccionID])
REFERENCES [dbo].[Deduccion] ([DeduccionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpleadosDeducciones] CHECK CONSTRAINT [FK_EmpleadosDeducciones_Deduccion_DeduccionID]
GO
ALTER TABLE [dbo].[EmpleadosDeducciones]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadosDeducciones_Empleados_EmpleadoID] FOREIGN KEY([EmpleadoID])
REFERENCES [dbo].[Empleados] ([EmpleadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmpleadosDeducciones] CHECK CONSTRAINT [FK_EmpleadosDeducciones_Empleados_EmpleadoID]
GO
ALTER TABLE [dbo].[EvaluacionesRendimiento]  WITH CHECK ADD  CONSTRAINT [FK_EvaluacionesRendimiento_Empleados_EmpleadoID] FOREIGN KEY([EmpleadoID])
REFERENCES [dbo].[Empleados] ([EmpleadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EvaluacionesRendimiento] CHECK CONSTRAINT [FK_EvaluacionesRendimiento_Empleados_EmpleadoID]
GO
ALTER TABLE [dbo].[Pagos]  WITH CHECK ADD  CONSTRAINT [FK_Pagos_Empleados_EmpleadoID] FOREIGN KEY([EmpleadoID])
REFERENCES [dbo].[Empleados] ([EmpleadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pagos] CHECK CONSTRAINT [FK_Pagos_Empleados_EmpleadoID]
GO
ALTER TABLE [dbo].[TurnoEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_TurnoEmpleados_Empleados_EmpleadoID] FOREIGN KEY([EmpleadoID])
REFERENCES [dbo].[Empleados] ([EmpleadoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TurnoEmpleados] CHECK CONSTRAINT [FK_TurnoEmpleados_Empleados_EmpleadoID]
GO
ALTER TABLE [dbo].[TurnoEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_TurnoEmpleados_Turnos_TurnoID] FOREIGN KEY([TurnoID])
REFERENCES [dbo].[Turnos] ([TurnoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TurnoEmpleados] CHECK CONSTRAINT [FK_TurnoEmpleados_Turnos_TurnoID]
GO
USE [master]
GO
ALTER DATABASE [EmpleadosDB] SET  READ_WRITE 
GO
