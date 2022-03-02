using GameFinder.Data;
using GameFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class PublisherService
    {
        public bool CreatePublisher(PublisherCreate model)
        {
            var entity = new Publisher()
            {
                Name = model.Name,
                Description = model.Description,
                Link = model.Link
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Publishers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PublisherListItem> GetPublishers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Publishers.Select(p => new PublisherListItem()
                {
                    PublisherId = p.PublisherId,
                    Name = p.Name,
                });

                return query.ToList();
            }
        }

        public PublisherDetail GetPublisherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers.Find(id);

                return new PublisherDetail()
                {
                    PublisherId = entity.PublisherId,
                    Name = entity.Name,
                    Description = entity.Description,
                    Link = entity.Link
                };
            }
        }

        public bool UpdatePublisher(int id, PublisherUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers.Find(id);

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Link = model.Link;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePublisher(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers.Find(id);

                ctx.Publishers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
