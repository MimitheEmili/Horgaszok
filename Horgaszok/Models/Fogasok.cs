using System;
using System.Collections.Generic;

namespace Horgaszadatok.Models;

public partial class Fogasok
{
    public int fogasok_id { get; set; }

    public int hal_id { get; set; }

    public int horgaszok_id { get; set; }

    public DateTime datum { get; set; }

    public virtual Halak? Hal { get; set; } = null!;

    public virtual Horgaszok? Horgaszok { get; set; } = null!;
}
