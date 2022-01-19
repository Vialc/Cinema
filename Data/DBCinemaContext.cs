using MeuCinema.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuCinema.Data
{
    public class DBCinemaContext : DbContext
    {
        public DBCinemaContext(DbContextOptions<DBCinemaContext> options) : base(options)
        {

        }

        public DbSet<FilmesModel> Filmes { get; set; }
    }
}
