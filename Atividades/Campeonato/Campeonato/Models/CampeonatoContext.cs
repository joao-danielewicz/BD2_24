using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Campeonato.Models;

public partial class CampeonatoContext : DbContext
{
    public CampeonatoContext()
    {
    }

    public CampeonatoContext(DbContextOptions<CampeonatoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atleta> Atleta { get; set; }

    public virtual DbSet<Equipe> Equipes { get; set; }

    public virtual DbSet<Fase> Fases { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Partida> Partida { get; set; }

    public virtual DbSet<Resultado> Resultados { get; set; }

    public virtual DbSet<TipoModalidade> TipoModalidades { get; set; }

    public virtual DbSet<TipoTorneio> TipoTorneios { get; set; }

    public virtual DbSet<Torneio> Torneios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=campeonato;User ID=;Password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Atleta>(entity =>
        {
            entity.HasKey(e => e.IdAtleta).HasName("PK_dbo.atleta");

            entity.ToTable("atleta");

            entity.Property(e => e.IdAtleta).HasColumnName("id_atleta");
            entity.Property(e => e.IdEquipe).HasColumnName("id_equipe");
            entity.Property(e => e.Nome)
                .HasColumnType("text")
                .HasColumnName("nome");

            entity.HasOne(d => d.IdEquipeNavigation).WithMany(p => p.Atleta)
                .HasForeignKey(d => d.IdEquipe)
                .HasConstraintName("fk_id_equipe_atleta");
        });

        modelBuilder.Entity<Equipe>(entity =>
        {
            entity.HasKey(e => e.IdEquipe).HasName("PK_dbo.equipe");

            entity.ToTable("equipe");

            entity.Property(e => e.IdEquipe).HasColumnName("id_equipe");
            entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");
            entity.Property(e => e.IdTorneio).HasColumnName("id_torneio");
            entity.Property(e => e.NomeEquipe)
                .HasColumnType("text")
                .HasColumnName("nome_equipe");

            entity.HasOne(d => d.IdTorneioNavigation).WithMany(p => p.Equipes)
                .HasForeignKey(d => d.IdTorneio)
                .HasConstraintName("fk_id_torneio_equipe");
        });

        modelBuilder.Entity<Fase>(entity =>
        {
            entity.HasKey(e => e.IdFase).HasName("PK_dbo.fase");

            entity.ToTable("fase");

            entity.Property(e => e.IdFase).HasColumnName("id_fase");
            entity.Property(e => e.Descricao)
                .HasColumnType("text")
                .HasColumnName("descricao");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK_dbo.grupo");

            entity.ToTable("grupo");

            entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");
            entity.Property(e => e.IdTorneio).HasColumnName("id_torneio");
            entity.Property(e => e.NomeGrupo)
                .HasColumnType("text")
                .HasColumnName("nome_grupo");

            entity.HasOne(d => d.IdTorneioNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdTorneio)
                .HasConstraintName("fk_id_torneio_grupo");
        });

        modelBuilder.Entity<Partida>(entity =>
        {
            entity.HasKey(e => e.IdPartida).HasName("PK_dbo.partida");

            entity.ToTable("partida");

            entity.Property(e => e.IdPartida).HasColumnName("id_partida");
            entity.Property(e => e.DataPartida)
                .HasColumnType("datetime")
                .HasColumnName("data_partida");
            entity.Property(e => e.IdEquipe1).HasColumnName("id_equipe_1");
            entity.Property(e => e.IdEquipe2).HasColumnName("id_equipe_2");
            entity.Property(e => e.IdFase).HasColumnName("id_fase");
            entity.Property(e => e.PlacarEquipe1).HasColumnName("placar_equipe_1");
            entity.Property(e => e.PlacarEquipe2).HasColumnName("placar_equipe_2");

            entity.HasOne(d => d.IdEquipe1Navigation).WithMany(p => p.PartidumIdEquipe1Navigations)
                .HasForeignKey(d => d.IdEquipe1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_equipe1_partida");

            entity.HasOne(d => d.IdEquipe2Navigation).WithMany(p => p.PartidumIdEquipe2Navigations)
                .HasForeignKey(d => d.IdEquipe2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_id_equipe2_partida");

            entity.HasOne(d => d.IdFaseNavigation).WithMany(p => p.Partida)
                .HasForeignKey(d => d.IdFase)
                .HasConstraintName("fk_id_fase");
        });

        modelBuilder.Entity<Resultado>(entity =>
        {
            entity.HasKey(e => e.IdResultado).HasName("PK_dbo.resultado");

            entity.ToTable("resultado");

            entity.Property(e => e.IdResultado).HasColumnName("id_resultado");
            entity.Property(e => e.IdEquipe).HasColumnName("id_equipe");
            entity.Property(e => e.QuantidadePontos).HasColumnName("quantidade_pontos");

            entity.HasOne(d => d.IdEquipeNavigation).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.IdEquipe)
                .HasConstraintName("fk_id_equipe_resultado");
        });

        modelBuilder.Entity<TipoModalidade>(entity =>
        {
            entity.HasKey(e => e.IdModalidade).HasName("PK_dbo.tipo_modalidade");

            entity.ToTable("tipo_modalidade");

            entity.Property(e => e.IdModalidade).HasColumnName("id_modalidade");
            entity.Property(e => e.NomeModalidade)
                .HasColumnType("text")
                .HasColumnName("nome_modalidade");
        });

        modelBuilder.Entity<TipoTorneio>(entity =>
        {
            entity.HasKey(e => e.IdTipoTorneio).HasName("PK_dbo.tipo_torneio");

            entity.ToTable("tipo_torneio");

            entity.Property(e => e.IdTipoTorneio).HasColumnName("id_tipo_torneio");
            entity.Property(e => e.NomeTipo)
                .HasColumnType("text")
                .HasColumnName("nome_tipo");
        });

        modelBuilder.Entity<Torneio>(entity =>
        {
            entity.HasKey(e => e.IdTorneio).HasName("PK_dbo.torneio");

            entity.ToTable("torneio");

            entity.Property(e => e.IdTorneio).HasColumnName("id_torneio");
            entity.Property(e => e.DataFim)
                .HasColumnType("datetime")
                .HasColumnName("data_fim");
            entity.Property(e => e.DataInicio)
                .HasColumnType("datetime")
                .HasColumnName("data_inicio");
            entity.Property(e => e.IdModalidade).HasColumnName("id_modalidade");
            entity.Property(e => e.IdTipoTorneio).HasColumnName("id_tipo_torneio");
            entity.Property(e => e.NomeTorneio)
                .HasColumnType("text")
                .HasColumnName("nome_torneio");

            entity.HasOne(d => d.IdModalidadeNavigation).WithMany(p => p.Torneios)
                .HasForeignKey(d => d.IdModalidade)
                .HasConstraintName("fk_id_modalidade");

            entity.HasOne(d => d.IdTipoTorneioNavigation).WithMany(p => p.Torneios)
                .HasForeignKey(d => d.IdTipoTorneio)
                .HasConstraintName("fk_id_tipo_torneio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
