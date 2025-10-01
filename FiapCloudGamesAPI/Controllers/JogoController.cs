using Core.Entity;
using Core.Input;
using Core.Repository;
using Infrastructure.Repository; // ou o namespace onde está seu ApplicationDbContext
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoController(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        [HttpGet("{guid:guid}")]
        public IActionResult Get([FromRoute] Guid guid)
        {
            try
            {
                return Ok(_jogoRepository.ObterPorGuid(guid));
            }
            catch (DbUpdateException dbEx)
            {
                return BadRequest(new { error = dbEx.InnerException?.Message ?? dbEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error", detail = ex.Message });
            }
        }

        [HttpDelete("{guid:guid}")]
        public IActionResult Delete([FromRoute] Guid guid)
        {
            var userName = User.Identity?.Name ?? "sistema"; //Sera resolvido posteriormente com o sistema de autenticação
            try
            {
                _jogoRepository.Deletar(guid);
                return Ok();
            }
            catch (DbUpdateException dbEx)
            {
                return BadRequest(new { error = dbEx.InnerException?.Message ?? dbEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error", detail = ex.Message });
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] JogoUpdateInput input)
        {
            var userName = User.Identity?.Name ?? "sistema"; //Sera resolvido posteriormente com o sistema de autenticação
            try
            {
                var jogo = _jogoRepository.ObterPorGuid(input.Guid);
                jogo.Nome = input.Nome;
                jogo.Descricao = input.Descricao;
                jogo.DataLancamento = DateOnly.FromDateTime(input.DataLancamento);
                jogo.ClassificacaoIndicativa = input.ClassificacaoIndicativa;
                jogo.Preco = input.Preco;
                jogo.GuidGenero = input.GuidGenero;
                jogo.GuidDesenvolvedor = input.GuidDesenvolvedor;
                jogo.Status = input.Status;
                jogo.ModificadoPor = userName;
                jogo.DataModificacao = DateTime.Now;
                _jogoRepository.Alterar(jogo);
                return Ok();
            }
            catch (DbUpdateException dbEx)
            {
                return BadRequest(new { error = dbEx.InnerException?.Message ?? dbEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error", detail = ex.Message });
            }
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_jogoRepository.ObterTodos());
            }
            catch (DbUpdateException dbEx)
            {
                return BadRequest(new { error = dbEx.InnerException?.Message ?? dbEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error", detail = ex.Message });
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] JogoInput input)
        {
            var userName = User.Identity?.Name ?? "sistema"; //Sera resolvido posteriormente com o sistema de autenticação
            try
            {
                var jogo = new Jogo()
                {
                    Nome = input.Nome,
                    Descricao = input.Descricao,
                    DataLancamento = DateOnly.FromDateTime(input.DataLancamento),
                    ClassificacaoIndicativa = input.ClassificacaoIndicativa,
                    Preco = input.Preco,
                    CriadoPor = userName,
                    Status = input.Status,
                    Genero = input.Genero,
                    Desenvolvedor = input.Desenvolvedor
                };
                _jogoRepository.Cadastrar(jogo);
                return Ok();
            }
            catch (DbUpdateException dbEx)
            {
                return BadRequest(new { error = dbEx.InnerException?.Message ?? dbEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error", detail = ex.Message });
            }
        }








        //    // Aqui virão os endpoints
        //    [HttpPost]
        //    public IActionResult CriarJogo([FromBody] Jogo jogo)
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest(ModelState);

        //        _context.Jogo.Add(jogo);
        //        _context.SaveChanges();

        //        return CreatedAtAction(nameof(ObterPorId), new { id = jogo.Guid }, jogo);
        //    }
        //    // Busca jogo pelo ID
        //    [HttpGet("{id}")]
        //    public IActionResult ObterPorId(Guid id)
        //    {
        //        var jogo = _context.Jogos.Find(id);

        //        if (jogo == null)
        //            return NotFound();

        //        return Ok(jogo);
        //    }

        //    // Listar todos os jogos
        //    [HttpGet]
        //    public IActionResult ListarTodos()
        //    {
        //        var jogos = _context.Jogo.ToList();
        //        return Ok(jogos);
        //    }

        //    // atualizar um jogo
        //    [HttpPut("{id}")]
        //    public IActionResult AtualizarJogo(Guid id, [FromBody] Jogo jogoAtualizado)
        //    {
        //        var jogo = _context.Jogo.Find(id);

        //        if (jogo == null)
        //            return NotFound();

        //        // Atualiza os campos
        //        jogo.Nome = jogoAtualizado.Nome;
        //        jogo.Genero = jogoAtualizado.Genero;
        //        jogo.Desenvolvedor = jogoAtualizado.Desenvolvedor;
        //        jogo.DataLancamento = jogoAtualizado.DataLancamento;
        //        jogo.Descricao = jogoAtualizado.Descricao;
        //        jogo.ClassificacaoIndicativa = jogoAtualizado.ClassificacaoIndicativa;
        //        jogo.Preco = jogoAtualizado.Preco;
        //        jogo.CriadoPor = jogoAtualizado.CriadoPor;

        //        _context.SaveChanges();

        //        return NoContent();
        //    }

        //    // remover um jogo
        //    [HttpDelete("{id}")]
        //    public IActionResult RemoverJogo(Guid id)
        //    {
        //        var jogo = _context.Jogo.Find(id);

        //        if (jogo == null)
        //            return NotFound();

        //        _context.Jogo.Remove(jogo);
        //        _context.SaveChanges();

        //        return NoContent();
        //    }


    }

}
