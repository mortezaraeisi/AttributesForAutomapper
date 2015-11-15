using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttributesForAutomapper.Domain
{
    public class Book
    {
        public virtual int Id { set; get; }

        [StringLength(128,MinimumLength = 3)]
        [Display(Name = "Book name")]
        public virtual string Name { set; get; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Borrow Date Time")]
        public virtual DateTime BorrowDateTime { set; get; }

        [DataType(DataType.Date)]
        [Display(Name = "Expired Date")]
        public virtual DateTime ExpiredDateTime { set; get; }

        [DataType(DataType.Currency)]
        [Display(Name = "Book price")]
        public virtual decimal Price { set; get; }

        [ForeignKey("StudentIdFk")]
        public virtual Student Student { set; get; }
        public virtual int StudentIdFk { set; get; }
    }
}
