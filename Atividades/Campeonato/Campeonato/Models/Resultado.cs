using System;
using System.Collections.Generic;

namespace Campeonato.Models;

public partial class Resultado
{
    public int IdResultado { get; set; }

    public int QuantidadePontos { get; set; }

    public int IdEquipe { get; set; }

    public virtual Equipe IdEquipeNavigation { get; set; } = null!;
}
