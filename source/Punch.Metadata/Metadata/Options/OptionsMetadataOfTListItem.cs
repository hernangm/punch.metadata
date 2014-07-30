using System.Collections.Generic;

namespace Punch.Metadata
{

    public class OptionsMetadata<TListItem> : MetadataExtenderParametersBase
    {
        public enum FetchMethodType
        {
            Local,
            Remote
        }
        public FetchMethodType FetchMethod { get; private set; }
        public IEnumerable<TListItem> Options { get; set; }
        public string Depends { get; set; }
        public string FilterBy { get; set; }
        public string Url { get; set; }
        public List<string> Parameters { get; set; }

        public OptionsMetadata(IEnumerable<TListItem> options)
            : this()
        {
            this.FetchMethod = FetchMethodType.Local;
            this.Options = options;
        }

        public OptionsMetadata()
        {
            this.FetchMethod = FetchMethodType.Remote;
            this.Parameters = new List<string>();
        }
    }
}
