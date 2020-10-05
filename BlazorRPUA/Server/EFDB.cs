using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRPUA.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using IdentityServer4.EntityFramework.Options;

namespace BlazorRPUA.Server
{
    public class EFDB: DbContext
    {

    public EFDB(DbContextOptions<EFDB> dbC) : base(dbC) { }
   
        

        //konstruktori da bi koristili appsettings.json
        //public EFDB(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        //public IConfiguration Configuration { get; }

        //db set klasa koje koristimo
        public DbSet<PrimalacUsluga> PrimalacUslugas { get; set; }
    public DbSet<Adresa> Adresas { get; set; }

        //definisanje ključeva za kreirane db setove
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PrimalacUsluga>().HasKey(p => p.ID);
        modelBuilder.Entity<Adresa>().HasKey(a => a.ID);

        //modelBuilder.Entity<Adresa>().HasData(new Adresa {ID=1, Ulica = "Mehmeda Alibašića", Broj ="13", Grad="Novi Pazar", PosBroj="36300", Drzava="Srbija"});
        //modelBuilder.Entity<Adresa>().HasData(new Adresa {ID=2, Ulica = "Kragujevačka", Broj ="BB", Grad="Novi Pazar", PosBroj="36300", Drzava="Srbija"});
            
        //modelBuilder.Entity<PrimalacUsluga>().HasData(new PrimalacUsluga { ID=1, Ime = "Esad", Prezime ="Međedović", KontaktTel="063614616", Email="esad@dr.com"});

        modelBuilder.Entity<PrimalacUsluga>().HasIndex(i => i.Email).IsUnique();
        modelBuilder.Entity<PrimalacUsluga>().HasIndex(i => i.KontaktTel).IsUnique();
    }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(Configuration["DB"]);
        //    //optionsBuilder.UseSqlServer(@"Data Source=EM-THINKPAD;Initial Catalog=DBCareRPUA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}

    }
}
