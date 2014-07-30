
namespace Punch.Metadata
{
    public interface ITimePickerBoundsMetadata
    {
        int starts { get; set; }
        int ends { get; set; }
    }

    public interface ITimePickerMinuteBoundsMetadata : ITimePickerBoundsMetadata
    {
        int interval { get; set; }
    }
}
