using System.Linq;
using AttributesForAutomapper.Domain;
using AutoMapper;

namespace AttributesForAutomapper.ViewModels
{
    [MapFrom(typeof (Student), ignoreAllNonExistingProperty: true, alsoCopyMetadata: true)]
    public class AdminStudentViewModel
    {
        // [IgnoreMap]
        public int Id { set; get; }

        [MapForMember("Name")]
        public string FirstName { set; get; }

        [MapForMember("Family")]
        public string LastName { set; get; }

        [IgnoreMap]
        public string Email { set; get; }

        [MapForMember("RegisterDateTime")]
        public string RegisterDateTimePersian { set; get; }

        [UseValueResolver(typeof (BookCountValueResolver))]
        public int BookCounts { set; get; }

        [UseValueResolver(typeof (BookPriceValueResolver))]
        public decimal TotalBookPrice { set; get; }
    }


    public class BookCountValueResolver : ValueResolver<Student, int>
    {
        protected override int ResolveCore(Student source) => source.Books.Count;
    };

    public class BookPriceValueResolver : ValueResolver<Student, decimal>
    {
        protected override decimal ResolveCore(Student source) => source.Books.Sum(b => b.Price);
    };
}
