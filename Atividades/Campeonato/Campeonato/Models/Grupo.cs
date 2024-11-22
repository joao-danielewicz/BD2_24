using System;
using System.Collections.Generic;

namespace Campeonato.Models;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    public string NomeGrupo { get; set; } = null!;

    public int IdTorneio { get; set; }

    public virtual Torneio IdTorneioNavigation { get; set; } = null!;
}
