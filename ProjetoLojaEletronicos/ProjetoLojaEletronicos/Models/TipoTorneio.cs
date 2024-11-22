using System;
using System.Collections.Generic;

namespace ProjetoLojaEletronicos.Models;

public partial class TipoTorneio
{
    public int IdTipoTorneio { get; set; }

    public string NomeTipo { get; set; } = null!;

    public virtual ICollection<Torneio> Torneios { get; set; } = new List<Torneio>();
}
