using System;
using System.Collections.Generic;

namespace Campeonato.Models;

public partial class Atleta
{
    public int IdAtleta { get; set; }

    public string Nome { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public string DataNascimento { get; set; } = null!;

    public int Peso { get; set; }

    public int IdEquipe { get; set; }

    public virtual Equipe IdEquipeNavigation { get; set; } = null!;
}
