using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Horgaszadatok.Models;

public partial class Halak
{
    public int halak_id { get; set; }

    public string hal_nev { get; set; } = null!;

    public string hal_faj { get; set; } = null!;

    public decimal? meret_cm { get; set; }

    public int to_id { get; set; }

    public byte[]? kep { get; set; }

    [JsonIgnore]
    public virtual ICollection<Fogasok> Fogasoks { get; set; } = new List<Fogasok>();

    public virtual Tavak? To { get; set; } = null!;
}
