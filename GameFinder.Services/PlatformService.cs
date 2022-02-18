using GameFinder.Data;
using GameFinder.Models.PlatformModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class PlatformService
    {
        public bool CreatePlatform(PlatformCreate model)
        {
            var platform = new Platform()
            {
                Name = model.Name,
                Manufacturer = model.Manufacturer,
                Medium = model.Medium,
                LaunchDate = model.LaunchDate,
                DiscontinueDate = model.DiscontinueDate
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Platforms.Add(platform);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlatformListItem> GetPlatforms()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Platforms.Select(p => new PlatformListItem()
                {
                    PlatformId = p.PlatformId,
                    Name = p.Name,
                    Manufacturer = p.Manufacturer
                });

                return query.ToList();
            }
        }

        public PlatformDetail GetPlatformById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Platforms.Find(id);
                
                var detail = new PlatformDetail()
                {
                    PlatformId = query.PlatformId,
                    Name = query.Name,
                    Manufacturer = query.Manufacturer,
                    Medium = query.Medium,
                    LaunchDate = query.LaunchDate,
                    DiscontinueDate = query.DiscontinueDate
                };

                return detail;
            }
        }

        public bool UpdatePlatform(int id, PlatformUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Platforms.Find(id);

                entity.Name = model.Name;
                entity.Manufacturer = model.Manufacturer;
                entity.Medium = model.Medium;
                entity.LaunchDate = model.LaunchDate;
                entity.DiscontinueDate = model.DiscontinueDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlatform(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Platforms.Find(id);

                ctx.Platforms.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
