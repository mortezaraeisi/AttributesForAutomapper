using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AttributesForAutomapper.Domain;

namespace AttributesForAutomapper.DAL
{
    public class MySampleContext : DbContext
    {
        public IDbSet<Student> Students { set; get; }
        public IDbSet<Book> Books { set; get; }

        public MySampleContext()
            : base(@"Data Source=(local); Integrated Security=True;Initial Catalog=SampleAutoMapperDb;")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
