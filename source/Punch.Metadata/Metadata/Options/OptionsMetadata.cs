using Punch.Bindings;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Metadata
{
    public class OptionsMetadata : MetadataBindingBase<KnockoutOptionsBinding>, IKnockoutInputBindingMetadata
    {
        public OptionsMetadata(string options)
            : base(new KnockoutOptionsBinding(options + "." + "options")) { }
    }
}
