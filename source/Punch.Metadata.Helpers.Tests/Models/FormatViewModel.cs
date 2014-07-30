using Eqip.Metadata;

namespace Punch.Metadata.Helpers.Tests
{
    public class FormatViewModel
    {
        public int Id { get; set; }
    }

    public class FormatMetadata : MetadataFor<FormatViewModel>
    {
        public FormatMetadata()
        {
            this.MetadataFor(m => m.Id).Format("0000");
        }
    }
}
