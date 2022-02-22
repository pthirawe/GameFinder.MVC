using GameFinder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class GameFeatureService
    {
        public bool CreateGameFeature(GameFeature item)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ctx.GameFeatures.Add(item);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameFeature> GetGameFeatures()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.GameFeatures.ToList();
            }
        }

        public GameFeature GetGameFeatureById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.GameFeatures.Find(id);
            }
        }

        public bool DeleteGameFeature(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameFeatures.Find(id);

                ctx.GameFeatures.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
