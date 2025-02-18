using System;
using System.Collections.Generic;

namespace Horgaszok.Models;

public partial class Fogasok
{
    public int FogasokId { get; set; }

    public int? HalId { get; set; }

    public int? HorgaszokId { get; set; }

    public DateTime Datum { get; set; }

    public virtual Halak? Hal { get; set; }

    public virtual Horgaszok? Horgaszok { get; set; }
}
