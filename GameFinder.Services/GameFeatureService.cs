using GameFinder.Data;
using GameFinder.Models.JoiningModels;
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

        public IEnumerable<GameFeatureDisplay> GetGameFeatures()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.GameFeatures.Select(gp => new GameFeatureDisplay()
                {
                    GameId = gp.GameId,
                    Title = gp.Game.Title,
                    FeatureID = gp.FeatureId,
                    Name = gp.Feature.Name
                });
                return query.ToList();
            }
        }

        public GameFeatureDisplay GetGameFeatureById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameFeatures.Find(id);
                var model = new GameFeatureDisplay()
                {
                    GameId = entity.GameId,
                    Title = entity.Game.Title,
                    FeatureID = entity.FeatureId,
                    Name = entity.Feature.Name
                };
                return model;
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
