using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Services
{
    public interface IFilmeService
    {
        public Filme AdicionarFilme(CreateFilmeDto filmeDto);

        public Filme? recuperaFilmePorId(int Id);

        public IEnumerable<Filme> GetFilmes(int skip, int take);
    }
}
