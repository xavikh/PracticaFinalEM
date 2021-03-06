﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PracticaEM.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; internal set; }
        public string Surname { get; internal set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PracticaEM.Models.GrupoClase> GrupoClases { get; set; }

        public System.Data.Entity.DbSet<PracticaEM.Models.Curso> Cursoes { get; set; }

        public System.Data.Entity.DbSet<PracticaEM.Models.Matricula> Matriculas { get; set; }

        public System.Data.Entity.DbSet<PracticaEM.Models.AsignacionDocente> AsignacionDocentes { get; set; }

        public System.Data.Entity.DbSet<PracticaEM.Models.Evaluacion> Evaluacions { get; set; }
    }
}