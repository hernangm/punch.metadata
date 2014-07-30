using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;

namespace Punch.Metadata
{
    public class OptionsConfigBuilder<TModel, TListItem> : IOptionsConfigBuilder<TModel, TListItem>
    {

        public OptionsMetadata<TListItem> ListSourceConfig { get; private set; }

        public OptionsConfigBuilder(OptionsMetadata<TListItem> listSourceConfig)
        {
            this.ListSourceConfig = listSourceConfig;
        }

        #region Local and Dependable
        public void DependsOn<TProperty>(Expression<Func<TModel, TProperty>> field, Expression<Func<TListItem, TProperty>> filterBy)
        {
            var dependsOnField = ExpressionHelper.GetExpressionText(field);
            this.ListSourceConfig.Depends = "$parent." + dependsOnField;
            this.ListSourceConfig.FilterBy = ExpressionHelper.GetExpressionText(filterBy);
        }
        #endregion

        #region Remote
        public IRemoteParamsOptionsConfigBuilder<TModel, TListItem> FetchFrom(string url)
        {
            this.ListSourceConfig.Url = url;
            return (IRemoteParamsOptionsConfigBuilder<TModel, TListItem>)this;
        }

        public void DependsOn<TProperty>(Expression<Func<TModel, TProperty>> field)
        {
            var dependsOnField = ExpressionHelper.GetExpressionText(field);
            this.ListSourceConfig.Depends = "$parent." + dependsOnField;
            this.WithParameter(field);
        }

        public IRemoteParamsOptionsConfigBuilder<TModel, TListItem> WithParameter<TProp>(Expression<Func<TModel, TProp>> parameter)
        {
            this.ListSourceConfig.Parameters.Add(ExpressionHelper.GetExpressionText(parameter));
            return (IRemoteParamsOptionsConfigBuilder<TModel, TListItem>)this;
        }
        #endregion
    }

    public static class OptionsExtensions
    {
        public static OptionsConfigBuilder<TModel, TListItem> Options<TModel, TProperty, TListItem, TOptionsValue, TOptionsText>(this IMetadataCollector<TModel, TProperty> metadataCollection, IEnumerable<TListItem> options, Expression<Func<TListItem, TOptionsValue>> optionsValue, Expression<Func<TListItem, TOptionsText>> optionsText)
        {
            var dependsOnConfig = new OptionsMetadata<TListItem>(options);
            metadataCollection.Add(dependsOnConfig);
            metadataCollection.Add(new OptionsMetadata(metadataCollection.PropertyName));
            metadataCollection.Add(new OptionsValueMetadata(ExpressionHelper.GetExpressionText(optionsValue)));
            metadataCollection.Add(new OptionsTextMetadata(ExpressionHelper.GetExpressionText(optionsText)));
            return new OptionsConfigBuilder<TModel, TListItem>(dependsOnConfig);
        }

        public static Doer<TModel, TProperty> Options<TModel, TProperty>(this IMetadataCollector<TModel, TProperty> metadataCollection)
        {
            return new Doer<TModel, TProperty>(metadataCollection);
        }
    }
}
