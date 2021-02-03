using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Models
{
    public interface IStoreRepository
    {

        IQueryable<Car> Cars { get; }

        void SaveProduct(Car p);
        void CreateProduct(Car p);
        void DeleteProduct(Car p);
    }
}