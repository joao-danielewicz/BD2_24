using System;
using System.Collections.Generic;

namespace Campeonato.Models;

public partial class Torneio
{
    public int IdTorneio { get; set; }

    public string NomeTorneio { get; set; } = null!;

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public int IdModalidade { get; set; }

    public int IdTipoTorneio { get; set; }

    public virtual ICollection<Equipe> Equipes { get; set; } = new List<Equipe>();

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();

    public virtual TipoModalidade IdModalidadeNavigation { get; set; } = null!;

    public virtual TipoTorneio IdTipoTorneioNavigation { get; set; } = null!;
}
