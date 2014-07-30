using System;
using System.Linq.Expressions;
using Punch.Metadata;

namespace Punch.Bindings
{
    public class KnockoutNumericBindingWithMetadata<TModel> : KnockoutDatePickerBinding<TModel>
    {
        public NumericMetadata Options { get; set; }

        public KnockoutNumericBindingWithMetadata(Expression<Func<TModel, object>> expression, NumericMetadata config)
            : base(expression)
        {
            this.Options = Options;
        }
    }
}
