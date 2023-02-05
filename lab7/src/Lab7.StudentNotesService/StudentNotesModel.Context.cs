using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace lab_6_odata
{    
    public partial class WsPINEntities : DbContext
    {
        public WsPINEntities() : base("name=WsPINEntities") { }

        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) => throw new UnintentionalCodeFirstException();
    }
}
