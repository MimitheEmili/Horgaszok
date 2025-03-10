using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Horgaszadatok.Models;

public partial class Tavak
{
    public int tavak_id { get; set; }

    public string to_nev { get; set; } = null!;

    public string helyszin { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Halak> Halaks { get; set; } = new List<Halak>();
}
