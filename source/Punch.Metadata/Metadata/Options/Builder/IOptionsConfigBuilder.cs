using System;
using System.Linq.Expressions;

namespace Punch.Metadata
{
    public interface IOptionsConfigBuilder<TModel, TListItem> : ILocalOptionsConfigBuilder<TModel, TListItem>, IRemoteOptionsConfigBuilder<TModel, TListItem>, IRemoteParamsOptionsConfigBuilder<TModel, TListItem>
    {
    
    }

    public interface IDependableOptionsConfigBuilder<TModel, TListItem>
    {
        void DependsOn<TProperty>(Expression<Func<TModel, TProperty>> expression);
    }

    public interface ILocalOptionsConfigBuilder<TModel, TListItem> : IDependableOptionsConfigBuilder<TModel, TListItem>
    {
        void DependsOn<TProperty>(Expression<Func<TModel, TProperty>> field, Expression<Func<TListItem, TProperty>> filterBy);
    }

    public interface IRemoteOptionsConfigBuilder<TModel, TListItem> : IDependableOptionsConfigBuilder<TModel, TListItem>
    {
        IRemoteParamsOptionsConfigBuilder<TModel, TListItem> FetchFrom(string url);
    }

    public interface IRemoteParamsOptionsConfigBuilder<TModel, TListItem> : IDependableOptionsConfigBuilder<TModel, TListItem>
    {
        IRemoteParamsOptionsConfigBuilder<TModel, TListItem> WithParameter<TProp>(Expression<Func<TModel, TProp>> expression);
    }
}
