using System.Linq;
using Punch.Contracts;
using Punch.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Punch.Metadata.Tests
{
    public class KnockoutMetadataAdapterTests : KnockoutMetadataAdapterBaseTests
    {
        [Test]
        public void filter_knockout()
        {
            Assert.IsTrue(typeof(FormatMetadata).GetInterfaces().Any(i => i == typeof(IKnockoutMetadata)));
        }

        [Test]
        public void serialize_viewmodel_with_metadata()
        {
            var metadata = this.Adapter.Adapt(typeof(PeliculaWithMetadataViewModel));
            var json = JsonConvert.SerializeObject(metadata);
            JObject obj = JObject.Parse(json);
            Assert.IsTrue(obj[KnockoutMetadataDictionary.THIS].HasValues);
            Assert.NotNull(obj[KnockoutMetadataDictionary.THIS]);
        }

        [Test]
        public void viewmodel_without_metadata()
        {
            var metadata = Adapter.Adapt(typeof(PeliculaWithoutMetadataViewModel));
            Assert.IsFalse(metadata.ContainsKey(KnockoutMetadataDictionary.THIS));
        }

        //[Test]
        //public void metadata_not_viewmodel_with_children_viewmodel()
        //{
        //    var metadata = Adapter.Adapt(typeof(PeliculaNotViewModelWithChildren));
        //    Assert.AreEqual(1,metadata.Count);
        //}

        [Test]
        public void metadata_viewmodel_without_children()
        {
            var metadata = Adapter.Adapt(typeof(PeliculaViewModel));
            Assert.AreEqual(0, metadata.Count);
        }

        [Test]
        public void viewmodel_with_metadata()
        {
            var metadata = Adapter.Adapt(typeof(PeliculaWithFormatMetadataViewModel));
            Assert.NotNull(metadata["$this"]);
        }

        //[Test]
        //public void viewmodel_with_metadata_and_children_collection_with_metadata()
        //{
        //    var metadata = Adapter.Adapt(typeof(PeliculaViewModelWithChildrenCollection));
        //    Assert.NotNull(metadata["$this"]);
        //    Assert.NotNull(metadata["Actor"]);
        //}


    }
}
