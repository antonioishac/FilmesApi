using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Services.impl;

public class FilmeService : IFilmeService
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeService(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Filme AdicionarFilme(CreateFilmeDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return filme;
    }

    public Filme? recuperaFilmePorId(int Id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == Id);
        if (filme == null) return null;

        return filme;
    }

    public IEnumerable<Filme> GetFilmes(int skip, int take)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }
}
