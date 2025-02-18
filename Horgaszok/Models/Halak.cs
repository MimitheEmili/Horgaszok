using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Horgaszok.Models;

public partial class Halak
{
    public int HalakId { get; set; }

    public string HalNev { get; set; } = null!;

    public string HalFaj { get; set; } = null!;

    public decimal? MeretCm { get; set; }

    public int? ToId { get; set; }

    public byte[]? Kep { get; set; }

    [JsonIgnore]
    public virtual ICollection<Fogasok> Fogasoks { get; set; } = new List<Fogasok>();

    public virtual Tavak? To { get; set; }
}
