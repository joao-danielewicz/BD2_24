IF NOT EXISTS ( SELECT * FROM sysobjects WHERE name = 'campeonato')
BEGIN 
	create database campeonato;
END

GO
	use campeonato;

GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'tipo_modalidade')
BEGIN
create table [dbo].[tipo_modalidade](
	[id_modalidade] INT IDENTITY (1,1) NOT NULL,
    [nome_modalidade] TEXT NOT NULL,
    CONSTRAINT [PK_dbo.tipo_modalidade] PRIMARY KEY CLUSTERED([id_modalidade] ASC)
);
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'tipo_torneio')
BEGIN
create table [dbo].[tipo_torneio](
	[id_tipo_torneio] INT IDENTITY (1,1) NOT NULL,
    [nome_tipo] TEXT NOT NULL,
    CONSTRAINT [PK_dbo.tipo_torneio] PRIMARY KEY CLUSTERED([id_tipo_torneio] ASC)
);
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'torneio')
BEGIN
create table [dbo].[torneio](
	[id_torneio] INT IDENTITY (1,1) NOT NULL,
	[nome_torneio] TEXT NOT NULL,
	[data_inicio] DATETIME NOT NULL,
	[data_fim] DATETIME NOT NULL,
	[id_modalidade] INT NOT NULL,
    [id_tipo_torneio] INT NOT NULL,
    CONSTRAINT [fk_id_modalidade] FOREIGN KEY([id_modalidade]) REFERENCES [dbo].[tipo_modalidade] ([id_modalidade]) ON DELETE CASCADE,
    CONSTRAINT [fk_id_tipo_torneio] FOREIGN KEY([id_tipo_torneio]) REFERENCES [dbo].[tipo_torneio] ([id_tipo_torneio]) ON DELETE CASCADE,
    CONSTRAINT [PK_dbo.torneio] PRIMARY KEY CLUSTERED([id_torneio] ASC)
);
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'fase')
BEGIN
create table [dbo].[fase](
	[id_fase] INT IDENTITY (1,1) NOT NULL,
    [descricao] TEXT NOT NULL,
    CONSTRAINT [PK_dbo.fase] PRIMARY KEY CLUSTERED([id_fase] ASC)
);
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'grupo')
BEGIN
create table [dbo].[grupo](
	[id_grupo] INT IDENTITY (1,1) NOT NULL,
	[nome_grupo] TEXT NOT NULL,
    [id_fase] INT NOT NULL,
	[id_torneio] INT NOT NULL,
    CONSTRAINT [fk_id_fase] FOREIGN KEY([id_fase]) REFERENCES [dbo].[fase] ([id_fase]) ON DELETE CASCADE,
	CONSTRAINT [fk_id_torneio_grupo] FOREIGN KEY([id_torneio]) REFERENCES [dbo].[torneio] ([id_torneio]) ON DELETE CASCADE,
    CONSTRAINT [PK_dbo.grupo] PRIMARY KEY CLUSTERED([id_grupo] ASC)
);
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'equipe')
BEGIN
create table [dbo].[equipe](
	[id_equipe] INT IDENTITY (1,1) NOT NULL,
    [nome_equipe] TEXT NOT NULL,
    [id_grupo] INT NULL,
    [id_torneio] INT NOT NULL,
    CONSTRAINT [fk_id_grupo] FOREIGN KEY([id_grupo]) references [dbo].[grupo] ([id_grupo]),
    CONSTRAINT [fk_id_torneio_equipe] FOREIGN KEY([id_torneio]) REFERENCES [dbo].[torneio] ([id_torneio]) ON DELETE CASCADE,
    CONSTRAINT [PK_dbo.equipe] PRIMARY KEY CLUSTERED([id_equipe] ASC)
);
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'atleta')
BEGIN
create table [dbo].[atleta](
	[id_atleta] INT IDENTITY (1,1) NOT NULL,
    [nome] TEXT NOT NULL,
    [genero] TEXT NOT NULL,
    [data_nascimento] TEXT NOT NULL,
    [peso] INT NOT NULL,
    [id_equipe] INT NOT NULL,
    CONSTRAINT [fk_id_equipe_atleta] FOREIGN KEY([id_equipe]) REFERENCES [dbo].[equipe] ([id_equipe]) ON DELETE CASCADE,
    CONSTRAINT [PK_dbo.atleta] PRIMARY KEY CLUSTERED([id_atleta] ASC)
);
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'partida')
BEGIN
create table [dbo].[partida](
	[id_partida] INT IDENTITY (1,1) NOT NULL,
    [data_partida] DATETIME NOT NULL,
    [placar_equipe_1] INT NOT NULL,
    [placar_equipe_2] INT NOT NULL,
    [id_equipe_1] INT NOT NULL,
    [id_equipe_2] INT NOT NULL,
    CONSTRAINT [fk_id_equipe1_partida] FOREIGN KEY([id_equipe_1]) REFERENCES [dbo].[equipe] ([id_equipe]),
    CONSTRAINT [fk_id_equipe2_partida] FOREIGN KEY([id_equipe_2]) REFERENCES [dbo].[equipe] ([id_equipe]),
    CONSTRAINT [PK_dbo.partida] PRIMARY KEY CLUSTERED([id_partida] ASC)
);
END
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'resultado')
BEGIN
create table [dbo].[resultado](
	[id_resultado] INT IDENTITY (1,1) NOT NULL,
    [quantidade_pontos] INT NOT NULL,
    [id_equipe] INT NOT NULL,
    CONSTRAINT [fk_id_equipe_resultado] FOREIGN KEY([id_equipe]) REFERENCES [dbo].[equipe] ([id_equipe]) ON DELETE CASCADE,
    CONSTRAINT [PK_dbo.resultado] PRIMARY KEY CLUSTERED([id_resultado] ASC)
);
END
GO