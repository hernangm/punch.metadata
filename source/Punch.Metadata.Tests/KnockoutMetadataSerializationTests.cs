using Punch.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Punch.Metadata.Tests
{
    public class KnockoutMetadataSerializationTests : KnockoutMetadataAdapterBaseTests
    {

        [Test]
        public void serialize_viewmodel_with_dynamic_metadata()
        {
            var adapted = this.Adapter.Adapt(typeof(PeliculaWithDynamicMetadataViewModel));
            var json = JsonConvert.SerializeObject(adapted);
            JObject obj = JObject.Parse(json);
            Assert.NotNull(obj[KnockoutMetadataDictionary.THIS]["Additional"][PeliculaWithDynamicMetadataViewModelMetadata.Login]);
            Assert.AreEqual(PeliculaWithDynamicMetadataViewModelMetadata.Login, obj[KnockoutMetadataDictionary.THIS]["Additional"][PeliculaWithDynamicMetadataViewModelMetadata.Login].Value<string>());
        }


        [Test]
        public void format()
        {
            var metadata = this.Adapter.Adapt(typeof(PeliculaWithFormatMetadataViewModel));
            var json = JsonConvert.SerializeObject(metadata);
            JObject obj = JObject.Parse(json);
            Assert.NotNull(obj[KnockoutMetadataDictionary.THIS]["Properties"]["Id"]);
        }


        [Test]
        public void list()
        {
            var adapted = this.Adapter.Adapt(typeof(PeliculaWithListMetadataViewModel));
            var json = JsonConvert.SerializeObject(adapted);
            JObject obj = JObject.Parse(json);
            Assert.NotNull(obj[KnockoutMetadataDictionary.THIS]["Properties"]["Nombre"]);
        }

    }
}
