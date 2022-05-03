using ExamAWS.Data;
using ExamAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAWS.Repositories
{
    public class RepositoryEquipos
    {
        private EquiposContext context;
        public RepositoryEquipos(EquiposContext context)
        {
            this.context = context;
        }

        public List<JUGADORES> GetJugadores(int idEquipo)
        {
            return this.context.Jugadores.Where(x => x.IdEquipo == idEquipo).ToList();
        }

        public void InsertJugador(JUGADORES jugador)
        {
            this.context.Jugadores.Add(jugador);
            this.context.SaveChanges();
        }
        public List<EQUIPOS> GetEquipos()
        {
            return this.context.Equipos.ToList();
        }
        public List<APUESTAS> GetApuestas()
        {
            return this.context.Apuestas.ToList();
        }
        public void InsetApuesta(APUESTAS apuesta)
        {
            this.context.Apuestas.Add(apuesta);
            this.context.SaveChanges();
        }

    }
}
