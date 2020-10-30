using Domain.Entities;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;


namespace Data

{
    [Serializable]
    public class PfeContext : DbContext
    {

        public PfeContext()
            : base("EspritDB")
        {
        }
        public static PfeContext Create()
        {
            return new PfeContext();
        }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Cours> Cours { get; set; }

        public DbSet<Formation> Formations { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Formateur> Formateurs { get; set; }
        //public DbSet<AccountModel> AccountModels { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("C##AZIZ");
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            //modelBuilder.Conventions.Remove<ColumnTypeCasingConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           
            ////AspNetUsers -> User
            //modelBuilder.Entity<ApplicationUser>()
            //    .ToTable("User");
            ////AspNetRoles -> Role
            //modelBuilder.Entity<IdentityRole>()
            //    .ToTable("Role");
            ////AspNetUserRoles -> UserRole
            //modelBuilder.Entity<IdentityUserRole>()
            //    .ToTable("UserRole");
            ////AspNetUserClaims -> UserClaim
            //modelBuilder.Entity<IdentityUserClaim>()
            //    .ToTable("UserClaim");
            ////AspNetUserLogins -> UserLogin
            //modelBuilder.Entity<IdentityUserLogin>()
            //    .ToTable("UserLogin");
        }



    }
}
