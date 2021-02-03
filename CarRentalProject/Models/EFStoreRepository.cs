using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;

        public EFStoreRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Car> Cars => context.Cars;

        public void CreateProduct(Car p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void DeleteProduct(Car p)
        {
            context.Remove(p);
            context.SaveChanges();
        }

        public void SaveProduct(Car p)
        {
            context.SaveChanges();
        }
    }
}

