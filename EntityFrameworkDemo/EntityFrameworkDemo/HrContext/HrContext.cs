using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityFrameworkDemo.Model;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo.HrContext
{
    public class HrContext : DbContext
    {
        public HrContext() : base("Hr")
        {
            Init();
        }

        private void Init()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            ConfigurePropertyId(modelBuilder);
            ApplyCustomConventions(modelBuilder);

            modelBuilder.Entity<Employee>().Property(x => x.Email).IsRequired().HasMaxLength(35)
                .HasColumnAnnotation(
                        IndexAnnotation.AnnotationName,
                        new IndexAnnotation(
                            new IndexAttribute("UX_Email") { IsUnique = true }));
        }

        private void ApplyCustomConventions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(10, 2));
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(250));
        }

        private void ConfigurePropertyId(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(c =>
            {
                c.Property("Id").HasColumnName(c.ClrType.Name + "Id");
            });
        }
    }
}
