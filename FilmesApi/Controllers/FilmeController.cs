using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[Route("api/filmes")]
[ApiController]
[Produces("application/json")]
public class FilmeController : ControllerBase
{
    private IFilmeService _filmeService;

    public FilmeController(IFilmeService filmeService)
    {            
        _filmeService = filmeService;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {            
        var filmeSave = _filmeService.AdicionarFilme(filmeDto);

        return CreatedAtAction(nameof(RecuperaFilmePorId),
            new { id = filmeSave.Id },
            filmeSave);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _filmeService.GetFilmes(skip, take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _filmeService.recuperaFilmePorId(id);
        if (filme == null) return NotFound();

        return Ok(filme);
    }
}
