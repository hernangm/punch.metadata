using System;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;

namespace Punch.Metadata
{
    public class DatePickerMetadata : MetadataExtenderParametersBase
    {
        public DateTime? minDate { get; set; }
        public DateTime? maxDate { get; set; }
    }

    public static class DatePickerExtensions
    {
        public static DatePickerMetadataConfigurator DatePicker<TModel, TProperty>(this IMetadataCollector<TModel, TProperty> metadataCollection)
        {
            var builder = new DatePickerMetadataConfigurator(new DatePickerMetadata());
            metadataCollection.Add(builder.DatePickerMetadata);
            return builder;
        }
    }
}
