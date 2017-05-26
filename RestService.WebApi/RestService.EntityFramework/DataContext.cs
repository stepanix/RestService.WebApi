using RestService.Domain.Core;
using Microsoft.AspNet.Identity.EntityFramework;
using RestService.Domain.Entities;
using RestService.Domain.Identity;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.ModelConfiguration.Conventions;
using EntityFramework.Filters;


namespace RestService.EntityFramework
{
    public class DataContext : IdentityDbContext<User, Role, string, UserLogin, UserRole, UserClaim>
    {
        public DataContext()
            : base("name=DataConnectionString")
        {
        }

        public static DataContext Create()
        {
           return new DataContext();
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Register filter interceptor
            DbInterception.Add(new FilterInterceptor());

            modelBuilder.Conventions.Add(FilterConvention.Create<ISoftDelete, bool>("IsDeleted", (e, IsDeleted) => e.IsDeleted == false));

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");

            modelBuilder.Entity<User>().Property(r => r.Id);
            modelBuilder.Entity<UserClaim>().Property(r => r.Id);
            modelBuilder.Entity<Role>().Property(r => r.Id);
            modelBuilder.Entity<UserClaim>().Property(r => r.Id);
            modelBuilder.Entity<UserLogin>().Property(r => r.Id);
            modelBuilder.Entity<UserRole>().Property(r => r.Id);

            //Add index to the ObjectId Audit
            //modelBuilder.Entity<Audit>()
            //    .Property(e => e.ObjectId)
            //    .HasColumnAnnotation(
            //    IndexAnnotation.AnnotationName,
            //    new IndexAnnotation(new IndexAttribute()));
        }
    }

    public class DataContextConfiguration : DbConfiguration
    {
        public DataContextConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new DataContextExecutionStrategy());
        }
    }

}
