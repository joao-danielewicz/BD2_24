USE [master]
GO
/****** Object:  Database [campeonato]    Script Date: 08/11/2024 16:45:31 ******/
CREATE DATABASE [campeonato]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'campeonato', FILENAME = N'C:\Users\João Danielewicz\campeonato.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'campeonato_log', FILENAME = N'C:\Users\João Danielewicz\campeonato_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [campeonato] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [campeonato].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [campeonato] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [campeonato] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [campeonato] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [campeonato] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [campeonato] SET ARITHABORT OFF 
GO
ALTER DATABASE [campeonato] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [campeonato] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [campeonato] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [campeonato] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [campeonato] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [campeonato] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [campeonato] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [campeonato] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [campeonato] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [campeonato] SET  ENABLE_BROKER 
GO
ALTER DATABASE [campeonato] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [campeonato] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [campeonato] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [campeonato] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [campeonato] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [campeonato] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [campeonato] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [campeonato] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [campeonato] SET  MULTI_USER 
GO
ALTER DATABASE [campeonato] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [campeonato] SET DB_CHAINING OFF 
GO
ALTER DATABASE [campeonato] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [campeonato] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [campeonato] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [campeonato] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [campeonato] SET QUERY_STORE = OFF
GO
USE [campeonato]
GO
/****** Object:  Table [dbo].[atleta]    Script Date: 08/11/2024 16:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[atleta](
	[id_atleta] [int] IDENTITY(1,1) NOT NULL,
	[nome] [text] NOT NULL,
	[id_equipe] [int] NOT NULL,
 CONSTRAINT [PK_dbo.atleta] PRIMARY KEY CLUSTERED 
(
	[id_atleta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipe]    Script Date: 08/11/2024 16:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipe](
	[id_equipe] [int] IDENTITY(1,1) NOT NULL,
	[nome_equipe] [text] NOT NULL,
	[id_grupo] [int] NULL,
	[id_torneio] [int] NOT NULL,
 CONSTRAINT [PK_dbo.equipe] PRIMARY KEY CLUSTERED 
(
	[id_equipe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fase]    Script Date: 08/11/2024 16:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fase](
	[id_fase] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [text] NOT NULL,
 CONSTRAINT [PK_dbo.fase] PRIMARY KEY CLUSTERED 
(
	[id_fase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[grupo]    Script Date: 08/11/2024 16:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grupo](
	[id_grupo] [int] IDENTITY(1,1) NOT NULL,
	[nome_grupo] [text] NOT NULL,
	[id_torneio] [int] NOT NULL,
 CONSTRAINT [PK_dbo.grupo] PRIMARY KEY CLUSTERED 
(
	[id_grupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[partida]    Script Date: 08/11/2024 16:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[partida](
	[id_partida] [int] IDENTITY(1,1) NOT NULL,
	[data_partida] [datetime] NOT NULL,
	[placar_equipe_1] [int] NOT NULL,
	[placar_equipe_2] [int] NOT NULL,
	[id_equipe_1] [int] NOT NULL,
	[id_equipe_2] [int] NOT NULL,
	[id_fase] [int] NULL,
 CONSTRAINT [PK_dbo.partida] PRIMARY KEY CLUSTERED 
(
	[id_partida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[resultado]    Script Date: 08/11/2024 16:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[resultado](
	[id_resultado] [int] IDENTITY(1,1) NOT NULL,
	[quantidade_pontos] [int] NOT NULL,
	[id_equipe] [int] NOT NULL,
 CONSTRAINT [PK_dbo.resultado] PRIMARY KEY CLUSTERED 
(
	[id_resultado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_modalidade]    Script Date: 08/11/2024 16:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_modalidade](
	[id_modalidade] [int] IDENTITY(1,1) NOT NULL,
	[nome_modalidade] [text] NOT NULL,
 CONSTRAINT [PK_dbo.tipo_modalidade] PRIMARY KEY CLUSTERED 
(
	[id_modalidade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_torneio]    Script Date: 08/11/2024 16:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_torneio](
	[id_tipo_torneio] [int] IDENTITY(1,1) NOT NULL,
	[nome_tipo] [text] NOT NULL,
 CONSTRAINT [PK_dbo.tipo_torneio] PRIMARY KEY CLUSTERED 
(
	[id_tipo_torneio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[torneio]    Script Date: 08/11/2024 16:45:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[torneio](
	[id_torneio] [int] IDENTITY(1,1) NOT NULL,
	[nome_torneio] [text] NOT NULL,
	[data_inicio] [datetime] NOT NULL,
	[data_fim] [datetime] NOT NULL,
	[id_modalidade] [int] NOT NULL,
	[id_tipo_torneio] [int] NOT NULL,
 CONSTRAINT [PK_dbo.torneio] PRIMARY KEY CLUSTERED 
(
	[id_torneio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[atleta]  WITH CHECK ADD  CONSTRAINT [fk_id_equipe_atleta] FOREIGN KEY([id_equipe])
REFERENCES [dbo].[equipe] ([id_equipe])
GO
ALTER TABLE [dbo].[atleta] CHECK CONSTRAINT [fk_id_equipe_atleta]
GO
ALTER TABLE [dbo].[equipe]  WITH CHECK ADD  CONSTRAINT [fk_id_grupo] FOREIGN KEY([id_grupo])
REFERENCES [dbo].[grupo] ([id_grupo])
GO
ALTER TABLE [dbo].[equipe] CHECK CONSTRAINT [fk_id_grupo]
GO
ALTER TABLE [dbo].[equipe]  WITH CHECK ADD  CONSTRAINT [fk_id_torneio_equipe] FOREIGN KEY([id_torneio])
REFERENCES [dbo].[torneio] ([id_torneio])
GO
ALTER TABLE [dbo].[equipe] CHECK CONSTRAINT [fk_id_torneio_equipe]
GO
ALTER TABLE [dbo].[grupo]  WITH CHECK ADD  CONSTRAINT [fk_id_torneio_grupo] FOREIGN KEY([id_torneio])
REFERENCES [dbo].[torneio] ([id_torneio])
GO
ALTER TABLE [dbo].[grupo] CHECK CONSTRAINT [fk_id_torneio_grupo]
GO
ALTER TABLE [dbo].[partida]  WITH CHECK ADD  CONSTRAINT [fk_id_equipe1_partida] FOREIGN KEY([id_equipe_1])
REFERENCES [dbo].[equipe] ([id_equipe])
GO
ALTER TABLE [dbo].[partida] CHECK CONSTRAINT [fk_id_equipe1_partida]
GO
ALTER TABLE [dbo].[partida]  WITH CHECK ADD  CONSTRAINT [fk_id_equipe2_partida] FOREIGN KEY([id_equipe_2])
REFERENCES [dbo].[equipe] ([id_equipe])
GO
ALTER TABLE [dbo].[partida] CHECK CONSTRAINT [fk_id_equipe2_partida]
GO
ALTER TABLE [dbo].[partida]  WITH CHECK ADD  CONSTRAINT [fk_id_fase] FOREIGN KEY([id_fase])
REFERENCES [dbo].[fase] ([id_fase])
GO
ALTER TABLE [dbo].[partida] CHECK CONSTRAINT [fk_id_fase]
GO
ALTER TABLE [dbo].[resultado]  WITH CHECK ADD  CONSTRAINT [fk_id_equipe_resultado] FOREIGN KEY([id_equipe])
REFERENCES [dbo].[equipe] ([id_equipe])
GO
ALTER TABLE [dbo].[resultado] CHECK CONSTRAINT [fk_id_equipe_resultado]
GO
ALTER TABLE [dbo].[torneio]  WITH CHECK ADD  CONSTRAINT [fk_id_modalidade] FOREIGN KEY([id_modalidade])
REFERENCES [dbo].[tipo_modalidade] ([id_modalidade])
GO
ALTER TABLE [dbo].[torneio] CHECK CONSTRAINT [fk_id_modalidade]
GO
ALTER TABLE [dbo].[torneio]  WITH CHECK ADD  CONSTRAINT [fk_id_tipo_torneio] FOREIGN KEY([id_tipo_torneio])
REFERENCES [dbo].[tipo_torneio] ([id_tipo_torneio])
GO
ALTER TABLE [dbo].[torneio] CHECK CONSTRAINT [fk_id_tipo_torneio]
GO
USE [master]
GO
ALTER DATABASE [campeonato] SET  READ_WRITE 
GO
