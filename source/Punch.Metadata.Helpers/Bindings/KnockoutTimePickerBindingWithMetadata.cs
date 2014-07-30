using System;
using System.Linq.Expressions;
using Punch.Metadata;

namespace Punch.Bindings
{
    public class KnockoutTimePickerBindingWithMetadata<TModel> : KnockoutTimePickerBinding<TModel>
    {
        public TimePickerMetadata Options { get; set; }

        public KnockoutTimePickerBindingWithMetadata(Expression<Func<TModel, object>> expression, TimePickerMetadata config)
            : base(expression)
        {
            this.Options = Options;
        }
    }
}
