using ScreenSound_04.Modelos;

namespace ScreenSound_04.Filtros;

internal class LinqFilter
{
    public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
    {
        var todosOsGenerosMusicais = musicas.Select(genero => genero.Genero).Distinct().ToList();
        foreach(var genero in todosOsGenerosMusicais)
        {
            Console.WriteLine($"- {genero}");
        }
    }

    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero) 
    {
        var artistaPorGeneroMusical = musicas.Where(musica=>musica.Genero!.Contains(genero)).Select(musica=>musica.Artista).Distinct().ToList();
        Console.WriteLine($"Exibindo artistas por gênero musical >>> {genero}");
        foreach(var artista in artistaPorGeneroMusical)
        {
            Console.WriteLine($" - {artista}");
        }
    }

    public static void FiltarMusicasDeUmArtista(List<Musica> musicas, string nomeDoArtisa) 
    {
        var musicasDoArtista = musicas.Where(musica => musica.Artista!.Equals(nomeDoArtisa)).ToList();
        Console.WriteLine(nomeDoArtisa);
        foreach(var musica in musicasDoArtista)
        {
            Console.WriteLine($" - {musica.Nome}");
        }
    }

    public static void FiltrarMusicasPorAno(List<Musica> musicas, int ano) 
    {
        var musicasPorAno = musicas.Where(musica => musica.Ano == ano).OrderBy(musica=>musica.Nome).Select(musica=>musica.Nome).Distinct().ToList();
        Console.WriteLine($"Musicas de {ano}");
        foreach(var musica in musicasPorAno)
        {
            Console.WriteLine($" - {musica}");
        }
    }

    public static void FiltrarPorTonalidade(List<Musica> musicas, string tonalidade)
    {
        var musicasNaTonalidadeDesejada = musicas.Where(musica => musica.Tonalidade.Equals(tonalidade)).Select(musica => musica.Nome).ToList();
        Console.WriteLine($"Músicas em: {tonalidade}");
        foreach (var musica in musicasNaTonalidadeDesejada)
        {
            Console.WriteLine($" - {musica}");
        }
        {
            
        }
    }

}
