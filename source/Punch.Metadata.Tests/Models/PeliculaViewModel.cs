using Punch.Core;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;
using Newtonsoft.Json;

namespace Punch.Metadata.Tests
{
    public class PeliculaViewModelNot
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }

    public class PeliculaViewModel : PeliculaViewModelNot
    {
        [KnockoutReference]
        public string KnockoutProperty { get; private set; }

        [JsonIgnore]
        public string MustIgnore { get { return "Pepe"; } }
    }

    [HasMetadata]
    public class PeliculaViewModelByAttribute : PeliculaViewModelNot
    {
    }

    [HasMetadata]
    public class PeliculaViewModelByInterface : PeliculaViewModelNot
    {
    }
}
