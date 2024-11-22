using System;
using System.Collections.Generic;

namespace ProjetoLojaEletronicos.Models;

public partial class Partidum
{
    public int IdPartida { get; set; }

    public DateTime DataPartida { get; set; }

    public int PlacarEquipe1 { get; set; }

    public int PlacarEquipe2 { get; set; }

    public int IdEquipe1 { get; set; }

    public int IdEquipe2 { get; set; }

    public int? IdFase { get; set; }

    public virtual Equipe IdEquipe1Navigation { get; set; } = null!;

    public virtual Equipe IdEquipe2Navigation { get; set; } = null!;

    public virtual Fase? IdFaseNavigation { get; set; }
}
