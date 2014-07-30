
namespace Punch.Metadata
{
    public interface ITimePickerMetadataConfigurator
    {
        ITimePickerMetadataConfigurator ShowHoursFrom(int from);
        ITimePickerMetadataConfigurator ShowHoursUntil(int until);
        ITimePickerMetadataConfigurator ShowMinutesFrom(int from);
        ITimePickerMetadataConfigurator ShowMinutesUntil(int until);
        ITimePickerMetadataConfigurator MinutesInterval(int interval);
    }
}
