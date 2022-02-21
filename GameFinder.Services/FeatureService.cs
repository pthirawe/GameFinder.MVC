using GameFinder.Data;
using GameFinder.Models.FeatureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class FeatureService
    {
        public bool CreateFeature(FeatureCreate model)
        {
            var entity = new Genre()
            {
                Name = model.Name,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Feature> GetFeatures()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Features.ToList();
            }
        }

        public Feature GetFeatureById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Features.Find(id);

                return entity;
            }
        }

        public bool FeatureUpdate(int id, FeatureUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Features.Find(id);
                
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool FeatureDelete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Features.Find(id);

                ctx.Features.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
