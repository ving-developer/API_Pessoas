using API_Pessoas.Context;
using API_Pessoas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pessoas.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PessoasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> Get()
        {
            return _context.Pessoa.AsNoTracking().ToList();
        }

        [HttpGet("{id}",Name = "ObterPessoa")]
        public ActionResult<Pessoa> Get(int id)
        {
            Pessoa pessoa = _context.Pessoa.AsNoTracking()
                .FirstOrDefault(p => p.id_pessoa == id);

            if (pessoa == null)
                return NotFound();
            return pessoa;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            _context.SaveChanges();

            return new CreatedAtRouteResult(
                "ObterPessoa",
                new { id = pessoa.id_pessoa },
                pessoa
            );
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            if (id == pessoa.id_pessoa)
            {
                _context.Entry(pessoa).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<Pessoa> Delete(int id)
        {
            Pessoa pessoa = _context.Pessoa.Find(id);

            if (pessoa == null)
                return NotFound();

            _context.Pessoa.Remove(pessoa);
            _context.SaveChanges();

            return pessoa;

        }

    }
}
