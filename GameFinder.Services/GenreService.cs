using GameFinder.Data;
using GameFinder.Models.GenreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class GenreService
    {
        public bool CreateGenre(GenreCreate model)
        {
            var entity = new Genre()
            {
                Name = model.Name,
                Description = model.Description
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GenreListItem> GetGenres()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var list = ctx.Genres.Select(g => new GenreListItem()
                {
                    GenreID = g.GenreId,
                    Name = g.Name
                });

                return list.ToList();
            }
        }

        public GenreDetail GetGenreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Genres.Find(id);
                var detail = new GenreDetail()
                {
                    GenreId = entity.GenreId,
                    Name = entity.Name,
                    Description = entity.Description
                };

                return detail;
            }
        }

        public bool GenreUpdate(int id, GenreUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Genres.Find(id);
                
                entity.Name = model.Name;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool GenreDelete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Genres.Find(id);

                ctx.Genres.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
