using ExamAWS.Models;
using ExamAWS.Repositories;
using ExamAWS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAWS.Controllers
{
    public class EquiposController : Controller
    {
        private RepositoryEquipos repo;
        private s3 service;

        public EquiposController(RepositoryEquipos repo, s3 service)
        {
            this.repo = repo;
            this.service = service;
        }
        public IActionResult Equipos()
        {
            List<EQUIPOS> equipos = this.repo.GetEquipos();
            return View(equipos);
        }
        public IActionResult Jugadores(int id)
        {
            List<JUGADORES> jugadores = this.repo.GetJugadores(id);
            return View(jugadores);
        }
        public IActionResult Apuestas()
        {
            List<APUESTAS> apuestas = this.repo.GetApuestas();
            return View(apuestas);
        }
        public IActionResult CreateApuesta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateApuesta(APUESTAS apuesta)
        {
            this.repo.InsetApuesta(apuesta);
            return RedirectToAction("Apuestas");
        }

        public IActionResult CreateJugador(int idEquipo)
        {
            ViewData["EQUIPO"] = idEquipo;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateJugador(int IdJugador, string Nombre, string Posicion, IFormFile Imagen, int IdEquipo)
        {
            string extension = Imagen.FileName.Split(".")[1];
            string fileName = Nombre.Trim() + "." + extension;
            using (Stream stream = Imagen.OpenReadStream())
            {
                await this.service.UploadFileAsync(stream, fileName);
            }
            JUGADORES jugador = new JUGADORES()
            {
                IdJugador = IdJugador,
                Nombre = Nombre,
                Posicion = Posicion,
                Imagen = fileName,
                IdEquipo = IdEquipo
            };
            this.repo.InsertJugador(jugador);
            return RedirectToAction("Equipos");
        }
    }
}

