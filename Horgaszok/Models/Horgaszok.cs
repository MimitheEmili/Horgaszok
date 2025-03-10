using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Horgaszadatok.Models;

public partial class Horgaszok
{
    public int horgaszok_id { get; set; }

    public string horgaszok_nev { get; set; } = null!;

    public int? eletkor { get; set; }

    [JsonIgnore]
    public virtual ICollection<Fogasok> Fogasoks { get; set; } = new List<Fogasok>();
}
