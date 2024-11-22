using System;
using System.Collections.Generic;

namespace ProjetoLojaEletronicos.Models;

public partial class Atletum
{
    public int IdAtleta { get; set; }

    public string Nome { get; set; } = null!;

    public int IdEquipe { get; set; }

    public virtual Equipe IdEquipeNavigation { get; set; } = null!;
}
