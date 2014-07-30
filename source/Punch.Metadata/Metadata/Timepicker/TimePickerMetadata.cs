using Eqip.Metadata;
using Eqip.Metadata.Contracts;

namespace Punch.Metadata
{
    public class TimePickerMetadata : MetadataExtenderParametersBase
    {
        public class TimePickerBoundsMetadata : ITimePickerBoundsMetadata
        {
            public int starts { get; set; }
            public int ends { get; set; }
        }

        public class TimePickerMinuteBoundsMetadata : TimePickerBoundsMetadata, ITimePickerMinuteBoundsMetadata
        {
            public int interval { get; set; }
        }

        public string defaultTime { get; set; }
        public ITimePickerBoundsMetadata hours { get; set; }
        public ITimePickerMinuteBoundsMetadata minutes { get; set; }
    }

    public static class TimePickerExtensions
    {
        public static ITimePickerMetadataConfigurator TimePicker<TModel, TProperty>(this IMetadataCollector<TModel, TProperty> metadataCollection)
        {
            var builder = new TimePickerMetadataConfigurator(new TimePickerMetadata());
            metadataCollection.Add(builder.TimePickerMetadata);
            return builder;
        }
    }

}
