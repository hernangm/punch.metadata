using System;
using System.Linq.Expressions;
using Punch.Metadata;

namespace Punch.Bindings
{
    public class KnockoutDatePickerBindingWithMetadata<TModel> : KnockoutDatePickerBinding<TModel>
    {
        public DatePickerMetadata Options { get; set; }

        public KnockoutDatePickerBindingWithMetadata(Expression<Func<TModel, object>> expression, DatePickerMetadata config)
            : base(expression)
        {
            this.Options = Options;
        }
    }
}
