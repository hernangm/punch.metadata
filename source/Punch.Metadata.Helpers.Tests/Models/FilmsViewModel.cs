using System.Collections.Generic;
using Eqip.Metadata;
using FluentValidation;

namespace Punch.Metadata.Helpers.Tests
{
    public class ListMetadataViewModel
    {
        public int Film { get; set; }
    }

    public class ListMetadataViewModelMetadata : MetadataFor<ListMetadataViewModel>
    {
        public ListMetadataViewModelMetadata()
        {
            this.RegisterValidator();
            this.MetadataFor(m => m.Film).Options(
                new List<KeyValuePair<int, string>>() {
                new KeyValuePair<int,string>(1,"Die Hard"),
                new KeyValuePair<int,string>(2,"Terminator")},
                m => m.Key,
                m => m.Value
            );
        }
    }

    public class FilmValidator : AbstractValidator<ListMetadataViewModel>
    {
        public FilmValidator()
        {
            RuleFor(m => m.Film).GreaterThan(8);
        }
    }
}
