using Microsoft.AspNetCore.Mvc;

namespace MeuCinema.Models
{
    public class FilmesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sinopse { get; set; }
        public string Imagem { get; set; }
    }
}
