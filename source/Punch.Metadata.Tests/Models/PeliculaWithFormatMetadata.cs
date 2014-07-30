using Eqip.Metadata;
using Eqip.Metadata.Contracts;

namespace Punch.Metadata.Tests
{
    [HasMetadata]
    public class PeliculaWithFormatMetadataViewModel
    {
        public int Id { get; set; }
    }

    public class PeliculaWithFormatMetadataViewModelMetadata : MetadataFor<PeliculaWithFormatMetadataViewModel>
    {
        public PeliculaWithFormatMetadataViewModelMetadata()
        {
            this.MetadataFor(m => m.Id).Format("0000");
        }
    }
}
