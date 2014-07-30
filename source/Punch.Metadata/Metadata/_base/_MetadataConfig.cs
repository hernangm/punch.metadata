using Punch.Contracts;
using Punch.Core;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;

namespace Punch.Metadata
{
    public abstract class MetadataBase : IKnockoutMetadata
    {
        public string Name
        {
            get { return new MetadataNameResolver().GetName(this.GetType()); }
        }
    }
}
