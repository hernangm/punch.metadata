using Punch.Bindings;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Metadata
{
    public class OptionsValueMetadata : MetadataBindingBase<KnockoutOptionsValueBinding>, IKnockoutInputBindingMetadata
    {
        public OptionsValueMetadata(string optionValue)
            : base(new KnockoutOptionsValueBinding(optionValue, true)) { }
    }
}
