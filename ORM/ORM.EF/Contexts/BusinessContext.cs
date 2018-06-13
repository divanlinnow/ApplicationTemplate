using Domain.Entities.Business;
using ORM.EF.Migrations;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace ORM.EF.Contexts
{
    public class BusinessContext : DbContext
    {
        public BusinessContext() : base("name=DevDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CoreContext, Configuration>());
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationBranch> OrganizationBranches { get; set; }
        public DbSet<OrganizationDepartment> OrganizationDepartments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<Workflow> WorkflowProcesses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Provide your own custom database schema name like this or comment it out to leave the default schema name.
            modelBuilder.HasDefaultSchema("AppTemplate");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var contextConfiguration = new ContextConfiguration();
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(contextConfiguration);

            foreach (var configuration in contextConfiguration.Configurations)
            {
                configuration.AddConfiguration(modelBuilder.Configurations);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}