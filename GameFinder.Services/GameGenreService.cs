using GameFinder.Data;
using GameFinder.Models.JoiningModels;
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

        public IEnumerable<GameGenreDisplay> GetGameGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.GameGenres.Select(gp => new GameGenreDisplay()
                {
                    GameId = gp.GameId,
                    Title = gp.Game.Title,
                    GenreID = gp.GenreId,
                    Name = gp.Genre.Name
                });
                return query.ToList();
            }
        }

        public GameGenreDisplay GetGameGenreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameGenres.Find(id);
                var model = new GameGenreDisplay()
                {
                    GameId = entity.GameId,
                    Title = entity.Game.Title,
                    GenreID = entity.GenreId,
                    Name = entity.Genre.Name
                };
                return model;
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
