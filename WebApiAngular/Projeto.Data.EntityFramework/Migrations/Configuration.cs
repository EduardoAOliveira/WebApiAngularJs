namespace Projeto.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projeto.Data.EntityFramework.Context.DataContext>
    {
        public Configuration()
        {
            //permissão de CREATE e ALTER
            AutomaticMigrationsEnabled = true;

            //permissão de DROP
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Projeto.Data.EntityFramework.Context.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
