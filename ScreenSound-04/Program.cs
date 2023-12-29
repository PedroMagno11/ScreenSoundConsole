using ScreenSound_04.Filtros;
using ScreenSound_04.Modelos;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        Console.Write("Informe o seu nome: ");
        string username = Console.ReadLine()!;
        var musicasPreferidas = new MusicasPreferidas(username);

        ExibirMenu(musicas, musicasPreferidas);

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}

Console.WriteLine();

void ExibirMenu(List<Musica> musicas, MusicasPreferidas musicasPreferidas)
{
    Console.WriteLine("Digite 1 - Ver todos os gêneros musicas.");
    Console.WriteLine("Digite 2 - Ver todas as músicas de determinado gênero musical.");
    Console.WriteLine("Digite 3 - Ver todas as musicas de um determinado artista.");
    Console.WriteLine("Digite 4 - Ver os sucessos de determinado ano.");
    Console.WriteLine("Digite 5 - Ver todas as músicas de determinada tonalidade.");
    Console.WriteLine("Digite 6 - Para adicionar uma música aos favoritos.");
    Console.WriteLine("Digite 7 - Para exibir lista de músicas favoritas.");
    Console.WriteLine("Digite 8 - Para gerar um arquivo json com as suas músicas favoritas.");

    int opcao = int.Parse(Console.ReadLine()!);

    switch (opcao)
    {
        case 1:
            Console.Clear();
            LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
            Console.ReadLine();
            Console.Clear();
            ExibirMenu(musicas, musicasPreferidas);
            break;
        case 2:
            Console.Clear();
            Console.Write("Informe um gênero musical: ");
            string genero = Console.ReadLine()!;
            LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, genero);
            Console.ReadLine();
            Console.Clear();
            ExibirMenu(musicas, musicasPreferidas);
            break;
        case 3:
            Console.Clear();
            Console.Write("Informe o nome de um artista ou banda: ");
            string artista = Console.ReadLine()!;
            LinqFilter.FiltarMusicasDeUmArtista(musicas, artista);
            Console.ReadLine();
            Console.Clear();
            ExibirMenu(musicas, musicasPreferidas);
            break;
        case 4:
            Console.Clear();
            Console.Write("Informe um ano: ");
            int ano = int.Parse(Console.ReadLine()!);

            LinqFilter.FiltrarMusicasPorAno(musicas, ano);
            Console.ReadLine();
            Console.Clear();
            ExibirMenu(musicas, musicasPreferidas);
            break;
        case 5:
            Console.Clear();
            Console.Write("Informe uma tonalidade musical: ");
            string tom = Console.ReadLine()!;

            LinqFilter.FiltrarPorTonalidade(musicas, tom);
            Console.ReadLine();
            Console.Clear();
            ExibirMenu(musicas, musicasPreferidas);
            break;
        case 6:
            Console.Clear();
            Console.Write("Informe o nome da música que deseja adicionar aos favoritos: ");
            string musicaFavorita = Console.ReadLine()!;
            if (musicas.Exists(musica => musica.Nome == musicaFavorita))
            {
                Musica musica = musicas.Find(musica => musica.Nome==musicaFavorita);
                musicasPreferidas.AdicionarMusicasPreferidas(musica);
            }
            else
            {
                Console.WriteLine("Música não encontrada!");
            }
            Console.ReadLine();
            Console.Clear();
            ExibirMenu(musicas, musicasPreferidas);
            break;
        case 7:
            Console.Clear();
            musicasPreferidas.ExibirMusicasPreferidas();
            Console.ReadLine();
            Console.Clear();
            ExibirMenu(musicas, musicasPreferidas);
            break;
        case 8:
            Console.Clear();
            musicasPreferidas.GerarArquivoJson();
            Console.ReadLine();
            Console.Clear();
            ExibirMenu(musicas, musicasPreferidas);
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}