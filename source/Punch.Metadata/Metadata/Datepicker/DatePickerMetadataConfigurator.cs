using System;

namespace Punch.Metadata
{
    public class DatePickerMetadataConfigurator: IFluentInterface
    {
        public DatePickerMetadata DatePickerMetadata { get; private set; }

        public DatePickerMetadataConfigurator(DatePickerMetadata datePickerConfig)
        {
            this.DatePickerMetadata = datePickerConfig;
        }

        public DatePickerMetadataConfigurator Min(DateTime min)
        {
            this.DatePickerMetadata.minDate = min;
            return this;
        }

        public DatePickerMetadataConfigurator Max(DateTime max)
        {
            this.DatePickerMetadata.maxDate = max;
            return this;
        }
    }
}
