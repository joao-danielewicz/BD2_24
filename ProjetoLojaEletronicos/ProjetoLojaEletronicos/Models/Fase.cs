using System;
using System.Collections.Generic;

namespace ProjetoLojaEletronicos.Models;

public partial class Fase
{
    public int IdFase { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Partidum> Partida { get; set; } = new List<Partidum>();
}
