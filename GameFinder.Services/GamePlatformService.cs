using GameFinder.Data;
using GameFinder.Models.JoiningModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class GamePlatformService
    {
        public bool CreateGamePlatform(GamePlatform item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.GamePlatforms.Add(item);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GamePlatformDisplay> GetGamePlatforms()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.GamePlatforms.Select(gp => new GamePlatformDisplay()
                {
                    GameId = gp.GameId,
                    Title = gp.Game.Title,
                    PlatformID = gp.PlatformId,
                    Name = gp.Platform.Name
                });
                return query.ToList();
            }
        }

        public GamePlatformDisplay GetGamePlatformById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GamePlatforms.Find(id);
                var model = new GamePlatformDisplay()
                {
                    GameId = entity.GameId,
                    Title = entity.Game.Title,
                    PlatformID = entity.PlatformId,
                    Name = entity.Platform.Name
                };
                return model;
            }
        }

        public bool DeleteGamePlatform(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GamePlatforms.Find(id);

                ctx.GamePlatforms.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
