using GameFinder.Data;
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

        public IEnumerable<GamePlatform> GetGamePlatforms()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.GamePlatforms.ToList();
            }
        }

        public GamePlatform GetGamePlatformById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.GamePlatforms.Find(id);
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
