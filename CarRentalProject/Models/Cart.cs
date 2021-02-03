using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalProject.Models
{
    public class Cart
    {

        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Car Car, int quantity)
        {
            CartLine line = Lines
                .Where(p => p.Car.CarID == Car.CarID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Car = Car,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Car car) =>
            Lines.RemoveAll(l => l.Car.CarID == car.CarID);

        public decimal ComputeTotalValue() =>
            Lines.Sum(e => e.Car.Price * e.Quantity);

        public virtual void Clear() => Lines.Clear();
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Car Car { get; set; }
        public int Quantity { get; set; }
    }
}
