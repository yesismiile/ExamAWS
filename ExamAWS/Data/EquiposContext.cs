using ExamAWS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAWS.Data
{
    public class EquiposContext: DbContext
    {
        public EquiposContext(DbContextOptions<EquiposContext> options)
        : base(options) { }

        public DbSet<APUESTAS> Apuestas { get; set; }
        public DbSet<EQUIPOS> Equipos { get; set; }
        public DbSet<JUGADORES> Jugadores { get; set; }
    }
    
}
