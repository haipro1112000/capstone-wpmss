using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseWPMSS
{
    public partial class MyDatabase : DbContext
    {
        public MyDatabase()
            : base("name=MyDatabase")
        {
        }

        public virtual DbSet<ACCOUNT> ACCOUNT { get; set; }
        public virtual DbSet<PHASE> PHASE { get; set; }
        public virtual DbSet<PHASE_TASK> PHASE_TASK { get; set; }
        public virtual DbSet<PROJECT> PROJECTS { get; set; }
        public virtual DbSet<ROLE_ACCOUNT> ROLE_ACCOUNT { get; set; }
        public virtual DbSet<ROLE_IN_PROJECT> ROLE_IN_PROJECT { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TASK> TASK { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.Passwords)
                .IsUnicode(false);

            modelBuilder.Entity<PROJECT>()
                .Property(e => e.Project_Manager)
                .IsUnicode(true);

            modelBuilder.Entity<ROLE_ACCOUNT>()
                .Property(e => e.Role_Name)
                .IsUnicode(false);
        }
    }
}
