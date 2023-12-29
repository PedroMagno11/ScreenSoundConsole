using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ScreenSound_04.Modelos
{
    internal class MusicasPreferidas
    {
        public string Nome { get; set; }
        public List<Musica> ListaDeMusicasPreferidas { get; }

        public MusicasPreferidas(string nome)
        {
            Nome = nome;
            ListaDeMusicasPreferidas = new List<Musica>();
        }

        public void AdicionarMusicasPreferidas(Musica musica)
        {
            ListaDeMusicasPreferidas.Add(musica);
            Console.WriteLine("Música adicionada com sucesso!");
        }

        public void ExibirMusicasPreferidas()
        {
            Console.WriteLine($"Essas são as músicas favoritas -> {Nome}");
            foreach(var musica in ListaDeMusicasPreferidas)
            {
                Console.WriteLine($" - {musica.Nome} de {musica.Artista}");
            }
            Console.WriteLine();
        }

        public void GerarArquivoJson()
        {
            string json = JsonSerializer.Serialize(new 
                {
                    nome = Nome,
                    musicas = ListaDeMusicasPreferidas,
                }
            );
            string nomeDoArquivo = $"musicas-favoritas-{Nome}.json";

            File.WriteAllText(nomeDoArquivo, json );
            Console.WriteLine($"O arquivo Json foi criado com sucesso! {Path.GetFullPath(nomeDoArquivo)}");
           

        }
    }
}
