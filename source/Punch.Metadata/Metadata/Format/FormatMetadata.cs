using Eqip.Metadata;
using Eqip.Metadata.Contracts;

namespace Punch.Metadata
{
    public class FormatMetadata : MetadataExtendedObservableConfig
    {
        public string Mask { get; private set; }

        public FormatMetadata(string mask)
            : base()
        {
            this.Mask = mask;
        }
    }

    public static class FormatExtensions
    {
        public static IMetadataCollectorOptions<TModel, TProperty> Format<TModel, TProperty>(this IMetadataCollector<TModel, TProperty> metadataCollection, string mask)
        {
            return metadataCollection.Add(new FormatMetadata(mask));
        }
    }
}
