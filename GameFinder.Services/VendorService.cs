using GameFinder.Data;
using GameFinder.Models.VendorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFinder.Services
{
    public class VendorService
    {
        public bool CreateVendor(VendorCreate model)
        {
            var entity = new Vendor()
            {
                Name = model.Name,
                Description = model.Description,
                Link = model.Link,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vendors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VendorListItem> GetVendors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Vendors.Select(v => new VendorListItem()
                {
                    VendorId = v.VendorId,
                    Name = v.Name
                });

                return query.ToList();
            }
        }

        public VendorDetail GetVendorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Vendors.Find(id);
                var detail = new VendorDetail()
                {
                    VendorId=entity.VendorId,
                    Name=entity.Name,
                    Description=entity.Description,
                    Link=entity.Link
                };

                return detail;
            }
        }

        public bool VendorUpdate(int id, VendorUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Vendors.Find(id);

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Link = model.Link;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVendor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Vendors.Find(id);

                ctx.Vendors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
