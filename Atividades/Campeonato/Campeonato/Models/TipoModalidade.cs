using System;
using System.Collections.Generic;

namespace Campeonato.Models;

public partial class TipoModalidade
{
    public int IdModalidade { get; set; }

    public string NomeModalidade { get; set; } = null!;

    public virtual ICollection<Torneio> Torneios { get; set; } = new List<Torneio>();
}
