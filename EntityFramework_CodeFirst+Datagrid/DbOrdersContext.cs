using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst_Datagrid
{
    public class DbOrdersContext : DbContext
    {
        public DbOrdersContext() : base (@"name=AppDb\OrdersDatabase") //database name
        {
        }

        public DbSet<Order> OurOrders { get; set; }
        public DbSet<SpecialOrder> OurSpecialOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            bool exists = System.IO.Directory.Exists("AppDb");
            if (!exists)
                System.IO.Directory.CreateDirectory("AppDb");
            
            //entity framework do not create EdmMetadata table (the table, which contains hash impresssion of the original database model)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            ConfigureDefectEntity(modelBuilder);
            //always recreate the database
            //Database.SetInitializer(new DropCreateDatabaseAlways<ContextObjednavky>());

            //
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbOrdersContext>());
        }

        private void ConfigureDefectEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Base.tbOrders");
            modelBuilder.Entity<SpecialOrder>().ToTable("Base.tbSpecialOrders");
        }



    }
}
