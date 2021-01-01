using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        //public ActionResult<IEnumerable<Evento>> Get()
        public async Task<IActionResult> Get()
        {
            // return new Evento[] {
            //     new Evento() {
            //         EventoId = 1,
            //         Tema = "Angular e .NET Core",
            //         Local = "Belo Horizonte",
            //         Lote = "1º Lote",
            //         QtdePessoas = 250,
            //         DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
            //         ImagemURL = "img1"
            //     },
            //     new Evento() {
            //         EventoId = 2,
            //         Tema = "Angular e Suas Novidades",
            //         Local = "São Paulo",
            //         Lote = "2º Lote",
            //         QtdePessoas = 350,
            //         DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
            //         ImagemURL = "img2"
            //     }
            //  };

            try
            {                
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou!");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // return new Evento[] {
            //     new Evento() {
            //         EventoId = 1,
            //         Tema = "Angular e .NET Core",
            //         Local = "Belo Horizonte",
            //         Lote = "1º Lote",
            //         QtdePessoas = 250,
            //         DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
            //     },
            //     new Evento() {
            //         EventoId = 2,
            //         Tema = "Angular e Suas Novidades",
            //         Local = "São Paulo",
            //         Lote = "2º Lote",
            //         QtdePessoas = 350,
            //         DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
            //     }
            //  }.FirstOrDefault(x => x.EventoId == id);
            
            try
            {                
                var results = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou!");
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
