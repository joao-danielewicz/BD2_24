using System;
using System.Collections.Generic;

namespace Campeonato.Models;

public partial class Equipe
{
    public int IdEquipe { get; set; }

    public string NomeEquipe { get; set; } = null!;

    public int? IdGrupo { get; set; }

    public int IdTorneio { get; set; }

    public virtual ICollection<Atleta> Atleta { get; set; } = new List<Atleta>();

    public virtual Torneio IdTorneioNavigation { get; set; } = null!;

    public virtual ICollection<Partida> PartidumIdEquipe1Navigations { get; set; } = new List<Partida>();

    public virtual ICollection<Partida> PartidumIdEquipe2Navigations { get; set; } = new List<Partida>();

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
