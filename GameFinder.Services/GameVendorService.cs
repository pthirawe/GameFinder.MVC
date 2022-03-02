using GameFinder.Data;
using GameFinder.Models.JoiningModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class GameVendorService
    {
        public bool CreateGameVendor(GameVendorCreate model)
        {
            var entity = new GameVendor()
            {
                GameId = model.GameId,
                VendorId = model.VendorId,
                Price = model.Price,
                Link = model.Link
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.GameVendors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameVendorListItem> GetGameVendors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.GameVendors.Select(gv => new GameVendorListItem()
                {
                    GameId = gv.GameId,
                    Title = gv.Game.Title,
                    VendorId = gv.VendorId,
                    VendorName = gv.Vendor.Name
                });

                return query.ToList();
            }
        }

        public GameVendorDetail GetGameVendorByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameVendors.Find(id);
                var detail = new GameVendorDetail()
                {
                    GameId=entity.GameId,
                    Title = entity.Game.Title,
                    VendorId=entity.VendorId,
                    VendorName=entity.Vendor.Name,
                    Price = entity.Price,
                    Link=entity.Link
                };

                return detail;
            }
        }

        public bool UpdateGameVendor(int id, GameVendorUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameVendors.Find(id);
                
                entity.GameId = model.GameId;
                entity.VendorId = model.VendorId;
                entity.Price = model.Price;
                entity.Link = model.Link;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGameVendor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameVendors.Find(id);

                ctx.GameVendors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
