using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Caching;
using Punch.Core;
using Eqip.Metadata.Contracts;
using Eqip.Metadata;
using Punch.Contracts;

namespace Punch.Metadata
{
    public class Provider : IKnockoutMetadataProvider
    {

        #region props and constrs
        private Cache Cache { get; set; }
        private IMetadataFactory MetadataFactory { get; set; }

        public Provider(Cache cache, IMetadataFactory metadataFactory)
        {
            this.Cache = cache;
            this.MetadataFactory = metadataFactory;
        }
        #endregion
        public IMetadataDescriptor GetMetadata(Type type)
        {
            IMetadataDescriptor descriptor = Cache[type.Name] as IMetadataDescriptor;

            if (descriptor == null)
            {
                var metadata = MetadataFactory.GetMetadataFor(type);
                if (metadata != null)
                {
                    descriptor = metadata.CreateDescriptor();
                    Cache[type.Name] = descriptor;
                }
            }
            return descriptor;
        }

        public IMetadataDescriptor GetMetadata<TType>() where TType : class
        {
            return GetMetadata(typeof(TType));
        }

        #region general
        public bool Contains<TModel, TProperty, TMetadata>(Expression<Func<TModel, TProperty>> binding)
            where TMetadata : IPropertyMetadata
        {
            Guard.NotNull(() => binding, binding);
            var metadata = GetMetadata(typeof(TModel));
            var propertyName = GetPropertyName(binding);
            if (metadata == null || !metadata.Properties.ContainsKey(propertyName))
            {
                return false;
            }
            return metadata.Properties[propertyName].Contains<TMetadata>();
        }



        public TMetadata FirstOrDefault<TModel, TProperty, TMetadata>(Expression<Func<TModel, TProperty>> binding)
            where TMetadata : IPropertyMetadata
        {
            Guard.NotNull(() => binding, binding);
            var metadata = GetMetadata(typeof(TModel));
            var propertyName = GetPropertyName(binding);
            if (metadata == null || !metadata.Properties.ContainsKey(propertyName))
            {
                return default(TMetadata);
            }
            return metadata.Properties[propertyName].FirstOrDefault<TMetadata>();
        }



        public IEnumerable<TMetadata> Where<TModel, TProperty, TMetadata>(Expression<Func<TModel, TProperty>> binding)
            where TMetadata : IPropertyMetadata
        {
            Guard.NotNull(() => binding, binding);
            var metadata = GetMetadata(typeof(TModel));
            var propertyName = GetPropertyName(binding);
            if (metadata == null || !metadata.Properties.ContainsKey(propertyName))
            {
                return new List<TMetadata>();
            }
            return metadata.Properties[propertyName].Where<TMetadata>();
        }
        #endregion


        #region bindings
        public bool ContainsBindingMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding)
        {
            return Contains<TModel, TProperty, IKnockoutBindingMetadata>(binding);
        }

        public IEnumerable<IKnockoutBindingMetadata> WhereBindingMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding)
        {
            return Where<TModel, TProperty, IKnockoutBindingMetadata>(binding);
        }
        #endregion


        #region extends
        public bool ContainsExtendedObservableMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding)
        {
            return Contains<TModel, TProperty, IKnockoutExtendedObservableMetadata>(binding);
        }

        public IKnockoutExtendedObservableMetadata FirstOrDefaultExtendedObservableMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding)
        {
            return FirstOrDefault<TModel, TProperty, IKnockoutExtendedObservableMetadata>(binding);
        }
        #endregion


        #region private
        private string GetPropertyName<TModel, TProperty>(Expression<Func<TModel, TProperty>> binding)
        {
            return KnockoutExpressionConverter.Convert(binding, null, false);
        }
        #endregion

    }
}
