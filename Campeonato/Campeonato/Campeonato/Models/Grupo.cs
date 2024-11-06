using System;
using System.Collections.Generic;

namespace Campeonato.Models;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    public string NomeGrupo { get; set; } = null!;

    public int IdFase { get; set; }

    public int IdTorneio { get; set; }

    public virtual ICollection<Equipe> Equipes { get; set; } = new List<Equipe>();

    public virtual Fase IdFaseNavigation { get; set; } = null!;

    public virtual Torneio IdTorneioNavigation { get; set; } = null!;
}
