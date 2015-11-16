using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AttributesForAutomapper.Domain
{
    public class Student
    {
        public virtual int Id { set; get; }

        [StringLength(32, MinimumLength = 2)]
        [Display(Name = "Name")]
        public virtual string Name { set; get; }

        [StringLength(64, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public virtual string Family { set; get; }

        [EmailAddress]
        [StringLength(128)]
        public virtual string Email { set; get; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Register Date")]
        public virtual DateTime RegisterDateTime { set; get; }

        public virtual ICollection<Book> Books { set; get; }
    }
}
