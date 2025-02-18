using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Horgaszok.Models;

public partial class Horgaszok
{
    public int HorgaszokId { get; set; }

    public string HorgaszokNev { get; set; } = null!;

    public int? Eletkor { get; set; }

    [JsonIgnore]
    public virtual ICollection<Fogasok> Fogasoks { get; set; } = new List<Fogasok>();
}
