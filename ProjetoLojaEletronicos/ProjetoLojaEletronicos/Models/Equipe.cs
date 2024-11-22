using System;
using System.Collections.Generic;

namespace ProjetoLojaEletronicos.Models;

public partial class Equipe
{
    public int IdEquipe { get; set; }

    public string NomeEquipe { get; set; } = null!;

    public int? IdGrupo { get; set; }

    public int IdTorneio { get; set; }

    public virtual ICollection<Atletum> Atleta { get; set; } = new List<Atletum>();

    public virtual Torneio IdTorneioNavigation { get; set; } = null!;

    public virtual ICollection<Partidum> PartidumIdEquipe1Navigations { get; set; } = new List<Partidum>();

    public virtual ICollection<Partidum> PartidumIdEquipe2Navigations { get; set; } = new List<Partidum>();

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
