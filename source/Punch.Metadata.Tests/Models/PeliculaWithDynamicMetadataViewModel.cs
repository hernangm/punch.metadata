
using Eqip.Metadata;
using Eqip.Metadata.Contracts;
namespace Punch.Metadata.Tests
{
    [HasMetadata]
    public class PeliculaWithDynamicMetadataViewModel
    {
        public string Nombre { get; set; }
    }

    public class PeliculaWithDynamicMetadataViewModelMetadata : MetadataFor<PeliculaWithDynamicMetadataViewModel>
    {
        public static readonly string Login = "Login";

        public PeliculaWithDynamicMetadataViewModelMetadata()
        {
            this.Additional.Login = Login;
        }
    }
}
