using GameFinder.Data;
using GameFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class DeveloperService
    {
        public bool CreateDeveloper(DeveloperCreate model)
        {
            var entity = new Developer()
            {
                Name = model.Name,
                Description = model.Description,
                Link = model.Link
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Developers.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DeveloperListItem> GetDevelopers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Developers.Select(d => new DeveloperListItem()
                {
                    DeveloperId = d.DeveloperId,
                    Name = d.Name,
                });

                return query.ToList();
            }
        }

        public DeveloperDetail GetDeveloperById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dev = ctx.Developers.Find(id);

                return new DeveloperDetail()
                {
                    DeveloperId = dev.DeveloperId,
                    Name = dev.Name,
                    Description = dev.Description,
                    Link = dev.Link
                };
            }
        }

        public bool UpdateDeveloper(int id, DeveloperUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dev = ctx.Developers.Find(id);

                dev.Name = model.Name;
                dev.Description = model.Description;
                dev.Link = model.Link;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDeveloper(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var dev = ctx.Developers.Find(id);

                ctx.Developers.Remove(dev);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
