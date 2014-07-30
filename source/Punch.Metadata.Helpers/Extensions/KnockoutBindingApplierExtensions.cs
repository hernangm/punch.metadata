using System.Web.Mvc;
using Punch.Contracts;
using Punch.Core;
using Punch.Metadata;

namespace Punch.Helpers
{
    public static class KnockoutBindingApplierExtensions
    {
        #region ApplyBindings
        public static KnockoutBindingApplier WithMetadata(this KnockoutBindingApplier applier)
        {
            if (applier.Model != null)
            {
                var metadata = new KnockoutMetadataAdapter().Adapt(applier.Model.GetType());
                applier.AddParameter(metadata);
            }
            return applier;
        }
        #endregion
    }
}
