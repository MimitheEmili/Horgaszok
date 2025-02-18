using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Horgaszadatok.Models;

public partial class Tavak
{
    public int TavakId { get; set; }

    public string ToNev { get; set; } = null!;

    public string Helyszin { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Halak> Halaks { get; set; } = new List<Halak>();
}
