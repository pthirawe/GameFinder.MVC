using GameFinder.Data;
using GameFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class GameService
    {
        public bool CreateGame(GameCreate model)
        {
            var entity = new Game()
            {
                Title = model.Title,
                Description = model.Description,
                ReleaseDate = model.ReleaseDate,
                DeveloperId = model.DeveloperId,
                PublisherId = model.PublisherId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetGames()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var gameList = ctx.Games.Select(g => new GameListItem()
                {
                    GameId = g.GameId,
                    Title = g.Title,
                });
                return gameList.ToArray();
            }
        }

        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game = ctx.Games.Single(g => g.GameId == id);

                return new GameDetail()
                {
                    GameId = game.GameId,
                    Title = game.Title,
                    Description = game.Description,
                    ReleaseDate = game.ReleaseDate,
                    Developer = game.Developer.Name,
                    Publisher = game.Publisher.Name
                };
            }
        }

        public bool UpdateGame(int id, GameUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game = ctx.Games.Find(id);
                
                game.Title = model.Title;
                game.Description = model.Description;
                game.ReleaseDate = model.ReleaseDate;
                game.PublisherId = model.PublisherId;
                game.DeveloperId = model.DeveloperId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game = ctx.Games.Find(id);

                ctx.Games.Remove(game);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
