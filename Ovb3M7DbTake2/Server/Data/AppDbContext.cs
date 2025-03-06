using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ovb3M7Db.Server.Models.AppDb;

namespace Ovb3M7Db.Server.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ovb3M7Db.Server.Models.AppDb.PokerHand>()
              .Property(p => p.Runtime)
              .HasColumnType("datetime");
            this.OnModelBuilding(builder);
        }

        public DbSet<Ovb3M7Db.Server.Models.AppDb.PokerHand> PokerHands { get; set; }

        public DbSet<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> SortHoleCardsStds { get; set; }

        public DbSet<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> SortHoleCombos { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    }
}