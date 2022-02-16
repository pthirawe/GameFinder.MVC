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
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Developer()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Link = model.Link
                };
                ctx.Developers.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
