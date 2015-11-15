using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public string Email { set; get; }

        [MapForMember("RegisterDateTime")]
        public string RegisterDateTimePersian { set; get; }

        [UseValueResolver(typeof (BookCountValueResolver))]
        public int BookCounts { set; get; }

        [UseValueResolver(typeof (BookPriceValueResolver))]
        public decimal BookPrice { set; get; }
    }


    public class BookCountValueResolver : ValueResolver<Student, int>
    {
        protected override int ResolveCore(Student source)
        {
            return source.Books.Count;
        }
    }
    public class BookPriceValueResolver : ValueResolver<Student, decimal>
    {
        protected override decimal ResolveCore(Student source)
        {
            return source.Books.Sum(b => b.Price);
            //instead of
            //var ok = 0M;
           // foreach (var b in source.Books) ok += b.Price;
           // return ok;
        }
    }
}
