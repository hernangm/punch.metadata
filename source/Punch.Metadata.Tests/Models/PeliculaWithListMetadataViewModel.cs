using System.Collections.Generic;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;

namespace Punch.Metadata.Tests
{
    [HasMetadata]
    public class PeliculaWithListMetadataViewModel
    {
        public string Nombre { get; set; }
    }

    public class PeliculaWithListMetadataViewModelMetadata : MetadataFor<PeliculaWithListMetadataViewModel>
    {
        public PeliculaWithListMetadataViewModelMetadata()
        {
            this.MetadataFor(m => m.Nombre).Options(new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("H", "Hernan"), new KeyValuePair<string, string>("P", "Pepe") }, m => m.Key, m => m.Value);
        }
    }
}
