using System.Collections.Generic;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;

namespace Punch.Metadata.Tests
{
    [HasMetadata]
    public class PeliculaWithoutMetadataViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    [HasMetadata]
    public class PeliculaWithMetadataViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class PeliculaWithMetadataViewModelMetadata : MetadataFor<PeliculaWithMetadataViewModel>
    {
        public PeliculaWithMetadataViewModelMetadata()
        {
            this.MetadataFor(m => m.Id).Format("0000");
            this.MetadataFor(m => m.Nombre).Options(new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("H", "Hernan"), new KeyValuePair<string, string>("P", "Pepe") }, m => m.Key, m => m.Value);
        }
    }
}
