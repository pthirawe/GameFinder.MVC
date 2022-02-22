using GameFinder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class GameGenreService
    {
        public bool CreateGameGenre(GameGenre item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.GameGenres.Add(item);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameGenre> GetGameGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.GameGenres.ToList();
            }
        }

        public GameGenre GetGameGenreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.GameGenres.Find(id);
            }
        }

        public bool DeleteGameGenre(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameGenres.Find(id);

                ctx.GameGenres.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
