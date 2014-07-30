using System;

namespace Punch.Metadata
{
    public class TimePickerMetadataConfigurator : ITimePickerMetadataConfigurator
    {
        private static readonly int HOURS_UPPER_BOUND = 23;
        private static readonly int MINUTES_UPPER_BOUND = 59;
        private static readonly int MINUTES_INTERVAL = 60;

        public TimePickerMetadata TimePickerMetadata { get; private set; }

        public TimePickerMetadataConfigurator(TimePickerMetadata timePickerMetadata)
        {
            this.TimePickerMetadata = timePickerMetadata;
        }

        public ITimePickerMetadataConfigurator ShowHoursFrom(int from)
        {
            if (from < 0 || from > HOURS_UPPER_BOUND)
            {
                OnArgumentOutOfRange("from", 1, HOURS_UPPER_BOUND);
            }
            this.TimePickerMetadata.hours.starts = from;
            return this;
        }

        public ITimePickerMetadataConfigurator ShowHoursUntil(int until)
        {
            if (until < 0 || until > HOURS_UPPER_BOUND)
            {
                OnArgumentOutOfRange("until", 1, HOURS_UPPER_BOUND);
            }
            this.TimePickerMetadata.hours.ends = until;
            return this;
        }

        public ITimePickerMetadataConfigurator ShowMinutesFrom(int from)
        {
            if (from < 0 || from > MINUTES_UPPER_BOUND)
            {
                OnArgumentOutOfRange("from", 1, MINUTES_UPPER_BOUND);
            }
            this.TimePickerMetadata.minutes.starts = from;
            return this;
        }

        public ITimePickerMetadataConfigurator ShowMinutesUntil(int until)
        {
            if (until < 0 || until > MINUTES_UPPER_BOUND)
            {
                OnArgumentOutOfRange("until", 1, MINUTES_UPPER_BOUND);
            }
            this.TimePickerMetadata.minutes.ends = until;
            return this;
        }

        public ITimePickerMetadataConfigurator MinutesInterval(int interval)
        {
            if (interval < 1 || interval > MINUTES_INTERVAL)
            {
                OnArgumentOutOfRange("interval", 1, MINUTES_INTERVAL);
            }
            this.TimePickerMetadata.minutes.interval = interval;
            return this;
        }

        private void OnArgumentOutOfRange(string name, int lowerBound, int upperBound)
        {
            throw new ArgumentOutOfRangeException(name, string.Format("The parameter should be a value between {0} and {1}", lowerBound, upperBound));
        }
    }
}
