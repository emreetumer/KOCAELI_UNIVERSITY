using EvrakTakip.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvrakTakip.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EvrakTipi> EvrakTipi { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Evrak> Evrak { get; set; }


        public DbSet<BakimHizmetKart> BakimHizmetKart { get; set; }
        public DbSet<BakimHizmetiGenel> BakimHizmetiGenel { get; set; }
        public DbSet<BakimHizmetiDetay> BakimHizmetiDetay { get; set; }
    }
}
