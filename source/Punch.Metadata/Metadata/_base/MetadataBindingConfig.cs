using Punch.Contracts;
using Punch.Core;

namespace Punch.Metadata
{
    public abstract class MetadataBindingBase<TBinding> : MetadataBase, IKnockoutBindingMetadata<TBinding> where TBinding : IKnockoutBindingItem
    {
        public bool ShouldReplace { get; protected set; }
        public TBinding Binding { get; private set; }

        protected MetadataBindingBase(TBinding binding)
        {
            this.Binding = binding;
        }

        public IKnockoutBindingItem GetBinding()
        {
            return this.Binding;
        }
    }
}
