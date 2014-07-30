using Punch.Bindings;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Metadata
{
    public class OptionsTextMetadata : MetadataBindingBase<KnockoutOptionsTextBinding>, IKnockoutInputBindingMetadata
    {
        public OptionsTextMetadata(string optionText)
            : base(new KnockoutOptionsTextBinding(optionText, true)) { }
    }
}
