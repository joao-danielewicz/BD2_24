﻿using System;
using System.Collections.Generic;

namespace Campeonato.Models;

public partial class Fase
{
    public int IdFase { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Partida> Partida { get; set; } = new List<Partida>();
}
