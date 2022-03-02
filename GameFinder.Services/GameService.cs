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
                var gameGenres = ctx.GameGenres;
                var gameList = ctx.Games.Select(g => new GameListItem()
                {
                    GameId = g.GameId,
                    Title = g.Title,
                    Genre = gameGenres.Where(x => x.GameId == g.GameId).Select(x => x.Genre.Name).ToList(),
                    Developer = g.Developer.Name,
                    Publisher = g.Publisher.Name
                });
                return gameList.ToList();
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
                    DeveloperId=game.DeveloperId,
                    Developer = game.Developer.Name,
                    PublisherId = game.PublisherId,
                    Publisher = game.Publisher.Name
                };
            }
        }

        public IEnumerable<GameListItem> GetGamesByDev(string devName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games = ctx.Games.Where(g => g.Developer.Name.Contains(devName)).Select(g => new GameListItem()
                {
                    GameId = g.GameId,
                    Title = g.Title
                });

                return games.ToList();
            }
        }

        public IEnumerable<GameListItem> GetGamesByPublisher(string pubName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games = ctx.Games.Where(g => g.Publisher.Name == pubName).Select(g => new GameListItem()
                {
                    GameId = g.GameId,
                    Title = g.Title
                });

                return games.ToList();
            }
        }

        public IEnumerable<GameListItem> GetGamesByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games = ctx.Games.Where(g => g.Title.Contains(title)).Select(g => new GameListItem()
                {
                    GameId=g.GameId,
                    Title=g.Title
                });

                return games.ToList();
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
