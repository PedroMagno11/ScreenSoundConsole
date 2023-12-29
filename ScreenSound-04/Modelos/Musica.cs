using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ScreenSound_04.Modelos
{
    internal class Musica
    {
        private string[] _tonalidades =
        {
            "C", "C#", "D", "Eb", "E", "F", "F#", "G", "Ab", "A", "Bb", "B"
        };

        [JsonPropertyName("song")]
        public string? Nome { get; set; }
        [JsonPropertyName("artist")]
        public string? Artista { get; set; }
        [JsonPropertyName("duration_ms")]
        public int Duracao { get; set; }
        [JsonPropertyName("genre")]
        public string? Genero { get; set; }
        [JsonPropertyName("year")]
        public string? AnoString { get; set; }
        [JsonPropertyName("key")]
        public int Key { get; set; }
        public int Ano
        {
            get
            {
                return int.Parse(this.AnoString);
            }
        }

        public string Tonalidade 
        {
            get
            {
                return this._tonalidades[Key];
            }
        }
        public override string ToString()
        {
            return $"Artista: {Artista}\nMúsica: {Nome}\nDuração em segundos: {Duracao/1000}\nGênero musical: {Genero}\nAno: {Ano}\nTonalidade: {Tonalidade}";
        }

    }
}
