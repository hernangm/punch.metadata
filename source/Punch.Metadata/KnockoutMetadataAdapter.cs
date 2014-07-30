using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Punch.Contracts;
using Punch.Core;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;

namespace Punch.Metadata
{
    public class KnockoutMetadataAdapter
    {
        private IKnockoutMetadataProvider MetadataProvider { get { return KnockoutMetadataProvider.Current; } }

        public KnockoutMetadataDictionary Adapt(Type type)
        {
            var metadataDictionary = new KnockoutMetadataDictionary();
            SetThis(type, ref metadataDictionary);
            var propertiesTypes = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                        .Select(m => m.PropertyType)
                                        .Distinct();

            foreach (var t in propertiesTypes)
            {
                var viewModelTypes = HasMetadataInspector.Inspect(t);
                foreach (var vt in viewModelTypes)
                {
                    if (!metadataDictionary.ContainsKey(t.Name))
                    {
                        metadataDictionary.Add(NormalizeViewModelType(vt), Adapt(vt));
                    }
                }
            }
            return metadataDictionary;
        }


        private void SetThis(Type type, ref KnockoutMetadataDictionary dic)
        {
            var viewModelTypes = HasMetadataInspector.Inspect(type);
            var metadatas = new Dictionary<Type, IMetadataDescriptor>();
            foreach (var tt in viewModelTypes)
            {
                var md = MetadataProvider.GetMetadata(tt);
                if (md != null)
                {
                    metadatas.Add(tt, md.FilterByInterface<IKnockoutExtenderParametersMetadata>());
                }
            }
            if (metadatas.Count > 0)
            {
                if (metadatas.Count == 1 && metadatas.Keys.First() == type)
                {
                    dic.SetThis(metadatas.First().Value);
                }
                else
                {
                    dic.SetThis(metadatas.Select(m => new KeyValuePair<string, IMetadataDescriptor>(m.Key.Name, m.Value)));
                }
            }
        }

        private static string NormalizeViewModelType(Type type)
        {
            var suffix = "ViewModel";
            var name = type.Name;
            if (name.EndsWith(suffix, StringComparison.InvariantCultureIgnoreCase))
            {
                name = Regex.Replace(name, suffix + "$", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }
            return name;
        }
    }
}
